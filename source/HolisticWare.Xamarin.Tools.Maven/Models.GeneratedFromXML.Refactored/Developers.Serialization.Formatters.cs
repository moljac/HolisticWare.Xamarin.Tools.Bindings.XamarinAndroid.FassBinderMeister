using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Refactored.Serialization.Formatters
{
	[XmlRoot(ElementName = "developers", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class Developers
	{
		[XmlElement(ElementName = "developer", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public Developer Developer
		{
			get;
			set;
		}

	}

}
