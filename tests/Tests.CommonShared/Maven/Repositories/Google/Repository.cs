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

using HolisticWare.Xamarin.Tools.Maven.Repositories.Google;

namespace UnitTests.Tools.Maven.Repositories.Google
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_Repository
    {
        static Test_Repository()
        {
            HolisticWare.Xamarin.Tools.Maven.MavenClient.HttpClient = Tests.CommonShared.Http.Client;

        }

        [Test]
        public void Test_Repository_Google_static_defaults()
        {
            Uri uri_root_default = new Uri($"https://dl.google.com/android/maven2");
            Uri uri_master_index_default = new Uri($"https://dl.google.com/android/maven2/master-index.xml");

            #if MSTEST
            Assert.IsNotNull(Repository.UrlRootDefault);
            Assert.IsNotNull(Repository.UrlMasterIndexDefault);
            Assert.IsNotNull(Repository.MasterIndexDefault);
            Assert.AreEqual
                        (
                            Repository.UrlRootDefault,
                            uri_root_default
                        );
            Assert.AreEqual
                        (
                            Repository.UrlMasterIndexDefault,
                            uri_master_index_default
                        );
            #elif NUNIT
            Assert.NotNull(Repository.UrlRootDefault);
            Assert.NotNull(Repository.UrlMasterIndexDefault);
            Assert.Null(Repository.MasterIndexDefault);
            Assert.AreEqual
                        (
                            Repository.UrlRootDefault,
                            uri_root_default
                        );
            Assert.AreEqual
                        (
                            Repository.UrlMasterIndexDefault,
                            uri_master_index_default
                        );
            #elif XUNIT
            Assert.NotNull(Repository.UrlRootDefault);
            Assert.NotNull(Repository.UrlMasterIndexDefault);
            Assert.NotNull(Repository.MasterIndexDefault);
            Assert.Equal
                        (
                            Repository.UrlRootDefault,
                            uri_root_default
                        );
            Assert.Equal
                        (
                            Repository.UrlMasterIndexDefault,
                            uri_master_index_default
                        );
            #endif

        }


        [Test]
        public void Test_Repository_Google_ctor01()
        {
            Repository r = new Repository();

            Uri uri_root = new Uri($"https://dl.google.com/android/maven2");


            #if MSTEST
            Assert.IsNotNull(r);
            Assert.IsNotNull(r.UrlMasterIndex);
            Assert.IsNotNull(r.MasterIndex);
            Assert.AreEqual
                        (
                            r.UrlRoot,
                            uri_root
                        );
            Assert.AreEqual
                        (
                            r.UrlRoot,
                            Repository.UrlRootDefault
                        );
            #elif NUNIT
            Assert.NotNull(r);
            Assert.AreEqual
                        (
                            r.UrlRoot,
                            uri_root
                        );
            Assert.AreEqual
                        (
                            r.UrlRoot,
                            Repository.UrlRootDefault
                        );
            #elif XUNIT
            Assert.NotNull(r);
            Assert.Equal
                        (
                            r.UrlRoot,
                            uri_root
                        );
            Assert.Equal
                        (
                            r.UrlRoot,
                            Repository.UrlRootDefault
                        );
            #endif

            return;
        }

    }
}
