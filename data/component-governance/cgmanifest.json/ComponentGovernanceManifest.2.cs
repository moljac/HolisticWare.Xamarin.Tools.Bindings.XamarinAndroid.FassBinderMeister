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
        [JsonProperty("Component")]
        public Component Component { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Maven")]
        public Maven Maven { get; set; }
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
}
