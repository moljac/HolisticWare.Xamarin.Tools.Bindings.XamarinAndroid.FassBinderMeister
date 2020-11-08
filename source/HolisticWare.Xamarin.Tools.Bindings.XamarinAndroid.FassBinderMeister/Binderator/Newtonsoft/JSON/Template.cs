using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // POCO class with Metadata for Buddy Class containing attributes
    // <PackageReference Include="Microsoft.AspNetCore.Mvc.DataAnnotations" Version="2.2.0" />
    // using Microsoft.AspNetCore.Mvc;
    [ModelMetadataType(typeof(JSON.Template))]
    public partial class Template
    {
        public static Template Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Template>(json);
        }

    }
}

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft.JSON
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public partial class Template
    {
        [JsonProperty("templateFile")]
        public string TemplateFile
        {
            get;
            set;
        }

        [JsonProperty("outputFileRule")]
        public string OutputFileRule
        {
            get;
            set;
        }
    }

}
