using System;

using Newtonsoft.Json;

// for buddy classes
using Microsoft.AspNetCore.Mvc;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        Microsoft.AspNetCore.Mvc.ModelMetadataType
        //Core.Serialization.ModelMetadataType
        (
            typeof(HolisticWare.Xamarin.Tools.GitHub.Serialization.Formatters.Tag)
        )
    ]
    public partial class Tag
    {
        public static Tag Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Tag>(json, Converter.Settings);
        }
    }
}
