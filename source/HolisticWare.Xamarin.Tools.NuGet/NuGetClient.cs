using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace HolisticWare.Xamarin.Tools.NuGet
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdk"/>
    /// <see cref="https://devblogs.microsoft.com/nuget/improved-search-syntax/"/>
    public partial class NuGetClient
    {
        ILogger logger = null;
        CancellationToken cancellationToken;

        SourceCacheContext cache = null;
        SourceRepository repository = null;

        public NuGetClient()
        {
            logger = NullLogger.Instance;
            cancellationToken = CancellationToken.None;

            cache = new SourceCacheContext();
            repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");

            return;
        }

        /// <summary>
        /// Search for NuGet packages by keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>IEnumerable<NuGet.Protocol.Core.Types.IPackageSearchMetadata></returns>
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
            PackageSearchResource resource = await repository.GetResourceAsync<PackageSearchResource>();
 
            // https://apisof.net/catalog/NuGet.Protocol.Core.Types.IPackageSearchMetadata
            // https://apisof.net/catalog/NuGet.Protocol.Core.Types.SearchFilter
            // https://github.com/NuGet/Home/issues/8719
            // https://apisof.net/catalog/NuGet.Protocol.Core.Types.PackageSearchResource.SearchAsync(String,SearchFilter,Int32,Int32,ILogger,CancellationToken)
            // search_filter_type
            // https://scm.mbwarez.dk/tools/nuget-package-overview/blob/3dab8c9ba3d9d65c52d9036d4695e91eb6ee169a/NugetOverview/Program.cs
            // https://128.39.141.180/justworks/playground/blob/168480a22f353c250ed0276af21e9b1993f40032/InternalDevTools/GitHooks/Resharper/NuGet.Protocol.xml
            // https://aakinshin.net/posts/rider-nuget-search/
 
            IEnumerable<IPackageSearchMetadata> results = await resource.SearchAsync
                                                                                (
                                                                                    keyword,
                                                                                    search_filter,
                                                                                    skip: 0,
                                                                                    take: 1000,
                                                                                    logger,
                                                                                    cancellationToken
                                                                                );

            IEnumerable<IPackageSearchMetadata> results_filtered = null;
            results_filtered =
                from IPackageSearchMetadata psm in results
                where filter(psm)
                select psm;

            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nuget_id"></param>
        /// <returns><IEnumerable<NuGet.Versioning.NuGetVersion>></returns>
        /// <see cref="https://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdk#list-package-versions"/>
        public async
            Task<IEnumerable<NuGetVersion>>
                                        GetPackageVersionsAsync
                                                (
                                                    string nuget_id
                                                )
        {
            FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();

            IEnumerable<NuGetVersion> versions = await resource.GetAllVersionsAsync
                                                                            (
                                                                                nuget_id,
                                                                                cache,
                                                                                logger,
                                                                                cancellationToken
                                                                            );

            foreach (NuGetVersion version in versions)
            {
                Console.WriteLine($"Found version {version}");
            }

            return versions;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nuget_id"></param>
        /// <returns></returns>
        /// <see cref="https://docs.microsoft.com/en-us/nuget/reference/nuget-client-sdk#get-package-metadata"/>
        public async
            Task<IEnumerable<IPackageSearchMetadata>>
                                        GetPackageMetadataAsync
                                                (
                                                    string nuget_id
                                                )
        {
            PackageMetadataResource resource = await repository.GetResourceAsync<PackageMetadataResource>();

            IEnumerable<IPackageSearchMetadata> packages = await resource.GetMetadataAsync
                                                                                (
                                                                                    nuget_id,
                                                                                    includePrerelease: true,
                                                                                    includeUnlisted: false,
                                                                                    cache,
                                                                                    logger,
                                                                                    cancellationToken
                                                                                );

            return packages;
        }

    }
}
