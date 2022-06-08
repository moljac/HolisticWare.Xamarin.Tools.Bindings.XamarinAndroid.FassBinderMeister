using Newtonsoft.Json; 
using System.Collections.Generic; 
using System; 
namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated{ 

    public class CatalogEntry
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string authors { get; set; }
        public List<DependencyGroup> dependencyGroups { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string licenseExpression { get; set; }
        public string licenseUrl { get; set; }
        public bool listed { get; set; }
        public string minClientVersion { get; set; }
        public string packageContent { get; set; }
        public string projectUrl { get; set; }
        public DateTime published { get; set; }
        public bool requireLicenseAcceptance { get; set; }
        public string summary { get; set; }
        public List<string> tags { get; set; }
        public string title { get; set; }
        public string version { get; set; }
    }

}