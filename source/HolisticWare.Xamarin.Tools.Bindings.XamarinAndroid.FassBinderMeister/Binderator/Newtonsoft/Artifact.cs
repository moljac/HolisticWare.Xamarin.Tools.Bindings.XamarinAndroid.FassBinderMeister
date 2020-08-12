using System.Collections.Generic;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Artifact
    {
        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("artifactId")]
        public string ArtifactId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("nugetVersion")]
        public string NugetVersion { get; set; }

        [JsonProperty("nugetId")]
        public string NugetId { get; set; }

        [JsonProperty("dependencyOnly")]
        public bool DependencyOnly { get; set; }
    }

}
