using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class Context
    {
        [JsonProperty("@vocab")]
        public Uri Vocab { get; set; }

        [JsonProperty("catalog")]
        public Uri Catalog { get; set; }

        [JsonProperty("xsd")]
        public Uri Xsd { get; set; }

        [JsonProperty("items")]
        public Dependencies Items { get; set; }

        [JsonProperty("commitTimeStamp")]
        public CommitTimeStamp CommitTimeStamp { get; set; }

        [JsonProperty("commitId")]
        public CommitId CommitId { get; set; }

        [JsonProperty("count")]
        public CommitId Count { get; set; }

        [JsonProperty("parent")]
        public CommitTimeStamp Parent { get; set; }

        [JsonProperty("tags")]
        public Dependencies Tags { get; set; }

        [JsonProperty("reasons")]
        public Reasons Reasons { get; set; }

        [JsonProperty("packageTargetFrameworks")]
        public Dependencies PackageTargetFrameworks { get; set; }

        [JsonProperty("dependencyGroups")]
        public Dependencies DependencyGroups { get; set; }

        [JsonProperty("dependencies")]
        public Dependencies Dependencies { get; set; }

        [JsonProperty("packageContent")]
        public PackageContent PackageContent { get; set; }

        [JsonProperty("published")]
        public PackageContent Published { get; set; }

        [JsonProperty("registration")]
        public PackageContent Registration { get; set; }
    }
}

