using System.Net.Http;
using System.Threading.Tasks;

using Core.Net.HTTP;

using HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated;

namespace HolisticWare.Xamarin.Tools.NuGet.ServerAPI
{
    /// <summary>
    /// 
    /// </summary>
    /// versions
    ///     https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
    /// details
    ///     https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.compose.material.ripple/index.json
    public partial class NuGetClient
    {
        public static HttpClient HttpClient { get; set; }

        public static
            string
            UrlFlatcontainerV3Default { get; } = "https://api.nuget.org/";

        public static partial class Utilities
        {
            public static async
                Task<string>
                                        GetPackageVersionsFromIndexAsync
                                            (
                                                string nuget_id
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
                string url = $"{NuGetClient.UrlFlatcontainerV3Default}/v3-flatcontainer/{nuget_id_lower}/index.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root data = null;

                data = Newtonsoft.Json.JsonConvert.DeserializeObject<HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root>(response);

                return response;
            }

            public static async
                Task<string>
                                        GetPackageRegistrationFromIndexAsync
                                            (
                                                string nuget_id
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.compose.material.ripple/index.json
                string url = $"{NuGetClient.UrlFlatcontainerV3Default}/v3-flatcontainer/{nuget_id_lower}/index.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration.Root data = null;

                data = Newtonsoft.Json.JsonConvert.DeserializeObject<HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration.Root>(response);

                return response;
            }

            public static async
                Task<string>
                                        GetPackageRegistrationFromIndexAsync
                                            (
                                                string nuget_id,
                                                string version
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.compose.material.ripple/1.0.0.json
                string url =
                    $"{NuGetClient.UrlFlatcontainerV3Default}/v3/registration5-gz-semver2/{nuget_id_lower}/{version}.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                return response;
            }

            public static async
                Task<string>
                                        GetNugetNuSpecAsync
                                            (
                                                string nuget_id,
                                                string version
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.fragment/1.3.0/xamarin.androidx.fragment.nuspec
                string url =
                    $"{NuGetClient.UrlFlatcontainerV3Default}/v3-flatcontainer//{nuget_id_lower}/{version}/{nuget_id_lower}.nuspec";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                return response;
            }
            
            public static async
                Task<byte[]>
                                        DownloadNuGetPackageNuPkgAsync
                                            (
                                                string nuget_id,
                                                string version
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
                string url = $"{NuGetClient.UrlFlatcontainerV3Default}/{nuget_id_lower}/index.json";

                byte[] response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetByteArrayAsync(url);
                }

                return response;
            }
        }
        
    }
}
