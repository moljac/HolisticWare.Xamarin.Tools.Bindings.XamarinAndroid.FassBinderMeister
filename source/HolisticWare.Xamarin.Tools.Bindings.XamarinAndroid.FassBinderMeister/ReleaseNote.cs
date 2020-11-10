using System;
using System.Collections.Generic;
using System.Text;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public class ReleaseNote
    {
        public ReleaseNote()
        {
            this.Artifacts = new List<string>();

            return;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public List<string> Artifacts
        {
            get;
            set;
        }

    }
}
