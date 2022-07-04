using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.NuGet.Core;

public partial class NuGetPackageDependency : NuGetPackage
{
    public List<NuGetPackageDependency> Dependencies
    {
        get;
        set;
    }
    
}