// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Timers;

using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

using HolisticWare.Xamarin.Tools.NuGet.NeekNoke;
using HolisticWare.Xamarin.Tools.NeekNoke.App.Console.DotNetTool;

using Action = HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Action;

Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
Trace.AutoFlush = true;
int width = Console.WindowWidth;

System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
stopwatch.Start();

// http://easyonlineconverter.com/converters/dot-net-string-escape.html
// https://www.csharpescaper.com/
// find ./ -name "*bckp-ts-$(date +"%Y%m%d)*"


Trace.WriteLine($"{Settings.Intro}");

string filename_timing = null;

foreach(string arg in args)
{
    switch (arg)
    {
        case "neek":
            NeekerNoker.Action = Action.Neek;
            break;
        case "noke":
            NeekerNoker.Action = Action.Noke;
            break;
        case string line_preprocessor when arg.StartsWith("--file-timing:"):
            filename_timing = arg.Replace("--file-timing:", "");
            break;
        default:
            Trace.WriteLine($"{arg} not recognized!!");
            Trace.WriteLine("verb/command (command line argument) can be neek or noke");
            return 1;
    }

}

var netCoreVer = System.Environment.Version; // 3.0.0
var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; // .NET Core 3.0.0-preview4.19113.15

string[] patterns = new string[]
                                {
                                    "*.csproj",
                                    "*.cake",
                                    "config.json",
                                    "*.props",
                                    "*.targets",
                                    "global.json",
                                    "workloads.json",
                                    "*.csx",
                                    "*.fsproj",
                                    "*.vbproj",
                                    "*.proj",
                                    "*.xproj",
                                    "packages.config",
                                };

Dictionary<string, string[]> patterns_files = new Scraper().Harvest(patterns);

/*
foreach (KeyValuePair<string, string[]> pattern in patterns_files)
{
    Trace.Indent();
    Trace.WriteLine(new string('=', 120));
    Trace.WriteLine($"file {pattern.Key}");

    foreach (string p in pattern.Value)
    {
        Trace.Indent();
        Trace.WriteLine($"{p}");
        Trace.Unindent();
    }

    Trace.Unindent();
}
*/

Trace.Flush();


NeekerNoker.VersionDotNetSDKBand = "6.0.400";   // needed for workloads
NeekerNoker neeker_noker = new NeekerNoker();

neeker_noker.Neek(patterns_files);
neeker_noker.Dump();

Dictionary<string, PackageAppearanceData> packages_found = neeker_noker.PackageDataCleanup();

Dictionary
        <
            string, // nuget_id
            (
                string version_current,
                string version_latest,
                List<string> versions_upgradeable,
                NuGetPackage package_details,
                bool failed
            )
        >
        packages_info = null;

Trace.WriteLine("Fetching NuGet package info from https://nuget.org ...");

packages_info = neeker_noker.PackageDataFetch(packages_found);

if (NeekerNoker.Action == Action.Noke)
{
    Trace.WriteLine("Writting NuGet updated package versions in files...");
    neeker_noker.Noke();
}


stopwatch.Stop();

// neek --file-timing:timings-System.Text.JSON.csv
// neek --file-timing:./samples/console/apps/project-references/timings-System.Text.JSON.csv
neeker_noker.DumpTiming(filename_timing, stopwatch);


if (NeekerNoker.Action == Action.Noke)
{
    Trace.WriteLine($"{Settings.Outro}");
}

/*
git submodule deinit -f .
git submodule update --init
*/

return 0;
