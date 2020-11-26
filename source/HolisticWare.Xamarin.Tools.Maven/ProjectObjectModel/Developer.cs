using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.ProjectObjectModel
{
	[XmlRoot(ElementName = "developer", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class Developer
	{
		[XmlElement(ElementName = "name", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public string Name { get; set; }
	}

}
