
using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        Microsoft.AspNetCore.Mvc.ModelMetadataType
        //System.ComponentModel.DataAnnotations.MetadataType
        //Core.Serialization.ModelMetadataType
        (
            //typeof(Serialization.Formatters.Artifact)
            typeof(ArtifactSerializationMetadata)
        )
    ]
    public partial class Artifact
    {
        public class ArtifactSerializationMetadata
        {
            [Newtonsoft.Json.JsonProperty("groupId")]
            [System.Text.Json.Serialization.JsonPropertyName("groupId")]
            // System.Text.Json.Serialization.Json
            //  does not have Order Property
            // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "groupId",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public string IdGroup
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("artifactId")]
            [System.Text.Json.Serialization.JsonPropertyName("artifactId")]
            // System.Text.Json.Serialization.Json
            //  does not have Order Property
            // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "artifactId",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public string Id
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("versionTextual")]
            [System.Text.Json.Serialization.JsonPropertyName("versionTextual")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "versionTextual",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public string VersionTextual
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("version")]
            [System.Text.Json.Serialization.JsonPropertyName("version")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "version",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public System.Version Version
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("versions")]
            [System.Text.Json.Serialization.JsonPropertyName("versions")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "versions",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public List<System.Version> Versions
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("versionsTextual")]
            [System.Text.Json.Serialization.JsonPropertyName("versionsTextual")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "versionsTextual",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public string VersionsTextual
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("dependencies")]
            [System.Text.Json.Serialization.JsonPropertyName("dependencies")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "dependencies",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public List<Artifact> Dependencies
            {
                get;
                set;
            }


            [Newtonsoft.Json.JsonProperty("projectObjectModelTextual")]
            [System.Text.Json.Serialization.JsonPropertyName("projectObjectModelTextual")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "projectObjectModelTextual",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public string ProjectObjectModelTextual
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonProperty("projectObjectModel")]
            [System.Text.Json.Serialization.JsonPropertyName("projectObjectModel")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "projectObjectModel",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public ModelsFromOfficialXSD.ProjectObjectModel ProjectObjectModel
            {
                get;
                set;
            }


        }













        public
            Artifact DeserializeFromJSON_Newtonsoft(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Artifact>(json);
        }

        public
            string SerializeToJSON_Newtonsoft()
        {
            /*
                Serialization order:

                "groupId": "androidx.activity",
                "artifactId": "activity",
                "version": "1.1.0",
                "nugetVersion": "1.1.0.4",
                "nugetId": "Xamarin.AndroidX.Activity",

                "artifactIdVersions"
                "artifactIdVersionLatest"
                "nugetVersions"
                "nugetVersionLatest"
                "dependencies"
             */
            List<string> properties_to_serialize = new List<string>
            {
                "groupId",
                "artifactId",
                "version",
                // extended
                "idFullyQualified",
                "versionTextual",
                "groupIndex",
                "versions",
                "versionsTextual",
                "projectObjectModelTextual",
                "projectObjectModel",
                "dependencies",
            };

            //Serialization.Formatters.
                OrderedContractResolver resolver = null;

            resolver = new //Serialization.Formatters.
                OrderedContractResolver(properties_to_serialize);

            string content = Newtonsoft.Json.JsonConvert.SerializeObject
                                                                (
                                                                    this,
                                                                    Newtonsoft.Json.Formatting.Indented,
                                                                    new Newtonsoft.Json.JsonSerializerSettings
                                                                    {
                                                                        ContractResolver = resolver
                                                                    }
                                                                );

            return content;
        }

        public static Artifact DeserializeFromJSON_System_Text_Json(string json)
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

        public static Artifact DeserializeFromXML(string xml)
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

