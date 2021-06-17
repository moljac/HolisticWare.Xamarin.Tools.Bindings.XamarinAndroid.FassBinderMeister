using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using Spectre.Console;

namespace HolisticWare.Xamarin.Tools.NuGet.dotnet_tool
{
    class Program
    {
        public static Task<int> Main(string[] args)
        {
            AnsiConsole.Render
                (
                    new FigletText("LUMPER")
                            .Color(new Color(89, 48, 1))
                );
            // Create a root command with some options
            RootCommand root_commamd = null;
            root_commamd = new RootCommand
                                    {
                                        Name = "lumper",
                                        Description = "lumper - nuget client"
                                    };

            root_commamd.AddCommand(Search());

            // Parse the incoming args and invoke the handler
            return root_commamd.InvokeAsync(args).Result;
        }

        private static Command Search()
        {
            Command cmd = new Command("search", "search nuget.org");

            cmd.AddOption
                (
                    new Option
                            (
                                new[] { "--nuget-id", "-id" },
                                "Nuget Id"
                            )
                    {
                        //Argument = new Argument<string>
                        //{
                        //    Arity = ArgumentArity.ExactlyOne
                        //}
                    }
                );

            cmd.Handler = CommandHandler.Create<string>
                            (
                                (nuget_id) =>
                                {
                                    if (String.IsNullOrEmpty(nuget_id))
                                    {
                                        Console.WriteLine("Required option nuget_id missing");
                                        return 1;
                                    }



                                    return 0;
                                }
                            );

            return cmd;
        }

    }
}
