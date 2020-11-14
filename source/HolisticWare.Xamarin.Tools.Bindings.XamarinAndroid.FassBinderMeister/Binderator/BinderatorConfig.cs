using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HolisticWare.Xamarin.Tools.GitHub;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator
{
    public class BinderatorConfig
    {
        static System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public IEnumerable<QuickType.ConfigRoot> Config
        {
            get;
            set;
        }

        public async
            Task<Dictionary<string, IEnumerable<Tag>>>
                    DownloadDefaultBinderatorConfigsAsync
                                                (
                                                )
        {
            Dictionary<string, IEnumerable<Tag>> binderator_configs = null;

            foreach (var rt in BinderatorConfigUrls.RepoTags)
            {
                //binderator_configs = await DownloadBinderatorConfigsAsync(rt.repo, rt.tag);

                if (rt.repo == "AndroidX")
                {
                }
            }

            return binderator_configs;
        }

        public async
            Task<Dictionary<string, IEnumerable<(Tag, string)>>>
                                    DownloadBinderatorConfigsAsync
                                                            (
                                                                string user_org,
                                                                string repo,
                                                                string tag = null
                                                            )
        {
            if (string.IsNullOrEmpty(user_org))
            {
                return null;
            }

            List<string> repos = null;
            if (string.IsNullOrEmpty(repo))
            {
                repos = new List<string>
                {
                    "AndroidX",
                    "GooglePlayServiceComponents"
                };
            }

            Dictionary<string, IEnumerable<Tag>> tags_for_repo = new Dictionary<string, IEnumerable<Tag>>();
            Dictionary<string, IEnumerable<(Tag, string)>> tags_for_repo_content = null;
            GitHubClient gc = new GitHubClient();

            if (string.IsNullOrEmpty(tag))
            {
                tags_for_repo.Add
                                (
                                    repo,
                                    await gc.Tags(user_org, repository: repo)
                                );
            }
            else
            {
                tags_for_repo.Add
                                (
                                    repo,
                                    await gc.Tags(user_org, repository: repo, tag)
                                );
            }

            tags_for_repo_content = new Dictionary<string, IEnumerable<(Tag, string)>>();

            foreach (string r in tags_for_repo.Keys)
            {
                List<(Tag, string)> list_tag_content = new List<(Tag, string)>();
                foreach (Tag t in tags_for_repo[r])
                {
                    string url_github = $"https://raw.githubusercontent.com/{user_org}/{r}/{t.Name}/config.json";
                    System.Net.Http.HttpResponseMessage result = await client.GetAsync(url_github);
                    string content = await result.Content.ReadAsStringAsync();
                    list_tag_content.Add((t, content));                    
                }

                tags_for_repo_content.Add(r, list_tag_content);
            }

            return tags_for_repo_content;
        }

    }
}
