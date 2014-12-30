using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mbackup
{
    public class FileSystemImpl : FileSystem
    {
        public string selectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "バックアップ先のフォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowNewFolderButton = true;

            string path;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                path = "";
            }
            return path;
        }

        public void copyFile(string srcFilePath, string dstFilePath)
        {
        }

        public void setFolderTreeNodeCollection(TreeView treeView, string folderPath)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            addFolderNode(treeView.Nodes, folderPath);
            treeView.CollapseAll();
            treeView.EndUpdate();
        }

        private void addFolderNode(TreeNodeCollection nodeCollection, string folderPath)
        {
            TreeNode node = nodeCollection.Add(System.IO.Path.GetFileName(folderPath));

            try
            {
                foreach (string name in System.IO.Directory.GetDirectories(folderPath))
                {
                    addFolderNode(node.Nodes, name);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                node.ToolTipText = e.Message;
                //node.ForeColor = 
            }
            catch (Exception)
            {
            }  
            
            try
            {
                foreach (string name in System.IO.Directory.GetFiles(folderPath))
                {
                    addFileNode(node.Nodes, name);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                node.ToolTipText = e.Message;
                //node.ForeColor = 
            }
            catch (Exception)
            {
            }

            node.EnsureVisible();
        }

        private void addFileNode(TreeNodeCollection nodeCollection, string filePath)
        {
            TreeNode node = nodeCollection.Add(System.IO.Path.GetFileName(filePath));
            node.EnsureVisible();
        }
    }
}
