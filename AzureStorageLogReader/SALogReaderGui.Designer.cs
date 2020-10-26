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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SALogReaderGui));
            this.btnAddLogs = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblNumberRows = new System.Windows.Forms.Label();
            this.btbClearTable = new System.Windows.Forms.Button();
            this.btnChooseColumns = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.bntExporToExcel = new System.Windows.Forms.Button();
            this.spinningCircles = new AzureStorageLogReader.SpinningCircles();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddLogs
            // 
            this.btnAddLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLogs.Location = new System.Drawing.Point(899, 581);
            this.btnAddLogs.Name = "btnAddLogs";
            this.btnAddLogs.Size = new System.Drawing.Size(152, 47);
            this.btnAddLogs.TabIndex = 0;
            this.btnAddLogs.Text = "Add Log files";
            this.btnAddLogs.UseVisualStyleBackColor = true;
            this.btnAddLogs.Click += new System.EventHandler(this.btnAddLogs_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "log";
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1041, 523);
            this.dataGridView.TabIndex = 1;
            // 
            // lblNumberRows
            // 
            this.lblNumberRows.AutoSize = true;
            this.lblNumberRows.Location = new System.Drawing.Point(12, 19);
            this.lblNumberRows.Name = "lblNumberRows";
            this.lblNumberRows.Size = new System.Drawing.Size(158, 17);
            this.lblNumberRows.TabIndex = 2;
            this.lblNumberRows.Text = "Number of loaded rows:";
            this.lblNumberRows.Click += new System.EventHandler(this.lblNumberRows_Click);
            // 
            // btbClearTable
            // 
            this.btbClearTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btbClearTable.Location = new System.Drawing.Point(745, 581);
            this.btbClearTable.Name = "btbClearTable";
            this.btbClearTable.Size = new System.Drawing.Size(150, 47);
            this.btbClearTable.TabIndex = 3;
            this.btbClearTable.Text = "Clear Table";
            this.btbClearTable.UseVisualStyleBackColor = true;
            this.btbClearTable.Click += new System.EventHandler(this.btbClearTable_Click);
            // 
            // btnChooseColumns
            // 
            this.btnChooseColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseColumns.Location = new System.Drawing.Point(591, 581);
            this.btnChooseColumns.Name = "btnChooseColumns";
            this.btnChooseColumns.Size = new System.Drawing.Size(150, 47);
            this.btnChooseColumns.TabIndex = 5;
            this.btnChooseColumns.Text = "Choose Columns";
            this.btnChooseColumns.UseVisualStyleBackColor = true;
            this.btnChooseColumns.Click += new System.EventHandler(this.btnChooseColumns_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(249, 17);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(39, 17);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "Find:";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(501, 14);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(329, 22);
            this.txtFilter.TabIndex = 7;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(836, 11);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(107, 28);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Apply Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbColumns
            // 
            this.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(292, 12);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(203, 24);
            this.cmbColumns.TabIndex = 9;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.Location = new System.Drawing.Point(945, 11);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(108, 28);
            this.btnClearFilter.TabIndex = 10;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // bntExporToExcel
            // 
            this.bntExporToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bntExporToExcel.Location = new System.Drawing.Point(438, 581);
            this.bntExporToExcel.Name = "bntExporToExcel";
            this.bntExporToExcel.Size = new System.Drawing.Size(150, 47);
            this.bntExporToExcel.TabIndex = 11;
            this.bntExporToExcel.Text = "Export To Excel";
            this.bntExporToExcel.UseVisualStyleBackColor = true;
            this.bntExporToExcel.Click += new System.EventHandler(this.bntExporToExcel_Click);
            // 
            // spinningCircles
            // 
            this.spinningCircles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinningCircles.BackColor = System.Drawing.Color.Transparent;
            this.spinningCircles.Location = new System.Drawing.Point(491, 250);
            this.spinningCircles.Name = "spinningCircles";
            this.spinningCircles.Size = new System.Drawing.Size(100, 100);
            this.spinningCircles.TabIndex = 4;
            this.spinningCircles.Text = "spinningCircles1";
            // 
            // SALogReaderGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 636);
            this.Controls.Add(this.bntExporToExcel);
            this.Controls.Add(this.btnClearFilter);
            this.Controls.Add(this.cmbColumns);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnChooseColumns);
            this.Controls.Add(this.spinningCircles);
            this.Controls.Add(this.btbClearTable);
            this.Controls.Add(this.lblNumberRows);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnAddLogs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SALogReaderGui";
            this.Text = "Azure Storage Log Reader";
            this.Load += new System.EventHandler(this.SALogReaderGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddLogs;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblNumberRows;
        private System.Windows.Forms.Button btbClearTable;
        private SpinningCircles spinningCircles;
        private System.Windows.Forms.Button btnChooseColumns;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cmbColumns;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button bntExporToExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

