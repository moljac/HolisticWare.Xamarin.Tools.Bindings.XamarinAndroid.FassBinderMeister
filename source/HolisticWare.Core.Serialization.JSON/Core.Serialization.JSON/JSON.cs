using System;

namespace Core.Serialization.JSON
{
	public static partial class
									JSON<T>
	{
		static
									JSON
										(
										)
		{
            Deserialize = DeserializeUsingSystemTextJson;

            return;
		}

        public static
            Func<string, Settings, T>
                                    Deserialize;


        public static
            T
                                    DeserializeUsingSystemTextJson
                                        (
                                            string json,
                                            Settings settings = null
                                        )
        {
            T retval = default(T);

            if (settings == null)
            {
                retval = System.Text.Json.JsonSerializer.Deserialize<T>
                                                                (
                                                                    json
                                                                );
            }
            else
            {
                // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-7-0
                // 
                System.Text.Json.JsonSerializerOptions jso = null;

                jso = settings.Data as System.Text.Json.JsonSerializerOptions;
            }

            return retval;
        }

        public static
            T
                                    DeserializeUsingNewtonsoftJson
                                        (
                                            string json,
                                            Settings settings = null
                                        )
        {
            T retval = default(T);

            if (settings == null)
            {
                retval = Newtonsoft.Json.JsonConvert.DeserializeObject<T>
                                                                (
                                                                    json
                                                                );
            }
            else
            {
                Newtonsoft.Json.Serialization.DefaultContractResolver jso = null;

                jso = settings.Data as Newtonsoft.Json.Serialization.DefaultContractResolver;
            }

            return retval;
        }

        public static
            T
                                    DeserializeUsingJil
                                        (
                                            string json,
                                            Settings settings = null
                                        )
        {
            return Jil.JSON.Deserialize<T>(json);
        }
    }
}

