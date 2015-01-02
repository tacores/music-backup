﻿using System;
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
            foreach (SourceFolder folder in setting.getSrcFolders())
            {
                listBoxFolder.Items.Add(folder.Path);
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
                    listBoxFolder.Items.Add(path);
                }
                catch (AlreadyExistException)
                {
                }
            }
        }

        private void listBoxFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string folder = (string)listBoxFolder.SelectedItem;

            fileSystem.setFolderTreeNodeCollection(treeViewSrcFolder, folder);
        }

        private void buttonRemoveFolder_Click(object sender, EventArgs e)
        {
            SourceFolder folder = (SourceFolder)listBoxFolder.SelectedItem;
            try
            {
                setting.removeSrcFolder(folder);
                listBoxFolder.Items.Remove(folder);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
