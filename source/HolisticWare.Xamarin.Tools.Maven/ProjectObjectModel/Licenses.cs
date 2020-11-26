using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.ProjectObjectModel
{
	[XmlRoot(ElementName = "licenses", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class Licenses
	{
		[XmlElement(ElementName = "license", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public License License { get; set; }
	}

}
