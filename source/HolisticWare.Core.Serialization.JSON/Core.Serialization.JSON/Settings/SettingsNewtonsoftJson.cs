using System;


namespace Core.Serialization.JSON
{
    /// <summary>
    /// 
    /// </summary>
    /// <see href="https://blog.bitscry.com/2021/10/20/pascal-case-naming-in-newtonsoft/"/>
    /// <see href="https://www.newtonsoft.com/json/help/html/NamingStrategySkipSpecifiedNames.htm"/>
    /// <see href="https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Serialization_CamelCaseNamingStrategy.htm"/>
    /// <see href="https://stackoverflow.com/questions/48647650/newtonsoft-jsonconvert-serializeobject-ignoring-jsonproperty-if-name-is-uppercas"/>
    /// Newtonsoft.Json.Serialization.DefaultContractResolver
	public class
                                    SettingsNewtonsoftJson
                                    :
                                    Settings
    {
        public
            Newtonsoft.Json.Serialization.NamingStrategy
                                    Settings
        {
            get;
            set;
        }

    }
}

