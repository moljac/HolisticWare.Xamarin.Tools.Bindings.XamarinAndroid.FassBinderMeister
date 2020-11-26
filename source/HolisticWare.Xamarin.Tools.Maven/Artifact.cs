using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.Maven
{
    /// <summary>
    /// 
    /// </summary>
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// dl.google.com/android/maven2/ artifact-metadata.json
    public partial class Artifact
    {
        public string Id
        {
            get;
            set;
        }

        public List<string> VersionsTextual
        {
            get;
            set;
        }

        public List<System.Version> Versions
        {
            get;
            set;
        }

        public List<Artifact> Dependencies
        {
            get;
            set;
        }

        public static IEnumerable<System.Version> GetVersions
                                                        (
                                                            IEnumerable<string> versions_textual
                                                        )
        {
            foreach(string vt in versions_textual)
            {
                System.Version v = System.Version.Parse(vt);

                yield return v;
            }
        }
    }
}
