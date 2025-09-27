using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AlgoSync;
using System.Threading;

namespace AlgoSync
{
    public partial class Form1 : Form
    {
        dynamic FI;
        dynamic FI1;
        List<string> lstCompCodes = new List<string>();
        bool m_CRMCredsVerified = false;
        DateTime? m_lastSyncDate = null;
        List<int> checkedMasters = new List<int>();
        int m_UserId;
        int m_CompanyId;
        Dictionary<int, string> jsonMasters;
        Dictionary<int, string> xmlMasters;
        Dictionary<int, string> qryMasters;
        private CancellationTokenSource _cts = null;


        public Form1()
        {
            InitializeComponent();
        }

        void frmMain_Load(object sender, EventArgs e)
        {
            SetDefaultValues();
            SetInputControls();
        }

        void SetDefaultValues()
        {
            int savedCompanyIdx = -1;
            int savedFinYrIdx = -1;
            int i = 0;

            jsonMasters = new Dictionary<int, string>
                        {
                            { g_CL.ACC_MAST, "accounts" },
                            { g_CL.CONT_GRP_MAST, "contactGroups" },
                            { g_CL.EXECUTIVE_MAST, "executives" },
                            { g_CL.ITEM_MAST, "items" },
                            { g_CL.IGRP_MAST, "itemGroups" },
                            { g_CL.UNIT_MAST, "units" },
                            { g_CL.AREA_MAST, "areas" },
                            { g_CL.STATE_MAST, "states" },
                            { g_CL.COUNTRY_MAST, "countries" },
                            { g_CL.CONT_DEPT_MAST, "contactDepartments" },
                        };

            qryMasters = new Dictionary<int, string>
                        {
                            { g_CL.CALL_CATEGORY_ENQUIRY_MAST, "enquiryCategories" },
                            { g_CL.CRM_SOURCE_MAST, "enquirySources" },
                            { g_CL.CALL_CATEGORY_SUPPORT_MAST, "supportCategories" },
                        };

            xmlMasters = new Dictionary<int, string>
                        {
                            { g_CL.CONTACT_MAST, "contacts" }
                        };

            try
            {
                FI = Activator.CreateInstance(Type.GetTypeFromProgID("Busy2L21.CFixedInterface"));
                FI1 = Activator.CreateInstance(Type.GetTypeFromProgID("Busy2L21.CFixedInterface1"));
            }
            catch (Exception ex)
            {

            }


            if (System.IO.File.Exists("userdata.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("userdata.txt");

                txtAppPath.Text = lines[i]; i++;
                txtDataPath.Text = lines[i]; i++;
                txtServerName.Text = lines[i]; i++;
                txtUsername.Text = lines[i]; i++;
                txtPassword.Text = lines[i]; i++;
                txtTallyServer.Text = lines[i]; i++;
                txtTallyPort.Text = lines[i]; i++;
                txtCRMUsername.Text = lines[i]; i++;
                txtCRMPassword.Text = lines[i]; i++;
                txtCRMCompCode.Text = lines[i]; i++;
                rbBusy.Checked = bool.Parse(lines[i]); i++;
                rbTally.Checked = bool.Parse(lines[i]); i++;
                rbAccess.Checked = bool.Parse(lines[i]); i++;
                rbSQL.Checked = bool.Parse(lines[i]); i++;
                rbBulk.Checked = bool.Parse(lines[i]); i++;
                rbIncremental.Checked = bool.Parse(lines[i]); i++;
                chkAccount.Checked = bool.Parse(lines[i]); i++;
                chkContact.Checked = bool.Parse(lines[i]); i++;
                chkContactGroup.Checked = bool.Parse(lines[i]); i++;
                chkExecutive.Checked = bool.Parse(lines[i]); i++;
                chkItem.Checked = bool.Parse(lines[i]); i++;
                chkItemGroup.Checked = bool.Parse(lines[i]); i++;
                chkUnit.Checked = bool.Parse(lines[i]); i++;
                chkArea.Checked = bool.Parse(lines[i]); i++;
                chkEnqSource.Checked = bool.Parse(lines[i]); i++;
                chkEnqCat.Checked = bool.Parse(lines[i]); i++;
                chkSupCat.Checked = bool.Parse(lines[i]); i++;
                chkState.Checked = bool.Parse(lines[i]); i++;
                chkCountry.Checked = bool.Parse(lines[i]); i++;
                chkContactDepartment.Checked = bool.Parse(lines[i]); i++;
                chkTallyGroup.Checked = bool.Parse(lines[i]); i++;
                chkTallyLedger.Checked = bool.Parse(lines[i]); i++;
                chkTallyStockGroup.Checked = bool.Parse(lines[i]); i++;
                chkTallyStockItem.Checked = bool.Parse(lines[i]); i++;
                chkTallyUnit.Checked = bool.Parse(lines[i]); i++;
                int.TryParse(lines[i], out savedCompanyIdx); i++;
                int.TryParse(lines[i], out savedFinYrIdx); i++;
                m_lastSyncDate = DateTime.TryParse(lines[i], out var dt) ? dt : (DateTime?)null; i++;

                ActionOnProductTypeChange();
                ActionOnDBTypeChange();
                VerifyCRMCreds();
            }
            else
            {
                rbBusy.Checked = true;
                rbAccess.Checked = true;
                rbBulk.Checked = true;
                chkAccount.Checked = true;
                chkContact.Checked = true;
                chkContactGroup.Checked = true;
                chkExecutive.Checked = true;
                chkItem.Checked = true;
                chkItemGroup.Checked = true;
                chkUnit.Checked = true;
                chkArea.Checked = true;
                chkEnqSource.Checked = true;
                chkEnqCat.Checked = true;
                chkSupCat.Checked = true;
                chkState.Checked = true;
                chkCountry.Checked = true;
                chkContactDepartment.Checked = true;
                chkTallyGroup.Checked = true;
                chkTallyLedger.Checked = true;
                chkTallyStockGroup.Checked = true;
                chkTallyStockItem.Checked = true;
                chkTallyUnit.Checked = true;
            }

            if (string.IsNullOrWhiteSpace(txtAppPath.Text))
                txtAppPath.Text = g_CL.DetectBusyPath();

            if (string.IsNullOrWhiteSpace(txtDataPath.Text))
                txtDataPath.Text = g_CL.GetBusyDataPath(txtAppPath.Text);

            if (string.IsNullOrWhiteSpace(txtTallyServer.Text))
                txtTallyServer.Text = "localhost";

            if (string.IsNullOrWhiteSpace(txtTallyPort.Text))
                txtTallyPort.Text = "9000";

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                txtUsername.Text = "sa";

            if (string.IsNullOrWhiteSpace(txtServerName.Text))
                txtServerName.Text = "localhost";

            LoadBusyCompListToCombo();

            if (savedCompanyIdx >= 0 && savedCompanyIdx < cbSelectCompany.Items.Count)
                cbSelectCompany.SelectedIndex = savedCompanyIdx;

            if (savedFinYrIdx >= 0 && savedFinYrIdx < cbFinYr.Items.Count)
                cbFinYr.SelectedIndex = savedFinYrIdx;
        }

        void SetInputControls()
        {
            gbTally.Left = gbBusy.Left;
            gbTally.Top = gbBusy.Top;

            gbTallyMasters.Left = gbBusyMasters.Left;
            gbTallyMasters.Top = gbBusyMasters.Top;

            lblTally.BackColor = Form1.DefaultBackColor;
            lblCRM.BackColor = Form1.DefaultBackColor;
            lblProgress.BackColor = Form1.DefaultBackColor;
            lblProgress2.BackColor = Form1.DefaultBackColor;

            btnStop.Enabled = false;
            btnLoadCompanies.Focus();
        }

        void rbBusy_CheckedChanged(object sender, EventArgs e)
        {
            ActionOnProductTypeChange();
        }

        async void ActionOnProductTypeChange()
        {
            if (rbBusy.Checked)
            {
                gbBusy.Visible = true;
                gbTally.Visible = false;
                gbDatabase.Visible = true;
                gbDataTransferType.Visible = true;
                gbBusyMasters.Visible = true;
                gbTallyMasters.Visible = false;
            }
            else
            {
                gbBusy.Visible = false;
                gbTally.Visible = true;
                gbDatabase.Visible = false;
                gbDataTransferType.Visible = false;
                gbBusyMasters.Visible = false;
                gbTallyMasters.Visible = true;

                string companyName = (await GetTallyCurrentCompName()).Replace("&", "&&");
                lblTally.Text = companyName;
            }
        }

        void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
            ActionOnDBTypeChange();
        }

        void ActionOnDBTypeChange()
        {
            lblDataPath.Visible = rbAccess.Checked;
            txtDataPath.Visible = rbAccess.Checked;
            btnBrowseDataPath.Visible = rbAccess.Checked;

            lblServerName.Visible = !rbAccess.Checked;
            txtServerName.Visible = !rbAccess.Checked;
            lblUsername.Visible = !rbAccess.Checked;
            txtUsername.Visible = !rbAccess.Checked;
            lblPassword.Visible = !rbAccess.Checked;
            txtPassword.Visible = !rbAccess.Checked;
            chkBusyPass.Visible = !rbAccess.Checked;

            LoadBusyCompListToCombo();

            if (rbAccess.Checked)
            {
                btnLoadCompanies.Top = txtDataPath.Top + 30;
            }
            else
            {
                btnLoadCompanies.Top = txtPassword.Top + 30;
            }
        }

        void chkBusyPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkBusyPass.Checked ? '\0' : '*';
        }

        void chkCRMPass_CheckedChanged(object sender, EventArgs e)
        {
            txtCRMPassword.PasswordChar = chkCRMPass.Checked ? '\0' : '*';
        }

        void btnBrowseDataPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = txtDataPath.Text.Trim();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDataPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        void LoadBusyCompListToCombo()
        {
            cbSelectCompany.Items.Clear();
            cbSelectCompany.Text = "";
            cbSelectCompany.SelectedIndex = -1;

            cbFinYr.Items.Clear();
            cbFinYr.Text = "";
            cbFinYr.SelectedIndex = -1;

            lstCompCodes.Clear();

            if (rbAccess.Checked)
            {
                if (!string.IsNullOrWhiteSpace(txtDataPath.Text))
                {
                    if (!txtDataPath.Text.Trim().EndsWith("\\"))
                    {
                        txtDataPath.Text = txtDataPath.Text.Trim() + "\\";
                    }

                    var compList = FI.GetCompList(txtDataPath.Text);

                    if (compList != null)
                    {

                        foreach (var item in compList)
                        {
                            cbSelectCompany.Items.Add(item[1]);
                            lstCompCodes.Add(item[2]);
                        }

                        if (cbSelectCompany.Items.Count > 0)
                        {
                            cbSelectCompany.SelectedIndex = 0;
                        }

                    }

                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtServerName.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    var compList = FI.GetCompListForCS(txtServerName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());

                    if (compList != null)
                    {

                        foreach (var item in compList)
                        {
                            cbSelectCompany.Items.Add(item[1]);
                            lstCompCodes.Add(item[2]);
                        }

                        if (cbSelectCompany.Items.Count > 0)
                        {
                            cbSelectCompany.SelectedIndex = 0;
                        }

                    }
                }

            }

        }


        void cbSelectCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectCompany.SelectedIndex > -1)
            {
                var selectedCompany = lstCompCodes[cbSelectCompany.SelectedIndex];
                var FinYearsList = FI1.GetAllFinYearsOfSpecificCompCode(selectedCompany);
                string lastFinYear = "";

                cbFinYr.Items.Clear();

                foreach (var item in FinYearsList)
                {
                    cbFinYr.Items.Add(item);
                    lastFinYear = item.ToString();
                }

                g_CL.FindComboIndex(cbFinYr, lastFinYear);
            }
        }

        void txtServerName_Leave(object sender, EventArgs e)
        {

        }

        void txtUsername_Leave(object sender, EventArgs e)
        {

        }

        void txtPassword_Leave(object sender, EventArgs e)
        {

        }

        void btnLoadCompanies_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                LoadBusyCompListToCombo();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        async void btnStart_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();

            try
            {
                await RunMainProcessAsync(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Process stopped by user.", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        bool ValidateDataB4StartingProcess(ref string p_ErrMsg)
        {
            bool proceed = true;
            int finYear = Convert.ToInt16(cbFinYr.Text);

            if (rbBusy.Checked)
            {
                if (proceed)
                {
                    if (cbSelectCompany.Items.Count <= 0 || cbSelectCompany.SelectedIndex < 0)
                    {
                        proceed = false;
                        p_ErrMsg = "Please select a valid company.";
                    }

                }

                if (proceed)
                {
                    if (cbFinYr.Items.Count <= 0 || cbFinYr.SelectedIndex < 0)
                    {
                        proceed = false;
                        p_ErrMsg = "Please select a valid financial year.";
                    }

                }
            }
            else
            {
                if (lblTally.Text.Trim() == "")
                {
                    proceed = false;
                    p_ErrMsg = "Tally company not detected, make sure company is open in tally.";
                }

                if (string.IsNullOrWhiteSpace(txtTallyPort.Text) || string.IsNullOrWhiteSpace(txtTallyServer.Text))
                {
                    proceed = false;
                    p_ErrMsg = "Please specify port and server details.";
                }
            }

            if (proceed)
            {
                if (!m_CRMCredsVerified)
                {
                    proceed = false;
                    p_ErrMsg = "Please verify the AlgoCRM credentials in order to proceed further.";
                }
            }

            if (proceed)
            {
                checkedMasters.Clear();

                if (rbTally.Checked)
                {
                    if (chkTallyLedger.Checked) checkedMasters.Add(g_CL.ACC_MAST);
                    if (chkTallyGroup.Checked) checkedMasters.Add(g_CL.AGRP_MAST);
                    if (chkTallyStockItem.Checked) checkedMasters.Add(g_CL.ITEM_MAST);
                    if (chkTallyStockGroup.Checked) checkedMasters.Add(g_CL.IGRP_MAST);
                    if (chkTallyUnit.Checked) checkedMasters.Add(g_CL.UNIT_MAST);
                }
                else
                {
                    if (chkAccount.Checked) checkedMasters.Add(g_CL.ACC_MAST);
                    if (chkContactGroup.Checked) checkedMasters.Add(g_CL.CONT_GRP_MAST);
                    if (chkExecutive.Checked) checkedMasters.Add(g_CL.EXECUTIVE_MAST);
                    if (chkItem.Checked) checkedMasters.Add(g_CL.ITEM_MAST);
                    if (chkItemGroup.Checked) checkedMasters.Add(g_CL.IGRP_MAST);
                    if (chkUnit.Checked) checkedMasters.Add(g_CL.UNIT_MAST);
                    if (chkArea.Checked) checkedMasters.Add(g_CL.AREA_MAST);
                    if (chkState.Checked) checkedMasters.Add(g_CL.STATE_MAST);
                    if (chkCountry.Checked) checkedMasters.Add(g_CL.COUNTRY_MAST);
                    if (chkContactDepartment.Checked) checkedMasters.Add(g_CL.CONT_DEPT_MAST);
                    if (chkContact.Checked) checkedMasters.Add(g_CL.CONTACT_MAST);
                    if (chkEnqCat.Checked) checkedMasters.Add(g_CL.CALL_CATEGORY_ENQUIRY_MAST);
                    if (chkEnqSource.Checked) checkedMasters.Add(g_CL.CRM_SOURCE_MAST);
                    if (chkSupCat.Checked) checkedMasters.Add(g_CL.CALL_CATEGORY_SUPPORT_MAST);
                }

                if (checkedMasters.Count == 0)
                {
                    proceed = false;
                    p_ErrMsg = "Please select at least one master type to sync.";
                }

            }


            if (proceed)
            {
                DialogResult result = MessageBox.Show(
                        "Starting data transfer. Please review all details before proceeding and click Yes to continue.",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (result != DialogResult.Yes)
                {
                    proceed = false;
                }
            }


            if (proceed)
            {
                Cursor.Current = Cursors.WaitCursor;
                g_CL.SetAllControlsEnabled(this, false);
                lblProgress.Enabled = true;
                lblProgress2.Enabled = true;
                btnStop.Enabled = true;
                Application.DoEvents();


                lblProgress.Text = "Establishing connection...";
                if (rbBusy.Checked)
                {
                    if (rbAccess.Checked)
                    {
                        proceed = FI.OpenDB(txtAppPath.Text.Trim(), txtDataPath.Text.Trim(), lstCompCodes[cbSelectCompany.SelectedIndex], finYear);
                    }
                    else
                    {
                        proceed = FI.OpenCSDBForYear(txtAppPath.Text.Trim(), txtServerName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), lstCompCodes[cbSelectCompany.SelectedIndex], finYear);
                    }

                    if (!proceed)
                    {
                        p_ErrMsg = "Failed to connect to Busy database. Please check the details and try again.";
                    }
                }
                else
                {
                    //tally
                }
            }


            return proceed;
        }

        private void VerifyCRMCreds()
        {
            bool proceed = true;
            string errMsg = "";
            string companyName = "";

            m_CRMCredsVerified = false;

            if (proceed)
            {
                if (string.IsNullOrWhiteSpace(txtCRMUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtCRMPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtCRMCompCode.Text))
                {
                    proceed = false;
                }
            }

            if (proceed)
            {
                try
                {
                    string apiUrl = g_CL.ReadVerifyAPIURLFromTextFile();
                    var payload = new
                    {
                        contact = txtCRMUsername.Text.Trim(),
                        password = txtCRMPassword.Text.Trim(),
                        c_id = txtCRMCompCode.Text.Trim()
                    };

                    using (var client = new HttpClient())
                    {
                        var json = JsonConvert.SerializeObject(payload);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = client.PostAsync(apiUrl, content).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var responseBody = response.Content.ReadAsStringAsync().Result;
                            var jObj = JObject.Parse(responseBody);

                            bool status = jObj.Value<bool>("status");
                            if (status)
                            {
                                companyName = jObj["data"]?["companyName"]?.ToString() ?? "";
                                m_UserId = jObj["data"]?["user_id"]?.Value<int>() ?? 0;
                                m_CompanyId = jObj["data"]?["company_id"]?.Value<int>() ?? 0;
                            }
                            else
                            {
                                proceed = false;
                                errMsg = jObj.Value<string>("message");
                            }

                        }
                        else
                        {
                            proceed = false;
                            errMsg = "Unknown error occurred.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    proceed = false;
                    errMsg = ex.Message;
                }
            }

            if (proceed)
            {
                m_CRMCredsVerified = true;
                lblCRM.ForeColor = System.Drawing.Color.Green;
                lblCRM.Text = "Credentials Verified.\r\n\r\nCompany Name : " + companyName;
            }
            else
            {
                m_CRMCredsVerified = false;
                lblCRM.ForeColor = System.Drawing.Color.Red;
                lblCRM.Text = "Credentials Not Verified";
            }

            if (!proceed && !string.IsNullOrWhiteSpace(errMsg))
            {
                MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void btnCRMVerify_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                VerifyCRMCreds();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            g_CL.DisposeObjectsInEnd();

            var lines = new List<string>
            {
                txtAppPath.Text.Trim(),
                txtDataPath.Text.Trim(),
                txtServerName.Text.Trim(),
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                txtTallyServer.Text.Trim(),
                txtTallyPort.Text.Trim(),
                txtCRMUsername.Text.Trim(),
                txtCRMPassword.Text.Trim(),
                txtCRMCompCode.Text.Trim(),
                rbBusy.Checked.ToString(),
                rbTally.Checked.ToString(),
                rbAccess.Checked.ToString(),
                rbSQL.Checked.ToString(),
                rbBulk.Checked.ToString(),
                rbIncremental.Checked.ToString(),
                chkAccount.Checked.ToString(),
                chkContact.Checked.ToString(),
                chkContactGroup.Checked.ToString(),
                chkExecutive.Checked.ToString(),
                chkItem.Checked.ToString(),
                chkItemGroup.Checked.ToString(),
                chkUnit.Checked.ToString(),
                chkArea.Checked.ToString(),
                chkEnqSource.Checked.ToString(),
                chkEnqCat.Checked.ToString(),
                chkSupCat.Checked.ToString(),
                chkState.Checked.ToString(),
                chkCountry.Checked.ToString(),
                chkContactDepartment.Checked.ToString(),
                chkTallyGroup.Checked.ToString(),
                chkTallyLedger.Checked.ToString(),
                chkTallyStockGroup.Checked.ToString(),
                chkTallyStockItem.Checked.ToString(),
                chkTallyUnit.Checked.ToString(),

                cbSelectCompany.SelectedIndex.ToString(),
                cbFinYr.SelectedIndex.ToString(),
                m_lastSyncDate.ToString()
            };

            System.IO.File.WriteAllLines("userdata.txt", lines);
        }

        void btnBrowseAppPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = txtAppPath.Text.Trim();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtAppPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }


        async Task<string> GetTallyMasterXML(int p_Mastertype)
        {
            string TallyServer = txtTallyServer.Text.Trim() + ":" + txtTallyPort.Text.Trim();
            string myErrStr = "";

            // Map master type to master name and tag name
            var masterMap = new Dictionary<int, (string masterName, string tagName)>
            {
                { g_CL.ACC_MAST,  ("Ledger",     "LEDGER") },
                { g_CL.AGRP_MAST, ("Group",      "GROUP") },
                { g_CL.ITEM_MAST, ("StockItem",  "STOCKITEM") },
                { g_CL.IGRP_MAST, ("StockGroup", "STOCKGROUP") },
                { g_CL.UNIT_MAST, ("Unit",       "UNIT") }
            };

            if (!masterMap.TryGetValue(p_Mastertype, out var masterInfo))
                return "";

            string mastername = masterInfo.masterName;
            string tagName = masterInfo.tagName;

            string xmlPayload = g_CL.GetTallyMasterPayload(mastername);
            string responseBody = await g_CL.GetTallyResponseAsync(TallyServer, xmlPayload, myErrStr);

            if (!string.IsNullOrEmpty(responseBody))
            {
                responseBody = g_CL.RemoveJunkChars(responseBody, 1);
                responseBody = g_CL.RemoveJunkChars(responseBody, 2);
                responseBody = g_CL.RemoveJunkChars(responseBody, 3);

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseBody);
                    string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);

                    JObject jsonObject = JObject.Parse(json);

                    JToken masterToken = jsonObject
                        .SelectToken("BODY")?
                        .SelectToken("DATA")?
                        .SelectToken("COLLECTION")?
                        .SelectToken(tagName);

                    JObject result = new JObject();
                    result[tagName.ToLower() + "s"] = masterToken ?? new JObject();
                    return result.ToString(Newtonsoft.Json.Formatting.Indented);
                }
                catch (Exception)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        async Task<string> GetTallyCurrentCompName()
        {
            string TallyServer = txtTallyServer.Text.Trim() + ":" + txtTallyPort.Text.Trim();
            string xmlPayload = g_CL.GetTallyPayLoad(DateTime.Today, DateTime.Today, DateTime.Today);
            string myErrStr = "";

            string responseBody = await g_CL.GetTallyResponseAsync(TallyServer, xmlPayload, myErrStr);
            if (!string.IsNullOrEmpty(responseBody))
            {
                responseBody = g_CL.RemoveJunkChars(responseBody, 1);
                responseBody = g_CL.RemoveJunkChars(responseBody, 2);
                responseBody = g_CL.RemoveJunkChars(responseBody, 3);

                try
                {
                    var xdoc = System.Xml.Linq.XDocument.Parse(responseBody);
                    var element = xdoc.Descendants("SVCURRENTCOMPANY").FirstOrDefault();
                    return element != null ? element.Value : "";
                }
                catch (Exception)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        async void btnRefreshTallyComp_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string companyName = (await GetTallyCurrentCompName()).Replace("&", "&&");
                lblTally.Text = companyName;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }




        private void txtCRMUsername_TextChanged(object sender, EventArgs e)
        {
            UnvalidateCRMCreds();
        }

        void UnvalidateCRMCreds()
        {
            if (m_CRMCredsVerified)
            {
                m_CRMCredsVerified = false;
                lblCRM.ForeColor = System.Drawing.Color.Red;
                lblCRM.Text = "Credentials Not Verified";
            }

        }

        string GetMasterTypeTag(int masterType)
        {
            if (jsonMasters.TryGetValue(masterType, out string tag)) return tag;
            if (qryMasters.TryGetValue(masterType, out tag)) return tag;
            if (xmlMasters.TryGetValue(masterType, out tag)) return tag;
            return null; // or a default string
        }

        private void txtCRMPassword_TextChanged(object sender, EventArgs e)
        {
            UnvalidateCRMCreds();
        }

        private void txtCRMCompCode_TextChanged(object sender, EventArgs e)
        {
            UnvalidateCRMCreds();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        async Task RunMainProcessAsync(CancellationToken token)
        {

            bool proceed = true;
            string errMsg = "";
            Dictionary<int, List<object>> codesByMasterType = new Dictionary<int, List<object>>();
            dynamic rst;
            string outputJson = "";
            string query = "";
            JObject finalJson = new JObject();
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = System.IO.Path.Combine(appPath, "jsonData.txt");
            string masterTypesCsv = "";
            long totalMasters = 0;
            long processedMasters = 0;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (proceed)
                {
                    proceed = ValidateDataB4StartingProcess(ref errMsg);
                    token.ThrowIfCancellationRequested();
                }


                if (rbBusy.Checked)
                {


                    if (proceed)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        //fetching masters count : start -------------------------------------------
                        token.ThrowIfCancellationRequested();
                        lblProgress.Text = "Fetching count of masters...";
                        Application.DoEvents();

                        masterTypesCsv = string.Join(",", checkedMasters);
                        query = "SELECT COUNT(code) FROM MASTER1 WHERE MASTERTYPE IN (" + masterTypesCsv + ")";
                        if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                        {
                            query += " AND CREATIONTIME >= " + g_CL.GetDateQryStr(m_lastSyncDate.Value);
                        }

                        rst = FI.GetRecordset(query);

                        if (rst != null && !rst.EOF)
                        {
                            totalMasters = Convert.ToInt32(rst.Fields[0].Value);
                            rst.Close();
                        }
                        //fetching masters count : end -------------------------------------------



                        //fetching all json masters : start -------------------------------------------
                        token.ThrowIfCancellationRequested();
                        masterTypesCsv = string.Join(
                            ",",
                            checkedMasters.Where(m => jsonMasters.ContainsKey(m))
                        );

                        query = "SELECT CODE, MASTERTYPE FROM MASTER1 WHERE MASTERTYPE IN (" + masterTypesCsv + ") order by mastertype";
                        if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                        {
                            query += " AND CREATIONTIME >= " + g_CL.GetDateQryStr(m_lastSyncDate.Value);
                        }

                        rst = FI.GetRecordset(query);

                        if (rst != null)
                        {
                            while (!rst.EOF)
                            {
                                token.ThrowIfCancellationRequested();
                                int masterType = Convert.ToInt32(rst.Fields["MASTERTYPE"].Value);
                                var code = rst.Fields["CODE"].Value;

                                if (!codesByMasterType.ContainsKey(masterType))
                                    codesByMasterType[masterType] = new List<object>();

                                codesByMasterType[masterType].Add(code);

                                rst.MoveNext();
                            }

                            rst.Close();

                            var groupedJson = new Dictionary<string, List<string>>();

                            foreach (var kvp in codesByMasterType)
                            {
                                token.ThrowIfCancellationRequested();
                                int masterType = kvp.Key;
                                lblProgress.Text = "Fetching " + GetMasterTypeTag(masterType) + "...";
                                List<object> codes = kvp.Value;

                                if (!jsonMasters.TryGetValue(masterType, out string tag))
                                    continue;

                                if (!groupedJson.ContainsKey(tag))
                                    groupedJson[tag] = new List<string>();

                                foreach (var codeObj in codes)
                                {
                                    token.ThrowIfCancellationRequested();
                                    long code = Convert.ToInt64(codeObj);
                                    string json = FI1.GetMastJSON(code);
                                    processedMasters = processedMasters + 1;
                                    lblProgress2.Text = "Masters Processed : " + processedMasters + " out of " + totalMasters + " (" + ((int)Math.Round(processedMasters * 100.0 / totalMasters)).ToString() + "%)";
                                    Application.DoEvents();
                                    groupedJson[tag].Add(json);
                                }
                            }

                            foreach (var kvp in groupedJson)
                            {
                                token.ThrowIfCancellationRequested();
                                string tag = kvp.Key;
                                List<string> jsonStrings = kvp.Value;

                                JArray arr = new JArray();
                                foreach (var jsonStr in jsonStrings)
                                {
                                    arr.Add(JObject.Parse(jsonStr));
                                }
                                finalJson[tag] = arr;
                            }
                        }
                        //fetching all json masters : end -------------------------------------------




                        //fetching all qry masters : start -------------------------------------------
                        token.ThrowIfCancellationRequested();
                        var qryMasterTypes = checkedMasters.Where(m => qryMasters.ContainsKey(m)).ToList();
                        string qryMasterTypesCsv = string.Join(",", qryMasterTypes);

                        if (qryMasterTypes.Count > 0)
                        {
                            lblProgress.Text = "Fetching category and source masters...";
                            Application.DoEvents();

                            query = "select name,mastertype from master1 where mastertype in (" + qryMasterTypesCsv + ") order by mastertype";
                            if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                            {
                                query += " AND CREATIONTIME >= " + g_CL.GetDateQryStr(m_lastSyncDate.Value);
                            }

                            rst = FI.GetRecordset(query);

                            if (rst != null)
                            {
                                var arraysByTag = new Dictionary<string, JArray>();
                                foreach (var masterType in qryMasterTypes)
                                {
                                    token.ThrowIfCancellationRequested();
                                    if (qryMasters.TryGetValue(masterType, out string tag))
                                        arraysByTag[tag] = new JArray();
                                }

                                while (!rst.EOF)
                                {
                                    token.ThrowIfCancellationRequested();
                                    int masterType = Convert.ToInt32(rst.Fields["MASTERTYPE"].Value);
                                    lblProgress.Text = "Processing " + GetMasterTypeTag(masterType) + "...";
                                    Application.DoEvents();
                                    string name = rst.Fields["NAME"].Value?.ToString();

                                    if (qryMasters.TryGetValue(masterType, out string tag) && arraysByTag.ContainsKey(tag))
                                    {
                                        var obj = new JObject { ["name"] = name };
                                        arraysByTag[tag].Add(obj);
                                    }

                                    processedMasters = processedMasters + 1;
                                    lblProgress2.Text = "Masters Processed : " + processedMasters + " out of " + totalMasters + " (" + ((int)Math.Round(processedMasters * 100.0 / totalMasters)).ToString() + "%)";
                                    Application.DoEvents();

                                    rst.MoveNext();
                                }

                                rst.Close();

                                foreach (var kvp in arraysByTag)
                                {
                                    token.ThrowIfCancellationRequested();
                                    if (kvp.Value.Count > 0)
                                        finalJson[kvp.Key] = kvp.Value;
                                }
                            }
                        }
                        //fetching all qry masters : end -------------------------------------------




                        //fetching all xml masters : start -------------------------------------------
                        token.ThrowIfCancellationRequested();
                        if (chkContact.Checked)
                        {
                            lblProgress.Text = "Fetching " + GetMasterTypeTag(g_CL.CONTACT_MAST) + "...";
                            Application.DoEvents();

                            query = "select code from master1 where mastertype in (" + g_CL.CONTACT_MAST + ")";
                            if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                            {
                                query += " AND CREATIONTIME >= " + g_CL.GetDateQryStr(m_lastSyncDate.Value);
                            }

                            rst = FI.GetRecordset(query);

                            if (rst != null)
                            {
                                var contacts = new JArray();

                                while (!rst.EOF)
                                {
                                    token.ThrowIfCancellationRequested();
                                    var code = rst.Fields["CODE"].Value;
                                    string xmlStr = FI.GetMasterXML(code);

                                    if (!string.IsNullOrWhiteSpace(xmlStr))
                                    {
                                        try
                                        {
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(xmlStr);

                                            string jsonText = JsonConvert.SerializeXmlNode(doc.DocumentElement, Newtonsoft.Json.Formatting.None, true);
                                            JObject contactObj = JObject.Parse(jsonText);

                                            contacts.Add(contactObj);
                                        }
                                        catch (Exception ex)
                                        {
                                            // Optionally handle or log XML/JSON conversion errors
                                        }
                                    }

                                    processedMasters = processedMasters + 1;
                                    lblProgress2.Text = "Masters Processed : " + processedMasters + " out of " + totalMasters + " (" + ((int)Math.Round(processedMasters * 100.0 / totalMasters)).ToString() + "%)";
                                    Application.DoEvents();

                                    rst.MoveNext();
                                }

                                rst.Close();

                                if (contacts.Count > 0)
                                    finalJson[GetMasterTypeTag(g_CL.CONTACT_MAST)] = contacts;
                            }
                        }
                        //fetching all xml masters : end -------------------------------------------

                    }
                }
                else
                {

                    if (proceed)
                    {
                        //-------------------------------------------------------
                        token.ThrowIfCancellationRequested();
                        if (chkTallyLedger.Checked)
                        {
                            lblProgress.Text = "Fetching ledgers...";
                            Application.DoEvents();
                            outputJson = await GetTallyMasterXML(g_CL.ACC_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["ledgers"];
                                if (ledgers != null)
                                    finalJson["ledgers"] = ledgers;
                            }
                        }
                        //-------------------------------------------------------

                        //-------------------------------------------------------
                        token.ThrowIfCancellationRequested();
                        if (chkTallyGroup.Checked)
                        {
                            lblProgress.Text = "Fetching groups...";
                            Application.DoEvents();
                            outputJson = await GetTallyMasterXML(g_CL.AGRP_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["groups"];
                                if (ledgers != null)
                                    finalJson["groups"] = ledgers;
                            }
                        }
                        //-------------------------------------------------------

                        //-------------------------------------------------------
                        token.ThrowIfCancellationRequested();
                        if (chkTallyStockItem.Checked)
                        {
                            lblProgress.Text = "Fetching stockitems...";
                            Application.DoEvents();
                            outputJson = await GetTallyMasterXML(g_CL.ITEM_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["stockitems"];
                                if (ledgers != null)
                                    finalJson["stockItems"] = ledgers;
                            }
                        }
                        //-------------------------------------------------------

                        //-------------------------------------------------------
                        token.ThrowIfCancellationRequested();
                        if (chkTallyStockGroup.Checked)
                        {
                            lblProgress.Text = "Fetching stockgroups...";
                            Application.DoEvents();
                            outputJson = await GetTallyMasterXML(g_CL.IGRP_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["stockgroups"];
                                if (ledgers != null)
                                    finalJson["stockGroups"] = ledgers;
                            }
                        }
                        //-------------------------------------------------------


                        //-------------------------------------------------------
                        token.ThrowIfCancellationRequested();
                        if (chkTallyUnit.Checked)
                        {
                            lblProgress.Text = "Fetching units...";
                            Application.DoEvents();
                            outputJson = await GetTallyMasterXML(g_CL.UNIT_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["units"];
                                if (ledgers != null)
                                    finalJson["units"] = ledgers;
                            }
                        }
                        //-------------------------------------------------------

                    }

                }



                //converting data to json: start------------------------
                token.ThrowIfCancellationRequested();
                if (proceed)
                {
                    if (finalJson.HasValues)
                    {
                        lblProgress.Text = "Doing final processing on data...";
                        lblProgress2.Text = "";
                        Application.DoEvents();
                        outputJson = finalJson.ToString(Newtonsoft.Json.Formatting.None);
                    }
                    else
                    {
                        proceed = false;
                        errMsg = "No data found to sync.";
                    }
                }
                //converting data to json: end------------------------



                //call crm api and transfer data------------------------
                token.ThrowIfCancellationRequested();
                if (proceed)
                {
                    lblProgress.Text = "Sending data to CRM...";
                    Application.DoEvents();

                    System.IO.File.WriteAllText(jsonFilePath, outputJson);

                    try
                    {
                        using (var client = new System.Net.Http.HttpClient())
                        using (var form = new System.Net.Http.MultipartFormDataContent())
                        using (var fileStream = System.IO.File.OpenRead(jsonFilePath))
                        {
                            client.DefaultRequestHeaders.Add("X-Source-Software", "Busy");

                            var userIdContent = new System.Net.Http.StringContent(m_UserId.ToString());
                            userIdContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                            {
                                Name = "\"user_id\""
                            };
                            form.Add(userIdContent);

                            var companyIdContent = new System.Net.Http.StringContent(m_CompanyId.ToString());
                            companyIdContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                            {
                                Name = "\"company_id\""
                            };
                            form.Add(companyIdContent);

                            var fileContent = new System.Net.Http.StreamContent(fileStream);
                            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                            {
                                Name = "\"file\"",
                                FileName = $"\"{System.IO.Path.GetFileName(jsonFilePath)}\""
                            };
                            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                            form.Add(fileContent);

                            string apiUrl = g_CL.ReadSetDataAPIURLFromTextFile();

                            var response = client.PostAsync(apiUrl, form).Result;
                            string responseBody = response.Content.ReadAsStringAsync().Result;

                            if (response.IsSuccessStatusCode)
                            {
                                var jsonObj = Newtonsoft.Json.Linq.JObject.Parse(responseBody);

                                bool status = jsonObj.Value<bool>("status");
                                string message = jsonObj.Value<string>("message");
                                var data = jsonObj["data"];

                                if (status)
                                {
                                    // Success logic
                                }
                                else
                                {
                                    proceed = false;
                                    errMsg = message;
                                }
                            }
                            else
                            {
                                proceed = false;
                                errMsg = "Error occurred while transferring data.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        proceed = false;
                        errMsg = ex.Message;
                    }

                    System.IO.File.Delete(jsonFilePath);
                }
                //call crm api and transfer data------------------------



                //------------------------------------------------------
                if (proceed)
                {
                    m_lastSyncDate = DateTime.Now;
                    MessageBox.Show("Data transfer completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(errMsg))
                    {
                        MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //-------------------------------------------------------

            }
            catch (Exception ex)
            {
                string fullMessage = ex.Message;
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    fullMessage += "\nInner Exception: " + inner.Message;
                    inner = inner.InnerException;
                }
                MessageBox.Show(fullMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblProgress.Text = "";
                lblProgress2.Text = "";
                if (rbBusy.Checked) FI.CloseDB();
                g_CL.SetAllControlsEnabled(this, true);
                btnStop.Enabled = false;
                Cursor.Current = Cursors.Default;

            }

        }
    }
}
