using System;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public class Repository : Maven.Repository
    {
        public Repository() : base()
        {
            this.UrlRoot = Repositories.Google.Repository.UrlRootDefault;

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

    }
}
