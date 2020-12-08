using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        // Microsoft.AspNetCore.Mvc.ModelMetadataType
        Core.Serialization.ModelMetadataType
        (
            typeof(Serialization.Formatters.GoogleMavenData)
        )
    ]
    public partial class GoogleMavenData
    {
        public static new GoogleMavenData DeserializeFromJSON_Newtonsoft(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleMavenData>(json);
        }

        public static string SerializeToJSON_Newtonsoft(GoogleMavenData GoogleMavenData)
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(GoogleMavenData);

            return content;
        }

        public static new GoogleMavenData DeserializeFromJSON_System_Text_Json(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<GoogleMavenData>(json);
        }

        public static string SerializeToJSON_System_Text_Json(GoogleMavenData GoogleMavenData)
        {
            string content = System.Text.Json.JsonSerializer.Serialize<GoogleMavenData>
                                                                    (
                                                                        GoogleMavenData,
                                                                        null
                                                                    );
            string type_name = GoogleMavenData.GetType().Name;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmm");
            string filename = $"{type_name}-{timestamp}.json";
            System.IO.File.WriteAllText(filename, content);

            return content;
        }

        public static new GoogleMavenData DeserializeFromXML(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(GoogleMavenData));

                return (GoogleMavenData)xs.Deserialize(tr);
            }
        }

        public static string SerializeToXML(string filename, GoogleMavenData GoogleMavenData)
        {
            System.Xml.Serialization.XmlSerializer xs = null;
            string content = null;

            using (System.IO.TextWriter tw = new System.IO.StringWriter())
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(GoogleMavenData));

                xs.Serialize(tw, GoogleMavenData);
                content = tw.ToString();
            }

            return content;
        }
    }
}
