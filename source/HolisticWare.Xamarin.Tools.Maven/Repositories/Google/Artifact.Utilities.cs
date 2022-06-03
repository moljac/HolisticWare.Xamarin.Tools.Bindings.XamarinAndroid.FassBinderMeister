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
                Task<string>
                                        DeserializaProjectObjecModelPOMAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string pom = await Utilities.DownloadProjectObjecModelPOMAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                return pom;
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

            public static async
                Task
                    <
                    (
                        string pom,
                        byte[] aar,
                        byte[] jar,
                        byte[] jar_javadoc,
                        byte[] jar_sources,
                        string module
                    )
                    >
                                        DownloadAllAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version
                                                )
            {
                string result_pom = null;
                byte[] result_aar = null;
                byte[] result_jar = null;
                byte[] result_jar_javadoc = null;
                byte[] result_jar_sources = null;
                string result_module = null;

                // cannot use Pralallel.ForEachAsync because of different return types
                Parallel.Invoke
                    (
                        async () =>
                        {
                            result_pom = await DownloadProjectObjecModelPOMAsync
                                                          (
                                                              group_id,
                                                              artifact_id,
                                                              version
                                                          );
                        }
                    );

                Parallel.Invoke
                    (
                        async () =>
                        {
                            result_aar = await DownloadArtifactAndroidArchiveAARAsync
                                                          (
                                                              group_id,
                                                              artifact_id,
                                                              version
                                                          );
                        }
                    );

                Parallel.Invoke
                    (
                        async () =>
                        {
                            result_jar = await DownloadArtifactJavaArchiveJARAsync
                                                          (
                                                              group_id,
                                                              artifact_id,
                                                              version
                                                          );
                        }
                    );

                Parallel.Invoke
                    (
                        async () =>
                        {
                            result_jar_javadoc = await DownloadJavaDocJavaArchiveJARAsync
                                                          (
                                                              group_id,
                                                              artifact_id,
                                                              version
                                                          );
                        }
                    );

                Parallel.Invoke
                    (
                        async () =>
                        {
                            result_jar_sources = await DownloadSourcesJavaArchiveJARAsync
                                                              (
                                                              group_id,
                                                              artifact_id,
                                                              version
                                                          );
                        }
                    );

                Parallel.Invoke
                    (
                        async () =>
                        {
                            result_module = await DownloadModuleAsync
                                                          (
                                                              group_id,
                                                              artifact_id,
                                                              version
                                                          );
                        }
                    );

                return
                    (
                        pom: result_pom,
                        aar: result_aar,
                        jar: result_jar,
                        jar_javadoc: result_jar_javadoc,
                        jar_sources: result_jar_sources,
                        module: result_module
                    );
            }
            //------------------------------------------------------------------------------------
            public static async
                Task<string>
                                        DownloadThenSaveProjectObjecModelPOMAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                string response = await DownloadProjectObjecModelPOMAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.pom";
                }

                System.IO.File.WriteAllText(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadThenSaveArtifactAndroidArchiveAARAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                byte[] response = await DownloadArtifactAndroidArchiveAARAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.aar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadThenSaveArtifactJavaArchiveJARAsync
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

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.jar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadThenSaveSourcesJavaArchiveJARAsync
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

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}-sources.jar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<byte[]>
                                        DownloadThenSaveJavaDocJavaArchiveJARAsync
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

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}-javadoc.jar";
                }

                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<string>
                                        DownloadThenSaveModuleAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version,
                                                    string filename = null
                                                )
            {
                string response = await DownloadModuleAsync
                                                (
                                                    group_id,
                                                    artifact_id,
                                                    version
                                                );

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"google-repo--{group_id}.{artifact_id}-{version}.pom";
                }

                System.IO.File.WriteAllText(filename, response);

                return response;
            }

        }
    }
}
