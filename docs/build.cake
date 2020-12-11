int exit_code;

EnsureDirectoryExists("./csharp/");

exit_code = StartProcess
                (
                    "xsd",
                    new ProcessSettings
                    {
                        Arguments =
                            "./maven-4.0.0.xsd"
                            + " " +
                            "/classes"
                            + " " +
                            "/namespace:HolisticWare.Xamarin.Tools.Maven"
                            + " " +
                            "/language:CS"
                            + " " +
                            "/outputdir:./csharp/"
                    }
                );
