using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerNokerDotNetGlobalJSON
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
							// 
							Newtonsoft.Json.Linq.JObject json_object = null;

							using (StringReader string_reader = new StringReader(System.IO.File.ReadAllText(file)))
							{
								Newtonsoft.Json.JsonTextReader jtr = new Newtonsoft.Json.JsonTextReader(string_reader);
								json_object = (Newtonsoft.Json.Linq.JObject) Newtonsoft.Json.Linq.JToken.ReadFrom(jtr);
							}

							Dictionary<string, JToken?> jt_sections = null;
							jt_sections = new Dictionary<string, JToken>()
							{
								{"sdk", json_object["sdk"]},
								{"msbuild-sdks", json_object["msbuild-sdks"]},
							};

							foreach (KeyValuePair<string, JToken?> kvp in jt_sections)
							{
								if (kvp.Value != null)
								{
									foreach (Newtonsoft.Json.Linq.JProperty jp in kvp.Value)
									{
										string name = (string) jp.Name;
										string version = (string) jp.Value;
									}
								}
							}

							List
							<
								(
								string nuget_id,
								string version
								)
							> msbuild_sdks = new List
							<
								(
								string nuget_id,
								string vetsion
								)
							>();

							foreach (Newtonsoft.Json.Linq.JProperty jp in json_object["msbuild-sdks"])
							{
								string name = (string) jp.Name;
								string value = (string) jp.Value;
								msbuild_sdks.Add((name, value));
							}

							this.ResultsPerFormat
									.ResultsPerFile[file].Log.Add
																(
																	(
																		file_new: file_new,
																		content: content_original,
																		content_new: content_new
																	)
																);

							return;
						}
					);

        return;
    }
}
