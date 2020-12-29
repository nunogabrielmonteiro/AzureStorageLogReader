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
    public partial class SALogin : Form
    {
        private ArrayList ck;

        public SALogin(ref ArrayList connectionkeys)
        {
            ck = connectionkeys;
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ck.Add(this.txtSAconnectionString.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
