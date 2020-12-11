using System.Collections.Generic;
using System.Linq;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
//namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Serialization.Formatters
{

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

