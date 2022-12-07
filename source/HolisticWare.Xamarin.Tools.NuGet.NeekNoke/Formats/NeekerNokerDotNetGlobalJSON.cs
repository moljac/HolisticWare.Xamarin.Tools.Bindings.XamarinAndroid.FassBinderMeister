using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats.Generated.GlobalJson;
using HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class
										NeekerNokerDotNetGlobalJSON
										:
										NeekerNokerBase
{
	public 
										NeekerNokerDotNetGlobalJSON 
										(
										)
	{

		return;
	}

	public 
		void
										NeekNoke
											(
												string[] files
											)
    {
		// initialize result, so Add does not crash (parallel) and no Concurrent Collections are needed
		foreach (string file in files)
		{
			this.ResultsPerFormat.ResultsPerFile.Add
													(
														file,
														new ResultsPerFile()
														{
															File = file
														}
													);
		}

		Parallel.ForEach
					(
						files,
						file =>
						{
							string extension = null;
							string ts = null;
							string file_new = null;
							string content_original = System.IO.File.ReadAllText(file);
							string content_new = null;

                            // https://learn.microsoft.com/en-us/dotnet/core/tools/global-json
                            /*
							Core.Serialization.JSON.JSON<Root>.Deserialize =
																	Core.Serialization.JSON.JSON<Root>.DeserializeUsingSystemTextJson
																	//Core.Serialization.JSON.JSON<Root>.DeserializeUsingNewtonsoftJson
                                                                    //Core.Serialization.JSON.JSON<Root>.DeserializeUsingJil
                                                                    ;
                            Core.Serialization.JSON.JSON<Root>.DeserializeCustom =
                                                                    Core.Serialization.JSON.JSON<Root>.DeserializeUsingSystemTextJson
                                                                    //Core.Serialization.JSON.JSON<Root>.DeserializeUsingNewtonsoftJson
                                                                    //Core.Serialization.JSON.JSON<Root>.DeserializeUsingJil
                                                                    ;

                            Root r = this
                                        .DeserializeUsingSystemTextJson(content_original)
                                        //.DeserializeUsingNewtonsoftJson(content_original)
                                        ;
							*/

                            Dictionary
                                    <
                                        string,
                                        Dictionary<string, object>
                                    >
                                        global_newtosoft_json = null;

                            global_newtosoft_json = Newtonsoft.Json.JsonConvert
                                                                            .DeserializeObject
                                                                                <
                                                                                    Dictionary
                                                                                            <
                                                                                                string,
                                                                                                Dictionary<string, object>
                                                                                            >
                                                                                >
                                                                                    (
                                                                                        content_original
                                                                                    );

                            Dictionary
                                    <
                                        string,
                                        Dictionary<string, object>
                                    >
                                        global_system_text_json = null;

                            global_system_text_json = System.Text.Json.JsonSerializer
                                                                            .Deserialize
                                                                                <
                                                                                    Dictionary
                                                                                            <
                                                                                                string,
                                                                                                Dictionary<string, object>
                                                                                            >
                                                                                >
                                                                                    (
                                                                                        content_original
                                                                                    );

                            this.ResultsPerFormat
                                    .ResultsPerFile[file].DotNetGlobalJson = global_newtosoft_json;

                            if ( ! global_newtosoft_json.ContainsKey("msbuild-sdks") )
                            {
                                return;
                            }

                            Dictionary<string, object> global_msbuild_sdks = global_newtosoft_json["msbuild-sdks"];

                            foreach
                                (
                                    KeyValuePair
                                        <
                                            string,
                                            object
                                        >
                                            kvp in global_msbuild_sdks
                                )
                            {
                                string nuget_id = kvp.Key;
                                string version_nuget = (string)kvp.Value;

                                this.ResultsPerFormat
                                        .ResultsPerFile[file]
                                            .PackageReferences.Add
                                                                (
                                                                    (
                                                                        nuget_id: nuget_id,
                                                                        version_current: version_nuget,
                                                                        versions_upgradeable: null,
                                                                        text_snippet_original: content_original,
                                                                        text_snippet_new: content_original
                                                                    )
                                                                );
                            }

                            this.ResultsPerFormat
									.ResultsPerFile[file]
                                        .Log.Add
											    (
												    (
													    file_backup: file_new,
													    content: content_original,
													    content_backup: content_new
												    )
											    );

							return;
						}
					);

        return;
    }

    public
        Root
                                    DeserializeUsingSystemTextJson
                                        (
                                            string json
                                        )
    {
        Root r = null;

        Core.Serialization.JSON.SettingsSystemTextJson settings = null;

        settings = new Core.Serialization.JSON.SettingsSystemTextJson
        {
            Settings = new SettingsSystemTextJsonGlobalJson()
        };

        r = global::Core.Serialization
                                .JSON.JSON<Root>.DeserializeCustom
                                                        (
                                                            json,
                                                            settings
                                                        );

        return r;
    }

    public
        Root
                                    DeserializeUsingNewtonsoftJson
                                        (
                                            string json
                                        )
    {
        Root r = null;

        Core.Serialization.JSON.SettingsNewtonsoftJson settings = null;

        settings = new Core.Serialization.JSON.SettingsNewtonsoftJson
        {
            Settings = new SettingsNewtonsoftJsonGlobalJson()
        };

        r = global::Core.Serialization
                                .JSON.JSON<Root>.DeserializeCustom
                                                        (
                                                            json,
                                                            settings
                                                        );

        return r;
    }
}
