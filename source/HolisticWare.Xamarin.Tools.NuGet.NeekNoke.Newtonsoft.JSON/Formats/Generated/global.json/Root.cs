namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Temperatures
    {
        [JsonProperty("sdk", NullValueHandling = NullValueHandling.Ignore)]
        public Sdk Sdk { get; set; }

        [JsonProperty("msbuild-sdks", NullValueHandling = NullValueHandling.Ignore)]
        public MsbuildSdks MsbuildSdks { get; set; }
    }

    public partial class MsbuildSdks
    {
        [JsonProperty("MSBuild.Sdk.Extras", NullValueHandling = NullValueHandling.Ignore)]
        public string MsBuildSdkExtras { get; set; }

        [JsonProperty("Microsoft.Build.Traversal", NullValueHandling = NullValueHandling.Ignore)]
        public string MicrosoftBuildTraversal { get; set; }

        [JsonProperty("Microsoft.Build.NoTargets", NullValueHandling = NullValueHandling.Ignore)]
        public string MicrosoftBuildNoTargets { get; set; }

        [JsonProperty("Xamarin.Legacy.Sdk", NullValueHandling = NullValueHandling.Ignore)]
        public string XamarinLegacySdk { get; set; }
    }

    public partial class Sdk
    {
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("rollForward", NullValueHandling = NullValueHandling.Ignore)]
        public string RollForward { get; set; }

        [JsonProperty("allowPrerelease", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllowPrerelease { get; set; }
    }
}