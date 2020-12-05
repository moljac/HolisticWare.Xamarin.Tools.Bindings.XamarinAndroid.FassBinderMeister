﻿using System;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    /// <summary>
    /// 
    /// </summary>
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// dl.google.com/android/maven2/ artifact-metadata.json
    public partial class Artifact : HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Artifact
    {
        public Artifact()
            : base()
        {
            this.ArtifactBindingNugetData = new ArtifactBindingNugetData();

            return;
        }

        public Artifact(string id_fully_qualified)
            : base(id_fully_qualified)
        {

            return;
        }

        public Artifact(string id_group, string id_artifact)
            : base (id_group, id_artifact)
        {

            return;
        }

        public ArtifactBindingNugetData ArtifactBindingNugetData
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
                    content = Artifact.SerializeToJSON_Newtonsoft(this);
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
