using System;
using System.Collections.Generic;
using System.Text;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public class ReleaseNotesHistory
    {
        public ReleaseNotesHistory()
        {
            return;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }

        public List<ReleaseNote> ReleaseNotes
        {
            get;
            set;
        }

    }
}
