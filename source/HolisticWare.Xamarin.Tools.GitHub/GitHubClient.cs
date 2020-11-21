using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    public class GitHubClient
    {
        // HttpClient is intended to be instantiated once per application,
        // rather than per-use. See Remarks.
        static readonly HttpClient http_client = new HttpClient();

        public GitHubClient()
        {
            http_client.DefaultRequestHeaders
                            .Add
                                (
                                    "User-Agent",
                                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                                )
                            /*                             
                            .UserAgent.Add(new ProductInfoHeaderValue($"{github_app_name}", $"{version}"))
                            */
                            ;

            return;
        }


        public async
            Task<IEnumerable<Tag>>
                                    Tags
                                        (
                                            string user_organization,
                                            string repository,
                                            string tag
                                        )
        {
            string url = $"https://api.github.com/repos/{user_organization}/{repository}/tags/{tag}";

            IEnumerable<Tag> tags = null;

            try
            {
                /*
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string response_body = await response.Content.ReadAsStringAsync();
                */
                // new helper method below
                string response_string_json = await http_client.GetStringAsync(url);
                tags = GitHub.Tags.Deserialize(response_string_json).ToList();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            IEnumerable<Tag> tags_found = from t in tags
                                                where t.Name == tag
                                                select t
                                                ;

            return tags_found;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_organization"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        ///
        public async
            Task<IEnumerable<Tag>>
                                    Tags
                                        (
                                            string user_organization,
                                            string repository
                                        )
        {
            string url = $"https://api.github.com/repos/{user_organization}/{repository}/tags";

            IEnumerable<Tag> tags = null;

            try
            {
                /*
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string response_body = await response.Content.ReadAsStringAsync();
                */
                // new helper method below
                string response_string_json = await http_client.GetStringAsync(url);
                tags = GitHub.Tags.Deserialize(response_string_json);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return tags;
        }
    }
}
