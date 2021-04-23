using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
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

        public MavenClient()
        {
            HttpClient.DefaultRequestHeaders
                            .Add
                                (
                                    "User-Agent",
                                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                                )
                            /*                             
                            .UserAgent.Add(new ProductInfoHeaderValue($"{github_app_name}", $"{version}"))
                            */
                            ;

            return;
        }

        public async
            Task<MasterIndex>
                            GetMasterIndexAsync
                                                (
                                                )
        {
            MasterIndex mi = new MasterIndex();

            return mi;
        }
    }
}
