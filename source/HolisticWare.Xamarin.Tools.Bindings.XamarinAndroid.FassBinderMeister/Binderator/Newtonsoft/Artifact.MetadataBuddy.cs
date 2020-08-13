
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.metadatatypeattribute?view=netcore-3.1
    // https://github.com/dotnet/standard/issues/450
    // https://www.nuget.org/packages/System.ComponentModel.Annotations/4.4.0
    //[MetadataType(typeof(ArtifactMetadataBuddy))]
    public partial class Artifact
    {
    }

    public partial class ArtifactMetadataBuddy : Artifact
    {
        [JsonProperty("groupId", Order = 1)]
        public new string GroupId
        {
            get;
            set;
        }

        [JsonProperty("artifactId", Order = 2)]
        public new string ArtifactId
        {
            get;
            set;
        }

        [JsonProperty("version", Order = 3)]
        public new string Version
        {
            get;
            set;
        }

        [JsonProperty("nugetVersion", Order = 4)]
        public new string NugetVersion
        {
            get;
            set;
        }

        [JsonProperty("nugetId", Order = 5)]
        public new string NugetId
        {
            get;
            set;
        }

        [JsonProperty("dependencyOnly", Order = 6)]
        public new bool DependencyOnly
        {
            get;
            set;
        }
    }
}
