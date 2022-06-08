using Newtonsoft.Json; 
using System.Collections.Generic; 
using System; 
namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated{ 

    public class Root
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public List<string> Type { get; set; }
        public string commitId { get; set; }
        public DateTime commitTimeStamp { get; set; }
        public int count { get; set; }
        public List<Item> items { get; set; }

        [JsonProperty("@context")]
        public Context Context { get; set; }
    }

}