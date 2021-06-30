using Azure.Messaging.EventHubs.Consumer;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ClosedXML.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

/// <summary>
/// Application Main Form.
/// </summary>
namespace AzureStorageLogReader
{
    public partial class SALogReaderGui : Form
    {
        #region private fields
        private string eventHubConnectionString = string.Empty;
        string eventhubname = string.Empty;
        string consumergroupname = string.Empty;
        DataTable mainDataTable = new DataTable();
        //Represent the worker thread were all work will be done
        BackgroundWorker backgroundworker = new BackgroundWorker();
        //Represent the worker thread for the connection pane
        BackgroundWorker backgroundworkerConnectionPane = new BackgroundWorker();
        BackgroundWorker backgroundworkerConnectionPaneLoadAll = new BackgroundWorker();
        BackgroundWorker backgroundworkerConnectionPaneEH = new BackgroundWorker();
        //Store the files paths to load in the grid
        string[] filePaths;
        //Map with the grid headers and the status, if they are visible or not
        Dictionary<string, bool> tableHeaderNames = new Dictionary<string, bool>();
        private ArrayList saConnectionString = new ArrayList();
        #endregion

        #region Properties
        /// <summary>
        /// Property indicates the current mode of the application (Classic,New)
        /// </summary>
        public bool ClassicLogs
        { get; set; }
        //Connection panel state
        public bool VisiblePane { get; set; }
        #endregion

        public SALogReaderGui()
        {

            InitializeComponent();

            InitializeMapWithGridColumnsNames();

            InitializeDataTable();

            InitializeDataGridView();

            //Initialize filter combobox with the grid columns names
            foreach (var col in tableHeaderNames)
            {
                cmbColumns.Items.Add(col.Key);
            }

            cmbColumns.Items.Add("Manual");

            backgroundworker.DoWork += Backgroundworker_DoWork;

            backgroundworker.RunWorkerCompleted += Backgroundworker_RunWorkerCompleted;

            backgroundworkerConnectionPane.DoWork += BackgroundworkerConnectionPane_DoWork;

            backgroundworkerConnectionPane.RunWorkerCompleted += BackgroundworkerConnectionPane_RunWorkerCompleted;

            backgroundworkerConnectionPaneLoadAll.DoWork += BackgroundworkerConnectionPaneLoadAll_DoWork;

            backgroundworkerConnectionPaneLoadAll.RunWorkerCompleted += BackgroundworkerConnectionPaneLoadAll_RunWorkerCompleted;

            backgroundworkerConnectionPaneEH.DoWork += BackgroundworkerConnectionPaneEH_DoWork;
            backgroundworkerConnectionPaneEH.RunWorkerCompleted += BackgroundworkerConnectionPaneEH_RunWorkerCompleted;

            //Wait animation not visible
            spinningCircles.Visible = false;
            this.spinningCirclesConnectionPane.Visible = false;
            //Maxime window
            this.WindowState = FormWindowState.Maximized;
            //Default log mode
            ClassicLogs = true;
            //Initial Menu state
            VisiblePane = false;
            //Hide Connector Pane
            this.panelLeft.Visible = false;
            //Combobox filter change index event
            this.cmbColumns.SelectedIndexChanged += cmbColumns_SelectedIndexChanged;
        }

        #region Initialization Methods
        private void InitializeMapWithGridColumnsNames()
        {
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

        }
        #endregion

        #region worker threads
        /// <summary>
        /// Start background work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ClassicLogs)
            {
                LoadData(filePaths);
            }
            else
            {
                LoadJSONData(filePaths);
            }
        }
        private void Backgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.DataSource = mainDataTable;
            spinningCircles.Visible = false;
            this.btnAddLogs.Enabled = true;
            this.btbClearTable.Enabled = true;
            this.btnAddFolder.Enabled = true;

            SetVisibleColumns();

            SetRowCount();
        }
        private void BackgroundworkerConnectionPaneLoadAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dataGridView.DataSource == null)
            {
                dataGridView.DataSource = mainDataTable;
            }

            this.SetRowCount();

            this.spinningCircles.Visible = false;
            this.spinningCirclesConnectionPane.Visible = false;
        }
        private void BackgroundworkerConnectionPaneLoadAll_DoWork(object sender, DoWorkEventArgs e)
        {

            TreeNode rootnode = null;

            string containername = GetCurrentFolderForLogs();

            rootnode = treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes[0].Nodes[0];

            if (rootnode.Nodes.Count == 0)
            {
                MessageBox.Show("No loaded nodes.Use the Load option first.");
                return;
            }

            string connectionString = saConnectionString[0].ToString();

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // Get the container client object

            string containerName = GetCurrentFolderForLogs();

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            foreach (TreeNode node in rootnode.Nodes)
            {

                BlobClient bc = containerClient.GetBlobClient(node.Text);

                if (ClassicLogs)
                {
                    var response = bc.DownloadTo(@"c:\temp\tempfile.log");

                    LoadData(new string[] { @"c:\temp\tempfile.log" });
                }
                else
                {
                    var response = bc.DownloadTo(@"c:\temp\tempfile.json");

                    LoadJSONData(new string[] { @"c:\temp\tempfile.json" });
                }


            }
            
        }

        private void BackgroundworkerConnectionPaneEH_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (dataGridView.DataSource == null)
            {
                dataGridView.DataSource = mainDataTable;
            }

            this.SetRowCount();

            this.spinningCircles.Visible = false;
            this.spinningCirclesConnectionPane.Visible = false;
        }

        private void BackgroundworkerConnectionPaneEH_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                Tuple<object,int> tuple = (Tuple<object, int>)e.Argument;

                int max = tuple.Item2;
                Form main = (Form)tuple.Item1;
                Task task = DoWorkAndSync(main,max);

                task.Wait();

            }
            catch(Exception exp)
            {
                MessageBox.Show("Error reading the events: "+exp.Message);
            }
            

        }

        private async Task DoWorkAndSync(Form main,int max)
        {
            try
            {
                ReadEventOptions reo = new ReadEventOptions();

                reo.MaximumWaitTime = new TimeSpan(0, 0, 5);

                reo.TrackLastEnqueuedEventProperties = false;

                 await using (var consumer = new EventHubConsumerClient(consumergroupname, eventHubConnectionString, eventhubname))
                 {

                     using var cancellationSource = new CancellationTokenSource();

                     cancellationSource.CancelAfter(TimeSpan.FromSeconds(120));

                     int i = 0;
                     await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(true, reo, cancellationSource.Token))
                     {
                         if (i >= max) break;

                        if (receivedEvent.Data != null)
                        {

                            string msg = Encoding.Default.GetString(receivedEvent.Data.Body.ToArray());

                            JObject jo = JObject.Parse(msg);

                            string lastmsg = jo["records"].First.ToString();

                            string cleaned = lastmsg.Replace("\n", "").Replace("\r", "");

                            System.IO.File.WriteAllText(@"c:\temp\tempfile.json", cleaned);

                            LoadJSONData(new string[] { @"c:\temp\tempfile.json" });

                           
                        } 
                        
                        i++;
                     }
                 }
            }
            catch (Exception exp)
            {
                MessageBox.Show(main,"Error reading the events: " + exp.Message);
            }
        }

        private void BackgroundworkerConnectionPane_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.spinningCirclesConnectionPane.Visible = false;

        }

        private void BackgroundworkerConnectionPane_DoWork(object sender, DoWorkEventArgs e)
        {
            Tuple<string, int> tuple = (Tuple<string, int>)e.Argument;
            string filter = tuple.Item1;
            int max = tuple.Item2;

            string connectionString = saConnectionString[0].ToString();

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // Get the container client object

            string containerName = GetCurrentFolderForLogs();

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            TreeNode tn = treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes[0].Nodes[0];

            ContextMenuStrip logsMenu = new ContextMenuStrip();

            ToolStripMenuItem loadIntoTable = new ToolStripMenuItem();

            loadIntoTable.Text = "Send to table";

            loadIntoTable.Click += LoadIntoTable_Click;

            logsMenu.Items.AddRange(new ToolStripMenuItem[] { loadIntoTable });

            var filterExt = ".log";

            if (!ClassicLogs) filterExt = ".json";

            int i = 0;
            // List all blobs in the container
            foreach (BlobItem blobItem in containerClient.GetBlobs(BlobTraits.None, BlobStates.None, filter))
            {
                if (blobItem.Name.Contains(filterExt))
                {
                    treeView.SafeInvoke(t => tn.Nodes.Add(blobItem.Name).ContextMenuStrip = logsMenu);
                    //tn.Nodes.Add(blobItem.Name).ContextMenuStrip = logsMenu;
                    i++;
                    if (i >= max) break;
                }
            }

            treeView.SafeInvoke(t => tn.ExpandAll());

        }

        #endregion

        #region Private aux methods
        private void SetRowCount()
        {
            lblNumberRows.Text = "Number of loaded rows: " + dataGridView.Rows.Count;
            toolTip1.SetToolTip(lblNumberRows, dataGridView.Rows.Count.ToString());
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

        private void MainDataTable_TableCleared(object sender, DataTableClearEventArgs e)
        {
            lblNumberRows.Text = "Number of loaded rows: " + mainDataTable.Rows.Count;
        }

        private void RemoveEventHubRootNode()
        {
            this.treeView.Nodes[0].Nodes[1].Remove();
        }

        private void AddEventHubRootNode()
        {
            this.treeView.Nodes[0].Nodes.Add("Event Hub");
        }

        #endregion

        #region Load Data
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
                        string location = jo["location"]?.ToString();
                        //string properties = jo["properties"]?.ToString();
                        string accountName = jo["properties"]?["accountName"]?.ToString()??string.Empty;
                        string requestUrl = jo["properties"]?["requestUrl"]?.ToString() ?? string.Empty;
                        string userAgentHeader = jo["properties"]?["userAgentHeader"]?.ToString() ?? string.Empty;
                        string referrerHeader = jo["properties"]?["referrerHeader"]?.ToString() ?? string.Empty;
                        string clientRequestId = jo["properties"]?["clientRequestId"]?.ToString() ?? string.Empty;
                        string etag = jo["properties"]?["etag"]?.ToString() ?? string.Empty;
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
        #endregion

        #region Event Handlers

        private void btnAddLogs_Click(object sender, EventArgs e)
        {
            DialogResult result;

            if (this.ClassicLogs)
            {
                result = openFileDialog.ShowDialog();
                filePaths = openFileDialog.FileNames;
            }
            else
            {
                result = openFileDialogJson.ShowDialog();
                filePaths = openFileDialogJson.FileNames;
            }

            if (result == DialogResult.OK)
            {
                try
                {
                    this.dataGridView.DataSource = null;
                    spinningCircles.Visible = true;
                    this.btnAddLogs.Enabled = false;
                    this.btnAddFolder.Enabled = false;
                    this.btbClearTable.Enabled = false;
                    backgroundworker.RunWorkerAsync();

                }
                catch (IOException ioexp)
                {
                    MessageBox.Show(ioexp.Message);
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
                            string filter = string.Empty;

                            if (colname.Equals("Manual", StringComparison.InvariantCultureIgnoreCase))
                                filter = this.txtFilter.Text;
                            else
                                filter = "[" + colname + "] like '%" + this.txtFilter.Text + "%'";
                            
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
                filePaths = openFileDialog.FileNames;
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
                        this.RemoveLabel_Click(this.treeView, null);
                        this.RemoveEventHubRootNode();
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
                        
                        this.RemoveLabel_Click(this.treeView, null);
                        this.AddEventHubRootNode();
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
     
        private void connectorPaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            if (VisiblePane)
            {
                //hide
                VisiblePane = false;
                panelLeft.Visible = false;
                tsmi.Checked = false;
            }
            else
            {
                //show
                VisiblePane = true;
                panelLeft.Visible = true;
                tsmi.Checked = true;
            }
        }

        private String GetCurrentFolderForLogs()
        {
            string containername = string.Empty;
            if (ClassicLogs)
                containername = "$logs"; 
            else
                containername = "insights-logs-storageread";
            return containername;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A GUI Windows application (.Net 4.8 Windows Forms) that allows to read and export the Azure Storage Log files. GitHub repository: https://github.com/nunomo/AzureStorageLogReader");
        }
        #endregion

        #region Treeview Events
        private void treeView_DoubleClick(object sender, EventArgs e)
        {

            TreeNode selectedNode = this.treeView.SelectedNode;

            if (saConnectionString.Count == 0)
            {
                if (selectedNode.Name == "StorageAccounts")
                {
                    try
                    {
                        SALogin cpf = new SALogin(ref saConnectionString);

                        if (cpf.ShowDialog(this) == DialogResult.OK)
                        {
                            string connectionString = saConnectionString[0].ToString();

                            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                            //insights-logs-storageread
                            string containerName = GetCurrentFolderForLogs();

                            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                            if (containerClient.Exists())
                            {
                                //Create context menu for root node to add the remove option
                                ContextMenuStrip connectionMenu = new ContextMenuStrip();
                                ToolStripMenuItem removeLabel = new ToolStripMenuItem();
                                removeLabel.Text = "Remove";
                                removeLabel.Click += RemoveLabel_Click;
                                connectionMenu.Items.AddRange(new ToolStripMenuItem[] { removeLabel });
                                TreeNode tn = treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes.Add(GetSANameFromCS(connectionString));
                                tn.ContextMenuStrip = connectionMenu;

                                //Create $logs container tree node
                                TreeNode tnchild = tn.Nodes.Add(containerClient.Name);
                                ContextMenuStrip logsMenu = new ContextMenuStrip();
                                ToolStripMenuItem loadLabel = new ToolStripMenuItem();
                                loadLabel.Text = "Load";
                                loadLabel.Click += LoadLabel_Click;
                                ToolStripMenuItem sendAlltoTable = new ToolStripMenuItem();
                                sendAlltoTable.Text = "Send all to table";
                                sendAlltoTable.Click += SendAlltoTable_Click;
                                logsMenu.Items.AddRange(new ToolStripMenuItem[] { loadLabel,sendAlltoTable });
                                tnchild.ContextMenuStrip = logsMenu;

                                treeView.Nodes["Connections"].Nodes["StorageAccounts"].ExpandAll();
                                //tn.ExpandAll();
                          
                            }
                            else
                            {
                                MessageBox.Show(containerName+" container not found!");
                                saConnectionString.Clear();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        saConnectionString.Clear();
                        MessageBox.Show(exp.Message);
                    }
                }
            }

            if (string.IsNullOrEmpty(eventHubConnectionString))
            {
                if (selectedNode.Text == "Event Hub")
                {
                    try
                    {
                        EHLogin cpf = new EHLogin();

                        if (cpf.ShowDialog(this) == DialogResult.OK)
                        {
                            eventHubConnectionString = cpf.ConnectionString;
                            eventhubname = cpf.EventHubName;
                            consumergroupname = cpf.ConsumerGroupName;
                            
                            if (!string.IsNullOrEmpty(eventHubConnectionString) && !string.IsNullOrEmpty(eventhubname) && !string.IsNullOrEmpty(consumergroupname))
                            {
                                
                                //Create context menu for root node to add the remove option
                                ContextMenuStrip connectionMenu = new ContextMenuStrip();

                                ToolStripMenuItem RemoveEHLabel = new ToolStripMenuItem();
                                RemoveEHLabel.Text = "Remove";
                                RemoveEHLabel.Click += RemoveEHLabel_Click; ;
                                ToolStripMenuItem LoadEHLabel = new ToolStripMenuItem();
                                LoadEHLabel.Text = "Load Logs";
                                LoadEHLabel.Click += LoadEHLabel_Click;
                                connectionMenu.Items.AddRange(new ToolStripMenuItem[] { RemoveEHLabel,LoadEHLabel });
                                TreeNode tn = treeView.Nodes["Connections"].Nodes[1].Nodes.Add(GetSANameFromCS(eventhubname));
                                tn.ContextMenuStrip = connectionMenu;


                                treeView.Nodes["Connections"].Nodes[1].ExpandAll();
                                tn.ExpandAll();
                                      
                            }
                            else
                            {
                                MessageBox.Show("Missing mandatory field!");
                                saConnectionString.Clear();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        eventHubConnectionString = string.Empty;
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }

        //Load event hub logs
        private void LoadEHLabel_Click(object sender, EventArgs e)
        {
            //Get Filter parameters
            FilterEHForm cpf = new FilterEHForm();

            cpf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            cpf.StartPosition = FormStartPosition.CenterParent;

            if (cpf.ShowDialog(this) == DialogResult.OK)
            {

                //Load data

                this.spinningCirclesConnectionPane.Visible = true;
                this.spinningCircles.Visible = true;

                backgroundworkerConnectionPaneEH.RunWorkerAsync(new Tuple<object,int>(this,cpf.Max));

            }
        }

        //Remove Event hub logs
        private void RemoveEHLabel_Click(object sender, EventArgs e)
        {
            eventHubConnectionString = string.Empty;
            eventhubname = string.Empty;
            consumergroupname = string.Empty;
            treeView.Nodes["Connections"].Nodes[1].Nodes.Clear();
        }

        private string GetSANameFromCS(string connectionString)
        {
            string[] connSplited = connectionString.Split(';');
            foreach(string str in connSplited)
            {
                if(str.Contains("AccountName"))
                {
                    var saname = str.Split('=')[1];
                    return saname;
                }
            }
            return connectionString;
        }

        /// <summary>
        /// Load Classic\Preview Storage logs from the $logs\insights container 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadLabel_Click(object sender, EventArgs e)
        {

            //Get Filter parameters
            FilterSAForm cpf = new FilterSAForm();

            cpf.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            cpf.StartPosition = FormStartPosition.CenterParent;

            if (cpf.ShowDialog(this) == DialogResult.OK)
            {

                //Load data

                this.spinningCirclesConnectionPane.Visible = true;
     
                backgroundworkerConnectionPane.RunWorkerAsync(new Tuple<string,int>(cpf.Prefix, cpf.Max));
                
            }
        }
   
        private void SendAlltoTable_Click(object sender, EventArgs e)
        {
            this.spinningCirclesConnectionPane.Visible = true;
            this.spinningCircles.Visible = true;

            dataGridView.DataSource = null;

            backgroundworkerConnectionPaneLoadAll.RunWorkerAsync();   
        }

        /// <summary>
        /// Loads selected node in the tree view to the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadIntoTable_Click(object sender, EventArgs e)
        {

            //use SourceControl property.. ContextMenuStrip must be associated with TreeView
            ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            TreeView treeView = (TreeView)cms.SourceControl;
            TreeNode node = treeView.GetNodeAt(treeView.PointToClient(cms.Location));

            string connectionString = saConnectionString[0].ToString();

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // Get the container client object

            string containerName = GetCurrentFolderForLogs(); 

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            BlobClient bc = containerClient.GetBlobClient(node.Text);

            if (ClassicLogs)
            {
                var response = bc.DownloadTo(@"c:\temp\tempfile.log");

                LoadData(new string[] { @"c:\temp\tempfile.log" });
            }
            else
            {
                var response = bc.DownloadTo(@"c:\temp\tempfile.json");

                LoadJSONData(new string[] { @"c:\temp\tempfile.json" });
            }

            if (dataGridView.DataSource == null)
            {
                dataGridView.DataSource = mainDataTable;
            }

            this.SetRowCount();
        }

        /// <summary>
        /// Removes the storage account connection from the treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLabel_Click(object sender, EventArgs e)
        {
            saConnectionString.Clear();
            treeView.Nodes["Connections"].Nodes["StorageAccounts"].Nodes.Clear();
        }


        #endregion

        private void AddFolder_Click(object sender, EventArgs e)
        {
            if (this.ClassicLogs)
            {
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;

                openFileDialog.FileName = "Folder Selection.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string folderPath = Path.GetDirectoryName(openFileDialog.FileName);

                        filePaths = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

                        this.dataGridView.DataSource = null;
                        spinningCircles.Visible = true;
                        this.btnAddLogs.Enabled = false;
                        this.btbClearTable.Enabled = false;
                        this.btnAddFolder.Enabled = false;
                        backgroundworker.RunWorkerAsync();

                    }
                    catch (IOException ioexp)
                    {
                        MessageBox.Show(ioexp.Message);
                    }
                }

                return;
            }
        }

        private void cmbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbColumns.SelectedItem.ToString().Equals("Manual", StringComparison.InvariantCultureIgnoreCase))
            {
                this.txtFilter.Text = "[Column1] like '%value1%' and [Column2] like '%value2%'";
            }
            else
                this.txtFilter.Text = "";
        }
    }
}
