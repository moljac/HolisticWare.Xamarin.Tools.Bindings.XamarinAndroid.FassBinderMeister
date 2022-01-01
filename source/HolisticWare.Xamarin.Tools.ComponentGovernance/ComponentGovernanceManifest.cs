using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.ComponentGovernance
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Git
    {
        public string repositoryUrl { get; set; }
        public string commitHash { get; set; }
    }

    public class Component
    {
        public string type { get; set; }
        public string Type { get; set; }
        public Git git { get; set; }
        public Maven Maven { get; set; }
    }

    public class Maven
    {
        public string ArtifactId { get; set; }
        public string GroupId { get; set; }
        public string Version { get; set; }
        public string NuGetId { get; set; }
    }

    public class Registration
    {
        public Component component { get; set; }
        public Component Component { get; set; }
    }

    public class Root
    {
        public List<Registration> Registrations { get; set; }
        public int Version { get; set; }
    }
}
