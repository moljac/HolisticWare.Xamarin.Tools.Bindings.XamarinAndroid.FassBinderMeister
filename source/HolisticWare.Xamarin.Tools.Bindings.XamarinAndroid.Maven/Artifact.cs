﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven.Models.GeneratedFromXML.Original;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.Maven
{
    /// <summary>
    /// 
    /// </summary>
    /// https://dl.google.com/android/maven2/androidx/arch/core/core-common/2.0.0/artifact-metadata.json
    /// dl.google.com/android/maven2/ artifact-metadata.json
    public partial class Artifact
    {
        public Artifact()
        {

            return;
        }

        public Artifact(string id_group, string id_artifact)
        {
            this.IdGroup = id_group;
            this.Id = id_artifact;

            return;
        }

        public Artifact(string id_fully_qualified)
        {
            int idx = id_fully_qualified.LastIndexOf('.');

            this.IdGroup = id_fully_qualified.Substring(0, idx);
            this.Id = id_fully_qualified.Substring(idx + 1, id_fully_qualified.Length - (idx + 1));

            return;
        }

        public string Id
        {
            get;
            set;
        }

        public string IdGroup
        {
            get;
            set;
        }

        public string IdFullyQualified
        {
            get
            {
                return string.Concat(this.IdGroup, ".", this.Id);
            }
            set
            {
            }
        }

        public string VersionTextual
        {
            get;
            set;
        }

        public System.Version Version
        {
            get;
            set;
        }

        public List<string> VersionsTextual
        {
            get;
            set;
        }

        public List<System.Version> Versions
        {
            get;
            set;
        }

        public List<Artifact> Dependencies
        {
            get;
            set;
        }




        public static
            IEnumerable<System.Version>
                                        GetVersions
                                                (
                                                    IEnumerable<string> versions_textual
                                                )
        {
            foreach(string vt in versions_textual)
            {
                System.Version v;
                bool parsed = System.Version.TryParse(vt, out v);

                yield return v;
            }
        }

        public static
            IEnumerable<System.Version>
                                    GetVersionsOfBindingsNuGetPackage
                                                (
                                                    IEnumerable<string> versions_textual
                                                )
        {
            foreach (string vt in versions_textual)
            {

                System.Version v;
                bool parsed = System.Version.TryParse(vt, out v);

                yield return v;
            }
        }

        public async
            Task<string>
                                    DownloadArtifactMetadata
                                            (
                                            )
        {
            string gid = this.IdFullyQualified.Replace(".", "/");
            string v = this.VersionTextual;
            string url = $"https://dl.google.com/android/maven2/{gid}/{v}/artifact-metadata.json";

            string response = null;

            try
            {
                response = await MavenClient.HttpClient.GetStringAsync(url);
            }
            catch(Exception exc)
            {
                response = exc.Message;
            }

            return response;
        }

        public async
            Task<string>
                                    DownloadProjectObjectModelPOM
                                            (
                                            )
        {
            string id = this.Id;
            string idfq = this.IdFullyQualified.Replace(".", "/");
            string v = this.VersionTextual;
            string url = $"https://dl.google.com/android/maven2/{idfq}/{v}/{id}-{v}.pom";

            string response = await MavenClient.HttpClient.GetStringAsync(url);

            return response;
        }

        public async
            Task<ProjectObjectModel.Project>
                                    DeserializeProjectObjectModelPOM
                                            (
                                            )
        {
            string content = await DownloadProjectObjectModelPOM();

            System.Xml.Serialization.XmlSerializer xs = null;
            xs = new System.Xml.Serialization.XmlSerializer(typeof(ProjectObjectModel.Project));
            ProjectObjectModel.Project result;

            string id_g = this.IdGroup;
            string id_a = this.Id;
            System.IO.File.WriteAllText($"{id_g}.{id_a}-pom.xml", content);

            using (System.IO.TextReader tr = new System.IO.StringReader(content))
            {
                result = (ProjectObjectModel.Project) xs.Deserialize(tr);
            }

            return result;
        }
        
        public async
            Task<ModelsFromOfficialXSD.Model>
                                    DeserializeProjectObjectModelPOMFromOfficialXSD
                                            (
                                            )
        {
            string content = await DownloadProjectObjectModelPOM();

            System.Xml.Serialization.XmlSerializer xs = null;
            xs = new System.Xml.Serialization.XmlSerializer(typeof(ModelsFromOfficialXSD.Model));
            ModelsFromOfficialXSD.Model result;

            string id_g = this.IdGroup;
            string id_a = this.Id;
            System.IO.File.WriteAllText($"{id_g}.{id_a}-pom.xml", content);

            using (System.IO.TextReader tr = new System.IO.StringReader(content))
            {
                result = (ModelsFromOfficialXSD.Model)xs.Deserialize(tr);
            }

            return result;
        }

    }
}