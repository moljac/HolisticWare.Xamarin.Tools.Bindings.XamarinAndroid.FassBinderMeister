using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{
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

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType.JSON
{
        public partial class Artifact
    {
        [JsonProperty("groupId")]
        public string GroupId
        {
            get;
            set;
        }

        [JsonProperty("artifactId")]
        public string ArtifactId
        {
            get;
            set;
        }

        [JsonProperty("version")]
        public string Version
        {
            get;
            set;
        }

        [JsonProperty("nugetId")]
        public string NugetId
        {
            get;
            set;
        }

        [JsonProperty("dependencyOnly")]
        public bool DependencyOnly
        {
            get;
            set;
        }

        [JsonProperty("nugetVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string NugetVersion
        {
            get;
            set;
        }
    }
}
