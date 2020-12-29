namespace AzureStorageLogReader
{
    partial class SALogin
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
            this.components = new System.ComponentModel.Container();
            this.lbllogin = new System.Windows.Forms.Label();
            this.txtSAconnectionString = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbllogin
            // 
            this.lbllogin.AutoSize = true;
            this.lbllogin.Location = new System.Drawing.Point(11, 13);
            this.lbllogin.Name = "lbllogin";
            this.lbllogin.Size = new System.Drawing.Size(293, 17);
            this.lbllogin.TabIndex = 0;
            this.lbllogin.Text = " Storage Account Connection String with Key:";
            // 
            // txtSAconnectionString
            // 
            this.txtSAconnectionString.Location = new System.Drawing.Point(16, 43);
            this.txtSAconnectionString.Name = "txtSAconnectionString";
            this.txtSAconnectionString.Size = new System.Drawing.Size(772, 22);
            this.txtSAconnectionString.TabIndex = 1;
            this.txtSAconnectionString.Text = "DefaultEndpointsProtocol=https;AccountName=mystorageaccount;AccountKey=mykey;Endp" +
    "ointSuffix=core.windows.net";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(671, 73);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 39);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // SALogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 120);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtSAconnectionString);
            this.Controls.Add(this.lbllogin);
            this.Name = "SALogin";
            this.Text = "Storage Account Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbllogin;
        private System.Windows.Forms.TextBox txtSAconnectionString;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnConnect;
    }
}