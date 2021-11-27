using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Repository
    {
        public static partial class Utilities
        {
            public static async
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

            /// <summary>
            /// Get MasterIndex of the MavenCentralSonatype Maven repository
            /// MavenCentralSonatype Maven repository dos not have pregenerated MasterIndex
            /// parsing HTTP directory output
            /// https://repo1.maven.org/maven2/
            /// </summary>
            /// <returns>Maven.MasterIndex</returns>
            public static async
                Task<Maven.MasterIndex>
                                                GetMasterIndexAsync
                                                        (
                                                        )
            {
                MasterIndex result = null;

                MasterIndexDefault = result;

                return result;
            }
        }
    }
}
