using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HolisticWare.Xamarin.Tools.NuGet;
using NuGet.Protocol.Core.Types;
using System;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    public class ArtifactBindingNugetData
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
                            SearchPackagesByKeywordAsync
                                                (
                                                    string keyword,
                                                    SearchFilter search_filter,
                                                    // Func<IPackageSearchMetadata, bool> filter
                                                    Predicate<IPackageSearchMetadata> filter
                                                )
        {
            IEnumerable<IPackageSearchMetadata> search_result = null;
            IEnumerable<IPackageSearchMetadata> search_result_filtered = null;

            search_result = await nuget_client.SearchPackagesByKeywordAsync
                                                            (
                                                                this.Id,
                                                                search_filter,
                                                                filter
                                                            );
            search_result_filtered =
                from IPackageSearchMetadata psm in search_result
                where filter(psm)
                select psm;

            this.NuGetPackagesFound = search_result_filtered;

            return search_result_filtered;
        }

        public bool FilterByNuGetId
                                                (
                                                    IPackageSearchMetadata package_metadata
                                                )
        {
            return
                package_metadata.Identity.Id == this.IdNuGet
                ;
        }
    }
}
