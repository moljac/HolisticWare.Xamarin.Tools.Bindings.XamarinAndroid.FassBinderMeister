using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class Repository
    {
        public static partial class Utilities
        {
            public static async
                Task<SearchData>
                                                Search
                                                        (
                                                            string search_term,
                                                            int search_results_count = 20
                                                        )
            {
                SearchData result = null;

                Maven.MasterIndex master_index = await GetMasterIndexAsync();
                master_index.GetGroupsAsync();

                Repository.MasterIndexDefault = master_index;

                result = new SearchData();
                result.Artifacts = new List<Maven.ArtifactUnversioned>();

                foreach(Maven.Group g in master_index.Groups)
                {
                    ArtifactUnversioned a = new ArtifactUnversioned()
                    {
                        Group = g,
                        GroupId = g.Id,
                    };

                    result.Artifacts.Add(a);
                }

                return result;
            }


            public static async
                Task<Maven.MasterIndex>
                                                GetMasterIndexAsync
                                                        (
                                                        )
            {
                MasterIndex result = null;

                string url = Repository.UrlMasterIndexDefault.AbsoluteUri;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    result = new MasterIndex()
                    {
                        Repository = new Repositories.Google.Repository(),
                        Content = await MavenClient.HttpClient.GetStringContentAsync(url),
                    };

                    IEnumerable<string> groups_textual = await result.GetGroupsTextualAsync();
                    result.GroupsTextual = groups_textual;

                    IEnumerable<Maven.Group> groups = await result.GetGroupsAsync();
                    result.Groups = groups;
                }

                MasterIndexDefault = result;

                return result;
            }
        }
    }
}
