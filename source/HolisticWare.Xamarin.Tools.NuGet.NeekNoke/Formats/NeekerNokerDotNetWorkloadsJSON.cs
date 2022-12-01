using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats.Generated.WorkloadsJson;
using HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class
                                        NeekerNokerDotNetWorkloadsJSON
										:
										NeekerNokerBase
{
	public
                                        NeekerNokerDotNetWorkloadsJSON
                                        (
										)
	{

		return;
	}

    public static
        string
                                        VersionDotNetSDKBand
    {
        get;
        set;
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

							if (NeekerNoker.Action == Action.Noke)
							{
								extension = Path.GetExtension(file);
								ts = DateTime.Now.ToString("yyyyMMdd-HHmmss");
								file_new = Path.ChangeExtension
								(
									file,
									$"bckp-ts-{ts}{extension}"
								);
								System.IO.File.Copy(file, file_new);
								content_new = System.IO.File.ReadAllText(file_new);
							}

							// 

							/*
							Root r = this
                                        //.DeserializeUsingSystemTextJson(content_original)
                                        .DeserializeUsingNewtonsoftJson(content_original)
                                        ;
							*/
							Dictionary<string, string> workloads_json = null;

                            workloads_json =
                                                //DeserializeDictionaryUsingNewtonsoftJson(content_original)
                                                DeserializeDictionaryUsingSystemTextJson(content_original)
                                                ;

							this.ResultsPerFormat
									.ResultsPerFile[file].DotNetWorkloadsJson = workloads_json;

                            foreach (KeyValuePair<string, string> kvp in workloads_json)
                            {
                                string nuget_id = kvp.Key;
                                string[] version_nuget_dotnet = kvp.Value.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                                string version_nuget = version_nuget_dotnet[0];
                                string version_dotnet = version_nuget_dotnet[1];

                                nuget_id = $"{nuget_id}.manifest-{version_dotnet}";

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
									.ResultsPerFile[file].Log.Add
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
        Dictionary<string, string>
                                    DeserializeDictionaryUsingSystemTextJson
                                        (
                                            string json
                                        )
	{
        Dictionary<string, string> workloads_system_text_json = null;

        workloads_system_text_json = System.Text.Json.JsonSerializer
                                                        .Deserialize
                                                            <
                                                                Dictionary<string, string>
                                                            >
                                                                (
                                                                    json

                                                                );
		return workloads_system_text_json;
    }

    public
        Dictionary<string, string>
                                    DeserializeDictionaryUsingNewtonsoftJson
                                        (
                                            string json
                                        )
    {
        Dictionary<string, string> workloads_newtosoft_json = null;

        workloads_newtosoft_json = Newtonsoft.Json.JsonConvert
                                                        .DeserializeObject
                                                            <
                                                                Dictionary<string, string>
                                                            >
                                                                (
                                                                    json
                                                                );

        return workloads_newtosoft_json;
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
            Settings = new SettingsSystemTextJsonWorkloadsJson()
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
            Settings = new SettingsNewtonsoftJsonWorkloadsJson()
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
