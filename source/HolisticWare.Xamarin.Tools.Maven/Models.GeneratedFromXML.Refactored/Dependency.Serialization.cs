using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Maven.Models.GeneratedFromXML.Refactored
{
	public partial class ProjectObjectModel
	{
		// POCO class with Metadata for Buddy Class containing attributes
		[
			// Microsoft.AspNetCore.Mvc.ModelMetadataType
			Core.Serialization.ModelMetadataType
									(
										typeof(Serialization.Formatters.Dependency)
									)
		]
		public partial class Dependency
		{
			public static Dependency DeserializeFromJSON_Newtonsoft(string json)
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Dependency>(json);
			}

			public static Dependency DeserializeFromJSON_System_Text_Json(string json)
			{
				return System.Text.Json.JsonSerializer.Deserialize<Dependency>(json);
			}

			public static Dependency DeserializeFromXML(string xml)
			{
				System.Xml.Serialization.XmlSerializer xs = null;

				using (System.IO.TextReader tr = new System.IO.StringReader(xml))
				{
					xs = new System.Xml.Serialization.XmlSerializer(typeof(Dependency));

					return (Dependency)xs.Deserialize(tr);
				}
			}
		}
	}
}