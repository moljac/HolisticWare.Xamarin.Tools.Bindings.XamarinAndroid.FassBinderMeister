public partial class Welcome
{
    public string MavenRepositoryType { get; set; }
    public string SlnFile { get; set; }
    public Debug Debug { get; set; }
    public string[] AdditionalProjects { get; set; }
    public Template[] Templates { get; set; }
    public Artifact[] Artifacts { get; set; }
}

public partial class Artifact
{
    public GroupId GroupId { get; set; }
    public string ArtifactId { get; set; }
    public string Version { get; set; }
    public NugetVersion? NugetVersion { get; set; }
    public string NugetId { get; set; }
    public bool? DependencyOnly { get; set; }
}

public partial class Debug
{
    public bool DumpModels { get; set; }
}

public partial class Template
{
    public string TemplateFile { get; set; }
    public string OutputFileRule { get; set; }
}

public enum GroupId 
{ 
    AndroidArchCore, 
    AndroidArchLifecycle, ComAndroidSupport, ComGoogleAndroidGms, ComGoogleFirebase, ComGoogleProtobuf, ComSquareupOkhttp, OrgTensorflow };

public enum NugetVersion { The7115000Preview2, The7115010Preview2, The7115020Preview2, The7115100Preview2, The7115200Preview2, The7116000Preview2, The7116020Preview2 };
