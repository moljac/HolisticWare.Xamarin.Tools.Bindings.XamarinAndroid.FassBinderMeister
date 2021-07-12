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
		public partial class Project
		{
			public string ModelVersion
			{
				get;
				set;
			}

			public string GroupId
			{
				get;
				set;
			}

			public string ArtifactId
			{
				get;
				set;
			}

			public string Version
			{
				get;
				set;
			}

			public string Name
			{
				get;
				set;
			}

			public string Description
			{
				get;
				set;
			}

			public string Url
			{
				get;
				set;
			}

			public string InceptionYear
			{
				get;
				set;
			}

			public Licenses Licenses
			{
				get;
				set;
			}

			public Developers Developers
			{
				get;
				set;
			}

			public SCM SCM
			{
				get;
				set;
			}

			public Dependencies Dependencies
			{
				get;
				set;
			}

			public string SchemaLocation
			{
				get;
				set;
			}

			public string XMLNS
			{
				get;
				set;
			}

			public string XSI
			{
				get;
				set;
			}
		}
	}
}
