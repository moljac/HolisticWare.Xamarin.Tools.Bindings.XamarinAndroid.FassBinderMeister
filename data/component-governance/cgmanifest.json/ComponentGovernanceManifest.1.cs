namespace HolisticWare.Xamarin.Tools.ComponentGovernance.Generated
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ComponentGovernanceManifest
    {
        [JsonProperty("registrations")]
        public Registration[] Registrations { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }
    }

    public partial class Registration
    {
        [JsonProperty("component")]
        public Component Component { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("licenseDetail", NullValueHandling = NullValueHandling.Ignore)]
        public string[] LicenseDetail { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("git")]
        public Git Git { get; set; }
    }

    public partial class Git
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("repositoryUrl")]
        public Uri RepositoryUrl { get; set; }

        [JsonProperty("commitHash")]
        public string CommitHash { get; set; }
    }
}
