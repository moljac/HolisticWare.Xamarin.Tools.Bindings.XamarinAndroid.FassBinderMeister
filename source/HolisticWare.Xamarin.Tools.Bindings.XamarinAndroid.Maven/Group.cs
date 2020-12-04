using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class Group
    {
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

        public (string name, string[] versions) GroupIndexTextual
        {
            get;
            set;
        }

        public GroupIndex GroupIndex
        {
            get;
            set;
        }

    }
}
