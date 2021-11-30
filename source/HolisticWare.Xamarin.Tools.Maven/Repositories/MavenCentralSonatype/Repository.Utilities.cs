using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

using HtmlAgilityPack;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public partial class Repository
    {
        public static partial class Utilities
        {
            public static async
                Task<SearchData>
                                                Search
                                                        (
                                                            string search_term,
                                                            int search_results_count = 20
                                                        )
            {
                SearchData result = null;

                Uri url_default = Repository.UrlSearchDefault;

                Uri url = new Uri
                                (
                                    url_default.AbsoluteUri
                                                .Replace("_PLACEHOLDER_SEARCH_TERM_", search_term)
                                                .Replace("_PLACEHOLDER_SEARCH_RESULTS_", search_results_count.ToString())
                                );

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    string content = await MavenClient.HttpClient.GetStringContentAsync(url);

                    Search.Root root = JsonSerializer.Deserialize<Search.Root>(content);

                    result = new SearchData()
                    {
                        Artifacts = new List<Maven.Artifact>()
                    };

                    foreach (Search.Doc d in root.Response.Docs)
                    {
                        Maven.Artifact a = new Maven.Artifact()
                        {
                            ArtifactId = d.A,
                            Group = new Maven.Group(d.G),
                            GroupId = d.G,
                        };

                        string g_id = d.Text[0];
                        string a_id = d.Text[1];

                        //((Artifact)a).GetMavenMetadataAsync();

                        string url_base = $"{Repository.UrlRootDefault}/{g_id.Replace('.', '/')}/{a_id}/maven-metadata.xml";

                        for (int i = 2; i < d.Text.Count; i++)
                        {
                            string url_file = $"{url_base}{d.Text[i]}";
                        }

                        foreach (var t in d.Text)
                        {
                        }

                        result.Artifacts.Add(a);
                    }
                }

                return result;
            }


            /// <summary>
            /// Get MasterIndex of the MavenCentralSonatype Maven repository
            /// MavenCentralSonatype Maven repository dos not have pregenerated MasterIndex
            /// parsing HTTP directory output
            /// https://repo1.maven.org/maven2/
            /// </summary>
            /// <returns>Maven.MasterIndex</returns>
            public static new async
                Task<Maven.MasterIndex>
                                                GetMasterIndexAsync
                                                        (
                                                        )
            {
                MasterIndex result = null;


                MasterIndexDefault = result;

                return result;
            }

        }
    }
}
