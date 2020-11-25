using System;
using System.Collections.Generic;


namespace HolisticWare.Xamarin.Tools.GitHub.Serialization.Formatters
{
    public class Tags
    {
        [Newtonsoft.Json.JsonProperty("name")]
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "name",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public string Name
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("zipball_url")]
        [System.Text.Json.Serialization.JsonPropertyName("zipball_url")]
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "zipball_url",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public Uri ZipballUrl
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("tarball_url")]
        [System.Text.Json.Serialization.JsonPropertyName("tarball_url")]
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "tarball_url",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public Uri TarballUrl
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("commit")]
        [System.Text.Json.Serialization.JsonPropertyName("commit")]
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "commit",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public Commit Commit
        {
            get;
            set;
        }

        [Newtonsoft.Json.JsonProperty("node_id")]
        [System.Text.Json.Serialization.JsonPropertyName("node_id")]
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "node_id",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public string NodeId
        {
            get;
            set;
        }
    }
}
