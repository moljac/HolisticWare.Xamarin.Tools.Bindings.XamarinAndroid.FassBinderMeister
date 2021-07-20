using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class GroupIndex
    {
        public static partial class Utilities
        {
            public async static
                Task<Uri>
                                                        GetUriAsync
                                                                (
                                                                    Group group
                                                                )
            {
                return await GetUriAsync(group.Id);
            }

            public static async
                Task<Uri>
                                                        GetUriAsync
                                                                (
                                                                    string id
                                                                )
            {

                Uri result = new Uri
                                    (
                                        $"{GroupIndex.UrlDefault}"
                                                    .Replace
                                                        (
                                                            "_PLACEHOLDER_GROUP_ID_",
                                                            id.Replace('.', '/')
                                                        )
                                    );

                return result;
            }

            public static async
                Task<GroupIndex>
                                                        GetGroupIndexAsync
                                                                (
                                                                    Group group
                                                                )
            {
                return await GetGroupIndexAsync(group.Id);
            }

            public static async
                Task<GroupIndex>
                                                        GetGroupIndexAsync
                                                                (
                                                                    string group_id
                                                                )
            {
                Uri url = await GetUriAsync(group_id);

                GroupIndex result = null;

                string content = await MavenClient.HttpClient.GetStringContentAsync(url);

                if (content != null)
                {
                    result = new GroupIndex(group_id);

                    result.ArtifactsTextual = ParseArtifactNamesAndVersionsFromXML
                                                                (
                                                                    group_id,
                                                                    content
                                                                ).ToList();
                }

                return result;
            }

            public static
                IEnumerable<(string name, string[] versions)>
                                                    ParseArtifactNamesAndVersionsFromXML
                                                        (
                                                            string group_id,
                                                            string xml
                                                        )
            {
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.LoadXml(xml);
                System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);

                System.Xml.XmlNodeList node_list = xmldoc.SelectNodes($"/{group_id}/*", ns);
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
        }
    }
}
