using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Models
{
    public class Project
    {
        public Project()
        {
            return;
        }

        public Group Group
        {
            get;
            set;
        }

        public Artifact Artifact
        {
            get;
            set;
        }
    }
}
