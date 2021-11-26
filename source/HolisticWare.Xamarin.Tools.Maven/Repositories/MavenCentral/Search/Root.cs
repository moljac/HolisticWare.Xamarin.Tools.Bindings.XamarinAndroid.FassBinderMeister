using System;
using System.Text.Json.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral.Search
{
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
