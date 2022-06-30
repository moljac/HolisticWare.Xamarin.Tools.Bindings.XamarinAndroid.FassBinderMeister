using System;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration
{
    public partial class Root
    {
        public Uri Id { get; set; }
        public string[] Type { get; set; }
        public Guid? CommitId { get; set; }
        public DateTimeOffset? CommitTimeStamp { get; set; }
        public long? Count { get; set; }
        public PackageRegistrationItem[] Items { get; set; }
        public Context Context { get; set; }
    }
    
}
