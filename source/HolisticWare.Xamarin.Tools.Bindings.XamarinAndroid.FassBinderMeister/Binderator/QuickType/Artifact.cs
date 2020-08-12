﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Artifact
    {
        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("artifactId")]
        public string ArtifactId { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("nugetId")]
        public string NugetId { get; set; }

        [JsonProperty("dependencyOnly")]
        public bool DependencyOnly { get; set; }

        [JsonProperty("nugetVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string NugetVersion { get; set; }
    }
}