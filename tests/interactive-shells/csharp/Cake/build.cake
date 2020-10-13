#addin "nuget:https://www.nuget.org/api/v2?package=Newtonsoft.Json"
#addin "nuget:?package=Newtonsoft.Json"

//#reference "../../../../source/HolisticWare.Xamarin.Tools.GitHub/bin/Debug/netstandard2.1/HolisticWare.Xamarin.Tools.GitHub.dll"
//#addin nuget:file://localhost/packages/?package=microsoft.ml.1.5.2.nupkg

using System.Net.Http;

#load "Tag.cs"

//using System.Net.Http;

string owner        = $"xamarin";
string repository   = $"AndroidX";
string url          =
                    // $"https://api.github.com/repos/{owner}/{repository}/tags"
                    // $"https://api.github.com/users/katodix"
                    // $"https://api.github.com/orgs/{owner}"
                    // $"https://api.github.com/users/moljac/repos"
                    // $"https://api.github.com/orgs/{owner}/repos"
                    // $"https://raw.githubusercontent.com/{owner}/{repository}/20200924-fix-dependencies-and-for-ArchTaskExecutor/config.json"
                    // docs
                    // "https://drive.google.com/file/d/0Bz-rhZ21ShvOTl9wdHBQdG1YSDQ/view"
                    // "https://doc-0k-b0-docs.googleusercontent.com/docs/securesc/4a6ib9h571rj6aq1ccapbcb39aau6vbe/nn9abr3hijoip6000fui2nl6jb6osarq/1602605475000/16191049093752762150/18006410927452750686/0Bz-rhZ21ShvOTl9wdHBQdG1YSDQ?e=download&authuser=0&nonce=cm39g0a9vighk&user=18006410927452750686&hash=0bo52h19mdrr269doe2eq83qnjh6h2i3"
                    "https://drive.google.com/uc?id=0Bz-rhZ21ShvOTl9wdHBQdG1YSDQ&export=download"
                    ;

using (System.Net.Http.HttpClient http_client = new System.Net.Http.HttpClient())
{
    // https://stackoverflow.com/questions/57079111/requesting-to-github-api-using-net-httpclient-says-forbidden
    /*
    Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36
    */
    http_client.DefaultRequestHeaders
                    .Add
                        (
                            "User-Agent",
                            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                        )
                    //.UserAgent.Add(new ProductInfoHeaderValue("yourAppName", "yourVersionNumber"))
                    ;
    string response_string_json = await http_client.GetStringAsync(url);

    Information($"JSON");
    Information($"{response_string_json}");
    // Now parse with JSON.Net
}
