using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mbackup.Exceptions;

namespace mbackup
{
    public partial class MainForm : Form
    {
        private DiContainer container;
        private FileSystem fileSystem;
        private Setting setting;
        private SourceFolderList sourceFolderList;

        public MainForm()
        {
            InitializeComponent();

            container = new DiContainer();
            fileSystem = container.getFileSystem();
            setting = container.getSetting();
            sourceFolderList = new SourceFolderList();

            loadSrcFolderList();
            loadDstFolder();
        }

        private void loadSrcFolderList()
        {
            dataGridViewSrcFolder.Rows.Clear();
            foreach (SourceFolder folder in setting.getSrcFolders())
            {
                sourceFolderList.add(folder);
                dataGridViewSrcFolder.Rows.Add(folder.Alias, folder.Path);
            }
        }

        private void loadDstFolder()
        {
            textBoxDstFolder.Text = setting.getDstFolder();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            string folder = fileSystem.selectFolder();
            if (folder != "")
            {
                setting.setDstFolder(folder);
                textBoxDstFolder.Text = folder;
            }
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            string path = fileSystem.selectFolder();
            if (path != "")
            {
                try
                {
                    SourceFolder folder = sourceFolderList.add(path);
                    setting.addSrcFolder(folder);
                    dataGridViewSrcFolder.Rows.Add(folder.Alias, folder.Path);
                }
                catch (AlreadyExistException)
                {
                }
            }
        }

        /*
        private void listBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string folder = (string)listBoxFolder.SelectedItem;

            fileSystem.setFolderTreeNodeCollection(treeViewSrcFolder, folder);
        }
         */

        private void buttonRemoveFolder_Click(object sender, EventArgs e)
        {
            /*
            SourceFolder folder = (SourceFolder)listBoxFolder.SelectedItem;
            try
            {
                setting.removeSrcFolder(folder);
                listBoxFolder.Items.Remove(folder);
            }
            catch (InvalidOperationException)
            {
            }
             */
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            foreach (SourceFolder folder in sourceFolderList.getList())
            {
                string dstPath = textBoxDstFolder.Text + @"\" + folder.Alias;
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(folder.Path, dstPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
            }
        }

        private void dataGridViewSrcFolder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && 0 <= e.RowIndex)
            {
                SourceFolder folder = sourceFolderList.getList().ElementAt(e.RowIndex);
                folder.Alias = (string)dataGridViewSrcFolder.Rows[e.RowIndex].Cells[0].Value;
                setting.changeSrcFolderAlias(folder);
            }
        }
    }
}
