using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace HolisticWare.Xamarin.Tools.Bindings.XamarinAndroid.FassBinderMeister
{
   public class ReleaseNotesHTMLData
    {
        public ReleaseNotesHTMLData()
        {

        }

        public string Url
        {
            get;
            set;
        } = "BinderatorConfigData/PROJECT/TIMESTAMP/config.json";

        public async Task<List<string>> ParseAsync()
        {
            string html =
                        //@"https://developer.android.com/jetpack/androidx/versions/all-channel"
                        @"https://developer.android.com/jetpack/androidx/versions/stable-channel"
                        ;

            HtmlWeb web = new HtmlWeb();

            HtmlDocument htmlDoc = await web.LoadFromWebAsync(html);

            HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

            Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);

            List<string> configs_strings = new List<string>();

            return configs_strings;
        }
    }
}
