using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NuGet.Protocol.Core.Types;
using global::NuGet.Packaging;

using HolisticWare.Xamarin.Tools.NuGet;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    public partial class ArtifactBindingNuget
    {
        public ArtifactBindingNuget()
        {
            nuget_client = new NuGet.ClientAPI.NuGetClient();

            return;
        }

        public ArtifactBindingNuget(string id_group, string id_artifact)
            : this()
        {
            nuget_client = new NuGet.ClientAPI.NuGetClient();

            return;
        }

        public string NuGetId
        {
            get;
            set;
        }

        public List<IPackageSearchMetadata> NuGetPackagesSearchResults
        {
            get;
            set;
        }

        protected NuGet.ClientAPI.NuGetClient nuget_client = null;

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
                                                                this.NuGetId,
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

            this.NuGetPackagesSearchResults = search_result_filtered.ToList();

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
                pms.Identity.Id == this.NuGetId
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

        public async
            Task
                            SaveAsync
                                        (
                                            string format = "json"
                                        )
        {
            string content = null;

            switch (format)
            {
                case "json":
                default:
                    content = this.SerializeToJSON_Newtonsoft();
                    break;
            }

            string type_name = this.GetType().FullName;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss.ff");
            string filename = $"{type_name}-{timestamp}.{format}";
            //System.IO.File.WriteAllText(filename, content);
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(filename))
            {
                await writer.WriteAsync(content);
            }

            return;
        }


    }
}
