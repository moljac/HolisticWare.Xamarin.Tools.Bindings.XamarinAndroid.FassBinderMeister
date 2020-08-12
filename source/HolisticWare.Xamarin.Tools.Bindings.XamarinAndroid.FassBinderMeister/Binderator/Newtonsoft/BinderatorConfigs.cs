using System.Collections.Generic;

using Newtonsoft.Json;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class BinderatorConfigs
    {
        [JsonProperty("ConfigArray")]
        public List<ConfigRoot> ConfigArray { get; set; }
    }

}
