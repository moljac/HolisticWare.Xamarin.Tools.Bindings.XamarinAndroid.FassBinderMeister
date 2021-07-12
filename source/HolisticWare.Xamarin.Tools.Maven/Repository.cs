using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Repository
    {
        protected static string url_root_default = null;

        public static string UrlRootDefault
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

        protected static string url_master_index_default = null;

        public static string UrlMasterIndexDefault
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

        protected string url_root = null;

        public string UrlRoot
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

            if ( await Repositories.Google.Group.GetUriForGroupAsync(group_id) != null)
            {
                r = new Repositories.Google.Repository();
            }
            else if (await Repositories.MavenCentralSonatype.Group.GetUriForGroupAsync(group_id) != null)
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
            Task<GroupIndex>
                                            GetGroupIndexAsync
                                                    (
                                                        string group_id
                                                    )
        {

            return null;
        }

        public virtual async
            Task<IEnumerable<GroupIndex>>
                                            GetGroupIndicesAsync
                                                    (
                                                    )
        {
            IEnumerable<GroupIndex> group_indices = null;

            return group_indices;
        }
    }
}
