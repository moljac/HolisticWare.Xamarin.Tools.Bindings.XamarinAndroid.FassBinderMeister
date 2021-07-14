using System;
namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype.Search
{
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Params
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

    public class ResponseHeader
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("QTime")]
        public int QTime { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }
    }

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

    public class Response
    {
        [JsonPropertyName("numFound")]
        public int NumFound { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("docs")]
        public List<Doc> Docs { get; set; }
    }

    public class Spellcheck
    {
        [JsonPropertyName("suggestions")]
        public List<object> Suggestions { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("responseHeader")]
        public ResponseHeader ResponseHeader { get; set; }

        [JsonPropertyName("response")]
        public Response Response { get; set; }

        [JsonPropertyName("spellcheck")]
        public Spellcheck Spellcheck { get; set; }
    }

}
