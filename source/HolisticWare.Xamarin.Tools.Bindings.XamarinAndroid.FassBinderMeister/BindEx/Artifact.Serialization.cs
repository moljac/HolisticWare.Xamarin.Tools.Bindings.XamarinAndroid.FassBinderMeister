
using System;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        // Microsoft.AspNetCore.Mvc.ModelMetadataType
        Core.Serialization.ModelMetadataType
        (
            typeof(ArtifactSerializationMetadata)
        )
    ]
    public partial class Artifact
    {
        public static new Artifact DeserializeFromJSON_Newtonsoft(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Artifact>(json);
        }

        public static string SerializeToJSON_Newtonsoft(Artifact artifact)
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject
                                                            (
                                                                artifact,
                                                                Newtonsoft.Json.Formatting.Indented
                                                            );

            return content;
        }

        public static new Artifact DeserializeFromJSON_System_Text_Json(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Artifact>(json);
        }

        public static string SerializeToJSON_System_Text_Json(Artifact artifact)
        {
            string content = System.Text.Json.JsonSerializer.Serialize<Artifact>
                                                                    (
                                                                        artifact,
                                                                        new System.Text.Json.JsonSerializerOptions
                                                                        {
                                                                            WriteIndented = true
                                                                        }                                                                        
                                                                    );

            return content;
        }

        public static new Artifact DeserializeFromXML(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                return (Artifact) xs.Deserialize(tr);
            }
        }

        public static string SerializeToXML(string filename, Artifact artifact)
        {
            System.Xml.Serialization.XmlSerializer xs = null;
            string content = null;

            using (System.IO.TextWriter tw = new System.IO.StringWriter())
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                xs.Serialize(tw, artifact);
                content = tw.ToString();
            }

            return content;
        }
    }
}

