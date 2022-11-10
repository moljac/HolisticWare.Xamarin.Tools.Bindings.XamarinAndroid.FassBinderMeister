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

using HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype;

//using AliasRepoAgnostic   = global::HolisticWare.Xamarin.Tools.Maven;
//using Artifact = global::HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype.Artifact;

namespace UnitTests.Tools.Maven.Repositories.MavenCentralSonatype
{

    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_Artifact
    {
        static Test_Artifact()
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
        public void Test_Artifact_MavenCentralSonatype_static_defaults()
        {
            /*
             */
            string url_default_textual_root     =
                                                  Artifact.UrlDefaultTextualRoot
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_"
                                                  ;
            string url_default_textual_binary   =
                                                  Artifact.UrlDefaultTextualBinary
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.aar"
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.jar"
                                                  ;
            string url_default_textual_pom      =
                                                  Artifact.UrlDefaultTextualProjectObjectModel
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_.pom"
                                                  ;
            string url_default_textual_sources  =
                                                  Artifact.UrlDefaultTextualSources
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-sources.jar"
                                                  ;
            string url_default_textual_javadoc  =
                                                  Artifact.UrlDefaultTextualJavaDoc
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-javadoc.jar"
                                                  ;
            string url_default_textual_module   =
                                                  Artifact.UrlDefaultTextualModule
                                                  // $"https://repo1.maven.org/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_-javadoc.jar"
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
                            $""
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
        #region         Download com_google_crypto_tink_tink_android
        // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/
        // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadProjectObjecModelPOMAsync_com_google_crypto_tink_tink_android_01()
        {
            // 
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactAndroidArchiveAARAsync_com_google_crypto_tink_tink_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1.jar
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactJavaArchiveJARAsync_com_google_crypto_tink_tink_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1.jar
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadJavaDocJavaArchiveJARAsync_com_google_crypto_tink_tink_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1-javadoc.jar
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadSourcesJavaArchiveJARAsync_com_google_crypto_tink_tink_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadMetadataAsync_com_google_crypto_tink_tink_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/maven-metadata.xml
            string module_01 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif


            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_google_crypto_tink_tink_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1.pom
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_google_crypto_tink_tink_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/1.6.1/tink-android-1.6.1.aar
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_google_crypto_tink_tink_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_google_crypto_tink_tink_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_google_crypto_tink_tink_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveModuleAsync_com_google_crypto_tink_tink_android_01()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_google_crypto_tink_tink_android_02()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.pom
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.pom"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_google_crypto_tink_tink_android_02()
        {
            // 
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.aar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_google_crypto_tink_tink_android_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_google_crypto_tink_tink_android_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-javadoc.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_google_crypto_tink_tink_android_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-sources.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveMetadataAsync_com_google_crypto_tink_tink_android_02()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.crypto.tink",
                                                                    "tink-android",
                                                                    "1.6.1",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        #endregion      Download com_google_crypto_tink_tink_android
        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------
        #region         Download com_google_crypto_dagger_dagger_android
        // https://repo1.maven.org/maven2/com/google/dagger/dagger-android/
        // https://repo1.maven.org/maven2/com/google/dagger/dagger-android/2.9/

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadProjectObjecModelPOMAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // 
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactAndroidArchiveAARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1.aar
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1.jar
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadJavaDocJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1-javadoc.jar
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadSourcesJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadMetadataAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/maven-metadata.xml
            string module_01 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif


            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/
            // https://repo1.maven.org/maven2/com/google/crypto/tink/tink-android/1.6.1/tink-android-1.6.1.pom
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // https://repo1.maven.org/maven2/com/google/crypto/tink/1.6.1/tink-android-1.6.1.aar
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_01()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveModuleAsync_com_google_crypto_dagger_dagger_android_01()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_google_crypto_dagger_dagger_android_02()
        {
            // https://dl.google.com/android/maven2/androidx/car/car/1.0.0-alpha7/car-1.0.0-alpha7.pom
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.pom"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_google_crypto_dagger_dagger_android_02()
        {
            // 
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.aar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-javadoc.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_google_crypto_dagger_dagger_android_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-sources.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveMetadataAsync_com_google_crypto_dagger_dagger_android_02()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.dagger",
                                                                    "dagger-android",
                                                                    "2.9",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        #endregion      Download com_google_crypto_dagger_dagger_android
        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------
        #region         Download com_squareup_dagger_dagger
        // https://repo1.maven.org/maven2/com/squareup/dagger/dagger/
        // https://repo1.maven.org/maven2/com/squareup/dagger/dagger/1.2.5/

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadProjectObjecModelPOMAsync_com_squareup_dagger_dagger_01()
        {
            // 
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactAndroidArchiveAARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactJavaArchiveJARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadJavaDocJavaArchiveJARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadSourcesJavaArchiveJARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadMetadataAsync_com_squareup_dagger_dagger_01()
        {
            string module_01 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif


            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_squareup_dagger_dagger_01()
        {
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_squareup_dagger_dagger_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveModuleAsync_com_squareup_dagger_dagger_01()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_squareup_dagger_dagger_02()
        {
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5.pom"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_squareup_dagger_dagger_02()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5.aar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_squareup_dagger_dagger_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_squareup_dagger_dagger_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5-javadoc.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_squareup_dagger_dagger_02()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5-sources.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveMetadataAsync_com_squareup_dagger_dagger_02()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "1.2.5",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.squareup.dagger",
                                                                    "dagger",
                                                                    "../../../../../../../../output/com.squareup.dagger:dagger:1.2.5-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        #endregion      Download com_squareup_dagger_dagger
        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------
        #region         Download org_jetbrains_kotlin_kotlin_stdlib
        // https://repo1.maven.org/maven2/org/jetbrains/kotlin/kotlin-stdlib/
        // https://repo1.maven.org/maven2/org/jetbrains/kotlin/kotlin-stdlib/1.5.30/
        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadProjectObjecModelPOMAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            // 
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactAndroidArchiveAARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadJavaDocJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadSourcesJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadMetadataAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            string module_01 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif


            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveModuleAsync_org_jetbrains_kotlin_kotlin_stdlib_01()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_org_jetbrains_kotlin_kotlin_stdlib_02()
        {
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.pom"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_org_jetbrains_kotlin_kotlin_stdlib_02()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.aar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-javadoc.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_org_jetbrains_kotlin_kotlin_stdlib_02()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-sources.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveMetadataAsync_org_jetbrains_kotlin_kotlin_stdlib_02()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "1.5.30",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
            #elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
            #endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "org.jetbrains.kotlin",
                                                                    "kotlin-stdlib",
                                                                    "../../../../../../../../output/com.google.crypto.tink:tink-android:1.6.1-maven-metadata.xml"
                                                                )
                                                                .Result;

            #if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
            #elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
            #endif

            return;
        }

        #endregion      Download org_jetbrains_kotlin_kotlin_stdlib
        //-----------------------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------------------
        #region         Download com_google_guava_guava
        // https://repo1.maven.org/maven2/com/google/guava/guava/
        // https://repo1.maven.org/maven2/com/google/guava/guava/30.1-android/
        // https://repo1.maven.org/maven2/com/google/guava/guava-io/r03/

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadProjectObjecModelPOMAsync_com_google_guava_guava_01()
        {
            // 
            string pom = Artifact.Utilities.DownloadProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactAndroidArchiveAARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadArtifactJavaArchiveJARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadJavaDocJavaArchiveJARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadSourcesJavaArchiveJARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadMetadataAsync_com_google_guava_guava_01()
        {
            string module_01 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava"
                                                                )
                                                                .Result;

#if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
#elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
#elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
#endif


            string module_02 = Artifact.Utilities.DownloadMetadataAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
                                                                )
                                                                .Result;

#if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
#elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
#elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
#endif


            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_google_guava_guava_01()
        {
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_google_guava_guava_01()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveModuleAsync_com_google_guava_guava_01()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava"
                                                                )
                                                                .Result;

#if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
#elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
#elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
#endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android"
                                                                )
                                                                .Result;

#if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
#elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
#elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
#endif

            return;
        }

        [Test]
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveProjectObjecModelPOMAsync_com_google_guava_guava_02()
        {
            string pom = Artifact.Utilities.DownloadThenSaveProjectObjecModelPOMAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android.pom"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactAndroidArchiveAARAsync_com_google_guava_guava_02()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android.aar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveArtifactJavaArchiveJARAsync_com_google_guava_guava_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveArtifactJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveJavaDocJavaArchiveJARAsync_com_google_guava_guava_02()
        {
            // N/A
            byte[] bytez = Artifact.Utilities.DownloadThenSaveJavaDocJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android-javadoc.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveSourcesJavaArchiveJARAsync_com_google_guava_guava_02()
        {
            byte[] bytez = Artifact.Utilities.DownloadThenSaveSourcesJavaArchiveJARAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android-sources.jar"
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
        public void Test_Repository_MavenCentralSonatype_static_API_01_DownloadThenSaveMetadataAsync_com_google_guava_guava_02()
        {
            string module_01 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "30.1-android",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android-maven-metadata.xml"
                                                                )
                                                                .Result;

#if MSTEST
            Assert.IsNotNull(module_01);
            Assert.IsFalse(string.IsNullOrEmpty(module_01));
#elif NUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
#elif XUNIT
            Assert.NotNull(module_01);
            Assert.False(string.IsNullOrEmpty(module_01));
#endif


            string module_02 = Artifact.Utilities.DownloadThenSaveMetadataAsync
                                                                (
                                                                    "com.google.guava",
                                                                    "guava",
                                                                    "../../../../../../../../output/com.google.guava:guava:30.1-android-maven-metadata.xml"
                                                                )
                                                                .Result;

#if MSTEST
            Assert.IsNotNull(module_02);
            Assert.IsFalse(string.IsNullOrEmpty(module_02));
#elif NUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
#elif XUNIT
            Assert.NotNull(module_02);
            Assert.False(string.IsNullOrEmpty(module_02));
#endif

            return;
        }

        #endregion      Download com_google_guava_guava
        //-----------------------------------------------------------------------------------------------------------


        [Test]
        public void Test_Artifact_MavenCentralSonatype_member_API_01_ParseArtifactIdFullyQualified()
        {
            Artifact a01 = new Artifact("androidx.car", "car", "1.0.0-alpha1");

            Artifact a02 = new Artifact("androidx.car", "car", "1.0.0");

            return;
        }

        [Test]
        public void Test_Artifact_MavenCentralSonatype_member_API_02_ParseArtifactIdFullyQualfied()
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
        public void Test_Artifact_MavenCentralSonatype_member_API_03_DeserializeProjectObjectModelPOM()
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
        public void Test_Artifact_MavenCentralSonatype_member_API_03_DependencyTree()
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
