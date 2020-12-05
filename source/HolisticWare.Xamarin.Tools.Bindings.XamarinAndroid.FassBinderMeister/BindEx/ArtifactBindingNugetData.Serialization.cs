using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NuGet.Protocol.Core.Types;
using global::NuGet.Packaging;

using HolisticWare.Xamarin.Tools.NuGet;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    // POCO class with Metadata for Buddy Class containing attributes
    [
        // Microsoft.AspNetCore.Mvc.ModelMetadataType
        Core.Serialization.ModelMetadataType
        (
            typeof(Serialization.Formatters.ArtifactBindingNugetData)
        )
    ]
    public partial class ArtifactBindingNugetData
    {
    }
}
