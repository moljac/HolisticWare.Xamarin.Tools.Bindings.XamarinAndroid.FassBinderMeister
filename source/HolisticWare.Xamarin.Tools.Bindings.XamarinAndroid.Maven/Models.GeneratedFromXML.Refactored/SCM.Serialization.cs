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
										typeof(Serialization.Formatters.SCM)
									)
		]
		public partial class SCM
		{
			public static SCM DeserializeFromJSON_Newtonsoft(string json)
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<SCM>(json);
			}

			public static SCM DeserializeFromJSON_System_Text_Json(string json)
			{
				return System.Text.Json.JsonSerializer.Deserialize<SCM>(json);
			}

			public static SCM DeserializeFromXML(string xml)
			{
				System.Xml.Serialization.XmlSerializer xs = null;

				using (System.IO.TextReader tr = new System.IO.StringReader(xml))
				{
					xs = new System.Xml.Serialization.XmlSerializer(typeof(SCM));

					return (SCM)xs.Deserialize(tr);
				}
			}
		}
	}
}
