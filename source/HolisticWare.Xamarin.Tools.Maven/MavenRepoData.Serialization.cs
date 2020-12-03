using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        // Microsoft.AspNetCore.Mvc.ModelMetadataType
        Core.Serialization.ModelMetadataType
        (
            typeof(HolisticWare.Xamarin.Tools.Maven.Serialization.Formatters.MavenRepoData)
        )
    ]
    public partial class MavenRepoData
    {
        public static MavenRepoData DeserializeFromJSON_Newtonsoft(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MavenRepoData>(json);
        }

        public static string SerializeToJSON_Newtonsoft(MavenRepoData maven_repo_data)
        {
            string content = Newtonsoft.Json.JsonConvert.SerializeObject(maven_repo_data);

            return content;
        }

        public static MavenRepoData DeserializeFromJSON_System_Text_Json(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<MavenRepoData>(json);
        }

        public static string SerializeToJSON_System_Text_Json(MavenRepoData maven_repo_data)
        {
            string content = System.Text.Json.JsonSerializer.Serialize<MavenRepoData>
                                                                    (
                                                                        maven_repo_data,
                                                                        null
                                                                    );
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmm");
            System.IO.File.WriteAllText($"maven-repo-data-{timestamp}", content);

            return content;
        }

        public static MavenRepoData DeserializeFromXML(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(MavenRepoData));

                return (MavenRepoData)xs.Deserialize(tr);
            }
        }

        public static string SerializeToXML(string filename, MavenRepoData maven_repo_data)
        {
            System.Xml.Serialization.XmlSerializer xs = null;
            string content = null;

            using (System.IO.TextWriter tw = new System.IO.StringWriter())
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                xs.Serialize(tw, maven_repo_data);
                content = tw.ToString();
            }

            return content;
        }

    }
}
