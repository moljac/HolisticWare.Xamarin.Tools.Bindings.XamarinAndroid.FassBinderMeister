using System;
using System.Collections.Generic;

namespace Core.Net.HTTP.IO
{
    /// <summary>
    /// Directory
    /// </summary>
    public partial class FileSystemItem
    {
        public IEnumerable<FileSystemItem> FileSystemItems
        {
            get;
            set;
        }

        protected string name;

        public string Name
        {
            get;
            set;
        }

        protected string url_textual;

        public string UrlTextual
        {
            get
            {
                return url_textual;
            }

            set
            {
                url_textual = value;
                url = new Uri(url_textual);

                return;
            }
        }

        protected Uri url;

        public Uri URL
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
                url_textual = url.AbsoluteUri;

                return;
            }
        }
    }
}
