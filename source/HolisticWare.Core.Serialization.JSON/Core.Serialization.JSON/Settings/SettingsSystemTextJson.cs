using System;


namespace Core.Serialization.JSON
{
    /// <summary>
    /// 
    /// </summary>
    /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties"/>
    /// <see href="https://makolyte.com/csharp-deserialize-json-using-different-property-names/"/>
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

    }
}

