using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class GroupIndex
    {
        public GroupIndex(string name)
        {
            this.Name = name;

            return;
        }

        public string Name
        {
            get;
            set;
        }

        public string UrlGroupIndex
        {
            get
            {
                string gid = this.Name.Replace(".", "/");
                string url = $"https://dl.google.com/android/maven2/{gid}/group-index.xml";

                return url;
            }
        }

        public string Content
        {
            get;
            set;
        }

        public List<(string name, string[] versions)> ArtifactsTextual
        {
            get;
            set;
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
                response_string_xml = await MavenClient.HttpClient.GetStringAsync(this.UrlGroupIndex);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return ParseArtifactNamesAndVersionsFromXML(response_string_xml);
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

            System.Xml.XmlNodeList node_list = xmldoc.SelectNodes("/metadata/*", ns);
            foreach (System.Xml.XmlNode xn in node_list)
            {
                string n = xn.Name;

                yield return (name: n, versions: null);
            }
        }

        public 
            IEnumerable<Artifact>
                                                GetArtifacts
                                                    (
                                                        IEnumerable<(string name, string[] versions)> artifacts_textual
                                                    )
        {
            foreach((string name, string[] versions) in artifacts_textual)
            {
                yield return new Artifact
                                    {
                                        Id = name,
                                    };
            }
        }

    }
}
