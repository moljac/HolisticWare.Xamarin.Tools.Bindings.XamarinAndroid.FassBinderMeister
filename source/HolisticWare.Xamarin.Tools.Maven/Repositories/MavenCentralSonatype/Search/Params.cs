using System;
using System.Text.Json.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype.Search
{
    public partial class Params
    {
        [JsonPropertyName("q")]
        public string Q { get; set; }

        [JsonPropertyName("core")]
        public string Core { get; set; }

        [JsonPropertyName("defType")]
        public string DefType { get; set; }

        [JsonPropertyName("indent")]
        public string Indent { get; set; }

        [JsonPropertyName("qf")]
        public string Qf { get; set; }

        [JsonPropertyName("spellcheck")]
        public string Spellcheck { get; set; }

        [JsonPropertyName("fl")]
        public string Fl { get; set; }

        [JsonPropertyName("start")]
        public string Start { get; set; }

        [JsonPropertyName("sort")]
        public string Sort { get; set; }

        [JsonPropertyName("spellcheck.count")]
        public string SpellcheckCount { get; set; }

        [JsonPropertyName("rows")]
        public string Rows { get; set; }

        [JsonPropertyName("wt")]
        public string Wt { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
