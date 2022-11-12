using System;
using System.Collections.Generic;
using System.Diagnostics;

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
		this.ResultsPerPattern = new ResultsPerPattern();

        return;
	}

    public
        ResultsPerPattern
                                        ResultsPerPattern
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
                                        NeekNoke
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
                    this.ResultsPerPattern.Results[kvp.Key] = f_binderator;
                    f_binderator.NeekNoke(kvp.Value);
                    break;
                case "*.csproj":
                case "*.fsproj":
                case "*.vbproj":
                case "*.proj":
                    NeekNoke.Formats.NeekerNokerMsBuildProject f_msbuild_proj = null;
                    f_msbuild_proj = new NeekNoke.Formats.NeekerNokerMsBuildProject();
                    this.ResultsPerPattern.Results[kvp.Key] = f_msbuild_proj;
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
                    this.ResultsPerPattern.Results[kvp.Key] = f_global_json;
                    f_global_json.NeekNoke(kvp.Value);
                    break;
                case "*.cake":
                    NeekNoke.Formats.NeekerNokerScriptCakeBuild f_cake = null;
                    f_cake = new NeekNoke.Formats.NeekerNokerScriptCakeBuild();
                    this.ResultsPerPattern.Results[kvp.Key] = f_cake;
                    f_cake.NeekNoke(kvp.Value);
                    break;
                case "*.csx":
                    NeekNoke.Formats.NeekerNokerScriptCSharpScriptAndScriptCS f_csx = null;
                    f_csx = new NeekNoke.Formats.NeekerNokerScriptCSharpScriptAndScriptCS();
                    this.ResultsPerPattern.Results[kvp.Key] = f_csx;
                    f_csx.NeekNoke(kvp.Value);
                    break;
                case "*.xproj":
                case "packages.config":
                    // TODO
                    break;
                default:
                    throw new NotSupportedException($"Neeker.NeekNoke: Pattern {kvp.Key} not supported");
            }
        }

        return results;
    }
}
