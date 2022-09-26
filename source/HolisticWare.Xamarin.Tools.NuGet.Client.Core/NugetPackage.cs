using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Core.IO;

namespace HolisticWare.Xamarin.Tools.NuGet.Core
{
    /// <summary>
    /// NuGetPackage class (abstrction/implementation
    ///
    /// </summary>
    ///
    /// <seealso href="https://learn.microsoft.com/en-us/nuget/concepts/package-versioning"/>
    /// <seealso href="https://semver.org/spec/v1.0.0.html"/>
    /// <seealso href="https://semver.org/spec/v2.0.0.html"/>
    public partial class NuGetPackage
    {
        public
                                        NuGetPackage
                                            (
                                            )
        {
            return;            
        }

        public
                                        NuGetPackage
                                            (
                                                // Fully qualified nuget id (nuget_id.version_semantic.nupkg)
                                                string nuget_id_fully_qualified
                                            )                                        
        {
            // Fully qualified nuget id
            // nuget_id.version_semantic.nupkg

            string[] parts = nuget_id_fully_qualified.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = parts.Length; i > -1; i--)
            {
                Trace.WriteLine($"parts[{i}] = {parts[i]}");

            }

            return;
        }

        public
                                                    NuGetPackage
                                                        (
                                                            // nuget_id
                                                            string nuget_id,
                                                            // version - semantic
                                                            // TODO: details
                                                            string version
                                                        )
        {
            // Fully
            this.Id = nuget_id;
            this.VersionTextual = version;
            
            return;            
        }
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