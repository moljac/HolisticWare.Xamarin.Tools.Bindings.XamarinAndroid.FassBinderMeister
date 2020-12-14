using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NuGet.Packaging;
using NuGet.Protocol.Core.Types;

namespace HolisticWare.Xamarin.Tools.NuGet
{
    public partial class NuGetPackage
    {
        public static NuGetClient NugetClient
        {
            get;
            set;
        }

        public string PackageId
        {
            get;
            set;
        }

        public string VersionTextual
        {
            get;
            set;
        }

        public string VersionLatestTextual
        {
            get;
            set;
        }

        public string DependencyVersionRange
        {
            get;
            set;
        }

        public List<string> VersionsTextual
        {
            get;
            set;
        }

        public List<NuGetPackage> Dependencies
        {
            get;
            set;
        }


        public IEnumerable<IPackageSearchMetadata> PackageSearchMetadata
        {
            get;
            set;
        }

        public async
            Task<IEnumerable<IPackageSearchMetadata>>
                                GetPackageSearchMetadataAsync
                                        (
                                        )
        {
            IEnumerable<IPackageSearchMetadata> package_metadata = null;
            package_metadata = await NugetClient.GetPackageMetadataAsync
                                                (
                                                    this.PackageId
                                                );

            IEnumerable<string> versions = null;
            versions = from IPackageSearchMetadata psm in package_metadata
                       orderby psm.Identity.Version descending
                       select psm.Identity.Version.ToFullString();

            this.VersionsTextual = versions.ToList();

            return package_metadata;
        }


        public async
            Task<List<NuGetPackage>>
                                GetDependencyTreeHierarchyAsync
                                        (
                                        )
        {
            List<NuGetPackage> dependencies = null;

            if (null == PackageSearchMetadata)
            {
                PackageSearchMetadata = await this.GetPackageSearchMetadataAsync();
            }

            foreach (IPackageSearchMetadata psm in PackageSearchMetadata)
            {
                foreach(PackageDependencyGroup ds in psm.DependencySets)
                {
                    global::NuGet.Frameworks.NuGetFramework tf = ds.TargetFramework;

                    if (tf.DotNetFrameworkName.ToLower().Contains("monoandroid"))
                    {
                        foreach(global::NuGet.Packaging.Core.PackageDependency p in ds.Packages)
                        {
                            string id = p.Id;
                            Console.WriteLine($"id = {id}");

                            global::NuGet.Versioning.VersionRange vr = p.VersionRange;
                            string vrpp = vr.PrettyPrint();

                            NuGetPackage np = new NuGetPackage()
                            {
                                PackageId = id,
                                DependencyVersionRange = vrpp,
                            };
                            dependencies = await np.GetDependencyTreeHierarchyAsync();
                            np.Dependencies = dependencies;

                            Console.WriteLine($"    has dependencies  = { null != dependencies}");
                        }
                    }
                }
            }


            return dependencies;
        }
    }
}
