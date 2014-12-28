using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mbackup
{
    /// <summary>
    /// An interface that represents file system. 
    /// </summary>
    public interface FileSystem
    {
        /// <summary>
        /// Let a user select a folder.
        /// When canceled, the method returns "".
        /// </summary>
        /// <returns>The folder's full path that a user selected.</returns>
        string selectFolder();

        /// <summary>
        /// Copy a file.
        /// </summary>
        /// <param name="srcPath">Source file full path.</param>
        /// <param name="dstPath">Destination file full path.</param>
        void copyFile(string srcFilePath, string dstFilePath);

        /// <summary>
        /// Create a TreeNodeCollection of the passed folder.
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>TreeNodeCollection</returns>
        TreeNodeCollection createTreeNodeCollection(string folderPath);
    }
}
