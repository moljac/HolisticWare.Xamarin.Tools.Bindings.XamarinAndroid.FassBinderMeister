using System;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public class Repository : Maven.Repository
    {
        public Repository() : base()
        {
            this.UrlRoot = Repositories.MavenCentralSonatype.Repository.UrlRootDefault;

            return;
        }

        static Repository()
        {
            url_root_default = new Uri($"https://repo1.maven.org/maven2");

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
    }
}
