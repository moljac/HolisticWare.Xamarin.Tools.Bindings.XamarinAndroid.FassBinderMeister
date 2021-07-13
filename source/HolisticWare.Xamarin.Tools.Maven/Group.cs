using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Group
    {
        public Group(string id, Repository repository = null)
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
                                                    GetUriForGroupIndexAsync
                                                            (
                                                                Group group
                                                            )
        {
            return await GetUriForGroupIndexAsync(group.Id);
        }


        public async static
            Task<Uri>
                                                    GetUriForGroupIndexAsync
                                                            (
                                                                string id
                                                            )
        {
            string url = $"{RepositoryDefault.UrlRoot}/{id.Replace('.', '/')}/group-index.xml";

            Uri result = null;
            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                result = new Uri(url);
            }

            return result;
        }

        public async static
            Task<GroupIndex>
                                                    GetGroupIndexAsync
                                                            (
                                                                Group group
                                                            )
        {
            return await GetGroupIndexAsync(group.Id);
        }

        public async static
            Task<GroupIndex>
                                                    GetGroupIndexAsync
                                                            (
                                                                string group_id
                                                            )
        {
            GroupIndex result = null;

            Uri uri = await GetUriForGroupIndexAsync(group_id);


            return result;
        }
    }
}
