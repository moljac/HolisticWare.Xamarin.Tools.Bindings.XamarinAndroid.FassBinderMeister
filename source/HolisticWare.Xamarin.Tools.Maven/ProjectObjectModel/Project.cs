using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.ProjectObjectModel
{
	/// <summary>
	/// Project Object Model
	/// POM file XML
	/// </summary>
	[XmlRoot(ElementName = "project", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class Project
	{
		[XmlElement(ElementName = "modelVersion", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string ModelVersion { get; set; }
		[XmlElement(ElementName = "groupId", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string GroupId { get; set; }
		[XmlElement(ElementName = "artifactId", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string ArtifactId { get; set; }
		[XmlElement(ElementName = "version", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Version { get; set; }
		[XmlElement(ElementName = "name", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Name { get; set; }
		[XmlElement(ElementName = "description", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Description { get; set; }
		[XmlElement(ElementName = "url", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Url { get; set; }
		[XmlElement(ElementName = "inceptionYear", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string InceptionYear { get; set; }
		[XmlElement(ElementName = "licenses", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public Licenses Licenses { get; set; }
		[XmlElement(ElementName = "developers", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public Developers Developers { get; set; }
		[XmlElement(ElementName = "scm", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public SCM SCM { get; set; }
		[XmlElement(ElementName = "dependencies", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public Dependencies Dependencies { get; set; }
		[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
		[XmlAttribute(AttributeName = "xmlns")]
		public string XMLNS { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string XSI { get; set; }
	}
}
