using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolisticWare.Xamarin.Tools.Maven.POM;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Artifact : Maven.ArtifactUnversioned
    {
        /// <summary>
        /// Artifact (Maven Artifact object)
        ///
        /// IdFullyQualified        <groupId>:<artifactId>:<version>
        /// </summary>
        /// <see href="https://maven.apache.org/guides/introduction/introduction-to-the-pom.html#minimal-pom"/>
        static Artifact()
        {
            return;
        }

        public Artifact()
            :
            base()
        {
            return;
        }

        public Artifact
                    (
                        string id_group,
                        string id_artifact
                    )
        {
            this.GroupId = id_group;
            this.ArtifactId = id_artifact;

            return;
        }

        public Artifact
                    (
                        string id_group,
                        string id_artifact,
                        string version
                    )
        {
            this.GroupId = id_group;
            this.ArtifactId = id_artifact;

            return;
        }

        public Artifact(string id_fully_qualified)
        {
            // unversioned:
            //                  androidx.ads.ads-identifier
            //                  androidx.ads:ads-identifier
            // versioned:
            //                  androidx.ads.ads-identifier-1.0.0
            //                  androidx.ads:ads-identifier-1.0.0
            int idx = id_fully_qualified.LastIndexOf('.');

            this.GroupId = id_fully_qualified.Substring(0, idx);
            this.ArtifactId = id_fully_qualified.Substring(idx + 1, id_fully_qualified.Length - (idx + 1));

            return;
        }

        protected static string url_default_textual_root = null;

        public static string UrlDefaultTextualRoot
        {
            get
            {
                return url_default_textual_root;
            }

            set
            {
                url_default_textual_root = value;

                return;
            }
        }

        protected static string url_default_textual_binary = null;

        public static string UrlDefaultTextualBinary
        {
            get
            {
                return url_default_textual_binary;
            }

            set
            {
                url_default_textual_binary = value;

                return;
            }
        }

        protected static string url_default_textual_pom = null;

        public static string UrlDefaultTextualProjectObjectModel
        {
            get
            {
                return url_default_textual_pom;
            }

            set
            {
                url_default_textual_pom = value;

                return;
            }
        }

        protected static string url_default_textual_sources = null;

        public static string UrlDefaultTextualSources
        {
            get
            {
                return url_default_textual_sources;
            }

            set
            {
                url_default_textual_sources = value;

                return;
            }
        }

        protected static string url_default_textual_javadoc = null;

        public static string UrlDefaultTextualJavaDoc
        {
            get
            {
                return url_default_textual_javadoc;
            }

            set
            {
                url_default_textual_javadoc = value;

                return;
            }
        }

        protected static string url_default_textual_module = null;

        /// <summary>
        /// Artifact (unversioned) Metadata
        /// Google Repository Only!
        /// </summary>
        public static string UrlDefaultTextualModule
        {
            get
            {
                return url_default_textual_module;
            }

            set
            {
                url_default_textual_module = value;

                return;
            }
        }

        protected static string url_default_textual_metadata = null;

        /// <summary>
        /// Artifact (unversioned) Metadata
        /// Maven Central / Sonatype Repository Only!
        /// </summary>
        public static string UrlDefaultTextualMetadata
        {
            get
            {
                return url_default_textual_metadata;
            }

            set
            {
                url_default_textual_metadata = value;

                return;
            }
        }

        public Group Group
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public List<string> Versions
        {
            get;
            set;
        }

        public List<System.Version> VersionsDotNet
        {
            get;
            set;
        }

        public List<Artifact> Dependencies
        {
            get;
            set;
        }

        public string ProjectObjectModelTextual
        {
            get;
            set;
        }

        public ProjectObjectModel ProjectObjectModel
        {
            get;
            set;
        }

        public async
            Task<List<string>>
                                        GetVersionsFromGroupIndexAsync
                                                (
                                                )
        {
            Maven.GroupIndex gi = await Maven.Group.Utilities.GetGroupIndexAsync(this.GroupId);

            IEnumerable<(string name, string[] versions)> artifacts_and_versions = null;

            artifacts_and_versions = await gi.GetArtifactNamesAndVersionsAsync();

            IEnumerable<string[]> artifact_versions_filtered = null;

            artifact_versions_filtered =
                                from (string name, string[] versions) av in artifacts_and_versions
                                where av.name == this.ArtifactId
                                select av.versions
                                ;

            List<string> result = artifact_versions_filtered.FirstOrDefault().Reverse().ToList();

            this.VersionsTextual = result;

            return result;
        }


        public static
            IEnumerable<System.Version>
                                        GetVersions
                                                (
                                                    IEnumerable<string> versions_textual
                                                )
        {
            foreach (string vt in versions_textual)
            {
                System.Version v;
                bool parsed = System.Version.TryParse(vt, out v);

                yield return v;
            }
        }

        public static
            IEnumerable<System.Version>
                                    GetVersionsOfBindingsNuGetPackage
                                                (
                                                    IEnumerable<string> versions_textual
                                                )
        {
            foreach (string vt in versions_textual)
            {

                System.Version v;
                bool parsed = System.Version.TryParse(vt, out v);

                yield return v;
            }
        }

        public async
            Task<string>
                                    DownloadArtifactMetadata
                                            (
                                            )
        {
            string gid = this.IdFullyQualified.Replace(".", "/");
            string v = this.VersionTextual;
            string url = $"https://dl.google.com/android/maven2/{gid}/{v}/artifact-metadata.json";

            string response = null;

            try
            {
                response = await MavenClient.HttpClient.GetStringAsync(url);
            }
            catch (Exception exc)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Artifact.DownloadArtifactMetadata Exception");
                sb.AppendLine($"    Message : {exc.Message}");

                System.Diagnostics.Trace.WriteLine(sb.ToString());

                return sb.ToString();
            }

            return response;
        }

        public virtual async
            Task<string>
                                    DownloadProjectObjectModelPOM
                                            (
                                            )
        {
            string response = null;

            return response;
        }

        public virtual async
            Task<ProjectObjectModel.Project>
                                    DeserializeProjectObjectModelPOM
                                            (
                                            )
        {
            ProjectObjectModel.Project result = null;

            return result;
        }

        public virtual async
            Task<POM.ProjectObjectModel>
                                    DeserializeProjectObjectModelPOMFromOfficialXSD
                                            (
                                            )
        {
            POM.ProjectObjectModel result = null;

            return result;
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
                    //content = this.SerializeToJSON_Newtonsoft();
                    break;
            }

            string type_name = this.GetType().FullName;
            string timestamp = DateTime.Now.ToString("yyyyMMdd-HHmmss.ff");
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
