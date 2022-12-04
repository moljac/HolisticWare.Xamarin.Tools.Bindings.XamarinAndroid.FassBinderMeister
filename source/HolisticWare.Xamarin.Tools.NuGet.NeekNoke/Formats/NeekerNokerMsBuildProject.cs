using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class
										NeekerNokerMsBuildProject
										:
										NeekerNokerBase
{
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

							string nuget_id = null;
							string version = null;
							string text_snippet_original = null;
							string text_snippet_new = null;

							string version_override = null;
							string inner_text = null;
							string outer_xml = null;

							XDocument xdoc = null;
							try
							{
								xdoc = XDocument.Load(file);
							}
							catch (System.Exception exc)
							{
								throw;
							}
							//------------------------------------------------------------------------------------------------------
							// PackageReference

							IEnumerable<XElement> xe_package_references = null;
							xe_package_references = xdoc.XPathSelectElements("//PackageReference");

							/*
							 
							 */
							Dictionary
									<
										(
											string nuget_id,
											string version
										),
										(
											string snippet_original,
											string snippet_new
										)
									>
									packages_with_versions_found;

							packages_with_versions_found = new Dictionary
																<
																	(
																		string nuget_id,
																		string version
																	),
																	(
																		string snippet_original,
																		string snippet_new
																	)
																>
																	();
	
							IEnumerable<XElement> xe_package_references_include_attribute = null;
							xe_package_references_include_attribute =
								xdoc.XPathSelectElements("//PackageReference[@Include]");
							if
							(
								xe_package_references_include_attribute == null
								||
								!xe_package_references_include_attribute.Any()
							)
							{
								// No PackageReferences;
								return;
							}

							foreach (XElement xe in xe_package_references_include_attribute)
							{
								nuget_id = xe.Attribute("Include").Value;
							}

							/*
							 
							 */
							IEnumerable<XElement> xe_package_references_version_attribute = null;
							xe_package_references_version_attribute =
								xdoc.XPathSelectElements("//PackageReference[@Version]");

							/*
							 
							 */
							IEnumerable<XElement> xe_package_references_version_node = null;
							xe_package_references_version_node = xdoc.XPathSelectElements("//PackageReference/Version");

							if
							(
								xe_package_references_version_attribute != null
								&&
								xe_package_references_version_attribute.Any()
							)
							{
								// There are Version (Attributes)
								foreach (XElement xe in xe_package_references_version_attribute)
								{
									version = xe.Attribute("Version").Value;
									string nuget_id_version_attribute = xe.Attribute("Include").Value;

									if 
										(
											! packages_with_versions_found.ContainsKey
																				(
																					(
																						nuget_id: nuget_id_version_attribute,
																						version: version
																					)
																				)
										)
									{
										packages_with_versions_found.Add
																		(
																			(
																				nuget_id: nuget_id_version_attribute,
																				version: version
																			),
																			(
																				snippet_original: null,
																				snippet_new: null
																			)
																		);
									}

								}
							}

							if
							(
								xe_package_references_version_node != null
								&&
								xe_package_references_version_node.Any()
							)
							{
								// There are Version (Nodes)
								foreach (XElement xe in xe_package_references_version_node)
								{
									if (xe.Name == "Version")
									{
										version = xe.Value;
										string nuget_id_version_node = xe.Parent.Attribute("Include").Value;
										packages_with_versions_found.Add
																		(
																			(
																				nuget_id: nuget_id_version_node,
																				version: version
																			),
																			(
																				snippet_original: null,
																				snippet_new: null
																			)
																		);
									}
								}
							}

							// Version is null or empty => Central Package Management
							if
							(
								xe_package_references != null
								&&
								xe_package_references.Any()
								&&
								(
									xe_package_references_version_attribute == null
									||
									(
										//xe_package_references_version_attribute != null
										//&&
										! xe_package_references_version_attribute.Any()
									)
								)
								&&
								(
									xe_package_references_version_node == null
									||
									(
										//xe_package_references_version_node != null
										//&&
										! xe_package_references_version_node.Any()
									)
								)
							)
							{
								// Central Package Management
							}
							else
							{
								// No PackageReferences
								// TODO: check packages.config
							}

							foreach (XElement xe in xe_package_references_version_attribute)
							{
								if (xe.Attribute("Version") != null)
								{
									version = xe.Attribute("Version").Value;
									text_snippet_original = xe.ToString();
								}
								else
								{
									continue;
								}
							}

							foreach (XElement xe in xe_package_references_version_node)
							{
                                version = xe.Value; //.Select(n => { return true; });
                                text_snippet_original = xe.Parent.ToString();

                                if (xe.Element("Version") != null)
								{
									continue;
								}
							}

							if (nuget_id == null)
							{
								string msg = "nuget_id is null";
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
							//------------------------------------------------------------------------------------------------------
                            //------------------------------------------------------------------------------------------------------
                            // PackageVersion

                            //------------------------------------------------------------------------------------------------------
                            
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
                            
                            // Console.WriteLine($"nuget_id:		{Environment.NewLine}			{nuget_id}");
                            // Console.WriteLine($"	version:			{Environment.NewLine}	{version}");
                            // Console.WriteLine($"		outer_xml:		{Environment.NewLine}	{outer_xml}");
                            
                            return;
						}

					);

		return;
	}
}
