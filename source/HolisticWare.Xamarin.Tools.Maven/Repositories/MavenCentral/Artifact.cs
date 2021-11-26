using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral
{
    public partial class Artifact : Maven.Artifact
    {
        static Artifact()
        {
            // $"https://dl.google.com/android/maven2/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_"
            url_default_textual_root = $"{Repository.UrlRootDefault}/_PLACEHOLDER_GROUP_ID_/_PLACEHOLDER_ARTIFACT_ID_/_PLACEHOLDER_VERSION_/_PLACEHOLDER_ARTIFACT_ID_-_PLACEHOLDER_VERSION_";
            url_default_textual_binary = $"{url_default_textual_root}._PLACEHOLDER_BINARY_EXTENSION_";
            url_default_textual_pom = $"{url_default_textual_root}.pom";
            url_default_textual_sources = $"{url_default_textual_root}-sources.jar";
            url_default_textual_javadoc = $"{url_default_textual_root}-javadoc.jar";
            url_default_textual_module = $"{url_default_textual_root}.module";

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
            this.VersionTextual = version;

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

        public virtual async
            Task<string>
                                    DownloadProjectObjectModelPOMAsync
                                            (
                                            )
        {
            string id = this.ArtifactId;
            string idfq = this.IdFullyQualified.Replace(".", "/");
            string v = this.VersionTextual;
            string url = $"https://dl.google.com/android/maven2/{idfq}/{v}/{id}-{v}.pom";

            string response = null;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                response = await MavenClient.HttpClient.GetStringAsync(url);
            }

            #if DEBUG
            string id_g = this.GroupId;
            string id_a = this.ArtifactId;
            System.IO.File.WriteAllText($"{id_g}.{id_a}-pom.xml", response);
            #endif

            return response;
        }

        public virtual async
            Task<POM.ProjectObjectModel.Project>
                                    DeserializeProjectObjectModelPOMAsync
                                            (
                                            )
        {
            string content = await DownloadProjectObjectModelPOMAsync();

            if (null == content)
            {
                return null;
            }

            System.Xml.Serialization.XmlSerializer xs = null;
            xs = new System.Xml.Serialization.XmlSerializer(typeof(POM.ProjectObjectModel.Project));

            POM.ProjectObjectModel.Project result;

            using (System.IO.TextReader tr = new System.IO.StringReader(content))
            {
                result = (POM.ProjectObjectModel.Project)xs.Deserialize(tr);
            }

            return result;
        }

        public virtual async
           Task<Dictionary<string, Artifact>>
                                   DependencyTreeAsync
                                           (
                                                Dictionary<string, Artifact> dictionary
                                           )
        {


            return dictionary;
        }
    }
}
