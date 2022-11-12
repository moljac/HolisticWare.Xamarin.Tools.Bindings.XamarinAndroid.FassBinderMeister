// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Timers;
using HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke;
using HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;
using Action = HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Action;

System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
stopwatch.Start();

string about =
@"
                 _                       _                                     
                | |                     | |                                    
 _ __   ___  ___| | ________ _ __   ___ | | _____                              
| '_ \ / _ \/ _ | |/ |______| '_ \ / _ \| |/ / _ \                             
| | | |  __|  __|   <       | | | | (_) |   |  __/                             
|_| |_|\___|\___|_|\_\      |_| |_|\___/|_|\_\___|                             
                                                                               
                                                                               
 _   _       _____      _                     _                       _        
| \ | |     |  __ \    | |                   | |                     | |       
|  \| |_   _| |  \/ ___| |_   _ __   ___  ___| | ________ _ __   ___ | | _____ 
| . ` | | | | | __ / _ | __| | '_ \ / _ \/ _ | |/ |______| '_ \ / _ \| |/ / _ \
| |\  | |_| | |_\ |  __| |_  | |_) |  __|  __|   <       | |_) | (_) |   |  __/
\_| \_/\__,_|\____/\___|\__| | .__/ \___|\___|_|\_\      | .__/ \___/|_|\_\___|
                             | |                         | |                   
                             |_|                         |_|
neek-noke
NuGet peek-poke
"
+
@"
moljac AKA miljenko mel cvjetko 
https://github.com/moljac

to collect backups

    find ./ -name ""*bckp-ts-*""
or 
    find ./ -name ""*bckp-ts-$(date +""%Y%m%d)*""

to cleanup backups:

    rm $(find ./ -name ""*bckp-ts-*"")

or

    rm $(find ./ -name ""*bckp-ts-$(date +""%Y%m%d)*"")
";

// http://easyonlineconverter.com/converters/dot-net-string-escape.html
// https://www.csharpescaper.com/
// find ./ -name "*bckp-ts-$(date +"%Y%m%d)*"

Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
Trace.AutoFlush = true;

Trace.WriteLine($"{about}");

switch (args.Length)
{
    case 0:
        NeekerNoker.Action = Action.Neek;
        break;
    case 1:
        switch (args[0])
        {
            case "neek":
                NeekerNoker.Action = Action.Neek;
                break;
            case "noke":
                NeekerNoker.Action = Action.Noke;
                break;
            default:
                Trace.WriteLine($"{args[0]} not recognized!!");
                Trace.WriteLine("verb/command (command line argument) can be neek or noke");
                return 1;
                break;
        }
        break;
    default:
        Trace.WriteLine("verb/command (command line argument) can be neek or noke");
        return 1;
}

string[] patterns = new string[]
                                {
                                    "*.csproj",
                                    "config.json",
                                    "directory.build.*.props",
                                    "directory.packages.*.props",
                                    "*.props",
                                    "*.targets",
                                    "global.json",
                                    "*.cake",
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

NeekerNoker neeker = new NeekerNoker();

neeker.NeekNoke(patterns_files);

foreach (KeyValuePair<string, NeekerNokerBase> nnb in neeker.ResultsPerPattern.Results)
{
    Trace.WriteLine($"pattern:      {nnb.Key}");
    NeekerNokerBase nn = nnb.Value;

    foreach
    (
        KeyValuePair
            <
                string,                         // file
                (
                    string file_backup,         // file backup
                    string content,
                    string content_backup
                )
            >
            kv_log in nn.ResultsPerFile.Log
    )
    {
        Trace.WriteLine($"  file:      {kv_log.Key}");
        if (NeekerNoker.Action == Action.Noke)
        {
            Trace.WriteLine($"      file_backup:      {kv_log.Value.file_backup}");
        }
    }

    Trace.WriteLine($"      Packages failed      ");
    Trace.WriteLine($"              NuGet packages that failed with information retrieval");
    Trace.WriteLine($"              NuGet packages that failed with information retrieval");
    Trace.WriteLine($"              please report (open issue)");
    Trace.WriteLine($"              https://github.com/HolisticWare-Xamarin-Tools/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister/issues");
    
    foreach
    (
        (
            string nuget_id,
            string version
        )
        pr in nn.ResultsPerFile.PackagesFailed
    )
    {
        Trace.WriteLine($"              nuget_id:           {pr.nuget_id}");
        Trace.WriteLine($"                  version:        {pr.version}");
    }

    Trace.WriteLine($"      Packages found      ");
    
    foreach
        (
            KeyValuePair
                <
                    string, 
                    (
                        string nuget_id,
                        string version_current, 
                        string[] versions_upgradeable, 
                        string text_snippet_original, 
                        string text_snippet_new
                    )
                > 
                    pr in nn.ResultsPerFile.PackageReferences
            )
    {
        Trace.WriteLine($"              nuget_id:           {pr.Value.nuget_id}");
        Trace.WriteLine($"                  version:           {pr.Value.version_current}");
        // string vu = Environment.NewLine + "\t\t" + string.Join($"{Environment.NewLine}\t\t", pr.versions_upgradeable);
        // Trace.WriteLine($"  versions:        {vu}");
    }
}

stopwatch.Stop();

Trace.WriteLine($"Elapsed:       {stopwatch.Elapsed}");

return 0;