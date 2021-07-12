using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel
{
	/// <summary>
	/// Project Object Model
	/// POM file XML
	/// </summary>
	public partial class ProjectObjectModel
	{
		public partial class Dependencies
		{
			public List<Dependency> Dependency
			{
				get;
				set;
			}

		}
	}
}
