using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class SearchData
    {
        protected List<Artifact> artifacts;

        public virtual
            List<Artifact>
                                                Artifacts
        {
            get
            {
                return this.artifacts;
            }

            set
            {
                this.artifacts = value;

                return;
            }
        }
    }
}
