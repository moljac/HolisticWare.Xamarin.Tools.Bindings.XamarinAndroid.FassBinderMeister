//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool   nuget:?package=Cake.CoreCLR

#addin  nuget:?package=HolisticWare.Xamarin.Tools.NuGet&prerelease&loaddependencies=true


using HolisticWare.Xamarin.Tools.NuGet;


            NuGetPackages.NugetClient = new NuGetClient();






            // NuGetPackages np = new NuGetPackages();

            // List<string> package_ids = new List<string>()
            // {
            //     "Xamarin.AndroidX.Legacy.Support.V13",
            //     "Xamarin.Google.Guava.ListenableFuture",
            //     "Xamarin.AndroidX.Annotations",
            //     "Xamarin.AndroidX.Activity",
            //     "Xamarin.AndroidX.NonExistentPackage",
            // };
            // List<NuGetPackage> result = np.GetPackageSearchMetadataForPackageNamesAsync(package_ids)
            //                                     .Result;

            // System.IO.Directory.CreateDirectory
            //                         (
            //                             $"nuget-client-api/NugetPackages/"
            //                         );

            // string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            // string json = null;

            // json = Newtonsoft.Json.JsonConvert.SerializeObject
            //                                         (
            //                                             result,
            //                                             Newtonsoft.Json.Formatting.Indented
            //                                         );
            // System.IO.File.WriteAllText
            //                     (
            //                         $"nuget-client-api/NugetPackages/PackageSearchMetadata-{timestamp}.json",
            //                         json
            //                     );






            // NuGetPackage.NugetClient = new NuGetClient();

            // NuGetPackage np = new NuGetPackage()
            // {
            //     PackageId = "Xamarin.AndroidX.Core",
            //     VersionTextual = "1.3.2",
            // };

            // List<NuGetPackage> result = null;
            // result = np.GetDependencyTreeHierarchyAsync()
            //                 .Result;

            // System.IO.Directory.CreateDirectory
            //                         (
            //                             $"nuget-client-api/NugetPackage/"
            //                         );

            // string timestamp = System.DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            // string json = null;

            // json = Newtonsoft.Json.JsonConvert.SerializeObject
            //                                         (
            //                                             result,
            //                                             Newtonsoft.Json.Formatting.Indented
            //                                         );
            // System.IO.File.WriteAllText
            //                     (
            //                         $"nuget-client-api/NugetPackage/DependencyTreeHierarchy-{timestamp}.json",
            //                         json
            //                     );




                NuGetClient.HttpClient = new HttpClient();

                Console.WriteLine($"nuget_id:    {nuget_id}");
                NuGetPackage np = await NuGetClient.Utilities
                                                .GetNuGetPackageFromRegistrationAsync(nuget_id)
                                                ;

                string versions = string.Join
                                            (
                                                $"\t{Environment.NewLine}\t\t",
                                                np.VersionsDates
                                                    .Select(kv => kv.Key + "\t = \t " + kv.Value.ToString("yyyy-MM-dd hh:mm:ss"))
                                                        .ToArray()
                                            );
                Console.WriteLine(versions);
