﻿namespace mbackup
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxFolder = new System.Windows.Forms.ListBox();
            this.treeViewSrcFolder = new System.Windows.Forms.TreeView();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonRemoveFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxDstFolder = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "バックアップ対象フォルダ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "バックアップ先";
            // 
            // listBoxFolder
            // 
            this.listBoxFolder.FormattingEnabled = true;
            this.listBoxFolder.ItemHeight = 12;
            this.listBoxFolder.Location = new System.Drawing.Point(14, 53);
            this.listBoxFolder.Name = "listBoxFolder";
            this.listBoxFolder.Size = new System.Drawing.Size(297, 76);
            this.listBoxFolder.TabIndex = 2;
            // 
            // treeViewSrcFolder
            // 
            this.treeViewSrcFolder.Location = new System.Drawing.Point(14, 135);
            this.treeViewSrcFolder.Name = "treeViewSrcFolder";
            this.treeViewSrcFolder.Size = new System.Drawing.Size(297, 236);
            this.treeViewSrcFolder.TabIndex = 3;
            // 
            // buttonAddFolder
            // 
            this.buttonAddFolder.Location = new System.Drawing.Point(14, 24);
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.buttonAddFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFolder.TabIndex = 4;
            this.buttonAddFolder.Text = "追加";
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveFolder
            // 
            this.buttonRemoveFolder.Location = new System.Drawing.Point(95, 24);
            this.buttonRemoveFolder.Name = "buttonRemoveFolder";
            this.buttonRemoveFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveFolder.TabIndex = 5;
            this.buttonRemoveFolder.Text = "除外";
            this.buttonRemoveFolder.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "残容量";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "コピー";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 377);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(752, 73);
            this.dataGridView1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "必要な容量";
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(691, 9);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFolder.TabIndex = 10;
            this.buttonSelectFolder.Text = "選択";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            // 
            // textBoxDstFolder
            // 
            this.textBoxDstFolder.Location = new System.Drawing.Point(373, 11);
            this.textBoxDstFolder.Name = "textBoxDstFolder";
            this.textBoxDstFolder.Size = new System.Drawing.Size(312, 19);
            this.textBoxDstFolder.TabIndex = 11;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(457, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(309, 275);
            this.treeView1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 456);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBoxDstFolder);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRemoveFolder);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.treeViewSrcFolder);
            this.Controls.Add(this.listBoxFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "mbackup";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFolder;
        private System.Windows.Forms.TreeView treeViewSrcFolder;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonRemoveFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TextBox textBoxDstFolder;
        private System.Windows.Forms.TreeView treeView1;
    }
}
