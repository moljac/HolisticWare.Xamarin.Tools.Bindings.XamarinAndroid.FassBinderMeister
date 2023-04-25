using System.Collections.Generic;

using HolisticWare.Xamarin.Tools.NuGet.NeekNoke;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke;

public partial class
                                        ResultsPerFormat
{
    public 
        Dictionary
                <
                    string,             // format regex
                    ResultsPerFilePattern
                >
                                        ResultsPerFilePattern
    {
        get;
        set;
    }

    public 
                                        ResultsPerFormat
                                            (
                                            )
    {
        this.ResultsPerFilePattern = new Dictionary
                                            <
                                                string,                     // format / pattern
                                                ResultsPerFilePattern
                                            >
        {
        };

        return;
    }
}
