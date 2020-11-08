using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // POCO class with Metadata for Buddy Class containing attributes
    // <PackageReference Include="Microsoft.AspNetCore.Mvc.DataAnnotations" Version="2.2.0" />
    // using Microsoft.AspNetCore.Mvc;
    [ModelMetadataType(typeof(JSON.Artifact))]
    public partial class ConfigRoot
    {
        public static ConfigRoot Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<ConfigRoot>(json);
        }
    }
}

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft.JSON
{
    public partial class ConfigRoot
    {
        [JsonProperty("mavenRepositoryType")]
        public string MavenRepositoryType
        {
            get;
            set;
        }

        [JsonProperty("slnFile")]
        public string SlnFile
        {
            get;
            set;
        }

        [JsonProperty("additionalProjects")]
        public List<string> AdditionalProjects
        {
            get;
            set;
        }

        [JsonProperty("templates")]
        public List<Template> Templates
        {
            get;
            set;
        }

        [JsonProperty("artifacts")]
        public List<Artifact> Artifacts
        {
            get;
            set;
        }
    }
}
