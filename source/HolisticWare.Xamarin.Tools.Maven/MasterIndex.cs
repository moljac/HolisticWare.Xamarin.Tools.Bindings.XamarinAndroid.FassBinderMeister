using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    /// <summary>
    /// MasterIndex - index of all group ids
    /// Google                  Maven Repository     -   available
    /// MavenCentralSonatype    Maven Repository     -   not available
    /// MavenCentralSonatype    Maven Repository     -   built from HTML
    /// </summary>
    public partial class MasterIndex
    {
        public Repository Repository
        {
            get;
            set;
        }

        public virtual string Content
        {
            get;
            set;
        }

        public virtual IEnumerable<string> GroupsTextual
        {
            get;
            set;
        }

        public virtual string Url
        {
            get;
            set;
        }


        public virtual async
            Task<IEnumerable<Group>>
                                                GetGroupsAsync
                                                    (
                                                    )
        {
            if(this.Repository == null)
            {
                return null;
            }

            //Load the XML file in XmlDocument.
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            System.Xml.XmlNamespaceManager ns = new System.Xml.XmlNamespaceManager(xd.NameTable);

            xd.LoadXml(this.Content);

            System.Xml.XmlNodeList nl = xd.SelectNodes("/metadata/*", ns);

            List<Group> groups = new List<Group>();

            foreach (System.Xml.XmlNode node in nl)
            {
                string node_name = node.Name;

                Group g = new Group(node_name);
                groups.Add(g);
            }

            return groups;
        }

    }
}
