// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
using TestContext = HolisticWare.Core.Testing.UnitTests.TestContext;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
// XUnit aliases
using Fact = NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

#if BENCHMARKDOTNET
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes.Jobs;
#else
using Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;
using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using HolisticWare.Xamarin.Tools.NuGet.Core;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using NuGetClient = HolisticWare.Xamarin.Tools.NuGet.ServerAPI.NuGetClient;
using VersionsData=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root;
using PackageRegistrationData=HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration.Root;
using NuSpecData=HolisticWare.Xamarin.Tools.NuGet.NuSpec.Generated.Microsoft.package;

namespace UnitTests.ClientsAPI.NuGetClients.ServerAPI
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_NuGetClient
    {
        
        [Test]
        public void GetPackageVersionsFromIndexAsync()
        {
            NuGetClient.HttpClient = Tests.CommonShared.Http.Client;

            Random rnd = new Random();
            IOrderedEnumerable<(string, string, string, string)> randomized = null;
            randomized = Data.AX.mappings_artifact_nuget.OrderBy((item) => rnd.Next());
            
            foreach ((string , string, string, string) mapping in randomized.Take(10))
            {
                string nuget_id = mapping.Item3;
                VersionsData versions = NuGetClient.Utilities.GetPackageVersionsFromIndexAsync(nuget_id).Result;
                
                Console.WriteLine($"nuget_id:    {nuget_id}");
            }

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif

            return;
        }

        [Test]
        public
            void
                                        GetNuGetPackageFromRegistrationAsync()
        {
            NuGetClient.HttpClient = Tests.CommonShared.Http.Client;

            Random rnd = new Random();
            IOrderedEnumerable<(string, string, string, string)> randomized = null;
            randomized = Data.AX.mappings_artifact_nuget.OrderBy((item) => rnd.Next());

            foreach ((string, string, string, string) mapping in Data.AX.mappings_artifact_nuget)//.Take(10))
            {
                string nuget_id = mapping.Item3;
                NuGetPackage np = NuGetClient.Utilities
                                                .GetNuGetPackageFromRegistrationAsync(nuget_id)
                                                .Result;

                Console.WriteLine($"nuget_id:    {nuget_id}");
                string versions = string.Join
                                            (
                                                $"\t{Environment.NewLine}\t\t",
                                                np.VersionsDates
                                                    .Select(kv => kv.Key + "\t = \t " + kv.Value.ToString("yyyy-MM-dd hh:mm:ss"))
                                                        .ToArray()
                                            );
                Console.WriteLine(versions);
            }
            
            foreach ((string, string, string, string) mapping in Data.GPS_FB_MLKit.mappings_artifact_nuget)//.Take(10))
            {
                string nuget_id = mapping.Item3;
                NuGetPackage np = NuGetClient.Utilities
                                                .GetNuGetPackageFromRegistrationAsync(nuget_id)
                                                .Result;

                Console.WriteLine($"nuget_id:    {nuget_id}");
                string versions = string.Join
                                            (
                                                $"\t{Environment.NewLine}\t\t",
                                                np.VersionsDates
                                                    .Select(kv => kv.Key + "\t = \t " + kv.Value.ToString("yyyy-MM-dd hh:mm:ss"))
                                                    .ToArray()
                                            );
                Console.WriteLine(versions);
            }
        }

        [Test]
        public
            void 
                                        GetPackageRegistrationFromIndexAsync()
        {
            NuGetClient.HttpClient = Tests.CommonShared.Http.Client;

            Random rnd = new Random();
            IOrderedEnumerable<(string, string, string, string)> randomized = null;
            randomized = Data.AX.mappings_artifact_nuget.OrderBy((item) => rnd.Next());
            
            foreach ((string , string, string, string) mapping in randomized.Take(10))
            {
                string nuget_id = mapping.Item3;
                PackageRegistrationData pr = NuGetClient.Utilities.GetPackageRegistrationFromIndexAsync(nuget_id).Result;
                
                Console.WriteLine($"nuget_id:    {nuget_id}");
            }

            // #if MSTEST
            // Assert.IsNotNull(package_metadata);
            // #elif NUNIT
            // Assert.NotNull(package_metadata);
            // #elif XUNIT
            // Assert.NotNull(package_metadata);
            // #endif

            return;
        }

        [Test]
        public 
            void 
                                        GetNuSpecAsync()
        {
            NuGetClient.HttpClient = Tests.CommonShared.Http.Client;

            Random rnd = new Random();
            IOrderedEnumerable<(string, string, string, string)> randomized = null;
            randomized = Data.AX.mappings_artifact_nuget.OrderBy((item) => rnd.Next());
            
            foreach ((string , string, string, string) mapping in randomized.Take(10))
            {
                string nuget_id = mapping.Item3;
                string version  = mapping.Item4;
                
                NuSpecData nuspec = NuGetClient.Utilities.GetNuSpecAsync(nuget_id, version).Result;
            }

            // #if MSTEST
            // Assert.IsNotNull(package_versions);
            // #elif NUNIT
            // Assert.NotNull(package_versions);
            // #elif XUNIT
            // Assert.NotNull(package_versions);
            // #endif

            return;
        }
        
        [Test]
        public 
            void 
                                        DownloadNuGetPackageNuPkgAsync()
        {
            NuGetClient.HttpClient = Tests.CommonShared.Http.Client;

            Random rnd = new Random();
            IOrderedEnumerable<(string, string, string, string)> randomized = null;
            randomized = Data.AX.mappings_artifact_nuget.OrderBy((item) => rnd.Next());
            
            foreach ((string , string, string, string) mapping in randomized.Take(10))
            {
                string nuget_id = mapping.Item3;
                string version  = mapping.Item4;
                
                byte[] blob = NuGetClient.Utilities.DownloadNuGetPackageNuPkgAsync(nuget_id, version).Result;
            }

            // #if MSTEST
            // Assert.IsNotNull(package_versions);
            // #elif NUNIT
            // Assert.NotNull(package_versions);
            // #elif XUNIT
            // Assert.NotNull(package_versions);
            // #endif

            return;
        }
    }
}
