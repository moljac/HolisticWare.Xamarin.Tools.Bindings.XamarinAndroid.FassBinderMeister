using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    public partial class MasterIndex
    {
        public MavenRepository MavenRepository
        {
            get;
            set;
        }

        public virtual string Content
        {
            get;
            set;
        }

        public virtual IEnumerable<string> GroupsTextual
        {
            get;
            set;
        }

        public virtual string Url
        {
            get;
            set;
        }


        public virtual async
            Task<IEnumerable<GroupIndex>>
                                                GetGroupIndicesAsync
                                                    (
                                                    )
        {
            if(MavenRepository == null)
            {
                return null;
            }

            IEnumerable<GroupIndex> group_indices = null;

            group_indices = await this.MavenRepository.GetGroupIndicesAsync();

            return group_indices;
        }

    }
}
