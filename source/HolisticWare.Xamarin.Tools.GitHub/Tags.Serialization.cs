using System;
using System.Collections.Generic;

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
            typeof(HolisticWare.Xamarin.Tools.GitHub.Serialization.Formatters.Tags)
        )
    ]
    public partial class Tags
    {
        public static IEnumerable<Tag> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Tag>>(json, Converter.Settings);
        }

    }
}
