using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Maven.Serialization.Formatters
{
    /// <summary>
    /// Artifact Buddy Class
    /// </summary>
    public class Artifact
    {
        [Newtonsoft.Json.JsonProperty("id")]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "id",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public string Id
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
    }
}

