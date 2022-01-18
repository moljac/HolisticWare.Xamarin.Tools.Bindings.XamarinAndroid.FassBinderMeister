using System.Collections.Generic;

using Newtonsoft.Json;


namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister.Binderator.NewtonSoft
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public partial class ConfigArray
    {
        public List<ConfigRoot> ConfigRoots
        {
            get;
            set;
        }
    }

}
