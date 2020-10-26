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
    public partial class ColumnsPickerForm : Form
    {
        private Dictionary<string, bool> tableHeaderNames;

        public ColumnsPickerForm()
        {
            InitializeComponent();
        }

        public ColumnsPickerForm(Dictionary<string, bool> tableHeaderNames):this()
        {

            try
            {

                this.tableHeaderNames = tableHeaderNames;

                this.checkBoxVersion.Checked = tableHeaderNames["Version"];
                this.checkBoxRequestStartTime.Checked = tableHeaderNames["RequestStartTime"];
                this.checkBoxOperationType.Checked = tableHeaderNames["OperationType"];
                this.checkBoxRequestStatus.Checked = tableHeaderNames["RequestStatus"];
                this.checkBoxHttpStatusCode.Checked = tableHeaderNames["HttpStatusCode"];
                this.checkBoxE2E_Latency.Checked = tableHeaderNames["E2E_Latency(ms)"];
                this.checkBoxServerLatency.Checked = tableHeaderNames["ServerLatency(ms)"];
                this.checkBoxAuthenticationType.Checked = tableHeaderNames["AuthenticationType"];
                this.checkBoxRequesterAccountName.Checked = tableHeaderNames["RequesterAccountName"];
                this.checkBoxOwnerAccountName.Checked = tableHeaderNames["OwnerAccountName"];
                this.checkBoxServiceType.Checked = tableHeaderNames["ServiceType"];
                this.checkBoxRequestURL.Checked = tableHeaderNames["RequestURL"];
                this.checkBoxRequestObjectKey.Checked = tableHeaderNames["RequestObjectKey"];
                this.checkBoxRequestID.Checked = tableHeaderNames["RequestID"];
                this.checkBoxOperationCount.Checked = tableHeaderNames["OperationCount"];
                this.checkBoxClientIP.Checked = tableHeaderNames["ClientIP"];
                this.checkBoxAPIVersion.Checked = tableHeaderNames["APIVersion"];
                this.checkBoxRequestHeaderSize.Checked = tableHeaderNames["RequestHeaderSize(bytes)"];
                this.checkBoxRequestPacketSize.Checked = tableHeaderNames["RequestPacketSize(bytes)"];
                this.checkBoxResponseHeaderSize.Checked = tableHeaderNames["ResponseHeaderSize(bytes)"];
                this.checkBoxResponsePacketSize.Checked = tableHeaderNames["ResponsePacketSize(bytes)"];
                this.checkBoxRequestContentLenght.Checked = tableHeaderNames["RequestContentLenght(bytes)"];
                this.checkBoxRequestMd5.Checked = tableHeaderNames["RequestMd5"];
                this.checkBoxServerMd5.Checked = tableHeaderNames["ServerMd5"];
                this.checkBoxetag.Checked = tableHeaderNames["etag"];
                this.checkBoxLastModifiedTime.Checked = tableHeaderNames["LastModifiedTime"];
                this.checkBoxConditionsUsed.Checked = tableHeaderNames["ConditionsUsed"];
                this.checkBoxUserAgent.Checked = tableHeaderNames["UserAgent"];
                this.checkBoxReferrerHeader.Checked = tableHeaderNames["ReferrerHeader"];
                this.checkBoxClientRequestID.Checked = tableHeaderNames["ClientRequestID"];
                this.checkBoxUserObjectID.Checked = tableHeaderNames["UserObjectID"];
                this.checkBoxTenantID.Checked = tableHeaderNames["TenantID"];
                this.checkBoxApplicationID.Checked = tableHeaderNames["ApplicationID"];
                this.checkBoxResourceID.Checked = tableHeaderNames["ResourceID"];
                this.checkBoxIssuer.Checked = tableHeaderNames["Issuer"];
                this.checkBoxUserPrincipalName.Checked = tableHeaderNames["UserPrincipalName"];
                this.checkBoxReserved.Checked = tableHeaderNames["Reserved"];
                this.checkBoxAuthenticationDetails.Checked = tableHeaderNames["AuthenticationDetails"];
                /*


                tableHeaderNames.Add("OperationType", true);
                tableHeaderNames.Add("RequestStatus", true);
                tableHeaderNames.Add("HttpStatusCode", true);
                tableHeaderNames.Add("E2E_Latency(ms)", true);
                tableHeaderNames.Add("ServerLatency(ms)", true);
                tableHeaderNames.Add("AuthenticationType", true);
                tableHeaderNames.Add("RequesterAccountName", true);
                tableHeaderNames.Add("OwnerAccountName", true);
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
                tableHeaderNames.Add("RequestMd5", true);
                tableHeaderNames.Add("ServerMd5", true);
                tableHeaderNames.Add("etag", true);
                tableHeaderNames.Add("LastModifiedTime", true);
                tableHeaderNames.Add("ConditionsUsed", true);
                tableHeaderNames.Add("UserAgent", true);
                tableHeaderNames.Add("ReferrerHeader", true);
                tableHeaderNames.Add("ClientRequestID", true);
                tableHeaderNames.Add("UserObjectID", true);
                tableHeaderNames.Add("TenantID", true);
                tableHeaderNames.Add("ApplicationID", true);
                tableHeaderNames.Add("ResourceID", true);
                tableHeaderNames.Add("Issuer", true);
                tableHeaderNames.Add("UserPrincipalName", true);
                tableHeaderNames.Add("Reserved", true);
                tableHeaderNames.Add("AuthenticationDetails", true);
                tableHeaderNames.Add("ColLast", false);
                tableHeaderNames.Add("Extra1", false);
                tableHeaderNames.Add("Extra2", false);
                */
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplly_Click(object sender, EventArgs e)
        {

            try 
            { 
                tableHeaderNames["Version"] = this.checkBoxVersion.Checked;

                tableHeaderNames["RequestStartTime"] = this.checkBoxRequestStartTime.Checked;

                tableHeaderNames["OperationType"] = this.checkBoxOperationType.Checked;

                tableHeaderNames["RequestStatus"] = this.checkBoxRequestStatus.Checked;

                tableHeaderNames["HttpStatusCode"] = this.checkBoxHttpStatusCode.Checked;

                tableHeaderNames["E2E_Latency(ms)"] = this.checkBoxE2E_Latency.Checked;

                tableHeaderNames["ServerLatency(ms)"] = this.checkBoxServerLatency.Checked;

                tableHeaderNames["AuthenticationType"] = this.checkBoxAuthenticationType.Checked;

                tableHeaderNames["RequesterAccountName"] = this.checkBoxRequesterAccountName.Checked;

                tableHeaderNames["OwnerAccountName"] = this.checkBoxOwnerAccountName.Checked;

                tableHeaderNames["ServiceType"] = this.checkBoxServiceType.Checked;

                tableHeaderNames["RequestURL"] = this.checkBoxRequestURL.Checked;

                tableHeaderNames["RequestObjectKey"] = this.checkBoxRequestObjectKey.Checked;

                tableHeaderNames["RequestID"] = this.checkBoxRequestID.Checked;

                tableHeaderNames["OperationCount"] = this.checkBoxOperationCount.Checked;

                tableHeaderNames["ClientIP"] = this.checkBoxClientIP.Checked;

                tableHeaderNames["APIVersion"] = this.checkBoxAPIVersion.Checked;

                tableHeaderNames["RequestHeaderSize(bytes)"] = this.checkBoxRequestHeaderSize.Checked;

                tableHeaderNames["RequestPacketSize(bytes)"] = this.checkBoxRequestPacketSize.Checked;

                tableHeaderNames["ResponseHeaderSize(bytes)"] = this.checkBoxResponseHeaderSize.Checked;

                tableHeaderNames["ResponsePacketSize(bytes)"] = this.checkBoxResponsePacketSize.Checked;

                tableHeaderNames["RequestContentLenght(bytes)"] = this.checkBoxRequestContentLenght.Checked;

                tableHeaderNames["RequestMd5"] = this.checkBoxRequestMd5.Checked;

                tableHeaderNames["ServerMd5"] = this.checkBoxServerMd5.Checked;

                tableHeaderNames["etag"] = this.checkBoxetag.Checked;

                tableHeaderNames["LastModifiedTime"] = this.checkBoxLastModifiedTime.Checked;

                tableHeaderNames["ConditionsUsed"] = this.checkBoxConditionsUsed.Checked;

                tableHeaderNames["UserAgent"] = this.checkBoxUserAgent.Checked;

                tableHeaderNames["ReferrerHeader"] = this.checkBoxReferrerHeader.Checked;

                tableHeaderNames["ClientRequestID"] = this.checkBoxClientRequestID.Checked;

                tableHeaderNames["UserObjectID"] = this.checkBoxUserObjectID.Checked;

                tableHeaderNames["TenantID"] = this.checkBoxTenantID.Checked;

                tableHeaderNames["ApplicationID"] = this.checkBoxApplicationID.Checked;

                tableHeaderNames["ResourceID"] = this.checkBoxResourceID.Checked;

                tableHeaderNames["Issuer"] = this.checkBoxIssuer.Checked;

                tableHeaderNames["UserPrincipalName"] = this.checkBoxUserPrincipalName.Checked;

                tableHeaderNames["Reserved"] = this.checkBoxReserved.Checked;

                tableHeaderNames["AuthenticationDetails"] = this.checkBoxAuthenticationDetails.Checked;

                this.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }
    }
}
