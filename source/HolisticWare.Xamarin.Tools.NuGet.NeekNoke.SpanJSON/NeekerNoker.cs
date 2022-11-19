using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;
using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke;

public partial class NeekerNoker
{
    public static 
        Action 
                                        Action
    {
        get;
        set;
    }

    public NeekerNoker()
	{
		this.ResultsPerFormat = new ResultsPerFormat();

        return;
	}

    public
        ResultsPerFormat
                                        ResultsPerFormat
    {
        get;
        set;
    }

	public 
		Dictionary<string, string[]>
										Harvest
										(
											string[] patterns,
											string location = "."
										)
    {
        return new Scraper().Harvest(patterns, location);
    }

	public
        void
                                        Neek
                                        (
                                            Dictionary<string, string[]> patterns_files
										)
    {
        if 
            (
                null == patterns_files
                ||
                patterns_files.Count == 0
            )
        {
            patterns_files = Harvest
                                (
                                    new string[]
                                                    {
                                                        "*.csproj",
                                                        "config.json",
                                                        "directory.build.*.props",
                                                        "directory.packages.*.props",
                                                        "*.props",
                                                        "*.targets",
                                                        "*.fsproj",
                                                        "*.vbproj",
                                                        "*.proj",
                                                    },
                                    "."
                                );
        }

        Dictionary
            <
                string,         // pattern
                Dictionary      // results
                        <
                            string,                         // filename
                            (
                                string file_backup,         // filename backup
                                string content,             // content (changed, new)
                                string content_backup       // content backu
                            )
                        >
            >
            results = null;

        results = new Dictionary
                            <
                                string,
                                Dictionary
                                    <
                                        string,
                                        (
                                            string file_backup,
                                            string content,
                                            string content_backup
                                        )
                                    >
                            >();

        foreach (KeyValuePair<string, string[]> kvp in patterns_files)
        {
            switch(kvp.Key)
            {
                case "config.json":
                    NeekNoke.Formats.NeekerNokerBinderatorConfig f_binderator = null;
                    f_binderator = new NeekNoke.Formats.NeekerNokerBinderatorConfig();
                    this.ResultsPerFormat.ResultsNeekerNoker[kvp.Key] = f_binderator;
                    f_binderator.NeekNoke(kvp.Value);
                    break;
                case "*.csproj":
                case "*.fsproj":
                case "*.vbproj":
                case "*.proj":
                    NeekNoke.Formats.NeekerNokerMsBuildProject f_msbuild_proj = null;
                    f_msbuild_proj = new NeekNoke.Formats.NeekerNokerMsBuildProject();
                    this.ResultsPerFormat.ResultsNeekerNoker[kvp.Key] = f_msbuild_proj;
                    f_msbuild_proj.NeekNoke(kvp.Value);
                    break;
                case "directory.packages.*.props":
                case "directory.build.*.props":
                case "*.props":
                case "*.targets":
                    break;
                case "global.json":
                    NeekNoke.Formats.NeekerNokerDotNetGlobalJSON f_global_json = null;
                    f_global_json = new NeekNoke.Formats.NeekerNokerDotNetGlobalJSON();
                    this.ResultsPerFormat.ResultsNeekerNoker[kvp.Key] = f_global_json;
                    f_global_json.NeekNoke(kvp.Value);
                    break;
                case "*.cake":
                    NeekNoke.Formats.NeekerNokerScriptCakeBuild f_cake = null;
                    f_cake = new NeekNoke.Formats.NeekerNokerScriptCakeBuild();
                    this.ResultsPerFormat.ResultsNeekerNoker[kvp.Key] = f_cake;
                    f_cake.NeekNoke(kvp.Value);
                    break;
                case "*.csx":
                    NeekNoke.Formats.NeekerNokerScriptCSharpScriptAndScriptCS f_csx = null;
                    f_csx = new NeekNoke.Formats.NeekerNokerScriptCSharpScriptAndScriptCS();
                    this.ResultsPerFormat.ResultsNeekerNoker[kvp.Key] = f_csx;
                    f_csx.NeekNoke(kvp.Value);
                    break;
                case "*.xproj":
                case "packages.config":
                    // TODO
                    break;
                default:
                    throw new NotSupportedException($"Neeker.Neek: Pattern {kvp.Key} not supported");
            }
        }

        return;
    }

    public
        void
                                        Noke
                                            (
                                                Dictionary<string, string[]> patterns_files
                                            )
    {
        return;
    }
    
    public
        void
                                        Dump
                                            (
                                            )
    {
        foreach (KeyValuePair<string, NeekerNokerBase> nnb in this.ResultsPerFormat.ResultsNeekerNoker)
        {
            string pattern = nnb.Key;
            NeekerNokerBase nn = nnb.Value;

            Trace.WriteLine($"pattern:      {pattern}");

            foreach (KeyValuePair<string, ResultsPerFile> rpf in nn.ResultsPerFormat.ResultsPerFile)
            {
                string file = rpf.Key;

                Trace.WriteLine($"  file:      {file}");

                if (NeekerNoker.Action == Action.Noke)
                {
                    foreach
                    (
                        (
                            string file_backup,
                            string content,
                            string content_backup
                        )
                            kv_log in rpf.Value.Log
                    )
                    {
                        Trace.WriteLine($"      file_backup:      {kv_log.file_backup}");
                    }
                }

                Trace.WriteLine($"      Packages failed      ");
                Trace.WriteLine($"              NuGet packages that failed with information retrieval");
                Trace.WriteLine($"              please report (open issue)");
                Trace.WriteLine($"              https://github.com/HolisticWare-Xamarin-Tools/HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister/issues");
                foreach ((string nuget_id, string version_current) pf in rpf.Value.PackagesFailed)
                {
                    Trace.WriteLine($"              nuget_id    :           {pf.nuget_id}");
                    Trace.WriteLine($"                  version :           {pf.version_current}");
                }

                Trace.WriteLine($"      Packages found      ");

                foreach
                (
                    (
                        string nuget_id,
                        string version_current,
                        string[] versions_upgradeable,
                        string text_snippet_original,
                        string text_snippet_new
                    )
                        pr in rpf.Value.PackageReferences
                )
                {
                    Trace.WriteLine($"              nuget_id:           {pr.nuget_id}");
                    Trace.WriteLine($"                  version:           {pr.version_current}");
                    // string vu = Environment.NewLine + "\t\t" + string.Join($"{Environment.NewLine}\t\t", pr.versions_upgradeable);
                    // Trace.WriteLine($"  versions:        {vu}");
                }
            }
        }

        return;
    }

    public
        Dictionary<string, string>
                                        PackageDataCleanup
                                            (
                                            )
    {
        Dictionary<string, string> packages_found = new Dictionary<string, string>();

        foreach (KeyValuePair<string, NeekerNokerBase> nnb in this.ResultsPerFormat.ResultsNeekerNoker)
        {
            string pattern = nnb.Key;
            NeekerNokerBase nn = nnb.Value;

            Trace.WriteLine($"pattern:      {pattern}");

            foreach (KeyValuePair<string, ResultsPerFile> rpf in nn.ResultsPerFormat.ResultsPerFile)
            {
                string file = rpf.Key;

                Trace.WriteLine($"  file:      {file}");

                foreach
                (
                    (
                        string nuget_id,
                        string version_current,
                        string[] versions_upgradeable,
                        string text_snippet_original,
                        string text_snippet_new
                    )
                        pr in rpf.Value.PackageReferences
                )
                {
                    string ni = pr.nuget_id;

                    if (!packages_found.ContainsKey(ni))
                    {
                        packages_found.Add(pr.nuget_id, pr.version_current);
                    }
                }
            }
        }

        return packages_found;
    }

    public
        Dictionary
                <
                    string, // nuget_id
                    (
                        string version_current,
                        string version_latest,
                        string[] versions_upgradeable,
                        NuGetPackage package_details,
                        bool failed
                    )
                >
                                        PackageDataFetch
                                            (
                                                Dictionary<string, string> packages
                                            )
    {
        Dictionary
            <
                string,                 // nuget_id
                (
                    string version_current,
                    string version_latest,
                    string[] versions_upgradeable,
                    NuGetPackage package_details,
                    bool failed
                )
            >
                packages_data = null;

        packages_data = new Dictionary
                                    <
                                        string, // nuget_id
                                        (
                                            string version_current,
                                            string version_latest,
                                            string[] versions_upgradeable,
                                            NuGetPackage package_details,
                                            bool failed
                                        )
                                    >
                                        ();

        foreach (KeyValuePair<string, string> kvp in packages)
        {
            packages_data.Add
                            (
                                kvp.Key,
                                (
                                    version_current: null,
                                    version_latest: null,
                                    versions_upgradeable: null,
                                    NuGetPackage: null,
                                    failed: false
                                )
                            );
        }
        Parallel.ForEach
                    (
                        packages,
                         nuget_id_x_version =>
                        {
                            string nuget_id = nuget_id_x_version.Key;
                            string version = nuget_id_x_version.Value;
            
                            global::HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root v = null;

                            bool failed = false;
                            try
                            {
                                v = NuGetPackage.Utilities
                                                    .GetPackageVersionsFromIndexAsync(nuget_id)
                                                    .Result;
                            }
                            catch (Exception exc)
                            {
                                failed = true;
                            }
                            
                            NuGetPackage np = null;
                            
                            try
                            {
                                np = NuGetPackage
                                                .Utilities
                                                    .GetNuGetPackageFromRegistrationAsync(nuget_id_x_version.Key)
                                                    .Result
                                                    ;

                                string version_latest = (v.versions.ToArray())[v.versions.Count - 1];
                                string[] versions_upgradeable = v.versions.ToArray();
                                
                                packages_data[nuget_id_x_version.Key] = 
                                                                        (
                                                                            version_current: version,
                                                                            version_latest: version_latest,
                                                                            versions_upgradeable: versions_upgradeable,
                                                                            NuGetPackage: np,
                                                                            failed: failed
                                                                        );
                            }
                            catch (Exception exc)
                            {
                                failed = true;
                                packages_data[nuget_id_x_version.Key] = 
                                                                        (
                                                                            version_current: version,
                                                                            version_latest: null,
                                                                            versions_upgradeable: null,
                                                                            NuGetPackage: null,
                                                                            failed: failed
                                                                        );
                            }
                        }
                );

        return packages_data;
    }

    public
        void
                                        DumpTiming
                                            (
                                                string file,
                                                Stopwatch stopwatch
                                            )
    {
        string log_data = null;

        #if DEBUG
        log_data = $"               {DateTime.Now.ToString("yyyyMMdd-HHmmss")},{stopwatch.Elapsed},Debug";
        Trace.WriteLine($"Elapsed:");
        Trace.WriteLine($"                      {log_data},");
        #else
        log_data = $"               {DateTime.Now.ToString("yyyyMMdd-HHmmss")},{stopwatch.Elapsed},Release";
        Trace.WriteLine($"Elapsed:");
        Trace.WriteLine($"                      {log_data},");
        #endif

        string dir_current = System.IO.Directory.GetCurrentDirectory();
        string filename =
                            file
                            // $"{dir_current}/timings-System.Text.JSON.csv"
                            ;
        string[] lines = System.IO.File.ReadAllLines(filename);
        lines[0] = log_data + Environment.NewLine + lines[0];
        System.IO.File.WriteAllLines(filename, lines);

        return;
    }
}
