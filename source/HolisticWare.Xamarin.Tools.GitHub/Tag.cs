using System;

using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    public partial class Tag
    {
        public string Name
        {
            get;
            set;
        }

        public Uri ZipballUrl
        {
            get;
            set;
        }

        public Uri TarballUrl
        {
            get;
            set;
        }

        public Commit Commit
        {
            get;
            set;
        }

        public string NodeId
        {
            get;
            set;
        }

    }

}

