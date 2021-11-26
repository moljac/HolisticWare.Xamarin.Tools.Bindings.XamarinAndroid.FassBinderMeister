using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral.Search
{
    public class Doc
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("g")]
        public string G { get; set; }

        [JsonPropertyName("a")]
        public string A { get; set; }

        [JsonPropertyName("latestVersion")]
        public string LatestVersion { get; set; }

        [JsonPropertyName("repositoryId")]
        public string RepositoryId { get; set; }

        [JsonPropertyName("p")]
        public string P { get; set; }

        [JsonPropertyName("timestamp")]
        public object Timestamp { get; set; }

        [JsonPropertyName("versionCount")]
        public int VersionCount { get; set; }

        [JsonPropertyName("text")]
        public List<string> Text { get; set; }

        [JsonPropertyName("ec")]
        public List<string> Ec { get; set; }
    }
}
