using System.Collections.Generic;
using System.Net;
using System.Net.Http;

using HolisticWare.Xamarin.Tools.NuGet.NeekNoke;
using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

namespace HolisticWare.Xamarin.Tools.NuGet.NeekNoke.Formats;

public partial class
                                        NeekerNokerBase
{
    static 
                                        NeekerNokerBase
                                            (
                                            )
    {
        HttpClientHandler handler = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        NuGetClient.HttpClient = new HttpClient(handler);

        return;
    }

    public
        NeekerNoker
                                        NeekNoker
    {
        get;
        set;
    }

    public
        virtual
        Dictionary
            <
                string,
                ResultsPerFilePattern
            >
                                        ResultsPerFilePattern
    {
        get;
        set;
    }

    public 
                                        NeekerNokerBase
                                            (
                                            )
    {
        this.ResultsPerFilePattern = new Dictionary<string, ResultsPerFilePattern>();
        
        return;
    }
}
