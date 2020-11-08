using System.Collections.Generic;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    public partial class ConfigRoot
    {
        public string MavenRepositoryType
        {
            get;
            set;
        }

        public string SlnFile
        {
            get;
            set;
        }

        public List<string> AdditionalProjects
        {
            get;
            set;
        }

        public List<Template> Templates
        {
            get;
            set;
        }

        public List<Artifact> Artifacts
        {
            get;
            set;
        }
    }
}
