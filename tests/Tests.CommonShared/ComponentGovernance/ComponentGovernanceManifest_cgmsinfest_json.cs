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
            mappings_artifact_nuget_01 = new List<(string, string, string, string)>
            {
                ("androidx.activity:activity", "1.4.0", "Xamarin.AndroidX.Activity", "1.4.0.4"),
                ("androidx.activity:activity-ktx", "1.4.0", "Xamarin.AndroidX.Activity.Ktx", "1.4.0.3"),
                ("androidx.ads:ads-identifier", "1.0.0-alpha04", "Xamarin.AndroidX.Ads.Identifier", "1.0.0.12-alpha04"),
                ("androidx.ads:ads-identifier-common", "1.0.0-alpha04", "Xamarin.AndroidX.Ads.IdentifierCommon", "1.0.0.12-alpha04"),
                ("androidx.ads:ads-identifier-provider", "1.0.0-alpha04", "Xamarin.AndroidX.Ads.IdentifierProvider", "1.0.0.12-alpha04"),
                ("androidx.annotation:annotation", "1.3.0", "Xamarin.AndroidX.Annotation", "1.3.0.4"),
                ("androidx.annotation:annotation-experimental", "1.2.0", "Xamarin.AndroidX.Annotation.Experimental", "1.2.0.2"),
                ("androidx.appcompat:appcompat", "1.4.2", "Xamarin.AndroidX.AppCompat", "1.4.2.1"),
                ("androidx.appcompat:appcompat-resources", "1.4.2", "Xamarin.AndroidX.AppCompat.AppCompatResources", "1.4.2.1"),
                ("androidx.arch.core:core-common", "2.1.0", "Xamarin.AndroidX.Arch.Core.Common", "2.1.0.15"),
                ("androidx.arch.core:core-runtime", "2.1.0", "Xamarin.AndroidX.Arch.Core.Runtime", "2.1.0.15"),
                ("androidx.asynclayoutinflater:asynclayoutinflater", "1.0.0", "Xamarin.AndroidX.AsyncLayoutInflater", "1.0.0.14"),
                ("androidx.autofill:autofill", "1.1.0", "Xamarin.AndroidX.AutoFill", "1.1.0.13"),
                ("androidx.biometric:biometric", "1.1.0", "Xamarin.AndroidX.Biometric", "1.1.0.10"),
                ("androidx.browser:browser", "1.4.0", "Xamarin.AndroidX.Browser", "1.4.0.2"),
                ("androidx.camera:camera-camera2", "1.0.2", "Xamarin.AndroidX.Camera.Camera2", "1.0.2.5"),
                ("androidx.camera:camera-core", "1.0.2", "Xamarin.AndroidX.Camera.Core", "1.0.2.5"),
                ("androidx.camera:camera-lifecycle", "1.0.2", "Xamarin.AndroidX.Camera.Lifecycle", "1.0.2.5"),
                ("androidx.car:car", "1.0.0-alpha7", "Xamarin.AndroidX.Car.Car", "1.0.0.12-alpha7"),
                ("androidx.car:car-cluster", "1.0.0-alpha5", "Xamarin.AndroidX.Car.Cluster", "1.0.0.12-alpha5"),
                ("androidx.car.app:app", "1.1.0", "Xamarin.AndroidX.Car.App.App", "1.1.0.3"),
                ("androidx.cardview:cardview", "1.0.0", "Xamarin.AndroidX.CardView", "1.0.0.16"),
                ("androidx.collection:collection", "1.2.0", "Xamarin.AndroidX.Collection", "1.2.0.4"),
                ("androidx.collection:collection-ktx", "1.2.0", "Xamarin.AndroidX.Collection.Ktx", "1.2.0.4"),
                ("androidx.compose.animation:animation", "1.1.1", "Xamarin.AndroidX.Compose.Animation", "1.1.1.2"),
                ("androidx.compose.animation:animation-core", "1.1.1", "Xamarin.AndroidX.Compose.Animation.Core", "1.1.1.2"),
                ("androidx.compose.foundation:foundation", "1.1.1", "Xamarin.AndroidX.Compose.Foundation", "1.1.1.2"),
                ("androidx.compose.foundation:foundation-layout", "1.1.1", "Xamarin.AndroidX.Compose.Foundation.Layout", "1.1.1.2"),
                ("androidx.compose.material:material", "1.1.1", "Xamarin.AndroidX.Compose.Material", "1.1.1.2"),
                ("androidx.compose.material:material-icons-core", "1.1.1", "Xamarin.AndroidX.Compose.Material.Icons.Core", "1.1.1.2"),
                ("androidx.compose.material:material-icons-extended", "1.1.1", "Xamarin.AndroidX.Compose.Material.Icons.Extended", "1.1.1.2"),
                ("androidx.compose.material:material-ripple", "1.1.1", "Xamarin.AndroidX.Compose.Material.Ripple", "1.1.1.2"),
                ("androidx.compose.runtime:runtime", "1.1.1", "Xamarin.AndroidX.Compose.Runtime", "1.1.1.2"),
                ("androidx.compose.runtime:runtime-livedata", "1.1.1", "Xamarin.AndroidX.Compose.Runtime.LiveData", "1.1.1.2"),
                ("androidx.compose.runtime:runtime-rxjava2", "1.1.1", "Xamarin.AndroidX.Compose.Runtime.RxJava2", "1.1.1.2"),
                ("androidx.compose.runtime:runtime-saveable", "1.1.1", "Xamarin.AndroidX.Compose.Runtime.Saveable", "1.1.1.2"),
                ("androidx.compose.ui:ui", "1.1.1", "Xamarin.AndroidX.Compose.UI", "1.1.1.2"),
                ("androidx.compose.ui:ui-geometry", "1.1.1", "Xamarin.AndroidX.Compose.UI.Geometry", "1.1.1.2"),
                ("androidx.compose.ui:ui-graphics", "1.1.1", "Xamarin.AndroidX.Compose.UI.Graphics", "1.1.1.2"),
                ("androidx.compose.ui:ui-text", "1.1.1", "Xamarin.AndroidX.Compose.UI.Text", "1.1.1.2"),
                ("androidx.compose.ui:ui-unit", "1.1.1", "Xamarin.AndroidX.Compose.UI.Unit", "1.1.1.2"),
                ("androidx.compose.ui:ui-util", "1.1.1", "Xamarin.AndroidX.Compose.UI.Util", "1.1.1.2"),
                ("androidx.compose.ui:ui-viewbinding", "1.1.1", "Xamarin.AndroidX.Compose.UI.ViewBinding", "1.1.1.2"),
                ("androidx.concurrent:concurrent-futures", "1.1.0", "Xamarin.AndroidX.Concurrent.Futures", "1.1.0.9"),
                ("androidx.constraintlayout:constraintlayout", "2.1.4", "Xamarin.AndroidX.ConstraintLayout", "2.1.4.1"),
                ("androidx.constraintlayout:constraintlayout-core", "1.0.4", "Xamarin.AndroidX.ConstraintLayout.Core", "1.0.4.1"),
                ("androidx.constraintlayout:constraintlayout-solver", "2.0.4", "Xamarin.AndroidX.ConstraintLayout.Solver", "2.0.4.9"),
                ("androidx.contentpager:contentpager", "1.0.0", "Xamarin.AndroidX.ContentPager", "1.0.0.14"),
                ("androidx.coordinatorlayout:coordinatorlayout", "1.2.0", "Xamarin.AndroidX.CoordinatorLayout", "1.2.0.2"),
                ("androidx.core:core", "1.8.0", "Xamarin.AndroidX.Core", "1.8.0.1"),
                ("androidx.core:core-animation", "1.0.0-alpha02", "Xamarin.AndroidX.Core.Animation", "1.0.0.12-alpha02"),
                ("androidx.core:core-google-shortcuts", "1.0.1", "Xamarin.AndroidX.Core.GoogleShortcuts", "1.0.1.1"),
                ("androidx.core:core-ktx", "1.8.0", "Xamarin.AndroidX.Core.Core.Ktx", "1.8.0.1"),
                ("androidx.core:core-role", "1.0.0", "Xamarin.AndroidX.Core.Role", "1.0.0.12"),
                ("androidx.core:core-splashscreen", "1.0.0-rc01", "Xamarin.AndroidX.Core.SplashScreen", "1.0.0.1-rc01"),
                ("androidx.cursoradapter:cursoradapter", "1.0.0", "Xamarin.AndroidX.CursorAdapter", "1.0.0.14"),
                ("androidx.customview:customview", "1.1.0", "Xamarin.AndroidX.CustomView", "1.1.0.13"),
                ("androidx.databinding:databinding-adapters", "7.2.1", "Xamarin.AndroidX.DataBinding.DataBindingAdapters", "7.2.1.1"),
                ("androidx.databinding:databinding-common", "7.2.1", "Xamarin.AndroidX.DataBinding.DataBindingCommon", "7.2.1.1"),
                ("androidx.databinding:databinding-runtime", "7.2.1", "Xamarin.AndroidX.DataBinding.DataBindingRuntime", "7.2.1.1"),
                ("androidx.databinding:viewbinding", "7.2.1", "Xamarin.AndroidX.DataBinding.ViewBinding", "7.2.1.1"),
                ("androidx.documentfile:documentfile", "1.0.1", "Xamarin.AndroidX.DocumentFile", "1.0.1.14"),
                ("androidx.drawerlayout:drawerlayout", "1.1.1", "Xamarin.AndroidX.DrawerLayout", "1.1.1.9"),
                ("androidx.dynamicanimation:dynamicanimation", "1.0.0", "Xamarin.AndroidX.DynamicAnimation", "1.0.0.14"),
                ("androidx.emoji:emoji", "1.1.0", "Xamarin.AndroidX.Emoji", "1.1.0.9"),
                ("androidx.emoji:emoji-appcompat", "1.1.0", "Xamarin.AndroidX.Emoji.AppCompat", "1.1.0.9"),
                ("androidx.emoji:emoji-bundled", "1.1.0", "Xamarin.AndroidX.Emoji.Bundled", "1.1.0.9"),
                ("androidx.emoji2:emoji2", "1.1.0", "Xamarin.AndroidX.Emoji2", "1.1.0.2"),
                ("androidx.emoji2:emoji2-views-helper", "1.1.0", "Xamarin.AndroidX.Emoji2.ViewsHelper", "1.1.0.2"),
                ("androidx.exifinterface:exifinterface", "1.3.3", "Xamarin.AndroidX.ExifInterface", "1.3.3.6"),
                ("androidx.fragment:fragment", "1.4.1", "Xamarin.AndroidX.Fragment", "1.4.1.2"),
                ("androidx.fragment:fragment-ktx", "1.4.1", "Xamarin.AndroidX.Fragment.Ktx", "1.4.1.2"),
                ("androidx.gridlayout:gridlayout", "1.0.0", "Xamarin.AndroidX.GridLayout", "1.0.0.14"),
                ("androidx.heifwriter:heifwriter", "1.0.0", "Xamarin.AndroidX.HeifWriter", "1.0.0.14"),
                ("androidx.interpolator:interpolator", "1.0.0", "Xamarin.AndroidX.Interpolator", "1.0.0.14"),
                ("androidx.leanback:leanback", "1.0.0", "Xamarin.AndroidX.Leanback", "1.0.0.16"),
                ("androidx.leanback:leanback-preference", "1.0.0", "Xamarin.AndroidX.Leanback.Preference", "1.0.0.14"),
                ("androidx.legacy:legacy-preference-v14", "1.0.0", "Xamarin.AndroidX.Legacy.Preference.V14", "1.0.0.14"),
                ("androidx.legacy:legacy-support-core-ui", "1.0.0", "Xamarin.AndroidX.Legacy.Support.Core.UI", "1.0.0.15"),
                ("androidx.legacy:legacy-support-core-utils", "1.0.0", "Xamarin.AndroidX.Legacy.Support.Core.Utils", "1.0.0.14"),
                ("androidx.legacy:legacy-support-v13", "1.0.0", "Xamarin.AndroidX.Legacy.Support.V13", "1.0.0.14"),
                ("androidx.legacy:legacy-support-v4", "1.0.0", "Xamarin.AndroidX.Legacy.Support.V4", "1.0.0.14"),
                ("androidx.lifecycle:lifecycle-common", "2.4.1", "Xamarin.AndroidX.Lifecycle.Common", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-common-java8", "2.4.1", "Xamarin.AndroidX.Lifecycle.Common.Java8", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-extensions", "2.2.0", "Xamarin.AndroidX.Lifecycle.Extensions", "2.2.0.14"),
                ("androidx.lifecycle:lifecycle-livedata", "2.4.1", "Xamarin.AndroidX.Lifecycle.LiveData", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-livedata-core", "2.4.1", "Xamarin.AndroidX.Lifecycle.LiveData.Core", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-livedata-core-ktx", "2.4.1", "Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-livedata-ktx", "2.4.1", "Xamarin.AndroidX.Lifecycle.LiveData.Ktx", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-process", "2.4.1", "Xamarin.AndroidX.Lifecycle.Process", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-reactivestreams", "2.4.1", "Xamarin.AndroidX.Lifecycle.ReactiveStreams", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-reactivestreams-ktx", "2.4.1", "Xamarin.AndroidX.Lifecycle.ReactiveStreams.Ktx", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-runtime", "2.4.1", "Xamarin.AndroidX.Lifecycle.Runtime", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-runtime-ktx", "2.4.1", "Xamarin.AndroidX.Lifecycle.Runtime.Ktx", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-service", "2.4.1", "Xamarin.AndroidX.Lifecycle.Service", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-viewmodel", "2.4.1", "Xamarin.AndroidX.Lifecycle.ViewModel", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-viewmodel-ktx", "2.4.1", "Xamarin.AndroidX.Lifecycle.ViewModel.Ktx", "2.4.1.2"),
                ("androidx.lifecycle:lifecycle-viewmodel-savedstate", "2.4.1", "Xamarin.AndroidX.Lifecycle.ViewModelSavedState", "2.4.1.2"),
                ("androidx.loader:loader", "1.1.0", "Xamarin.AndroidX.Loader", "1.1.0.14"),
                ("androidx.localbroadcastmanager:localbroadcastmanager", "1.1.0", "Xamarin.AndroidX.LocalBroadcastManager", "1.1.0.2"),
                ("androidx.media:media", "1.6.0", "Xamarin.AndroidX.Media", "1.6.0.1"),
                ("androidx.media2:media2-common", "1.2.1", "Xamarin.AndroidX.Media2.Common", "1.2.1.2"),
                ("androidx.media2:media2-session", "1.2.1", "Xamarin.AndroidX.Media2.Session", "1.2.1.2"),
                ("androidx.media2:media2-widget", "1.2.1", "Xamarin.AndroidX.Media2.Widget", "1.2.1.2"),
                ("androidx.mediarouter:mediarouter", "1.3.0", "Xamarin.AndroidX.MediaRouter", "1.3.0.1"),
                ("androidx.multidex:multidex", "2.0.1", "Xamarin.AndroidX.MultiDex", "2.0.1.14"),
                ("androidx.navigation:navigation-common", "2.4.2", "Xamarin.AndroidX.Navigation.Common", "2.4.2.1"),
                ("androidx.navigation:navigation-common-ktx", "2.4.2", "Xamarin.AndroidX.Navigation.Common.Ktx", "2.4.2.1"),
                ("androidx.navigation:navigation-fragment", "2.4.2", "Xamarin.AndroidX.Navigation.Fragment", "2.4.2.1"),
                ("androidx.navigation:navigation-fragment-ktx", "2.4.2", "Xamarin.AndroidX.Navigation.Fragment.Ktx", "2.4.2.1"),
                ("androidx.navigation:navigation-runtime", "2.4.2", "Xamarin.AndroidX.Navigation.Runtime", "2.4.2.1"),
                ("androidx.navigation:navigation-runtime-ktx", "2.4.2", "Xamarin.AndroidX.Navigation.Runtime.Ktx", "2.4.2.1"),
                ("androidx.navigation:navigation-ui", "2.4.2", "Xamarin.AndroidX.Navigation.UI", "2.4.2.1"),
                ("androidx.navigation:navigation-ui-ktx", "2.4.2", "Xamarin.AndroidX.Navigation.UI.Ktx", "2.4.2.1"),
                ("androidx.paging:paging-common", "3.1.1", "Xamarin.AndroidX.Paging.Common", "3.1.1.2"),
                ("androidx.paging:paging-common-ktx", "3.1.1", "Xamarin.AndroidX.Paging.Common.Ktx", "3.1.1.2"),
                ("androidx.paging:paging-runtime", "3.1.1", "Xamarin.AndroidX.Paging.Runtime", "3.1.1.2"),
                ("androidx.paging:paging-runtime-ktx", "3.1.1", "Xamarin.AndroidX.Paging.Runtime.Ktx", "3.1.1.2"),
                ("androidx.paging:paging-rxjava2", "3.1.1", "Xamarin.AndroidX.Paging.RxJava2", "3.1.1.2"),
                ("androidx.paging:paging-rxjava2-ktx", "3.1.1", "Xamarin.AndroidX.Paging.RxJava2.Ktx", "3.1.1.2"),
                ("androidx.palette:palette", "1.0.0", "Xamarin.AndroidX.Palette", "1.0.0.14"),
                ("androidx.palette:palette-ktx", "1.0.0", "Xamarin.AndroidX.Palette.Palette.Ktx", "1.0.0.7"),
                ("androidx.percentlayout:percentlayout", "1.0.0", "Xamarin.AndroidX.PercentLayout", "1.0.0.15"),
                ("androidx.preference:preference", "1.2.0", "Xamarin.AndroidX.Preference", "1.2.0.2"),
                ("androidx.preference:preference-ktx", "1.2.0", "Xamarin.AndroidX.Preference.Preference.Ktx", "1.2.0.2"),
                ("androidx.print:print", "1.0.0", "Xamarin.AndroidX.Print", "1.0.0.14"),
                ("androidx.profileinstaller:profileinstaller", "1.1.0", "Xamarin.AndroidX.ProfileInstaller.ProfileInstaller", "1.1.0.2"),
                ("androidx.recommendation:recommendation", "1.0.0", "Xamarin.AndroidX.Recommendation", "1.0.0.14"),
                ("androidx.recyclerview:recyclerview", "1.2.1", "Xamarin.AndroidX.RecyclerView", "1.2.1.7"),
                ("androidx.recyclerview:recyclerview-selection", "1.1.0", "Xamarin.AndroidX.RecyclerView.Selection", "1.1.0.8"),
                ("androidx.resourceinspection:resourceinspection-annotation", "1.0.1", "Xamarin.AndroidX.ResourceInspection.Annotation", "1.0.1.2"),
                ("androidx.room:room-common", "2.4.2", "Xamarin.AndroidX.Room.Common", "2.4.2.2"),
                ("androidx.room:room-guava", "2.4.2", "Xamarin.AndroidX.Room.Guava", "2.4.2.2"),
                ("androidx.room:room-ktx", "2.4.2", "Xamarin.AndroidX.Room.Room.Ktx", "2.4.2.3"),
                ("androidx.room:room-runtime", "2.4.2", "Xamarin.AndroidX.Room.Runtime", "2.4.2.2"),
                ("androidx.room:room-rxjava2", "2.4.2", "Xamarin.AndroidX.Room.Room.RxJava2", "2.4.2.2"),
                ("androidx.room:room-rxjava3", "2.4.2", "Xamarin.AndroidX.Room.Room.RxJava3", "2.4.2.2"),
                ("androidx.savedstate:savedstate", "1.1.0", "Xamarin.AndroidX.SavedState", "1.1.0.8"),
                ("androidx.savedstate:savedstate-ktx", "1.1.0", "Xamarin.AndroidX.SavedState.SavedState.Ktx", "1.1.0.8"),
                ("androidx.security:security-crypto", "1.0.0", "Xamarin.AndroidX.Security.SecurityCrypto", "1.0.0.7"),
                ("androidx.slice:slice-builders", "1.0.0", "Xamarin.AndroidX.Slice.Builders", "1.0.0.14"),
                ("androidx.slice:slice-core", "1.0.0", "Xamarin.AndroidX.Slice.Core", "1.0.0.14"),
                ("androidx.slice:slice-view", "1.0.0", "Xamarin.AndroidX.Slice.View", "1.0.0.14"),
                ("androidx.slidingpanelayout:slidingpanelayout", "1.2.0", "Xamarin.AndroidX.SlidingPaneLayout", "1.2.0.2"),
                ("androidx.sqlite:sqlite", "2.2.0", "Xamarin.AndroidX.Sqlite", "2.2.0.2"),
                ("androidx.sqlite:sqlite-framework", "2.2.0", "Xamarin.AndroidX.Sqlite.Framework", "2.2.0.2"),
                ("androidx.startup:startup-runtime", "1.1.1", "Xamarin.AndroidX.Startup.StartupRuntime", "1.1.1.2"),
                ("androidx.swiperefreshlayout:swiperefreshlayout", "1.1.0", "Xamarin.AndroidX.SwipeRefreshLayout", "1.1.0.9"),
                ("androidx.tracing:tracing", "1.1.0", "Xamarin.AndroidX.Tracing.Tracing", "1.1.0.1"),
                ("androidx.transition:transition", "1.4.1", "Xamarin.AndroidX.Transition", "1.4.1.7"),
                ("androidx.tvprovider:tvprovider", "1.0.0", "Xamarin.AndroidX.TvProvider", "1.0.0.16"),
                ("androidx.vectordrawable:vectordrawable", "1.1.0", "Xamarin.AndroidX.VectorDrawable", "1.1.0.14"),
                ("androidx.vectordrawable:vectordrawable-animated", "1.1.0", "Xamarin.AndroidX.VectorDrawable.Animated", "1.1.0.14"),
                ("androidx.versionedparcelable:versionedparcelable", "1.1.1", "Xamarin.AndroidX.VersionedParcelable", "1.1.1.14"),
                ("androidx.viewpager:viewpager", "1.0.0", "Xamarin.AndroidX.ViewPager", "1.0.0.14"),
                ("androidx.viewpager2:viewpager2", "1.0.0", "Xamarin.AndroidX.ViewPager2", "1.0.0.16"),
                ("androidx.wear:wear", "1.2.0", "Xamarin.AndroidX.Wear", "1.2.0.6"),
                ("androidx.wear:wear-input", "1.1.0", "Xamarin.AndroidX.Wear.Input", "1.0.0.4"),
                ("androidx.wear:wear-ongoing", "1.0.0", "Xamarin.AndroidX.Wear.Ongoing", "1.0.0.4"),
                ("androidx.wear:wear-phone-interactions", "1.0.1", "Xamarin.AndroidX.Wear.PhoneInteractions", "1.0.1.2"),
                ("androidx.wear:wear-remote-interactions", "1.0.0", "Xamarin.AndroidX.Wear.RemoteInteractions", "1.0.0.4"),
                ("androidx.webkit:webkit", "1.4.0", "Xamarin.AndroidX.WebKit", "1.4.0.8"),
                ("androidx.window:window", "1.0.0", "Xamarin.AndroidX.Window", "1.0.0.9"),
                ("androidx.window:window-extensions", "1.0.0-alpha01", "Xamarin.AndroidX.Window.WindowExtensions", "1.0.0.9-alpha01"),
                ("androidx.window:window-java", "1.0.0", "Xamarin.AndroidX.Window.WindowJava", "1.0.0.9"),
                ("androidx.work:work-runtime", "2.7.1", "Xamarin.AndroidX.Work.Runtime", "2.7.1.4"),
                ("androidx.work:work-runtime-ktx", "2.7.1", "Xamarin.AndroidX.Work.Work.Runtime.Ktx", "2.7.1.4"),
                ("com.google.android.material:material", "1.6.1", "Xamarin.Google.Android.Material", "1.6.1.1"),
                ("com.google.auto.value:auto-value-annotations", "1.9", "Xamarin.Google.AutoValue.Annotations", "1.9.0.2"),
                ("com.google.code.gson:gson", "2.9.0", "GoogleGson", "2.9.0.2"),
                ("com.google.crypto.tink:tink-android", "1.6.1", "Xamarin.Google.Crypto.Tink.Android", "1.6.1.7"),
                ("com.google.guava:failureaccess", "1.0.1", "Xamarin.Google.Guava.FailureAccess", "1.0.1.7"),
                ("com.google.guava:guava", "31.1-android", "Xamarin.Google.Guava", "31.1.0.3"),
                ("com.google.guava:listenablefuture", "1.0", "Xamarin.Google.Guava.ListenableFuture", "1.0.0.9"),
                ("com.google.j2objc:j2objc-annotations", "1.3", "Xamarin.Google.J2Objc.Annotations", "1.3.0.1"),
                ("io.reactivex.rxjava2:rxjava", "2.2.21", "Xamarin.Android.ReactiveX.RxJava", "2.2.21.7"),
                ("io.reactivex.rxjava3:rxjava", "3.1.5", "Xamarin.Android.ReactiveX.RxJava3.RxJava", "3.1.5.1"),
                ("org.checkerframework:checker-qual", "3.22.1", "Xamarin.CheckerFramework.CheckerQual", "3.22.1.1"),
                ("org.jetbrains:annotations", "23.0.0", "Xamarin.Jetbrains.Annotations", "23.0.0.4"),
                ("org.jetbrains.kotlin:kotlin-reflect", "1.6.21", "Xamarin.Kotlin.Reflect", "1.6.21.1"),
                ("org.jetbrains.kotlin:kotlin-stdlib", "1.6.21", "Xamarin.Kotlin.StdLib", "1.6.21.1"),
                ("org.jetbrains.kotlin:kotlin-stdlib-common", "1.6.21", "Xamarin.Kotlin.StdLib.Common", "1.6.21.1"),
                ("org.jetbrains.kotlin:kotlin-stdlib-jdk7", "1.6.21", "Xamarin.Kotlin.StdLib.Jdk7", "1.6.21.1"),
                ("org.jetbrains.kotlin:kotlin-stdlib-jdk8", "1.6.21", "Xamarin.Kotlin.StdLib.Jdk8", "1.6.21.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-android", "1.6.2", "Xamarin.KotlinX.Coroutines.Android", "1.6.2.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-core", "1.6.2", "Xamarin.KotlinX.Coroutines.Core", "1.6.2.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-core-jvm", "1.6.2", "Xamarin.KotlinX.Coroutines.Core.Jvm", "1.6.2.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-guava", "1.6.2", "Xamarin.KotlinX.Coroutines.Guava", "1.6.2.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-jdk8", "1.6.2", "Xamarin.KotlinX.Coroutines.Jdk8", "1.6.2.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-reactive", "1.6.2", "Xamarin.KotlinX.Coroutines.Reactive", "1.6.2.1"),
                ("org.jetbrains.kotlinx:kotlinx-coroutines-rx2", "1.6.2", "Xamarin.KotlinX.Coroutines.Rx2", "1.6.2.1"),
                ("org.reactivestreams:reactive-streams", "1.0.4", "Xamarin.Android.ReactiveStreams", "1.0.4.1")
            };


            mappings_artifact_nuget_02 = new List<(string, string, string, string)>
            {
                ("com.google.android.gms:play-services-ads", "20.6.0", "Xamarin.GooglePlayServices.Ads", "120.6.0.1"),
                ("com.google.android.gms:play-services-ads-base", "20.6.0", "Xamarin.GooglePlayServices.Ads.Base", "120.6.0.1"),
                ("com.google.android.gms:play-services-ads-identifier", "18.0.1", "Xamarin.GooglePlayServices.Ads.Identifier", "118.0.1.1"),
                ("com.google.android.gms:play-services-ads-lite", "20.6.0", "Xamarin.GooglePlayServices.Ads.Lite", "120.6.0.1"),
                ("com.google.android.gms:play-services-afs-native", "19.0.3", "Xamarin.GooglePlayServices.AFS.Native", "119.0.3.1"),
                ("com.google.android.gms:play-services-analytics", "18.0.1", "Xamarin.GooglePlayServices.Analytics", "118.0.1.1"),
                ("com.google.android.gms:play-services-analytics-impl", "18.0.1", "Xamarin.GooglePlayServices.Analytics.Impl", "118.0.1.1"),
                ("com.google.android.gms:play-services-appinvite", "18.0.0", "Xamarin.GooglePlayServices.AppInvite", "118.0.0.6"),
                ("com.google.android.gms:play-services-appset", "16.0.2", "Xamarin.GooglePlayServices.AppSet", "16.0.2.1"),
                ("com.google.android.gms:play-services-audience", "17.0.0", "Xamarin.GooglePlayServices.Audience", "117.0.0.6"),
                ("com.google.android.gms:play-services-auth", "20.2.0", "Xamarin.GooglePlayServices.Auth", "120.2.0.1"),
                ("com.google.android.gms:play-services-auth-api-phone", "18.0.1", "Xamarin.GooglePlayServices.Auth.Api.Phone", "118.0.1.1"),
                ("com.google.android.gms:play-services-auth-base", "18.0.3", "Xamarin.GooglePlayServices.Auth.Base", "118.0.3.1"),
                ("com.google.android.gms:play-services-auth-blockstore", "16.1.0", "Xamarin.GooglePlayServices.Auth.Blockstore", "116.1.0.1"),
                ("com.google.android.gms:play-services-awareness", "19.0.1", "Xamarin.GooglePlayServices.Awareness", "119.0.1.1"),
                ("com.google.android.gms:play-services-base", "18.0.1", "Xamarin.GooglePlayServices.Base", "118.0.1.1"),
                ("com.google.android.gms:play-services-basement", "18.0.2", "Xamarin.GooglePlayServices.Basement", "118.0.2.1"),
                ("com.google.android.gms:play-services-cast", "21.0.1", "Xamarin.GooglePlayServices.Cast", "121.0.1.1"),
                ("com.google.android.gms:play-services-cast-framework", "21.0.1", "Xamarin.GooglePlayServices.Cast.Framework", "121.0.1.1"),
                ("com.google.android.gms:play-services-cast-tv", "19.0.1", "Xamarin.GooglePlayServices.Cast.TV", "119.0.1.1"),
                ("com.google.android.gms:play-services-clearcut", "17.0.0", "Xamarin.GooglePlayServices.Clearcut", "117.0.0.6"),
                ("com.google.android.gms:play-services-cloud-messaging", "17.0.2", "Xamarin.GooglePlayServices.CloudMessaging", "117.0.2.1"),
                ("com.google.android.gms:play-services-cronet", "18.0.1", "Xamarin.GooglePlayServices.CroNet", "118.0.1.1"),
                ("com.google.android.gms:play-services-drive", "17.0.0", "Xamarin.GooglePlayServices.Drive", "117.0.0.7"),
                ("com.google.android.gms:play-services-fido", "18.1.0", "Xamarin.GooglePlayServices.Fido", "118.1.0.6"),
                ("com.google.android.gms:play-services-fitness", "21.0.1", "Xamarin.GooglePlayServices.Fitness", "121.0.1.1"),
                ("com.google.android.gms:play-services-flags", "18.0.1", "Xamarin.GooglePlayServices.Flags", "118.0.1.4"),
                ("com.google.android.gms:play-services-games", "22.0.1", "Xamarin.GooglePlayServices.Games", "122.0.1.1"),
                ("com.google.android.gms:play-services-gass", "20.0.0", "Xamarin.GooglePlayServices.Gass", "120.0.0.6"),
                ("com.google.android.gms:play-services-gcm", "17.0.0", "Xamarin.GooglePlayServices.Gcm", "117.0.0.6"),
                ("com.google.android.gms:play-services-identity", "18.0.1", "Xamarin.GooglePlayServices.Identity", "118.0.1.1"),
                ("com.google.android.gms:play-services-iid", "17.0.0", "Xamarin.GooglePlayServices.Iid", "117.0.0.6"),
                ("com.google.android.gms:play-services-instantapps", "18.0.1", "Xamarin.GooglePlayServices.InstantApps", "118.0.1.1"),
                ("com.google.android.gms:play-services-location", "19.0.1", "Xamarin.GooglePlayServices.Location", "119.0.1.1"),
                ("com.google.android.gms:play-services-maps", "18.0.2", "Xamarin.GooglePlayServices.Maps", "118.0.2.1"),
                ("com.google.android.gms:play-services-measurement", "20.1.2", "Xamarin.GooglePlayServices.Measurement", "120.1.2.1"),
                ("com.google.android.gms:play-services-measurement-api", "20.1.2", "Xamarin.GooglePlayServices.Measurement.Api", "120.1.2.1"),
                ("com.google.android.gms:play-services-measurement-base", "20.1.2", "Xamarin.GooglePlayServices.Measurement.Base", "120.1.2.1"),
                ("com.google.android.gms:play-services-measurement-impl", "20.1.2", "Xamarin.GooglePlayServices.Measurement.Impl", "120.1.2.1"),
                ("com.google.android.gms:play-services-measurement-sdk", "20.1.2", "Xamarin.GooglePlayServices.Measurement.Sdk", "120.1.2.1"),
                ("com.google.android.gms:play-services-measurement-sdk-api", "20.1.2", "Xamarin.GooglePlayServices.Measurement.Sdk.Api", "120.1.2.1"),
                ("com.google.android.gms:play-services-mlkit-barcode-scanning", "18.0.0", "Xamarin.GooglePlayServices.MLKit.BarcodeScanning", "118.0.0.1"),
                ("com.google.android.gms:play-services-mlkit-face-detection", "17.0.1", "Xamarin.GooglePlayServices.MLKit.FaceDetection", "117.0.1.1"),
                ("com.google.android.gms:play-services-mlkit-image-labeling", "16.0.6", "Xamarin.GooglePlayServices.MLKit.ImageLabeling", "116.0.6.1"),
                ("com.google.android.gms:play-services-mlkit-language-id", "17.0.0-beta1", "Xamarin.GooglePlayServices.MLKit.LanguageId", "117.0.0.1-beta1"),
                ("com.google.android.gms:play-services-mlkit-text-recognition", "18.0.0", "Xamarin.GooglePlayServices.MLKit.Text.Recognition", "118.0.0.1"),
                ("com.google.android.gms:play-services-mlkit-text-recognition-common", "17.0.0", "Xamarin.GooglePlayServices.MLKit.Text.Recognition.Common", "117.0.0.1"),
                ("com.google.android.gms:play-services-nearby", "18.1.0", "Xamarin.GooglePlayServices.Nearby", "118.1.0.1"),
                ("com.google.android.gms:play-services-oss-licenses", "17.0.0", "Xamarin.GooglePlayServices.Oss.Licenses", "117.0.0.6"),
                ("com.google.android.gms:play-services-pal", "19.0.0", "Xamarin.GooglePlayServices.PAL", "119.0.0.1"),
                ("com.google.android.gms:play-services-panorama", "17.0.0", "Xamarin.GooglePlayServices.Panorama", "117.0.0.6"),
                ("com.google.android.gms:play-services-password-complexity", "18.0.0", "Xamarin.GooglePlayServices.PasswordComplexity", "118.0.0.1"),
                ("com.google.android.gms:play-services-pay", "16.0.3", "Xamarin.GooglePlayServices.Pay", "116.0.3.1"),
                ("com.google.android.gms:play-services-phenotype", "17.0.0", "Xamarin.GooglePlayServices.Phenotype", "117.0.0.6"),
                ("com.google.android.gms:play-services-places", "17.0.0", "Xamarin.GooglePlayServices.Places", "117.0.0.6"),
                ("com.google.android.gms:play-services-places-placereport", "17.0.0", "Xamarin.GooglePlayServices.Places.PlaceReport", "117.0.0.6"),
                ("com.google.android.gms:play-services-plus", "17.0.0", "Xamarin.GooglePlayServices.Plus", "117.0.0.7"),
                ("com.google.android.gms:play-services-recaptcha", "16.0.1", "Xamarin.GooglePlayServices.Recaptcha", "116.0.1.1"),
                ("com.google.android.gms:play-services-safetynet", "18.0.1", "Xamarin.GooglePlayServices.SafetyNet", "118.0.1.1"),
                ("com.google.android.gms:play-services-stats", "17.0.3", "Xamarin.GooglePlayServices.Stats", "117.0.3.1"),
                ("com.google.android.gms:play-services-streamprotect", "16.0.2", "Xamarin.GooglePlayServices.StreamProtect", "116.0.2.2"),
                ("com.google.android.gms:play-services-tagmanager", "18.0.1", "Xamarin.GooglePlayServices.TagManager", "118.0.1.1"),
                ("com.google.android.gms:play-services-tagmanager-api", "18.0.1", "Xamarin.GooglePlayServices.TagManager.Api", "118.0.1.1"),
                ("com.google.android.gms:play-services-tagmanager-v4-impl", "18.0.1", "Xamarin.GooglePlayServices.TagManager.V4.Impl", "118.0.1.1"),
                ("com.google.android.gms:play-services-tasks", "18.0.1", "Xamarin.GooglePlayServices.Tasks", "118.0.1.1"),
                ("com.google.android.gms:play-services-vision", "20.1.3", "Xamarin.GooglePlayServices.Vision", "120.1.3.6"),
                ("com.google.android.gms:play-services-vision-common", "19.1.3", "Xamarin.GooglePlayServices.Vision.Common", "119.1.3.6"),
                ("com.google.android.gms:play-services-vision-face-contour-internal", "16.1.0", "Xamarin.GooglePlayServices.Vision.Face.Contour.Internal", "116.1.0.6"),
                ("com.google.android.gms:play-services-vision-image-label", "18.1.1", "Xamarin.GooglePlayServices.Vision.ImageLabel", "118.1.1.6"),
                ("com.google.android.gms:play-services-vision-image-labeling-internal", "16.1.0", "Xamarin.GooglePlayServices.Vision.ImageLabelingInternal", "116.1.0.6"),
                ("com.google.android.gms:play-services-wallet", "19.1.0", "Xamarin.GooglePlayServices.Wallet", "119.1.0.1"),
                ("com.google.android.gms:play-services-wearable", "17.1.0", "Xamarin.GooglePlayServices.Wearable", "117.1.0.6"),
                ("com.google.android.play:core", "1.10.3", "Xamarin.Google.Android.Play.Core", "1.10.3.1"),
                ("com.google.android.play:integrity", "1.0.0", "Xamarin.Google.Android.Play.Integrity", "1.0.0.1"),
                ("com.google.firebase:firebase-abt", "21.0.0", "Xamarin.Firebase.Abt", "121.0.0.6"),
                ("com.google.firebase:firebase-ads", "20.3.0", "Xamarin.Firebase.Ads", "120.3.0.6"),
                ("com.google.firebase:firebase-ads-lite", "20.3.0", "Xamarin.Firebase.Ads.Lite", "120.3.0.6"),
                ("com.google.firebase:firebase-analytics", "20.0.1", "Xamarin.Firebase.Analytics", "120.0.1.1"),
                ("com.google.firebase:firebase-analytics-impl", "16.3.0", "Xamarin.Firebase.Analytics.Impl", "116.3.0.6"),
                ("com.google.firebase:firebase-annotations", "16.0.0", "Xamarin.Firebase.Annotations", "116.0.0.6"),
                ("com.google.firebase:firebase-appcheck-interop", "16.0.0-beta01", "Xamarin.Firebase.AppCheck.Interop", "116.0.0.6-beta01"),
                ("com.google.firebase:firebase-appindexing", "20.0.0", "Xamarin.Firebase.AppIndexing", "120.0.0.8"),
                ("com.google.firebase:firebase-auth", "21.0.1", "Xamarin.Firebase.Auth", "121.0.1.7"),
                ("com.google.firebase:firebase-auth-interop", "20.0.0", "Xamarin.Firebase.Auth.Interop", "120.0.0.6"),
                ("com.google.firebase:firebase-common", "20.0.0", "Xamarin.Firebase.Common", "120.0.0.6"),
                ("com.google.firebase:firebase-components", "17.0.0", "Xamarin.Firebase.Components", "117.0.0.6"),
                ("com.google.firebase:firebase-config", "21.0.1", "Xamarin.Firebase.Config", "121.0.1.6"),
                ("com.google.firebase:firebase-core", "19.0.1", "Xamarin.Firebase.Core", "119.0.1.6"),
                ("com.google.firebase:firebase-crash", "16.2.1", "Xamarin.Firebase.Crash", "116.2.1.6"),
                ("com.google.firebase:firebase-crashlytics", "18.2.1", "Xamarin.Firebase.Crashlytics", "118.2.1.6"),
                ("com.google.firebase:firebase-crashlytics-ndk", "18.2.1", "Xamarin.Firebase.Crashlytics.NDK", "118.2.1.6"),
                ("com.google.firebase:firebase-database", "20.0.0", "Xamarin.Firebase.Database", "120.0.0.6"),
                ("com.google.firebase:firebase-database-collection", "18.0.0", "Xamarin.Firebase.Database.Collection", "118.0.0.6"),
                ("com.google.firebase:firebase-database-connection", "16.0.2", "Xamarin.Firebase.Database.Connection", "116.0.2.6"),
                ("com.google.firebase:firebase-datatransport", "18.0.1", "Xamarin.Firebase.Datatransport", "118.0.1.6"),
                ("com.google.firebase:firebase-dynamic-links", "20.1.1", "Xamarin.Firebase.Dynamic.Links", "120.1.1.6"),
                ("com.google.firebase:firebase-encoders", "17.0.0", "Xamarin.Firebase.Encoders", "117.0.0.6"),
                ("com.google.firebase:firebase-encoders-json", "18.0.0", "Xamarin.Firebase.Encoders.JSON", "118.0.0.6"),
                ("com.google.firebase:firebase-encoders-proto", "16.0.0", "Xamarin.Firebase.Encoders.Proto", "116.0.0.1"),
                ("com.google.firebase:firebase-firestore", "23.0.3", "Xamarin.Firebase.Firestore", "123.0.3.6"),
                ("com.google.firebase:firebase-functions", "20.0.0", "Xamarin.Firebase.Functions", "120.0.0.6"),
                ("com.google.firebase:firebase-iid", "21.1.0", "Xamarin.Firebase.Iid", "121.1.0.6"),
                ("com.google.firebase:firebase-iid-interop", "17.1.0", "Xamarin.Firebase.Iid.Interop", "117.1.0.6"),
                ("com.google.firebase:firebase-inappmessaging", "20.1.0", "Xamarin.Firebase.InAppMessaging", "120.1.0.6"),
                ("com.google.firebase:firebase-inappmessaging-display", "20.1.0", "Xamarin.Firebase.InAppMessaging.Display", "120.1.0.6"),
                ("com.google.firebase:firebase-installations", "17.0.0", "Xamarin.Firebase.Installations", "117.0.0.6"),
                ("com.google.firebase:firebase-installations-interop", "17.0.0", "Xamarin.Firebase.Installations.InterOp", "117.0.0.6"),
                ("com.google.firebase:firebase-invites", "17.0.0", "Xamarin.Firebase.Invites", "117.0.0.6"),
                ("com.google.firebase:firebase-measurement-connector", "19.0.0", "Xamarin.Firebase.Measurement.Connector", "119.0.0.6"),
                ("com.google.firebase:firebase-messaging", "22.0.0", "Xamarin.Firebase.Messaging", "122.0.0.6"),
                ("com.google.firebase:firebase-ml-common", "22.1.2", "Xamarin.Firebase.ML.Common", "122.1.2.6"),
                ("com.google.firebase:firebase-ml-model-interpreter", "22.0.4", "Xamarin.Firebase.ML.Model.Interpreter", "122.0.4.6"),
                ("com.google.firebase:firebase-ml-natural-language", "22.0.1", "Xamarin.Firebase.ML.Natural.Language", "122.0.1.6"),
                ("com.google.firebase:firebase-ml-natural-language-language-id-model", "20.0.8", "Xamarin.Firebase.ML.Natural.Language.Id.Model", "120.0.8.6"),
                ("com.google.firebase:firebase-ml-natural-language-smart-reply", "18.0.8", "Xamarin.Firebase.ML.Natural.Language.Smart.Reply", "118.0.8.6"),
                ("com.google.firebase:firebase-ml-natural-language-smart-reply-model", "20.0.8", "Xamarin.Firebase.ML.Natural.Language.Smart.Reply.Model", "120.0.8.6"),
                ("com.google.firebase:firebase-ml-natural-language-translate", "22.0.2", "Xamarin.Firebase.ML.Natural.Language.Translate", "122.0.2.6"),
                ("com.google.firebase:firebase-ml-natural-language-translate-model", "20.0.9", "Xamarin.Firebase.ML.Natural.Language.Translate.Model", "120.0.9.6"),
                ("com.google.firebase:firebase-ml-vision", "24.1.0", "Xamarin.Firebase.ML.Vision", "124.1.0.6"),
                ("com.google.firebase:firebase-ml-vision-automl", "18.0.6", "Xamarin.Firebase.ML.Vision.AutoML", "118.0.6.6"),
                ("com.google.firebase:firebase-ml-vision-barcode-model", "16.1.2", "Xamarin.Firebase.ML.Vision.BarCode.Model", "116.1.2.6"),
                ("com.google.firebase:firebase-ml-vision-face-model", "20.0.2", "Xamarin.Firebase.ML.Vision.Face.Model", "120.0.2.6"),
                ("com.google.firebase:firebase-ml-vision-image-label-model", "20.0.2", "Xamarin.Firebase.ML.Vision.Image.Label.Model", "120.0.2.6"),
                ("com.google.firebase:firebase-ml-vision-internal-vkp", "17.0.2", "Xamarin.Firebase.ML.Vision.Internal.Vkp", "117.0.2.6"),
                ("com.google.firebase:firebase-ml-vision-object-detection-model", "19.0.6", "Xamarin.Firebase.ML.Vision.Object.Detection.Model", "119.0.6.6"),
                ("com.google.firebase:firebase-perf", "20.0.2", "Xamarin.Firebase.Perf", "120.0.2.6"),
                ("com.google.firebase:firebase-storage", "20.0.0", "Xamarin.Firebase.Storage", "120.0.0.6"),
                ("com.google.firebase:firebase-storage-common", "17.0.0", "Xamarin.Firebase.Storage.Common", "117.0.0.6"),
                ("com.google.firebase:protolite-well-known-types", "18.0.0", "Xamarin.Firebase.ProtoliteWellKnownTypes", "118.0.0.6"),
                ("com.google.mlkit:barcode-scanning", "17.0.2", "Xamarin.Google.MLKit.BarcodeScanning", "117.0.2.1"),
                ("com.google.mlkit:barcode-scanning-common", "17.0.0", "Xamarin.Google.MLKit.BarcodeScanning.Common", "117.0.0.1"),
                ("com.google.mlkit:common", "18.2.0", "Xamarin.Google.MLKit.Common", "118.2.0.1"),
                ("com.google.mlkit:digital-ink-recognition", "18.0.0", "Xamarin.Google.MLKit.DigitalInk.Recognition", "118.0.0.1"),
                ("com.google.mlkit:face-detection", "16.1.5", "Xamarin.Google.MLKit.FaceDetection", "116.1.5.1"),
                ("com.google.mlkit:image-labeling", "17.0.7", "Xamarin.Google.MLKit.ImageLabeling", "117.0.7.1"),
                ("com.google.mlkit:image-labeling-automl", "16.2.1", "Xamarin.Google.MLKit.ImageLabeling.AutoML", "116.2.1.7"),
                ("com.google.mlkit:image-labeling-common", "18.0.0", "Xamarin.Google.MLKit.ImageLabeling.Common", "118.0.0.1"),
                ("com.google.mlkit:image-labeling-custom", "17.0.1", "Xamarin.Google.MLKit.ImageLabeling.Custom", "117.0.1.1"),
                ("com.google.mlkit:image-labeling-custom-common", "17.0.0", "Xamarin.Google.MLKit.ImageLabeling.Custom.Common", "117.0.0.1"),
                ("com.google.mlkit:image-labeling-default-common", "17.0.0", "Xamarin.Google.MLKit.ImageLabeling.Default.Common", "117.0.0.1"),
                ("com.google.mlkit:language-id", "17.0.3", "Xamarin.Google.MLKit.Language.Id", "117.0.3.1"),
                ("com.google.mlkit:linkfirebase", "17.0.0", "Xamarin.Google.MLKit.LinkFirebase", "117.0.0.1"),
                ("com.google.mlkit:mediapipe-internal", "16.0.0", "Xamarin.Google.MLKit.MediaPipe.Internal", "116.0.0.6"),
                ("com.google.mlkit:object-detection", "17.0.0", "Xamarin.Google.MLKit.ObjectDetection", "117.0.0.1"),
                ("com.google.mlkit:object-detection-common", "18.0.0", "Xamarin.Google.MLKit.ObjectDetection.Common", "118.0.0.1"),
                ("com.google.mlkit:object-detection-custom", "17.0.0", "Xamarin.Google.MLKit.ObjectDetection.Custom", "117.0.0.1"),
                ("com.google.mlkit:pose-detection", "17.0.0", "Xamarin.Google.MLKit.PoseDetection", "117.0.0.6"),
                ("com.google.mlkit:pose-detection-accurate", "17.0.0", "Xamarin.Google.MLKit.PoseDetection.Accurate", "117.0.0.6"),
                ("com.google.mlkit:pose-detection-common", "17.0.0", "Xamarin.Google.MLKit.PoseDetection.Common", "117.0.0.6"),
                ("com.google.mlkit:smart-reply", "17.0.0", "Xamarin.Google.MLKit.SmartReply", "117.0.0.1"),
                ("com.google.mlkit:translate", "17.0.0", "Xamarin.Google.MLKit.Translate", "117.0.0.1"),
                ("com.google.mlkit:vision-common", "17.1.0", "Xamarin.Google.MLKit.Vision.Common", "117.1.0.1"),
                ("com.google.mlkit:vision-interfaces", "16.0.0", "Xamarin.Google.MLKit.Vision.Interfaces", "116.0.0.1"),
                ("com.google.mlkit:vision-internal-vkp", "18.2.2", "Xamarin.Google.MLKit.Vision.Internal.Vkp", "118.2.2.1"),
                ("com.google.android.odml:image", "1.0.0-beta1", "Xamarin.Google.Android.ODML.Image", "1.0.0.1-beta1"),
                ("com.google.android.libraries.places:places", "2.0.0", "Xamarin.GoogleAndroid.Libraries.Places", "2.0.0.1"),
                ("com.google.android.libraries.places:places-compat", "2.0.0", "Xamarin.GoogleAndroid.Libraries.Places.Compat", "2.0.0.1"),
                ("com.android.volley:volley", "1.2.1", "Xamarin.Android.Volley", "1.2.1.1"),
                ("com.android.volley:volley-cronet", "1.2.1", "Xamarin.Android.Volley.CroNet", "1.2.1.1"),
                ("com.github.bumptech.glide:annotations", "4.13.2", "Xamarin.Android.Glide.Annotations", "4.13.2.1"),
                ("com.github.bumptech.glide:disklrucache", "4.13.2", "Xamarin.Android.Glide.DiskLruCache", "4.13.2.1"),
                ("com.github.bumptech.glide:gifdecoder", "4.13.2", "Xamarin.Android.Glide.GifDecoder", "4.13.2.1"),
                ("com.github.bumptech.glide:glide", "4.13.2", "Xamarin.Android.Glide", "4.13.2.1"),
                ("com.github.bumptech.glide:recyclerview-integration", "4.13.2", "Xamarin.Android.Glide.RecyclerViewIntegration", "4.13.2.1"),
                ("com.google.android:annotations", "4.1.1.4", "Xamarin.GoogleAndroid.Annotations", "4.1.1.7"),
                ("com.google.android.datatransport:transport-api", "3.0.0", "Xamarin.Google.Android.DataTransport.TransportApi", "3.0.0.4"),
                ("com.google.android.datatransport:transport-backend-cct", "3.1.4", "Xamarin.Google.Android.DataTransport.TransportBackendCct", "3.1.4.1"),
                ("com.google.android.datatransport:transport-runtime", "3.1.4", "Xamarin.Google.Android.DataTransport.TransportRuntime", "3.1.4.1"),
                ("com.google.android.ump:user-messaging-platform", "2.0.0", "Xamarin.Google.UserMessagingPlatform", "2.0.0.1"),
                ("com.google.code.findbugs:jsr305", "3.0.2", "Xamarin.Google.Code.FindBugs.JSR305", "3.0.2.5"),
                ("com.google.dagger:dagger", "2.41", "Xamarin.Google.Dagger", "2.41.0.1"),
                ("com.google.errorprone:error_prone_annotations", "2.10.0", "Xamarin.Google.ErrorProne.Annotations", "2.10.0.1"),
                ("com.google.zxing:core", "3.5.0", "Xamarin.Google.ZXing.Core", "3.5.0.1"),
                ("com.google.protobuf:protobuf-javalite", "3.19.2", "Xamarin.Protobuf.JavaLite", "3.19.2.1"),
                ("com.google.protobuf:protobuf-lite", "3.0.1", "Xamarin.Protobuf.Lite", "3.0.1.5"),
                ("com.squareup.okhttp:okhttp", "2.7.5", "Square.OkHttp", "2.7.5.5"),
                ("com.squareup.okhttp3:okhttp", "4.9.3", "Square.OkHttp3", "4.9.3.1"),
                ("com.squareup.okhttp3:okhttp-urlconnection", "4.9.3", "Square.OkHttp3.UrlConnection", "4.9.3.1"),
                ("com.squareup.okio:okio", "2.10.0", "Square.OkIO", "2.10.0.4"),
                ("com.squareup.picasso:picasso", "2.8", "Square.Picasso", "2.8.0.4"),
                ("com.squareup.retrofit:retrofit", "1.9.0", "Square.Retrofit", "1.9.0.5"),
                ("com.squareup:javapoet", "1.13.0", "Square.JavaPoet", "1.13.0.1"),
                ("io.grpc:grpc-android", "1.45.1", "Xamarin.Grpc.Android", "1.45.1.1"),
                ("io.grpc:grpc-api", "1.45.1", "Xamarin.Grpc.Api", "1.45.1.1"),
                ("io.grpc:grpc-context", "1.45.1", "Xamarin.Grpc.Context", "1.45.1.1"),
                ("io.grpc:grpc-core", "1.45.1", "Xamarin.Grpc.Core", "1.45.1.1"),
                ("io.grpc:grpc-okhttp", "1.45.1", "Xamarin.Grpc.OkHttp", "1.45.1.1"),
                ("io.grpc:grpc-protobuf-lite", "1.45.1", "Xamarin.Grpc.Protobuf.Lite", "1.45.1.1"),
                ("io.grpc:grpc-stub", "1.45.1", "Xamarin.Grpc.Stub", "1.45.1.1"),
                ("io.opencensus:opencensus-api", "0.29.0", "Xamarin.Io.OpenCensus.OpenCensusApi", "0.29.0.1"),
                ("io.opencensus:opencensus-contrib-grpc-metrics", "0.29.0", "Xamarin.Io.OpenCensus.OpenCensusContribGrpcMetrics", "0.29.0.1"),
                ("io.perfmark:perfmark-api", "0.24.0", "Xamarin.Io.PerfMark.PerfMarkApi", "0.24.0.1"),
                ("javax.inject:javax.inject", "1", "Xamarin.JavaX.Inject", "1.0.0.5"),
                ("org.chromium.net:cronet-api", "92.4515.131", "Xamarin.Chromium.CroNet.Api", "92.4515.131.1"),
                ("org.chromium.net:cronet-common", "92.4515.131", "Xamarin.Chromium.CroNet.Common", "92.4515.131.1"),
                ("org.chromium.net:cronet-embedded", "92.4515.131", "Xamarin.Chromium.CroNet.Embedded", "92.4515.131.1"),
                ("org.chromium.net:cronet-fallback", "92.4515.131", "Xamarin.Chromium.CroNet.Fallback", "92.4515.131.1"),
                ("org.codehaus.mojo:animal-sniffer-annotations", "1.19", "Xamarin.CodeHaus.Mojo.AnimalSnifferAnnotations", "1.19.0.1"),
                ("org.tensorflow:tensorflow-lite", "2.6.0", "Xamarin.TensorFlow.Lite", "2.6.0.1"),
                ("org.tensorflow:tensorflow-lite-gpu", "2.6.0", "Xamarin.TensorFlow.Lite.Gpu", "2.6.0.1"),
            };

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
