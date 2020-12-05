using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx.Serialization.Formatters
{
    /// <summary>
    /// Artifact Buddy Class
    /// </summary>
    public class Artifact
    {
        [Newtonsoft.Json.JsonProperty("id", Order = 1)]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        // System.Text.Json.Serialization.Json
        //  does not hve Order Property
        // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
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

