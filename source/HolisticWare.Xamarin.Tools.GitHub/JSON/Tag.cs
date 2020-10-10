using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    [ModelMetadataType(typeof(HolisticWare.Xamarin.Tools.GitHub.JSON.Tag))]
    public partial class Tag
    {
        public static Tag FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Tag>(json, Converter.Settings);
        }

    }
}

namespace HolisticWare.Xamarin.Tools.GitHub.JSON
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("zipball_url")]
        public Uri ZipballUrl
        {
            get;
            set;
        }

        [JsonProperty("tarball_url")]
        public Uri TarballUrl
        {
            get;
            set;
        }

        [JsonProperty("commit")]
        public Commit Commit
        {
            get;
            set;
        }

        [JsonProperty("node_id")]
        public string NodeId
        {
            get;
            set;
        }
    }
}
