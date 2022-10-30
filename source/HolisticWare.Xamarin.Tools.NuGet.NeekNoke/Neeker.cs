using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke;

public partial class Neeker
{
	public Neeker()
	{
		this.Result = new ResultData();

        return;
	}

	public
		ResultData
										Result
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
                    this.Result.Results[kvp.Key] = new NeekNoke.Formats.NeekerBinderatorConfig();
                    new Formats.NeekerBinderatorConfig().Neek(kvp.Value);
                    break;  
                case "*.csproj":
                case "*.fsproj":
                case "*.vbproj":
                case "*.proj":
                    this.Result.Results[kvp.Key] = new NeekNoke.Formats.NeekerMsBuildProject();
                    Dictionary      // results
                        <
                            string,                         // filename
                            (
                                string file_backup,         // filename backup
                                string content,             // content (changed, new)
                                string content_backup       // content backup
                            )
                        > result = null;
                    result = new Formats.NeekerMsBuildProject().Neek(kvp.Value);
                    results.Add(kvp.Key, result);
                    break;
                case "directory.packages.*.props":
                case "directory.build.*.props":
                case "*.props":
                case "*.targets":
                    break;
                case "global.json":
                    this.Result.Results[kvp.Key] = new NeekNoke.Formats.NeekerDotNetGlobalJSON();
                    new Formats.NeekerDotNetGlobalJSON().Neek(kvp.Value);
                    break;
                case "*.cake":
                    this.Result.Results[kvp.Key] = new NeekNoke.Formats.NeekerScriptCakeBuild();
                    new Formats.NeekerScriptCakeBuild().Neek(kvp.Value);
                    break;
                case "*.csx":
                    this.Result.Results[kvp.Key] = new NeekNoke.Formats.NeekerScriptCSharpScriptAndScriptCS();
                    new Formats.NeekerScriptCSharpScriptAndScriptCS().Neek(kvp.Value);
                    break;
                case "*.xproj":
                case "packages.config":
                    // TODO
                    break;
                default:
                    throw new NotSupportedException($"Neeker.Neek: Pattern {kvp.Key} not supported");
            }
        }

        return results;
    }

	public partial class ResultData
	{
        public ResultData()
        {
            this.Results = new Dictionary<string, Formats.NeekerBase>();

            return;
        }

		public 
			Dictionary<string, Formats.NeekerBase>
										Results
		{
			get;
			set;			
		}

	}
}
