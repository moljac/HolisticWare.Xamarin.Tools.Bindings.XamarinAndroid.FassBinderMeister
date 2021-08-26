using System.Collections.Generic;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google.Artifacts.Module.Generated
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Attributes
    {
        [JsonProperty("org.gradle.status")]
        public string OrgGradleStatus { get; set; }

        [JsonProperty("org.gradle.category")]
        public string OrgGradleCategory { get; set; }

        [JsonProperty("org.gradle.dependency.bundling")]
        public string OrgGradleDependencyBundling { get; set; }

        [JsonProperty("org.gradle.libraryelements")]
        public string OrgGradleLibraryelements { get; set; }

        [JsonProperty("org.gradle.usage")]
        public string OrgGradleUsage { get; set; }

        [JsonProperty("org.gradle.docstype")]
        public string OrgGradleDocstype { get; set; }
    }

    public class Component
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Gradle
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class CreatedBy
    {
        [JsonProperty("gradle")]
        public Gradle Gradle { get; set; }
    }

    public class Version
    {
        [JsonProperty("requires")]
        public string Requires { get; set; }
    }

    public class Dependency
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("version")]
        public Version Version { get; set; }
    }

    public class File
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("sha512")]
        public string Sha512 { get; set; }

        [JsonProperty("sha256")]
        public string Sha256 { get; set; }

        [JsonProperty("sha1")]
        public string Sha1 { get; set; }

        [JsonProperty("md5")]
        public string Md5 { get; set; }
    }

    public class Variant
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("dependencies")]
        public List<Dependency> Dependencies { get; set; }

        [JsonProperty("files")]
        public List<File> Files { get; set; }
    }

    public class Root
    {
        [JsonProperty("formatVersion")]
        public string FormatVersion { get; set; }

        [JsonProperty("component")]
        public Component Component { get; set; }

        [JsonProperty("createdBy")]
        public CreatedBy CreatedBy { get; set; }

        [JsonProperty("variants")]
        public List<Variant> Variants { get; set; }
    }

}