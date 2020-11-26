
namespace HolisticWare.Xamarin.Tools.Maven.DevelopersObjectModel
{
	// POCO class with Metadata for Buddy Class containing attributes
	[
		// Microsoft.AspNetCore.Mvc.ModelMetadataType
		Core.Serialization.ModelMetadataType
		(
			typeof(HolisticWare.Xamarin.Tools.Maven.ProjectObjectModel.Serialization.Formatters.Developers)
		)
	]
	public partial class Developers
	{
		public static Developers DeserializeFromJSON_Newtonsoft(string json)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<Developers>(json);
		}

		public static Developers DeserializeFromJSON_System_Text_Json(string json)
		{
			return System.Text.Json.JsonSerializer.Deserialize<Developers>(json);
		}

		public static Developers DeserializeFromXML(string xml)
		{
			System.Xml.Serialization.XmlSerializer xs = null;

			using (System.IO.TextReader tr = new System.IO.StringReader(xml))
			{
				xs = new System.Xml.Serialization.XmlSerializer(typeof(Developers));

				return (Developers)xs.Deserialize(tr);
			}
		}
	}

}
