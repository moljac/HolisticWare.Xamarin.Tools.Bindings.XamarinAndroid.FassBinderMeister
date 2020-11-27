using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Refactored.Serialization.Formatters
{
	public partial class Licenses
	{
		[XmlElement(ElementName = "license", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public License License
		{
			get;
			set;
		}

	}

}
