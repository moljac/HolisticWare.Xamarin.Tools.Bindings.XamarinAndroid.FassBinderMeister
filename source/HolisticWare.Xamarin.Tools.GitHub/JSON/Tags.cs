using System;
using System.Collections.Generic;

using Newtonsoft.Json;

// for buddy classes
using Microsoft.AspNetCore.Mvc;

namespace HolisticWare.Xamarin.Tools.GitHub
{
    // POCO class with Metadata for Buddy Class containing attributes
    [ModelMetadataType(typeof(HolisticWare.Xamarin.Tools.GitHub.JSON.Tag))]
    public partial class Tags
    {
        public static IEnumerable<Tag> Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Tag>>(json, Converter.Settings);
        }

    }
}

namespace HolisticWare.Xamarin.Tools.GitHub.JSON
{
    public class Tags
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
