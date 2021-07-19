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

        protected Uri url_group_index = null;

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

    }
}
