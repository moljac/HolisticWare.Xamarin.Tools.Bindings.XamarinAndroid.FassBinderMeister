//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool nuget:?package=Cake.CoreCLR

#addin nuget:?package=Newtonsoft.Json&version=12.0.3

#addin nuget:?package=HolisticWare.Xamarin.Tools.ComponentGovernance&version=0.0.1.1
#addin nuget:?package=HolisticWare.Core.Net.HTTP&version=0.0.1
#addin nuget:?package=HolisticWare.Core.IO&version=0.0.1

using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using HolisticWare.Xamarin.Tools.ComponentGovernance;

var TARGET = Argument ("t", Argument ("target", "Default"));

JArray binderator_json_array = null;

List<(string, string, string, string)> mappings_artifact_nuget = new List<(string, string, string, string)>();


Task ("mappings-artifact-nuget")
    .Does
    (
        () =>
        {
            using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
            {
                JsonTextReader jtr = new JsonTextReader(reader);
                binderator_json_array = (JArray)JToken.ReadFrom(jtr);
            }

            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                bool? dependency_only = (bool?) jo["dependencyOnly"];
                if ( dependency_only == true)
                {
                    continue;
                }

                string group_id  	= (string) jo["groupId"];
                string artifact_id  = (string) jo["artifactId"];
                string artifact_v   = (string) jo["version"];
                string nuget_id  	= (string) jo["nugetId"];
                string nuget_v  	= (string) jo["nugetVersion"];

                mappings_artifact_nuget.Add
                (
                    (
                        $"{group_id}:{artifact_id}",
                        $"{artifact_v}",
                        $"{nuget_id}",
                        $"{nuget_v}"
                    )
                );
            }

            // dump for C# tuple initialization
            string dump = string.Join($",{Environment.NewLine}", mappings_artifact_nuget);
            dump = dump.Replace("(","(\"");
            dump = dump.Replace(")","\")");
            dump = dump.Replace(", ","\", \"");
            EnsureDirectoryExists("./output/");
			System.IO.File.WriteAllText($"./output/mappings-artifact-nuget.md", dump);


            Manifest manifest = new Manifest();

            manifest.MappingMavenArtifact2NuGetPackage = mappings_artifact_nuget;

            Console.WriteLine($"Saving ComponetGovernanceManifest cgmanifest.json...");
            manifest.Save("./cgmanifest.json");

            return;
        }
    );

Task ("Default")
    .IsDependentOn ("mappings-artifact-nuget")
    ;

RunTarget (TARGET);
