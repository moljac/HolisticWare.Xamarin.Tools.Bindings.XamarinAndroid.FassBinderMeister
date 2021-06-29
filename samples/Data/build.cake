// #tool "dotnet:?package=dotnet-xscgen"
// #tool "dotnet:?package=ddotnet-xdt"


// https://api.met.no/weatherapi/locationforecast/2.0/schema


EnsureDirectoryExists("./pom/");
EnsureDirectoryExists("./nuspec/");
EnsureDirectoryExists("./maven-central/");
EnsureDirectoryExists("./maven-google/");


FilePath output_path = null;
int  exit_code = -1;

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
