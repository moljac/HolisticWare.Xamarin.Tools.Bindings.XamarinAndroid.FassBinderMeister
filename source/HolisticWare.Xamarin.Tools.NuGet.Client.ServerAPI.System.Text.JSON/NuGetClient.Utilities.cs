using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Tools.NuGet.ServerAPI
{
    /// <summary>
    /// 
    /// </summary>
    /// versions
    ///     https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
    /// details
    ///     https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.compose.material.ripple/index.json
    public partial class NuGetClient
    {
        public static HttpClient HttpClient
        {
            get;
            set;

        }

        // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/index.json
        // https://api.nuget.org/v3-flatcontainer/xamarin.androidx.compose.material.ripple/1.0.0/xamarin.androidx.compose.material.ripple.1.0.0.nupkg        
        public static
            string
                                        UrlV3FlatcontainerDefault
        {
            get;
        } = "https://api.nuget.org/v3-flatcontainer";

        // https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.compose.material.ripple/index.json
        // https://api.nuget.org/v3/registration5-gz-semver2/xamarin.androidx.compose.material.ripple/1.0.0.json
        public static
            string
                                        UrlV3Registration5SemVerDefault
        {
            get;
        } = "https://api.nuget.org/v3/registration5-gz-semver2";

        
    }
}
