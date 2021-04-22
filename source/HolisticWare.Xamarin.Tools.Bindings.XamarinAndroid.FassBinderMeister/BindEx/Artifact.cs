using System;
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
            this.ArtifactBindingNuget = new ArtifactBindingNuget();

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

        public ArtifactBindingNuget ArtifactBindingNuget
        {
            get;
            set;
        }


        public static
            (string id_group, string id_artifact)
                            Parse
                                        (
                                            string id_fully_qualified
                                        )
        {
            string[] parts1 = null;

            string id_g = null;
            string id_a = null;


            parts1 = id_fully_qualified?.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts1.Length == 2)
            {
                id_g = parts1[0];
                id_a = parts1[1];

                return (id_group: id_g, id_artifact: id_a);
            }

            int? idx_last = id_fully_qualified?.LastIndexOf('.');

            if ( idx_last == null)
            {
                throw new ArgumentException($"Could not parse fully qualified artifact id: {id_fully_qualified}");
            }
            else
            {
                id_g = id_fully_qualified?.Substring(0, idx_last.Value);
                id_a = id_fully_qualified?.Substring(idx_last.Value, id_fully_qualified.Length - idx_last.Value);
            }

            return (id_group: "g", id_artifact: "a");
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
