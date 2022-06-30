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
using System.Collections.Generic;

using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using HolisticWare.Xamarin.Tools.ComponentGovernance;
using Newtonsoft.Json;

namespace UnitTests.ComponentGovernance
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class ComponentGovernanceManifest_cgmanifest_json
    {
        static List<(string, string, string, string)> mappings_artifact_nuget_01;
        static List<(string, string, string, string)> mappings_artifact_nuget_02;

        static ComponentGovernanceManifest_cgmanifest_json()
        {
            mappings_artifact_nuget_01 = Data.AX.mappings_artifact_nuget;
            mappings_artifact_nuget_02 = Data.GPS_FB_MLKit.mappings_artifact_nuget;
            
            /*
            Manifest.Defaults.VersionBasedOnFullyQualifiedArtifactIdDelegate = delegate(string s)
            {
                if 
                (
                    s.StartsWith("androidx.")
                    ||
                    s.StartsWith("com.google.android.material")
                    ||
                    s.StartsWith("com.google.firebase")
                )
                {
                    return "The Apache Software License, Version 2.0";
                }
                
                if 
                (
                    s.StartsWith("com.google.android.gms")
                    ||
                    s.StartsWith("com.google.android.odml")
                    ||
                    s.StartsWith("com.google.android.ump")
                )
                {
                    return "Android Software Development Kit License";
                }
                
                if 
                (
                    s.StartsWith("org.chromium.net")
                )
                {
                    return "Chromium and built-in dependencies";
                }
                
                if 
                (
                    s.StartsWith("com.google.mlkit")
                )
                {
                    return "ML Kit Terms of Service";
                }
                
                if 
                (
                    s.StartsWith("com.google.android.play")
                )
                {
                    return "Play Core Software Development Kit Terms of Service";
                }
                
                return null;    
            };
            */
            
            return;
        }

        [Test]
        public void Serialize_01()
        {
            Manifest manifest = new Manifest();

            manifest.MappingMavenArtifact2NuGetPackage = mappings_artifact_nuget_01;

            Console.WriteLine($"Saving ComponetGovernanceManifest cgmanifest.json...");
            manifest.Save("./cgmanifest.01.json");
            System.IO.File.WriteAllText
                                (
                                    "Licenses.01.json",
                                    Newtonsoft.Json.JsonConvert.SerializeObject
                                                                            ( 
                                                                                Manifest.Defaults.Licenses,
                                                                                Formatting.Indented
                                                                            )
                                );
                
            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif

            //foreach (IPackageSearchMetadata pm in search)
            //{
            //    Console.WriteLine($"----------------------------------------------------------");
            //    Console.WriteLine($"Title   : {pm.Title}");
            //    Console.WriteLine($"Summary         : {pm.Summary}");
            //    Console.WriteLine($"Tags            : {pm.Tags}");
            //}

            return;
        }

        [Test]
        public void Serialize_02()
        {
            Manifest manifest = new Manifest();

            manifest.MappingMavenArtifact2NuGetPackage = mappings_artifact_nuget_02;

            Console.WriteLine($"Saving ComponetGovernanceManifest cgmanifest.json...");
            manifest.Save("./cgmanifest.02.json");
            System.IO.File.WriteAllText
                                (
                                    "Licenses.02.json",
                                    Newtonsoft.Json.JsonConvert.SerializeObject
                                                                            ( 
                                                                                Manifest.Defaults.Licenses,
                                                                                Formatting.Indented
                                                                            )
                                                                        );

            //#if MSTEST
            //Assert.IsNotNull(search);
            //#elif NUNIT
            //Assert.NotNull(search);
            //#elif XUNIT
            //Assert.NotNull(search);
            //#endif

            //foreach (IPackageSearchMetadata pm in search)
            //{
            //    Console.WriteLine($"----------------------------------------------------------");
            //    Console.WriteLine($"Title   : {pm.Title}");
            //    Console.WriteLine($"Summary         : {pm.Summary}");
            //    Console.WriteLine($"Tags            : {pm.Tags}");
            //}

            return;
        }
    }
}
