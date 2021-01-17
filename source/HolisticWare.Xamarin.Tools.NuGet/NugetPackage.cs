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

        public NuGetPackage DependencyOf
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
            // sorting in reverse order of version
            // in order to hit later versions first (speeding up) when iterating through
            // IEnumebrable/collections/containers
            package_metadata = from IPackageSearchMetadata psm in package_metadata
                               orderby psm.Identity.Version descending
                               select psm
                               ;
            IEnumerable<string> versions = null;
            versions = from IPackageSearchMetadata psm in package_metadata
                       // no need to sort - done above
                       //orderby psm.Identity.Version descending
                       select psm.Identity.Version.ToFullString()
                       ;

            this.VersionsTextual = versions.ToList();

            return package_metadata;
        }


        #if DEBUG
        public System.CodeDom.Compiler.IndentedTextWriter w = new System.CodeDom.Compiler.IndentedTextWriter(Console.Out);
        #endif

        public async
            Task<List<NuGetPackage>>
                                GetDependencyTreeHierarchyAsync
                                        (
                                        )
        {
            #if DEBUG
            w.Indent++;
            await w.WriteLineAsync($" id = {this.PackageId}");
            #endif

            List<NuGetPackage> dependencies = null;

            if (null == PackageSearchMetadata)
            {
                PackageSearchMetadata = await this.GetPackageSearchMetadataAsync();
            }

            foreach (IPackageSearchMetadata psm in PackageSearchMetadata)
            {
                if (! psm.Identity.Version.OriginalVersion.Contains(this.VersionTextual))
                {
                    continue;
                }

                foreach (PackageDependencyGroup ds in psm.DependencySets)
                {
                    global::NuGet.Frameworks.NuGetFramework tf = ds.TargetFramework;

                    if (tf.DotNetFrameworkName.ToLower().Contains("monoandroid"))
                    {
                        foreach (global::NuGet.Packaging.Core.PackageDependency p in ds.Packages)
                        {
                            if (null == dependencies)
                            {
                                dependencies = new List<NuGetPackage>();
                            }

                            string id = p.Id;
                            global::NuGet.Versioning.VersionRange vr = p.VersionRange;
                            string vrpp = vr.PrettyPrint();

                            NuGetPackage np = new NuGetPackage()
                            {
                                PackageId = id,
                                VersionTextual = vr.MinVersion.ToFullString(),
                                DependencyVersionRange = vrpp,
                                DependencyOf = this,
                            };

                            np.Dependencies = await np.GetDependencyTreeHierarchyAsync();

                            dependencies.Add(np);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                this.Dependencies = dependencies;
            }

            return dependencies;
        }
    }
}
