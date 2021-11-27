using System.Collections.Generic;

namespace Core.IO
{
    /// <summary>
    /// Directory
    /// </summary>
    public partial class FileSystem
    {
        public string Name
        {
            get;
            set;
        }

        public IEnumerable<FileSystemItem> FileSystemItems
        {
            get;
            set;
        }
    }
}
