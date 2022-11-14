using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Core.Net.HTTP;
using HolisticWare.Xamarin.Tools.NuGet.Core;

using Versions=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root;
using PackageRegistration=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration.Root;
using PackageFromNuSpec=HolisticWare.Xamarin.Tools.NuGet.NuSpec.Generated.Microsoft.Package;

namespace HolisticWare.Xamarin.Tools.NuGet.ServerAPI
{
    public partial class NuGetPackage
    {
        public static partial class Utilities
        {
            public static async
                Task<Versions>
                                        GetPackageVersionsFromIndexAsync
                                            (
                                                string nuget_id
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                string url = $"{NuGetClient.UrlV3FlatcontainerDefault}/{nuget_id_lower}/index.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                Versions data = System.Text.Json.JsonSerializer.Deserialize<Versions>(response);

                return data;
            }

            public static async
                Task<NuGetPackage>
                                        GetNuGetPackageFromRegistrationAsync
                                            (
                                                string nuget_id
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                string url = $"{NuGetClient.UrlV3Registration5SemVerDefault}/{nuget_id_lower}/index.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                NuGetPackage nuget_package = new NuGetPackage()
                {
                    VersionsTextual = new List<string>(),
                    VersionsDates = new Dictionary<string, DateTime>(),
                };
                
                return nuget_package;
            }

            public static async
                Task<PackageRegistration>
                                        GetPackageRegistrationFromIndexAsync
                                            (
                                                string nuget_id
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                string url = $"{NuGetClient.UrlV3Registration5SemVerDefault}/{nuget_id_lower}/index.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                PackageRegistration data = null;
                try
                {
                    data = System.Text.Json.JsonSerializer.Deserialize<PackageRegistration>(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return data;
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
                string url = $"{NuGetClient.UrlV3Registration5SemVerDefault}/{nuget_id_lower}/{version}.json";

                string response = null;

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }

                return response;
            }

            public static async
                Task<PackageFromNuSpec>
                                        GetNuSpecAsync
                                            (
                                                string nuget_id,
                                                string version
                                            )
            {
                string nuget_id_lower = nuget_id.ToLower();
                // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.fragment/1.3.0/xamarin.androidx.fragment.nuspec
                string url =
                    $"{NuGetClient.UrlV3FlatcontainerDefault}/{nuget_id_lower}/{version}/{nuget_id_lower}.nuspec";

                string response = null;
                string ns = "http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd";
                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }
                //response = response.Replace(ns, "");

                PackageFromNuSpec data = null;
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer
                                                                                            (
                                                                                                typeof(PackageFromNuSpec),
                                                                                                ns
                                                                                            );
                using (System.IO.StringReader reader = new System.IO.StringReader(response))
                {
                    data = xs.Deserialize(reader) as PackageFromNuSpec;
                }

                return data;
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
                string url = $"{NuGetClient.UrlV3FlatcontainerDefault}/{nuget_id_lower}/{version}/{nuget_id_lower}.{version}.json";

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
