using System;
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
    public partial class FilterEHForm : Form
    {
        public  int Max { get; set; }

        public FilterEHForm()
        {
            InitializeComponent();
            this.cmbMaxEvents.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Max = int.Parse(cmbMaxEvents.SelectedItem.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
