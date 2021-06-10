using System;
using System.Collections.Generic;
using System.Text;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public static partial class ProjectData
    {
        public static Dictionary<string, string> ProjectConfigs
        {
            get;
            set;
        } = new Dictionary<string, string>()
        {
            {
                "AndroidX",
                "https://raw.githubusercontent.com/xamarin/AndroidX/main/config.json"
            },
            {
                "GooglePlayServices with AndroidX",
                "https://raw.githubusercontent.com/xamarin/GooglePlayServicesComponents/main/config.json"
            },
            {
                "GooglePlayServices with Android.Support",
                "https://raw.githubusercontent.com/xamarin/GooglePlayServicesComponents/71.x.y.z-legacy-Android.Support/config.json"
            },
            {
                "Android.Support",
                "https://raw.githubusercontent.com/xamarin/AndroidSupportComponents/master/config.json"
            },
            {
                "XamarinComponents Android Kotlin",
                "https://raw.githubusercontent.com/xamarin/XamarinComponents/main/Android/Kotlin/config.json"
            },
        };
    }
}
