namespace HolisticWare.Xamarin.Tools.NuGet.ClientAPI
{
    public class NuGetPackageDependency : NuGetPackage
    {
        public NuGetPackage DependencyOf
        {
            get;
            set;
        }
        
    }
}