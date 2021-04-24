using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class MavenRepositoryMavenCentral : MavenRepository
    {
        public MavenRepositoryMavenCentral() : base()
        {
            defalt_url = "";
            defalt_url_master_index = null;

            return;
        }

        protected string defalt_url = null;

        public override string DefaultUrl
        {
            get
            {
                return defalt_url;
            }
            set
            {
                defalt_url = value;
            }
        }

        protected string defalt_url_master_index = null;

        public override string DefaultUrlMasterIndex
        {
            get
            {
                return defalt_url_master_index;
            }
            set
            {
                defalt_url_master_index = value;
            }
        }

        protected MasterIndex master_index = null;

        public override MasterIndex MasterIndex
        {
            get
            {
                return master_index;
            }
            set
            {
                master_index = value;
            }
        }
    }
}
