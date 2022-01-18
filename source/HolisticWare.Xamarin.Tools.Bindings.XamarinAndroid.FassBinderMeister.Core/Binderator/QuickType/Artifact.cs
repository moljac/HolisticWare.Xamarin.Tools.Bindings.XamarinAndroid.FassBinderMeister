
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{
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
