using System;
using System.Threading.Tasks;

using System.CommandLine;
using System.CommandLine.Invocation;

/*

https://github.com/dotnet/command-line-api/blob/main/docs/Features-overview.md#debugging

 
*/
namespace HolisticWare.Xamarin.Tools.NuGet.dotnet_tool
{
    public partial class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Command command_search_maven =
                new Command
                        (
                            "maven",
                            "search for various packages"
                        )
                {
                    new Argument<string>
                                (
                                    "maven",
                                    "search maven repositories (Google and Maven Central (Sonatype)"
                                ),
                    new Option<string>
                                (
                                    new[] { "--MavenGroupId", "-mgid" },
                                    "Maven Group Id"
                                ),
                    new Option<string>
                                (
                                    new[] { "--MavenArtifactId", "-maid" },
                                    "Maven Artifact Id"
                                ),
                    new Option<string>
                                (
                                    new[] { "--MavenArtifactVersion", "-mav" },
                                    "Maven Artifact Version"
                                ),
                    //--------------------------------------------------------------------------
                    new Option<string>
                                (
                                    new[] { "--verbose", "-v" },
                                    "Verbose output"
                                ),
                };
            command_search_maven.Handler = CommandHandler.Create
                                                        <
                                                            string, // MavenGroupId
                                                            string, // MavenArtifactId
                                                            string  // MavenArtifactVersion
                                                        >
                                                        (
                                                            (
                                                                maven_group_id,
                                                                maven_artifact_id,
                                                                maven_artifact_version
                                                            )
                                                            =>
                                                            {
                                                                return;
                                                            }
                                                        );

            Command command_search_nuget =
                new Command
                        (
                            "nuget",
                            "search for nuget packages"
                        )
                {
                    new Option<string>
                                (
                                    new[] { "--NuGetId", "-nid" },
                                    "NuGet Id"
                                ),
                    new Option<string>
                                (
                                    new[] { "--NuGetVersion", "-nv" },
                                    "Nuget Version"
                                ),
                    //--------------------------------------------------------------------------
                    new Option<string>
                                (
                                    new[] { "--verbose", "-v" },
                                    "Verbose output"
                                ),
                };

            Command command_search_any =
                new Command
                        (
                            "any",
                            "search for any package (searches maven and nuget)"
                        )
                {
                    new Option<string>
                                (
                                    new[] { "--Term", "-t" },
                                    "Search Term."
                                ),
                    //--------------------------------------------------------------------------
                    new Option<string>
                                (
                                    new[] { "--verbose", "-v" },
                                    "Verbose output"
                                ),
                };

            Command command_search = new Command ("search")
            {
                command_search_maven,
                command_search_nuget,
                command_search_any,
            };

            RootCommand command_root = new RootCommand
            {
                command_search,
            new Command
                        (
                            "echo",
                            "Stop copying me!")
                {
            new Command
                    (
                        "times",
                        "Repeat a number of times."
                    )
            {
                new Argument<string>
                            (
                                "words",
                                "The thing you are saying."
                            ),
                new Option<int>
                            (
                                new[] { "--count", "-c" },
                                description: "The number of times to copy you.",
                                getDefaultValue: () => 1
                            ),
                new Option<int>
                            (
                                new[] { "--delay", "-d" },
                                description: "The delay between each echo.",
                                getDefaultValue: () => 100
                            ),
                new Option<string>
                            (
                                new[] { "--verbose", "-v" },
                                "Show the deets."
                            ),
            }
            .WithHandler(nameof(HandleEchoTimesAsync)),
            new Command
                    (
                        "forever",
                        "Just keep repeating."
                    )
            {
                new Argument<string>
                            (
                                "words",
                                "The thing you are saying."
                            ),
                new Option<int>
                            (
                                new[] { "--delay", "-d" },
                                description: "The delay between each echo.",
                                getDefaultValue: () => 100),
                new Option<string>
                            (
                                new[] { "--verbose", "-v" },
                                "Show the deets."
                            ),
            }.WithHandler(nameof(HandleEchoForeverAsync)),
        },
    };

            return await cmd.InvokeAsync(args);
        }

        private static object HandleEchoTimesAsync()
        {
            throw new NotImplementedException();
        }

        private static object HandleEchoForeverAsync()
        {
            throw new NotImplementedException();
        }

        private static object HandleGreeting()
        {
            throw new NotImplementedException();
        }
    }
}