using System;

namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration
{ 
    public partial class PackageRegistrationItem
    {
        public Uri Id { get; set; }
        public string Type { get; set; }
        public Guid? CommitId { get; set; }
        public DateTimeOffset? CommitTimeStamp { get; set; }
        public long? Count { get; set; }
        public ItemItem[] Items { get; set; }
        public Uri Parent { get; set; }
        public string Lower { get; set; }
        public string Upper { get; set; }
    }
}