using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using HolisticWare.Xamarin.Tools.GitHub;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType;

namespace BindingConfigurator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            Dictionary<string, IEnumerable<(Tag, string)>> repo_tags_content;

            repo_tags_content = await new BinderatorConfigDownloader().DownloadBinderatorConfigContentsAsync
                                                                            (
                                                                                "xamarin",
                                                                                "androidx"
                                                                            );



            //await GoogleMavenData.LoadAsync(local: false);

            //ProcesGoogleAndroidX();
            //ProcesGooglePlayServicesFirebase();

            Console.WriteLine("Exiting ...");

            return;
        }

        private static void ProcesGooglePlayServicesFirebase()
        {
            GoogleMavenData google_maven_data = new GoogleMavenData();

            google_maven_data.RepositoryNames = new List<string>()
            {
                "com.google.android.gms",
                "com.google.firebase",
            };

            google_maven_data.Name = "google-play-services-and-firebase";
            string json = null;
            json = File.ReadAllText
                                (
                                    Path.Combine
                                            (
                                                "BinderatorConfigData",
                                                "GooglePlayServicesFirebase",
                                                "201911",
                                                "config.json"
                                            )
                                );
            ConfigRoot cr = new ConfigRoot();
            IEnumerable<ConfigRoot> config = JsonConvert.DeserializeObject<IEnumerable<ConfigRoot>>(json);

            google_maven_data.BinderatorConfig = new BinderatorConfigDownloader()
            {
                Configs = config
            };

            google_maven_data.ArtifactsToBind = new List<string>
            {
                "play-services-ads",
                "play-services-ads-base",
                "play-services-ads-identifier",
                "play-services-ads-lite",
                "play-services-analytics",
                "play-services-analytics-impl",
                "play-services-appinvite",
                "play-services-audience",
                "play-services-auth",
                "play-services-auth-api-phone",
                "play-services-auth-base",
                "play-services-awareness",
                "play-services-base",
                "play-services-basement",
                "play-services-cast",
                "play-services-cast-framework",
                "play-services-clearcut",
                "play-services-drive",
                "play-services-fido",
                "play-services-fitness",
                "play-services-flags",
                "play-services-games",
                "play-services-gass",
                "play-services-gcm",
                "play-services-identity",
                "play-services-iid",
                "play-services-instantapps",
                "play-services-location",
                "play-services-maps",
                "play-services-measurement",
                "play-services-measurement-base",
                "play-services-measurement-api",
                "play-services-measurement-impl",
                "play-services-measurement-sdk",
                "play-services-measurement-sdk-api",
                "play-services-nearby",
                "play-services-oss-licenses",
                "play-services-panorama",
                "play-services-phenotype",
                "play-services-places",
                "play-services-places-placereport",
                "play-services-plus",
                "play-services-safetynet",
                "play-services-stats",
                "play-services-tagmanager",
                "play-services-tagmanager-api",
                "play-services-tagmanager-v4-impl",
                "play-services-tasks",
                "play-services-vision",
                "play-services-vision-common",
                "play-services-vision-image-label",
                "play-services-wallet",
                "play-services-wearable",
                "firebase-abt",
                "firebase-ads",
                "firebase-ads-lite",
                "firebase-analytics",
                "firebase-analytics-impl",
                "firebase-appindexing",
                "firebase-auth",
                "firebase-auth-interop",
                "firebase-common",
                "firebase-config",
                "firebase-core",
                "firebase-crash",
                "firebase-database",
                "firebase-database-collection",
                "firebase-database-connection",
                "firebase-dynamic-links",
                "firebase-firestore",
                "firebase-functions",
                "firebase-iid",
                "firebase-iid-interop",
                "firebase-invites",
                "firebase-measurement-connector",
                "firebase-measurement-connector-impl",
                "firebase-messaging",
                "firebase-ml-common",
                "firebase-ml-model-interpreter",
                "firebase-ml-vision",
                "firebase-ml-vision-image-label-model",
                "firebase-perf",
                "firebase-storage",
                "firebase-storage-common",
                "protolite-well-known-types",
            };


            google_maven_data.Initialize();

            google_maven_data.LoadRemoteReposAsync();

            google_maven_data.SaveAsync().Wait();

            return;
        }

        private static void ProcesGoogleAndroidX()
        {
            GoogleMavenData google_maven_data = new GoogleMavenData();

            google_maven_data.RepositoryNames = new List<string>()
            {
            };

            google_maven_data.Name = "androidx";
            string json = null;
            json = File.ReadAllText
                                (
                                    Path.Combine
                                            (
                                                "BinderatorConfigData",
                                                "AndroidX",
                                                "202001",
                                                "config.json"
                                            )
                                );
            IEnumerable<ConfigRoot> config = JsonConvert.DeserializeObject<IEnumerable<ConfigRoot>>(json);

            google_maven_data.BinderatorConfig = new BinderatorConfigDownloader()
            {
                Configs = config
            };

            google_maven_data.RepositoryNames = new List<string>
            {
                "androidx",
            };


            google_maven_data.Initialize();

            google_maven_data.LoadRemoteReposAsync();

            google_maven_data.SaveAsync().Wait();

            return;
        }

    }
}
