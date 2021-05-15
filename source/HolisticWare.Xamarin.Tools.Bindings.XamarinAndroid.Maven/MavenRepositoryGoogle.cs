using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    /// <summary>
    /// MavenRepositoryGoogle
    /// </summary>
    /// <see href="https://maven.google.com/web/index.html"/>
    /// <see href="https://dl.google.com/android/maven2/master-index.xml"/>
    /// 
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
    public partial class MavenRepositoryGoogle : MavenRepository
    {
        static MavenRepositoryGoogle()
        {
            UrlDefault = "https://maven.google.com/web/index.html";
            UrlMasterIndexDefault = "https://dl.google.com/android/maven2/master-index.xml";
            UrlGroupIndexDefault = "https://dl.google.com/android/maven2/GROUP_ID/group-index.xml";
            UrlArtifactMetadataDefault = "https://dl.google.com/android/maven2/GROUP_ID/ARTIFACT_ID/group-index.xml";
            return;
        }


        public MavenRepositoryGoogle() : base()
        {

            return;
        }

        public bool
                            ExistsGroup
                                        (
                                            string group_id
                                        )
        {
            string url = MavenRepositoryGoogle.GetUrlForGroupId(group_id);

            Uri uri_result = null;
            bool result_create = Uri.TryCreate(url, UriKind.Absolute, out uri_result);
            bool result_web = uri_result.Scheme == Uri.UriSchemeHttp || uri_result.Scheme == Uri.UriSchemeHttps;

            return result_create && result_web;
        }

        public static
            string
                            GetUrlForGroupId
                                        (
                                            string group_id
                                        )
        {
            string gi = group_id.Replace('.', '\\');
            string url = MavenRepositoryGoogle.UrlGroupIndexDefault.Replace("GROUP_ID", gi);

            return url;
        }

        public static
            string
                            GetUrlForArtifactId
                                        (
                                            string group_id,
                                            string artifact_id
                                        )
        {
            string gi = group_id.Replace('.', '\\');
            string url = MavenRepositoryGoogle.UrlArtifactMetadataDefault
                                                        .Replace("GROUP_ID", gi)
                                                        .Replace("ARTIFACT_ID", artifact_id)
                                                        ;

            return url;
        }

        public override async
            Task
                            InitializeAsync
                                        (
                                        )
        {
            this.MasterIndex = await this.GetMasterIndexAsync();

            await this.MasterIndex.GetGroupIndicesAsync();

            return;
        }

        public virtual async
            Task<MasterIndex>
                            GetMasterIndexAsync
                                        (
                                        )
        {
            MasterIndex mi = new MasterIndexGoogle();

            return mi;
        }
    }
}
