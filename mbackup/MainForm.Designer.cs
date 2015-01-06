namespace mbackup
{
    partial class MainForm
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
            this.treeViewSrcFolder = new System.Windows.Forms.TreeView();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonRemoveFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxDstFolder = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridViewSrcFolder = new System.Windows.Forms.DataGridView();
            this.buttonCalcSize = new System.Windows.Forms.Button();
            this.Alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SrcFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSrcFolder)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(394, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "バックアップ先";
            // 
            // treeViewSrcFolder
            // 
            this.treeViewSrcFolder.Location = new System.Drawing.Point(14, 214);
            this.treeViewSrcFolder.Name = "treeViewSrcFolder";
            this.treeViewSrcFolder.Size = new System.Drawing.Size(297, 230);
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
            this.buttonAddFolder.Click += new System.EventHandler(this.buttonAddFolder_Click);
            // 
            // buttonRemoveFolder
            // 
            this.buttonRemoveFolder.Location = new System.Drawing.Point(95, 24);
            this.buttonRemoveFolder.Name = "buttonRemoveFolder";
            this.buttonRemoveFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveFolder.TabIndex = 5;
            this.buttonRemoveFolder.Text = "除外";
            this.buttonRemoveFolder.UseVisualStyleBackColor = true;
            this.buttonRemoveFolder.Click += new System.EventHandler(this.buttonRemoveFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "残容量";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(317, 69);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(134, 46);
            this.buttonCopy.TabIndex = 7;
            this.buttonCopy.Text = "コピー";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 420);
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
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // textBoxDstFolder
            // 
            this.textBoxDstFolder.Location = new System.Drawing.Point(467, 11);
            this.textBoxDstFolder.Name = "textBoxDstFolder";
            this.textBoxDstFolder.Size = new System.Drawing.Size(218, 19);
            this.textBoxDstFolder.TabIndex = 11;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(457, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(309, 340);
            this.treeView1.TabIndex = 12;
            // 
            // dataGridViewSrcFolder
            // 
            this.dataGridViewSrcFolder.AllowUserToAddRows = false;
            this.dataGridViewSrcFolder.AllowUserToDeleteRows = false;
            this.dataGridViewSrcFolder.AllowUserToResizeRows = false;
            this.dataGridViewSrcFolder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSrcFolder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Alias,
            this.SrcFolder});
            this.dataGridViewSrcFolder.Location = new System.Drawing.Point(14, 53);
            this.dataGridViewSrcFolder.MultiSelect = false;
            this.dataGridViewSrcFolder.Name = "dataGridViewSrcFolder";
            this.dataGridViewSrcFolder.RowTemplate.Height = 21;
            this.dataGridViewSrcFolder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSrcFolder.Size = new System.Drawing.Size(297, 155);
            this.dataGridViewSrcFolder.TabIndex = 13;
            // 
            // buttonCalcSize
            // 
            this.buttonCalcSize.Location = new System.Drawing.Point(457, 399);
            this.buttonCalcSize.Name = "buttonCalcSize";
            this.buttonCalcSize.Size = new System.Drawing.Size(75, 23);
            this.buttonCalcSize.TabIndex = 14;
            this.buttonCalcSize.Text = "再計算";
            this.buttonCalcSize.UseVisualStyleBackColor = true;
            // 
            // Alias
            // 
            this.Alias.HeaderText = "保存名";
            this.Alias.Name = "Alias";
            this.Alias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Alias.Width = 80;
            // 
            // SrcFolder
            // 
            this.SrcFolder.HeaderText = "フォルダ";
            this.SrcFolder.Name = "SrcFolder";
            this.SrcFolder.ReadOnly = true;
            this.SrcFolder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SrcFolder.Width = 170;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 456);
            this.Controls.Add(this.buttonCalcSize);
            this.Controls.Add(this.dataGridViewSrcFolder);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBoxDstFolder);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRemoveFolder);
            this.Controls.Add(this.buttonAddFolder);
            this.Controls.Add(this.treeViewSrcFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "mbackup";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSrcFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView treeViewSrcFolder;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonRemoveFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TextBox textBoxDstFolder;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridViewSrcFolder;
        private System.Windows.Forms.Button buttonCalcSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alias;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcFolder;
    }
}

