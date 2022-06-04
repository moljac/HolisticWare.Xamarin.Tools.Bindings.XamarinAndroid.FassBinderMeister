// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
/*
https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/1.1.1.1/xamarin.androidx.compose.material.ripple.nuspec
https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/1.1.1.1/xamarin.androidx.compose.material.ripple.1.1.1.1.nupkg


https://api.nuget.org/v3/registration5-semver1/xamarin.androidx.compose.material.ripple/index.json
https://api.nuget.org/v3/registration5-semver2/xamarin.androidx.compose.material.ripple/index.json
https://api.nuget.org/v3/registration3/xamarin.androidx.compose.material.ripple/1.1.1.1.json


https://api.nuget.org/v3/index.json


      "@id": "https://api.nuget.org/v3//{id-lower}/index.json",




https://www.nuget.org/packages/Xamarin.AndroidX.Compose.Material.Ripple
*/

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;





    public enum Id { XamarinAndroidXComposeAnimation, XamarinAndroidXComposeFoundation, XamarinAndroidXComposeRuntime, XamarinAndroidXComposeUiUtil, XamarinKotlinStdLibCommon };

    public enum DependencyType { PackageDependency };

    public enum TargetFramework { MonoAndroid120, MonoAndroid90, Net60Android310 };

    public enum DependencyGroupType { PackageDependencyGroup };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DependencyGroupTypeConverter.Singleton,
                DependencyTypeConverter.Singleton,
                IdConverter.Singleton,
                TargetFrameworkConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DependencyGroupTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DependencyGroupType) || t == typeof(DependencyGroupType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "PackageDependencyGroup")
            {
                return DependencyGroupType.PackageDependencyGroup;
            }
            throw new Exception("Cannot unmarshal type DependencyGroupType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DependencyGroupType)untypedValue;
            if (value == DependencyGroupType.PackageDependencyGroup)
            {
                serializer.Serialize(writer, "PackageDependencyGroup");
                return;
            }
            throw new Exception("Cannot marshal type DependencyGroupType");
        }

        public static readonly DependencyGroupTypeConverter Singleton = new DependencyGroupTypeConverter();
    }

    internal class DependencyTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DependencyType) || t == typeof(DependencyType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "PackageDependency")
            {
                return DependencyType.PackageDependency;
            }
            throw new Exception("Cannot unmarshal type DependencyType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DependencyType)untypedValue;
            if (value == DependencyType.PackageDependency)
            {
                serializer.Serialize(writer, "PackageDependency");
                return;
            }
            throw new Exception("Cannot marshal type DependencyType");
        }

        public static readonly DependencyTypeConverter Singleton = new DependencyTypeConverter();
    }

    internal class IdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Id) || t == typeof(Id?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Xamarin.AndroidX.Compose.Animation":
                    return Id.XamarinAndroidXComposeAnimation;
                case "Xamarin.AndroidX.Compose.Foundation":
                    return Id.XamarinAndroidXComposeFoundation;
                case "Xamarin.AndroidX.Compose.Runtime":
                    return Id.XamarinAndroidXComposeRuntime;
                case "Xamarin.AndroidX.Compose.UI.Util":
                    return Id.XamarinAndroidXComposeUiUtil;
                case "Xamarin.Kotlin.StdLib.Common":
                    return Id.XamarinKotlinStdLibCommon;
            }
            throw new Exception("Cannot unmarshal type Id");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Id)untypedValue;
            switch (value)
            {
                case Id.XamarinAndroidXComposeAnimation:
                    serializer.Serialize(writer, "Xamarin.AndroidX.Compose.Animation");
                    return;
                case Id.XamarinAndroidXComposeFoundation:
                    serializer.Serialize(writer, "Xamarin.AndroidX.Compose.Foundation");
                    return;
                case Id.XamarinAndroidXComposeRuntime:
                    serializer.Serialize(writer, "Xamarin.AndroidX.Compose.Runtime");
                    return;
                case Id.XamarinAndroidXComposeUiUtil:
                    serializer.Serialize(writer, "Xamarin.AndroidX.Compose.UI.Util");
                    return;
                case Id.XamarinKotlinStdLibCommon:
                    serializer.Serialize(writer, "Xamarin.Kotlin.StdLib.Common");
                    return;
            }
            throw new Exception("Cannot marshal type Id");
        }

        public static readonly IdConverter Singleton = new IdConverter();
    }

    internal class TargetFrameworkConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TargetFramework) || t == typeof(TargetFramework?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "MonoAndroid12.0":
                    return TargetFramework.MonoAndroid120;
                case "MonoAndroid9.0":
                    return TargetFramework.MonoAndroid90;
                case "net6.0-android31.0":
                    return TargetFramework.Net60Android310;
            }
            throw new Exception("Cannot unmarshal type TargetFramework");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TargetFramework)untypedValue;
            switch (value)
            {
                case TargetFramework.MonoAndroid120:
                    serializer.Serialize(writer, "MonoAndroid12.0");
                    return;
                case TargetFramework.MonoAndroid90:
                    serializer.Serialize(writer, "MonoAndroid9.0");
                    return;
                case TargetFramework.Net60Android310:
                    serializer.Serialize(writer, "net6.0-android31.0");
                    return;
            }
            throw new Exception("Cannot marshal type TargetFramework");
        }

        public static readonly TargetFrameworkConverter Singleton = new TargetFrameworkConverter();
    }
}
