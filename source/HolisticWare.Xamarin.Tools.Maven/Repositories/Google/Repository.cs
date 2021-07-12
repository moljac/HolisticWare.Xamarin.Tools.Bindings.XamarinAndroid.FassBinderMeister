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
            url_root_default = $"https://dl.google.com/android/maven2";
            url_master_index_default = $"{UrlRootDefault}/master-index.xml";

            return;
        }

        public static string UrlRootDefault
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

        public static new string UrlMasterIndexDefault
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

        public string UrlRoot
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

        public string UrlMasterIndex
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

            string url = this.UrlMasterIndex;

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
