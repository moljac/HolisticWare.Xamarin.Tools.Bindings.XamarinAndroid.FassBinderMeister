using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class Group
    {
        public Group(string id, Repository repository = null)
        {
            this.Id = id;
            this.Repository = repository;

            return;
        }

        static Group()
        {
            url_group_default = null;
            url_group_index_default = $"{Repository.UrlRootDefault}/_PLACEHOLDER_GROUP_/group-index.xml";

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

        protected static string url_group_default = null;

        public static string UrlGroupDefault
        {
            get;
            set;
        }

        protected static string url_group_index_default = null;

        public static string UrlGroupIndexDefault
        {
            get
            {
                return url_group_index_default;
            }
            set
            {

            }
        }

        public virtual string UrlGroup
        {
            get;
            set;
        }

        public virtual string UrlGroupIndex
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



        public static async
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
            string url = $"{RepositoryDefault.UrlRoot}/{id.Replace('.', '/')}/group-index.xml";

            Uri result = null;
            if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
            {
                result = new Uri(url);
            }

            return result;
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


        public static async
            Task<Uri>
                                                    GetUriForGroupAsync
                                                            (
                                                                string id
                                                            )
        {
            Uri result = null;

            return result;
        }

        public static async
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
