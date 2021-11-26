using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype.Search
{
    public class Response
    {
        [JsonPropertyName("numFound")]
        public int NumFound { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("docs")]
        public List<Doc> Docs { get; set; }
    }
}
