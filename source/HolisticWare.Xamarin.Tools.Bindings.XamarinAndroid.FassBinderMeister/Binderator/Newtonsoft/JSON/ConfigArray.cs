using System.Collections.Generic;

using Newtonsoft.Json;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public partial class ConfigArray
    {
        [JsonProperty("ConfigArray")]
        public List<ConfigRoot> ConfigArrays { get; set; }
    }

}
