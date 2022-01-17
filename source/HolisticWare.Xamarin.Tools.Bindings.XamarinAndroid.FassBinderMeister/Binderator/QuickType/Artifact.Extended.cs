using System.Collections.Generic;
using System.Net.Http;


// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{
    public partial class Artifact
    {
        // HttpClient is intended to be instantiated once per application,
        // rather than per-use. See Remarks.
        public static HttpClient HttpClient
        {
            get;
            set;
        }

        public List<string> ArtifactIdDependencies
        {
            get;
            set;
        }

        public List<string> NugetVersions
        {
            get;
            set;
        }

        public List<(string TargetFramework, List<string> Packages)> NugetIdDependencies
        {
            get;
            set;
        }

        public Artifact()
        {
            ngc = new NuGet.ClientAPI.NuGetClient(HttpClient);

            return;
        }

    }
}
