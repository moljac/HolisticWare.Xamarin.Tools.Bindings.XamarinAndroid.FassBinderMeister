using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class MavenRepository
    {
        public MavenRepository()
        {
        }

        public virtual async
            Task
                            InitializeAsync
                                        (
                                        )
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
                                            string path = "MavenRepository.newtonsoft.json"
                                        )
        {
            string[] path_parts = path.Split(new[] { "." }, StringSplitOptions.None);
            string format = path_parts[path_parts.Length - 1];
            string library = path_parts[path_parts.Length - 2];

            if (path_parts.Length >= 2)
            {
                library = path_parts[path_parts.Length - 2];
            }

            string content = null;
            string msg = null;

            switch (format)
            {
                case "proto":
                case "protobuf":
                    break;
                case "xml":
                    content = MavenRepository.SerializeToXML(this);
                    break;
                case "json":
                    switch(library)
                    {
                        case "system-text-json":
                            content = MavenRepository.SerializeToJSON_System_Text_Json(this);
                            break;
                        case "newtonsoft":
                            content = MavenRepository.SerializeToJSON_Newtonsoft(this);
                            break;
                        default:
                            msg = $"Unknown serialization format {format}";
                            throw new InvalidProgramException(msg);
                    }
                    break;
                default:
                    msg = $"Unknown serialization format {format}";
                    throw new InvalidProgramException(msg);
            }

            string type_name = this.GetType().Name;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmm");
            string filename = $"{type_name}-{timestamp}.{library}.json";
            //System.IO.File.WriteAllText(filename, content);
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(filename))
            {
                await writer.WriteAsync(content);
            }

            return;
        }

    }
}
