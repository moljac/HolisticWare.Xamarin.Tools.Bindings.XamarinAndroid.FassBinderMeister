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

        foreach(KeyValuePair<string, string[]> kvp in patterns_files)
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
                    new Formats.NeekerMsBuildProject().Neek(kvp.Value);
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

        return;
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
