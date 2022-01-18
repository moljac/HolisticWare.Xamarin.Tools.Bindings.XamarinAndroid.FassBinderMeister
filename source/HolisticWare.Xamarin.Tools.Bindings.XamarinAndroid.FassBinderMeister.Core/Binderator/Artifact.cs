using System;
using System.Collections.Generic;
using System.Linq;
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

        public Artifact
                            (
                                string id_group,
                                string id_artifact,
                                string version = "0.0.0"
                            )
        {
            this.GroupId = id_group;
            this.ArtifactId = id_artifact;
            this.Version = version;

            string[] group_id_parts = this.GroupId.Split(new[] { "." }, StringSplitOptions.None);

            this.NugetId = string.Join
                                    (
                                        ".",
                                        group_id_parts
                                            .Concat(new string[] { id_artifact })
                                            .Select(name => char.ToUpper(name[0]) + name.Substring(1))
                                            //.ToArray() // Un-Lazy/Fleissig for debugging
                                    );

            this.NugetVersion = this.Version;

            return;
        }

        public Artifact
                            (
                                string id_fully_qualified,
                                string version = "0.0.0"
                            )
        {
            int idx = id_fully_qualified.LastIndexOf('.');

            this.GroupId = id_fully_qualified.Substring(0, idx);
            this.ArtifactId = id_fully_qualified.Substring(idx + 1, id_fully_qualified.Length - (idx + 1));
            this.Version = version;

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
                                            string path = "MavenRepository.newtonsoft-json.json"
                                        )
        {
            string[] path_parts = path.Split(new[] { "." }, StringSplitOptions.None);
            string format = path_parts[path_parts.Length - 1];
            string library = path_parts[path_parts.Length - 2];

            if (path_parts.Length >= 2)
            {
                library = path_parts[path_parts.Length - 2];
            }

            System.IO.MemoryStream stream = null;
            string content = null;
            string msg = null;

            switch (format)
            {
                case "binary":
                case "bin":
                    switch (library)
                    {
                        case "system-runtime-serialization":
                            stream = this.SerializeToBinary
                                            (
                                                library = "System.Runtime.Serialization"
                                            );
                            break;
                        case "protobuf-net":
                            stream = this.SerializeToBinary
                                            (
                                                library = "protobuf-net"
                                            );
                            break;
                        default:
                            msg = $"Unknown serialization format {format}";
                            throw new InvalidProgramException(msg);
                    }
                    break;
                case "xml":
                    content = this.SerializeToXML();
                    break;
                case "json":
                    switch (library)
                    {
                        case "system-text-json":
                            content = this.SerializeToJSON
                                                    (
                                                        library = "System.Text.Json"
                                                    );
                            break;
                        case "newtonsoft-json":
                            content = this.SerializeToJSON
                                                    (
                                                        library = "Newtonsoft.Json"
                                                    );
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
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmssff");
            library = library.ToLower().Replace('.', '-');
            string filename = $"{timestamp}-{type_name}.{library}.{format}";

            if ( ! string.IsNullOrEmpty(content))
            {
                //System.IO.File.WriteAllText(filename, content);
                using
                    (
                        System.IO.StreamWriter writer = System.IO.File.CreateText(filename)
                    )
                {
                    await writer.WriteAsync(content);
                    writer.Flush();
                    writer.Close();
                }
            }
            else if ( stream != null)
            {
                using
                    (
                        System.IO.FileStream fs = new System.IO.FileStream
                                                                (
                                                                    filename,
                                                                    System.IO.FileMode.Create,
                                                                    System.IO.FileAccess.Write
                                                                )
                    )
                {
                    stream.WriteTo(fs);
                    fs.Flush();
                    fs.Close();
                }
            }
            else
            {
                msg = "Data (Serialized object) not saved!";
                throw new InvalidOperationException(msg);
            }

            return;
        }

        public static async
            Task<Artifact>
                            LoadAsync
                                        (
                                            string path
                                        )
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            string[] path_parts = path.Split(new[] { "." }, StringSplitOptions.None);
            string format = path_parts[path_parts.Length - 1];
            string library = path_parts[path_parts.Length - 2];

            string content = null;
            using (System.IO.StreamReader reader = System.IO.File.OpenText(path))
            {
                content = await reader.ReadToEndAsync();
            }

            Artifact object_deserialized = null;

            switch (format)
            {
                case "json":
                default:
                    object_deserialized = Artifact.DeserializeFromJSON(content);
                    break;
            }

            return object_deserialized;
        }
    }
}
