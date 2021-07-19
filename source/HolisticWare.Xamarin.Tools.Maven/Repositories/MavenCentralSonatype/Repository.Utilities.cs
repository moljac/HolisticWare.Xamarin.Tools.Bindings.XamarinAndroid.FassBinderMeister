﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
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

                // https://search.maven.org/solrsearch/select?q=_PLACEHOLDER_SEARCH_TERM_&start=0&rows=_PLACEHOLDER_SEARCH_RESULTS_
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
                        Artifacts = new List<Maven.ArtifactUnversioned>()
                    };

                    foreach (Search.Doc d in root.Response.Docs)
                    {
                        Maven.ArtifactUnversioned a = new ArtifactUnversioned()
                        {
                            ArtifactId = d.A,
                            Group = new Maven.Group(d.G),
                            GroupId = d.G,
                        };

                        string g_id = d.Text[0];
                        string a_id = d.Text[1];


                        ((ArtifactUnversioned)a).GetMavenMetadataAsync();

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
        }
    }
}