using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    public class GitHubClient
    {
        // HttpClient is intended to be instantiated once per application,
        // rather than per-use. See Remarks.
        static readonly HttpClient http_client = new HttpClient();

        public GitHubClient()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user_organization"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        ///
        // https://api.github.com/repos/xamarin/AndroidX/tags
        // https://api.github.com/repos/xamarin/Essentials/tags
        public async Task<IEnumerable<Tag>> Tags(string user_organization, string repository)
        {
            string url = $"https://api.github.com/repos/{user_organization}/{repository}/tags";

            IEnumerable<Tag> tags = null;

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                /*
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string response_body = await response.Content.ReadAsStringAsync();
                */
                // new helper method below
                http_client.DefaultRequestHeaders
                                .Add
                                    (
                                        "User-Agent",
                                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                                    )
                                /*
                                .UserAgent.Add(new ProductInfoHeaderValue("yourAppName", "yourVersionNumber"))
                                */
                                ;
                string response_string_json = await http_client.GetStringAsync(url);
                //tags = Tag.FromJson(response_string_json);
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
