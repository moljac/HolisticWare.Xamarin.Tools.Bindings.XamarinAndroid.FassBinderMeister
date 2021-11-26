using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral
{
    public partial class GroupIndex : Maven.GroupIndex
    {
        public GroupIndex (string group_id)
            :
            base(group_id)
        {
            this.Name = group_id;

            return;
        }

        static GroupIndex()
        {
            url_default_textual = null;
            url_default = null;

            // TODO: build GroupIndex

            return;
        }

        public async
            Task<IEnumerable<(string name, string[] versions)>>
                                                GetArtifactNamesAndVersionsAsync
                                                    (
                                                    )
        {
            string response_string_xml = null;

            try
            {
                /*
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string response_body = await response.Content.ReadAsStringAsync();
                */
                // new helper method below
                response_string_xml = await MavenClient.HttpClient.GetStringAsync(this.Url);
                this.Content = response_string_xml;
            }
            catch (HttpRequestException exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"GroupIndex.GetArtifactNamesAndVersionsAsync HttpRequestException");
                sb.AppendLine($"    Message : {exc.Message}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());
            }

            IEnumerable<(string name, string[] versions)> result = null;
            result = ParseArtifactNamesAndVersionsFromXML(response_string_xml);

            return result;
        }

        public 
            IEnumerable<ArtifactUnversioned>
                                                GetArtifacts
                                                    (
                                                        IEnumerable<(string name, string[] versions)> artifacts_textual
                                                    )
        {
            foreach((string name, string[] versions) at in artifacts_textual)
            {
                ArtifactUnversioned a = new ArtifactUnversioned
                                    {
                                        ArtifactId = at.name,
                                        VersionsTextual = (at.versions).ToList(),
                                        Versions = ArtifactUnversioned.GetVersions(at.versions)
                                                                .ToList()
                                                                //.OrderByDescending()
                                    };

                yield return a;
            }
        }

    }
}
