
namespace HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Refactored.Serialization.Formatters
{
	/// <summary>
	/// Project Object Model
	/// POM file XML
	/// </summary>
	[Newtonsoft.Json.JsonObject("project")]
	//[System.Text.Json.Serialization("project")]
	[System.Xml.Serialization.XmlRoot
								(
									ElementName = "project",
									Namespace = "http://maven.apache.org/POM/4.0.0"
								)
	]
	public partial class Project
	{
		[Newtonsoft.Json.JsonProperty("modelVersion")]
		[System.Text.Json.Serialization.JsonPropertyName("modelVersion")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "modelVersion",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string ModelVersion
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("groupId")]
		[System.Text.Json.Serialization.JsonPropertyName("groupId")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "groupId",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string GroupId
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("artifactId")]
		[System.Text.Json.Serialization.JsonPropertyName("artifactId")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "artifactId",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string ArtifactId
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("version")]
		[System.Text.Json.Serialization.JsonPropertyName("version")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "version",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string Version
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("name")]
		[System.Text.Json.Serialization.JsonPropertyName("name")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "name",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string Name
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("description")]
		[System.Text.Json.Serialization.JsonPropertyName("description")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "description",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string Description
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("url")]
		[System.Text.Json.Serialization.JsonPropertyName("url")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "url",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string Url
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("inceptionYear")]
		[System.Text.Json.Serialization.JsonPropertyName("inceptionYear")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "inceptionYear",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string InceptionYear
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("licenses")]
		[System.Text.Json.Serialization.JsonPropertyName("licenses")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "licenses",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public Licenses Licenses
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("developers")]
		[System.Text.Json.Serialization.JsonPropertyName("developers")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "developers",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public Developers Developers
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("scm")]
		[System.Text.Json.Serialization.JsonPropertyName("scm")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "scm",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public SCM SCM
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("dependencies")]
		[System.Text.Json.Serialization.JsonPropertyName("dependencies")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "dependencies",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public Dependencies Dependencies
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("schemaLocation")]
		[System.Text.Json.Serialization.JsonPropertyName("schemaLocation")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "schemaLocation",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string SchemaLocation
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("xmlns")]
		[System.Text.Json.Serialization.JsonPropertyName("xmlns")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "xmlns",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string XMLNS
		{
			get;
			set;
		}

		[Newtonsoft.Json.JsonProperty("xsi")]
		[System.Text.Json.Serialization.JsonPropertyName("xsi")]
		[System.Xml.Serialization.XmlElement
									(
										ElementName = "xsi",
										Namespace = "http://maven.apache.org/POM/4.0.0"
									)
		]
		public string XSI
		{
			get;
			set;
		}

	}
}
