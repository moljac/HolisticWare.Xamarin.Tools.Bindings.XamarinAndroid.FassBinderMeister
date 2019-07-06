using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Models
{
    public class Group
    {
        public Group()
        {
            this.Artifacts = new List<Artifact>();

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public List<Artifact> Artifacts
        {
            get;
            set;
        }
    }
}
