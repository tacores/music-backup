using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    /// <summary>
    /// This class represents a folder that you want to backup.
    /// </summary>
    public class SourceFolder
    {
        public SourceFolder(string alias, string path)
        {
            Alias = alias;
            Path = path;
        }

        /// <summary>
        /// Alias is used to destination folder name.
        /// It should be unique in the application.
        /// </summary>
        public string Alias
        {
            get;
            set;
        }

        /// <summary>
        /// Path represents a source folder path.
        /// </summary>
        public string Path
        {
            get;
            set;
        }
    }
}
