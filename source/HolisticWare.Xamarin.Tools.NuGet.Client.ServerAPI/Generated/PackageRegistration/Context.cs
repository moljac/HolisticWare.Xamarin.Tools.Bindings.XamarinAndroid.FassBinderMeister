
using System;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration
{
    public partial class Context
    {
        public Uri Vocab { get; set; }
        public Uri Catalog { get; set; }
        public Uri Xsd { get; set; }
        public Dependencies Items { get; set; }
        public CommitTimeStamp CommitTimeStamp { get; set; }
        public CommitId CommitId { get; set; }
        public CommitId Count { get; set; }
        public CommitTimeStamp Parent { get; set; }
        public Dependencies Tags { get; set; }
        public Reasons Reasons { get; set; }
        public Dependencies PackageTargetFrameworks { get; set; }
        public Dependencies DependencyGroups { get; set; }
        public Dependencies Dependencies { get; set; }
        public PackageContent PackageContent { get; set; }
        public PackageContent Published { get; set; }
        public PackageContent Registration { get; set; }
    }
}