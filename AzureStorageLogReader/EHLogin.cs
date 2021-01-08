using AzureStorageLogReaderLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureStorageLogReader
{
    public partial class EHLogin : Form
    {

        public EHLogin()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
        }

        public string ConnectionString { get; internal set; }
        public string EventHubName { get; internal set; }
        public string ConsumerGroupName { get; internal set; }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectionString = this.txtEHconnectionString.Text.Trim(); ;
            EventHubName = this.txtEventHubName.Text.Trim();
            ConsumerGroupName = this.txtConsumerGroup.Text.Trim() ;
            //Library.GetEvents(ConnectionString, eventhubname);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
