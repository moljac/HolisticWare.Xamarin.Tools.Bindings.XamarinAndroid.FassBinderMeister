// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;

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

Console.WriteLine($"{about}");

string[] patterns = new string[]
{
    "*.csproj",
    "directory.build.*.props",
    "directory.packages.*.props",
    "*.props",
    "*.targets",
    "*.fsproj",
    "*.vbproj",
    "*.proj",
};

Dictionary<string, string[]> patterns_files = new Dictionary<string, string[]>();

foreach (string pattern in patterns)
{
    patterns_files.Add(pattern, new string[] { });
}

Parallel.ForEach
            (
                patterns,
                pattern =>
                {
                    string[] files_for_pattern = System.IO.Directory.GetFiles
                                                                        (
                                                                            ".",
                                                                            pattern,
                                                                            System.IO.SearchOption.AllDirectories
                                                                        );

                    patterns_files[pattern] = files_for_pattern;
                }
            );


foreach (KeyValuePair<string, string[]> pattern in patterns_files)
{
    Console.WriteLine($"file {pattern.Key}");

    foreach (string p in pattern.Value)
    {
        Console.WriteLine($"        {p}");
    }
}

//Console.ReadLine();
