using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
   public class ConfigData
    {
        public ConfigData()
        {

        }

        public string CachePathPattern
        {
            get;
            set;
        } = "BinderatorConfigData/PROJECT/TIMESTAMP/config.json";

        public async Task<List<string>> LoadConfigsContentAsync(List<string> timestamps, string project)
        {
            string[] directories = System.IO.Directory.GetDirectories(this.CachePathPattern.Replace("PROJECT", project));
            List<string> configs_strings = new List<string>();

            return configs_strings;
        }
    }
}
