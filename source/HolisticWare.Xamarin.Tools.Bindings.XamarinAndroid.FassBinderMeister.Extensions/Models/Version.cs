using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Models
{
    public class Version
    {
        public Version()
        {
            this.Dependencies = new
                                    List
                                        <
                                            (
                                                string ArtifactId,
                                                string Version
                                            )
                                        >
                                        ();

            return;
        }

        public string Value
        {
            get;
            set;
        }

        public List
                    <
                        (
                            string ArtifactId,
                            string Version
                        )
                    >
                    Dependencies
        {
            get;
            set;
        }
    }
}
