using System;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public class AndroidMavenPackage
    {
        public AndroidMavenPackage()
        {
        }

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
