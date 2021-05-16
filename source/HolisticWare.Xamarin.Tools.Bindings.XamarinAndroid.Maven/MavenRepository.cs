using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    /// <summary>
    /// MavenRepository
    /// </summary>
    /// https://maven.google.com/web/index.html
    /// https://maven.google.com/web/index.html#android.arch.core:common:1.0.0
    ///
    /// https://dl.google.com/android/maven2/master-index.xml
    /// https://dl.google.com/android/maven2/androidx/arch/core/group-index.xml
    ///
    /// Artifact metadata - 
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// https://dl.google.com/android/maven2/androidx/activity/activity/1.3.0-alpha07/artifact-metadata.json
    ///
    /// Artifact POM
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/core-common-2.0.0.pom
    /// 
    /// dl.google.com/android/maven2/ artifact-metadata.json
    ///
    /// https://search.maven.org/
    /// 
    /// https://search.maven.org/search?q=a:tensorflow-lite
    /// https://search.maven.org/artifact/org.tensorflow/tensorflow-lite
    /// https://search.maven.org/remotecontent?filepath=org/tensorflow/tensorflow-lite/2.4.0/tensorflow-lite-2.4.0.aar
    /// https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/
    /// https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/maven-metadata.xml
    /// https://search.maven.org/solrsearch/select?q=opencensus&start=0&rows=200
    ///
    /// https://mvnrepository.com/
    /// 
    /// https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/2.4.0/
    /// https://repo1.maven.org/maven2/org/tensorflow/tensorflow-lite/
    public abstract partial class MavenRepository
    {
        protected MavenClient maven_client = null;

        static  MavenRepository()
        {
            return;
        }

        public MavenRepository()
        {
            return;
        }

        public virtual MavenClient MavenClient
        {
            get;
            set;
        }

        protected static string url_default = null;

        public static string UrlDefault
        {
            get
            {
                return url_default;
            }
            protected set
            {
                url_default = value;
            }
        }

        protected static string url_master_index_default = null;

        public static string UrlMasterIndexDefault
        {
            get
            {
                return url_master_index_default;
            }
            protected set
            {
                url_master_index_default = value;
            }
        }

        protected static string url_group_index_default = null;

        public static string UrlGroupIndexDefault
        {
            get
            {
                return url_group_index_default;
            }
            protected set
            {
                url_group_index_default = value;
            }
        }

        protected static string url_artifact_metadata_default = null;

        public static string UrlArtifactMetadataDefault
        {
            get
            {
                return url_artifact_metadata_default;
            }
            protected set
            {
                url_artifact_metadata_default = value;
            }
        }

        public virtual MasterIndex MasterIndex
        {
            get;
            set;
        }


        public abstract 
            Task
                            InitializeAsync
                                        (
                                        );


        public async
            Task<Group>
                            GetGroupAsync
                                        (
                                            string group_id
                                        )
        {
            return null;
        }

        /// <summary>
        /// Detect Maven Repository for given artifact
        /// </summary>
        /// <param name="id_fully_qualified"></param>
        /// <returns></returns>
        public static
            IEnumerable<MavenRepository>
                            DetectMavenRepository
                                        (
                                            string id_fully_qualified
                                        )
        {
            (string id_group, string id_artifact, string version) a = Artifact.Parse(id_fully_qualified);

            string url = null;

            MavenRepository mr_google = null;
            try
            {
                url = MavenRepositoryGoogle.GetUrlForGroupId(a.id_group);

                if (url != null)
                {
                    mr_google = new MavenRepositoryGoogle();
                }
            }
            catch (System.Exception exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Artifact.DetectMavenRepository Exception for MavenRepositoryGoogle");
                sb.AppendLine($"    Message : {exc.Message}");
                sb.AppendLine($"    Artifact Id Fully Qualified: {id_fully_qualified}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                throw;
            }

            yield return mr_google;

            //try
            //{
            //    mr = new MavenRepositoryMavenCentral();

            //}
            //catch (System.Exception exc)
            //{
            //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //    sb.AppendLine($"Artifact.DetectMavenRepository Exception for MavenRepositoryMavenCentral");
            //    sb.AppendLine($"    Message : {exc.Message}");
            //    sb.AppendLine($"    Artifact Id Fully Qualified: {id_fully_qualified}");

            //    System.Diagnostics.Trace.WriteLine(sb.ToString());

            //    throw;
            //}

            //return;
        }

        public virtual async
            Task<GroupIndex>
                            GetGroupIndexAsync
                                        (
                                            string group_id
                                        )
        {

            return null;
        }

        public virtual async
            Task<IEnumerable<GroupIndex>>
                                                GetGroupIndicesAsync
                                                    (
                                                    )
        {
            IEnumerable<GroupIndex> group_indices = null;

            return group_indices;
        }

        public virtual async
            Task<Artifact>
                            GetArtifactAsync
                                        (
                                            string group_id,
                                            string artifact_id
                                        )
        {

            return null;
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
