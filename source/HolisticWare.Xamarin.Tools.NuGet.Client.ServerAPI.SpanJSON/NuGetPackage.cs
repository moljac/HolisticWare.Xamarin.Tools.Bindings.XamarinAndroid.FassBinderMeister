using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace HolisticWare.Xamarin.Tools.NuGet.ServerAPI
{
    /// <summary>
    /// NuGetPackage class (abstrction/implementation
    ///
    /// </summary>
    ///
    /// <seealso href="https://learn.microsoft.com/en-us/nuget/concepts/package-versioning"/>
    /// <seealso href="https://semver.org/spec/v1.0.0.html"/>
    /// <seealso href="https://semver.org/spec/v2.0.0.html"/>
    public partial class NuGetPackage  : Core.NuGetPackage
    {
        /// <summary>
        /// constructor/ctor for NuGet package
        /// </summary>
        public
                                        NuGetPackage
                                            (
                                            )
        {
            return;
        }

        /// <summary>
        /// constructor/ctor for NuGet package
        /// </summary>
        /// <param name="nuget_id_fully_qualified"></param>
        public
                                        NuGetPackage
                                            (
                                                // Fully qualified nuget id (nuget_id.version_semantic.nupkg)
                                                string nuget_id_fully_qualified
                                            )
                                        : base(nuget_id_fully_qualified)
        {
            return;
        }

        /// <summary>
        /// constructor/ctor for NuGet package
        /// </summary>
        public
                                        NuGetPackage
                                            (
                                                // nuget_id
                                                string nuget_id,
                                                // version - semantic
                                                // TODO: details
                                                string version
                                            )
                                        : base(nuget_id, version)
        {
            return;
        }
    }
}
