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

        public async
            Task<ReleaseNotesHistory>
                                        ParseAsync
                                                (
                                                    string html
                                                )
        {
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36";
            web.PreRequest = OnPreRequest;
            HtmlDocument html_doc = await web.LoadFromWebAsync(html);
            HtmlNodeCollection nodes = null;

            HtmlNode node_title = html_doc.DocumentNode.SelectSingleNode("//head/title");

            if (node_title.InnerText == "Moved Temporarily")
            {
                HtmlNodeCollection node_href = html_doc.DocumentNode.SelectNodes("//A");
                html_doc = await web.LoadFromWebAsync(html);
            }

            if
                (
                    html == ReleaseNotesUrls.AndroidX.Stable
                    ||
                    html == ReleaseNotesUrls.AndroidX.RC
                    ||
                    html == ReleaseNotesUrls.AndroidX.Beta
                    ||
                    html == ReleaseNotesUrls.AndroidX.Alpha
                )
            {
                nodes = html_doc.DocumentNode.SelectNodes
                                                    (
                                                        //"//head/title"
                                                        //"//h3[@data-text]"
                                                        //"//div[contains(@class, 'devsite-article-body')]"
                                                        ".//*[contains(@class, 'devsite-article-body')]"
                                                    );
            }
            if
                (
                    html == ReleaseNotesUrls.AndroidX.All
                )
            {
                nodes = html_doc.DocumentNode.SelectNodes
                                                    (
                                                        //"//head/title"
                                                        //"//h3[@data-text]"
                                                        ".//*[contains(@class, 'devsite-article-body')]"
                                                    );
            }

            List<ReleaseNote> release_notes = release_notes = new List<ReleaseNote>();
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
                    foreach (HtmlNode node_ul in node.ChildNodes)
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

            return release_notes_history;
        }

        private static bool OnPreRequest(System.Net.HttpWebRequest request)
        {
            request.AllowAutoRedirect = true;

            return true;
        }
    }
}
