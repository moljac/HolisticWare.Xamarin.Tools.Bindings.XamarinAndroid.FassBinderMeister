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
using System.Collections.Generic;

using HolisticWare.Xamarin.Tools.Maven.Repositories.Google;

//using AliasRepoAgnostic   = global::HolisticWare.Xamarin.Tools.Maven;
//using Artifact = global::HolisticWare.Xamarin.Tools.Maven.Repositories.Google.Artifact;

namespace UnitTests.Tools.Maven.Repositories.Google
{

    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class 
                                        Artifact_static_API_Test
    {
        static 
                                        Artifact_static_API_Test
                                            (
                                            )
        {
            HolisticWare.Xamarin.Tools.Maven.MavenClient.HttpClient = Tests.CommonShared.Http.Client;

            // download and save tests
            if ( ! System.IO.Directory.Exists("../../../../../../../../output/"))
            {
                System.IO.Directory.CreateDirectory("../../../../../../../../output/");
            }
            
            return;
        }

        [Test]
        public void 
                                        Defaults
                                            (
                                            )
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
        
        //-----------------------------------------------------------------------------------------------------------
        #region         Download androidx.car.car
        // https://maven.google.com/web/index.html?q=car#androidx.car:car:1.0.0-alpha7

        [Test]
        public void Repository_Google_static_API_01_DownloadProjectObjecModelPOMAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.pom
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.aar
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadModuleAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.module
            string module = Artifact.Utilities.DownloadModuleAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(module);
            Assert.IsTrue(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.pom
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.aar
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_androidx_car_car_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveModuleAsync_androidx_car_car_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.module
            string module = Artifact.Utilities.DownloadThenSaveModuleAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(module);
            Assert.IsTrue(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_androidx_car_car_02()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.pom
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7",
                                                                    "../../../../../../../../output/androidx.car.car-1.0.0-alpha7.pom"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_androidx_car_car_02()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.aar
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7",
                                                                    "../../../../../../../../output/androidx.car.car-1.0.0-alpha7.aar"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_androidx_car_car_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7",
                                                                    "../../../../../../../../output/androidx.car.car-1.0.0-alpha7.jar"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_androidx_car_car_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7",
                                                                    "../../../../../../../../output/androidx.car.car-1.0.0-alpha7.jar"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_androidx_car_car_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7",
                                                                    "../../../../../../../../output/androidx.car.car-1.0.0-alpha7-sources.jar"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadThenSaveModuleAsync_androidx_car_car_02()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.module
            string module = Artifact.Utilities.DownloadThenSaveModuleAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7",
                                                                    "../../../../../../../../output/androidx.car.car-1.0.0-alpha7.module"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(module);
            Assert.IsTrue(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #endif

            return;
        }

        #endregion      Download androidx.car.car
        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------
        #region         Download androidx.biometric.biometric
        // https://maven.google.com/web/index.html#androidx.biometric:biometric:1.1.0

        [Test]
        public void Repository_Google_static_API_01_DownloadProjectObjecModelPOMAsync_androidx_biometric_biometric_01()
        {
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "androidx.biometric",
                                                                    "biometric",
                                                                    "1.1.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_androidx_biometric_biometric_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "androidx.biometric",
                                                                    "biometric",
                                                                    "1.1.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_androidx_biometric_biometric_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "androidx.biometric",
                                                                    "biometric",
                                                                    "1.1.0"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_androidx_biometric_biometric_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "androidx.biometric",
                                                                    "biometric",
                                                                    "1.1.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_androidx_biometric_biometric_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "androidx.biometric",
                                                                    "biometric",
                                                                    "1.1.0"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadModuleAsync_androidx_biometric_biometric_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.module
            string module = Artifact.Utilities.DownloadModuleAsync
                                                                (
                                                                    "androidx.biometric",
                                                                    "biometric",
                                                                    "1.1.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module);
            Assert.IsFalse(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.NotNull(module);
            Assert.False(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.NotNull(module);
            Assert.False(string.IsNullOrEmpty(module));
            #endif

            return;
        }
        #endregion      Download androidx.biometric.biometric
        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------
        #region         Download androidx.appcompat.appcompat
        // https://maven.google.com/web/index.html#androidx.appcompat:appcompat:1.3.1

        [Test]
        public void Repository_Google_static_API_01_DownloadProjectObjecModelPOMAsync_androidx_appcompat_appcompat_01()
        {
            // https://dl.google.com/android/maven2/androidx/appcompat/appcompat/1.3.1/car-1.3.1.pom
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "androidx.appcompat",
                                                                    "appcompat",
                                                                    "1.3.1"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_androidx_appcompat_appcompat_01()
        {
            // https://dl.google.com/android/maven2/androidx/appcompat/appcompat/1.3.1/car-1.3.1.aar
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "androidx.appcompat",
                                                                    "appcompat",
                                                                    "1.3.1"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_androidx_appcompat_appcompat_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "androidx.appcompat",
                                                                    "appcompat",
                                                                    "1.3.1"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_androidx_appcompat_appcompat_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "androidx.appcompat",
                                                                    "appcompat",
                                                                    "1.3.1"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_androidx_appcompat_appcompat_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "androidx.appcompat",
                                                                    "appcompat",
                                                                    "1.3.1"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadModuleAsync_androidx_appcompat_appcompat_01()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.module
            string module = Artifact.Utilities.DownloadModuleAsync
                                                                (
                                                                    "androidx.car",
                                                                    "car",
                                                                    "1.0.0-alpha7"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(module);
            Assert.IsTrue(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #endif

            return;
        }
        #endregion      Download androidx.appcompat.appcompat
        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------
        #region         Download com.google.android.gms.play-services-ads
        // https://maven.google.com/web/index.html?#com.google.android.gms:play-services-ads:20.3.0

        [Test]
        public void Repository_Google_static_API_01_DownloadProjectObjecModelPOMAsync_com_google_android_gms_play_services_ads_01()
        {
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.android.gms",
                                                                    "play-services-ads",
                                                                    "20.3.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_com_google_android_gms_play_services_ads_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.android.gms",
                                                                    "play-services-ads",
                                                                    "20.3.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_com_google_android_gms_play_services_ads_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.android.gms",
                                                                    "play-services-ads",
                                                                    "20.3.0"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_com_google_android_gms_play_services_ads_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.android.gms",
                                                                    "play-services-ads",
                                                                    "20.3.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_com_google_android_gms_play_services_ads_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.android.gms",
                                                                    "play-services-ads",
                                                                    "20.3.0"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadModuleAsync_com_google_android_gms_play_services_ads_01()
        {
            string module = Artifact.Utilities.DownloadModuleAsync
                                                                (
                                                                    "com.google.android.gms",
                                                                    "play-services-ads",
                                                                    "20.3.0"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(module);
            Assert.IsTrue(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #endif

            return;
        }
        #endregion      Download com.google.android.gms.play-services-ads
        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------
        #region         Download org.chromium.net.cronet-api
        // https://maven.google.com/web/index.html?#org.chromium.net:cronet-api:92.4515.131
        [Test]
        public void Repository_Google_static_API_01_DownloadProjectObjecModelPOMAsync_org_chromium_net_cronet_api_01()
        {
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "org.chromium.net",
                                                                    "cronet-api",
                                                                    "92.4515.131"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_org_chromium_net_cronet_api_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "org.chromium.net",
                                                                    "cronet-api",
                                                                    "92.4515.131"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.NotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_org_chromium_net_cronet_api_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "org.chromium.net",
                                                                    "cronet-api",
                                                                    "92.4515.131"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_org_chromium_net_cronet_api_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "org.chromium.net",
                                                                    "cronet-api",
                                                                    "92.4515.131"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_org_chromium_net_cronet_api_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "org.chromium.net",
                                                                    "cronet-api",
                                                                    "92.4515.131"
                                                                )
                                                                .Result;
            #if MSTEST



            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadModuleAsync_org_chromium_net_cronet_api_01()
        {
            string module = Artifact.Utilities.DownloadModuleAsync
                                                                (
                                                                    "org.chromium.net",
                                                                    "cronet-api",
                                                                    "92.4515.131"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(module);
            Assert.IsTrue(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.Null(module);
            Assert.True(string.IsNullOrEmpty(module));
            #endif

            return;
        }
        #endregion      Download org.chromium.net.cronet-api
        //-----------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------
        #region         Download com.android.tools.build.jetifier.jetifier-core
        // https://maven.google.com/web/index.html?#com.android.tools.build.jetifier:jetifier-core:1.0.0-beta10
        [Test]
        public void Repository_Google_static_API_01_DownloadProjectObjecModelPOMAsync_com_android_tools_build_jetifier_jetifier_core_01()
        {
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "com.android.tools.build.jetifier",
                                                                    "jetifier-core",
                                                                    "1.0.0-beta10"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(pom);
            Assert.IsFalse(string.IsNullOrEmpty(pom));
            #elif NUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #elif XUNIT
            Assert.NotNull(pom);
            Assert.False(string.IsNullOrEmpty(pom));
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactAndroidArchiveAARAsync_com_android_tools_build_jetifier_jetifier_core_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.android.tools.build.jetifier",
                                                                    "jetifier-core",
                                                                    "1.0.0-beta10"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.Null(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadArtifactJavaArchiveJARAsync_com_android_tools_build_jetifier_jetifier_core_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.android.tools.build.jetifier",
                                                                    "jetifier-core",
                                                                    "1.0.0-beta10"
                                                                )
                                                                .Result;
            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadJavaDocJavaArchiveJARAsync_com_android_tools_build_jetifier_jetifier_core_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.android.tools.build.jetifier",
                                                                    "jetifier-core",
                                                                    "1.0.0-beta10"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNull(bytez);
            #elif NUNIT
            Assert.IsNull(bytez);
            #elif XUNIT
            Assert.Null(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadSourcesJavaArchiveJARAsync_com_android_tools_build_jetifier_jetifier_core_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.android.tools.build.jetifier",
                                                                    "jetifier-core",
                                                                    "1.0.0-beta10"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(bytez);
            #elif NUNIT
            Assert.IsNotNull(bytez);
            #elif XUNIT
            Assert.NotNull(bytez);
            #endif

            return;
        }

        [Test]
        public void Repository_Google_static_API_01_DownloadModuleAsync_com_android_tools_build_jetifier_jetifier_core_01()
        {
            string module = Artifact.Utilities.DownloadModuleAsync
                                                                (
                                                                    "com.android.tools.build.jetifier",
                                                                    "jetifier-core",
                                                                    "1.0.0-beta10"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module);
            Assert.IsFalse(string.IsNullOrEmpty(module));
            #elif NUNIT
            Assert.NotNull(module);
            Assert.False(string.IsNullOrEmpty(module));
            #elif XUNIT
            Assert.NotNull(module);
            Assert.False(string.IsNullOrEmpty(module));
            #endif

            return;
        }
        #endregion      Download com.android.tools.build.jetifier.jetifier-core
        //-----------------------------------------------------------------------------------------------------------


        [Test]
        public void Artifact_Google_member_API_01_ParseArtifactIdFullyQualified()
        {
            Artifact a01 = new Artifact("androidx.car", "car", "1.0.0-alpha1");

            Artifact a02 = new Artifact("androidx.car", "car", "1.0.0");

            return;
        }

        [Test]
        public void Artifact_Google_member_API_02_ParseArtifactIdFullyQualfied()
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
        public void Artifact_Google_member_API_03_DeserializeProjectObjectModelPOM()
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
        public void Artifact_Google_member_API_03_DependencyTree()
        {
            Dictionary<string, Artifact> d01 = new Dictionary<string, Artifact>();
            Artifact a01 = new Artifact("androidx.car", "car", "1.0.0-alpha1");
            Dictionary<string, Artifact> result_a01 = a01.DependencyTreeAsync(d01).Result;

            Dictionary<string, Artifact> d02 = new Dictionary<string, Artifact>();
            Artifact a02 = new Artifact("androidx.cardview", "cardview", "1.0.0");
            Dictionary<string, Artifact> result_a02 = a02.DependencyTreeAsync(d02).Result;

            Dictionary<string, Artifact> d03 = new Dictionary<string, Artifact>();
            Artifact a03 = new Artifact("androidx.core", "core", "1.6.0-alpha01");
            Dictionary<string, Artifact> result_a03 = a03.DependencyTreeAsync(d03).Result;

            Dictionary<string, Artifact> d04 = new Dictionary<string, Artifact>();
            Artifact a04 = new Artifact("androidx.core", "core", "1.6.0-alpha01");
            Dictionary<string, Artifact> result_a04 = a04.DependencyTreeAsync(d04).Result;

            Dictionary<string, Artifact> d05 = new Dictionary<string, Artifact>();
            Artifact a05 = new Artifact("androidx.core", "core", "1.6.0");
            Dictionary<string, Artifact> result_a05 = a05.DependencyTreeAsync(d05).Result;

            Dictionary<string, Artifact> d06 = new Dictionary<string, Artifact>();
            Artifact a06 = new Artifact("androidx.fragment", "fragment", "1.3.0-alpha01");
            Dictionary<string, Artifact> result_a06 = a06.DependencyTreeAsync(d06).Result;

            Dictionary<string, Artifact> d07 = new Dictionary<string, Artifact>();
            Artifact a07 = new Artifact("androidx.fragment", "fragment", "1.3.6");
            Dictionary<string, Artifact> result_a07 = a07.DependencyTreeAsync(d07).Result;




            Dictionary<string, Artifact> d11 = new Dictionary<string, Artifact>();
            Artifact a11 = new Artifact("com.google.android.material", "material", "1.4.0-alpha01");
            Dictionary<string, Artifact> result_a11 = a11.DependencyTreeAsync(d11).Result;

            Dictionary<string, Artifact> d12 = new Dictionary<string, Artifact>();
            Artifact a12 = new Artifact("com.google.android.material", "material", "1.4.0");
            Dictionary<string, Artifact> result_a12 = a12.DependencyTreeAsync(d12).Result;

            return;
        }

    }
}
