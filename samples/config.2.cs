
public class Debug
{
    public bool DumpModels { get; set; }
}

public class Template
{
    public string templateFile { get; set; }
    public string outputFileRule { get; set; }
}

public class Artifact
{
    public string groupId { get; set; }
    public string artifactId { get; set; }
    public string version { get; set; }
    public string nugetVersion { get; set; }
    public string nugetId { get; set; }
    public bool? dependencyOnly { get; set; }
}

public class RootObject
{
    public string mavenRepositoryType { get; set; }
    public string slnFile { get; set; }
    public Debug debug { get; set; }
    public List<string> additionalProjects { get; set; }
    public List<Template> templates { get; set; }
    public List<Artifact> artifacts { get; set; }
}