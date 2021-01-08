namespace AzureStorageLogReader
{
    partial class FilterEHForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMaxEvents = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maximum number of event to load:";
            // 
            // cmbMaxEvents
            // 
            this.cmbMaxEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaxEvents.FormattingEnabled = true;
            this.cmbMaxEvents.Items.AddRange(new object[] {
            "100",
            "1000",
            "10000",
            "100000"});
            this.cmbMaxEvents.Location = new System.Drawing.Point(19, 37);
            this.cmbMaxEvents.Name = "cmbMaxEvents";
            this.cmbMaxEvents.Size = new System.Drawing.Size(221, 24);
            this.cmbMaxEvents.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(415, 65);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 41);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Apply";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // FilterEHForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 114);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cmbMaxEvents);
            this.Controls.Add(this.label2);
            this.Name = "FilterEHForm";
            this.Text = "Choose Filter for Event Hub Load";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMaxEvents;
        private System.Windows.Forms.Button btnLoad;
    }
}