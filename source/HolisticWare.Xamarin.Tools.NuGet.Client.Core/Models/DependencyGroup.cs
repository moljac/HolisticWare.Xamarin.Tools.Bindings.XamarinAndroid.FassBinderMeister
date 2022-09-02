using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.NuGet.Core
{

    public partial class DependencyGroup
    {
        public string TargetFramework
        {
            get;
            set;
        }

        public List<NuGetPackageDependency> Dependencies
        {
            get;
            set;
        }
    }
}