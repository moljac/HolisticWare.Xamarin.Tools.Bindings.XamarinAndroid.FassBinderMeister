using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerNokerScriptCakeBuild
						:
						NeekerNokerBase
{
	public 
										NeekerNokerScriptCakeBuild 
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
						async (file) =>
						{
							string extension = null;
							string ts = null;
							string file_new = null;
							string content_original = System.IO.File.ReadAllText(file);
							string content_new = null;

							string nuget_id = null;
							string version = null;
							string text_snippet_original = null;
							string text_snippet_new = null;

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

							string[] lines = System.IO.File.ReadLines(file).ToArray();
							string[] nuget_reference_parts = null;

							foreach(string line in lines)
							{
								switch (line)
								{
									case string line_preprocessor when line.StartsWith("#"):
										if (line.Contains("nuget:?package="))
										{
											text_snippet_original = line;
										}
										line_preprocessor = line.Replace("#", "").Trim();
										switch (line_preprocessor)
										{
											case string preprocessor_cmd when line_preprocessor.StartsWith("addin"):
												preprocessor_cmd = preprocessor_cmd.Replace("addin", "");
												preprocessor_cmd = preprocessor_cmd.Replace("nuget:?package=", "");
												preprocessor_cmd = preprocessor_cmd.Trim();
												nuget_reference_parts = preprocessor_cmd.Split
																							(
																								new[] {"&"}, 
																								StringSplitOptions.RemoveEmptyEntries
																							);
												nuget_id = nuget_reference_parts[0];
												
												foreach (string part in nuget_reference_parts)
												{
													if (part.StartsWith("version="))
													{
														version = part.Replace("version=", "");
													}
												}
												
												break;
											case string preprocessor_cmd when line_preprocessor.StartsWith("tool"):
												if (line.Contains("nuget:?package="))
												{
													text_snippet_original = line;
												}
												preprocessor_cmd = preprocessor_cmd.Replace("tool", "");
												preprocessor_cmd = preprocessor_cmd.Replace("nuget:?package=", "");
												preprocessor_cmd = preprocessor_cmd.Trim();
												nuget_reference_parts = preprocessor_cmd.Split
																							(
																								new[] {"&"}, 
																								StringSplitOptions.RemoveEmptyEntries
																							);
												nuget_id = nuget_reference_parts[0];
												foreach (string part in nuget_reference_parts)
												{
													if (part.StartsWith("version="))
													{
														version = part.Replace("version=", "");
													}
												}
												
												break;
											default:
												break;
										}

										if (nuget_id == null)
										{
											break;
										}

										this.ResultsPerFormat
												.ResultsPerFile[file]
													.PackageReferences.Add
																		(
																			(
																				nuget_id: nuget_id,
																				version_current: version,
																				versions_upgradeable: null,
																				text_snippet_original: text_snippet_original,
																				text_snippet_new: text_snippet_new
																			)
																		);
										nuget_id = null;
										version = null;
										break;
									default:
										continue;
										break;
								}


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