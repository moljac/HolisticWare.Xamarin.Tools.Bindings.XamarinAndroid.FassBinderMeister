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

using System;

using HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype;

namespace UnitTests.Tools.Maven.Repositories.MavenCentralSonatype
{
    //[TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_Repository
    {
        [Test]
        public void Test_Repository_MavenCentralSonatype_static_Search_io_opencensus_01()
        {

            SearchData result  = Repository.Utilities.Search("io.opencensus").Result;

            #if MSTEST
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 20);
            #elif NUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 20);
            #elif XUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.NotEmpty(result.Artifacts);
            Assert.Equal(20, result.Artifacts.Count);
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_Search_io_opencensus_02()
        {

            SearchData result = Repository.Utilities.Search("io.opencensus", 100).Result;

            #if MSTEST
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 41);
            #elif NUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 41);
            #elif XUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.NotEmpty(result.Artifacts);
            Assert.Equal(41, result.Artifacts.Count);
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_Search_androidx_car_01()
        {

            SearchData result = Repository.Utilities.Search("androidx.car").Result;

            #if MSTEST
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 0);
            #elif NUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 0);
            #elif XUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.Empty(result.Artifacts);
            Assert.Equal(0, result.Artifacts.Count);
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_Search_androidx_car_02()
        {

            SearchData result = Repository.Utilities.Search("androidx.car", 100).Result;

            #if MSTEST
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 0);
            #elif NUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.Equals(result.Artifacts.Count, 0);
            #elif XUNIT
            Assert.NotNull(result);
            Assert.NotNull(result.Artifacts);
            Assert.Empty(result.Artifacts);
            Assert.Equal(0, result.Artifacts.Count);
            #endif

            return;
        }

    }
}
