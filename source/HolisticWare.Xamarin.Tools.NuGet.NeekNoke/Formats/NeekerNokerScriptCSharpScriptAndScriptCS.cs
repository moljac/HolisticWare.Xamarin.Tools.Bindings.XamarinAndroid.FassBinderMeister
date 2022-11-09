using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerScriptCSharpScriptAndScriptCS
                        :
						NeekerNokerBase
{
	public NeekerScriptCSharpScriptAndScriptCS()
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
