using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class MavenRepository
    {
        public static
            MavenRepository
                                DeserializeFromJSON_Newtonsoft
                                            (
                                                string json
                                            )
        {
            MavenRepository mr = null;
            mr = Newtonsoft.Json.JsonConvert.DeserializeObject<MavenRepository>
                                                    (
                                                        json
                                                    );
            return mr;
        }

        public
            string
                                SerializeToJSON_Newtonsoft
                                            (
                                            )
        {
            string content = null;

            content = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        this
                                                    );

            return content;
        }

        public static
            string
                                SerializeToJSON_Newtonsoft
                                            (
                                                MavenRepository maven_repo_data
                                            )
        {
            string content = null;

            content = Newtonsoft.Json.JsonConvert.SerializeObject
                                                    (
                                                        maven_repo_data
                                                    );

            return content;
        }

        public static
            MavenRepository
                                DeserializeFromJSON_System_Text_Json
                                            (
                                                string json
                                            )
        {
            MavenRepository mr = null;
            mr = System.Text.Json.JsonSerializer.Deserialize<MavenRepository>
                                                    (
                                                        json
                                                    );
            return mr;
        }

        public static
            string
                                SerializeToJSON_System_Text_Json
                                            (
                                                MavenRepository maven_repo_data
                                            )
        {
            string content = null;
            content = System.Text.Json.JsonSerializer.Serialize<MavenRepository>
                                                        (
                                                            maven_repo_data,
                                                            new System.Text.Json.JsonSerializerOptions
                                                            {
                                                                WriteIndented    = true
                                                            }
                                                        );

            return content;
        }

        public static
            MavenRepository
                                DeserializeFromXML
                                            (
                                                string xml
                                            )
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(MavenRepository));

                return (MavenRepository)xs.Deserialize(tr);
            }
        }

        public static
            string
                                SerializeToXML
                                            (
                                                MavenRepository maven_repo_data
                                            )
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
