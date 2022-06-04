using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class DependencyGroup
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public DependencyGroupType Type { get; set; }

        [JsonProperty("dependencies")]
        public Dependency[] Dependencies { get; set; }

        [JsonProperty("targetFramework")]
        public TargetFramework TargetFramework { get; set; }
    }
}

