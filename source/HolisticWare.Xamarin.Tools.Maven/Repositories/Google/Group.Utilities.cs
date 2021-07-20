using System;
using System.Collections.Generic;
using System.Linq;
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
                                                                    Group group
                                                                )
            {
                return await GetGroupIndexAsync(group.Id);
            }

            public static async
                Task<GroupIndex>
                                                        GetGroupIndexAsync
                                                                (
                                                                    string group_id
                                                                )
            {
                return await Google.GroupIndex.Utilities.GetGroupIndexAsync(group_id);
            }

            public static async
                Task<List<string>>
                                                        GetGroupsMissingForPrefixAsync
                                                                (
                                                                    string prefix,
                                                                    string[] groups_available
                                                                )
            {
                HashSet<string> result = new HashSet<string>();

                Array.Sort<string>(groups_available);

                Maven.MasterIndex master_index = await Repositories.Google.Repository.Utilities.GetMasterIndexAsync();

                string[] maven_index_groups =
                                        (
                                            from Maven.Group g in master_index.Groups
                                                select g.Id
                                        ).ToArray<string>();

                HashSet<string> groups_available_hashed = new HashSet<string>(groups_available);

                foreach (string group in maven_index_groups)
                {
                    if (group.StartsWith(prefix))
                    {
                        bool contains = false;

                        foreach (string group_available in groups_available)
                        {
                            if (group.Contains(group_available))
                            {
                                contains = true;
                            }
                        }

                        if (! contains)
                        {
                            result.Add(group);
                        }
                    }
                }

                return result.ToList<string>();
            }

            public static async
                Task<List<string>>
                                                        GetGroupsMissingForContentAsync
                                                                (
                                                                    string content,
                                                                    string[] groups_available
                                                                )
            {
                HashSet<string> result = new HashSet<string>();

                Array.Sort<string>(groups_available);

                Maven.MasterIndex master_index = await Repositories.Google.Repository.Utilities.GetMasterIndexAsync();

                string[] maven_index_groups =
                                        (
                                            from Maven.Group g in master_index.Groups
                                            select g.Id
                                        ).ToArray<string>();

                HashSet<string> groups_available_hashed = new HashSet<string>(groups_available);

                foreach (string group in maven_index_groups)
                {
                    if (group.Contains(content))
                    {
                        bool contains = false;

                        foreach (string group_available in groups_available)
                        {
                            if (group.Contains(group_available))
                            {
                                contains = true;
                            }
                        }

                        if (!contains)
                        {
                            result.Add(group);
                        }
                    }
                }

                return result.ToList<string>();
            }

        }
    }
}
