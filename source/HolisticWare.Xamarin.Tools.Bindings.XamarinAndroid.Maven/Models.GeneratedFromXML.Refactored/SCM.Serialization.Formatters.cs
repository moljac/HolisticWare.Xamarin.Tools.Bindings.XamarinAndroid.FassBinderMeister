using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Models.GeneratedFromXML.Refactored.Serialization.Formatters
{
	[XmlRoot(ElementName = "scm", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class SCM
	{
		[XmlElement(ElementName = "connection", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Connection { get; set; }
		[XmlElement(ElementName = "url", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Url { get; set; }
	}

}
