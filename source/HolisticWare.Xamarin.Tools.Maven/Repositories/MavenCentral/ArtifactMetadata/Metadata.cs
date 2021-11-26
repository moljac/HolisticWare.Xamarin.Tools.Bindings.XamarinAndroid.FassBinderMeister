using System;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral.ArtifactMetadata
{
    [System.Xml.Serialization.XmlType("metadata")]
    /// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Metadata
    {

        private string groupIdField;

        private string artifactIdField;

        private MetadataVersioning versioningField;

        [System.Xml.Serialization.XmlElement("groupId")]
        /// <remarks/>
        public string GroupId
        {
            get
            {
                return this.groupIdField;
            }
            set
            {
                this.groupIdField = value;
            }
        }

        [System.Xml.Serialization.XmlElement("artifactId")]
        /// <remarks/>
        public string ArtifactId
        {
            get
            {
                return this.artifactIdField;
            }
            set
            {
                this.artifactIdField = value;
            }
        }

        [System.Xml.Serialization.XmlElement("versioning")]
        /// <remarks/>
        public MetadataVersioning Versioning
        {
            get
            {
                return this.versioningField;
            }
            set
            {
                this.versioningField = value;
            }
        }
    }
}
