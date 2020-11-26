using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.ProjectObjectModel
{
	[XmlRoot(ElementName = "dependency", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class Dependency
	{
		[XmlElement(ElementName = "groupId", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string GroupId { get; set; }
		[XmlElement(ElementName = "artifactId", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string ArtifactId { get; set; }
		[XmlElement(ElementName = "version", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Version { get; set; }
		[XmlElement(ElementName = "scope", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Scope { get; set; }
	}
}
