// #tool "dotnet:?package=dotnet-xscgen"
// #tool "dotnet:?package=ddotnet-xdt"


// https://api.met.no/weatherapi/locationforecast/2.0/schema


EnsureDirectoryExists("./yr.no/");
EnsureDirectoryExists("./yr.no/data/");
EnsureDirectoryExists("./yr.no/xsd/");
EnsureDirectoryExists("./yr.no/xsd/xsd.exe/");
EnsureDirectoryExists("./yr.no/xsd/liquidtechnologies/");
EnsureDirectoryExists("./yr.no/csharp/");


FilePath output_path = null;
int  exit_code = -1;

output_path = File("./yr.no/xsd/schema.xsd");
if ( ! FileExists(output_path) )
{
    DownloadFile
            (
                "https://api.met.no/weatherapi/locationforecast/2.0/schema",
                output_path
            );
}



string ns_root = "HolisticWare.Ph4ct3x.Utilities.Weather.Providers.YrNo";
string ns = ns_root;

ns = ns_root 
        + "." +
        "WeatherData.Current.Croatia.Regions"
        ;
exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            $"{output_path}"
                            + " " +
                            "/classes"
                            + " " +
                            $"/namespace:{ns}"
                            + " " +
                            "/language:CS"
                            + " " +
                            "/outputdir:./yr.no/csharp/"
                    }
                );                
