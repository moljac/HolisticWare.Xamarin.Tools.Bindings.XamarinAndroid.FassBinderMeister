using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
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


            public static async
                Task<Uri>
                                                        GetUriAsync
                                                                (
                                                                    string id
                                                                )
            {
                string url = $"{RepositoryDefault.UrlRoot}/{id.Replace('.', '/')}";

                Uri result = null;
                if (await MavenClient.HttpClient.IsReachableUrlAsync(url))
                {
                    result = new Uri(url);
                }

                return result;
            }

            public async static
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
                Uri result = null;

                return result;
            }
        }
    }
}
