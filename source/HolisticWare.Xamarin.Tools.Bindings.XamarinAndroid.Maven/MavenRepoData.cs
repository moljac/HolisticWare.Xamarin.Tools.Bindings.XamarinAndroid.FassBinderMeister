using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class MavenRepoData
    {
        public MavenRepoData()
        {
        }

        public async Task InitializeAsync()
        {
            MavenClient mc = new MavenClient();
            this.MasterIndex = await mc.GetMasterIndexAsync();

            await this.MasterIndex.GetGroupNamesAsync();
            await this.MasterIndex.GetGroupIndicesAsync();

            return;
        }

        public MasterIndex MasterIndex
        {
            get;
            set;
        }

        public async
            Task
                            SaveAsync
                                        (
                                            string format = "json"
                                        )
        {
            string content = null;

            switch (format)
            {
                case "json":
                default:
                    content = MavenRepoData.SerializeToJSON_Newtonsoft(this);
                    break;
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmm");
            string filename = $"maven-repo-data-{timestamp}.{format}";
            //System.IO.File.WriteAllText(filename, content);
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(filename))
            {
                await writer.WriteAsync(content);
            }

            return;
        }

    }
}
