using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public partial class SearchData : Maven.SearchData
    {
        public virtual
            List<Maven.Artifact>
                                                Artifacts
        {
            get
            {
                return artifacts;
            }

            set
            {
                artifacts = value;

                return;
            }
        }
    }
}
