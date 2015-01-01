using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mbackup
{
    /// <summary>
    /// The interface which represents a file system. 
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
        /// Set a TreeNodeCollection of the TreeView in passed folder.
        /// TreeNodeCollection is cleared when this method is invoked.
        /// </summary>
        /// <param name="nodeCollection">The Treeview in which nodes are added.</param>
        /// <param name="folderPath">A full path of the folder.</param>
        /// <returns>TreeNodeCollection</returns
        void setFolderTreeNodeCollection(TreeView treeView, string folderPath);
    }
}
