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

using System.Collections.Generic;

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx;

namespace UnitTests.FassBinderMeister.BindEx
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_Artifact
    {
        [Test]
        public void Ctor_01()
        {
            Artifact a = new Artifact("androidx.car", "car");

            a.SaveAsync().Wait();

            #if MSTEST
            Assert.IsNotNull(a);
            #elif NUNIT
            Assert.NotNull(a);
            #elif XUNIT
            Assert.NotNull(a);
            #endif

            return;
        }

        [Test]
        public void Ctor_02()
        {
            Artifact a = new Artifact("androidx.car.car");

            a.SaveAsync().Wait();

            #if MSTEST
            Assert.IsNotNull(a);
            #elif NUNIT
            Assert.NotNull(a);
            #elif XUNIT
            Assert.NotNull(a);
            #endif

            return;
        }

        [Test]
        public void Parse_androidx_car_car_01()
        {
            (string id_group, string id_artifact, string version) result;
            result = Artifact.Parse("androidx.car.car");

            #if MSTEST
            Assert.AreEqual(result.id_group, "androidx.car");
            Assert.AreEqual(result.id_artifact, "car");
            Assert.AreEqual(result.version, null);
            #elif NUNIT
            Assert.AreEqual(result.id_group, "androidx.car");
            Assert.AreEqual(result.id_artifact, "car");
            Assert.AreEqual(result.version, null);
            #elif XUNIT
            Assert.Equal(result.id_group, "androidx.car");
            Assert.Equal(result.id_artifact, "car");
            Assert.Equal(result.version, null);
            #endif

            return;
        }

        [Test]
        public void Parse_androidx_car_car_02()
        {
            (string id_group, string id_artifact, string version) result;
            result = Artifact.Parse("androidx.car:car");

            #if MSTEST
            Assert.AreEqual(result.id_group, "androidx.car");
            Assert.AreEqual(result.id_artifact, "car");
            Assert.AreEqual(result.version, null);
            #elif NUNIT
            Assert.AreEqual(result.id_group, "androidx.car");
            Assert.AreEqual(result.id_artifact, "car");
            Assert.AreEqual(result.version, null);
            #elif XUNIT
            Assert.Equal(result.id_group, "androidx.car");
            Assert.Equal(result.id_artifact, "car");
            Assert.Equal(result.version, null);
            #endif

            return;
        }

        [Test]
        public void Parse_org_tensorflow_tensorflow_lite_01()
        {
            (string id_group, string id_artifact, string version) result;
            result = Artifact.Parse("org.tensorflow.tensorflow-lite");

            #if MSTEST
            Assert.AreEqual(result.id_group, "org.tensorflow");
            Assert.AreEqual(result.id_artifact, "tensorflow-lite");
            Assert.AreEqual(result.version, null);
            #elif NUNIT
            Assert.AreEqual(result.id_group, "org.tensorflow");
            Assert.AreEqual(result.id_artifact, "tensorflow-lite");
            Assert.AreEqual(result.version, null);
            #elif XUNIT
            Assert.Equal(result.id_group, "org.tensorflow");
            Assert.Equal(result.id_artifact, "tensorflow-lite");
            Assert.Equal(result.version, null);
            #endif

            return;
        }
        
        [Test]
        public void Parse_org_tensorflow_tensorflow_lite_02()
        {
            (string id_group, string id_artifact, string version) result;
            result = Artifact.Parse("org.tensorflow:tensorflow-lite");

            #if MSTEST
            Assert.AreEqual(result.id_group, "org.tensorflow");
            Assert.AreEqual(result.id_artifact, "tensorflow-lite");
            Assert.AreEqual(result.version, null);
            #elif NUNIT
            Assert.AreEqual(result.id_group, "org.tensorflow");
            Assert.AreEqual(result.id_artifact, "tensorflow-lite");
            Assert.AreEqual(result.version, null);
            #elif XUNIT
            Assert.Equal(result.id_group, "org.tensorflow");
            Assert.Equal(result.id_artifact, "tensorflow-lite");
            Assert.Equal(result.version, null);
            #endif

            return;
        }

        [Test]
        public void Parse_com_example_android_app_magic_12_3_01()
        {
            (string id_group, string id_artifact, string version) result;

            // https://developer.android.com/studio/build/dependencies
            result = Artifact.Parse("com.example.android:app-magic:12.3");

            #if MSTEST
            Assert.AreEqual(result.id_group, "com.example.android");
            Assert.AreEqual(result.id_artifact, "app-magic");
            Assert.AreEqual(result.version, "12.3");
            #elif NUNIT
            Assert.Equals(result.id_group, "com.example.android");
            Assert.Equals(result.id_artifact, "app-magic");
            Assert.Equals(result.version, "12.3");
            #elif XUNIT
            Assert.Equal(result.id_group, "com.example.android");
            Assert.Equal(result.id_artifact, "app-magic");
            Assert.Equal(result.version, "12.3");
            #endif

            return;
        }

        [Test]
        public void DetectMavenRepository_01a()
        {
            var result = Artifact.DetectMavenRepository("androidx.car:car");


            //#if MSTEST
            //Assert.AreEqual(result.id_group, "com.example.android");
            //Assert.AreEqual(result.id_artifact, "app-magic");
            //Assert.AreEqual(result.version, "12.3");
            //#elif NUNIT
            //Assert.Equals(result.id_group, "com.example.android");
            //Assert.Equals(result.id_artifact, "app-magic");
            //Assert.Equals(result.version, "12.3");
            //#elif XUNIT
            //Assert.Equal(result.id_group, "com.example.android");
            //Assert.Equal(result.id_artifact, "app-magic");
            //Assert.Equal(result.version, "12.3");
            //#endif

            return;
        }

        [Test]
        public void DetectMavenRepository_02a()
        {
            var result = Artifact.DetectMavenRepository("org.tensorflow:tensorflow-lite:2.4.0");


            //#if MSTEST
            //Assert.AreEqual(result.id_group, "com.example.android");
            //Assert.AreEqual(result.id_artifact, "app-magic");
            //Assert.AreEqual(result.version, "12.3");
            //#elif NUNIT
            //Assert.Equals(result.id_group, "com.example.android");
            //Assert.Equals(result.id_artifact, "app-magic");
            //Assert.Equals(result.version, "12.3");
            //#elif XUNIT
            //Assert.Equal(result.id_group, "com.example.android");
            //Assert.Equal(result.id_artifact, "app-magic");
            //Assert.Equal(result.version, "12.3");
            //#endif

            return;
        }

        [Test]
        public void DetectMavenRepository_03()
        {
            var result = Artifact.DetectMavenRepository("com.example.android:app-magic:12.3");


            //#if MSTEST
            //Assert.AreEqual(result.id_group, "com.example.android");
            //Assert.AreEqual(result.id_artifact, "app-magic");
            //Assert.AreEqual(result.version, "12.3");
            //#elif NUNIT
            //Assert.Equals(result.id_group, "com.example.android");
            //Assert.Equals(result.id_artifact, "app-magic");
            //Assert.Equals(result.version, "12.3");
            //#elif XUNIT
            //Assert.Equal(result.id_group, "com.example.android");
            //Assert.Equal(result.id_artifact, "app-magic");
            //Assert.Equal(result.version, "12.3");
            //#endif

            return;
        }


        [Test]
        public void DownloadArtifactMetadata()
        {
            Artifact a = new Artifact
            {
                GroupId = "androidx.car",
                ArtifactId = "car",
                VersionTextual = "1.0.0-alpha7"
            };

            string content = a.DownloadArtifactMetadata().Result;

            a.SaveAsync().Wait();

            #if MSTEST
            Assert.IsNotNull(a);
            Assert.IsNotNull(content);
            Assert.IsFalse(content.Contains("404 (Not Found)."));
            #elif NUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
            Assert.IsFalse(content.Contains("404 (Not Found)."));
            #elif XUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
            Assert.False(content.Contains("404 (Not Found)."));
            #endif

            return;
        }

        [Test]
        public void DownloadProjectObjectModelPOM()
        {
            Artifact a = new Artifact
            {
                GroupId = "androidx.car",
                ArtifactId = "car",
                VersionTextual = "1.0.0-alpha7"
            };

            string content = a.DownloadProjectObjectModelPOM().Result;

            a.SaveAsync().Wait();

            #if MSTEST
            Assert.IsNotNull(a);
            Assert.IsNotNull(content);
            #elif NUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
            #elif XUNIT
            Assert.NotNull(a);
            Assert.NotNull(content);
            #endif

            return;
        }

    }
}
