namespace AzureStorageLogReader
{
    partial class SALogReaderGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Storage Accounts");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Connections", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SALogReaderGui));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectorPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.rbtnClassic = new System.Windows.Forms.RadioButton();
            this.rbtnNew = new System.Windows.Forms.RadioButton();
            this.bntExporToExcel = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnChooseColumns = new System.Windows.Forms.Button();
            this.btbClearTable = new System.Windows.Forms.Button();
            this.lblNumberRows = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddLogs = new System.Windows.Forms.Button();
            this.openFileDialogJson = new System.Windows.Forms.OpenFileDialog();
            this.spinningCircles = new AzureStorageLogReader.SpinningCircles();
            this.spinningCirclesConnectionPane = new AzureStorageLogReader.SpinningCircles();
            this.menuStrip1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "log";
            this.openFileDialog.Filter = "log files | *.log";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectorPaneToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // connectorPaneToolStripMenuItem
            // 
            this.connectorPaneToolStripMenuItem.Name = "connectorPaneToolStripMenuItem";
            this.connectorPaneToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.connectorPaneToolStripMenuItem.Text = "Connector Pane";
            this.connectorPaneToolStripMenuItem.Click += new System.EventHandler(this.connectorPaneToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeft.Controls.Add(this.spinningCirclesConnectionPane);
            this.panelLeft.Controls.Add(this.treeView);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 28);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(420, 608);
            this.panelLeft.TabIndex = 15;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "StorageAccounts";
            treeNode1.Text = "Storage Accounts";
            treeNode2.Name = "Connections";
            treeNode2.Text = "Connections";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView.Size = new System.Drawing.Size(418, 606);
            this.treeView.TabIndex = 0;
            this.treeView.DoubleClick += new System.EventHandler(this.treeView_DoubleClick);
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.rbtnClassic);
            this.panelMain.Controls.Add(this.rbtnNew);
            this.panelMain.Controls.Add(this.bntExporToExcel);
            this.panelMain.Controls.Add(this.btnClearFilter);
            this.panelMain.Controls.Add(this.cmbColumns);
            this.panelMain.Controls.Add(this.btnFilter);
            this.panelMain.Controls.Add(this.txtFilter);
            this.panelMain.Controls.Add(this.lblFilter);
            this.panelMain.Controls.Add(this.btnChooseColumns);
            this.panelMain.Controls.Add(this.spinningCircles);
            this.panelMain.Controls.Add(this.btbClearTable);
            this.panelMain.Controls.Add(this.lblNumberRows);
            this.panelMain.Controls.Add(this.dataGridView);
            this.panelMain.Controls.Add(this.btnAddLogs);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(420, 28);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(642, 608);
            this.panelMain.TabIndex = 16;
            // 
            // rbtnClassic
            // 
            this.rbtnClassic.AutoSize = true;
            this.rbtnClassic.Checked = true;
            this.rbtnClassic.Location = new System.Drawing.Point(15, 14);
            this.rbtnClassic.Name = "rbtnClassic";
            this.rbtnClassic.Size = new System.Drawing.Size(73, 21);
            this.rbtnClassic.TabIndex = 27;
            this.rbtnClassic.TabStop = true;
            this.rbtnClassic.Text = "Classic";
            this.rbtnClassic.UseVisualStyleBackColor = true;
            this.rbtnClassic.Click += new System.EventHandler(this.rbtnClassic_CheckedChanged);
            // 
            // rbtnNew
            // 
            this.rbtnNew.AutoSize = true;
            this.rbtnNew.Location = new System.Drawing.Point(94, 14);
            this.rbtnNew.Name = "rbtnNew";
            this.rbtnNew.Size = new System.Drawing.Size(78, 21);
            this.rbtnNew.TabIndex = 26;
            this.rbtnNew.Text = "Preview";
            this.rbtnNew.UseVisualStyleBackColor = true;
            this.rbtnNew.Click += new System.EventHandler(this.rbtnNew_CheckedChanged);
            // 
            // bntExporToExcel
            // 
            this.bntExporToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntExporToExcel.Location = new System.Drawing.Point(17, 572);
            this.bntExporToExcel.Name = "bntExporToExcel";
            this.bntExporToExcel.Size = new System.Drawing.Size(150, 26);
            this.bntExporToExcel.TabIndex = 25;
            this.bntExporToExcel.Text = "Export To Excel";
            this.bntExporToExcel.UseVisualStyleBackColor = true;
            this.bntExporToExcel.Click += new System.EventHandler(this.bntExporToExcel_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.Location = new System.Drawing.Point(577, 41);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(52, 28);
            this.btnClearFilter.TabIndex = 24;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // cmbColumns
            // 
            this.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(264, 42);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(187, 24);
            this.cmbColumns.TabIndex = 23;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(513, 41);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(62, 28);
            this.btnFilter.TabIndex = 22;
            this.btnFilter.Text = "Apply Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(456, 42);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(54, 25);
            this.txtFilter.TabIndex = 21;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(219, 48);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(43, 17);
            this.lblFilter.TabIndex = 20;
            this.lblFilter.Text = "Filter:";
            // 
            // btnChooseColumns
            // 
            this.btnChooseColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseColumns.Location = new System.Drawing.Point(170, 572);
            this.btnChooseColumns.Name = "btnChooseColumns";
            this.btnChooseColumns.Size = new System.Drawing.Size(150, 26);
            this.btnChooseColumns.TabIndex = 19;
            this.btnChooseColumns.Text = "Choose Columns";
            this.btnChooseColumns.UseVisualStyleBackColor = true;
            this.btnChooseColumns.Click += new System.EventHandler(this.btnChooseColumns_Click);
            // 
            // btbClearTable
            // 
            this.btbClearTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btbClearTable.Location = new System.Drawing.Point(324, 572);
            this.btbClearTable.Name = "btbClearTable";
            this.btbClearTable.Size = new System.Drawing.Size(150, 26);
            this.btbClearTable.TabIndex = 17;
            this.btbClearTable.Text = "Clear Table";
            this.btbClearTable.UseVisualStyleBackColor = true;
            this.btbClearTable.Click += new System.EventHandler(this.btbClearTable_Click);
            // 
            // lblNumberRows
            // 
            this.lblNumberRows.AutoSize = true;
            this.lblNumberRows.Location = new System.Drawing.Point(15, 49);
            this.lblNumberRows.Name = "lblNumberRows";
            this.lblNumberRows.Size = new System.Drawing.Size(170, 17);
            this.lblNumberRows.TabIndex = 16;
            this.lblNumberRows.Text = "Number of loaded rows: 0";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 77);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(618, 487);
            this.dataGridView.TabIndex = 15;
            // 
            // btnAddLogs
            // 
            this.btnAddLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLogs.Location = new System.Drawing.Point(478, 572);
            this.btnAddLogs.Name = "btnAddLogs";
            this.btnAddLogs.Size = new System.Drawing.Size(152, 26);
            this.btnAddLogs.TabIndex = 14;
            this.btnAddLogs.Text = "Add Log files";
            this.btnAddLogs.UseVisualStyleBackColor = true;
            this.btnAddLogs.Click += new System.EventHandler(this.btnAddLogs_Click);
            // 
            // openFileDialogJson
            // 
            this.openFileDialogJson.DefaultExt = "json";
            this.openFileDialogJson.Filter = "JSON files| *.json";
            this.openFileDialogJson.Multiselect = true;
            this.openFileDialogJson.RestoreDirectory = true;
            this.openFileDialogJson.SupportMultiDottedExtensions = true;
            // 
            // spinningCircles
            // 
            this.spinningCircles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinningCircles.BackColor = System.Drawing.Color.Transparent;
            this.spinningCircles.Location = new System.Drawing.Point(281, 254);
            this.spinningCircles.Name = "spinningCircles";
            this.spinningCircles.Size = new System.Drawing.Size(90, 90);
            this.spinningCircles.TabIndex = 18;
            this.spinningCircles.Text = "spinningCircles1";
            // 
            // spinningCirclesConnectionPane
            // 
            this.spinningCirclesConnectionPane.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinningCirclesConnectionPane.BackColor = System.Drawing.Color.Transparent;
            this.spinningCirclesConnectionPane.Location = new System.Drawing.Point(154, 254);
            this.spinningCirclesConnectionPane.Name = "spinningCirclesConnectionPane";
            this.spinningCirclesConnectionPane.Size = new System.Drawing.Size(90, 90);
            this.spinningCirclesConnectionPane.TabIndex = 19;
            this.spinningCirclesConnectionPane.Text = "spinningCircles1";
            // 
            // SALogReaderGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 636);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SALogReaderGui";
            this.Text = "Azure Storage Log Reader";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectorPaneToolStripMenuItem;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.RadioButton rbtnClassic;
        private System.Windows.Forms.RadioButton rbtnNew;
        private System.Windows.Forms.Button bntExporToExcel;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Button btnChooseColumns;
        private SpinningCircles spinningCircles;
        private System.Windows.Forms.Button btbClearTable;
        private System.Windows.Forms.Label lblNumberRows;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btnAddLogs;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogJson;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private SpinningCircles spinningCirclesConnectionPane;
    }
}

