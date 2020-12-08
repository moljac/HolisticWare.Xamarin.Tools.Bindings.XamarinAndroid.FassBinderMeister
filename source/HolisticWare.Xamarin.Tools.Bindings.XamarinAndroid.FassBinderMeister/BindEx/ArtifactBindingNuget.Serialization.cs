using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using NuGet.Protocol.Core.Types;
using global::NuGet.Packaging;

using HolisticWare.Xamarin.Tools.NuGet;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.BindEx
{
    public partial class ArtifactBindingNuget
    {
        public
            Artifact DeserializeFromJSON_Newtonsoft(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Artifact>(json);
        }

        public
            string SerializeToJSON_Newtonsoft()
        {
            /*
                Serialization order:

                "groupId": "androidx.activity",
                "artifactId": "activity",
                "version": "1.1.0",
                "nugetVersion": "1.1.0.4",
                "nugetId": "Xamarin.AndroidX.Activity",

                "artifactIdVersions"
                "artifactIdVersionLatest"
                "nugetVersions"
                "nugetVersionLatest"
                "dependencies"
             */
            List<string> properties_to_serialize = new List<string>
            {
                "groupId",
                "artifactId",
                "version",
                // extended
                "idFullyQualified",
                "versionTextual",
                "groupIndex",
                "versions",
                "versionsTextual",
                "projectObjectModelTextual",
                "projectObjectModel",
                "dependencies",
            };

            //Serialization.Formatters.
            OrderedContractResolver resolver = null;

            resolver = new //Serialization.Formatters.
                OrderedContractResolver(properties_to_serialize);

            string content = Newtonsoft.Json.JsonConvert.SerializeObject
                                                                (
                                                                    this,
                                                                    Newtonsoft.Json.Formatting.Indented,
                                                                    new Newtonsoft.Json.JsonSerializerSettings
                                                                    {
                                                                        ContractResolver = resolver
                                                                    }
                                                                );

            return content;
        }

        public static Artifact DeserializeFromJSON_System_Text_Json(string json)
        {
            return System.Text.Json.JsonSerializer.Deserialize<Artifact>(json);
        }

        public static string SerializeToJSON_System_Text_Json(Artifact artifact)
        {
            string content = System.Text.Json.JsonSerializer.Serialize<Artifact>
                                                                    (
                                                                        artifact,
                                                                        new System.Text.Json.JsonSerializerOptions
                                                                        {
                                                                            WriteIndented = true
                                                                        }
                                                                    );

            return content;
        }

        public static Artifact DeserializeFromXML(string xml)
        {
            System.Xml.Serialization.XmlSerializer xs = null;

            using (System.IO.TextReader tr = new System.IO.StringReader(xml))
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                return (Artifact)xs.Deserialize(tr);
            }
        }

        public static string SerializeToXML(string filename, Artifact artifact)
        {
            System.Xml.Serialization.XmlSerializer xs = null;
            string content = null;

            using (System.IO.TextWriter tw = new System.IO.StringWriter())
            {
                xs = new System.Xml.Serialization.XmlSerializer(typeof(Artifact));

                xs.Serialize(tw, artifact);
                content = tw.ToString();
            }

            return content;
        }

    }
}
