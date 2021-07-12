using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public partial class Group
    {
        public Group(string id, Repository repository = null)
        {
            this.Id = id;
            this.Repository = repository;

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public static Repository RepositoryDefault
        {
            get;
            set;
        }

        public virtual Repository Repository
        {
            get;
            set;
        }

        public async static
            Task<Uri>
                                                    GetUriForGroupAsync
                                                            (
                                                                Group group
                                                            )
        {
            return await GetUriForGroupAsync(group.Id);
        }


        public async static
            Task<Uri>
                                                    GetUriForGroupAsync
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
    }
}
