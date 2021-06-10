using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HolisticWare.Xamarin.Tools.NuGet.ServerAPI
{
    public partial class NuGetClient
    {
        public static HttpClient HttpClient
        {
            get;
            set;
        }

    }
}
