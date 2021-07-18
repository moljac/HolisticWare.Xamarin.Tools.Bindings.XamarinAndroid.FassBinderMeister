using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    /// <summary>
    /// MasterIndex - index of all group ids
    /// Google                  Maven Repository     -   available
    /// MavenCentralSonatype    Maven Repository     -   not available
    /// MavenCentralSonatype    Maven Repository     -   built from HTML
    /// </summary>
    public partial class MasterIndex : Maven.MasterIndex
    {

        public override async
            Task<IEnumerable<string>>
                                                GetGroupsTextualAsync
                                                    (
                                                    )
        {
            List<string> result = new List<string>();

            return result;
        }

        public override async
            Task<IEnumerable<Maven.Group>>
                                                GetGroupsAsync
                                                    (
                                                    )
        {
            List<Maven.Group> result = new List<Maven.Group>();

            return result;
        }

    }
}
