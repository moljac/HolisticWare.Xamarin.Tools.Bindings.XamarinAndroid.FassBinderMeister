using System;
using System.Threading.Tasks;
using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Artifact
    {
        public static partial class Utilities
        {
            public static
                (string id_group, string id_artifact, string version)
                                            ParseArtifactIdFullyQualified
                                                (
                                                    string id_fully_qualified
                                                )
            {
                string[] parts1 = null;

                string id_g = null;
                string id_a = null;
                string version = null;


                parts1 = id_fully_qualified?.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts1.Length == 2)
                {
                    id_g = parts1[0];
                    id_a = parts1[1];

                    return (id_group: id_g, id_artifact: id_a, version: version);
                }
                else if (parts1.Length == 3)
                {
                    id_g = parts1[0];
                    id_a = parts1[1];
                    version = parts1[2];

                    return (id_group: id_g, id_artifact: id_a, version: version);
                }
                else if (parts1.Length == 1)
                {
                    // No Op - string did not contain ':'
                }
                else
                {
                    throw new InvalidOperationException($"Fully qualified artifact name error");
                }

                int? idx_last = id_fully_qualified?.LastIndexOf('.');

                if (idx_last == null)
                {
                    throw new ArgumentException($"Could not parse fully qualified artifact id: {id_fully_qualified}");
                }
                else
                {
                    id_g = id_fully_qualified?.Substring(0, idx_last.Value);
                    id_a = id_fully_qualified?.Substring(idx_last.Value + 1, id_fully_qualified.Length - idx_last.Value - 1);
                }

                return (id_group: id_g, id_artifact: id_a, version: version);
            }
        }

        public static async
            Task<byte[]>
                                    DownloadArtifactAndroidArchiveAARAsync
                                            (
                                                string group_id,
                                                string artifact_id,
                                                string version,
                                                string filename = null
                                            )
        {
            string id = artifact_id;
            string idg_url = group_id.Replace(".", "/");
            string v = version;
            string url = $"{Repository.UrlRootDefault}/{idg_url}/{v}/{id}-{v}.aar";

            byte[] response = null;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                response = await MavenClient.HttpClient.GetByteArrayAsync(url);
            }

            if (string.IsNullOrEmpty(filename))
            {
                filename = $"{group_id}.{artifact_id}-{version}.aar";
            }

            return response;
        }

        public static async
            Task<byte[]>
                                    DownloadArtifactJavaArchiveJARAsync
                                            (
                                                string group_id,
                                                string artifact_id,
                                                string version,
                                                string filename = null
                                            )
        {
            string id = artifact_id;
            string idg_url = group_id.Replace(".", "/");
            string v = version;
            string url = $"{Repository.UrlRootDefault}/{idg_url}/{v}/{id}-{v}.jar";

            byte[] response = null;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                response = await MavenClient.HttpClient.GetByteArrayAsync(url);
            }

            if (string.IsNullOrEmpty(filename))
            {
                filename = $"{group_id}.{artifact_id}-{version}.jar";
            }

            return response;
        }

        public static async
            Task<byte[]>
                                    DownloadSourcesJavaArchiveJARAsync
                                            (
                                                string group_id,
                                                string artifact_id,
                                                string version,
                                                string filename = null
                                            )
        {
            string id = artifact_id;
            string idg_url = group_id.Replace(".", "/");
            string v = version;
            string url = $"{Repository.UrlRootDefault}/{idg_url}/{v}/{id}-{v}-sources.jar";

            byte[] response = null;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                response = await MavenClient.HttpClient.GetByteArrayAsync(url);
            }

            if (string.IsNullOrEmpty(filename))
            {
                filename = $"{group_id}.{artifact_id}-{version}-sources.jar";
            }

            return response;
        }

        public static async
            Task<byte[]>
                                    DownloadJavaDocJavaArchiveJARAsync
                                            (
                                                string group_id,
                                                string artifact_id,
                                                string version,
                                                string filename = null
                                            )
        {
            string id = artifact_id;
            string idg_url = group_id.Replace(".", "/");
            string v = version;
            string url = $"{Repository.UrlRootDefault}/{idg_url}/{v}/{id}-{v}-javadoc.jar";

            byte[] response = null;

            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                response = await MavenClient.HttpClient.GetByteArrayAsync(url);
            }

            if (string.IsNullOrEmpty(filename))
            {
                filename = $"{group_id}.{artifact_id}-{version}-javadoc.jar";
            }

            return response;
        }
    }
}
