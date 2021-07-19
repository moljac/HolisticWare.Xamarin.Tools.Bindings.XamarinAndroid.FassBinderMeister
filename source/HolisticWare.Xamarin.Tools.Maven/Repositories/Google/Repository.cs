using System;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public class Repository : Maven.Repository
    {
        public Repository() : base()
        {
            this.UrlRoot = Repositories.Google.Repository.UrlRootDefault;
            this.UrlMasterIndex = Repositories.Google.Repository.UrlMasterIndexDefault;

            return;
        }

        static Repository()
        {
            // Google
            // root url
            url_root_default = new Uri($"https://dl.google.com/android/maven2");

            // Google
            // search url - not available, search must be built/implemented
            url_search_default = null;

            // Google
            // master index - must be built/implemented
            url_master_index_default = new Uri($"{UrlRootDefault.AbsolutePath}/master-index.xml");

            return;
        }

        public static Uri UrlRootDefault
        {
            get
            {
                return url_root_default;
            }
            set
            {
                url_root_default = value;

                return;
            }
        }

        public static new Uri UrlMasterIndexDefault
        {
            get
            {
                return url_master_index_default;
            }
            set
            {
                url_master_index_default = value;

                return;
            }
        }

        public static MasterIndex MasterIndexDefault
        {
            get
            {
                return master_index_default;
            }
            set
            {
                master_index_default = value;

                return;
            }
        }

        public Uri UrlRoot
        {
            get
            {
                return url_root;
            }
            set
            {
                url_root = value;

                return;
            }
        }

        public Uri UrlMasterIndex
        {
            get
            {
                return url_master_index;
            }
            set
            {
                url_master_index = value;

                return;
            }
        }

        public MasterIndex MasterIndex
        {
            get
            {
                return master_index;
            }
            set
            {
                master_index = value;

                return;
            }
        }

        public static class Utilities
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
                    string content = await MavenClient.HttpClient.GetStringContentAsync(url);

                    Repository.MasterIndexDefault = new MasterIndex()
                    {
                        Content = content
                    };
                    await Repository.MasterIndexDefault.GetGroupsAsync();
                }

                string xml = Repository.MasterIndexDefault.Content;

                return result;
            }
        }

    }
}
