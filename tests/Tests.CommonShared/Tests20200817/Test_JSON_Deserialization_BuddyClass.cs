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

namespace UnitTests.JSON
{
    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed
    public partial class Test_JSON_Deserialization_BuddyClass
    {
        [Test]
        public void Test_JSON_Deserialization_Tag()
        {
            string json = $@"
{{
    ""name""        : ""20201105 - stable - releases"",
    ""zipball_url"" : ""https://api.github.com/repos/xamarin/AndroidX/zipball/20201105-stable-releases"",
    ""tarball_url"" : ""https://api.github.com/repos/xamarin/AndroidX/tarball/20201105-stable-releases"",
    ""commit""      :
        {{
           ""sha""  : ""6d248c6318e9ea34c8d1e81cbe0acf212e40f934"",
            ""url"" : ""https://api.github.com/repos/xamarin/AndroidX/commits/6d248c6318e9ea34c8d1e81cbe0acf212e40f934""
        }},
    ""node_id""     : ""MDM6UmVmMjIyNTA4NzgxOnJlZnMvdGFncy8yMDIwMTEwNS1zdGFibGUtcmVsZWFzZXM = ""
  }}
";
            Tag t = Tag.Deserialize(json);

            #if MSTEST
            Assert.AreEqual(t.Name, "20201105 - stable - releases");
            #elif NUNIT
            Assert.AreEqual(t.Name, "20201105 - stable - releases");
            #elif XUNIT
            Assert.Equal(t.Name, "20201105 - stable - releases");
            #endif

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// https://api.github.com/repos/xamarin/AndroidX/tags
        [Test]
        public void Test_JSON_Deserialization_Tags_IEnumerable_of_Tag_01()
        {
            string json = $@"
[
    {{
        ""name""        : ""20201105 - stable - releases"",
        ""zipball_url"" : ""https://api.github.com/repos/xamarin/AndroidX/zipball/20201105-stable-releases"",
        ""tarball_url"" : ""https://api.github.com/repos/xamarin/AndroidX/tarball/20201105-stable-releases"",
        ""commit""      :
            {{
               ""sha""  : ""6d248c6318e9ea34c8d1e81cbe0acf212e40f934"",
                ""url"" : ""https://api.github.com/repos/xamarin/AndroidX/commits/6d248c6318e9ea34c8d1e81cbe0acf212e40f934""
            }},
        ""node_id""     : ""MDM6UmVmMjIyNTA4NzgxOnJlZnMvdGFncy8yMDIwMTEwNS1zdGFibGUtcmVsZWFzZXM = ""
      }},
      {{
        ""name""        : ""20201104 - stable - releases"",
        ""zipball_url"" : ""https://api.github.com/repos/xamarin/AndroidX/zipball/20201104-stable-releases"",
        ""tarball_url"" : ""https://api.github.com/repos/xamarin/AndroidX/tarball/20201104-stable-releases"",
        ""commit""      :
            {{
                ""sha"" : ""18c59379833b131a79e222e38e135b86a7567a3b"",
                ""url"" : ""https://api.github.com/repos/xamarin/AndroidX/commits/18c59379833b131a79e222e38e135b86a7567a3b""
            }},
        ""node_id"" : ""MDM6UmVmMjIyNTA4NzgxOnJlZnMvdGFncy8yMDIwMTEwNC1zdGFibGUtcmVsZWFzZXM=""
  }},
]
";
            IEnumerable<Tag> tags = Tags.Deserialize(json);

            #if MSTEST
            Assert.AreEqual(tags.Count(), 2);
            #elif NUNIT
            Assert.AreEqual(tags.Count(), 2);
            #elif XUNIT
            Assert.Equal(tags.Count(), 2);
            #endif

            return;
        }

        /// https://api.github.com/repos/xamarin/AndroidX/tags
        [Test]
        public void Test_JSON_Deserialization_Tags_IEnumerable_of_Tag_02_AndroidX()
        {
            string url = "https://api.github.com/repos/xamarin/AndroidX/tags";
            Tests.CommonShared.Http.Client.DefaultRequestHeaders
                                                .Add
                                                    (
                                                        "User-Agent",
                                                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                                                    );

            string response_json = Tests.CommonShared.Http.Client.GetStringAsync(url).Result;

            IEnumerable<Tag> tags = Tags.Deserialize(response_json);

            DataBinderatorAndroidX.TagsAsJSON = response_json;
            DataBinderatorAndroidX.Tags = tags;

            return;
        }

        /// https://api.github.com/repos/xamarin/GooglePlayServicesComponents/tags
        [Test]
        public void Test_JSON_Deserialization_Tags_IEnumerable_of_Tag_02_GPS_FB()
        {
            string url = "https://api.github.com/repos/xamarin/GooglePlayServicesComponents/tags";
            Tests.CommonShared.Http.Client.DefaultRequestHeaders
                                                .Add
                                                    (
                                                        "User-Agent",
                                                        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                                                    );

            string response_json = Tests.CommonShared.Http.Client.GetStringAsync(url).Result;

            IEnumerable<Tag> tags = Tags.Deserialize(response_json);

            DataBinderatorGooglePlayServicesAndFirebase.TagsAsJSON = response_json;
            DataBinderatorGooglePlayServicesAndFirebase.Tags = tags;

            return;
        }
    }
}
