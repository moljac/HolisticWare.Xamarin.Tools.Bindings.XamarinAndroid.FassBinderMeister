﻿using System;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator
{
    public class BinderatorConfigUrls
    {
        public BinderatorConfigUrls()
        {
        }

        static (string repo, string tag)[] RepoTags =
        {
            ( repo: $"AndroidX", tag: $"20200214-stable-release" ),
            ( repo: $"AndroidX", tag: $"20200316-stable-release-previous-GPS-FB" ),
            ( repo: $"AndroidX", tag: $"20200318-stable-release" ),
            ( repo: $"AndroidX", tag: $"20200327-stable-release-fix-issue0066-ViewPager2.FragmentStateAdapter.OnBindViewHolder" ),
            ( repo: $"AndroidX", tag: $"20200330-stable-release-updates" ),
            ( repo: $"AndroidX", tag: $"20200404-stable-release-fix-issue0086-Work.Runtime-missing-dependencies" ),
            ( repo: $"AndroidX", tag: $"20200408-WorkRuntime-2.3.3.1" ),
            ( repo: $"AndroidX", tag: $"20200424-stable-release-Fragment-Navigation-Preference-VersionedParcelable" ),
            ( repo: $"AndroidX", tag: $"20200504-stable-release-migration-fixes" ),

            ( repo: $"GooglePlayServicesComponents", tag: $"100.20200429-androidx-previews01" ),
            ( repo: $"GooglePlayServicesComponents", tag: $"100.20200513-androidx-previews02" ),
            ( repo: $"GooglePlayServicesComponents", tag: $"100.20200526-androidx-previews03" ),
            ( repo: $"GooglePlayServicesComponents", tag: $"100.20200527-androidx-previews01-202005" ),
        };

        public static async Task DownloadConfigsAsync()
        {
            foreach (var rt in RepoTags)
            {
                await DownloadConfigAsync(rt.repo, rt.tag);
            }

            return;
        }

        static System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        public static async Task DownloadConfigAsync(string repo, string tag)
        {
            string user_org = $"xamarin";
            string url_github = $"https://raw.githubusercontent.com/{user_org}/{repo}/{tag}/config.json";


            System.Net.Http.HttpResponseMessage result = await client.GetAsync(url_github);
            string dir = System.IO.Path.Combine("BinderatorConfigData", "tags", $"{repo}", $"{tag}");
            string content = await result.Content.ReadAsStringAsync();
            if (! System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            System.IO.File.WriteAllText
                                (
                                    System.IO.Path.Combine($"{dir}", "config.json"),
                                    content
                                );

            return;
        }
    }
}
