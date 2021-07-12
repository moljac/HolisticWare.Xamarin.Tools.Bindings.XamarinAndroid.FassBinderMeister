﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.POM.ProjectObjectModel
{
	public partial class ProjectObjectModel
	{
		public partial class License
		{
			public string Name
			{
				get;
				set;
			}

			public string Url
			{
				get;
				set;
			}

			public string Distribution
			{
				get;
				set;
			}

		}
	}
}