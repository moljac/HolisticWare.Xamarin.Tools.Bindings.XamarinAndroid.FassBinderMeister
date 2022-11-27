using System;


namespace Core.Serialization.JSON
{
	public class
                                    SettingsSystemTextJson
                                    :
                                    Settings
    {
        public
            System.Text.Json.JsonNamingPolicy
                                    Settings
        {
            get;
            set;
        }

        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties
        // https://makolyte.com/csharp-deserialize-json-using-different-property-names/

    }
}

