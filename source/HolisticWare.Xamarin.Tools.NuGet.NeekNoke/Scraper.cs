using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke;

public class Scraper
{
	public Scraper()
	{
	}

	public 
		Dictionary<string, string[]>
										Harvest
										(
											string[] patterns,
											string location = "."
										)										
	{
		Dictionary<string, string[]> patterns_files = new Dictionary<string, string[]>();

		// initialize result, so Add does not crash (parallel) and no Concurrent Collections are needed
		foreach (string pattern in patterns)
		{
			patterns_files.Add(pattern, new string[] { });
		}

		Parallel.ForEach
					(
						patterns,
						pattern =>
						{
							string[] files_for_pattern = System.IO.Directory.GetFiles
																				(
																					".",
																					pattern,
																					System.IO.SearchOption.AllDirectories
																				);

							patterns_files[pattern] = files_for_pattern;
						}
					);

		return patterns_files;
	}
}



