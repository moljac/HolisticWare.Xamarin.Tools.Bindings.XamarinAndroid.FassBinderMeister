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
    public partial class Test_Group
    {
        static Test_Group()
        {
            HolisticWare.Xamarin.Tools.Maven.MavenClient.HttpClient = Tests.CommonShared.Http.Client;

            return;
        }

        [Test]
        public void Test_Group_Google_static_defaults()
        {
            // not browsable
            Uri uri_group_default = null;
            Uri uri_group_index_default = new Uri($"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/group-index.xml");

            #if MSTEST
            Assert.IsNull(Group.UrlDefault);
            Assert.IsNotNull(Group.UrlGroupIndexDefault);
            Assert.IsNull(Group.GroupIndexDefault);
            Assert.AreEqual
                        (
                            Group.UrlDefault,
                            uri_group_default
                        );
            Assert.AreEqual
                        (
                            Group.UrlGroupIndexDefault,
                            uri_group_index_default
                        );
            #elif NUNIT
            Assert.Null(Group.UrlDefault);
            Assert.NotNull(Group.UrlGroupIndexDefault);
            Assert.Null(Group.GroupIndexDefault);
            Assert.AreEqual
                        (
                            Group.UrlDefault,
                            uri_group_default
                        );
            Assert.AreEqual
                        (
                            Group.UrlGroupIndexDefault,
                            uri_group_index_default
                        );
            #elif XUNIT
            Assert.Null(Group.UrlDefault);
            Assert.NotNull(Group.UrlGroupIndexDefault);
            Assert.Null(Group.GroupIndexDefault);
            Assert.Equal
                        (
                            Group.UrlDefault,
                            uri_group_default
                        );
            Assert.Equal
                        (
                            Group.UrlGroupIndexDefault,
                            uri_group_index_default
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_static_API_01_GetUriAsync()
        {
            Uri ug_artifact_exists_01 = null;

            ug_artifact_exists_01 = Group.Utilities.GetUriAsync("androidx.car").Result;

            Uri ug_artifact_exists_02 = null;

            ug_artifact_exists_02 = Group.Utilities.GetUriAsync("androidx.window").Result;

            Uri ug_artifact_does_not_exists = null;

            ug_artifact_does_not_exists = Group.Utilities.GetUriAsync("io.opencensus").Result;

            #if MSTEST
            Assert.AreEqual
                        (
                            ug_artifact_exists_01,
                            null
                        );
            Assert.AreEqual
                        (
                            ug_artifact_exists_02,
                            null
                        );
            Assert.AreEqual
                        (
                            ug_artifact_does_not_exists,
                            null
                        );
            #elif NUNIT
            Assert.AreEqual
                        (
                            ug_artifact_exists_01,
                            null
                        );
            Assert.AreEqual
                        (
                            ug_artifact_exists_02,
                            null
                        );
            Assert.AreEqual
                        (
                            ug_artifact_does_not_exists,
                            null
                        );
            #elif XUNIT
            Assert.Equal
                        (
                            ug_artifact_exists_01,
                            null
                        );
            Assert.Equal
                        (
                            ug_artifact_exists_02,
                            null
                        );
            Assert.Equal
                        (
                            ug_artifact_does_not_exists,
                            null
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_static_API_02_GetUriForGroupIndexAsync()
        {
            Uri ugi_artifact_exists_01 = null;

            ugi_artifact_exists_01 = Group.Utilities.GetUriForGroupIndexAsync("androidx.car").Result;

            Uri ugi_artifact_exists_02 = null;

            ugi_artifact_exists_02 = Group.Utilities.GetUriForGroupIndexAsync("androidx.window").Result;

            Uri ugi_artifact_does_not_exists = null;

            ugi_artifact_does_not_exists = Group.Utilities.GetUriForGroupIndexAsync("io.opencensus").Result;

            #if MSTEST
            Assert.AreEqual
                        (
                            ugi_artifact_exists_01,
                            new Uri($"https://dl.google.com/android/maven2/androidx/car/group-index.xml")
                        );
            Assert.AreEqual
                        (
                            ugi_artifact_exists_02,
                            new Uri($"https://dl.google.com/android/maven2/androidx/window/group-index.xml")
                        );
            Assert.AreEqual
                        (
                            ugi_artifact_does_not_exists,
                            null
                        );
            #elif NUNIT
            Assert.AreEqual
                        (
                            ugi_artifact_exists_01,
                            new Uri($"https://dl.google.com/android/maven2/androidx/car/group-index.xml")
                        );
            Assert.AreEqual
                        (
                            ugi_artifact_exists_02,
                            new Uri($"https://dl.google.com/android/maven2/androidx/window/group-index.xml")
                        );
            Assert.AreEqual
                        (
                            ugi_artifact_does_not_exists,
                            null
                        );
            #elif XUNIT
            Assert.Equal
                        (
                            ugi_artifact_exists_01,
                            new Uri($"https://dl.google.com/android/maven2/androidx/car/group-index.xml")
                        );
            Assert.Equal
                        (
                            ugi_artifact_exists_02,
                            new Uri($"https://dl.google.com/android/maven2/androidx/window/group-index.xml")
                        );
            Assert.Equal
                        (
                            ugi_artifact_does_not_exists,
                            null
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_static_API_03_GetGroupIndexAsync()
        {
            HolisticWare.Xamarin.Tools.Maven.GroupIndex gi_artifact_exists_01 = null;

            gi_artifact_exists_01 = Group.Utilities.GetGroupIndexAsync("androidx.car").Result;

            HolisticWare.Xamarin.Tools.Maven.GroupIndex gi_artifact_exists_02 = null;

            gi_artifact_exists_02 = Group.Utilities.GetGroupIndexAsync("androidx.window").Result;

            HolisticWare.Xamarin.Tools.Maven.GroupIndex gi_artifact_does_not_exists = null;

            gi_artifact_does_not_exists = Group.Utilities.GetGroupIndexAsync("io.opencensus").Result;

            #if MSTEST
            Assert.IsNotNull
                        (
                            gi_artifact_exists_01
                        );
            Assert.IsNotNull
                        (
                            gi_artifact_exists_02
                        );
            Assert.IsNotNull
                        (
                            gi_artifact_exists_01.ArtifactsTextual                            
                        );
            Assert.IsNotNull
                        (
                            gi_artifact_exists_02.ArtifactsTextual
                        );
            Assert.IsNull
                        (
                            gi_artifact_does_not_exists
                        );
            #elif NUNIT
            Assert.NotNull
                        (
                            gi_artifact_exists_01
                        );
            Assert.NotNull
                        (
                            gi_artifact_exists_02
                        );
            Assert.NotNull
                        (
                            gi_artifact_exists_01.ArtifactsTextual                            
                        );
            Assert.NotNull
                        (
                            gi_artifact_exists_02.ArtifactsTextual
                        );
            Assert.Null
                        (
                            gi_artifact_does_not_exists
                        );
            #elif XUNIT
            Assert.NotNull
                        (
                            gi_artifact_exists_01
                        );
            Assert.NotNull
                        (
                            gi_artifact_exists_02
                        );
            Assert.NotNull
                        (
                            gi_artifact_exists_01.ArtifactsTextual                            
                        );
            Assert.NotNull
                        (
                            gi_artifact_exists_02.ArtifactsTextual
                        );
            Assert.Null
                        (
                            gi_artifact_does_not_exists
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_static_API_04_GetGroupsMissingForPrefixAsync()
        {
            System.Collections.Generic.List<string> groups_missing = null;

            groups_missing = Group.Utilities.GetGroupsMissingForPrefixAsync
                                                            (
                                                                "androidx",
                                                                new string[]
                                                                        {
                                                                            "window",
                                                                            "compose",
                                                                            "ui",
                                                                            "car",
                                                                        }
                                                            )
                                                            .Result;

            #if MSTEST
            Assert.IsNotNull
                        (
                            groups_missing
                        );
            #elif NUNIT
            Assert.NotNull
                        (
                            groups_missing
                        );
            #elif XUNIT
            Assert.NotNull
                        (
                            groups_missing
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_static_API_05_GetGroupsMissingForContent()
        {
            System.Collections.Generic.List<string> groups_missing_01 = null;

            groups_missing_01 = Group.Utilities.GetGroupsMissingForContentAsync
                                                            (
                                                                "core",
                                                                new string[]
                                                                        {
                                                                            "window",
                                                                            "compose",
                                                                            "ui",
                                                                            "car",
                                                                        }
                                                            )
                                                            .Result;

            System.Collections.Generic.List<string> groups_missing_02 = null;

            groups_missing_02 = Group.Utilities.GetGroupsMissingForContentAsync
                                                            (
                                                                "androidx.core",
                                                                new string[]
                                                                        {
                                                                            "window",
                                                                            "compose",
                                                                            "ui",
                                                                            "car",
                                                                        }
                                                            )
                                                            .Result;

            #if MSTEST
            Assert.IsNotNull
                        (
                            groups_missing_01
                        );
            Assert.IsNotNull
                        (
                            groups_missing_02
                        );
            #elif NUNIT
            Assert.NotNull
                        (
                            groups_missing_01
                        );
            Assert.NotNull
                        (
                            groups_missing_02
                        );
            #elif XUNIT
            Assert.NotNull
                        (
                            groups_missing_01
                        );
            Assert.NotNull
                        (
                            groups_missing_02
                        );
            #endif

            return;
        }


        [Test]
        public void Test_Group_Google_ctor01_androidx_car()
        {
            Group g = new Group("androidx.car");

            Uri uri_group = null;
            Uri uri_group_index = new Uri($"https://dl.google.com/android/maven2/androidx/car/group-index.xml");

            #if MSTEST
            Assert.IsNotNull(g);
            Assert.IsNotNull(g.UrlGroupIndex);
            Assert.IsNotNull(g.GroupIndex);
            Assert.AreEqual
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.AreEqual
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #elif NUNIT
            Assert.NotNull(g);
            Assert.AreEqual
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.AreEqual
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #elif XUNIT
            Assert.NotNull(g);
            Assert.Equal
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.Equal
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_ctor02_androidx_compose()
        {
            string group_textual = "androidx.compose";
            Group g = new Group(group_textual);

            Uri uri_group = null;
            Uri uri_group_index = new Uri
                                        (
                                            Group.UrlGroupIndexDefault
                                                        .AbsoluteUri
                                                        .Replace
                                                            (
                                                                "_PLACEHOLDER_GROUP_ID_",
                                                                group_textual.Replace('.', '/')
                                                            )
                                        );
            
            #if MSTEST
            Assert.IsNotNull(g);
            Assert.IsNotNull(g.UrlGroupIndex);
            Assert.IsNotNull(g.GroupIndex);
            Assert.AreEqual
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.AreEqual
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #elif NUNIT
            Assert.NotNull(g);
            Assert.AreEqual
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.AreEqual
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #elif XUNIT
            Assert.NotNull(g);
            Assert.Equal
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.Equal
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Group_Google_ctor10_io_opencensus()
        {
            string group_textual = "io.opencensus";
            Group g = new Group(group_textual);

            Uri uri_group = null;
            Uri uri_group_index = new Uri
                                        (
                                            Group.UrlGroupIndexDefault
                                                        .AbsoluteUri
                                                        .Replace
                                                            (
                                                                "_PLACEHOLDER_GROUP_ID_",
                                                                group_textual.Replace('.', '/')
                                                            )
                                        );

            #if MSTEST
            Assert.IsNotNull(g);
            Assert.IsNotNull(g.UrlGroupIndex);
            Assert.IsNotNull(g.GroupIndex);
            Assert.AreEqual
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.AreEqual
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #elif NUNIT
            Assert.NotNull(g);
            Assert.AreEqual
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.AreEqual
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #elif XUNIT
            Assert.NotNull(g);
            Assert.Equal
                        (
                            g.UrlGroup,
                            uri_group
                        );
            Assert.Equal
                        (
                            g.UrlGroupIndex,
                            uri_group_index
                        );
            #endif

            return;
        }

    }
}
