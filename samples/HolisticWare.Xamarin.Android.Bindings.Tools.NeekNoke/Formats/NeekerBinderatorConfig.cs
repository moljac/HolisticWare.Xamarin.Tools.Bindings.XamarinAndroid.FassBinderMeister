namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerBinderatorConfig
						:
						NeekerBase
{
	public NeekerBinderatorConfig ()
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
							this.Result.Log.Add(file, $" file {file}");
						}
					);

        return;        
    }

	public partial class ResultData
	{
		public 
			Dictionary<string, string>
										Log
		{
			get;
			set;			
		}

	}
}
