using System;
using System.Collections.Generic;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats
{
    public class
                                    SettingsNewtonsoftJsonGlobalJson
                                    :
                                    Newtonsoft.Json.Serialization.DefaultContractResolver

    {
        protected
            Dictionary<string, string>
                                    PropertyMappings
        {
            get; set;
        }

        public
                                    SettingsNewtonsoftJsonGlobalJson
                                        (
                                        )
        {
            this.PropertyMappings = new Dictionary<string, string>
                                                {
                                                    {"Meta", "meta"},
                                                    {"LastUpdated", "last_updated"},
                                                    {"Disclaimer", "disclaimer"},
                                                    {"License", "license"},
                                                    {"CountResults", "results"},
                                                    {"Term", "term"},
                                                    {"Count", "count"},
                                                };

            return;
        }

        protected override
            string
                                    ResolvePropertyName
                                        (
                                            string name
                                        )
        {
            string retval = null;

            bool found = this.PropertyMappings.TryGetValue(name, out retval);

            if ( !found )
            {
                retval = base.ResolvePropertyName(name);
            }

            return retval;
        }
    }
}

