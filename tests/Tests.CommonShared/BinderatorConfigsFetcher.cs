using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft;

namespace Tests.CommonShared
{
    public static class BinderatorConfigsFetcher
    {
        public static HttpClient HttpClient
        {
            get;
            set;
        } = Tests.CommonShared.Http.Client;

        static BinderatorConfigsFetcher()
        {
            return;
        }

        public async static
            Task
            InitializeAsync
                                                (
                                                )
        {
            foreach (KeyValuePair<string, string> kvp in ProjectData.ProjectConfigUrls)
            {
                HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync(kvp.Value);
                //HttpContent content = response.Content;

                string content_textual =
                                            // await client.GetStringAsync(kvp.Value)
                                            client.GetStringAsync(kvp.Value).Result
                                            ;

                //using (HttpClient client = new HttpClient())
                //using (HttpResponseMessage response = await client.GetAsync(kvp.Value))
                //using (HttpContent content = response.Content)
                {
                    string result =
                                        // await content.ReadAsStringAsync()
                                        content_textual
                                        ;
                    ConfigRoot binderator_config = JsonSerializer.Deserialize<ConfigRoot>(result);
                }
            }

            return;
        }
    }
}
