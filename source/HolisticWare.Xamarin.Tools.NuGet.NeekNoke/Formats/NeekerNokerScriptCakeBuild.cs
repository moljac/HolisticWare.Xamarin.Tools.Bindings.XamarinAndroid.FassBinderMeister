using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerScriptCakeBuild
						:
						NeekerNokerBase
{
	public NeekerScriptCakeBuild ()
	{
		this.Result = new ResultData();

		return;
	}

	public
		ResultData
										Result
	{
		get;
		set;
	}

	public 
		void
										Neek
										(
											string[] files
										)										
	{
		// initialize result, so Add does not crash (parallel) and no Concurrent Collections are needed
		foreach (string file in files)
		{
			this.Result.Log.Add(file, "");
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
							string[] lines = System.IO.File.ReadLines(file).ToArray();

							foreach(string line in lines)
							{
								switch (line)
								{
									case string line_preprocessor when line.StartsWith("#"):
										line_preprocessor = line.Replace("#", "").Trim();
										switch (line_preprocessor)
										{
											case string preprocessor_cmd when line_preprocessor.StartsWith("addin"):
												break;
											case string preprocessor_cmd when line_preprocessor.StartsWith("tool"):
												break;
											default:
												break;
										}
										break;
									default:
										break;
								}
							}

							this.Result.Log[file] = $" file {file}";
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
