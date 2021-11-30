using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Core.Net.HTTP.IO
{
    public class FileSystem
                    :
                    Directory
    {
        public FileSystem(string url)
            : this(new Uri(url))
        {
            return;
        }

        public FileSystem(Uri url)
        {
            this.URL = url;
            base.URL = url;

            this.DirectoryNamesIgnored = new List<string>
                            {
                                // MavenCentralSonatype
                                "..",
                                // Nuxeo
                                "Parent Directory",
                                "&&id",
                            };

            return;
        }

        public Uri URL
        {
            get;

            set;
        }

        public IEnumerable<FileSystemItem> FileSystemItems
        {
            get;
            set;
        }

        public List<string> FileExtensions
        {
            get;
            set;
        } = new List<string>
        {
            ".txt",
            ".xml",
            ".json",
            ".zip",

        };

        /*
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

            HtmlWeb web = new HtmlWeb();
            HtmlDocument html_doc = web.LoadFromWebAsync(url_root).Result;

            IEnumerable<HtmlNode> links = html_doc.DocumentNode.Descendants("a");

            result = new List<FileSystemItem>();

            foreach (HtmlNode link in links)
            {
                foreach (string dni in this.DirectoryNamesIgnored)
                {
                    if (url_root.Contains(dni))
                    {

                        continue;
                    }
                }

                string file_extension = System.IO.Path.GetExtension(link.InnerHtml);

                if (string.IsNullOrEmpty(file_extension))
                {
                    Directory d = new Directory()
                                        {
                                            Name = link.InnerHtml,
                                            UrlTextual = $"{url_root}/{link.InnerHtml}",
                                        };

                    result.Add(d);
                    List<FileSystemItem> directories = await d.BuildAsync();
                    d.FileSystemItems = directories;
                }
                else
                {
                    File f = new File()
                                        {
                                            Name = link.InnerHtml,
                                            UrlTextual = $"{url_root}/{link.InnerHtml}",
                                        };

                    result.Add(f);
                }
            }

            this.FileSystemItems = result;

            return result;
        }
        */
    }
}
