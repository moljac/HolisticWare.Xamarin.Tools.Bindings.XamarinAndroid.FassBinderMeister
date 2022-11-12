using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Core.Net.HTTP;
using HolisticWare.Xamarin.Tools.NuGet.Core;

using Versions=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root;
using PackageRegistration=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration.Root;
using NuSpecData=HolisticWare.Xamarin.Tools.NuGet.NuSpec.Generated.Microsoft.package;

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

                Versions data = Newtonsoft.Json.JsonConvert.DeserializeObject<Versions>(response);

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

                JObject jo = null;
                try
                {
                    // https://www.newtonsoft.com/json/help/html/queryinglinqtojson.htm
                    jo = JObject.Parse(response);
                }
                catch (Exception exc)
                {
                    /*
                        If you get gibberish and exception similar to:
                        
                        ```
                        System.AggregateException: 
                            One or more errors occurred. 
                                (Unexpected character encountered while parsing value: . Path '', line 0, position 0.)
                         ---> Newtonsoft.Json.JsonReaderException: Unexpected character encountered while parsing value: . Path '', line 0, position 0.
                           at Newtonsoft.Json.JsonTextReader.ParseValue()
                           at Newtonsoft.Json.JsonTextReader.Read()
                           at Newtonsoft.Json.Linq.JObject.Load(JsonReader reader, JsonLoadSettings settings)
                           at Newtonsoft.Json.Linq.JObject.Parse(String json, JsonLoadSettings settings)
                           at Newtonsoft.Json.Linq.JObject.Parse(String json)
                           at HolisticWare.Xamarin.Tools.NuGet.ServerAPI.NuGetPackage.Utilities.GetNuGetPackageFromRegistrationAsync(String nuget_id) 
                            in ./source/HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI/NuGetPackage.Utilities.cs:line 69
                        ```
                        
                        add:
                        
                        ```csharp
                        HttpClientHandler handler = new HttpClientHandler()
                        {
                            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                        };

                        NuGetClient.HttpClient = new HttpClient(handler);
                        ```
                     */
                    string msg = "";
                    throw;
                }

                try
                {
                    JArray jarray_items0 = (JArray) jo["items"];
                    foreach (JToken jtoken_item0 in jarray_items0)
                    {
                        JArray jarray_items1 = (JArray) jtoken_item0["items"];

                        foreach (JToken jtoken_item1 in jarray_items1)
                        {
                            JValue jvalue_id = (JValue) jtoken_item1["catalogEntry"]["id"];
                            nuget_package.Id = jvalue_id.Value.ToString();
                            JValue jvalue_version = (JValue) jtoken_item1["catalogEntry"]["version"];
                            string version = jvalue_version.Value.ToString();
                            nuget_package.VersionTextual = version;
                            nuget_package.VersionsTextual.Add(version);
                            JValue jvalue_published = (JValue) jtoken_item1["catalogEntry"]["published"];
                            nuget_package.Published = DateTime.Parse(jvalue_published.Value.ToString());
                            nuget_package.VersionsDates.Add(nuget_package.VersionTextual, nuget_package.Published);
                            JValue jvalue_description = (JValue) jtoken_item1["catalogEntry"]["description"];
                            nuget_package.Description = jvalue_description.Value.ToString();
                            JValue jvalue_summary = (JValue) jtoken_item1["catalogEntry"]["summary"];
                            nuget_package.Summary = jvalue_summary.Value.ToString();

                            // nuget_package.LicenseExpression = jvalue_summary.Value.ToString();
                            // nuget_package.LicenseURL = jvalue_summary.Value.ToString();
                            // nuget_package.LicenseAcceptanceRequired = jvalue_summary.Value.ToString();
                            // nuget_package.ProjectURL = jvalue_summary.Value.ToString();

                            JArray jarray_dependency_groups = (JArray) jtoken_item1["catalogEntry"]["dependencyGroups"];

                            if (jarray_dependency_groups == null)
                            {
                                continue;
                            }

                            if (jarray_dependency_groups.Count > 0)
                            {
                                nuget_package.DependencyGroups = new List<DependencyGroup>();
                            }

                            foreach (JToken jtoken_dependency_group in jarray_dependency_groups)
                            {
                                DependencyGroup dg = new DependencyGroup();

                                JValue jvalue_target_framework = (JValue) jtoken_dependency_group["targetFramework"];
                                dg.TargetFramework = jvalue_target_framework?.Value?.ToString();

                                nuget_package.DependencyGroups.Add(dg);

                                JArray jarray_dependencies = (JArray) jtoken_dependency_group["dependencies"];

                                if (jarray_dependencies == null)
                                {
                                    continue;
                                }

                                if (jarray_dependencies.Count > 0)
                                {
                                    dg.Dependencies = new List<NuGetPackageDependency>();
                                }

                                foreach (JToken jtoken_dependency in jarray_dependencies)
                                {
                                    JValue jvalue_dependency_id    = (JValue) jtoken_dependency["id"];
                                    JValue jvalue_range            = (JValue) jtoken_dependency["range"];

                                    NuGetPackageDependency nuget_package_dependency = new NuGetPackageDependency()
                                    {
                                        Id = jvalue_dependency_id.Value.ToString(),
                                        VersionRangeTextualDependency = jvalue_range.Value.ToString(),
                                    };

                                    dg.Dependencies.Add(nuget_package_dependency);
                                }
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    Trace.WriteLine(exc);
                    throw;
                }

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
                    data = Newtonsoft.Json.JsonConvert
                                                .DeserializeObject<PackageRegistration>(response);
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
                Task<NuSpecData>
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

                if (await NuGetClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await NuGetClient.HttpClient.GetStringContentAsync(url);
                }
                response = response.Replace("xmlns=\"http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd\"", "");

                NuSpecData data = null;
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer
                                                                                            (
                                                                                                typeof(NuSpecData)
                                                                                            );
                using (System.IO.StringReader reader = new System.IO.StringReader(response))
                {
                    data = xs.Deserialize(reader) as NuSpecData;
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
