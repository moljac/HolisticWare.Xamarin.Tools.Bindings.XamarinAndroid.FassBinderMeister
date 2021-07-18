using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
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

        static Group()
        {
            url_group_default = null;
            url_group_index_default = new Uri($"{Repository.UrlRootDefault}/_PLACEHOLDER_GROUP_ID_/group-index.xml");

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

        protected static Uri url_group_default = null;

        public static Uri UrlGroupDefault
        {
            get;
            set;
        }

        protected static Uri url_group_index_default = null;

        public static Uri UrlGroupIndexDefault
        {
            get
            {
                return url_group_index_default;
            }
            set
            {

            }
        }

        public virtual Uri UrlGroup
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
