using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Windows.Forms;

namespace AzureStorageLogReader
{
    public partial class SALogReaderGui : Form
    {     
        DataTable mainDataTable = new DataTable();
      
        BackgroundWorker backgroundworker = new BackgroundWorker();
       
        string[] files;

        Dictionary<string, bool> tableHeaderNames = new Dictionary<string, bool>();/* {  "Version","RequestStartTime","OperationType","RequestStatus","HttpStatusCode",
                "E2E_Latency(ms)",
                "ServerLatency(ms)","AuthenticationType","RequesterAccountName", "OwnerAccountName","ServiceType",
                "RequestURL","RequestObjectKey","RequestID","OperationCount","ClientIP","APIVersion","RequestHeaderSize(bytes)",
                "RequestPacketSize(bytes)","ResponseHeaderSize(bytes)","ResponsePacketSize(bytes)","RequestContentLenght(bytes)"
                ,"RequestMd5","ServerMd5","etag","LastModifiedTime","ConditionsUsed","UserAgent","ReferrerHeader","ClientRequestID",
                "UserObjectID","TenantID",
                "ApplicationID","ResourceID",
                "Issuer","UserPrincipalName","Reserved","AuthenticationDetails","ColLast","Extra1","Extra2"};
        */


        public SALogReaderGui()
        {
            InitializeComponent();

            tableHeaderNames.Add("Version", true);
            tableHeaderNames.Add("RequestStartTime", true);
            tableHeaderNames.Add("OperationType", true);
            tableHeaderNames.Add("RequestStatus", true);
            tableHeaderNames.Add("HttpStatusCode", true);
            tableHeaderNames.Add("E2E_Latency(ms)", true);
            tableHeaderNames.Add("ServerLatency(ms)", true);
            tableHeaderNames.Add("AuthenticationType", true);
            tableHeaderNames.Add("RequesterAccountName", true);
            tableHeaderNames.Add("OwnerAccountName", false);
            tableHeaderNames.Add("ServiceType", true);
            tableHeaderNames.Add("RequestURL", true);
            tableHeaderNames.Add("RequestObjectKey", true);
            tableHeaderNames.Add("RequestID", true);
            tableHeaderNames.Add("OperationCount", true);
            tableHeaderNames.Add("ClientIP", true);
            tableHeaderNames.Add("APIVersion", true);
            tableHeaderNames.Add("RequestHeaderSize(bytes)", true);
            tableHeaderNames.Add("RequestPacketSize(bytes)", true);
            tableHeaderNames.Add("ResponseHeaderSize(bytes)", true);
            tableHeaderNames.Add("ResponsePacketSize(bytes)", true);
            tableHeaderNames.Add("RequestContentLenght(bytes)", true);
            tableHeaderNames.Add("RequestMd5", false);
            tableHeaderNames.Add("ServerMd5", false);
            tableHeaderNames.Add("etag", false);
            tableHeaderNames.Add("LastModifiedTime", true);
            tableHeaderNames.Add("ConditionsUsed", true);
            tableHeaderNames.Add("UserAgent", true);
            tableHeaderNames.Add("ReferrerHeader", false);
            tableHeaderNames.Add("ClientRequestID", true);
            tableHeaderNames.Add("UserObjectID", true);
            tableHeaderNames.Add("TenantID", false);
            tableHeaderNames.Add("ApplicationID", true);
            tableHeaderNames.Add("ResourceID", true);
            tableHeaderNames.Add("Issuer", false);
            tableHeaderNames.Add("UserPrincipalName", true);
            tableHeaderNames.Add("Reserved", false);
            tableHeaderNames.Add("AuthenticationDetails", true);
            tableHeaderNames.Add("ColLast", false);
            tableHeaderNames.Add("Extra1", false);
            tableHeaderNames.Add("Extra2", false);

            foreach(var col in tableHeaderNames)
            {
                cmbColumns.Items.Add(col.Key);
            }

            spinningCircles.Visible = false;

            InitializeDataTable();

            InitializeDataGridView();

            backgroundworker.DoWork += Backgroundworker_DoWork;

            backgroundworker.RunWorkerCompleted += Backgroundworker_RunWorkerCompleted;

        }

        private void Backgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = mainDataTable;
            spinningCircles.Visible = false;
            this.btnAddLogs.Enabled = true;
            this.btbClearTable.Enabled = true;

            SetVisibleColumns();
            SetRowCount();
        }

        void SetRowCount()
        {
            lblNumberRows.Text = "Number of loaded rows: " + dataGridView.Rows.Count;
        }

        private void SetVisibleColumns()
        {
            try { 
                if (dataGridView.Columns.Count > 0)
                {
                    foreach (var col in tableHeaderNames)
                    {
                        string colname = col.Key;

                        dataGridView.Columns[colname].Visible = col.Value;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Backgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData(files);
        }


        private void InitializeDataTable()
        {

            mainDataTable = new DataTable();

            DataRow dr = mainDataTable.NewRow();

            
            foreach (var columnName in tableHeaderNames)
            {
                if (columnName.Key.Contains("Latency") || columnName.Key.Contains("(bytes)"))
                {
                    DataColumn dc = mainDataTable.Columns.Add(columnName.Key, typeof(int));
                }
                else
                {
                    DataColumn dc = mainDataTable.Columns.Add(columnName.Key);
                }
            }

            mainDataTable.TableCleared += MainDataTable_TableCleared;
        }

        private void InitializeDataGridView()
        {
           

            dataGridView.ReadOnly = true;

            dataGridView.AllowUserToAddRows = false;

            dataGridView.RowHeadersVisible = false;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {

                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridView.ColumnAdded += DataGridView_ColumnAdded;

            dataGridView.DataBindingComplete += DataGridView_DataBindingComplete;



        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           /* dataGridView.Columns["ColLast"].Visible = false;
            dataGridView.Columns["Extra1"].Visible = false;
            dataGridView.Columns["Extra2"].Visible = false;*/
        }

        private void DataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            /*dataGridView.Columns["ColLast"].Visible = false;
            dataGridView.Columns["Extra1"].Visible = false;
            dataGridView.Columns["Extra2"].Visible = false;*/
        }

        private void MainDataTable_TableCleared(object sender, DataTableClearEventArgs e)
        {
            lblNumberRows.Text = "Number of loaded rows: " + mainDataTable.Rows.Count;
        }

        private void btnAddLogs_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); 

            if (result == DialogResult.OK) 
            {
               files = openFileDialog.FileNames;

                try
                {
                    this.dataGridView.DataSource = null;
                    spinningCircles.Visible = true;
                    this.btnAddLogs.Enabled = false;
                    this.btbClearTable.Enabled = false;
                    

                    backgroundworker.RunWorkerAsync();

                }
                catch (IOException)
                {

                }
            }   
        }

        private void LoadData(string[] files)
        {
            try { 

                foreach (string file in files)
                {

                    //reading all the lines(rows) from the file.
                    string[] rows = File.ReadAllLines(file);


                    //Creating row for each line.(except the first line, which contain column names)
                    for (int i = 1; i < rows.Length; i++)
                    {
                        string lineDecoded = HttpUtility.HtmlDecode(rows[i]);

                        lineDecoded = lineDecoded.Replace("\"", string.Empty);

                        lineDecoded = Regex.Replace(lineDecoded, "; ", ",");

                        //string[] rowValues  = Regex.Split(lineDecoded, @";[^ ]");

                        string[] rowValues = lineDecoded.Replace("\"", string.Empty).Split(';');

                        DataRow dr = mainDataTable.NewRow();

                        dr.ItemArray = rowValues;

                        mainDataTable.Rows.Add(dr);
                    }

                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btbClearTable_Click(object sender, EventArgs e)
        {
            mainDataTable.Clear();
        }

        private void btnChooseColumns_Click(object sender, EventArgs e)
        {
            try { 

                ColumnsPickerForm cpf = new ColumnsPickerForm(this.tableHeaderNames);
                cpf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                cpf.StartPosition = FormStartPosition.CenterParent;
                cpf.ShowDialog(this);

                SetVisibleColumns();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void lblNumberRows_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try { 
                if (mainDataTable.Columns.Count > 0)
                {

                    if (cmbColumns.SelectedItem != null && !string.IsNullOrEmpty(cmbColumns.SelectedItem.ToString()))
                    {
                        if (String.IsNullOrEmpty(txtFilter.Text))
                        {
                            //Clear Filter
                            this.dataGridView.DataSource = this.mainDataTable;
                        }
                        else
                        {
                            string colname = cmbColumns.SelectedItem.ToString();
                            //Apply Filter
                            DataView dv;
                            string filter = "["+colname + "] like '%" + this.txtFilter.Text + "%'";
                            dv = new DataView(mainDataTable, filter, "RequestStartTime Desc", DataViewRowState.CurrentRows);
                            dataGridView.DataSource = dv;
                        }
                    }

                    SetRowCount();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void SALogReaderGui_Load(object sender, EventArgs e)
        {

        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtFilter.Text = string.Empty;
                this.cmbColumns.SelectedIndex = -1;
                this.dataGridView.DataSource = mainDataTable;
                SetRowCount();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void bntExporToExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel File(.xlsx)| *.xlsx";

            saveFileDialog.Title = "Save Excel file";

            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                files = openFileDialog.FileNames;
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(this.mainDataTable, "Storage Logs");
                wb.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Data Exported!");

            }
        }
    }
}
