namespace HolisticWare.Xamarin.Tools.ComponentGovernance.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;

    public partial class ComponentGovernanceManifest
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-character-casing
        public static
            JsonSerializerOptions
                                        Options
        {
            get;

            set;
        } = new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            };

        public Registration[] Registrations { get; set; }

        public long Version { get; set; }
    }

    public partial class Registration
    {
        public Component Component { get; set; }

        public string License { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string[] LicenseDetail { get; set; }
    }

    public partial class Component
    {
        public string Type { get; set; }

        public Maven Maven { get; set; }

        public Git Git { get; set; }
    }

    public partial class Maven
    {
        public string ArtifactId { get; set; }

        public string GroupId { get; set; }

        public string Version { get; set; }

        public string NuGetId { get; set; }
        
        public string NuGetVersion { get; set; }
    }


    public partial class Git
    {
        public Uri RepositoryUrl { get; set; }

        public string CommitHash { get; set; }

        public string Name { get; set; }
    }
}
