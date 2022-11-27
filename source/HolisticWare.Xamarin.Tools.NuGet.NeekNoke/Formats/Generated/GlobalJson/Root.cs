namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats.Generated.GlobalJson
{

    public partial class Root
    {
        public Sdk Sdk { get; set; }

        public MsBuildSdks MsbuildSdks { get; set; }
    }

    public partial class MsBuildSdks
    {
        public string MsBuildSdkExtras { get; set; }

        public string MicrosoftBuildTraversal { get; set; }

        public string MicrosoftBuildNoTargets { get; set; }

        public string XamarinLegacySdk { get; set; }
    }

    public partial class Sdk
    {
        public string Version { get; set; }

        public string RollForward { get; set; }

        public bool? AllowPrerelease { get; set; }
    }
}