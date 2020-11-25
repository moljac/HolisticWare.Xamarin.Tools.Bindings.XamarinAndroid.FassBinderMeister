using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Maven
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        // Microsoft.AspNetCore.Mvc.ModelMetadataType
        Core.Serialization.ModelMetadataType
        (
            typeof(HolisticWare.Xamarin.Tools.Maven.Serialization.Formatters.Artifact)
        )
    ]
    public partial class Artifact
    {
        public static Artifact DeserializeFromJSON(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Artifact>(json);
        }

        public static Artifact DeserializeFromJSON1(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Artifact>(json);
        }

        public static Artifact DeserializeFromXML(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                return (Artifact) xs.Deserialize(tr);
            }
        }
    }
}

