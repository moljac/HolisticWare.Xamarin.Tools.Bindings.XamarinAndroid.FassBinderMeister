using System;
using System.Net.Http;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class MavenClient
    {
        /// <summary>
        /// HttpClient object
        /// best practice to create one HttpClient per Application and inject it
        /// 
        /// HttpClient is intended to be instantiated once per application, rather than per-use.
        /// </summary>
        public static HttpClient HttpClient
        {
            get;
            set;
        }
    }
}
