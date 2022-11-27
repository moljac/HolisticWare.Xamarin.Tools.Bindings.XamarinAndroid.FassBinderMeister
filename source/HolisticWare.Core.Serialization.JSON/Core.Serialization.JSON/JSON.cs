using System;
using System.Runtime;
using System.Text.Json;

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
            DeserializeCustom = DeserializeUsingSystemTextJson;

            return;
		}

        public static
            Func<string, T>
                                    Deserialize;


        public static
            Func<string, Settings, T>
                                    DeserializeCustom;


        public static
            T
                                    DeserializeUsingSystemTextJson
                                        (
                                            string json
                                        )
        {
            T retval = default(T);

            retval = System.Text.Json.JsonSerializer.Deserialize<T>
                                                            (
                                                                json
                                                            );

            return retval;
        }

        public static
            T
                                    DeserializeUsingSystemTextJson
                                        (
                                            string json,
                                            Settings settings
                                        )
        {
            T retval = default(T);

            if (settings == null)
            {
                retval = DeserializeUsingSystemTextJson(json);
            }
            else
            {
                // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-7-0
                // 
                System.Text.Json.JsonSerializerOptions jso = null;

                jso = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNamingPolicy = settings.Settings
                };
            }

            return retval;
        }

        public static
            T
                                    DeserializeUsingNewtonsoftJson
                                        (
                                            string json
                                        )
        {
            T retval = default(T);

            retval = Newtonsoft.Json.JsonConvert.DeserializeObject<T>
                                                            (
                                                                json
                                                            );

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
                DeserializeUsingNewtonsoftJson(json);            }
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
                                            string json
                                        )
        {
            T retval = default(T);

            retval = Jil.JSON.Deserialize<T>
                                        (
                                            json
                                        );

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
            T retval = default(T);

            if (settings == null)
            {
                DeserializeUsingJil(json);
            }
            else
            {
                Newtonsoft.Json.Serialization.DefaultContractResolver jso = null;

                jso = settings.Data as Newtonsoft.Json.Serialization.DefaultContractResolver;
            }

            return retval;
        }
    }
}

