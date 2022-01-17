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

using System.Linq;
using System.Collections.Generic;

using HolisticWare.Xamarin.Tools.GitHub;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister;

namespace UnitTests.Core.Net.HTTP.IO
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_FileSystem
    {
        [Test]
        public void Test_FileSystem_Maven_Repository_MavenCentralSonatype_MavenCentral()
        {
            string url = "https://repo1.maven.org/maven2/";

            global::Core.Net.HTTP.IO.FileSystem fs = new global::Core.Net.HTTP.IO.FileSystem(url);

            List<global::Core.Net.HTTP.IO.FileSystemItem> fs_tree = null;

            fs_tree = fs.BuildAsync().Result;

            return;
        }

        [Test]
        public void Test_FileSystem_Maven_Repository_MavenCentralSonatype_Sonatype()
        {
            string url = "https://oss.sonatype.org/content/repositories/releases/";

            global::Core.Net.HTTP.IO.FileSystem fs = new global::Core.Net.HTTP.IO.FileSystem(url);

            List<global::Core.Net.HTTP.IO.FileSystemItem> fs_tree = null;

            fs_tree = fs.BuildAsync().Result;

            return;
        }

        [Test]
        public void Test_FileSystem_Maven_Repository_Atlassian()
        {
            string url = "https://packages.atlassian.com/mvn/maven-atlassian-external/";

            global::Core.Net.HTTP.IO.FileSystem fs = new global::Core.Net.HTTP.IO.FileSystem(url);

            List<global::Core.Net.HTTP.IO.FileSystemItem> fs_tree = null;

            fs_tree = fs.BuildAsync().Result;

            return;
        }

        [Test]
        public void Test_FileSystem_Maven_Repository_Nuxeo()
        {
            string url = "https://maven-eu.nuxeo.org/nexus/content/repositories/public-releases/";

            global::Core.Net.HTTP.IO.FileSystem fs = new global::Core.Net.HTTP.IO.FileSystem(url);
            fs.DirectoryNamesIgnored = new List<string>
                                                {
                                                    "2wayfilter/",
                                                    "CCPEngine/",
                                                    "CRS_AGENT_API/",
                                                    "Entity/",
                                                    "GIS/",
                                                    "ObjectFX/",
                                                    "PeterService/",
                                                    "SM/",
                                                    "Simulator/",
                                                    "TubeSimulator/",
                                                    "WMS_API/",
                                                    "XML/",
                                                    "maven-enforcer-plugin/",
                                                };
            List<global::Core.Net.HTTP.IO.FileSystemItem> fs_tree = null;

            // Create and add a new default trace listener.
            // System.Diagnostics.DefaultTraceListener defaultListener;
            // defaultListener = new System.Diagnostics.DefaultTraceListener();
            // System.Diagnostics.Trace.Listeners.Add(defaultListener);
            string p = "../../../../../../../../output";
            System.Diagnostics.Trace.Listeners.Clear();
            System.Diagnostics.Trace.Listeners.Add
                                                (
                                                    new System.Diagnostics.TextWriterTraceListener
                                                            (
                                                                $"{p}/FileSystem_Maven_Repository_Nuxeo.log",
                                                                "Maven.Repository.Listener"
                                                            )
                                                );
            System.Diagnostics.Trace.Listeners.Add
                                                (
                                                    new System.Diagnostics.DefaultTraceListener()
                                                );

            fs_tree = fs.BuildAsync().Result;

            return;
        }
    }
}
