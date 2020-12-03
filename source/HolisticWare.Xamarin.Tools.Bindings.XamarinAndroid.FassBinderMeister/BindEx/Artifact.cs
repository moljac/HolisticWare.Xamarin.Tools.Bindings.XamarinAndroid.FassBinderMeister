
namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    /// <summary>
    /// 
    /// </summary>
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// dl.google.com/android/maven2/ artifact-metadata.json
    public partial class Artifact : HolisticWare.Xamarin.Tools.Maven.Artifact
    {
        public Artifact()
            : base()
        {
            this.ArtifactBindingNugetData = new ArtifactBindingNugetData();

            return;
        }

        public Artifact(string id_fully_qualified)
            : base(id_fully_qualified)
        {

            return;
        }

        public Artifact(string id_group, string id_artifact)
            : base (id_group, id_artifact)
        {

            return;
        }

        public ArtifactBindingNugetData ArtifactBindingNugetData
        {
            get;
            set;
        }

    }
}
