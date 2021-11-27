using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Repository
    {
        protected static Uri url_root_default = null;

        public static Uri UrlRootDefault
        {
            get
            {
                return url_root_default;
            }
            set
            {
                url_root_default = value;

                return;
            }
        }

        protected static Uri url_master_index_default = null;

        public static Uri UrlMasterIndexDefault
        {
            get
            {
                return url_master_index_default;
            }
            set
            {
                url_master_index_default = value;

                return;
            }
        }

        protected static MasterIndex master_index_default = null;

        public static MasterIndex MasterIndexDefault
        {
            get
            {
                return master_index_default;
            }
            set
            {
                master_index_default = value;

                return;
            }
        }

        protected Uri url_root = null;

        public Uri UrlRoot
        {
            get
            {
                return url_root;
            }
            set
            {
                url_root = value;

                return;
            }
        }

        protected static Uri url_master_index = null;

        public static Uri UrlMasterIndex
        {
            get
            {
                return url_master_index;
            }
            set
            {
                url_master_index = value;

                return;
            }
        }

        protected MasterIndex master_index = null;

        public MasterIndex MasterIndex
        {
            get
            {
                return master_index;
            }
            set
            {
                master_index = value;

                return;
            }
        }

        protected static Uri url_search_default = null;

        public static Uri UrlSearchDefault
        {
            get
            {
                return url_search_default;
            }
            set
            {
                url_search_default = value;

                return;
            }
        }


        public virtual async
            Task<SearchData>
                                            Search
                                                    (
                                                        string search_term,
                                                        int search_results_count = 20
                                                    )
        {
            SearchData result = null;

            // Discovery

            return result;
        }


        public static async
            Task<MasterIndex>
                                            GetMasterIndexAsync
                                                    (
                                                    )
        {
            MasterIndex result = null;

            // Discovery

            return result;
        }








        public async static
            Task<Repository>
                                        GetRepositoryForGroupAsync
                                                    (
                                                        Group group
                                                    )
        {
            return await GetRepositoryForGroupAsync(group.Id);
        }

        public async static
            Task<Repository>
                                        GetRepositoryForGroupAsync
                                                    (
                                                        string group_id
                                                    )
        {
            Repository r = null;

            if ( await Repositories.Google.Group.Utilities.GetUriAsync(group_id) != null)
            {
                r = new Repositories.Google.Repository();
            }
            else if (await Repositories.MavenCentralSonatype.Group.Utilities.GetUriAsync(group_id) != null)
            {
                r = new Repositories.MavenCentralSonatype.Repository();
            }
            else
            {
                //throw new Exception($"Group not found {group_id}");
            }

            return r;
        }

        public virtual async
            Task<IEnumerable<Group>>
                                            GetGroupsAsync
                                                    (
                                                    )
        {
            IEnumerable<Group> result = null;

            return result;
        }

        public virtual async
            Task<IEnumerable<Group>>
                                            GetGroupIndicesAsync
                                                    (
                                                    )
        {
            IEnumerable<Group> result = null;

            return result;
        }
    }
}
