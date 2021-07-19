using System;
using System.Threading.Tasks;

using Core.Net.HTTP;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentralSonatype
{
    public partial class Group : Maven.Group
    {
        public Group(string id, Repository repository = null)
            :
            base(id, repository)
        {
            this.Id = id;
            this.Repository = repository;

            return;
        }

    }
}
