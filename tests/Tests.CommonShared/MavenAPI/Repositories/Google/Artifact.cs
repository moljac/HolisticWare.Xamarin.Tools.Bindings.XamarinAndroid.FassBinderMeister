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
using Core;
using System.Collections.Generic;

namespace UnitTests.ClientsAPI.Maven.Repositories.Google
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_Artifact
    {
        static Test_Artifact()
        {
            HolisticWare.Xamarin.Tools.Maven.MavenClient.HttpClient = Tests.CommonShared.Http.Client;

            return;
        }

        [Test]
        public void Test_Artifact_Google_static_defaults()
        {
            /*
                https://dl.google.com/android/maven2/androidx/biometric/biometric/1.1.0/biometric-1.1.0.aar
                https://dl.google.com/android/maven2/androidx/biometric/biometric/1.1.0/biometric-1.1.0.pom
                https://dl.google.com/android/maven2/androidx/biometric/biometric/1.1.0/biometric-1.1.0-sources.jar
                https://dl.google.com/android/maven2/androidx/biometric/biometric/1.1.0/biometric-1.1.0-javadoc.jar
                https://dl.google.com/android/maven2/androidx/biometric/biometric/1.1.0/biometric-1.1.0.module
             */
            string url_default_textual_root     =
                                                  Artifact.UrlDefaultTextualRoot
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_"
                                                  ;
            string url_default_textual_binary   =
                                                  Artifact.UrlDefaultTextualBinary
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.aar"
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.jar"
                                                  ;
            string url_default_textual_pom      =
                                                  Artifact.UrlDefaultTextualProjectObjectModel
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.pom"
                                                  ;
            string url_default_textual_sources  =
                                                  Artifact.UrlDefaultTextualSources
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-sources.jar"
                                                  ;
            string url_default_textual_javadoc  =
                                                  Artifact.UrlDefaultTextualJavaDoc
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-javadoc.jar"
                                                  ;
            string url_default_textual_module   =
                                                  Artifact.UrlDefaultTextualModule
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.module"
                                                  ;


            // not browsable
            Uri uri_group_default = null;
            Uri uri_group_index_default = new Uri($"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_");


            #if MSTEST
            Assert.IsNotNull(url_default_textual_root);
            Assert.IsNotNull(url_default_textual_binary);
            Assert.IsNotNull(url_default_textual_pom);
            Assert.IsNotNull(url_default_textual_sources);
            Assert.IsNotNull(url_default_textual_javadoc);
            Assert.IsNotNull(url_default_textual_module);
            Assert.AreEqual
                        (
                            url_default_textual_root,
                            $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/group-index.xml"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_binary,
                            $"{url_default_textual_root}._PLACEHOLDER_BINARY_EXTENSION_"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_pom,
                            $"{url_default_textual_root}.pom"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_sources,
                            $"{url_default_textual_root}-sources.jar"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_javadoc,
                            $"{url_default_textual_root}-javadoc.jar"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_module,
                            $"{url_default_textual_root}.module"
                        );
            #elif NUNIT
            Assert.NotNull(url_default_textual_root);
            Assert.NotNull(url_default_textual_binary);
            Assert.NotNull(url_default_textual_pom);
            Assert.NotNull(url_default_textual_sources);
            Assert.NotNull(url_default_textual_javadoc);
            Assert.NotNull(url_default_textual_module);
            Assert.AreEqual
                        (
                            url_default_textual_binary,
                            $"{url_default_textual_root}._PLACEHOLDER_BINARY_EXTENSION_"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_pom,
                            $"{url_default_textual_root}.pom"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_sources,
                            $"{url_default_textual_root}-sources.jar"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_javadoc,
                            $"{url_default_textual_root}-javadoc.jar"
                        );
            Assert.AreEqual
                        (
                            url_default_textual_module,
                            $"{url_default_textual_root}.module"
                        );
            #elif XUNIT
            Assert.NotNull(url_default_textual_root);
            Assert.NotNull(url_default_textual_binary);
            Assert.NotNull(url_default_textual_pom);
            Assert.NotNull(url_default_textual_sources);
            Assert.NotNull(url_default_textual_javadoc);
            Assert.NotNull(url_default_textual_module);
            Assert.Equal
                        (
                            url_default_textual_binary,
                            $"{url_default_textual_root}._PLACEHOLDER_BINARY_EXTENSION_"
                        );
            Assert.Equal
                        (
                            url_default_textual_pom,
                            $"{url_default_textual_root}.pom"
                        );
            Assert.Equal
                        (
                            url_default_textual_sources,
                            $"{url_default_textual_root}-sources.jar"
                        );
            Assert.Equal
                        (
                            url_default_textual_javadoc,
                            $"{url_default_textual_root}-javadoc.jar"
                        );
            Assert.Equal
                        (
                            url_default_textual_module,
                            $"{url_default_textual_root}.module"
                        );
            #endif

            return;
        }

        [Test]
        public void Test_Artifact_Google_static_API_01_ParseArtifactIdFullyQualified()
        {
            // unversioned:
            //                  androidx.ads.ads-identifier
            //                  androidx.ads:ads-identifier
            // versioned:
            //                  androidx.ads.ads-identifier-1.0.0
            //                  androidx.ads:ads-identifier-1.0.0
            //                  androidx.ads.ads-identifier-1.0.0
            //                  androidx.ads:ads-identifier-1.0.0

            (string id_group, string id_artifact, string version) a01;
            a01 = Artifact.Utilities.ParseArtifactIdFullyQualified("androidx.ads.ads-identifier");

            (string id_group, string id_artifact, string version) a02;
            a02 = Artifact.Utilities.ParseArtifactIdFullyQualified("androidx.ads:ads-identifier");

            (string id_group, string id_artifact, string version) a03;
            a03 = Artifact.Utilities.ParseArtifactIdFullyQualified("androidx.biometric.biometric-1.0.0");

            (string id_group, string id_artifact, string version) a04;
            a04 = Artifact.Utilities.ParseArtifactIdFullyQualified("androidx.biometric:biometric-1.0.0");

            (string id_group, string id_artifact, string version) a05;
            a05 = Artifact.Utilities.ParseArtifactIdFullyQualified("androidx.ads.ads-identifier-1.0.0-alpha04");

            (string id_group, string id_artifact, string version) a06;
            a06 = Artifact.Utilities.ParseArtifactIdFullyQualified("androidx.ads:ads-identifier-1.0.0-alpha04");

            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_01_ParseArtifactIdFullyQualified()
        {
            Artifact a01 = new Artifact("androidx.car", "car", "1.0.0-alpha1");

            Artifact a02 = new Artifact("androidx.car", "car", "1.0.0");

            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_02_ParseArtifactIdFullyQualfied()
        {
            Artifact a01 = new Artifact("androidx.ads.ads-identifier");

            Artifact a02 = new Artifact("androidx.ads:ads-identifier");

            Artifact a03 = new Artifact("androidx.ads.ads-identifier-1.0.0");

            Artifact a04 = new Artifact("androidx.ads:ads-identifier-1.0.0");

            Artifact a05 = new Artifact("androidx.ads:ads-identifier:1.0.0");

            Artifact a06 = new Artifact("androidx.ads.ads-identifier-1.0.0-alpha01");

            Artifact a07 = new Artifact("androidx.ads:ads-identifier-1.0.0-alpha01");

            Artifact a08 = new Artifact("androidx.ads:ads-identifier:1.0.0-alpha01");




            Artifact a11 = new Artifact("androidx.car.car");

            Artifact a12 = new Artifact("androidx.car:car");

            Artifact a13 = new Artifact("androidx.car.car-1.0.0-alpha1");

            Artifact a14 = new Artifact("androidx.car:car-1.0.0-alpha1");

            Artifact a15 = new Artifact("androidx.car:car:1.0.0-alpha1");

            Artifact a16 = new Artifact("androidx.car.car-1.0.0-alpha5");

            Artifact a17 = new Artifact("androidx.car:car-1.0.0-alpha5");

            Artifact a18 = new Artifact("androidx.car:car:1.0.0-alpha5");



            Artifact a21 = new Artifact("androidx.cardview.cardview");

            Artifact a22 = new Artifact("androidx.cardview:cardview");

            Artifact a23 = new Artifact("androidx.cardview.cardview-1.0.0");

            Artifact a24 = new Artifact("androidx.cardview:cardview-1.0.0");

            Artifact a25 = new Artifact("androidx.cardview:cardview:1.0.0");

            Artifact a26 = new Artifact("androidx.cardview.cardview-1.0.0-alpha3");

            Artifact a27 = new Artifact("androidx.cardview:cardview-1.0.0-alpha3");

            Artifact a28 = new Artifact("androidx.cardview:cardview:1.0.0-alpha3");

            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_03_DeserializeProjectObjectModelPOM()
        {
            Artifact a01 = new Artifact("androidx.car", "car", "1.0.0-alpha1");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p01 = null;
            p01 = a01.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a02 = new Artifact("androidx.cardview", "cardview", "1.0.0");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p02 = null;
            p02 = a02.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a03 = new Artifact("androidx.core", "core", "1.6.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p03 = null;
            p03 = a03.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a04 = new Artifact("androidx.core", "core", "1.6.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p04 = null;
            p04 = a04.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a05 = new Artifact("androidx.core", "core", "1.6.0");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p05 = null;
            p05 = a05.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a06 = new Artifact("androidx.fragment", "fragment", "1.3.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p06 = null;
            p06 = a06.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a07 = new Artifact("androidx.fragment", "fragment", "1.3.6");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p07 = null;
            p07 = a07.DeserializeProjectObjectModelPOMAsync().Result;




            Artifact a11 = new Artifact("com.google.android.material", "material", "1.4.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p11 = null;
            p11 = a11.DeserializeProjectObjectModelPOMAsync().Result;

            Artifact a12 = new Artifact("com.google.android.material", "material", "1.4.0");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p12 = null;
            p12 = a12.DeserializeProjectObjectModelPOMAsync().Result;


            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_03_DependencyTree()
        {
            Dictionary<string, Artifact> d01 = new Dictionary<string, Artifact>();
            Artifact a01 = new Artifact("androidx.car", "car", "1.0.0-alpha1");
            a01.DependencyTreeAsync(d01).Result;

            Dictionary<string, Artifact> d02 = new Dictionary<string, Artifact>();
            Artifact a02 = new Artifact("androidx.cardview", "cardview", "1.0.0");
            a02.DependencyTreeAsync(d02).Result;

            Dictionary<string, Artifact> d03 = new Dictionary<string, Artifact>();
            Artifact a03 = new Artifact("androidx.core", "core", "1.6.0-alpha01");
            a03.DependencyTreeAsync(d03).Result;

            Dictionary<string, Artifact> d04 = new Dictionary<string, Artifact>();
            Artifact a04 = new Artifact("androidx.core", "core", "1.6.0-alpha01");
            a04.DependencyTreeAsync(d04).Result;

            Dictionary<string, Artifact> d05 = new Dictionary<string, Artifact>();
            Artifact a05 = new Artifact("androidx.core", "core", "1.6.0");
            a05.DependencyTreeAsync(d05).Result;

            Dictionary<string, Artifact> d06 = new Dictionary<string, Artifact>();
            Artifact a06 = new Artifact("androidx.fragment", "fragment", "1.3.0-alpha01");
            a06.DependencyTreeAsync(d06).Result;

            Dictionary<string, Artifact> d07 = new Dictionary<string, Artifact>();
            Artifact a07 = new Artifact("androidx.fragment", "fragment", "1.3.6");
            a07.DependencyTreeAsync(d07).Result;




            Dictionary<string, Artifact> d11 = new Dictionary<string, Artifact>();
            Artifact a11 = new Artifact("com.google.android.material", "material", "1.4.0-alpha01");
            a11.DependencyTreeAsync(d11).Result;

            Dictionary<string, Artifact> d12 = new Dictionary<string, Artifact>();
            Artifact a12 = new Artifact("com.google.android.material", "material", "1.4.0");
            a12.DependencyTreeAsync(d12).Result;

            return;
        }

    }
}
