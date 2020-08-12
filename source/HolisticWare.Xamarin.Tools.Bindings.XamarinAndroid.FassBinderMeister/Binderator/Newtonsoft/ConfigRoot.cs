using System.Collections.Generic;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    public class ConfigRoot
    {
        [JsonProperty("mavenRepositoryType")]
        public string MavenRepositoryType { get; set; }

        [JsonProperty("slnFile")]
        public string SlnFile { get; set; }

        [JsonProperty("additionalProjects")]
        public List<string> AdditionalProjects { get; set; }

        [JsonProperty("templates")]
        public List<Template> Templates { get; set; }

        [JsonProperty("artifacts")]
        public List<Artifact> Artifacts { get; set; }
    }
}
