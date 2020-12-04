using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Models.GeneratedFromXML.Refactored.Serialization.Formatters
{
	/// <summary>
	/// Project Object Model
	/// POM file XML
	/// </summary>
	[XmlRoot(ElementName = "dependencies", Namespace = "http://maven.apache.org/POM/4.0.0")]
	public partial class Dependencies
	{
		[XmlElement(ElementName = "dependency", Namespace = "http://maven.apache.org/POM/4.0.0")]
		public List<Dependency> Dependency
		{
			get;
			set;
		}

	}
}
