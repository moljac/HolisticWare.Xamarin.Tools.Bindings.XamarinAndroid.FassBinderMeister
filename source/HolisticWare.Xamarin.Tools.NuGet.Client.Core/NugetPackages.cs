using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.NuGet.Core
{
    public partial class NuGetPackages
    {
        public static NuGetClient NugetClient
        {
            get;
            set;
        }

        public List<string> PackageIds
        {
            get;
            set;
        }

        public
            List<NuGetPackage> NugetPackages

        {
            get;
            set;
        }

        public async
            Task<List<NuGetPackage>>
                                GetPackageSearchMetadataForPackageNamesAsync
                                        (
                                            List<string> package_ids
                                        )
        {
            List<NuGetPackage> result = new List<NuGetPackage>();

            foreach (string package_id in package_ids)
            {
               NuGetPackage np = new NuGetPackage
                {
                    Id = package_id,
                 };

                result.Add(np);
            }

            return result;
        }
    }
}
