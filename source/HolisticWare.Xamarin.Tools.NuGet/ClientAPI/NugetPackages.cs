using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace HolisticWare.Xamarin.Tools.NuGet.ClientAPI
{
    public partial class NuGetPackages : Core.NuGetPackages
    {
        public static NuGetClient NugetClient
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
                    PackageId = package_id,
                 };

                NuGetPackage.NugetClient = NuGetPackages.NugetClient;

                np.PackageSearchMetadata = await np.GetPackageSearchMetadataAsync();
                np.Dependencies = await np.GetDependencyTreeHierarchyAsync();

                result.Add(np);
            }

            return result;
        }
    }
}
