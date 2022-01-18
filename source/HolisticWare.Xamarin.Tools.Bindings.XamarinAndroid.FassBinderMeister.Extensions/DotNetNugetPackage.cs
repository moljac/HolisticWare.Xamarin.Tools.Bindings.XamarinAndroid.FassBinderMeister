using System;
namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public class DotNetNugetPackage
    {
        public DotNetNugetPackage()
        {
        }

        public string NugetId
        {
            get;
            set;
        }

        public string VersionTextual
        {
            get;
            set;
        }

        public Version Version
        {
            get;
            set;
        }

        public IEquatable<DotNetNugetPackage> Dependencies
        {
            get;
            set;
        }
    }
}
