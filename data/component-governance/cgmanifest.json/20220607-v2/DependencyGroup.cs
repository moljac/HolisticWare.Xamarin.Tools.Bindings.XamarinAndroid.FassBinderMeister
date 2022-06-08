using Newtonsoft.Json; 
using System.Collections.Generic; 
namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated{ 

    public class DependencyGroup
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public List<Dependency> dependencies { get; set; }
        public string targetFramework { get; set; }

        [JsonProperty("@container")]
        public string Container { get; set; }
    }

}