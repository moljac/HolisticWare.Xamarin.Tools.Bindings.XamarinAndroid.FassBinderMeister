using Newtonsoft.Json; 
using System.Collections.Generic; 
using System; 
namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated{ 

    public class Item
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string commitId { get; set; }
        public DateTime commitTimeStamp { get; set; }
        public int count { get; set; }
        public List<Item> items { get; set; }
        public string parent { get; set; }
        public string lower { get; set; }
        public string upper { get; set; }
        public CatalogEntry catalogEntry { get; set; }
        public string packageContent { get; set; }
        public string registration { get; set; }

        [JsonProperty("@container")]
        public string Container { get; set; }
    }

}