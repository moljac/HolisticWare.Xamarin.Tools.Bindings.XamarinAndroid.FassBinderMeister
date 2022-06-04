using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class ItemItem
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("commitId")]
        public Guid CommitId { get; set; }

        [JsonProperty("commitTimeStamp")]
        public DateTimeOffset CommitTimeStamp { get; set; }

        [JsonProperty("catalogEntry")]
        public CatalogEntry CatalogEntry { get; set; }

        [JsonProperty("packageContent")]
        public Uri PackageContent { get; set; }

        [JsonProperty("registration")]
        public Uri Registration { get; set; }
    }
}

