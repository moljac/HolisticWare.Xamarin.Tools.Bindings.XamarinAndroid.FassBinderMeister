using System;

namespace HolisticWare.Xamarin.Tools.Maven.Repositories.MavenCentral.ArtifactMetadata
{
    [System.Xml.Serialization.XmlType("metadataVersioning")]
    /// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MetadataVersioning
    {

        private string latestField;

        private string releaseField;

        private string[] versionsField;

        private ulong lastUpdatedField;

        [System.Xml.Serialization.XmlElement("latest")]
        /// <remarks/>
        public string Latest
        {
            get
            {
                return this.latestField;
            }
            set
            {
                this.latestField = value;
            }
        }

        [System.Xml.Serialization.XmlElement("release")]
        /// <remarks/>
        public string Release
        {
            get
            {
                return this.releaseField;
            }
            set
            {
                this.releaseField = value;
            }
        }

        [System.Xml.Serialization.XmlElement("versions")]
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("version", IsNullable = false)]
        public string[] Versions
        {
            get
            {
                return this.versionsField;
            }
            set
            {
                this.versionsField = value;
            }
        }

        [System.Xml.Serialization.XmlElement("lastUpdated")]
        /// <remarks/>
        public ulong LastUpdated
        {
            get
            {
                return this.lastUpdatedField;
            }
            set
            {
                this.lastUpdatedField = value;
            }
        }
    }
}

