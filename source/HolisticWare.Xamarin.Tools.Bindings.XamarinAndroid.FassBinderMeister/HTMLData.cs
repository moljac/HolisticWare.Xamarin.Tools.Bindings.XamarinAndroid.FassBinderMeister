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

        public async Task<ReleaseNotesHistory> ParseAsync()
        {
            string html =
                        //@"https://developer.android.com/jetpack/androidx/versions/all-channel"
                        @"https://developer.android.com/jetpack/androidx/versions/stable-channel"
                        ;

            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = await web.LoadFromWebAsync(html);

            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes
                                                            (
                                                                //"//head/title"
                                                                //"//h3[@data-text]"
                                                                "//div[contains(@class, 'devsite-article-body')]"
                                                            );

            List<ReleaseNote> release_notes = new List<ReleaseNote>();

            ReleaseNote rn = null;

            foreach (HtmlNode node in nodes.Descendants())
            {   
                if (node.Name == "h3")
                {
                    string inner_html = node.InnerHtml;
                    DateTime date_time_release = DateTime.Parse(inner_html);

                    rn = new ReleaseNote()
                    {
                        Date = date_time_release
                    };
                    release_notes.Add(rn);
                }
                if (node.Name == "ul")
                {
                    foreach(HtmlNode node_ul in node.ChildNodes)
                    {
                        if (node_ul.Name == "li")
                        {
                            string inner_text = node_ul.InnerText;
                            rn.Artifacts.Add(inner_text);
                        }
                    }
                }

            }

            ReleaseNotesHistory release_notes_history = new ReleaseNotesHistory()
            {
                Count = release_notes.Count,
                Date = DateTime.Today,
                ReleaseNotes = release_notes
            };

            string json_string;
            json_string = System.Text.Json.JsonSerializer.Serialize(release_notes_history);
            System.IO.File.WriteAllText("release-notes-20201110.md", json_string);

            return release_notes_history;
        }
    }
}
