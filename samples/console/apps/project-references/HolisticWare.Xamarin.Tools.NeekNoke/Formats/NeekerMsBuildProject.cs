using System.Threading.Tasks;
using System.Xml.Linq;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerMsBuildProject
						:
						NeekerBase
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
										Log
	{
		get;
		protected set;
	}

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
		Dictionary
				<
					string,
					(
						string file_backup,
						string content,
						string content_backup
					)
                > log = new Dictionary
								<
									string,
									(
										string file_backup,
										string content,
										string content_backup
									)
                                >();

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
							string content = System.IO.File.ReadAllText(file);
                            string content_new = System.IO.File.ReadAllText(file_new);

                            System.Xml.XmlDocument xmldoc = null;
							System.Xml.XmlNamespaceManager ns1 = null;

							//  namespace is required, otherwise NRE
							string xml_namespace_name = "msbuild_project"; // string conntent is irrelevant

							xmldoc = new System.Xml.XmlDocument();
							xmldoc.Load(file.ToString());
							ns1 = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);
							ns1.AddNamespace(xml_namespace_name, "http://schemas.microsoft.com/developer/msbuild/2003");


							List
								<
									(
										string nuget_id,
										string version
									)
								> package_references = null;

                            package_references = new List
											<
												(
													string nuget_id,
													string version
												)
											>();

                            string xpath = "//msbuild_project:Project/msbuild_project:ItemGroup/msbuild_project:PackageReference";

							System.Xml.XmlNodeList node_list = xmldoc.SelectNodes(xpath, ns1);

							foreach (System.Xml.XmlNode node in node_list)
							{
								System.Xml.XmlAttribute xml_attribute_include = node.Attributes["Include"];
								System.Xml.XmlNode xml_node_version = node.SelectSingleNode("Version", ns1);

								string inner_text = node.InnerText; //.Value;
								string outer_text = node.OuterXml; //.Value;
							}

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
											content: content,
											content_backup: content_new
										);
						}

					);

		this.Log = log;

		return log;        
	}
}
