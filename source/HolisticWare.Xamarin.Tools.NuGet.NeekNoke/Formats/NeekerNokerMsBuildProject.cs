using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

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

                            System.Xml.XmlDocument xmldoc = null;
							System.Xml.XmlNamespaceManager ns1 = null;

							string xpath = null;
							//  namespace is required, otherwise NRE
							string xml_namespace_name = "msbuild_project"; // string conntent is irrelevant

							xmldoc = new System.Xml.XmlDocument();
							ns1 = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);
							ns1.AddNamespace(xml_namespace_name, "http://schemas.microsoft.com/developer/msbuild/2003");

							try
							{
								xmldoc.Load(file.ToString());
							}
							catch (System.Xml.XmlException exc_xml)
							{
								Console.WriteLine(exc_xml.Message);
								throw;
							}
							Console.WriteLine($"file:		{Environment.NewLine}	{file}");

							//------------------------------------------------------------------------------------------------------
							// PackageReference
							xpath = "//msbuild_project:Project/msbuild_project:ItemGroup/msbuild_project:PackageReference";
							
                            System.Xml.XmlNodeList node_list_package_references = xmldoc.SelectNodes(xpath, ns1);

                            foreach (System.Xml.XmlNode node in node_list_package_references)
							{
								// nuget id is in Include attribute
								System.Xml.XmlAttribute xml_attribute_include = node.Attributes["Include"];
                                // nuget version could be in
								//		Version attribute
                                System.Xml.XmlAttribute xml_attribute_version = node.Attributes["Version"];
								//		Version node
								if (xml_attribute_version == null)
								{
									System.Xml.XmlNode xml_node_version = node.SelectSingleNode("Version", ns1);
                                    
									if (xml_node_version == null)
									{
										// NOOP
										// version can be null in NuGet central Pakcage Management
									}
									else
									{
                                        version = xml_node_version.Value;
                                    }
                                }
                                else
								{
                                    version = xml_attribute_version.Value;
                                }

                                //		VersionOverride attribute
                                System.Xml.XmlAttribute xml_attribute_version_override = node.Attributes["VersionOverride"];

                                if (xml_attribute_version_override == null)
                                {
                                    System.Xml.XmlNode xml_node_version_override = node.SelectSingleNode("VersionOverride", ns1);

                                    if (xml_node_version_override == null)
                                    {
                                        // NOOP
                                        // version can be null in NuGet Central Pakcage Management
                                    }
                                    else
                                    {
                                        version_override = xml_node_version_override.Value;
                                    }
                                }
                                else
                                {
                                    version_override = xml_attribute_version_override.Value;
                                }

                                nuget_id = xml_attribute_include.Value;

								if (version == null && version_override != null)
								{
									version = version_override;
                                }
								
                                inner_text = node.InnerText; //.Value;
                                outer_xml = node.OuterXml; //.Value;
                                
                                //if (version != null)
                                {
	                                // add only if Version is defined (not null)
	                                // otherwise it is NuGet Central Package Management and defined in other file
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
                                }
							}
                            //------------------------------------------------------------------------------------------------------
                            //------------------------------------------------------------------------------------------------------
                            // PackageVersion
                            xpath = "//msbuild_project:Project/msbuild_project:ItemGroup/msbuild_project:PackageVersion";

                            List
                                <
                                    (
                                        string nuget_id,
                                        string version_current,
                                        string[] versions_updateable
                                    )
                                > package_versions = null;

                            package_references = new List
                                                        <
                                                            (
                                                                string nuget_id,
                                                                string version,
                                                                string[] versions_upgradeable,
																string text_snippet_original,
																string text_snippet_new
                                                            )
                                                        >();

                            System.Xml.XmlNodeList node_list_package_versions = xmldoc.SelectNodes(xpath, ns1);

							foreach (System.Xml.XmlNode node in node_list_package_versions)
							{
								// nuget id is in Include attribute
								System.Xml.XmlAttribute xml_attribute_include = node.Attributes["Include"];
								// nuget version could be in
								//		Version attribute
								System.Xml.XmlAttribute xml_attribute_version = node.Attributes["Version"];
								//		Version node
								if (xml_attribute_version == null)
								{
									System.Xml.XmlNode xml_node_version = node.SelectSingleNode("Version", ns1);

									if (xml_node_version == null)
									{
										// NOOP
										// version can be null in NuGet Central Pakcage Management
									}
									else
									{
										version = xml_node_version.Value;
									}
								}
								else
								{
									version = xml_attribute_version.Value;
								}

                                nuget_id = xml_attribute_include.Value;

                                if (version == null && version_override != null)
                                {
                                    version = version_override;
                                }

                                inner_text = node.InnerText; //.Value;
                                outer_xml = node.OuterXml; //.Value;

                                //if (version != null)
                                {
                                    // add only if Version is defined (not null)
                                    // otherwise it is NuGet Central Package Management and defined in other file
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
                                }
							}
                            //------------------------------------------------------------------------------------------------------

                            /*
							XDocument xDoc = XDocument.Load(file);

							XNamespace ns2 = XNamespace.Get("http://schemas.microsoft.com/developer/msbuild/2003");

							//References "By DLL (file)"
							var list1 = from list in xDoc.Descendants(ns2 + "ItemGroup")
										from item in list.Elements(ns2 + "PackageReference")
											// where item.Element(ns + "HintPath") != null
										select new
										{
											CsProjFileName = file,
											ReferenceInclude = item.Attribute("Include").Value,
											RefType = (item.Element(ns2 + "HintPath") == null) ? "CompiledDLLInGac" : "CompiledDLL",
											HintPath = (item.Element(ns2 + "HintPath") == null) ? string.Empty : item.Element(ns2 + "HintPath").Value
										};


							foreach (var v in list1)
							{
								Console.WriteLine(v.ToString());
							}


							//References "By Project"
							var list2 = from list in xDoc.Descendants(ns2 + "ItemGroup")
										from item in list.Elements(ns2 + "ProjectReference")
										where
										item.Element(ns2 + "Project") != null
										select new
										{
											CsProjFileName = file,
											ReferenceInclude = item.Attribute("Include").Value,
											RefType = "ProjectReference",
											ProjectGuid = item.Element(ns2 + "Project").Value
										};


							foreach (var v in list2)
							{
								Console.WriteLine(v.ToString());
							}

							//References "By Project"
							var list3 = from list in xDoc.Descendants(ns2 + "ItemGroup")
										from item in list.Elements(ns2 + "PackageReference")
										where
										item.Element(ns2 + "Project") != null
										select new
										{
											CsProjFileName = file,
											ReferenceInclude = item.Attribute("Include").Value,
											RefType = "ProjectReference",
											ProjectGuid = item.Element(ns2 + "Project").Value
										};


							foreach (var v in list2)
							{
								Console.WriteLine(v.ToString());
							}
							*/

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
