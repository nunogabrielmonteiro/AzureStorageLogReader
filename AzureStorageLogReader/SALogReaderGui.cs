using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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

        public bool ClassicLogs
        { get; set; }

        public SALogReaderGui()
        {
           
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;

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

            ClassicLogs = true;
            VisiblePane = false;
            this.panelLeft.Visible = false;

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
            if (ClassicLogs)
            {
                LoadData(files);
            }
            else
            {
                LoadJSONData(files);
            }
        }


        private void LoadData(string[] files)
        {
            try
            {

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

        private void LoadDataFromStream(Stream stream)
        {
            try
            {

                //reading all the lines(rows) from the file.

                List<string> lines = new List<string>();

                using (StreamReader streamreader = new StreamReader(stream))
                {
                    string line;

                    while ((line = streamreader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }


                string[] rows = lines.ToArray();


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
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void LoadJSONData(string[] files)
        {
            try
            {

                foreach (string file in files)
                {

                    //reading all the lines(rows) from the file.
                    string[] rows = File.ReadAllLines(file);


                    //each line contains a request represented in JSON data
                    for (int i = 0; i < rows.Length; i++)
                    {

                        string filepath = rows[i];

                        JObject jo = JObject.Parse(filepath);

                        string time = jo["time"]?.ToString();
                        string resourceId = jo["resourceId"]?.ToString();
                        string category = jo["category"]?.ToString();
                        string operationName = jo["operationName"]?.ToString();
                        string operationVersion = jo["operationVersion"]?.ToString();
                        string schemaVersion = jo["schemaVersion"]?.ToString();
                        string statusCode = jo["statusCode"]?.ToString();
                        string statusText = jo["statusText"]?.ToString();
                        string durationMs = jo["durationMs"]?.ToString();
                        string callerIpAddress = jo["callerIpAddress"]?.ToString();
                        string correlationId = jo["correlationId"]?.ToString();
                        //string identity = jo["identity"].ToString();
                        string identitytype = jo["identity"]?["type"]?.ToString();
                        string tokenHash = jo["identity"]?["tokenHash"]?.ToString();
                        string appID = jo["identity"]?["requester "]?["appID"]?.ToString();
                        string audience = jo["identity"]?["requester "]?["audience"]?.ToString();
                        string objectId = jo["identity"]?["requester "]?["objectId"]?.ToString();
                        string tenantId = jo["identity"]?["requester "]?["tenantId"]?.ToString();
                        string tokenIssuer = jo["identity"]?["requester "]?["tokenIssuer"]?.ToString();
                        string upn = jo["identity"]?["requester "]?["upn"]?.ToString();
                        string userName = jo["identity"]?["requester "]?["userName"]?.ToString();
                        string location = jo["location"].ToString();
                        //string properties = jo["properties"].ToString();
                        string accountName = jo["properties"]["accountName"]?.ToString()??string.Empty;
                        string requestUrl = jo["properties"]["requestUrl"]?.ToString() ?? string.Empty;
                        string userAgentHeader = jo["properties"]["userAgentHeader"]?.ToString() ?? string.Empty;
                        string referrerHeader = jo["properties"]["referrerHeader"]?.ToString() ?? string.Empty;
                        string clientRequestId = jo["properties"]["clientRequestId"]?.ToString() ?? string.Empty;
                        string etag = jo["properties"]["etag"]?.ToString() ?? string.Empty;
                        string serverLatencyMs = jo["properties"]["serverLatencyMs"]?.ToString() ?? "0";
                        string serviceType = jo["properties"]["serviceType"]?.ToString() ?? string.Empty;
                        string operationCount = jo["properties"]["operationCount"]?.ToString() ?? "0";
                        string requestHeaderSize = jo["properties"]["requestHeaderSize"]?.ToString() ?? "0";
                        string requestBodySize = jo["properties"]["requestBodySize"]?.ToString() ?? "0";
                        string responseHeaderSize = jo["properties"]["responseHeaderSize"]?.ToString() ?? "0";
                        string responseBodySize = jo["properties"]["responseBodySize"]?.ToString() ?? "0";
                        string requestMd5 = jo["properties"]["requestMd5"]?.ToString() ?? string.Empty;
                        string serverMd5 = jo["properties"]["serverMd5"]?.ToString() ?? string.Empty;
                        string lastModifiedTime = jo["properties"]["lastModifiedTime"]?.ToString() ?? string.Empty;
                        string conditionsUsed = jo["properties"]["conditionsUsed"]?.ToString() ?? string.Empty;
                        string contentLengthHeader = jo["properties"]["contentLengthHeader"]?.ToString() ?? string.Empty;
                        string tlsVersion = jo["properties"]["tlsVersion"]?.ToString() ?? string.Empty;
                        string smbTreeConnectID = jo["properties"]["smbTreeConnectID"]?.ToString() ?? string.Empty;
                        string smbPersistentHandleID = jo["properties"]["smbPersistentHandleID"]?.ToString() ?? string.Empty;
                        string smbVolatileHandleID = jo["properties"]["smbVolatileHandleID"]?.ToString() ?? string.Empty;
                        string smbMessageID = jo["properties"]["smbMessageID"]?.ToString() ?? string.Empty;
                        string smbCreditsConsumed = jo["properties"]["smbCreditsConsumed"]?.ToString() ?? string.Empty;
                        string smbCommandDetail = jo["properties"]["smbCommandDetail"]?.ToString() ?? string.Empty;
                        string smbFileId = jo["properties"]["smbFileId"]?.ToString() ?? string.Empty;
                        string smbSessionID = jo["properties"]["smbSessionID"]?.ToString() ?? string.Empty;
                        //string smbCommandMajor = jo["properties"]["smbCommandMajor"]?.ToString()??string.Empty;
                        //string smbCommandMinor = jo["properties"]["smbCommandMinor"]?.ToString()??string.Empty;
                        string uri = jo["uri"]?.ToString();
                        string protocol = jo["protocol"]?.ToString();
                        string resourceType = jo["resourceType"]?.ToString();

                        string[] rowValues = { schemaVersion,time,operationName, "RequestStatus", statusCode, "0",serverLatencyMs, identitytype,accountName, "OwnerAccountName", serviceType,requestUrl, "RequestObjectKey",clientRequestId,operationCount, callerIpAddress,operationName,requestHeaderSize,requestBodySize,responseHeaderSize,responseBodySize,
                        "0", requestMd5, serverMd5, etag, lastModifiedTime,conditionsUsed, userAgentHeader
                        ,referrerHeader,clientRequestId,objectId,tenantId,appID,resourceId,tokenIssuer,upn,userName,audience,"","",""};

                        /*string lineDecoded = HttpUtility.HtmlDecode(rows[i]);

                        lineDecoded = lineDecoded.Replace("\"", string.Empty);

                        lineDecoded = Regex.Replace(lineDecoded, "; ", ",");

                        //string[] rowValues  = Regex.Split(lineDecoded, @";[^ ]");

                        string[] rowValues = lineDecoded.Replace("\"", string.Empty).Split(';');*/

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
            DialogResult result;

            if (this.ClassicLogs)
            {
                result = openFileDialog.ShowDialog();
                files = openFileDialog.FileNames;
            }
            else
            {
                result = openFileDialogJson.ShowDialog();
                files = openFileDialogJson.FileNames;
            }

            if (result == DialogResult.OK) 
            {
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

        private void rbtnClassic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnClassic.Checked)
            {
                if (!ClassicLogs)
                {
                    DialogResult dialogResult = MessageBox.Show(this, "Are you sure you want to change to classic mode? The data in the table will be cleared!", "Change to Classic Mode", MessageBoxButtons.YesNo);

                    if (DialogResult.Yes == dialogResult)
                    {
                        ClassicLogs = true;
                        mainDataTable.Clear();
                    }
                    else
                    {
                        ClassicLogs = false;
                        rbtnClassic.Checked = false;
                        rbtnNew.Checked = true;
                        return;
                    }
                }

                
            }

        }

        private void rbtnNew_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNew.Checked)
            {
                if (ClassicLogs)
                {
                    DialogResult dialogResult = MessageBox.Show(this, "Are you sure you want to change to the New mode? The data in the table will be cleared!", "Change to New Mode", MessageBoxButtons.YesNo);

                    if (DialogResult.Yes == dialogResult)
                    {
                        ClassicLogs = false;
                        mainDataTable.Clear();
                    }
                    else
                    {
                        ClassicLogs = true;
                        rbtnClassic.Checked = false;
                        rbtnClassic.Checked = true;
                        return;
                    }
                }
                
            }

        }

        public bool VisiblePane { get; set; }
        private void connectorPaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            if (VisiblePane)
            {
                //hide
                VisiblePane = false ;
                panelLeft.Visible = false;
                tsmi.Checked = false;

            }
            else
            {
                //show
                VisiblePane = true;
                panelLeft.Visible = true ;
                tsmi.Checked = true;


            }

        }

        private void spinningCircles_Click(object sender, EventArgs e)
        {

        }

        private ArrayList saConnectionString = new ArrayList();
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (saConnectionString.Count == 0)
            {
                if (e.Node.Name == "StorageAccounts")
                {
                    try
                    {

                        SALogin cpf = new SALogin(ref saConnectionString);
                        cpf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        cpf.StartPosition = FormStartPosition.CenterParent;
                        if (cpf.ShowDialog(this) == DialogResult.OK)
                        {

                            ContextMenuStrip connectionMenu = new ContextMenuStrip();
                            //Create some menu items.
                            ToolStripMenuItem removeLabel = new ToolStripMenuItem();
                            removeLabel.Text = "Remove";
                            removeLabel.Click += RemoveLabel_Click;
                            connectionMenu.Items.AddRange(new ToolStripMenuItem[] { removeLabel });

                            string connectionString = saConnectionString[0].ToString();

                            //Add SA to Node

                            TreeNode tn = treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes.Add(connectionString);

                            tn.ContextMenuStrip = connectionMenu;

                            //Iterate over containers.


                            // Create a client that can authenticate with a connection string
                            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                            //Azure.Pageable<BlobContainerItem> containerPages = service.GetBlobContainers(Azure.Storage.Blobs.Models.BlobContainerTraits.None,BlobContainerStates.None,"$logs");

                            //Azure.Pageable<BlobContainerItem> containerPage in containerPages)

                            /*foreach (BlobContainerItem containerItem in containerPages)
                            {

                                tn.Nodes.Add(containerItem.Name);
                                //Console.WriteLine("Container name: {0}", containerItem.Name);
                            }*/

                            // Get the container client object

                            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("$logs");

                            tn = tn.Nodes.Add(containerClient.Name);

                            // List all blobs in the container
                            /* foreach (BlobItem blobItem in containerClient.GetBlobs())
                             {
                                 //Console.WriteLine("\t" + blobItem.Name);
                                 tn.Nodes.Add(blobItem.Name);
                             }*/

                            ContextMenuStrip logsMenu = new ContextMenuStrip();
                            //Create some menu items.
                            ToolStripMenuItem loadLabel = new ToolStripMenuItem();
                            loadLabel.Text = "Load";
                            loadLabel.Click += LoadLabel_Click;
                            //ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                            //deleteLabel.Text = "Delete";
                            logsMenu.Items.AddRange(new ToolStripMenuItem[] { loadLabel});
                            tn.ContextMenuStrip = logsMenu;
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }

        private void LoadLabel_Click(object sender, EventArgs e)
        {
           
            //Get Filter parameters
            FilterSAForm cpf = new FilterSAForm();
            
            cpf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            
            cpf.StartPosition = FormStartPosition.CenterParent;
           
            if (cpf.ShowDialog(this) == DialogResult.OK)
            {

                string filter = cpf.Prefix;
                int max = cpf.Max;

                string connectionString = saConnectionString[0].ToString();

                // Create a client that can authenticate with a connection string
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                // Get the container client object

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("$logs");

                TreeNode tn = treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes[0].Nodes[0];


                ContextMenuStrip logsMenu = new ContextMenuStrip();
                //Create some menu items.
                ToolStripMenuItem loadIntoTable = new ToolStripMenuItem();
                loadIntoTable.Text = "Load into table";
                loadIntoTable.Click += LoadIntoTable_Click; ;
                //ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                //deleteLabel.Text = "Delete";
                logsMenu.Items.AddRange(new ToolStripMenuItem[] { loadIntoTable });

                int i = 0;
                // List all blobs in the container
                foreach (BlobItem blobItem in containerClient.GetBlobs(BlobTraits.None, BlobStates.None, filter))
                {
                    //Console.WriteLine("\t" + blobItem.Name);
                    tn.Nodes.Add(blobItem.Name).ContextMenuStrip = logsMenu;
                    i++;
                    if (i >= max) break;
                }
            }
        }

        private void LoadIntoTable_Click(object sender, EventArgs e)
        {
            //Get the clicked node!!!!
            
            //use SourceControl property.. ContextMenuStrip must be associated with TreeView
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = ( TreeView ) cms.SourceControl;
            TreeNode node = treeView.GetNodeAt( treeView.PointToClient( cms.Location ) );

            string connectionString = saConnectionString[0].ToString();

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // Get the container client object

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("$logs");

            BlobClient bc = containerClient.GetBlobClient(node.Text);

            var response = bc.DownloadTo(@"c:\temp\tempfile.log");

            LoadData(new string[] { @"c:\temp\tempfile.log" });

            if(dataGridView.DataSource == null)
                dataGridView.DataSource = mainDataTable;
        }

        private void RemoveLabel_Click(object sender, EventArgs e)
        {
            saConnectionString.Clear();
            treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes.Clear();
            //MessageBox.Show(sender.ToString());
        }

        private void treeView_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
