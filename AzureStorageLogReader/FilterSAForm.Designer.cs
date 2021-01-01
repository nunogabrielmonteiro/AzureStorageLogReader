namespace AzureStorageLogReader
{
    partial class FilterSAForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMaxBlobs = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add prefix filter for $log blobs: blob/yyyy/mm/dd/hh/";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(16, 39);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(493, 22);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.Text = "blob/2020/07/04/03";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum blobs returned:";
            // 
            // cmbMaxBlobs
            // 
            this.cmbMaxBlobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaxBlobs.FormattingEnabled = true;
            this.cmbMaxBlobs.Items.AddRange(new object[] {
            "10",
            "50",
            "100"});
            this.cmbMaxBlobs.Location = new System.Drawing.Point(19, 96);
            this.cmbMaxBlobs.Name = "cmbMaxBlobs";
            this.cmbMaxBlobs.Size = new System.Drawing.Size(121, 24);
            this.cmbMaxBlobs.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(415, 124);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 41);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Apply";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // FilterSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 177);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmbMaxBlobs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label1);
            this.Name = "FilterSAForm";
            this.Text = "Choose Filter for $logs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMaxBlobs;
        private System.Windows.Forms.Button btnLoad;
    }
}