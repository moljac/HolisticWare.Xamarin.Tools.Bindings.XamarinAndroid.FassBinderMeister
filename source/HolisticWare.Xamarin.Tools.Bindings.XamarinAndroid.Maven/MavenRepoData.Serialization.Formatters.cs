using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Serialization.Formatters
{
    public partial class MavenRepoData
    {
        [Newtonsoft.Json.JsonProperty("master_index", Order = 1)]
        [System.Text.Json.Serialization.JsonPropertyName("master_index")]
        // System.Text.Json.Serialization.Json
        //  does not hve Order Property
        // https://stackoverflow.com/questions/59134564/net-core-3-order-of-serialization-for-jsonpropertyname-system-text-json-seria
        [System.Xml.Serialization.XmlElement
                                        (
                                            ElementName = "master_index",
                                            Namespace = "http://holisticware.net"
                                        )
        ]
        public MasterIndex MasterIndex
        {
            get;
            set;
        }

    }
}
