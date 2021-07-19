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

            this.UrlGroup = null;
            this.UrlGroupIndex = new Uri
                                        (
                                            Group
                                                .UrlGroupIndexDefault
                                                    .AbsoluteUri
                                                        .Replace
                                                            (
                                                                "_PLACEHOLDER_GROUP_ID_",
                                                                this.Id.Replace('.', '/')
                                                            )
                                        );
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
                url_group_index_default = value;

                return;
            }
        }

        public virtual Uri UrlGroup
        {
            get;
            set;
        }

        public virtual Uri UrlGroupIndex
        {
            get
            {
                Uri url = Utilities.GetUriForGroupIndexAsync(this.Id).Result;

                if (MavenClient.HttpClient.IsReachableUrlAsync(url).Result)
                {
                    url_group_index = url;
                }

                return url;
            }

            set
            {
                url_group_index = value;

                return;
            }
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



    }
}
