using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public partial class Group : Maven.Group
    {
        public Group(string id, Repository repository = null)
            :
            base(id, repository)
        {
            this.Id = id;
            this.Repository = repository;

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public static Repository RepositoryDefault
        {
            get;
            set;
        }

        public virtual Repository Repository
        {
            get;
            set;
        }


        public static Uri UrlGroupDefault
        {
            get;
            set;
        }

        public virtual Uri UrlGroup
        {
            get;
            set;
        }

        public static Uri UrlGroupIndexDefault
        {
            get;
            set;
        }

        public virtual Uri UrlGroupIndex
        {
            get;
            set;
        }

        public static GroupIndex GroupIndexDefault
        {
            get;
            set;
        }

        public virtual GroupIndex GroupIndex
        {
            get;
            set;
        }

        public async static
            Task<Uri>
                                                    GetUriForGroupAsync
                                                            (
                                                                Group group
                                                            )
        {
            return await GetUriForGroupAsync(group.Id);
        }


        public async static
            Task<Uri>
                                                    GetUriForGroupIndexAsync
                                                            (
                                                                Group group
                                                            )
        {
            return await GetUriForGroupAsync(group.Id);
        }


        public static async
            Task<Uri>
                                                    GetUriForGroupIndexAsync
                                                            (
                                                                string id
                                                            )
        {
            Uri result = null;

            return result;
        }

        public static async
            Task<Uri>
                                                    GetUriForGroupAsync
                                                            (
                                                                string id
                                                            )
        {
            string url = $"{RepositoryDefault.UrlRoot}/{id.Replace('.', '/')}";

            Uri result = null;
            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                result = new Uri(url);
            }

            return result;
        }
    }
}
