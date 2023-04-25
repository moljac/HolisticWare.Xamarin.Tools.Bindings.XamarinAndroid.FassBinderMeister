//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool nuget:?package=Cake.CoreCLR

#addin nuget:?package=Newtonsoft.Json&version=13.0.2
#addin nuget:?package=Newtonsoft.Json.Schema&version=3.0.4&loaddependencies=true
#addin nuget:?package=NJsonSchema&version=10.8.0&loaddependencies=true
#addin nuget:?package=JsonSchema.Net&version=4.0.0-beta2&loaddependencies=true
#addin nuget:?package=Spectre.Console&version=0.45.1-preview.0.46&loaddependencies=true


#addin nuget:?package=HolisticWare.Xamarin.Tools.ComponentGovernance&version=0.0.1.2
#addin nuget:?package=HolisticWare.Core.Net.HTTP&version=0.0.1
#addin nuget:?package=HolisticWare.Core.IO&version=0.0.1

using System.Collections.Generic;

using Spectre.Console;

using HolisticWare.Xamarin.Tools.ComponentGovernance;

var TARGET = Argument ("t", Argument ("target", "Default"));

Newtonsoft.Json.Linq.JArray binderator_json_array = null;

List<(string, string, string, string)> mappings_artifact_nuget = null;
Dictionary<string, string> Licenses = new Dictionary<string, string>();

// modifying default method for licenses
Manifest.Defaults.VersionBasedOnFullyQualifiedArtifactIdDelegate = delegate(string fully_qualified_artifact_id)
{
    if
        (
            fully_qualified_artifact_id.StartsWith("androidx")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.material")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.firebase")
            ||
            fully_qualified_artifact_id.StartsWith("org.jetbrains.kotlin")
            ||
            fully_qualified_artifact_id.StartsWith("org.jetbrains.kotlinx")
            ||
            fully_qualified_artifact_id.StartsWith("org.jetbrains")
            ||
            fully_qualified_artifact_id.StartsWith("com.squareup")
            ||
            fully_qualified_artifact_id.StartsWith("io.grpc")
            ||
            fully_qualified_artifact_id.StartsWith("io.reactivex.rxjava3")
            ||
            fully_qualified_artifact_id.StartsWith("io.reactivex.rxjava2")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.j2objc")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.guava")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.auto.value")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.code.gson")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.crypto.tink")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android:annotations")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.datatransport")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.code.findbugs")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.dagger")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.errorprone")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.zxing")
            ||
            fully_qualified_artifact_id.StartsWith("io.opencensus")
            ||
            fully_qualified_artifact_id.StartsWith("io.perfmark")
            ||
            fully_qualified_artifact_id.StartsWith("javax.inject")
            ||
            fully_qualified_artifact_id.StartsWith("org.tensorflow")
            ||
            fully_qualified_artifact_id.StartsWith("com.android.volley")
        )
    {
        const string l = "The Apache Software License, Version 2.0";
        const string u = "https://www.apache.org/licenses/LICENSE-2.0.txt";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("org.checkerframework")
            ||
            fully_qualified_artifact_id.StartsWith("org.codehaus.mojo")            
        )
    {
        const string l = "MIT";
        const string u = "http://opensource.org/licenses/MIT";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("com.github.bumptech.glide")
        )
    {
        const string l = "The Apache Software License, Version 2.0 AND Simplified BSD License";
        const string u = "https://www.apache.org/licenses/LICENSE-2.0.txt;http://www.opensource.org/licenses/bsd-license";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("org.reactivestreams")
        )
    {
        const string l = "MIT-0";
        const string u = "https://spdx.org/licenses/MIT-0.html";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.gms")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.odml")
            ||
            fully_qualified_artifact_id.StartsWith("com.google.android.ump")
        )
    {
        const string l = "Android Software Development Kit License";
        const string u = "https://developer.android.com/studio/terms";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("org.chromium.net")
        )
    {
        const string l = "Chromium and built-in dependencies";
        const string u = "https://storage.cloud.google.com/chromium-cronet/android/72.0.3626.96/Release/cronet/LICENSE";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("com.google.mlkit")
        )
    {
        const string l = "ML Kit Terms of Service";
        const string u = "https://developers.google.com/ml-kit/terms";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.play")
        )
    {
        const string l = "Play Core Software Development Kit Terms of Service";
        const string u = "https://developer.android.com/guide/playcore#license";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }

    if
        (
            fully_qualified_artifact_id.StartsWith("com.google.android.libraries.places")
        )
    {
        const string l = "Google Maps Platform Terms of Service";
        const string u = "https://cloud.google.com/maps-platform/terms/";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }
    
    if
        (
            fully_qualified_artifact_id.StartsWith("com.google.protobuf")
        )
    {
        const string l = "BSD 2 Clause AND BSD 3 Clause";
        const string u = "https://opensource.org/licenses/BSD-2-Clause;https://opensource.org/licenses/BSD-3-Clause;";

        if (!Licenses.ContainsKey(l))
        {
            Licenses.Add(l, u);
        }

        return l;
    }


    return null;
};


Task ("mappings-artifact-nuget")
    .Does
    (
        () =>
        {
            Manifest manifest = new Manifest();
            string dump;

            using (StreamReader reader = System.IO.File.OpenText(@"./config.ax.json"))
            {
                Newtonsoft.Json.JsonTextReader jtr = new Newtonsoft.Json.JsonTextReader(reader);
                binderator_json_array = (Newtonsoft.Json.Linq.JArray) Newtonsoft.Json.Linq.JToken.ReadFrom(jtr);
            }

            mappings_artifact_nuget = new List<(string, string, string, string)>();

            foreach(Newtonsoft.Json.Linq.JObject jo in binderator_json_array[0]["artifacts"])
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
            dump = string.Join($",{Environment.NewLine}", mappings_artifact_nuget);
            dump = dump.Replace("(","(\"");
            dump = dump.Replace(")","\")");
            dump = dump.Replace(", ","\", \"");
            EnsureDirectoryExists("./output/");
			System.IO.File.WriteAllText($"./output/mappings-artifact-nuget.md", dump);


            manifest.MappingMavenArtifact2NuGetPackage = mappings_artifact_nuget;

            Console.WriteLine($"Saving ComponetGovernanceManifest cgmanifest.ax.json...");
            manifest.Save("./cgmanifest.ax.json");



            using (StreamReader reader = System.IO.File.OpenText(@"./config.gps-fb-mlkit.json"))
            {
                Newtonsoft.Json.JsonTextReader jtr = new Newtonsoft.Json.JsonTextReader(reader);
                binderator_json_array = (Newtonsoft.Json.Linq.JArray) Newtonsoft.Json.Linq.JToken.ReadFrom(jtr);
            }

            mappings_artifact_nuget = new List<(string, string, string, string)>();

            foreach(Newtonsoft.Json.Linq.JObject jo in binderator_json_array[0]["artifacts"])
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
            dump = string.Join($",{Environment.NewLine}", mappings_artifact_nuget);
            dump = dump.Replace("(","(\"");
            dump = dump.Replace(")","\")");
            dump = dump.Replace(", ","\", \"");
            EnsureDirectoryExists("./output/");
			System.IO.File.WriteAllText($"./output/mappings-artifact-nuget.md", dump);


            manifest.MappingMavenArtifact2NuGetPackage = mappings_artifact_nuget;

            Console.WriteLine($"Saving ComponetGovernanceManifest cgmanifest.gps-fb-mlkit.json...");
            manifest.Save("./cgmanifest.gps-fb-mlkit.json");

            return;
        }
    );

Task ("Default")
    .IsDependentOn ("mappings-artifact-nuget")
    ;

var table = new Table()
                    .RoundedBorder()
                    .AddColumn("📁 file name")
                    .AddColumn("🚨 errors")
                    ;
string[] files = new[] 
                    { 
                        "./cgmanifest.ax.json", 
                        "./cgmanifest.gps-fb-mlkit.json",
                    };

foreach (string file in files)
{
    string text = await System.IO.File.ReadAllTextAsync(file);
    Newtonsoft.Json.Linq.JToken json = Newtonsoft.Json.Linq.JToken.Parse(text);
    
    // use the schema on the json model
    string jsonSchema = json["$schema"]?.ToString();
    NJsonSchema.JsonSchema schema = jsonSchema switch 
                                                {
                                                    {Length: > 0} when jsonSchema.StartsWith("http") 
                                                        => 
                                                        await NJsonSchema.JsonSchema.FromUrlAsync(jsonSchema),
                                                    {Length: > 0} 
                                                        =>
                                                        await NJsonSchema.JsonSchema.FromFileAsync(jsonSchema),
                                                    _ => null
                                                };

    if (schema is null)
    {
        table.AddRow(file, "[purple]unavailable $schema[/]");
        continue;
    }
    
    ICollection<NJsonSchema.Validation.ValidationError> errors = schema.Validate(json);
    string results = errors.Any()
        ? 
            $"‣ {errors.Count} total errors\n" 
            +
            string.Join
                    (
                        "", 
                        errors
                        .Select
                            (
                                e 
                                => 
                                    $"  ‣ [red]{e}[/] at " 
                                    +
                                    $"[yellow]{e.LineNumber}:{e.LinePosition}[/]\n"
                            )
                    )
        : 
            "[green]✔[/] [lime]looks good![/]"
        ;

    Information(file);
    Information(results);
    // table.AddRow(file, results);
}

AnsiConsole.Render(table);

// string verification_repo_url_git = "https://github.com/JamieMagee/verify-cgmanifest.git";
// string verification_repo_url_zip = "https://github.com/JamieMagee/verify-cgmanifest/archive/refs/heads/main.zip";
// 
// DownloadFile(verification_repo_url_zip, "verification_repo_url.zip");
// Unzip("verification_repo_url.zip", "./verification_repo_url");

// CopyFile("cgmanifest.ax.json", "./verification_repo_url/cgmanifest.json"); 
// StartProcess("cd", "./verification_repo_url");
// StartProcess("pwd");
// StartProcess("ll", "./");
// StartProcess("npm", "install");
// StartProcess("npm", "verify");
// StartProcess("cd", "../");

// CopyFile("cgmanifest.gps-fb-mlkit.json", "./verification_repo_url/cgmanifest.json"); 
// StartProcess("cd", "./verification_repo_url");
// StartProcess("npm", "install");
// StartProcess("npm", "verify");
// StartProcess("cd", "../");

// DeleteDirectory
//         (
//             "./verification_repo_url",
//             new DeleteDirectorySettings 
//             {
//                 Recursive = true,
//                 Force = true
//             }
//         );

RunTarget (TARGET);
