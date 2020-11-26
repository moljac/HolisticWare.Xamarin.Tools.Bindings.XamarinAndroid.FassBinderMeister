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

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister;

namespace UnitTests.Android.Developer.ReleaseNotesScraping
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_ReleaseNotesHTMLData
    {
        [Test]
        public void Test_ReleaseNotes_AndroidX_Stable()
        {
            ReleaseNotesHTMLData rn = new ReleaseNotesHTMLData();
            var release_notes_history = rn.ParseAsync(ReleaseNotesUrls.AndroidX.Stable).Result;

            string json_string;
            json_string = System.Text.Json.JsonSerializer.Serialize
                                                            (
                                                                release_notes_history,
                                                                new System.Text.Json.JsonSerializerOptions
                                                                {
                                                                    WriteIndented = true
                                                                }
                                                            );
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            System.IO.File.WriteAllText($"release-notes-androidx-stable-{date}.json", json_string);

            #if MSTEST
            Assert.IsNotNull(rn);
            #elif NUNIT
            Assert.NotNull(rn);
            #elif XUNIT
            Assert.NotNull(rn);
            #endif


            return;
        }

        [Test]
        public void Test_ReleaseNotes_AndroidX_All()
        {
            ReleaseNotesHTMLData rn = new ReleaseNotesHTMLData();
            var release_notes_history = rn.ParseAsync(ReleaseNotesUrls.AndroidX.All).Result;

            string json_string;
            json_string = System.Text.Json.JsonSerializer.Serialize
                                                            (
                                                                release_notes_history,
                                                                new System.Text.Json.JsonSerializerOptions
                                                                {
                                                                    WriteIndented = true
                                                                }
                                                            );
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            System.IO.File.WriteAllText($"release-notes-androidx-all-{date}.json", json_string);

            #if MSTEST
            Assert.IsNotNull(rn);
            #elif NUNIT
            Assert.NotNull(rn);
            #elif XUNIT
            Assert.NotNull(rn);
            #endif

            return;
        }

        [Test]
        public void Test_ReleaseNotes_AndroidX_RC()
        {
            ReleaseNotesHTMLData rn = new ReleaseNotesHTMLData();
            var release_notes_history = rn.ParseAsync(ReleaseNotesUrls.AndroidX.RC).Result;

            string json_string;
            json_string = System.Text.Json.JsonSerializer.Serialize
                                                            (
                                                                release_notes_history,
                                                                new System.Text.Json.JsonSerializerOptions
                                                                {
                                                                    WriteIndented = true
                                                                }
                                                            );
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            System.IO.File.WriteAllText($"release-notes-androidx-rc-{date}.json", json_string);

            #if MSTEST
            Assert.IsNotNull(rn);
            #elif NUNIT
            Assert.NotNull(rn);
            #elif XUNIT
            Assert.NotNull(rn);
            #endif

            return;
        }

        [Test]
        public void Test_ReleaseNotes_AndroidX_Beta()
        {
            ReleaseNotesHTMLData rn = new ReleaseNotesHTMLData();
            var release_notes_history = rn.ParseAsync(ReleaseNotesUrls.AndroidX.Beta).Result;

            string json_string;
            json_string = System.Text.Json.JsonSerializer.Serialize
                                                            (
                                                                release_notes_history,
                                                                new System.Text.Json.JsonSerializerOptions
                                                                {
                                                                    WriteIndented = true
                                                                }
                                                            );
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            System.IO.File.WriteAllText($"release-notes-androidx-beta-{date}.json", json_string);

            #if MSTEST
            Assert.IsNotNull(rn);
            #elif NUNIT
            Assert.NotNull(rn);
            #elif XUNIT
            Assert.NotNull(rn);
            #endif

            return;
        }

        [Test]
        public void Test_ReleaseNotes_AndroidX_Alpha()
        {
            ReleaseNotesHTMLData rn = new ReleaseNotesHTMLData();
            var release_notes_history = rn.ParseAsync(ReleaseNotesUrls.AndroidX.Alpha).Result;

            string json_string;
            json_string = System.Text.Json.JsonSerializer.Serialize
                                                            (
                                                                release_notes_history,
                                                                new System.Text.Json.JsonSerializerOptions
                                                                {
                                                                    WriteIndented = true
                                                                }
                                                            );
            string date = DateTime.Today.ToString("yyyy-MM-dd");
            System.IO.File.WriteAllText($"release-notes-androidx-alpha-{date}.json", json_string);

            #if MSTEST
            Assert.IsNotNull(rn);
            #elif NUNIT
            Assert.NotNull(rn);
            #elif XUNIT
            Assert.NotNull(rn);
            #endif

            return;
        }
    }
}
