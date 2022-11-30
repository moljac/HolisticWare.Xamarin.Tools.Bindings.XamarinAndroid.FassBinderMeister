using System;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats
{
    public class
                                    SettingsSystemTextJsonGlobalJson
                                    :
                                    System.Text.Json.JsonNamingPolicy

    {
        public override
            string
                                    ConvertName
                                        (
                                            string name
                                        )
        {
            string retval = null;

            switch(name)
            {
                case "Sdk":
                    retval = "sdk";
                    break;
                case "MsBuildSdks":
                    retval = "msbuild-sdks";
                    break;
                default:
                    break;
            }

            return retval;
        }
    }
}

