using System;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class Repository : Maven.Repository
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
            url_master_index_default = new Uri($"{UrlRootDefault.AbsoluteUri}/master-index.xml");

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


    }
}
