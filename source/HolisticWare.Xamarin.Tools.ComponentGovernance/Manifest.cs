namespace HolisticWare.Xamarin.Tools.ComponentGovernance
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;

    public partial class Manifest
    {
        public Manifest()
        {
            MappingMavenArtifact2NuGetPackage = new List
                                                    <
                                                        (
                                                            string ArtifactIdFullyQualified,
                                                            string ArtifactVersion,
                                                            string NugetId,
                                                            string NugetVersion
                                                        )
                                                    >();

            return;
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-character-casing
        public static
            JsonSerializerOptions
                                            Options
        {
            get;

            set;
        } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };

        protected
            List
            <
                (
                    string ArtifactIdFullyQualified,  // Fully Qualified ArtifactId ($"{GroupId}:{ArtifactId}")
                    string ArtifactVersion,
                    string NugetId,
                    string NugetVersion
                )
            >
            mapping_maven_artifact_2_nuget_package;

        public
            List
            <
                (
                    string ArtifactIdFullyQualified,  // Fully Qualified ArtifactId ($"{GroupId}:{ArtifactId}")
                    string ArtifactVersion,
                    string NugetId,
                    string NugetVersion
                )
            >
                                            MappingMavenArtifact2NuGetPackage
        {
            get
            {
                return this.mapping_maven_artifact_2_nuget_package;
            }

            set
            {
                this.mapping_maven_artifact_2_nuget_package = value;

                List<Generated.Registration> registrations = new List<Generated.Registration>();

                foreach (var m in this.mapping_maven_artifact_2_nuget_package)
                {
                    string[] artifact_parts = m.ArtifactIdFullyQualified.Split(new char[] { ':' });

                    string fq_id_v = $"{m.ArtifactIdFullyQualified}:{m.ArtifactVersion}";
                    
                    Generated.Registration r = new Generated.Registration
                    {
                        Component = new Generated.Component
                        {
                            Type    = "Maven",
                            Maven   = new Generated.Maven
                                                    {
                                                        ArtifactId      = artifact_parts[1],
                                                        GroupId         = artifact_parts[0],
                                                        Version         = m.ArtifactVersion,
                                                        NuGetId         = m.NugetId,
                                                        NuGetVersion    = m.NugetVersion,
                                                    },
                        },
                        Description     = Defaults.Description,
                        License         = Defaults.VersionBasedOnFullyQualifiedArtifactIdDelegate(fq_id_v),
                        LicenseDetail   = Defaults.LicenseDetail
                    };

                    registrations.Add(r);
                }

                ComponentGovernanceManifest = new Generated.ComponentGovernanceManifest()
                {
                    Registrations = registrations.ToArray(),
                    Version = Defaults.Version,
                };

                return;
            }
        }

        public
            Generated.ComponentGovernanceManifest
                                            ComponentGovernanceManifest
        {
            get;
            set;
        }

        public
            void
                                            Save
                                                (
                                                    string filename
                                                )
        {
            string json = JsonSerializer.Serialize
                                            (
                                                this.ComponentGovernanceManifest,
                                                Manifest.Options
                                            );

            System.IO.File.WriteAllText(filename, json);

            return;
        }
    }
}
