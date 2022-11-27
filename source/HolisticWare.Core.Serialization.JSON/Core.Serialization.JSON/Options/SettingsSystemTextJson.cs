using System;
using System.Text.Json;

namespace Core.Serialization.JSON
{
	public class
                                    SettingsSystemTextJson
                                    :
                                    Settings
    {
        public
            JsonNamingPolicy
                                    JsonNamingPolicy
        {
            get;
            set;
        }

        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties
        // https://makolyte.com/csharp-deserialize-json-using-different-property-names/

    }
}

