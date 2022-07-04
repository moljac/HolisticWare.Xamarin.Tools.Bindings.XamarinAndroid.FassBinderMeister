using System.Net;
using System.Net.Http;

namespace Tests.CommonShared
{
    public static class Http
    {
        static Http()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            client = new HttpClient(handler);
        }

        private static HttpClient client;

        public static HttpClient Client
            => client;
    }
}
