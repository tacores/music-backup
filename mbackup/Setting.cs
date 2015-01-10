using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    /// <summary>
    /// This interface represents application settings such as source folders.
    /// </summary>
    public interface Setting
    {
        /// <summary>
        /// Get a list of source folders (backupped folders)
        /// </summary>
        /// <returns></returns>
        List<SourceFolder> getSrcFolders();

        /// <summary>
        /// Add a source folder path to the list.
        /// A user select the folder via GUI.
        /// If the folder already exists, this method throws AlreadyExistException.
        /// </summary>
        /// <param name="folderPath">A source folder path.</param>
        void addSrcFolder(SourceFolder folderPath);

        /// <summary>
        /// Remove a source folder path from the list.
        /// If the folder doesn't exist on the list, this method throws InvalidOperationException.
        /// </summary>
        /// <param name="folderPath">A source folder path.</param>
        void removeSrcFolder(SourceFolder folderPath);

        void changeSrcFolderAlias(SourceFolder folder);

        /// <summary>
        /// Set a backup destination folder path.
        /// It's expected that external storage is set; such as USB HDD.
        /// </summary>
        /// <param name="folderPath">A destination folder path.</param>
        void setDstFolder(string folderPath);

        /// <summary>
        /// Get a backup destination folder path.
        /// If the folder isn't set, this method returns "".
        /// </summary>
        /// <returns>A destination folder path.</returns>
        string getDstFolder();
    }
}
