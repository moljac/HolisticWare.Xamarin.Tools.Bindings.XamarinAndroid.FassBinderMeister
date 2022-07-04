using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.IO;

namespace HolisticWare.Xamarin.Tools.NuGet.Core
{
    public partial class NuGetPackage
    {
        public string Id
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

        public string VersionRangeTextualDependency
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Summary
        {
            get;
            set;
        }
        
        public string LicenseExpression
        {
            get;
            set;
        }
        
        public Uri LicenseURL
        {
            get;
            set;
        }

        public bool LicenseAcceptanceRequired
        {
            get;
            set;
        }

        public Uri ProjectURL
        {
            get;
            set;
        }
        

        public List<string> VersionsTextual
        {
            get;
            set;
        }

        public DateTime Published
        {
            get;
            set;
        }

        public Dictionary<string, DateTime> VersionsDates
        {
            get;
            set;
        }
        
        public List<DependencyGroup> DependencyGroups
        {
            get;
            set;
        }
    }
}