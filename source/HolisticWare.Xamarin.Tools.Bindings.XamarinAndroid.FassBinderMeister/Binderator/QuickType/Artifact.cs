﻿using Newtonsoft.Json;

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuHolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BinderatorickType;
//
//    var config = Config.FromJson(jsonString);

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.QuickType
{

    public partial class Artifact
    {
        public string ArtifactIdDependencies
        {
            get;
            set;
        }

        public string NugetIdDependencies
        {
            get;
            set;
        }
    }
}
