using System;
using System.Text.Json.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral.Search
{
    public class ResponseHeader
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("QTime")]
        public int QTime { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }
    }
}
