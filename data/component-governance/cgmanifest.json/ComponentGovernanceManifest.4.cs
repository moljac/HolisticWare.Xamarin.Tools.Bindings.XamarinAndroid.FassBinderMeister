namespace HolisticWare.Xamarin.Tools.ComponentGovernance.Generated
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ComponentGovernanceManifest
    {
        [JsonProperty("Registrations")]
        public Registration[] Registrations { get; set; }

        [JsonProperty("Version")]
        public long Version { get; set; }
    }

    public partial class Registration
    {
        // [JsonProperty("component", NullValueHandling = NullValueHandling.Ignore)]
        // public ComponentClass RegistrationComponent { get; set; }

        [JsonProperty("Component", NullValueHandling = NullValueHandling.Ignore)]
        public Component Component { get; set; }

        [JsonProperty("license", NullValueHandling = NullValueHandling.Ignore)]
        public string License { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
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

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Maven")]
        public Maven Maven { get; set; }


        [JsonProperty("git")]
        public Git Git { get; set; }
    }

    public partial class Maven
    {
        [JsonProperty("ArtifactId")]
        public string ArtifactId { get; set; }

        [JsonProperty("GroupId")]
        public string GroupId { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("NuGetId")]
        public string NuGetId { get; set; }
    }


    public partial class Git
    {
        [JsonProperty("repositoryUrl")]
        public Uri RepositoryUrl { get; set; }

        [JsonProperty("commitHash")]
        public string CommitHash { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
