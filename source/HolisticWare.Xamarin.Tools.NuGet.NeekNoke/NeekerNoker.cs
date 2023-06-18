using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;
using HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke;

public partial class
                                        NeekerNoker
{
    public static
        bool
                                        AllowPrereleases
    {
        get;
        set;
    } = false;

    public static 
        Action 
                                        Action
    {
        get;
        set;
    }

    public static
        string
                                        VersionDotNetSDKBand
    {
        get
        {
            return Formats.NeekerNokerDotNetWorkloadsJSON.VersionDotNetSDKBand;
        }
        set
        {
            Formats.NeekerNokerDotNetWorkloadsJSON.VersionDotNetSDKBand = value;

            return;
        }
    }

    public
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
                                        PackagesDetails
    {
        get;
        set;
    }

    public
                                        NeekerNoker
                                            (
                                            )
	{
		this.ResultsPerFormat = new Dictionary<string, ResultsPerFormat>()
        {
            {
                "MSBuild (Project Files, Property/Target Files)",
                new ResultsPerFormat()
                {
                    ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>
                    {
                        {
                            "*.csproj",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                        {
                            "*.fsproj",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                        {
                            "*.vbproj",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                        {
                            "*.xproj",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                        {
                            "*.proj",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                        {
                            "*.props",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                        {
                            "*.targets",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                    }
                }
            },
            {
                "Binderator Config",
                new ResultsPerFormat()
                {
                    ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>
                    {
                        {
                            "config.json",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                    }
                }
            },
            {
                "dotnet global.json files",
                new ResultsPerFormat()
                {
                    ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>
                    {
                        {
                            "global.json",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                    },
                }
            },
            {
                "dotnet workloads files (used: workloads.json)",
                new ResultsPerFormat()
                {
                    ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>
                    {
                        {
                            "workloads.json",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                    },
                }
            },
            {
                "Cake Build Script Files",
                new ResultsPerFormat()
                {
                    ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>
                    {
                        {
                            "*.cake",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                    },
                }
            },
            {
                "Script Files (dotnet script, csx, scriptcs)",
                new ResultsPerFormat()
                {
                    ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>
                    {
                        {
                            "*.csx",
                            new ResultsPerFilePattern()
                            {
                                ResultsPerFile = new Dictionary<string, ResultsPerFile>()
                            }
                        },
                    },
                }
            },
        };

        return;
	}

    public
        Dictionary<string, ResultsPerFormat>
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
                                                    },
                                    "."
                                );
        }


        foreach (KeyValuePair<string, string[]> kvp in patterns_files)
        {
            switch(kvp.Key)
            {
                case "*.csproj":
                case "*.fsproj":
                case "*.vbproj":
                case "*.proj":
                case "*.xproj":
                case "*.props":
                case "*.targets":
                    NeekNoke.Formats.NeekerNokerMsBuildProject f_msbuild_proj = null;
                    f_msbuild_proj = new NeekNoke.Formats.NeekerNokerMsBuildProject()
                                                                    {
                                                                        NeekNoker = this
                                                                    };
                    this.ResultsPerFormat["MSBuild (Project Files, Property/Target Files)"]
                            .ResultsPerFilePattern[kvp.Key]
                                .NeekNokeFormatter = f_msbuild_proj;
                    f_msbuild_proj.NeekNoke(kvp.Key, kvp.Value);
                    break;
                case "config.json":
                    NeekNoke.Formats.NeekerNokerBinderatorConfig f_binderator = null;
                    f_binderator = new NeekNoke.Formats.NeekerNokerBinderatorConfig()
                                                                    {
                                                                        NeekNoker = this
                                                                    };
                    this.ResultsPerFormat["Binderator Config"]
                            .ResultsPerFilePattern[kvp.Key]
                                .NeekNokeFormatter = f_binderator;
                    f_binderator.NeekNoke(kvp.Key, kvp.Value);
                    break;
                case "global.json":
                    NeekNoke.Formats.NeekerNokerDotNetGlobalJSON f_global_json = null;
                    f_global_json = new NeekNoke.Formats.NeekerNokerDotNetGlobalJSON()
                                                                    {
                                                                        NeekNoker = this
                                                                    };
                    this.ResultsPerFormat["dotnet global.json files"]
                            .ResultsPerFilePattern[kvp.Key]
                                .NeekNokeFormatter = f_global_json;
                    f_global_json.NeekNoke(kvp.Key, kvp.Value);
                    break;
                case "workloads.json":
                    NeekNoke.Formats.NeekerNokerDotNetWorkloadsJSON f_workloads_json = null;
                    f_workloads_json = new NeekNoke.Formats.NeekerNokerDotNetWorkloadsJSON()
                                                                    {
                                                                        NeekNoker = this
                                                                    };
                    this.ResultsPerFormat["dotnet workloads files (used: workloads.json)"]
                            .ResultsPerFilePattern[kvp.Key]
                                .NeekNokeFormatter = f_workloads_json;
                    f_workloads_json.NeekNoke(kvp.Key, kvp.Value);
                    break;
                    
                case "*.cake":
                    NeekNoke.Formats.NeekerNokerScriptCakeBuild f_cake = null;
                    f_cake = new NeekNoke.Formats.NeekerNokerScriptCakeBuild()
                                                                    {
                                                                        NeekNoker = this
                                                                    };
                    this.ResultsPerFormat["Cake Build Script Files"]
                            .ResultsPerFilePattern[kvp.Key]
                                .NeekNokeFormatter = f_cake;
                        f_cake.NeekNoke(kvp.Key, kvp.Value);
                    break;
                case "*.csx":
                    NeekNoke.Formats.NeekerNokerScriptCSharpScriptAndScriptCS f_csx = null;
                    f_csx = new NeekNoke.Formats.NeekerNokerScriptCSharpScriptAndScriptCS()
                                                                    {
                                                                        NeekNoker = this
                                                                    };
                    this.ResultsPerFormat["Script Files (dotnet script, csx, scriptcs)"]
                            .ResultsPerFilePattern[kvp.Key]
                                .NeekNokeFormatter = f_csx;
                    f_csx.NeekNoke(kvp.Key, kvp.Value);
                    break;
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
                                            )
    {
        List
            <
                (
                    string nuget_id,
                    string version_current,
                    string[] versions_upgradeable
                )
            >
            package_nuget_references = new List
                                                <
                                                    (
                                                        string nuget_id,
                                                        string version_current,
                                                        string[] versions_upgradeable
                                                    )
                                                >
                                                ();

        foreach (KeyValuePair<string, ResultsPerFormat> format_rpf in this.ResultsPerFormat)
        {
            string format = format_rpf.Key;

            foreach (KeyValuePair<string, ResultsPerFilePattern> pattern_rpfp in format_rpf.Value.ResultsPerFilePattern)
            {
                string pattern = pattern_rpfp.Key;
                ResultsPerFilePattern rpfp = pattern_rpfp.Value;

                foreach (KeyValuePair<string, ResultsPerFile> file_rpf in rpfp.ResultsPerFile)
                {
                    string file = file_rpf.Key;
                    ResultsPerFile rpf = file_rpf.Value;

                    foreach(var pr in rpf.PackageReferences)
                    {
                        package_nuget_references.Add
                                                    (
                                                        (
                                                            nuget_id: pr.nuget_id,
                                                            version_current: pr.version_current,
                                                            versions_upgradeable: pr.versions_upgradeable
                                                        )
                                                    );
                    }
                }

            }
        }

        return;
    }
    
    public
        void
                                        Dump
                                            (
                                            )
    {
        Trace.WriteLine(new string('#', Console.WindowWidth));
        Trace.WriteLine($"grepping files for NuGet packages ...");
        string directory = global::Core.IO.Directory.Current["System.Environment.CurrentDirectory"];
        Trace.WriteLine($"   DirectoryCurrent = {directory}");

        foreach (KeyValuePair<string, ResultsPerFormat> result_per_format in this.ResultsPerFormat)
        {
            string format = result_per_format.Key;
            ResultsPerFormat rp_format = result_per_format.Value;

            Trace.WriteLine($"format:      {format}");

            foreach (var rp_pattern in rp_format.ResultsPerFilePattern)
            {
                string pattern = rp_pattern.Key;
                ResultsPerFilePattern rp_file_pattern = rp_pattern.Value;

                Trace.WriteLine($"  pattern:      {pattern}");
                Trace.WriteLine($"      files:    {rp_file_pattern.ResultsPerFile.Count}");

                foreach (var rp_file in rp_file_pattern.ResultsPerFile)
                {
                    string file = rp_file.Key;
                    ResultsPerFile rpf = rp_file.Value;

                    Trace.WriteLine($"      file:       {file}");
                    Trace.WriteLine($"                      {rpf.File}");

                    Trace.WriteLine($"          package references:");
                    foreach (var pr in rpf.PackageReferences)
                    {
                        Trace.WriteLine($"              nuget_id:   {pr.nuget_id}");
                        Trace.WriteLine($"                  version:   {pr.version_current}");
                        if (pr.versions_upgradeable != null)
                        {
                            Trace.WriteLine($"                  versions_upgradeable:");
                            
                            foreach (string vu in pr.versions_upgradeable)
                            {
                                Trace.WriteLine($"                      {vu}");
                            }
                        }
                    }
                    
                    Trace.WriteLine($"          packages failed:");
                    foreach (var pf in rpf.PackagesFailed)
                    {
                        Trace.WriteLine($"              nuget_id:   {pf.nuget_id}");
                        Trace.WriteLine($"                  version:   {pf.version_current}");
                    }
                }
            }
        }

        return;
    }

    public
        Dictionary<string, PackageAppearanceData>
                                        PackageDataCleanup
                                            (
                                            )
    {
        Dictionary<string, PackageAppearanceData> packages_found = null;

        packages_found = new Dictionary<string, PackageAppearanceData>();

        foreach (KeyValuePair<string, ResultsPerFormat> result_per_format in this.ResultsPerFormat)
        {
            ResultsPerFormat rp_format = result_per_format.Value;

            foreach (var rp_pattern in rp_format.ResultsPerFilePattern)
            {
                ResultsPerFilePattern rp_file_pattern = rp_pattern.Value;

                foreach (var rp_file in rp_file_pattern.ResultsPerFile)
                {
                    string file = rp_file.Key;
                    ResultsPerFile rpf = rp_file.Value;

                    foreach (var pr in rpf.PackageReferences)
                    {
                        if (pr.versions_upgradeable != null)
                        {                            
                            foreach (string vu in pr.versions_upgradeable)
                            {
                            }
                        }
                    }

                    foreach (var pf in rpf.PackagesFailed)
                    {
                    }
                }
            }
        }

        //foreach (KeyValuePair<string, NeekerNokerBase> nnb in this.ResultsPerFormat.ResultsNeekerNoker)
        //{
        //    string pattern = nnb.Key;
        //    NeekerNokerBase nn = nnb.Value;

        //    Trace.WriteLine($"pattern:      {pattern}");

        //    foreach (KeyValuePair<string, ResultsPerFile> rpf in nn.ResultsPerFormat.ResultsPerFile)
        //    {
        //        string file = rpf.Key;

        //        Trace.WriteLine($"  file:      {file}");

        // foreach
        // (
        //     (
        //         string nuget_id,
        //         string version_current,
        //         string[] versions_upgradeable,
        //         string text_snippet_original,
        //         string text_snippet_new
        //     )
        //         pr in rpf.Value.PackageReferences
        // )
        // {
        //     string ni = pr.nuget_id;
        //
        //     if (!packages_found.ContainsKey(ni))
        //     {
        //         packages_found.Add(pr.nuget_id, pr.version_current);
        //     }
        // }
        //    }
        //}

        return packages_found;
    }

    public
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
                                        PackageDataFetch
                                            (
                                                Dictionary<string, PackageAppearanceData> packages
                                            )
    {
        Dictionary
            <
                string,                 // nuget_id
                (
                    string version_current,
                    string version_latest,
                    List<string> versions_upgradeable,
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
                                            List<string> versions_upgradeable,
                                            NuGetPackage package_details,
                                            bool failed
                                        )
                                    >
                                        ();

        foreach (KeyValuePair<string, PackageAppearanceData> kvp in packages)
        {
            packages_data.Add
                            (
                                kvp.Key,
                                (
                                    version_current: null,
                                    version_latest: null,
                                    versions_upgradeable: null,
                                    package_details: null,
                                    failed: false
                                )
                            );
        }

        Parallel.ForEach
                    (
                        packages,
                        nuget_id_x_appearance =>
                        {
                            string nuget_id = nuget_id_x_appearance.Key;
                            PackageAppearanceData appearance_data = nuget_id_x_appearance.Value;
            
                            global::HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Versions.Root v = null;

                            bool failed = false;
                            
                            try
                            {
                                v = NuGetPackage.Utilities
                                                    .GetPackageVersionsFromIndexAsync(nuget_id)
                                                    .Result;

                                if (NeekerNoker.AllowPrereleases == false)
                                {
                                    List<string> versions_stable = new List<string>();
                                    foreach (string ver in v.versions)
                                    {
                                        if (ver.Contains("+"))
                                        {
                                            continue;
                                        }
                                        if (ver.Contains("-"))
                                        {
                                            continue;
                                        }
                                        versions_stable.Add(ver);
                                    }

                                    v.versions = versions_stable;
                                }
                            }
                            catch (Exception exc)
                            {
                                failed = true;
                                packages_data[nuget_id_x_appearance.Key] =
                                                            (
                                                                version_current: appearance_data.VersionCurrent,
                                                                version_latest: appearance_data.VersionLatest,
                                                                versions_upgradeable: appearance_data.VersionsUpgradeable,
                                                                package_details: null,
                                                                failed: failed
                                                            );
                            }

                            NuGetPackage np = null;
                            
                            try
                            {
                                np = NuGetPackage
                                                .Utilities
                                                    .GetNuGetPackageFromRegistrationAsync(nuget_id_x_appearance.Key)
                                                    .Result
                                                    ;

                                string version_latest = np.VersionTextual;
                                List<string> versions_upgradeable = np.VersionsTextual;
                                
                                packages_data[nuget_id_x_appearance.Key] = 
                                                            (
                                                                version_current: appearance_data.VersionCurrent,
                                                                version_latest: version_latest,
                                                                versions_upgradeable: versions_upgradeable,
                                                                package_details: np,
                                                                failed: failed
                                                            );
                            }
                            catch (Exception exc)
                            {
                                failed = true;
                                packages_data[nuget_id_x_appearance.Key] = 
                                                                        (
                                                                            version_current: appearance_data.VersionCurrent,
                                                                            version_latest: null,
                                                                            versions_upgradeable: null,
                                                                            package_details: null,
                                                                            failed: failed
                                                                        );
                            }
                        }
                );

        this.PackagesDetails = packages_data;

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
        if (string.IsNullOrEmpty(file))
        {
            return;
        }

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
