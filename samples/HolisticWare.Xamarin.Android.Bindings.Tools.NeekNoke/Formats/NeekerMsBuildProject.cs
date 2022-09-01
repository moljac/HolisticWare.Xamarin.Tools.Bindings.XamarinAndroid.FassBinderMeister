namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerMsBuildProject
						:
						NeekerBase
{
	public 
		Dictionary<string, string> 
										Log
	{
		get;
		protected set;
	}

	public 
		void
										Neek
										(
											string[] files
										)										
    {
		Dictionary<string, string> log = new Dictionary<string, string>();

		// initialize result, so Add does not crash (parallel) and no Concurrent Collections are needed
		foreach (string file in files)
		{
			log.Add(file, "");
		}

		Parallel.ForEach
					(
						files,
						file =>
						{
							log.Add(file, $" file {file}");
						}
					);

		this.Log = log;

        return;        
    }
}
