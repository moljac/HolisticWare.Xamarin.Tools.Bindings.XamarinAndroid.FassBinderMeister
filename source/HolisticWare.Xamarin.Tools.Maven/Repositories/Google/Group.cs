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
                                            GroupIndex.UrlDefault
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
            repository_default = new Repositories.Google.Repository();

            // group is not browseable/accessible
            url_default_textual = null;

            // group is not browseable/accessible
            url_default = null;

            // group index
            url_group_index_default = Repositories.Google.GroupIndex.UrlDefault;

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

        public static string UrlDefaultTextual
        {
            get
            {
                return url_default_textual;
            }

            set
            {
                url_default_textual = value;

                return;
            }
        }

        public static Uri UrlDefault
        {
            get
            {
                return url_default;
            }

            set
            {
                url_default = value;

                return;
            }
        }

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

        public virtual Uri Url
        {
            get
            {
                Uri url_tmp = Group.Utilities.GetUriForGroupIndexAsync(this.Id).Result;

                if (MavenClient.HttpClient.IsReachableUrlAsync(url_tmp).Result)
                {
                    this.url = url_tmp;
                }

                return this.url;
            }

            set
            {
                this.url = value;

                return;
            }
        }

        public static Maven.GroupIndex GroupIndexDefault
        {
            get
            {
                return group_index_default;
            }

            set
            {
                group_index_default = value;

                return;
            }
        }

        public virtual GroupIndex GroupIndex
        {
            get;
            set;
        }



    }
}
