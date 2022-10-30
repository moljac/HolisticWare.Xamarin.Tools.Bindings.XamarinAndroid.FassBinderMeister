using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerDotNetGlobalJSON
						:
						NeekerBase
{
	public NeekerDotNetGlobalJSON ()
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

							// https://learn.microsoft.com/en-us/dotnet/core/tools/global-json
							// 
							Newtonsoft.Json.Linq.JObject json_object = null;

							using (StringReader string_reader = new StringReader(System.IO.File.ReadAllText(file)))
							{
								Newtonsoft.Json.JsonTextReader jtr = new Newtonsoft.Json.JsonTextReader(string_reader);
								json_object = (Newtonsoft.Json.Linq.JObject) Newtonsoft.Json.Linq.JToken.ReadFrom(jtr);
							}

							foreach(Newtonsoft.Json.Linq.JProperty jp in json_object["sdk"])
							{
								string version  = (string) jp.Value;
							}

							List
								<(
									string nuget_id, 
									string version
								)> msbuild_sdks = new List
														<(
															string nuget_id, 
															string vetsion
														)>();
							
							foreach(Newtonsoft.Json.Linq.JProperty jp in json_object["msbuild-sdks"])
							{
								string name  = (string) jp.Name;
								string value  = (string) jp.Value;
								msbuild_sdks.Add((name, value));
							}							
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
