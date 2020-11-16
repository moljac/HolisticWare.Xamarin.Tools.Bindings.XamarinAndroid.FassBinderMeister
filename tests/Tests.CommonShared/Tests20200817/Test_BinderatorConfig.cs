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
using System.Linq;
using System.Collections.Generic;

using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using HolisticWare.Xamarin.Tools.GitHub;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType;

namespace UnitTests.Binderator.Config
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_BinderatorConfig
    {
        [Test]
        public void Test_BinderatorConfig_DownloadBinderatorConfigContents()
        {
            BinderatorConfig bc = new BinderatorConfig();

            Dictionary<string, IEnumerable<(Tag, string)>> configs = bc.DownloadBinderatorConfigContentsAsync
                                                                                (
                                                                                    user_org: "xamarin",
                                                                                    repo: "androidx"
                                                                                ).Result;

            #if MSTEST
            Assert.IsNotNull(configs);
            Assert.IsTrue(configs.Any());
            #elif NUNIT
            Assert.NotNull(configs);
            Assert.IsTrue(configs.Any());
            #elif XUNIT
            Assert.NotNull(configs);
            Assert.True(configs.Any());
            #endif

            Console.WriteLine($"Packages found...");
            foreach (KeyValuePair<string, IEnumerable<(Tag tag, string content)>> c in configs)
            {
                string repo = c.Key;
                Console.WriteLine($"----------------------------------------------------------");
                Console.WriteLine($"Repo   : {c.Key}");
                foreach ((Tag tag, string content) tag_content in c.Value)
                {
                    Console.WriteLine($"        Tag     : {tag_content.tag.Name}");
                    Console.WriteLine($"        Content : {tag_content.content}");
                    System.IO.Directory.CreateDirectory
                                            (
                                                $"binderator-configs/{repo}/{tag_content.tag.Name}/"
                                            );
                    System.IO.File.WriteAllText
                                        (
                                            $"binderator-configs/{repo}/{tag_content.tag.Name}/config.json",
                                            tag_content.content
                                        );
                }

                return;
            }

        }

        [Test]
        public void Test_BinderatorConfig_DownloadBinderatorConfigObjects()
        {
            BinderatorConfig bc = new BinderatorConfig();

            Dictionary<string, IEnumerable<(Tag, List<ConfigRoot>)>> configs = bc.DownloadBinderatorConfigObjectsAsync
                                                                                            (
                                                                                                user_org: "xamarin",
                                                                                                repo: "androidx"
                                                                                            ).Result;
        }

    }
}