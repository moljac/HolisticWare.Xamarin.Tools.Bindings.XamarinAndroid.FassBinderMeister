using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Models
{
    public class Repository
    {
        public Repository()
        {
            this.Groups = new List<Group>();

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public List<Models.Group> Groups
        {
            get;
            set;
        }
    }
}
