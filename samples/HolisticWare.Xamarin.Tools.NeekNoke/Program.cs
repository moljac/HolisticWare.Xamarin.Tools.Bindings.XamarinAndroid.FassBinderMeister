// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;
using System.Diagnostics;
using HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke;

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


moljac AKA miljenko mel cvjetko 
https://github.com/moljac
";


Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
Trace.AutoFlush = true;

Trace.WriteLine($"{about}");

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
Console.Clear();

new Neeker().Neek(patterns_files);

//Console.ReadLine();
