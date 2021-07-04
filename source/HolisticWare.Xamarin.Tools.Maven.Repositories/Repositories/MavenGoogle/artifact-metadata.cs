using System.Collections.Generic;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Maven.RepositoriesArtifact.Metadata.Generated
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Artifact
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }

    public class Root
    {
        [JsonProperty("artifacts")]
        public List<Artifact> Artifacts { get; set; }
    }

}