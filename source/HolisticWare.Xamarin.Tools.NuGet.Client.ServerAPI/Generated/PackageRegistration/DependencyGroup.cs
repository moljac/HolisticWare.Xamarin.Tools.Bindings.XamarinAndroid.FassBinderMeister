using System;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration
{ 
    public partial class DependencyGroup
    {
        public Uri Id { get; set; }
        public string Type { get; set; }
        public Dependency[] Dependencies { get; set; }
        public string TargetFramework { get; set; }
    }
}