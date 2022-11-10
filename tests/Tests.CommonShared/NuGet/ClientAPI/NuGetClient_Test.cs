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

using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using HolisticWare.Xamarin.Tools.NuGet.ClientAPI;
using System.Linq;
using System.Text;

namespace UnitTests.ClientsAPI.NuGetClients.ClientAPI
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class NuGetClient_Tests
    {

        [Test]
        public void Packages_Search()
        {
            NuGetClient.HttpClient = Tests.CommonShared.Http.Client;

            NuGetClient ngc = new NuGetClient(Tests.CommonShared.Http.Client);

            IEnumerable<IPackageSearchMetadata> search = null;
            search = ngc.SearchPackagesByKeywordAsync
                            (
                                "androidx",
                                new global::NuGet.Protocol.Core.Types.SearchFilter
                                                                        (
                                                                            includePrerelease: true
                                                                        ),
                                skip: 0,
                                take: 1000,
                                psm =>
                                {
                                    return
                                    (
                                        psm.Identity.Id.StartsWith("Xamarin.AndroidX")
                                        //psm.Description.Contains("car")
                                        //||
                                        //psm.Description.Contains("androidx.car")
                                    );
                                }
                            ).Result;

            #if MSTEST
            Assert.IsNotNull(search);
            #elif NUNIT
            Assert.NotNull(search);
            #elif XUNIT
            Assert.NotNull(search);
            #endif

            Console.WriteLine($"Packages found...");
            foreach (IPackageSearchMetadata pm in search)
            {
                IEnumerable<VersionInfo> versions = pm.GetVersionsAsync().Result;

                IEnumerable<(string version, long count)> versions_sorted = null;
                versions_sorted = versions
                                        .OrderByDescending(v => v.Version)
                                        .Select(v => (v.Version.ToString(), v.DownloadCount.Value));
                                        ;
                StringBuilder versions_dump = new StringBuilder();
                foreach((string version, long count) v_c in versions_sorted)
                {
                    versions_dump.AppendLine($"{v_c.version}   {v_c.count}".PadLeft(10));
                }
                Console.WriteLine($"----------------------------------------------------------");
                Console.WriteLine($"Identity.Id     : {pm.Identity.Id}");
                Console.WriteLine($"Title           : {pm.Title}");
                Console.WriteLine($"Summary         : {pm.Summary}");
                Console.WriteLine($"Tags            : {pm.Tags}");
                Console.WriteLine($"Versions        : ");
                Console.WriteLine($"{versions_dump}");
            }

            return;
        }

        [Test]
        public 
            void 
                                        Packages_PackageMetadata
                                            (
                                            )
        {
            NuGetClient ngc = new NuGetClient(Tests.CommonShared.Http.Client);

            IEnumerable<IPackageSearchMetadata> package_metadata = null;
            package_metadata = ngc.GetPackageMetadataAsync
                                                (
                                                  "Xamarin.AndroidX.Core"
                                                ).Result;

            #if MSTEST
            Assert.IsNotNull(package_metadata);
            #elif NUNIT
            Assert.NotNull(package_metadata);
            #elif XUNIT
            Assert.NotNull(package_metadata);
            #endif

            Console.WriteLine($"Package metadata...");
            foreach (IPackageSearchMetadata pm in package_metadata)
            {
                Console.WriteLine($"----------------------------------------------------------");
                Console.WriteLine($"Title   : {pm.Title}");
                Console.WriteLine($"Summary         : {pm.Summary}");
                Console.WriteLine($"Tags            : {pm.Tags}");
            }

            return;
        }

        [Test]
        public 
            void 
                                        Packages_PackageVersions_Xamarin_AndroidX_Core
                                            (
                                            )
        {
            NuGetClient ngc = new NuGetClient(Tests.CommonShared.Http.Client);

            IEnumerable<NuGetVersion> package_versions = ngc.GetPackageVersionsAsync
                                                                                (
                                                                                 "Xamarin.AndroidX.Core"
                                                                                ).Result;

            #if MSTEST
            Assert.IsNotNull(package_versions);
            #elif NUNIT
            Assert.NotNull(package_versions);
            #elif XUNIT
            Assert.NotNull(package_versions);
            #endif

            Console.WriteLine($"Package metadata...");
            foreach (NuGetVersion v in package_versions)
            {
                Console.WriteLine($"----------------------------------------------------------");
                Console.WriteLine($"Version         : {v.Version}");
                Console.WriteLine($"Summary         : {v.OriginalVersion}");
            }

            return;
        }
    }
}
