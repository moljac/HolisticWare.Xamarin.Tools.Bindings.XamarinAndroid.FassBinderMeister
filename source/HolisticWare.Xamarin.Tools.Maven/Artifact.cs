using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    public partial class Artifact
    {
        public string Id
        {
            get;
            set;
        }

        public List<Artifact> Dependencies
        {
            get;
            set;
        }
    }
}
