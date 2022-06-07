// Root myDeserializedClass = JsonConvert.DeserializeObject<ComponentGovernanceManifest>(myJsonResponse);
namespace HolisticWare.Xamarin.Tools.ComponentGovernance.Generated
{
     public class Component
    {
        public string Type { get; set; }
        public Maven Maven { get; set; }
    }

    public class Maven
    {
        public string ArtifactId { get; set; }
        public string GroupId { get; set; }
        public string Version { get; set; }
    }

    public class Registration
    {
        public Component Component { get; set; }
    }

    public class ComponentGovernanceManifest
    {
        public List<Registration> Registrations { get; set; }
        public int Version { get; set; }
    }
}
