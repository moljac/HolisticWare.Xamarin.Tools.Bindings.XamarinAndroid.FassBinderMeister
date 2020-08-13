using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator
{
    public class BinderatorConfig
    {
        public BinderatorConfig()
        {
            return;
        }

        public IEnumerable<QuickType.Config> Config
        {
            get;
            set;
        }
    }
}
