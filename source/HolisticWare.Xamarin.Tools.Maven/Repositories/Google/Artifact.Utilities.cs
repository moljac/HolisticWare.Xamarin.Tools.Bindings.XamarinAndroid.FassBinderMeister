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
                Task<string>
                                        DownloadProjectObjecModelPOMAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string v = version;
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/{v}/{id}-{v}.pom";

                string response = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await MavenClient.HttpClient.GetStringContentAsync(url);
                }

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadArtifactAndroidArchiveAARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string v = version;
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/{v}/{id}-{v}.aar";

                byte[] response = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await MavenClient.HttpClient.GetByteArrayAsync(url);
                }

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadArtifactJavaArchiveJARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string v = version;
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/{v}/{id}-{v}.jar";

                byte[] response = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await MavenClient.HttpClient.GetByteArrayAsync(url);
                }

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadSourcesJavaArchiveJARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string v = version;
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/{v}/{id}-{v}-sources.jar";

                byte[] response = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await MavenClient.HttpClient.GetByteArrayAsync(url);
                }

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadJavaDocJavaArchiveJARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string v = version;
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/{v}/{id}-{v}-javadoc.jar";

                byte[] response = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await MavenClient.HttpClient.GetByteArrayAsync(url);
                }

                return response;
            }


            public static async
                Task<string>
                                        DownloadModuleAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string v = version;
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/{v}/{id}-{v}.module";

                string response = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    response = await MavenClient.HttpClient.GetStringContentAsync(url);
                }

                return response;
            }

            //------------------------------------------------------------------------------------
            public static async
                Task<byte[]>
                                        DownloadAndSaveArtifactAndroidArchiveAARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                byte[] response = await DownloadAndSaveArtifactAndroidArchiveAARAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.aar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadAndSaveArtifactJavaArchiveJARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                byte[] response = await DownloadArtifactJavaArchiveJARAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.jar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadAndSaveSourcesJavaArchiveJARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                byte[] response = await DownloadSourcesJavaArchiveJARAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.aar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadAndSaveJavaDocJavaArchiveJARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                byte[] response = await DownloadJavaDocJavaArchiveJARAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.aar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

        }
    }
}
