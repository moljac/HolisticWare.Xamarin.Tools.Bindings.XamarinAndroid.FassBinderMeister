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

							// https://learn.microsoft.com/en-us/dotnet/core/tools/global-json

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
                                        //.DeserializeUsingSystemTextJson(content_original)
                                        .DeserializeUsingNewtonsoftJson(content_original)
                                        ;

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
