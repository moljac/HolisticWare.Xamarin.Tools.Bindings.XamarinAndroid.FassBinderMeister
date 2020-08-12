using System.Collections.Generic;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Template
    {
        [JsonProperty("templateFile")]
        public string TemplateFile { get; set; }

        [JsonProperty("outputFileRule")]
        public string OutputFileRule { get; set; }
    }

}
