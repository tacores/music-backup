using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mbackup
{
    /// <summary>
    /// This class represents a list of folders that is backupped.
    /// When the folder names are duplicate, this class generates no-duplicate alias.
    /// </summary>
    public class SourceFolderList
    {
        private List<SourceFolder> list;
        private HashSet<string> aliasSet;

        public SourceFolderList()
        {
            list = new List<SourceFolder>();
            aliasSet = new HashSet<string>();
        }

        /// <summary>
        /// Get a list of source folder.
        /// </summary>
        /// <returns>A list of source folder.</returns>
        public List<SourceFolder> getList()
        {
            return list;
        }

        /// <summary>
        /// Add a source folder to the list.
        /// This method create a SourceFolder instance.
        /// Usually this method use a folder name as alias.
        /// But when alias is duplicate, this method generates a no-duplicate alias.
        /// This method throw InvalidOperationException when it cannot generate a alias.
        /// </summary>
        /// <param name="folderPath">A Folder path that you want to backup.</param>
        /// <returns>A SourceFolder instance that is created.</returns>
        public SourceFolder add(string folderPath)
        {
            string alias = createUniqueAlias(folderPath);
            SourceFolder srcFolder = new SourceFolder(alias, folderPath);
            list.Add(srcFolder);
            return srcFolder;
        }

        /// <summary>
        /// Add a source folder to the list.
        /// It should be only used for initialization when load settings.
        /// </summary>
        /// <param name="sourceFolder"></param>
        public void add(SourceFolder sourceFolder)
        {
            aliasSet.Add(sourceFolder.Alias);
            list.Add(sourceFolder);
        }

        private  string createUniqueAlias(string folderPath)
        {
            string alias = new System.IO.DirectoryInfo(folderPath).Name;
            string origin = alias;
            for (int i = 2; i < 10 && aliasSet.Contains(alias); ++i)
            {
                alias = origin + "(" + i + ")";
            }
            if (aliasSet.Contains(alias))
            {
                throw new InvalidOperationException();
            }
            aliasSet.Add(alias);
            return alias;
        }

        /// <summary>
        /// Remove a source folder from the list.
        /// </summary>
        /// <param name="sourceFolder">A source folder that you want to remove.</param>
        public void remove(SourceFolder sourceFolder)
        {
            aliasSet.Remove(sourceFolder.Alias);
            list.Remove(sourceFolder);
        }
    }
}
