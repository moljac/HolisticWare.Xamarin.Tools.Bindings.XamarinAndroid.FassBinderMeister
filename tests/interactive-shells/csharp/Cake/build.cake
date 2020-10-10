using System.Net.Http;

string url = $"https://api.github.com/repos/xamarin/AndroidX/tags";

using (HttpClient http_client = new HttpClient())
{
    // https://stackoverflow.com/questions/57079111/requesting-to-github-api-using-net-httpclient-says-forbidden
    /*
    Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36
    */
    http_client.DefaultRequestHeaders
                    .Add
                        (
                            "User-Agent",
                            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36"
                        )
                    //.UserAgent.Add(new ProductInfoHeaderValue("yourAppName", "yourVersionNumber"))
                    ;
    string response_string_json = await http_client.GetStringAsync(url);

    Information($"JSON");
    Information($"{response_string_json}");
    // Now parse with JSON.Net
}
