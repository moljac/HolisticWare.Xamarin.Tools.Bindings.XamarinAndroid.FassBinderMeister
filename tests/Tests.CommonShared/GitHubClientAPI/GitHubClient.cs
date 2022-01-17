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

using System.Linq;
using System.Collections.Generic;

using HolisticWare.Xamarin.Tools.GitHub;

namespace UnitTests.ClientsAPI.GitHub
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_GitHubClientAPI
    {

        // https://api.github.com/repos/xamarin/AndroidX/tags
        // https://api.github.com/repos/xamarin/Essentials/tags

        [Test]
        public void Test_GetTagsAsync_AndroidX()
        {
            GitHubClient ghc = new GitHubClient(Tests.CommonShared.Http.Client);

            IEnumerable<Tag> tags = ghc.GetTagsAsync("xamarin", "AndroidX").Result;

            #if MSTEST
            Assert.IsTrue(tags.Any());
            #elif NUNIT
            Assert.True(tags.Any());
            #elif XUNIT
            Assert.True(tags.Any());
            #endif

            return;
        }

        [Test]
        public void Test_GetTagsAsync_GooglePlayServices()
        {
            GitHubClient ghc = new GitHubClient(Tests.CommonShared.Http.Client);

            IEnumerable<Tag> tags = ghc.GetTagsAsync("xamarin", "GooglePlayServicesComponents").Result;

            #if MSTEST
            Assert.IsTrue(tags.Any());
            #elif NUNIT
            Assert.True(tags.Any());
            #elif XUNIT
            Assert.True(tags.Any());
            #endif

            return;
        }

        [Test]
        public void Test_GetTagsAsync_Essentials()
        {
            GitHubClient ghc = new GitHubClient(Tests.CommonShared.Http.Client);

            IEnumerable<Tag> tags = ghc.GetTagsAsync("xamarin", "Essentials").Result;

            #if MSTEST
            Assert.IsTrue(tags.Any());
            #elif NUNIT
            Assert.True(tags.Any());
            #elif XUNIT
            Assert.True(tags.Any());
            #endif

            return;
        }
    }
}
