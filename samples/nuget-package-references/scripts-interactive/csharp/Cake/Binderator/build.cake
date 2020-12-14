//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool   nuget:?package=Cake.CoreCLR

#addin  nuget:?package=HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister&prerelease&loaddependencies=true
#addin  nuget:?package=HolisticWare.Xamarin.Tools.NuGet&prerelease&loaddependencies=true


using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator;

Artifact a = null;

a = new Artifact("androidx.car", "car", "0.0.0");

a.SaveAsync().Wait();
