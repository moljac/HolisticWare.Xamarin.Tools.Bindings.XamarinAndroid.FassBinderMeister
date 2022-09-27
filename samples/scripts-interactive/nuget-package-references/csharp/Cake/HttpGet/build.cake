#addin "Cake.Http"

string url_root = $"https://repo1.maven.org/maven2";

string group_id = "io.opencensus";
string artifact_id = "opencensus-api";

string url_artifact_id = $"{url_root}/{group_id.Replace(".", "/")}/{artifact_id}";
string url_artifact_id_metadata = $"{url_artifact_id}/maven-metadata.xml";

// https://repo1.maven.org/maven2/io/opencensus/opencensus-api/maven-metadata.xml
string response = HttpGet($"{url_artifact_id_metadata}");


