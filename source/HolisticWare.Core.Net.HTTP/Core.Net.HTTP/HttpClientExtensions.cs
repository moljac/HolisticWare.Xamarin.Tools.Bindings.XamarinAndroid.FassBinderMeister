using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Net.HTTP
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class HttpClientExtensions
    {
        public static async
            Task<bool>
                                    IsReachableUrlAsync
                                                (
                                                    this HttpClient c,
                                                    string url
                                                )
        {
            bool is_reachable = false;

            using (HttpResponseMessage result = await c.GetAsync(url))
            {
                HttpStatusCode StatusCode = result.StatusCode;
                switch (StatusCode)
                {

                    case HttpStatusCode.Accepted:
                        is_reachable = true;
                        break;
                    case HttpStatusCode.OK:
                        is_reachable = true;
                        break;
                    default:
                        is_reachable = false;
                        break;
                }
            }

            return is_reachable;
        }
    }
}
