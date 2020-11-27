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
										typeof(Serialization.Formatters.Licenses)
									)
		]
		public partial class Licenses
		{
			public static Licenses DeserializeFromJSON_Newtonsoft(string json)
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Licenses>(json);
			}

			public static Licenses DeserializeFromJSON_System_Text_Json(string json)
			{
				return System.Text.Json.JsonSerializer.Deserialize<Licenses>(json);
			}

			public static Licenses DeserializeFromXML(string xml)
			{
				System.Xml.Serialization.XmlSerializer xs = null;

				using (System.IO.TextReader tr = new System.IO.StringReader(xml))
				{
					xs = new System.Xml.Serialization.XmlSerializer(typeof(Licenses));

					return (Licenses)xs.Deserialize(tr);
				}
			}
		}
	}
}
