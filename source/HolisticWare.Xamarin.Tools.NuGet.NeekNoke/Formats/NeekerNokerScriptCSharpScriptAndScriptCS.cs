using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerNokerScriptCSharpScriptAndScriptCS
                        :
						NeekerNokerBase
{
	public 
										NeekerNokerScriptCSharpScriptAndScriptCS
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

							// #r "nuget:Newtonsoft.Json"
							// #r "nuget: AutoMapper, 6.1.0"
							// #r "nuget:Newtonsoft.Json,1.20"
							
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
							;
						}
					);

        return;        
    }

	public partial class ResultData
	{
		public ResultData()
		{
			this.Log = new Dictionary<string, string>();
			
			return;
		}

		public 
			Dictionary<string, string>
										Log
		{
			get;
			set;			
		}

	}
}
