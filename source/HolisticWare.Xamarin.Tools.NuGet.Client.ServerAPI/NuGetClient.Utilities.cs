using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using global::Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.NuGet.ServerAPI
{
    public partial class NuGetClient
    {
        public static HttpClient HttpClient
        {
            get;
            set;
        }

        public static
                string
                UrlFlatcontainerV3Default
        {
            get;
        } = "https://api.nuget.org/v3-flatcontainer/";

        public static partial class Utilities
        {
            public static async
                Task<string>
                                        GetNugetPackageVersionsFromIndexAsync
                                                (
                                                    string nuget_id
                                                )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
                string url = $"{NuGetClient.UrlFlatcontainerV3Default}/{nuget_id_lower}/index.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

                return response;
            }
        }

        public static async
            Task<string>
                                    GetNugetNuSpecAsync
                                            (
                                                string nuget_id
                                            )
        {
            string nuget_id_lower = nuget_id.ToLower();
            // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
            string url = $"{NuGetClient.UrlFlatcontainerV3Default}/{nuget_id_lower}/index.json";

            string response = null;

            if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
            {
                response = await NuGetClient.HttpClient.GetStringContentAsync(url);
            }

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

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
