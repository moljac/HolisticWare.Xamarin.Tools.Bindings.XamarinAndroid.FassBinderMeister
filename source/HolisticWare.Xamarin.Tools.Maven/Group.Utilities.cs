using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Group
    {
        public static partial class Utilities
        {
            public async static
                Task<Uri>
                                                        GetUriForGroupIndexAsync
                                                                (
                                                                    Group group
                                                                )
            {
                return await GetUriForGroupIndexAsync(group.Id);
            }


            public async static
                Task<Uri>
                                                        GetUriForGroupIndexAsync
                                                                (
                                                                    string id
                                                                )
            {
                string url = $"{RepositoryDefault.UrlRoot}/{id.Replace('.', '/')}/group-index.xml";

                Uri result = null;
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    result = new Uri(url);
                }

                return result;
            }

            public async static
                Task<GroupIndex>
                                                        GetGroupIndexAsync
                                                                (
                                                                    Group group
                                                                )
            {
                return await GetGroupIndexAsync(group.Id);
            }

            public async static
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
