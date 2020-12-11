using System;
using System.Collections.Generic;
using System.Linq;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.Serialization
{
    /// <summary>
    /// Very few serialization frameworks do use ModelMetadataType
    ///
    /// The best option for framework is to have Identical class (name and properties)
    /// with serialization attributes and then copy the data
    ///
    /// TODO: source code generator!
    /// </summary>
    [
        Microsoft.AspNetCore.Mvc.ModelMetadataType
        //System.ComponentModel.DataAnnotations.MetadataType
        //Core.Serialization.ModelMetadataType
        (
            //typeof(Serialization.Formatters.Artifact)
            typeof(Binderator.Artifact)
        )
    ]
    [ProtoBuf.ProtoContract]
    [Serializable]
    public partial class Artifact
    {
        public Artifact()
        {
            return;
        }

        public Artifact(Binderator.Artifact a)
        {
            this.GroupId = a.GroupId;
            this.ArtifactId = a.ArtifactId;
            this.Version = a.Version;
            this.NugetVersion = a.NugetVersion;
            this.NugetId = a.NugetId;
            this.DependencyOnly = a.DependencyOnly;

            return;
        }

        static Artifact()
        {
            /*
                Serialization order:

                "groupId": "androidx.car",
                "artifactId": "car",
                "version": "1.0.0-alpha7",
                "nugetVersion": "1.0.0.3-alpha7",
                "nugetId": "Xamarin.AndroidX.Car.Car",
                "dependencyOnly": false
             */
            SerializationOrder = new List<string>
                                            {
                                                "groupId",
                                                "artifactId",
                                                "version",
                                                "nugetVersion",
                                                "nugetId",
                                                "dependencyOnly",
                                            };

            InitializeSerialization();

            return;
        }

        public static List<string> SerializationOrder
        {
            get;
            set;
        }

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
        [ProtoBuf.ProtoMember(1)]
        public string GroupId
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
        [ProtoBuf.ProtoMember(2)]
        public string ArtifactId
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("version")]
        [System.Text.Json.Serialization.JsonPropertyName("version")]
        // System.Text.Json.Serialization.Json
        //  does not have Order Property
        // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "version",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        [ProtoBuf.ProtoMember(3)]
        public string Version
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("nugetVersion")]
        [System.Text.Json.Serialization.JsonPropertyName("nugetVersion")]
        // System.Text.Json.Serialization.Json
        //  does not have Order Property
        // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "nugetVersion",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        [ProtoBuf.ProtoMember(4)]
        public string NugetVersion
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("nugetId")]
        [System.Text.Json.Serialization.JsonPropertyName("nugetId")]
        // System.Text.Json.Serialization.Json
        //  does not have Order Property
        // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "nugetId",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        [ProtoBuf.ProtoMember(5)]
        public string NugetId
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("dependencyOnly")]
        [System.Text.Json.Serialization.JsonPropertyName("dependencyOnly")]
        // System.Text.Json.Serialization.Json
        //  does not have Order Property
        // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "dependencyOnly",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        [ProtoBuf.ProtoMember(6)]
        public bool DependencyOnly
        {
            get;
            set;
        }


        internal static OrderedContractResolver resolver = null;

        public static
            Dictionary<string, object>
                            SerializationSettings
        {
            get;
            set;
        }

        public static
            void
                                    InitializeSerialization
                                                            (
                                                            )
        {
            resolver = new OrderedContractResolver
                                (
                                    Artifact.SerializationOrder
                                );

            SerializationSettings = new Dictionary<string, object>()
            {
                {
                    "Newtonsoft.Json",
                    new Newtonsoft.Json.JsonSerializerSettings
                    {
                        ContractResolver = resolver
                    }
                },
                {
                    "System.Text.Json",
                    new System.Text.Json.JsonSerializerOptions
                    {
                        WriteIndented = true
                    }
                },
            };

        }

    }


    internal class OrderedContractResolver
        :
        Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver
    //Newtonsoft.Json.Serialization.DefaultContractResolver
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
            //if (t.Name.Contains("ArtifactSerializationMetadata"))
            //{

            //}

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
