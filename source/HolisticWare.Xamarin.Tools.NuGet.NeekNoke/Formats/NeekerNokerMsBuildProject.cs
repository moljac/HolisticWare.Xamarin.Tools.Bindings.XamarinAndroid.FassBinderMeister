using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerMsBuildProject
						:
						NeekerNokerBase
{
	public
        Dictionary
            <
                string,
                (
                    string file_backup,
                    string content,
                    string content_backup
                )
            >
                                            Neek
                                                    (
														string[] files
													)										
	{
		// initialize result, so Add does not crash (parallel) and no Concurrent Collections are needed
		foreach (string file in files)
		{
			log.Add
					(
						file,
						(
							file_backup: "",
							content: null,
							content_backup: null
						)
					);
		}

		Parallel.ForEach
					(
						files,
						file =>
						{
							string extension = Path.GetExtension(file);
							string ts = DateTime.Now.ToString("yyyyMMdd-HHmmss");
							string file_new = Path.ChangeExtension
															(
																file, 
																$"bckp-ts-{ts}{extension}"
															);
							System.IO.File.Copy(file, file_new);
							string content_original = System.IO.File.ReadAllText(file);
                            string content_new = System.IO.File.ReadAllText(file_new);
                            string nuget_id = null;
                            string version = null;
                            string version_override = null;
                            string inner_text = null;
                            string outer_xml = null;
                            string text_snippet_original = null;
                            string text_snippet_new = null;

                            XDocument xdoc = null;
                            try
							{
								xdoc = XDocument.Load(file);
							}
							catch (System.Exception exc)
							{
								Trace.WriteLine(exc.Message);
								throw;
							}
							Trace.WriteLine($"file:		{Environment.NewLine}	{file}");

							//------------------------------------------------------------------------------------------------------
							// PackageReference

							IEnumerable<XElement> xe_package_references = null;
							xe_package_references = xdoc.XPathSelectElements("//PackageReference");
							/*
							 
							 */
							IEnumerable<XElement> xe_package_references_version_attribute = null;
							xe_package_references_version_attribute = xdoc.XPathSelectElements("//PackageReference[@Version]");

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
											xe_package_references_version_attribute != null
											&&
											! xe_package_references_version_attribute.Any()
										)
									)
									&&
									(
										xe_package_references_version_node == null
										||
										(
											xe_package_references_version_node != null
											&&
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
									continue;
								}
							}
							foreach (XElement xe in xe_package_references_version_node)
							{
								if (xe.Element("Version") != null)
								{
									//version = xe.Nodes().Select(n => { return true; });
									continue;
								}
							}

							package_references.Add
				                                (
					                                (
						                                nuget_id: nuget_id,
						                                version: version,
						                                versions_upgradeable: null,
						                                text_snippet_original: text_snippet_original,
						                                text_snippet_new: text_snippet_new
					                                )
				                                );
                            //------------------------------------------------------------------------------------------------------
                            //------------------------------------------------------------------------------------------------------
                            // PackageVersion
                            
                            //------------------------------------------------------------------------------------------------------


                            log[file] =
										(
											file_backup: file_new,
											content: content_original,
											content_backup: content_new
										);
                            
                            Console.WriteLine($"nuget_id:		{Environment.NewLine}			{nuget_id}");
                            Console.WriteLine($"	version:			{Environment.NewLine}	{version}");
                            Console.WriteLine($"		outer_xml:		{Environment.NewLine}	{outer_xml}");
                            
                            return;
						}

					);

		this.Log = log;

		return log;        
	}
}
