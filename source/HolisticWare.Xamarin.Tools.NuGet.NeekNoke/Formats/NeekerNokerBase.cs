using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using HolisticWare.Xamarin.Tools.NuGet.ServerAPI;

namespace HolisticWare.Xamarin.Android.Bindings.Tools.NeekNoke.Formats;

public partial class NeekerNokerBase
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
        ResultsPerFile
                                        ResultsPerFile
    {
        get;
        set;
    }

    public 
                                        NeekerNokerBase
                                            (
                                            )
    {
        this.ResultsPerFile = new ResultsPerFile();
        
        return;
    }
}
