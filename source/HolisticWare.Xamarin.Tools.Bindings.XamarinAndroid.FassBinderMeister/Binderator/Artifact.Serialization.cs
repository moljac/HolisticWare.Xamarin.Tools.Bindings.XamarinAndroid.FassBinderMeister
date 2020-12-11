using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator
{
    public partial class Artifact
    {
        #region     JSON
        //-----------------------------------------------------------------------------------------
        public static
            Artifact
                                    DeserializeFromJSON
                                                            (
                                                                string json,
                                                                string library = "System.Text.Json"
                                                            )
        {
            Artifact a = null;

            switch (library.ToLower())
            {
                case "newtonsoft":
                    Newtonsoft.Json.JsonSerializerSettings s = Serialization.Artifact.SerializationSettings["Newtonsoft.Json"]
                                                                    as
                                                                    Newtonsoft.Json.JsonSerializerSettings;
                    a = Newtonsoft.Json.JsonConvert.DeserializeObject<Artifact>(json, s);
                    break;
                case "system.text.json":
                default:
                    System.Text.Json.JsonSerializerOptions o = Serialization.Artifact.SerializationSettings["System.Text.Json"]
                                                                    as
                                                                    System.Text.Json.JsonSerializerOptions;

                    a = System.Text.Json.JsonSerializer.Deserialize<Artifact>(json, o);
                    break;
            }

            return a;
        }

        public static async
            Task<Artifact>
                                    DeserializeFromJSONAsync
                                                            (
                                                                string json,
                                                                string library = "System.Text.Json"
                                                            )
        {
            Artifact a = null;

            switch (library.ToLower())
            {
                case "newtonsoft":
                    a = Newtonsoft.Json.JsonConvert.DeserializeObject<Artifact>(json);
                    break;
                case "system.text.json":
                default:
                    System.IO.Stream s = new System.IO.MemoryStream
                                                            (
                                                                Encoding.UTF8.GetBytes(json ?? "")
                                                            );
                    a = await System.Text.Json.JsonSerializer.DeserializeAsync<Artifact>(s);
                    break;
            }

            return a;
        }

        public
            string
                                    SerializeToJSON
                                                            (
                                                                string library = "Newtonsoft.Json"
                                                            )
        {
            string content = null;

            switch (library.ToLower())
            {
                case "newtonsoft.json":
                    Newtonsoft.Json.JsonSerializerSettings s = Serialization.Artifact.SerializationSettings["Newtonsoft.Json"]
                                                                    as
                                                                    Newtonsoft.Json.JsonSerializerSettings;

                    content = Newtonsoft.Json.JsonConvert.SerializeObject
                                                                (
                                                                    this,
                                                                    Newtonsoft.Json.Formatting.Indented,
                                                                    s
                                                                );
                    break;
                case "system.text.json":
                default:
                    System.Text.Json.JsonSerializerOptions o = Serialization.Artifact.SerializationSettings["System.Text.Json"]
                                                                    as
                                                                    System.Text.Json.JsonSerializerOptions;
                    content = System.Text.Json.JsonSerializer.Serialize<Artifact>
                                                                (
                                                                    this,
                                                                    o
                                                                );
                    break;
                }

            return content;
        }


        public static
            string
                                    SerializeToJSON_System_Text_Json
                                                            (
                                                                Artifact artifact
                                                            )
        {
            return artifact.SerializeToJSON();
        }
        //-----------------------------------------------------------------------------------------
        #endregion  JSON.System.Text.Json



        #region     XML
        //-----------------------------------------------------------------------------------------
        public static
            Artifact
                                        DeserializeFromXML
                                                            (
                                                                string xml
                                                            )
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                return (Artifact)xs.Deserialize(tr);
            }
        }

        public
            string
                                        SerializeToXML
                                                            (
                                                            )
        {
            System.Xml.Serialization.XmlSerializer xs = null;
            string content = null;

            using (System.IO.TextWriter tw = new System.IO.StringWriter())
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                xs.Serialize(tw, this);
                content = tw.ToString();
            }

            return content;
        }

        public static
            string
                                        SerializeToXML
                                                            (
                                                                Artifact artifact
                                                            )
        {
            return artifact.SerializeToXML();
        }
        //-----------------------------------------------------------------------------------------
        #endregion  XML


        #region     XML
        //-----------------------------------------------------------------------------------------
        public
            System.IO.MemoryStream
                            SerializeToBinary
                                                    (
                                                        string library = "protobuf-net"
                                                    )
        {
            System.IO.MemoryStream stream = null;

            Serialization.Artifact object_metadata = new(this);

            switch (library)
            {
                case "protobuf-net":
                    stream = new System.IO.MemoryStream();
                    ProtoBuf.Serializer.Serialize
                                            (
                                                stream,
                                                object_metadata
                                            );
                    break;
                case "system-runtime-serialization":
                default:
                    stream = new System.IO.MemoryStream();
                    // Serialize an object into the storage medium referenced by 'stream' object.
                    System.Runtime.Serialization.IFormatter formatter = null;
                    formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(stream, object_metadata);
                    break;
            }

            return stream;
        }
        //-----------------------------------------------------------------------------------------
        #endregion  XML
    }
}