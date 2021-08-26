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
using TestClass = Xunit.FactAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
// XUnit aliases
// using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
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

using Core;


namespace UnitTests.ClientsAPI.Maven.Repositories.Google
{
    //using AliasRepoAgnostic   = global::HolisticWare.Xamarin.Tools.Maven;
    using AliasArtifactGoogle = global::HolisticWare.Xamarin.Tools.Maven.Repositories.Google.Artifact;

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
                                                  AliasArtifactGoogle.UrlDefaultTextualRoot
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_"
                                                  ;
            string url_default_textual_binary   =
                                                  AliasArtifactGoogle.UrlDefaultTextualBinary
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.aar"
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.jar"
                                                  ;
            string url_default_textual_pom      =
                                                  AliasArtifactGoogle.UrlDefaultTextualProjectObjectModel
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.pom"
                                                  ;
            string url_default_textual_sources  =
                                                  AliasArtifactGoogle.UrlDefaultTextualSources
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-sources.jar"
                                                  ;
            string url_default_textual_javadoc  =
                                                  AliasArtifactGoogle.UrlDefaultTextualJavaDoc
                                                  // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-javadoc.jar"
                                                  ;
            string url_default_textual_module   =
                                                  AliasArtifactGoogle.UrlDefaultTextualModule
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
        public void Test_Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.pom
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.aar
            byte[] bytez = AliasArtifactGoogle.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            return;
        }

        [Test]
        public void Test_Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = AliasArtifactGoogle.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            return;
        }

        [Test]
        public void Test_Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = AliasArtifactGoogle.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            return;
        }

        [Test]
        public void Test_Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = AliasArtifactGoogle.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_01_ParseArtifactIdFullyQualified()
        {
            AliasArtifactGoogle a01 = new AliasArtifactGoogle("androidx.car", "car", "1.0.0-alpha1");

            AliasArtifactGoogle a02 = new AliasArtifactGoogle("androidx.car", "car", "1.0.0");

            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_02_ParseArtifactIdFullyQualfied()
        {
            AliasArtifactGoogle a01 = new AliasArtifactGoogle("androidx.ads.ads-identifier");

            AliasArtifactGoogle a02 = new AliasArtifactGoogle("androidx.ads:ads-identifier");

            AliasArtifactGoogle a03 = new AliasArtifactGoogle("androidx.ads.ads-identifier-1.0.0");

            AliasArtifactGoogle a04 = new AliasArtifactGoogle("androidx.ads:ads-identifier-1.0.0");

            AliasArtifactGoogle a05 = new AliasArtifactGoogle("androidx.ads:ads-identifier:1.0.0");

            AliasArtifactGoogle a06 = new AliasArtifactGoogle("androidx.ads.ads-identifier-1.0.0-alpha01");

            AliasArtifactGoogle a07 = new AliasArtifactGoogle("androidx.ads:ads-identifier-1.0.0-alpha01");

            AliasArtifactGoogle a08 = new AliasArtifactGoogle("androidx.ads:ads-identifier:1.0.0-alpha01");




            AliasArtifactGoogle a11 = new AliasArtifactGoogle("androidx.car.car");

            AliasArtifactGoogle a12 = new AliasArtifactGoogle("androidx.car:car");

            AliasArtifactGoogle a13 = new AliasArtifactGoogle("androidx.car.car-1.0.0-alpha1");

            AliasArtifactGoogle a14 = new AliasArtifactGoogle("androidx.car:car-1.0.0-alpha1");

            AliasArtifactGoogle a15 = new AliasArtifactGoogle("androidx.car:car:1.0.0-alpha1");

            AliasArtifactGoogle a16 = new AliasArtifactGoogle("androidx.car.car-1.0.0-alpha5");

            AliasArtifactGoogle a17 = new AliasArtifactGoogle("androidx.car:car-1.0.0-alpha5");

            AliasArtifactGoogle a18 = new AliasArtifactGoogle("androidx.car:car:1.0.0-alpha5");



            AliasArtifactGoogle a21 = new AliasArtifactGoogle("androidx.cardview.cardview");

            AliasArtifactGoogle a22 = new AliasArtifactGoogle("androidx.cardview:cardview");

            AliasArtifactGoogle a23 = new AliasArtifactGoogle("androidx.cardview.cardview-1.0.0");

            AliasArtifactGoogle a24 = new AliasArtifactGoogle("androidx.cardview:cardview-1.0.0");

            AliasArtifactGoogle a25 = new AliasArtifactGoogle("androidx.cardview:cardview:1.0.0");

            AliasArtifactGoogle a26 = new AliasArtifactGoogle("androidx.cardview.cardview-1.0.0-alpha3");

            AliasArtifactGoogle a27 = new AliasArtifactGoogle("androidx.cardview:cardview-1.0.0-alpha3");

            AliasArtifactGoogle a28 = new AliasArtifactGoogle("androidx.cardview:cardview:1.0.0-alpha3");

            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_03_DeserializeProjectObjectModelPOM()
        {
            AliasArtifactGoogle a01 = new AliasArtifactGoogle("androidx.car", "car", "1.0.0-alpha1");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p01 = null;
            p01 = a01.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a02 = new AliasArtifactGoogle("androidx.cardview", "cardview", "1.0.0");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p02 = null;
            p02 = a02.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a03 = new AliasArtifactGoogle("androidx.core", "core", "1.6.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p03 = null;
            p03 = a03.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a04 = new AliasArtifactGoogle("androidx.core", "core", "1.6.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p04 = null;
            p04 = a04.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a05 = new AliasArtifactGoogle("androidx.core", "core", "1.6.0");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p05 = null;
            p05 = a05.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a06 = new AliasArtifactGoogle("androidx.fragment", "fragment", "1.3.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p06 = null;
            p06 = a06.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a07 = new AliasArtifactGoogle("androidx.fragment", "fragment", "1.3.6");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p07 = null;
            p07 = a07.DeserializeProjectObjectModelPOMAsync().Result;




            AliasArtifactGoogle a11 = new AliasArtifactGoogle("com.google.android.material", "material", "1.4.0-alpha01");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p11 = null;
            p11 = a11.DeserializeProjectObjectModelPOMAsync().Result;

            AliasArtifactGoogle a12 = new AliasArtifactGoogle("com.google.android.material", "material", "1.4.0");

            HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel.Project p12 = null;
            p12 = a12.DeserializeProjectObjectModelPOMAsync().Result;


            return;
        }

        [Test]
        public void Test_Artifact_Google_member_API_03_DependencyTree()
        {
            Dictionary<string, AliasArtifactGoogle> d01 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a01 = new AliasArtifactGoogle("androidx.car", "car", "1.0.0-alpha1");
            Dictionary<string, AliasArtifactGoogle> result_a01 = a01.DependencyTreeAsync(d01).Result;

            Dictionary<string, AliasArtifactGoogle> d02 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a02 = new AliasArtifactGoogle("androidx.cardview", "cardview", "1.0.0");
            Dictionary<string, AliasArtifactGoogle> result_a02 = a02.DependencyTreeAsync(d02).Result;

            Dictionary<string, AliasArtifactGoogle> d03 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a03 = new AliasArtifactGoogle("androidx.core", "core", "1.6.0-alpha01");
            Dictionary<string, AliasArtifactGoogle> result_a03 = a03.DependencyTreeAsync(d03).Result;

            Dictionary<string, AliasArtifactGoogle> d04 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a04 = new AliasArtifactGoogle("androidx.core", "core", "1.6.0-alpha01");
            Dictionary<string, AliasArtifactGoogle> result_a04 = a04.DependencyTreeAsync(d04).Result;

            Dictionary<string, AliasArtifactGoogle> d05 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a05 = new AliasArtifactGoogle("androidx.core", "core", "1.6.0");
            Dictionary<string, AliasArtifactGoogle> result_a05 = a05.DependencyTreeAsync(d05).Result;

            Dictionary<string, AliasArtifactGoogle> d06 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a06 = new AliasArtifactGoogle("androidx.fragment", "fragment", "1.3.0-alpha01");
            Dictionary<string, AliasArtifactGoogle> result_a06 = a06.DependencyTreeAsync(d06).Result;

            Dictionary<string, AliasArtifactGoogle> d07 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a07 = new AliasArtifactGoogle("androidx.fragment", "fragment", "1.3.6");
            Dictionary<string, AliasArtifactGoogle> result_a07 = a07.DependencyTreeAsync(d07).Result;




            Dictionary<string, AliasArtifactGoogle> d11 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a11 = new AliasArtifactGoogle("com.google.android.material", "material", "1.4.0-alpha01");
            Dictionary<string, AliasArtifactGoogle> result_a11 = a11.DependencyTreeAsync(d11).Result;

            Dictionary<string, AliasArtifactGoogle> d12 = new Dictionary<string, AliasArtifactGoogle>();
            AliasArtifactGoogle a12 = new AliasArtifactGoogle("com.google.android.material", "material", "1.4.0");
            Dictionary<string, AliasArtifactGoogle> result_a12 = a12.DependencyTreeAsync(d12).Result;

            return;
        }

    }
}
