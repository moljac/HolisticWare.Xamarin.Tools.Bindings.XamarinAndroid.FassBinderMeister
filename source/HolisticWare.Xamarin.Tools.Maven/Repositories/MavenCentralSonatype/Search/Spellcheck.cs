using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype.Search
{
    public class Spellcheck
    {
        [JsonPropertyName("suggestions")]
        public List<object> Suggestions { get; set; }
    }
}
