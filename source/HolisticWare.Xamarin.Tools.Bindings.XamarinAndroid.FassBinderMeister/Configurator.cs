using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
    public class Configurator
    {
        public Configurator()
        {
            this.Repositories = new List<Models.Repository>();

            this.Projects = new List<Models.Project>();

            return;
        }

        public List<Models.Repository> Repositories
        {
            get;
            set;
        }

        public List<Models.Project> Projects
        {
            get;
            set;
        }

    }
}
