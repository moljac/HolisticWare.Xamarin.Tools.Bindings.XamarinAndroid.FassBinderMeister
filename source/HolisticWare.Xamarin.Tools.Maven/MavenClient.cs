using System;
using System.Net.Http;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class MavenClient
    {
        // HttpClient is intended to be instantiated once per application,
        // rather than per-use. See Remarks.
        public static HttpClient HttpClient
        {
            get;
            set;
        }
    }
}
