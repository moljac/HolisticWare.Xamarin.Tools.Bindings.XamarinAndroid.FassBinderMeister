using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
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

                System.Diagnostics.Trace.WriteLine($"Url = {url}");
                System.Diagnostics.Trace.WriteLine("       probing");
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    System.Diagnostics.Trace.WriteLine($"       downloading {url}");
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

                System.Diagnostics.Trace.WriteLine($"Url = {url}");
                System.Diagnostics.Trace.WriteLine("       probing");
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    System.Diagnostics.Trace.WriteLine($"       downloading {url}");
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

                System.Diagnostics.Trace.WriteLine($"Url = {url}");
                System.Diagnostics.Trace.WriteLine("       probing");
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    System.Diagnostics.Trace.WriteLine($"       downloading {url}");
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

                System.Diagnostics.Trace.WriteLine($"Url = {url}");
                System.Diagnostics.Trace.WriteLine("       probing");
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    System.Diagnostics.Trace.WriteLine($"       downloading {url}");
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

                System.Diagnostics.Trace.WriteLine($"Url = {url}");
                System.Diagnostics.Trace.WriteLine("       probing");
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    System.Diagnostics.Trace.WriteLine($"       downloading {url}");
                    response = await MavenClient.HttpClient.GetByteArrayAsync(url);
                }

                return response;
            }

            public static async
                Task<string>
                                        DownloadMetadataAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version = null
                                                )
            {
                string id = artifact_id;
                string idg_url = group_id.Replace(".", "/");
                string url = $"{Repository.UrlRootDefault}/{idg_url}/{id}/maven-metadata.xml";

                string response = null;

                System.Diagnostics.Trace.WriteLine($"Url = {url}");
                System.Diagnostics.Trace.WriteLine("       probing");
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    System.Diagnostics.Trace.WriteLine($"       downloading {url}");
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
                        string metadata
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
                string result_metadata = null;

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
                            result_metadata = await DownloadMetadataAsync
                                                          (
                                                              group_id,
                                                              artifact_id
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
                        metadata: result_metadata
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

                System.Diagnostics.Trace.WriteLine($"  saving to file {filename}");
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

                System.Diagnostics.Trace.WriteLine($"  saving to file {filename}");
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

                System.Diagnostics.Trace.WriteLine($"  saving to file {filename}");
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

                System.Diagnostics.Trace.WriteLine($"  saving to file {filename}");
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

                System.Diagnostics.Trace.WriteLine($"  saving to file {filename}");
                System.IO.File.WriteAllBytes(filename, response);

                return response;
            }

            public static async
                Task<string>
                                        DownloadThenSaveMetadataAsync
                                                (
                                                    string group_id,
                                                    string artifact_id,
                                                    string version = null,
                                                    string filename = null
                                                )
            {
                string response = await DownloadMetadataAsync
                                                (
                                                    group_id,
                                                    artifact_id
                                                );

                if (response == null)
                {
                    return response;
                }

                if (string.IsNullOrEmpty(filename))
                {
                    filename = $"mavencentralsonatype-repo--{group_id}.{artifact_id}--maven-metadata.xml";
                }

                System.Diagnostics.Trace.WriteLine($"   saving to file: {filename}");
                System.IO.File.WriteAllText(filename, response);

                return response;
            }
        }
    }
}
