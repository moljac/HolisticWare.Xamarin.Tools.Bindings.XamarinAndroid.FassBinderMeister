using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
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
