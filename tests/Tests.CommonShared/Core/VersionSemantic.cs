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

using System.Collections.Generic;

using Core;

namespace UnitTests.Core
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_VersionSemantic
    {
        [Test]
        public void Test_VersionSemantic_static_API_01_Parse_01()
        {
            Dictionary<string, VersionSemantic> data;

            data = new Dictionary<string, VersionSemantic>()
            {
                { "1.9.0", new VersionSemantic() },
                { "1.10.0", new VersionSemantic() },
                { "1.11.0", new VersionSemantic() },
                { "1.0.0-alpha", new VersionSemantic() },
                { "1.0.0-alpha.1", new VersionSemantic() },
                { "1.0.0-0.3.7", new VersionSemantic() },
                { "1.0.0-x.7.z.92", new VersionSemantic() },
                { "1.0.0-x-y-z.–", new VersionSemantic() },
                { "1.0.0-alpha+001", new VersionSemantic() },
                { "1.0.0+20130313144700", new VersionSemantic() },
                { "1.0.0-beta+exp.sha.5114f85", new VersionSemantic() },
                { "1.0.0+21AF26D3—-117B344092BD", new VersionSemantic() },
                { "", new VersionSemantic() },
                { "", new VersionSemantic() },
                { "", new VersionSemantic() },
                { "", new VersionSemantic() },
                { "", new VersionSemantic() },
                { "", new VersionSemantic() },
            };

            #if MSTEST
            Assert.AreEqual(data[""], "20201105 - stable - releases");
            #elif NUNIT
            Assert.AreEqual(data[""], "20201105 - stable - releases");
            #elif XUNIT
            Assert.Equal(data[""].ToString(), "20201105 - stable - releases");
            #endif

            return;
        }

        [Test]
        public void Test_VersionSemantic_static_API_01_Parse_02()
        {
            VersionSemantic.Parse("1");
            VersionSemantic.Parse01("1");
            VersionSemantic.Parse02("1");

            VersionSemantic.Parse("1.0");
            VersionSemantic.Parse01("1.0");
            VersionSemantic.Parse02("1.0");

            VersionSemantic.Parse("1.0.0");
            VersionSemantic.Parse01("1.0.0");
            VersionSemantic.Parse02("1.0.0");

            VersionSemantic.Parse("1.0.0-alpha01");
            VersionSemantic.Parse01("1.0.0-alpha01");
            VersionSemantic.Parse02("1.0.0-alpha01");

            VersionSemantic.Parse("1.0.0-alpha01-20210712");
            VersionSemantic.Parse01("1.0.0-alpha01-20210712");
            VersionSemantic.Parse02("1.0.0-alpha01-20210712");

            VersionSemantic.Parse("1.0.0-alpha01+20210712");
            VersionSemantic.Parse01("1.0.0-alpha01+20210712");
            VersionSemantic.Parse02("1.0.0-alpha01+20210712");


            new VersionSemantic("1.0.0") < new VersionSemantic("2.0.0")
            new VersionSemantic("2.0.0" < new VersionSemantic("2.1.0")
            new VersionSemantic("2.1.0" < new VersionSemantic("2.1.1")

            return;
        }
    }
}
