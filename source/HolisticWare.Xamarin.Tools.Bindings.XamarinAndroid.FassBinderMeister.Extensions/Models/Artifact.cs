using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Models
{
    public class Artifact
    {
        public Artifact()
        {
            this.Versions = new List<Version>();

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public List<Version> Versions
        {
            get;
            set;
        }

    }
}
