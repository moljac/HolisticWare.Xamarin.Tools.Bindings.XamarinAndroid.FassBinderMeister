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
            return await c.IsReachableUrlAsync(new Uri(url));
        }

        public static async
            Task<bool>
                                    IsReachableUrlAsync
                                                (
                                                    this HttpClient c,
                                                    Uri uri
                                                )
        {
            bool is_reachable = false;

            try
            {
                using (HttpResponseMessage result = await c?.GetAsync(uri.AbsoluteUri))
                {
                    HttpStatusCode status_code = result.StatusCode;
                    switch (status_code)
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
            }
            catch (Exception exc)
            {
                string msg = exc.Message;

                throw;
            }

            return is_reachable;
        }

        public static async
            Task<string>
                                    GetStringContentAsync
                                                (
                                                    this HttpClient c,
                                                    string url
                                                )
        {
            return await c.GetStringContentAsync(new Uri(url));
        }

        public static async
            Task<string>
                                    GetStringContentAsync
                                                (
                                                    this HttpClient c,
                                                    Uri uri
                                                )
        {
            string content_textual = null;

            using (System.Net.Http.HttpResponseMessage response = await c.GetAsync(uri.AbsoluteUri))
            {
                if (response.IsSuccessStatusCode)
                {
                    using (System.Net.Http.HttpContent content = response.Content)
                    {
                        content_textual = await response.Content.ReadAsStringAsync();
                    }
                }
            }

            return content_textual;
        }
    }
}
