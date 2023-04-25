using System;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace HolisticWare.Xamarin.Tools.NuGet.Client.ServerAPI.Generated.Search
{
    /// <summary>
    /// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    /// </summary>
    public class Root
    {
        public Context context { get; set; }
        public int totalHits { get; set; }
        public List<Datum> data { get; set; }
    }

    public class Context
    {
        public string vocab { get; set; }

        public string @base { get; set; }
    }

    public class Datum
    {
        public string type { get; set; }
        public string registration { get; set; }
        public string id { get; set; }
        public string version { get; set; }
        public string description { get; set; }
        public string summary { get; set; }
        public string title { get; set; }
        public string iconUrl { get; set; }
        public string licenseUrl { get; set; }
        public string projectUrl { get; set; }
        public List<string> tags { get; set; }
        public List<string> authors { get; set; }
        public List<string> owners { get; set; }
        public int totalDownloads { get; set; }
        public bool verified { get; set; }
        public List<PackageType> packageTypes { get; set; }
        public List<Version> versions { get; set; }
    }

    public class PackageType
    {
        public string name { get; set; }
    }

    public class Version
    {
        public string version { get; set; }
        public int downloads { get; set; }

        public string id { get; set; }
    }
}







