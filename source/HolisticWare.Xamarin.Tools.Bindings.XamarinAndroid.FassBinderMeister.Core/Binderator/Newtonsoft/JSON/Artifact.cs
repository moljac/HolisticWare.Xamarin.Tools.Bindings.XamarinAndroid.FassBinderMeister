using Newtonsoft.Json;

using Microsoft.AspNetCore.Mvc;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.metadatatypeattribute?view=netcore-3.1
    // https://github.com/dotnet/standard/issues/450
    // https://www.nuget.org/packages/System.ComponentModel.Annotations/4.4.0

    // POCO class with Metadata for Buddy Class containing attributes
    // <PackageReference Include="Microsoft.AspNetCore.Mvc.DataAnnotations" Version="2.2.0" />
    // using Microsoft.AspNetCore.Mvc;
    [ModelMetadataType(typeof(JSON.Artifact))]
    public partial class Artifact
    {
        public static Artifact Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Artifact>(json);
        }

    }
}

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft.JSON
{
    public partial class Artifact
    {
        [JsonProperty("groupId", Order = 1)]
        public string GroupId
        {
            get;
            set;
        }

        [JsonProperty("artifactId", Order = 2)]
        public string ArtifactId
        {
            get;
            set;
        }

        [JsonProperty("version", Order = 3)]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty("nugetVersion", Order = 4)]
        public string NugetVersion
        {
            get;
            set;
        }

        [JsonProperty("nugetId", Order = 5)]
        public string NugetId
        {
            get;
            set;
        }

        [JsonProperty("dependencyOnly", Order = 6)]
        public bool DependencyOnly
        {
            get;
            set;
        }
    }
}