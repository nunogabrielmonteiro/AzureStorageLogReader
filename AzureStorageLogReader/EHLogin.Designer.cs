namespace AzureStorageLogReader
{
    partial class EHLogin
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
            this.txtEHconnectionString = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventHubName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConsumerGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbllogin
            // 
            this.lbllogin.AutoSize = true;
            this.lbllogin.Location = new System.Drawing.Point(22, 16);
            this.lbllogin.Name = "lbllogin";
            this.lbllogin.Size = new System.Drawing.Size(250, 17);
            this.lbllogin.TabIndex = 0;
            this.lbllogin.Text = "Event Hub Connection String with Key:";
            // 
            // txtEHconnectionString
            // 
            this.txtEHconnectionString.Location = new System.Drawing.Point(22, 41);
            this.txtEHconnectionString.Name = "txtEHconnectionString";
            this.txtEHconnectionString.Size = new System.Drawing.Size(772, 22);
            this.txtEHconnectionString.TabIndex = 1;
            this.txtEHconnectionString.Text = "Endpoint=sb://eventhub.servicebus.windows.net/;SharedAccessKeyName=mykeyname;Shar" +
    "edAccessKey=myKeuValue";
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
            this.btnConnect.Location = new System.Drawing.Point(671, 195);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(117, 39);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Event Hub Name:";
            // 
            // txtEventHubName
            // 
            this.txtEventHubName.Location = new System.Drawing.Point(22, 96);
            this.txtEventHubName.Name = "txtEventHubName";
            this.txtEventHubName.Size = new System.Drawing.Size(766, 22);
            this.txtEventHubName.TabIndex = 5;
            this.txtEventHubName.Text = "MyEventHub";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Consumer Group Name:";
            // 
            // txtConsumerGroup
            // 
            this.txtConsumerGroup.Location = new System.Drawing.Point(22, 151);
            this.txtConsumerGroup.Name = "txtConsumerGroup";
            this.txtConsumerGroup.Size = new System.Drawing.Size(766, 22);
            this.txtConsumerGroup.TabIndex = 7;
            this.txtConsumerGroup.Text = "$Default";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(22, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(395, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Note: The Event Hub must be reacheable from your machine.";
            // 
            // EHLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 242);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConsumerGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEventHubName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtEHconnectionString);
            this.Controls.Add(this.lbllogin);
            this.Name = "EHLogin";
            this.Text = "Event Hub Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbllogin;
        private System.Windows.Forms.TextBox txtEHconnectionString;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventHubName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConsumerGroup;
        private System.Windows.Forms.Label label3;
    }
}