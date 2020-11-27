using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Refactored.Serialization.Formatters
{
	[XmlRoot(ElementName = "license", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class License
	{
		[XmlElement(ElementName = "name", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Name
		{
			get;
			set;
		}

		[XmlElement(ElementName = "url", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Url
		{
			get;
			set;
		}

		[XmlElement(ElementName = "distribution", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Distribution
		{
			get;
			set;
		}

	}
}
