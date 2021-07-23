using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.POM
{
	/// <summary>
	/// Project Object Model
	/// POM file XML
	/// </summary>
	public partial class ProjectObjectModel
	{
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
}
