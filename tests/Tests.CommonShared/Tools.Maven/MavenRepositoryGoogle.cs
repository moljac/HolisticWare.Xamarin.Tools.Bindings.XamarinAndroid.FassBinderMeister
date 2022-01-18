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

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven;

namespace UnitTests.Tools.Maven
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_MavenRepositoryGoogle
    {
        // MavenNet is missing some API
        // https://github.com/Redth/MavenNet/
        // MavenClient is simple client for Google Maven Repo

        [Test]
        public void GetUrlForGroupId_androidx_car()
        {
            string url = MavenRepositoryGoogle.GetUrlForGroupId("androidx.car");

            string url_correct = "https://dl.google.com/android/maven2/androidx/car/group-index.xml";
            #if MSTEST
            Assert.IsNotNull(url);
            Assert.AreEqual(url, url_correct);
            #elif NUNIT
            Assert.NotNull(url);
            Assert.AreEqual(url, url_correct);
            #elif XUNIT
            Assert.NotNull(url);
            Assert.Equal(url_correct, url);
            #endif

            return;
        }

        [Test]
        public void GetUrlForGroupId_androidx_security()
        {
            string url = MavenRepositoryGoogle.GetUrlForGroupId("androidx.security");

            #if MSTEST
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/androidx/security/group-index.xml");
            #elif NUNIT
            Assert.NotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/androidx/security/group-index.xml");
            #elif XUNIT
            Assert.NotNull(url);
            Assert.Equal("https://dl.google.com/android/maven2/androidx/security/group-index.xml", url);
            #endif

            return;
        }

        [Test]
        public void GetUrlForGroupId_com_google_android_gms()
        {
            string url = MavenRepositoryGoogle.GetUrlForGroupId("com.google.android.gms");

            #if MSTEST
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/com/google/android/gms/group-index.xml");
            #elif NUNIT
            Assert.NotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/com/google/android/gms/group-index.xml");
            #elif XUNIT
            Assert.NotNull(url);
            Assert.Equal("https://dl.google.com/android/maven2/com/google/android/gms/group-index.xml", url);
            #endif

            return;
        }


        [Test]
        public void GetUrlForGroupId_com_firebase()
        {
            string url = MavenRepositoryGoogle.GetUrlForGroupId("com.google.firebase");

            #if MSTEST
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/com/google/firebase/group-index.xml");
            #elif NUNIT
            Assert.NotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/com/google/firebase/group-index.xml");
            #elif XUNIT
            Assert.NotNull(url);
            Assert.Equal("https://dl.google.com/android/maven2/com/google/firebase/group-index.xml", url);
            #endif

            return;
        }


        [Test]
        public void GetUrlForGroupId_com_google_android_material()
        {
            string url = MavenRepositoryGoogle.GetUrlForGroupId("com.google.android.material");

            #if MSTEST
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/com/google/android/material/group-index.xml");
            #elif NUNIT
            Assert.NotNull(url);
            Assert.AreEqual(url, "https://dl.google.com/android/maven2/com/google/android/material/group-index.xml");
            #elif XUNIT
            Assert.NotNull(url);
            Assert.Equal("https://dl.google.com/android/maven2/com/google/android/material/group-index.xml", url);
            #endif

            return;
        }

    }
}
