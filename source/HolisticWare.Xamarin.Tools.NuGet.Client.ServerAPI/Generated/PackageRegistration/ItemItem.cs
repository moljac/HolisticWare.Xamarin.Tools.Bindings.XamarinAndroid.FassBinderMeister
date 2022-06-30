using System; 
namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.PackageRegistration
{ 
    public partial class ItemItem
    {
        public Uri Id { get; set; }
        public string Type { get; set; }
        public Guid? CommitId { get; set; }
        public DateTimeOffset? CommitTimeStamp { get; set; }
        public CatalogEntry CatalogEntry { get; set; }
        public Uri PackageContent { get; set; }
        public Uri Registration { get; set; }
    }

}