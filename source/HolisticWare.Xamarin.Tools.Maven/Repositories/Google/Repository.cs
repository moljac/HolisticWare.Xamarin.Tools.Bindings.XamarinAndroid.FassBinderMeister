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
            url_root_default = new Uri($"https://dl.google.com/android/maven2");
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


        public virtual async
            Task<MasterIndex>
                                            GetMasterIndexAsync
                                                    (
                                                    )
        {
            MasterIndex result = null;

            string url = this.UrlMasterIndex.AbsolutePath;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                using (System.Net.Http.HttpResponseMessage response = await MavenClient.HttpClient.GetAsync(url))
                {
                    using (System.Net.Http.HttpContent content = response.Content)
                    {
                        this.MasterIndex = new MasterIndex()
                        {
                            Content = await response.Content.ReadAsStringAsync(),
                        };
                        await this.MasterIndex.GetGroupsAsync();
                    }
                }
            }

            string xml = this.MasterIndex.Content;

            return result;
        }

        public virtual async
           Task<SearchData>
                                           Search
                                                   (
                                                       string search_term,
                                                       int search_results_count = 20
                                                   )
        {
            SearchData result = null;

            Uri url = Repository.UrlSearchDefault;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                using (System.Net.Http.HttpResponseMessage response = await MavenClient.HttpClient.GetAsync(url))
                {
                    using (System.Net.Http.HttpContent content = response.Content)
                    {
                        this.MasterIndex = new MasterIndex()
                        {
                            Content = await response.Content.ReadAsStringAsync(),
                        };
                        await this.MasterIndex.GetGroupsAsync();
                    }
                }
            }

            return result;
        }

    }
}
