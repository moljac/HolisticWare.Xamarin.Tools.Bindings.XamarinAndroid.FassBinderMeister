using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    /// <summary>
    /// MasterIndex - index of all group ids
    /// Google                  Maven Repository     -   available
    /// MavenCentralSonatype    Maven Repository     -   not available
    /// MavenCentralSonatype    Maven Repository     -   built from HTML
    /// </summary>
    public partial class MasterIndex : Maven.MasterIndex
    {


        public override async
            Task<IEnumerable<string>>
                                                GetGroupsTextualAsync
                                                    (
                                                    )
        {
            List<string> result = new List<string>();

            await Task.Run
                        (
                            () =>
                            {
                                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                                System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(xd.NameTable);

                                xd.LoadXml(this.Content);

                                System.Xml.XmlNodeList nl = xd.SelectNodes("/metadata/*", ns);


                                foreach (System.Xml.XmlNode node in nl)
                                {
                                    string node_name = node.Name;

                                    result.Add(node_name);
                                }

                                this.GroupsTextual = result;
                            }
                        );

            return result;
        }

        public override async
            Task<IEnumerable<Maven.Group>>
                                                GetGroupsAsync
                                                    (
                                                    )
        {
            List<Maven.Group> result = new List<Maven.Group>();

            await Task.Run
                        (
                            () =>
                            {
                                foreach (string group in this.GroupsTextual)
                                {
                                    Group g = new Group(group);
                                    result.Add(g);
                                }
                            }
                        );

            return result;
        }

    }
}
