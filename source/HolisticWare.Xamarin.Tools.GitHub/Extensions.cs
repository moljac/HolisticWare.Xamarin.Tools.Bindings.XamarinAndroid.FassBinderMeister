using System;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    public static class Extensions
    {
        public static string ToJson(this Tag self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }

        public static string ToJson(this User self)
            => JsonConvert.SerializeObject(self, Converter.Settings);

        public static string ToJson(this Organization self)
            => JsonConvert.SerializeObject(self, Converter.Settings);

    }
}
