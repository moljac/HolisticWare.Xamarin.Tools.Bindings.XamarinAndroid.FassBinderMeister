using System;
using System.Collections.Generic;
using HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke
{
	public partial class
                                        ResultsPerFilePattern
    {
		public ResultsPerFilePattern()
		{
		}

        public
            Dictionary<string, ResultsPerFile>
                                        ResultsPerFile
        {
            get;

            internal set;
        }
        public
            NeekerNokerBase
                                        NeekNokeFormatter
        {
            get;
            internal set;
        }
    }
}

