using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class Dependency
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public DependencyType Type { get; set; }

        [JsonProperty("id")]
        public Id DependencyId { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("registration")]
        public Uri Registration { get; set; }
    }
}

