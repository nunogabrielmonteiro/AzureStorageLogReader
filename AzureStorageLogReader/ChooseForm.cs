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
    public partial class ChooseForm : Form
    {
        public int mySelectedIndex = 0;

        public ChooseForm()
        {
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mySelectedIndex = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mySelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mySelectedIndex = 2;
        }
    }
}
