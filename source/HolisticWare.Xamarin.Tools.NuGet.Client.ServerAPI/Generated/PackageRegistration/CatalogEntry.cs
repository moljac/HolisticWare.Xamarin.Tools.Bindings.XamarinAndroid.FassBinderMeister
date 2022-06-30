using Newtonsoft.Json; 
using System.Collections.Generic; 
using System; 

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration
{ 
    public partial class CatalogEntry
    {
        public Uri Id { get; set; }
        public string Type { get; set; }
        public string Authors { get; set; }
        public DependencyGroup[] DependencyGroups { get; set; }
        public string Description { get; set; }
        public Uri IconUrl { get; set; }
        public string CatalogEntryId { get; set; }
        public string Language { get; set; }
        public string LicenseExpression { get; set; }
        public Uri LicenseUrl { get; set; }
        public bool? Listed { get; set; }
        public string MinClientVersion { get; set; }
        public Uri PackageContent { get; set; }
        public Uri ProjectUrl { get; set; }
        public DateTimeOffset? Published { get; set; }
        public bool? RequireLicenseAcceptance { get; set; }
        public string Summary { get; set; }
        public string[] Tags { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
    }

}