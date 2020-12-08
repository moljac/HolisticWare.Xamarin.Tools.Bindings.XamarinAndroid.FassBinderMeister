// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
//
//    Pergission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without ligitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to pergit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this pergission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIgiTED TO THE WARRANTIES
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

using System.Collections.Generic;
using System.Linq;

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx;

namespace UnitTests.FassBinderMeister.BindEx
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_ArtifactBindingNuget
    {
        [Test]
        public void Test_Maven_Google_ArtifactBindingNuget_Ctor_01()
        {
            ArtifactBindingNuget abnd = new ArtifactBindingNuget("androidx.car", "car");

            #if MSTEST
            Assert.IsNotNull(abnd);
            #elif NUNIT
            Assert.NotNull(abnd);
            #elif XUNIT
            Assert.NotNull(abnd);
            #endif

            return;
        }

        [Test]
        public void Test_Maven_Google_ArtifactBindingNuget_SearchPackagesByKeywordAsync()
        {
            ArtifactBindingNuget abnd = new ArtifactBindingNuget("androidx.car", "car")
            {
                NuGetId = "Xamarin.AndroidX.Car.Car"
            };

            IEnumerable<global::NuGet.Protocol.Core.Types.IPackageSearchMetadata> result = null;
            result = abnd.SearchPackagesByKeywordWithFilterAsync
                            (
                                abnd.NuGetId,
                                // null,
                                new global::NuGet.Protocol.Core.Types.SearchFilter
                                                                        (
                                                                            includePrerelease: true
                                                                        ),
                                skip: 0,
                                take: 100,
                                // default (for null) predicates:
                                // 
                                // custom predicate:
                                psm =>
                                {
                                    return
                                    (
                                        (
                                            psm.Title.ToLower().Contains("androidx")
                                            &&
                                            psm.Title.ToLower().Contains("car")
                                        )
                                        &&
                                        (
                                            psm.Description.ToLower().Contains("car")
                                            ||
                                            psm.Description.ToLower().Contains("androidx.car")
                                        )
                                    );
                                }
                            )
                            .Result;

            List<global::NuGet.Protocol.Core.Types.IPackageSearchMetadata> l = result.ToList();

            abnd.NuGetPackagesSearchResults = l;

            abnd.SaveAsync().Wait();

            #if MSTEST
            Assert.IsNotNull(abnd);
            Assert.IsNotNull(result);
            #elif NUNIT
            Assert.NotNull(abnd);
            Assert.NotNull(result);
            #elif XUNIT
            Assert.NotNull(abnd);
            Assert.NotNull(result);
            #endif

            return;
        }
    }
}
