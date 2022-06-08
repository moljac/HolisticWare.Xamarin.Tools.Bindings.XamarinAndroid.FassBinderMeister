using Newtonsoft.Json; 
namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated{ 

    public class Dependencies
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@container")]
        public string Container { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
        public string id { get; set; }
        public string range { get; set; }
        public string registration { get; set; }
    }

}