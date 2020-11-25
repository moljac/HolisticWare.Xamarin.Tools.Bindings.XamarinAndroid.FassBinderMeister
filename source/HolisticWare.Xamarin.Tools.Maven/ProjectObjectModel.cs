using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven
{
	/// <summary>
	/// Project Object Model
	/// POM file XML
	/// </summary>
	/// https://maven.apache.org/guides/introduction/introduction-to-the-pom.html
	public partial class ProjectObjectModel
    {

		[XmlRoot(ElementName = "license", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public partial class License
		{
			[XmlElement(ElementName = "name", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public string Name { get; set; }
			[XmlElement(ElementName = "url", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public string Url { get; set; }
			[XmlElement(ElementName = "distribution", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public string Distribution { get; set; }
		}

		[XmlRoot(ElementName = "licenses", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public partial class Licenses
		{
			[XmlElement(ElementName = "license", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public License License { get; set; }
		}

		[XmlRoot(ElementName = "developer", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public partial class Developer
		{
			[XmlElement(ElementName = "name", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public string Name { get; set; }
		}

		[XmlRoot(ElementName = "developers", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public partial class Developers
		{
			[XmlElement(ElementName = "developer", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public Developer Developer { get; set; }
		}

		[XmlRoot(ElementName = "scm", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public partial class SCM
		{
			[XmlElement(ElementName = "connection", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public string Connection { get; set; }
			[XmlElement(ElementName = "url", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public string Url { get; set; }
		}

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

		[XmlRoot(ElementName = "dependencies", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public partial class Dependencies
		{
			[XmlElement(ElementName = "dependency", Namespace = "http://maven.apache.org/POM/4.0.0")]
			public List<Dependency> Dependency { get; set; }
		}

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
}
