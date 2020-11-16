using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using global::NuGet.Protocol.Core.Types;
using HolisticWare.Xamarin.Tools.NuGet;
using NuGet.Packaging.Core;
using NuGet.Protocol;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{

    public partial class Artifact
    {
        public List<string> ArtifactIdDependencies
        {
            get;
            set;
        }

        public List<string> NugetVersions
        {
            get;
            set;
        }

        public Dictionary<string, List<string>> NugetIdDependencies
        {
            get;
            set;
        }

        NuGetClient ngc = null;

        public Artifact()
        {
            ngc = new NuGetClient();

            return;
        }

        IEnumerable<IPackageSearchMetadata> package_metadata = null;

        public IEnumerable<IPackageSearchMetadata> NugetPackageMetadata
        {
            get
            {
                return package_metadata;
            }
            set
            {
                package_metadata = value;
            }
        }

        public async
            Task<IEnumerable<IPackageSearchMetadata>>
                            GetPackageMetadataAsync
                                            (
                                            )
        {
            package_metadata = await ngc.GetPackageMetadataAsync(this.NugetId);

            List<string> nuget_versions = new List<string>();

            foreach(PackageSearchMetadataRegistration pmd in package_metadata)
            {
                global::NuGet.Versioning.NuGetVersion nv = pmd.Version;
                nuget_versions.Add(nv.OriginalVersion.ToString());

                Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();

                foreach (global::NuGet.Packaging.PackageDependencyGroup dependency in pmd.DependencySets)
                {
                    d.Add
                        (
                            dependency.TargetFramework.Framework,
                            (
                                from PackageDependency p in dependency.Packages
                                select p.Id

                            ).ToList()
                        );
                }

                this.NugetIdDependencies = d;
            }

            nuget_versions.Sort();

            this.NugetVersions = nuget_versions;

            return package_metadata;
        }

        public async
            Task<IEnumerable<IPackageSearchMetadata>>
                            GetPackageMetadataAsync
                                            (
                                                string nuget_id
                                            )
        {
            package_metadata = await ngc.GetPackageMetadataAsync(nuget_id);

            return package_metadata;
        }
    }
}
