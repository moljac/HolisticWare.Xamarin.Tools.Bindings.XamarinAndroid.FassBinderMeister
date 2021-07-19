using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class GroupIndex
    {
        public static partial class Utilities
        {
            public async static
                Task<Uri>
                                                        GetUriAsync
                                                                (
                                                                    Group group
                                                                )
            {
                return await GetUriAsync(group.Id);
            }

            public static async
                Task<Uri>
                                                        GetUriAsync
                                                                (
                                                                    string id
                                                                )
            {
                Uri result = null;

                return result;
            }
        }
    }
}
