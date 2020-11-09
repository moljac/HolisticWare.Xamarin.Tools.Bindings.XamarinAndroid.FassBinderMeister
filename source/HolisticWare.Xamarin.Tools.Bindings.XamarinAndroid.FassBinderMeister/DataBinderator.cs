using System;
using System.Collections.Generic;
using System.Text;

using HolisticWare.Xamarin.Tools.GitHub;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public class DataBinderator
    {
        public static IEnumerable<Tag> Tags
        {
            get;
            set;
        }

        public static string TagsAsJSON
        {
            get;
            set;
        }
    }
}
