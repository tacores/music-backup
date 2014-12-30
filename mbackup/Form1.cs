using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mbackup
{
    public partial class Form1 : Form
    {
        private FileSystem fileSystem;
        private Setting setting;

        public Form1()
        {
            InitializeComponent();

            fileSystem = new FileSystemImpl();
            //setting = new SettingXmlImpl(fileSystem);
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            textBoxDstFolder.Text = fileSystem.selectFolder();
        }

        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            string folder = fileSystem.selectFolder();
            listBoxFolder.Items.Add(folder);
        }

        private void listBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string folder = (string)listBoxFolder.SelectedItem;

            fileSystem.setFolderTreeNodeCollection(treeViewSrcFolder, folder);
        }
    }
}
