using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    public partial class CatalogEntry
    {
        [JsonProperty("@id")]
        public Uri Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("authors")]
        public string Authors { get; set; }

        [JsonProperty("dependencyGroups")]
        public DependencyGroup[] DependencyGroups { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("id")]
        public string CatalogEntryId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("licenseExpression")]
        public string LicenseExpression { get; set; }

        [JsonProperty("licenseUrl")]
        public Uri LicenseUrl { get; set; }

        [JsonProperty("listed")]
        public bool Listed { get; set; }

        [JsonProperty("minClientVersion")]
        public string MinClientVersion { get; set; }

        [JsonProperty("packageContent")]
        public Uri PackageContent { get; set; }

        [JsonProperty("projectUrl")]
        public Uri ProjectUrl { get; set; }

        [JsonProperty("published")]
        public DateTimeOffset Published { get; set; }

        [JsonProperty("requireLicenseAcceptance")]
        public bool RequireLicenseAcceptance { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}

