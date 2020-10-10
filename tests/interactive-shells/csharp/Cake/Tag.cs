// Generated by https://quicktype.io

#if ! CAKE
namespace HolisticWare.Xamarin.Tools.GitHub
{
#endif
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("zipball_url")]
        public Uri ZipballUrl { get; set; }

        [JsonProperty("tarball_url")]
        public Uri TarballUrl { get; set; }

        [JsonProperty("commit")]
        public Commit Commit { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }
    }

    public partial class Commit
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public static partial class TagExtensions
    {
        public static Tag FromJson(string json) => JsonConvert.DeserializeObject<Tag>(json, Converter.Settings);
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

#if ! CAKE
}
#endif

    // public static class Serialize
    // {
    //     public static string ToJson(this Tag self) => JsonConvert.SerializeObject(self, Converter.Settings);
    // }