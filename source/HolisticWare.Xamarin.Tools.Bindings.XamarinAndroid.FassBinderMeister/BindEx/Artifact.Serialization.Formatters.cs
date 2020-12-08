using System.Collections.Generic;
using System.Linq;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    /// <summary>
    /// Artifact Buddy Class
    /// </summary>
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
        public new class ArtifactSerializationMetadata
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
            [Newtonsoft.Json.JsonProperty("groupId")]
            [System.Text.Json.Serialization.JsonPropertyName("groupId")]
            // System.Text.Json.Serialization.Json
            //  does not hve Order Property
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
            //  does not hve Order Property
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
            public Maven.ModelsFromOfficialXSD.ProjectObjectModel ProjectObjectModel
            {
                get;
                set;
            }


            [Newtonsoft.Json.JsonProperty("artifactBindingNuget")]
            [System.Text.Json.Serialization.JsonPropertyName("artifactBindingNuget")]
            [System.Xml.Serialization.XmlElement
                                            (
                                                ElementName = "artifactBindingNuget",
                                                Namespace = "http://holisticware.net"
                                            )
            ]
            public ArtifactBindingNuget ArtifactBindingNuget
            {
                get;
                set;
            }
        }

        internal class OrderedContractResolver
            :
            Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver
        // Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            private IList<string> properties_to_serialize = null;

            public OrderedContractResolver(IList<string> list)
            {
                properties_to_serialize = list;
            }

            protected override
                IList<Newtonsoft.Json.Serialization.JsonProperty>
                                        CreateProperties
                                                (
                                                    System.Type t,
                                                    Newtonsoft.Json.MemberSerialization ms
                                                )
            {
                if (t.Name.Contains("ArtifactSerializationMetadata"))
                {

                }
                IList<Newtonsoft.Json.Serialization.JsonProperty> properties = null;
                properties = base.CreateProperties(t, ms);

                var p2 = properties.Where(p => properties_to_serialize.Contains(p.PropertyName));

                var p3 = p2.ToList();

                foreach (Newtonsoft.Json.Serialization.JsonProperty prop in properties)
                {
                    prop.Order = properties_to_serialize.IndexOf(prop.PropertyName) + 1;
                }

                var list_ordered = properties.OrderBy(p => p.Order).ToList();


                return list_ordered;
            }
        }


    }
}

