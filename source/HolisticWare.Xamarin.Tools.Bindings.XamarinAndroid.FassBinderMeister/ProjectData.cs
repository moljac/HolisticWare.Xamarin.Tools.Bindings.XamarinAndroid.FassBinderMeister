using System;
using System.Collections.Generic;
using System.Text;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    class ProjectData
    {
        public Dictionary<string, string> ProjectConfigs
        {
            get;
            set;
        } = new Dictionary<string, string>()
        {
            {
                "AndroidX",
                "https://github.com/xamarin/AndroidX/blob/master/config.json"
            },
            {
                "GooglePlayServices with Android.Support",
                "https://github.com/xamarin/GooglePlayServicesComponents/blob/master/config.json"
            },
            {
                "GooglePlayServices with Android.Support",
                "https://github.com/xamarin/GooglePlayServicesComponents/blob/master_based_androidx/config.json"
            },
            {
                "Android.Support",
                "https://github.com/xamarin/AndroidSupportComponents/blob/master/config.json"
            },
        };
    }
}
