using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolisticWare.Xamarin.Tools.Maven.POM;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ArtifactUnversioned : Maven.ArtifactUnversioned
    {
        public ArtifactUnversioned()
        {
            return;
        }

        public ArtifactUnversioned(string id_group, string id_artifact)
        {
            this.GroupId = id_group;
            this.ArtifactId = id_artifact;

            return;
        }

        public ArtifactUnversioned(string id_fully_qualified)
        {
            int idx = id_fully_qualified.LastIndexOf('.');

            this.GroupId = id_fully_qualified.Substring(0, idx);
            this.ArtifactId = id_fully_qualified.Substring(idx + 1, id_fully_qualified.Length - (idx + 1));

            return;
        }



    }
}
