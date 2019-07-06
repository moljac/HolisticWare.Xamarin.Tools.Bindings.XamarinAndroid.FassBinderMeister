
//scriptcs -install MavenNet


// Open by URL
string url = "https://dl.google.com/dl/android/maven2";
var repo = MavenRepository.OpenUrl (url);

await repo.LoadMetadataAsync ();


