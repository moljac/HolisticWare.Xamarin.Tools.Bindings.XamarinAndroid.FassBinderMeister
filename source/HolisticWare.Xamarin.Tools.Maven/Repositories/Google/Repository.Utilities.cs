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

                MasterIndex master_index = await GetMasterIndexAsync();

                return result;
            }


            public static async
                Task<MasterIndex>
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

                    IEnumerable<Group> groups = await result.GetGroupsAsync();
                }

                MasterIndexDefault = result;

                return result;
            }
        }
    }
}
