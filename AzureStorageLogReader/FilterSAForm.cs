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
    public partial class FilterSAForm : Form
    {
        public string Prefix { get; set; }
        public  int Max { get; set; }

        public FilterSAForm()
        {
            InitializeComponent();
            this.cmbMaxBlobs.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Prefix = this.txtFilter.Text;
            Max = int.Parse(cmbMaxBlobs.SelectedItem.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
