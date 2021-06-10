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
            foreach (KeyValuePair<string, string> kvp in ProjectData.ProjectConfigs)
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(kvp.Value))
                using (HttpContent content = response.Content)
                {
                    string result = await content.ReadAsStringAsync();
                    var binderator_config =
                        JsonSerializer.Deserialize<ConfigRoot>(result);
                }
            }

            return;
        }
    }
}
