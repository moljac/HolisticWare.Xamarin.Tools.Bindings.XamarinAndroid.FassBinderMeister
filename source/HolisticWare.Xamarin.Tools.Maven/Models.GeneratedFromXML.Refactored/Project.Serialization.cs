using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Refactored
{
	public partial class ProjectObjectModel
	{
		// POCO partial class with
		// REQUIRED Metadata for Buddy Class containing attributes
		// Optional Deserialization API
		[
			// Microsoft.AspNetCore.Mvc.ModelMetadataType
			Core.Serialization.ModelMetadataType
									(
										typeof(Serialization.Formatters.Project)
									)
		]
		public partial class Project
		{
			public static Project DeserializeFromJSON_Newtonsoft(string json)
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Project>(json);
			}

			public static Project DeserializeFromJSON_System_Text_Json(string json)
			{
				return System.Text.Json.JsonSerializer.Deserialize<Project>(json);
			}

			public static Project DeserializeFromXML(string xml)
			{
				System.Xml.Serialization.XmlSerializer xs = null;

				using (System.IO.TextReader tr = new System.IO.StringReader(xml))
				{
					xs = new System.Xml.Serialization.XmlSerializer(typeof(Project));

					return (Project)xs.Deserialize(tr);
				}
			}
		}
	}
}
