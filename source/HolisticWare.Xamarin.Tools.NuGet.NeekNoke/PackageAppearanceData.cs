using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke
{
    public partial class
                                        PackageAppearanceData
    {
        public
                                        PackageAppearanceData
                                        (
                                        )
        {
        }

        public
            string
                                        VersionCurrent
        {
            get;
            internal set;
        }

        public
            string
                                        VersionLatest
        {
            get;
            internal set;
        }

        public
            List<string>
                                        VersionsUpgradeable
        {
            get;
            internal set;
        }
    }
}

