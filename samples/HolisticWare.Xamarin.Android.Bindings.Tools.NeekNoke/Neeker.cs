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
                    this.Result 
                    new Formats.NeekerBinderatorConfig().Neek(kvp.Value);
                    break;  
                case "*.csproj":
                case "*.fsproj":
                case "*.vbproj":
                case "*.proj":
                    new Formats.NeekerMsBuildProject().Neek(kvp.Value);
                    break;
                case "directory.packages.*.props":
                case "directory.build.*.props":
                case "*.props":
                case "*.targets":
                    break;
                default:
                    throw new NotSupportedException($"Neeker.Neek: Pattern {kvp.Key} not supported");
            }
        }

        return;
    }

	public partial class ResultData
	{
		public 
			Dictionary<string, Formats.NeekerBase>
										Results
		{
			get;
			set;			
		}

	}
}
