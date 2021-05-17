using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NuGet.Packaging;
using NuGet.Protocol.Core.Types;

namespace HolisticWare.Xamarin.Tools.NuGet.Core
{
    public partial class NuGetPackage
    {
        public string PackageId
        {
            get;
            set;
        }

        public string VersionTextual
        {
            get;
            set;
        }

        public string VersionLatestTextual
        {
            get;
            set;
        }

        public string DependencyVersionRange
        {
            get;
            set;
        }

        public List<string> VersionsTextual
        {
            get;
            set;
        }

    }
}