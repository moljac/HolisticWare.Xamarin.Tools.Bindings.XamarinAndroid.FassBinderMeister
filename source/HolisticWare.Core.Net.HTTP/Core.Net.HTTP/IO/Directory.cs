using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace Core.Net.HTTP.IO
{
    /// <summary>
    /// Directory is FileSystemItem
    /// </summary>
    public partial class Directory
        : FileSystemItem
    {
        protected   List<string> directory_names_ignored;

        public      List<string> DirectoryNamesIgnored
        {
            get
            {
                return this.directory_names_ignored;
            }

            set
            {
                if (null == this.directory_names_ignored)
                {
                    this.directory_names_ignored = new List<string>();
                }

                this.directory_names_ignored.AddRange(value);
                this.directory_names_ignored.Sort();
                this.directory_names_ignored = this.directory_names_ignored.Distinct().ToList();

                return;
            }
        }

        public async
            Task<List<FileSystemItem>>
                                            BuildAsync
                                                    (
                                                        Uri url = null
                                                    )

        {
            List<FileSystemItem> result = null;

            if (url == null)
            {
                if (this.URL == null)
                {
                    throw new ArgumentNullException("Url undefined");
                }

                url = this.URL;
            }

            string url_root = url.AbsoluteUri;
            System.Diagnostics.Trace.WriteLine($"url = {url_root}");

            HtmlWeb web = new HtmlWeb();
            HtmlDocument html_doc = web.LoadFromWebAsync(url_root).Result;

            IEnumerable<HtmlNode> links = html_doc.DocumentNode.Descendants("a");

            result = new List<FileSystemItem>();

            HtmlNodeCollection html_nodes = html_doc.DocumentNode
                                                        .SelectNodes("//a[@href]")
                                                        ;
            if (null == html_nodes)
            {
                return null;
            }

            List<string> directory_names = html_nodes
                                                    .Where(html_node => ! string.IsNullOrEmpty(html_node.InnerHtml) )
                                                    .Select(html_node => html_node.InnerHtml)
                                                    .Except(this.DirectoryNamesIgnored)
                                                    .ToList()
                                                    ;
            foreach (string link in directory_names)
            {
                string file_extension = System.IO.Path.GetExtension(link);

                if (string.IsNullOrEmpty(file_extension))
                {
                    Directory d = new Directory()
                    {
                        Name = link,
                        UrlTextual = $"{url_root}/{link}",
                        DirectoryNamesIgnored = this.DirectoryNamesIgnored,
                    };

                    result.Add(d);

                    d.FileSystemItems = await d.BuildAsync();
                }
                else
                {
                    File f = new File()
                    {
                        Name = link,
                        UrlTextual = $"{url_root}/{link}",
                    };

                    result.Add(f);
                }
            }

            return result;
        }
    }
}
