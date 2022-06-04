using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class Root
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public string[] Type { get; set; }

        [JsonProperty("commitId")]
        public Guid CommitId { get; set; }

        [JsonProperty("commitTimeStamp")]
        public DateTimeOffset CommitTimeStamp { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("@context")]
        public Context Context { get; set; }
    }
}

