using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public class Repository : Maven.Repository
    {
        public Repository() : base()
        {
            this.UrlRoot = Repositories.MavenCentralSonatype.Repository.UrlRootDefault;

            return;
        }

        static Repository()
        {
            // Maven Central Sonatype
            // root url
            url_root_default = new Uri($"https://repo1.maven.org/maven2");

            // Maven Central Sonatype
            // search url
            url_search_default = new Uri($"https://search.maven.org/solrsearch/select?q=_PLACEHOLDER_SEARCH_TERM_&start=0&rows=_PLACEHOLDER_SEARCH_RESULTS_");


            // Maven Central Sonatype
            // master index - must be built/implemented
            url_master_index_default = null;

            return;
        }

        public static Uri UrlRootDefault
        {
            get
            {
                return url_root_default;
            }
            set
            {
                url_root_default = value;

                return;
            }
        }

        public static new Uri UrlMasterIndexDefault
        {
            get
            {
                return url_master_index_default;
            }
            set
            {
                url_master_index_default = value;

                return;
            }
        }

        public static class Utilities
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

        public virtual async
            Task<SearchData>
                                            Search
                                                    (
                                                        string search_term,
                                                        int search_results_count = 20
                                                    )
        {
            SearchData result = null;

            // Discovery

            return result;
        }

    }
}
