using System.Collections.Generic;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public partial class Artifact
    {
        public string GroupId
        {
            get;
            set;
        }

        public string ArtifactId
        {
            get;
            set;
        }


        public string Version
        {
            get;
            set;
        }

        public string NugetVersion
        {
            get;
            set;
        }

        public string NugetId
        {
            get;
            set;
        }

        public bool DependencyOnly
        {
            get;
            set;
        }
    }

}
