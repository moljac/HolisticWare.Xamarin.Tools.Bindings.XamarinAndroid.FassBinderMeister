namespace HolisticWare.Xamarin.Tools.ComponentGovernance.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;

    public partial class ComponentGovernanceManifest
    {
        public string Schema
        {
            get;
            set;
        } = "https://json.schemastore.org/component-detection-manifest.json";

        public Registration[] Registrations
        {
            get;
            set;
        }

        public long Version
        {
            get;
            set;
        }
    }
}
