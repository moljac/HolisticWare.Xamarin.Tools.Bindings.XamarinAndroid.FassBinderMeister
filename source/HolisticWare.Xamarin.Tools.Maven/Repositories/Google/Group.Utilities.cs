using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.Google
{
    public partial class Group
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

            /// <summary>
            /// GetUriAsync
            /// null for Uri - Google Maven Repo has no accessible Group Uri
            /// </summary>
            /// <param name="id">Group Id (Name)</param>
            /// <returns>null</returns>
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

            public static async
                Task<Uri>
                                                        GetUriForGroupIndexAsync
                                                                (
                                                                    Group group
                                                                )
            {
                return await GetUriForGroupIndexAsync(group.Id);
            }

            public static async
                Task<Uri>
                                                        GetUriForGroupIndexAsync
                                                                (
                                                                    string id
                                                                )
            {
                string url = $"{GroupIndex.UrlDefaultTextual.Replace("_PLACEHOLDER_GROUP_ID_", id.Replace('.', '/'))}";

                Uri result = null;

                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    result = new Uri(url);
                }

                return result;
            }

            public static async
                Task<GroupIndex>
                                                        GetGroupIndexAsync
                                                                (
                                                                    string group_id
                                                                )
            {
                GroupIndex result = null;

                Uri uri = await GetUriForGroupIndexAsync(group_id);

                return result;
            }
        }
    }
}
