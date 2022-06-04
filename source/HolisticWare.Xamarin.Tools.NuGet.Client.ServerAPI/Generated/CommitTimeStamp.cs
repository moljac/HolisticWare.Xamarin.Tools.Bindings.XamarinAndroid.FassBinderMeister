using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class CommitTimeStamp
    {
        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }
    }
}

