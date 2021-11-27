using System.Collections.Generic;

namespace Core.IO
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
    }
}
