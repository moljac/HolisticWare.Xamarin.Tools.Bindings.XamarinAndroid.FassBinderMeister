using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class Artifact
    {
        public static partial class Utilities
        {
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
}
