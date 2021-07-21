using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
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
            url_default_textual = $"{Repository.UrlRootDefault}/_PLACEHOLDER_GROUP_ID_/group-index.xml";

            url_default = new Uri(url_default_textual);

            return;
        }

        public static string UrlDefaultTextual
        {
            get
            {
                return url_default_textual;
            }

            set
            {
                url_default_textual = value;

                return;
            }
        }

        public static Uri UrlDefault
        {
            get
            {
                return url_default;
            }

            set
            {
                url_default = value;

                return;
            }
        }

        public override string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;

                return;
            }
        }

        public override Uri Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;

                return;
            }
        }

        public override string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;

                return;
            }
        }

        public override
            List<(string name, string[] versions)>
                                                ArtifactsTextual
        {
            get
            {
                return this.artifacts_textual;
            }

            set
            {
                this.artifacts_textual = value;

                return;
            }
        }

        public override
            List<Maven.Artifact>
                                                Artifacts
        {
            get
            {
                return this.artifacts;
            }

            set
            {
                this.artifacts = value;

                return;
            }
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
            IEnumerable<(string name, string[] versions)>
                                                ParseArtifactNamesAndVersionsFromXML
                                                    (
                                                        string xml
                                                    )
        {
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);

            System.Xml.XmlNodeList node_list = xmldoc.SelectNodes($"/{this.Name}/*", ns);
            foreach (System.Xml.XmlNode xn in node_list)
            {
                string n = xn.Name;
                string[] vs = xn.Attributes["versions"].InnerXml.Split
                                                            (
                                                                new string[] { "," },
                                                                StringSplitOptions.RemoveEmptyEntries
                                                            );
                yield return (name: n, versions: vs);
            }
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
