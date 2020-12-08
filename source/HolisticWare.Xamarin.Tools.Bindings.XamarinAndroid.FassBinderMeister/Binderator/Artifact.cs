using System;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator
{
    /// <summary>
    /// 
    /// </summary>
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// dl.google.com/android/maven2/ artifact-metadata.json
    public partial class Artifact
    {
        public Artifact()
        {
            return;
        }

        public Artifact(string id_group, string id_artifact)
        {
            this.GroupId = id_group;
            this.ArtifactId = id_artifact;

            return;
        }

        public Artifact(string id_fully_qualified)
        {
            int idx = id_fully_qualified.LastIndexOf('.');

            this.GroupId = id_fully_qualified.Substring(0, idx);
            this.ArtifactId = id_fully_qualified.Substring(idx + 1, id_fully_qualified.Length - (idx + 1));

            return;
        }

        /*
            "groupId": "androidx.car",
            "artifactId": "car",
            "version": "1.0.0-alpha7",
            "nugetVersion": "1.0.0.3-alpha7",
            "nugetId": "Xamarin.AndroidX.Car.Car",
            "dependencyOnly": false
         */

        public string GroupId
        {
            get;
            set;
        }

        public string ArtifactId
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public string NugetVersion
        {
            get;
            set;
        }

        public string NugetId
        {
            get;
            set;
        }

        public bool DependencyOnly
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

            string type_name = this.GetType().FullName;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmssmm");
            string filename = $"{type_name}-{timestamp}.{format}";
            //System.IO.File.WriteAllText(filename, content);
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(filename))
            {
                await writer.WriteAsync(content);
            }

            return;
        }
    }
}
