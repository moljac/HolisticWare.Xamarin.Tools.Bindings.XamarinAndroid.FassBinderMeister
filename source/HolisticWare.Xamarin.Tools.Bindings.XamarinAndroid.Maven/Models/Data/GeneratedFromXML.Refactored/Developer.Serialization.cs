using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Models.GeneratedFromXML.Refactored
{
	public partial class ProjectObjectModel
	{
		// POCO class with Metadata for Buddy Class containing attributes
		[
			// Microsoft.AspNetCore.Mvc.ModelMetadataType
			Core.Serialization.ModelMetadataType
									(
										typeof(Serialization.Formatters.Developer)
									)
		]
		public partial class Developer
		{
			public static Developer DeserializeFromJSON_Newtonsoft(string json)
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<Developer>(json);
			}

			public static Developer DeserializeFromJSON_System_Text_Json(string json)
			{
				return System.Text.Json.JsonSerializer.Deserialize<Developer>(json);
			}

			public static Developer DeserializeFromXML(string xml)
			{
				System.Xml.Serialization.XmlSerializer xs = null;

				using (System.IO.TextReader tr = new System.IO.StringReader(xml))
				{
					xs = new System.Xml.Serialization.XmlSerializer(typeof(Developer));

					return (Developer)xs.Deserialize(tr);
				}
			}
		}
	}
}
