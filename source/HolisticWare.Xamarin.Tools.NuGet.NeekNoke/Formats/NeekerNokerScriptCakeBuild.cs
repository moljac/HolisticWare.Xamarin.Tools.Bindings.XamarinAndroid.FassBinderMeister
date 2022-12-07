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

							string[] lines = System.IO.File.ReadLines(file).ToArray();
							string nuget_reference = null;
							string[] nuget_reference_parts = null;

							foreach(string line in lines)
							{
								switch (line)
								{
									case string line_preprocessor when line.StartsWith("#"):
                                        if ( ! line.Contains("nuget:?package="))
										{
											continue;
										}
                                        text_snippet_original = line_preprocessor;
										line_preprocessor = line_preprocessor.Replace("#", "").Trim();
                                        line_preprocessor = line_preprocessor.Replace("\"", "").Trim();

                                        switch (line_preprocessor)
										{
											case string preprocessor_cmd when line_preprocessor.StartsWith("addin"):
                                                nuget_reference = preprocessor_cmd.Replace("addin", "");
												break;
											case string preprocessor_cmd when line_preprocessor.StartsWith("tool"):
                                                nuget_reference = preprocessor_cmd.Replace("tool", "");												
												break;
											default:
												break;
										}

                                        nuget_reference = nuget_reference.Replace("nuget:?package=", "");
                                        nuget_reference = nuget_reference.Trim();
                                        nuget_reference_parts = nuget_reference.Split
                                                                                    (
                                                                                        new[] { "&" },
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

										if (nuget_id == null || version == null)
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
									.ResultsPerFile[file]
										.Log.Add
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
