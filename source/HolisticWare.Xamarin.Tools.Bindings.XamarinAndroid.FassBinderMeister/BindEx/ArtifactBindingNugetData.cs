using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NuGet.Protocol.Core.Types;
using global::NuGet.Packaging;

using HolisticWare.Xamarin.Tools.NuGet;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    public partial class ArtifactBindingNugetData
    {
        public ArtifactBindingNugetData()
        {
            nuget_client = new NuGetClient();

            return;
        }

        public ArtifactBindingNugetData(string id_group, string id_artifact)
            : this()
        {
            this.Id = id_artifact;
            this.IdGroup = id_group;

            nuget_client = new NuGetClient();

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public string IdGroup
        {
            get;
            set;
        }

        public string IdNuGet
        {
            get;
            set;
        }

        public IEnumerable<IPackageSearchMetadata> NuGetPackagesFound
        {
            get;
            set;
        }

        protected NuGetClient nuget_client = null;

        public async
            Task<IEnumerable<IPackageSearchMetadata>>
                            SearchPackagesByKeywordWithFilterAsync
                                                (
                                                    string keyword,
                                                    SearchFilter search_filter = null,
                                                    int skip = 0,
                                                    int take = 100,
                                                    // Func<IPackageSearchMetadata, bool> filter
                                                    Predicate<IPackageSearchMetadata> filter = null
                                                )
        {
            if (null == search_filter)
            {
                search_filter = new SearchFilter(true);
            }

            if (null == filter)
            {
            }

            IEnumerable<IPackageSearchMetadata> search_result = null;
            IEnumerable<IPackageSearchMetadata> search_result_filtered = null;


            search_result = await nuget_client.SearchPackagesByKeywordAsync
                                                            (
                                                                this.Id,
                                                                search_filter,
                                                                skip,
                                                                take,
                                                                filter
                                                            );
            search_result_filtered =
                from IPackageSearchMetadata psm in search_result
                where
                    FilterByTargetFrameworkAsync(psm, "MonoAndroid").Result
                    &&
                    filter(psm)
                select psm;

            this.NuGetPackagesFound = search_result_filtered;

            return search_result_filtered;
        }

        public
            bool
                            FilterByNuGetId
                                                (
                                                    IPackageSearchMetadata pms
                                                )
        {
            return
                pms.Identity.Id == this.IdNuGet
                ;
        }

        public async
            Task<bool>
                            FilterByTargetFrameworkAsync
                                                (
                                                    IPackageSearchMetadata pms,
                                                    string target_framework = "MonoAndroid"
                                                )
        {
            bool result = false;

            if (pms.DependencySets.Count() == 0)
            {
                IEnumerable<IPackageSearchMetadata> search_result = null;
                search_result = await nuget_client.GetPackageMetadataAsync
                                                                (
                                                                    pms.Identity.Id
                                                                );

                foreach (IPackageSearchMetadata psm_tf in search_result)
                {
                    foreach (PackageDependencyGroup tf in psm_tf.DependencySets)
                    {
                        if (tf.TargetFramework.Framework == target_framework)
                        {
                            result = true;
                            break;
                        }
                    }

                    if (result == true)
                    {
                        break;
                    }
                }
            }
            else
            {
                foreach (PackageDependencyGroup tf in pms.DependencySets)
                {
                    if (tf.TargetFramework.Framework == target_framework)
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
