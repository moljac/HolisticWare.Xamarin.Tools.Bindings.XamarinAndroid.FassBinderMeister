using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class MasterIndex
    {
        public string Content
        {
            get;
            set;
        }

        public IEnumerable<string> GroupsTextual
        {
            get;
            set;
        }

        public static string Url
        {
            get;
            set;
        }  = $"https://dl.google.com/android/maven2/master-index.xml";

        public async
            Task<IEnumerable<GroupIndex>>
                                                GetGroupIndicesAsync
                                                    (
                                                    )
        {
            this.GroupsTextual = await GetGroupNamesAsync();

            return GroupIndicesFromGroupNames(this.GroupsTextual);
        }

        public async
            Task<IEnumerable<string>>
                                                GetGroupNamesAsync
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
                response_string_xml = await MavenClient.HttpClient.GetStringAsync(MasterIndex.Url);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return ParseGroupNamesFromXMl(response_string_xml);
        }


        public IEnumerable<string>
                                                ParseGroupNamesFromXMl
                                                    (
                                                        string xml
                                                    )
        {
            System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
            xmldoc.LoadXml(xml);
            System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);

            System.Xml.XmlNodeList node_list = xmldoc.SelectNodes("/metadata/*", ns);
            foreach(System.Xml.XmlNode xn in node_list)
            {
                string name = xn.Name;
                yield return name;
            }
        }

        public IEnumerable<GroupIndex>
                                                GroupIndicesFromGroupNames
                                                    (
                                                        IEnumerable<string> groupnames
                                                    )
        {
            foreach (string gn in groupnames)
            {
                GroupIndex gi = new GroupIndex(gn);

                yield return gi;
            }
        }
    }
}
