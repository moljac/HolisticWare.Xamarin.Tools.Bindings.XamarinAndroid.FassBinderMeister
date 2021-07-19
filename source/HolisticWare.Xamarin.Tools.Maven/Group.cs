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

        protected string id = null;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;

                return;
            }
        }

        protected static Repository repository_default = null;

        public static Repository RepositoryDefault
        {
            get
            {
                return repository_default;
            }

            set
            {
                repository_default = value;

                return;
            }
        }

        protected Repository repository = null;

        public virtual Repository Repository
        {
            get
            {
                return repository;
            }

            set
            {
                repository = value;

                return;
            }
        }

        protected static string url_default_textual = null;

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

        protected static Uri url_default = null;

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

        protected Uri url = null;

        public virtual Uri Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;

                return;
            }
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

        protected Uri url_group_index = null;

        public virtual Uri UrlGroupIndex
        {
            get
            {
                return url_group_index;
            }

            set
            {
                url_group_index = value;

                return;
            }
        }

        protected static GroupIndex group_index_default = null;

        public static GroupIndex GroupIndexDefault
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

        protected GroupIndex group_index = null;

        public virtual GroupIndex GroupIndex
        {
            get
            {
                return group_index;
            }

            set
            {
                group_index = value;

                return;
            }
        }

    }
}
