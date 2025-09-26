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

namespace AlgoSync
{
    public partial class Form1: Form
    {
        const int AGRP_MAST = 1;
        const int ACC_MAST = 2;
        const int CCGRP_MAST = 3;
        const int CC_MAST = 4;
        const int IGRP_MAST = 5;
        const int ITEM_MAST = 6;
        const int CUR_MAST = 7;
        const int UNIT_MAST = 8;
        const int BS_MAST = 9;
        const int MCGRP_MAST = 10;
        const int MC_MAST = 11;
        const int FORM_MAST = 12;
        const int ST_MAST = 13;
        const int PT_MAST = 14;
        const int BOM_MAST = 15;
        const int UNITCON_MAST = 16;
        const int CURCON_MAST = 17;
        const int SN_MAST = 18;
        const int BROKER_MAST = 19;
        const int AUTHOR_MAST = 20;
        const int SERIES_MAST = 21;
        const int TDS_MAST = 22;
        const int PARTY_MAST = 23;
        const int BRANCH_MAST = 24;
        const int TAX_CATEGORY_MAST = 25;
        const int MAST_SERIES_GRP_MAST = 26;
        const int EMPLOYEE_MAST = 27;
        const int EMP_GRP_MAST = 28;
        const int SALARY_COMPONENT_MAST = 29;
        const int DS_MAST = 30;
        const int MS_MAST = 31;
        const int SCHEME_MAST = 32;
        const int EXECUTIVE_MAST = 33;
        const int CONT_GRP_MAST = 34;
        const int CONTACT_MAST = 36;
        const int VCH_SERIES_GRP_MAST = 51;
        const int BILL_REFGRP_MAST = 52;
        const int BATCH_REFGRP_MAST = 53;
        const int ORDER_REFGRP_MAST = 54;
        const int COUNTRY_MAST = 55;
        const int STATE_MAST = 56;
        const int CITY_MAST = 57;
        const int REGION_MAST = 58;
        const int AREA_MAST = 59;
        const int CONT_DEPT_MAST = 60;
        const int CRM_SOURCE_MAST = 61;
        const int CALL_CLOSE_SUB_STATUS_MAST = 62;
        const int NEXT_ACTION_MAST = 63;
        const int SALUTATION_MAST = 64;
        const int CALL_OPEN_SUB_STATUS_MAST = 65;
        const int CALL_CATEGORY_ENQUIRY_MAST = 66;
        const int CALL_CATEGORY_SUPPORT_MAST = 67;
        const int TRADE_MAST = 68;
        const int ITEM_CATEGORY_MAST = 69;
        const int ACC_CATEGORY_MAST = 70;
        const int USER_MAST = 71;
        const int NMCATEGORY_MAST = 101;
        const int FAQ_GRP_ENQUIRY_MAST = 102;
        const int FAQ_GRP_SUPPORT_MAST = 103;

        dynamic FI;
        dynamic FI1;
        List<string> lstCompCodes = new List<string>();
        bool m_CRMCredsVerified = false;
        DateTime? m_lastSyncDate = null;
        List<int> checkedMasters = new List<int>();
        int m_UserId;
        int m_CompanyId;

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

            try
            {
                FI = Activator.CreateInstance(Type.GetTypeFromProgID("Busy2L21.CFixedInterface"));
                FI1 = Activator.CreateInstance(Type.GetTypeFromProgID("Busy2L21.CFixedInterface1"));
            }
            catch(Exception ex)
            {

            }
            

            if (System.IO.File.Exists("userdata.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("userdata.txt");
                 
                txtAppPath.Text = lines[i];i++;
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
                chkAccount.Checked= true;
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
                txtAppPath.Text = DetectBusyPath();

            if (string.IsNullOrWhiteSpace(txtDataPath.Text))
                txtDataPath.Text = GetBusyDataPath(txtAppPath.Text);

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
                gbBusyMasters.Visible= true;
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

            if(rbAccess.Checked)
            {
                btnLoadCompanies.Top=txtDataPath.Top + 30;
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

                FindComboIndex(cbFinYr, lastFinYear);
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
            bool proceed = true;
            string errMsg = "";
            Dictionary<int, string> jsonMasters;
            Dictionary<int, string> xmlMasters;
            Dictionary<int, string> qryMasters;
            Dictionary<int, List<object>> codesByMasterType = new Dictionary<int, List<object>>();
            dynamic rst;
            string outputJson = "";
            string query = "";
            JObject finalJson = new JObject();
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = System.IO.Path.Combine(appPath, "jsonData.txt");
            string masterTypesCsv = "";

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (proceed)
                {
                    proceed = ValidateDataB4StartingProcess(ref errMsg);
                }
               

                if(rbBusy.Checked)
                {
                    

                    if (proceed)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        jsonMasters = new Dictionary<int, string>
                        {
                            { ACC_MAST, "accounts" },
                            { CONT_GRP_MAST, "contactGroups" },
                            { EXECUTIVE_MAST, "executives" },
                            { ITEM_MAST, "items" },
                            { IGRP_MAST, "itemGroups" },
                            { UNIT_MAST, "units" },
                            { AREA_MAST, "areas" },
                            { STATE_MAST, "states" },
                            { COUNTRY_MAST, "countries" },
                            { CONT_DEPT_MAST, "contactDepartments" },
                        };

                        qryMasters = new Dictionary<int, string>
                        {
                            { CALL_CATEGORY_ENQUIRY_MAST, "enquiryCategories" },
                            { CRM_SOURCE_MAST, "enquirySources" },
                            { CALL_CATEGORY_SUPPORT_MAST, "supportCategories" },
                        };

                        xmlMasters = new Dictionary<int, string>
                        {
                            { CONTACT_MAST, "contacts" },
                            { CONT_GRP_MAST, "contactGroups" },
                            { EXECUTIVE_MAST, "executives" },
                            { ITEM_MAST, "items" },
                            { IGRP_MAST, "itemGroups" },
                            { UNIT_MAST, "units" },
                            { AREA_MAST, "areas" },
                            { STATE_MAST, "states" },
                            { COUNTRY_MAST, "countries" },
                            { CONT_DEPT_MAST, "contactDepartments" },
                        };
                        //---------------------------------------------------

                        masterTypesCsv = string.Join(
                            ",",
                            checkedMasters.Where(m => jsonMasters.ContainsKey(m))
                        );
                  
                        query = "SELECT CODE, MASTERTYPE FROM MASTER1 WHERE MASTERTYPE IN (" + masterTypesCsv + ")";
                        if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                        {
                            query += " AND CREATIONTIME >= " + GetDateQryStr(m_lastSyncDate.Value);
                        }

                        rst = FI.GetRecordset(query);

                        if (rst != null)
                        {
                            while (!rst.EOF)
                            {
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
                                int masterType = kvp.Key;
                                List<object> codes = kvp.Value;

                                if (!jsonMasters.TryGetValue(masterType, out string tag))
                                    continue;

                                if (!groupedJson.ContainsKey(tag))
                                    groupedJson[tag] = new List<string>();

                                foreach (var codeObj in codes)
                                {
                                    long code = Convert.ToInt64(codeObj);
                                    string json = FI1.GetMastJSON(code);
                                    groupedJson[tag].Add(json);
                                }
                            }

                            foreach (var kvp in groupedJson)
                            {
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
                        //---------------------------------------------------




                        //logic for source and category masters---------------
                        var qryMasterTypes = checkedMasters.Where(m => qryMasters.ContainsKey(m)).ToList();
                        string qryMasterTypesCsv = string.Join(",", qryMasterTypes);

                        query = "select name,mastertype from master1 where mastertype in (" + qryMasterTypesCsv + ")";
                        if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                        {
                            query += " AND CREATIONTIME >= " + GetDateQryStr(m_lastSyncDate.Value);
                        }

                        rst = FI.GetRecordset(query);

                        if (rst != null)
                        {
                            var arraysByTag = new Dictionary<string, JArray>();
                            foreach (var masterType in qryMasterTypes)
                            {
                                if (qryMasters.TryGetValue(masterType, out string tag))
                                    arraysByTag[tag] = new JArray();
                            }

                            while (!rst.EOF)
                            {
                                int masterType = Convert.ToInt32(rst.Fields["MASTERTYPE"].Value);
                                string name = rst.Fields["NAME"].Value?.ToString();

                                if (qryMasters.TryGetValue(masterType, out string tag) && arraysByTag.ContainsKey(tag))
                                {
                                    var obj = new JObject { ["name"] = name };
                                    arraysByTag[tag].Add(obj);
                                }

                                rst.MoveNext();
                            }

                            rst.Close();

                            foreach (var kvp in arraysByTag)
                            {
                                if (kvp.Value.Count > 0)
                                    finalJson[kvp.Key] = kvp.Value;
                            }
                        }
                        //logic for source and category masters---------------




                        //logic for contact master------------------------------
                        if (chkContact.Checked)
                        {
                            string contactTag = xmlMasters.ContainsKey(CONTACT_MAST) ? xmlMasters[CONTACT_MAST] : "contacts";

                            query = "select code from master1 where mastertype in (" + CONTACT_MAST + ")";
                            if (rbIncremental.Checked && m_lastSyncDate.HasValue)
                            {
                                query += " AND CREATIONTIME >= " + GetDateQryStr(m_lastSyncDate.Value);
                            }

                            rst = FI.GetRecordset(query);

                            if (rst != null)
                            {
                                var contacts = new JArray();

                                while (!rst.EOF)
                                {
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

                                    rst.MoveNext();
                                }

                                rst.Close();

                                if (contacts.Count > 0)
                                    finalJson[contactTag] = contacts;
                            }
                        }
                        //logic for contact master------------------------------

                    }
                }
                else
                {
                     
                    if(proceed)
                    {
                        if(chkTallyLedger.Checked)
                        {
                            outputJson = await GetTallyMasterXML(ACC_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["ledgers"];
                                if (ledgers != null)
                                    finalJson["ledgers"] = ledgers;
                            }
                        }

                        if (chkTallyGroup.Checked)
                        {
                            outputJson = await GetTallyMasterXML(AGRP_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["groups"];
                                if (ledgers != null)
                                    finalJson["groups"] = ledgers;
                            }
                        }

                        if (chkTallyStockItem.Checked)
                        {
                            outputJson = await GetTallyMasterXML(ITEM_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["stockitems"];
                                if (ledgers != null)
                                    finalJson["stockItems"] = ledgers;
                            }
                        }

                        if (chkTallyStockGroup.Checked)
                        {
                            outputJson = await GetTallyMasterXML(IGRP_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["stockgroups"];
                                if (ledgers != null)
                                    finalJson["stockGroups"] = ledgers;
                            }
                        }

                        if (chkTallyUnit.Checked)
                        {
                            outputJson = await GetTallyMasterXML(UNIT_MAST);
                            if (!string.IsNullOrEmpty(outputJson))
                            {
                                JObject ledgerObj = JObject.Parse(outputJson);
                                JToken ledgers = ledgerObj["units"];
                                if (ledgers != null)
                                    finalJson["units"] = ledgers;
                            }
                        }

                    }
                        
                }


                if(proceed)
                {
                    if (finalJson.HasValues)
                    {
                        outputJson = finalJson.ToString(Newtonsoft.Json.Formatting.None);
                    }
                    else
                    {
                        proceed = false;
                        errMsg = "No data found to sync.";
                    }
                }



                //call crm api and transfer data------------------------
                // Code Generated by Sidekick is for learning and experimentation purposes only.
                if (proceed)
                {
                    System.IO.File.WriteAllText(jsonFilePath, outputJson);

                    try
                    {
                        using (var client = new System.Net.Http.HttpClient())
                        using (var form = new System.Net.Http.MultipartFormDataContent())
                        using (var fileStream = System.IO.File.OpenRead(jsonFilePath))
                        {
                            client.DefaultRequestHeaders.Add("X-Source-Software", "Busy");

                            // Add string contents with explicit Content-Disposition
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

                            // Add file content with explicit Content-Disposition and Content-Type
                            var fileContent = new System.Net.Http.StreamContent(fileStream);
                            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                            {
                                Name = "\"file\"",
                                FileName = $"\"{System.IO.Path.GetFileName(jsonFilePath)}\""
                            };
                            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                            form.Add(fileContent);

                            string apiUrl = ReadSetDataAPIURLFromTextFile();

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



                if (proceed) 
                {
                    m_lastSyncDate=DateTime.Now;
                    lblProgress.Text = "";
                    MessageBox.Show("Data transfer completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(!string.IsNullOrWhiteSpace(errMsg))
                    {
                        MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                if(rbBusy.Checked) FI.CloseDB();
                SetAllControlsEnabled(this, true);
                Cursor.Current = Cursors.Default;
            }

        }

        bool ValidateDataB4StartingProcess(ref string p_ErrMsg)
        {
            bool proceed = true;

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
                    p_ErrMsg="Tally company not detected, make sure company is open in tally.";
                }

                if (string.IsNullOrWhiteSpace(txtTallyPort.Text) || string.IsNullOrWhiteSpace(txtTallyServer.Text))
                {
                    proceed = false;
                    p_ErrMsg = "Please specify port and server details.";
                }
            }

            if (proceed)
            {
                if(!m_CRMCredsVerified)
                {
                    proceed = false;
                    p_ErrMsg = "Please verify the AlgoCRM credentials in order to proceed further.";
                }
            }

            if (proceed)
            {
                checkedMasters.Clear();

                if(rbTally.Checked)
                {
                    if (chkTallyLedger.Checked) checkedMasters.Add(ACC_MAST);
                    if (chkTallyGroup.Checked) checkedMasters.Add(AGRP_MAST); 
                    if (chkTallyStockItem.Checked) checkedMasters.Add(ITEM_MAST);
                    if (chkTallyStockGroup.Checked) checkedMasters.Add(IGRP_MAST);
                    if (chkTallyUnit.Checked) checkedMasters.Add(UNIT_MAST);
                }
                else
                { 
                    if (chkAccount.Checked) checkedMasters.Add(ACC_MAST);
                    if (chkContactGroup.Checked) checkedMasters.Add(CONT_GRP_MAST);
                    if (chkExecutive.Checked) checkedMasters.Add(EXECUTIVE_MAST);
                    if (chkItem.Checked) checkedMasters.Add(ITEM_MAST);
                    if (chkItemGroup.Checked) checkedMasters.Add(IGRP_MAST);
                    if (chkUnit.Checked) checkedMasters.Add(UNIT_MAST);
                    if (chkArea.Checked) checkedMasters.Add(AREA_MAST);
                    if (chkState.Checked) checkedMasters.Add(STATE_MAST);
                    if (chkCountry.Checked) checkedMasters.Add(COUNTRY_MAST);
                    if (chkContactDepartment.Checked) checkedMasters.Add(CONT_DEPT_MAST);
                    if (chkContact.Checked) checkedMasters.Add(CONTACT_MAST);
                    if (chkEnqCat.Checked) checkedMasters.Add(CALL_CATEGORY_ENQUIRY_MAST);
                    if (chkEnqSource.Checked) checkedMasters.Add(CRM_SOURCE_MAST);
                    if (chkSupCat.Checked) checkedMasters.Add(CALL_CATEGORY_SUPPORT_MAST);
                }

                if (checkedMasters.Count == 0)
                {
                    proceed = false;
                    p_ErrMsg = "Please select at least one master type to sync.";
                }
   
            }


            if(proceed)
            {
                DialogResult result = MessageBox.Show(
                        "Starting data transfer. Please review all details before proceeding and click Yes to continue.",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if(result != DialogResult.Yes)
                {
                    proceed = false;
                }
            }


            if (proceed)
            {
                Cursor.Current = Cursors.WaitCursor;
                lblProgress.Text = "Data Transfer In Progress... Please wait.";
                SetAllControlsEnabled(this, false);
                lblProgress.Enabled = true;
                Application.DoEvents();

                if (rbBusy.Checked)
                {
                    if (rbAccess.Checked)
                    {
                        proceed = FI.OpenDB(txtAppPath.Text.Trim(), txtDataPath.Text.Trim(), lstCompCodes[cbFinYr.SelectedIndex]);
                    }
                    else
                    {
                        proceed = FI.OpenCSDB(txtAppPath.Text.Trim(), txtServerName.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), lstCompCodes[cbSelectCompany.SelectedIndex]);
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


        private void SetAllControlsEnabled(Control parent, bool enabled)
        {
            foreach (Control c in parent.Controls)
            {
                c.Enabled = enabled;
                if (c.HasChildren)
                {
                    SetAllControlsEnabled(c, enabled);
                }
            }
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
                    string apiUrl = ReadVerifyAPIURLFromTextFile();
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
            DisposeObjectsInEnd();

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

        string GetTallyPayLoad(DateTime p_FromDate, DateTime p_ToDate, DateTime p_CurrDate)
        {
            string payLoad = "";
            payLoad += "<ENVELOPE>";
            payLoad += "<HEADER>";
            payLoad += "<VERSION> 1 </VERSION> ";
            payLoad += "<TALLYREQUEST> Export </TALLYREQUEST>";
            payLoad += "<TYPE> Data </TYPE>";
            payLoad += "<ID> Day Book </ID>";
            payLoad += "</HEADER>";
            payLoad += "<BODY>";
            payLoad += "<DESC>";
            payLoad += "<STATICVARIABLES>";
            payLoad += "<SVEXPORTFORMAT>$$SysName: XML </SVEXPORTFORMAT>";
            payLoad += "<SVFROMDATE >" + p_FromDate.ToString("yyyyMMdd") + "</SVFROMDATE>";
            payLoad += "<SVTODATE >" + p_ToDate.ToString("yyyyMMdd") + "</ SVTODATE >";
            payLoad += "<SVCURRENTDATE >" + p_CurrDate.ToString("yyyyMMdd") + "</SVCURRENTDATE>";
            payLoad += "</STATICVARIABLES >";
            payLoad += "</DESC >";
            payLoad += "</BODY >";
            payLoad += "</ENVELOPE>";

            return payLoad;
        }


        string GetTallyMasterPayload(string p_Master)
        {
            string xmlPayload = "<ENVELOPE><HEADER><VERSION>1</VERSION><TALLYREQUEST>Export</TALLYREQUEST><TYPE>Collection</TYPE><ID>All Masters</ID></HEADER>";
            xmlPayload += "<BODY><DESC><STATICVARIABLES><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT></STATICVARIABLES>";
            xmlPayload += "<TDL><TDLMESSAGE><COLLECTION NAME=\"All Masters\" ISMODIFY=\"No\"><TYPE>" + p_Master +"</TYPE><FETCH>*.*</FETCH></COLLECTION></TDLMESSAGE></TDL>";
            xmlPayload += "</DESC></BODY></ENVELOPE>";

            return xmlPayload;
        }


    
        async Task<string> GetTallyMasterXML(int p_Mastertype)
        {
            string TallyServer = txtTallyServer.Text.Trim() + ":" + txtTallyPort.Text.Trim();
            string myErrStr = "";

            // Map master type to master name and tag name
            var masterMap = new Dictionary<int, (string masterName, string tagName)>
            {
                { ACC_MAST,  ("Ledger",     "LEDGER") },
                { AGRP_MAST, ("Group",      "GROUP") },
                { ITEM_MAST, ("StockItem",  "STOCKITEM") },
                { IGRP_MAST, ("StockGroup", "STOCKGROUP") },
                { UNIT_MAST, ("Unit",       "UNIT") }
            };

            if (!masterMap.TryGetValue(p_Mastertype, out var masterInfo))
                return "";

            string mastername = masterInfo.masterName;
            string tagName = masterInfo.tagName;

            string xmlPayload = GetTallyMasterPayload(mastername);
            string responseBody = await GetTallyResponseAsync(TallyServer, xmlPayload, myErrStr);

            if (!string.IsNullOrEmpty(responseBody))
            {
                responseBody = RemoveJunkChars(responseBody, 1);
                responseBody = RemoveJunkChars(responseBody, 2);
                responseBody = RemoveJunkChars(responseBody, 3);

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
            string xmlPayload = GetTallyPayLoad(DateTime.Today, DateTime.Today, DateTime.Today);
            string myErrStr = "";

            string responseBody = await GetTallyResponseAsync(TallyServer, xmlPayload, myErrStr);
            if (!string.IsNullOrEmpty(responseBody))
            {
                responseBody = RemoveJunkChars(responseBody, 1);
                responseBody = RemoveJunkChars(responseBody, 2);
                responseBody = RemoveJunkChars(responseBody, 3);

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


        string GetQryStr(string p_Str)
        {
            return "'" + p_Str.Replace("'", "''").ToString() + "'";
        }

        string GetDateQryStr(DateTime p_Date)
        {
            return "'" + p_Date.ToString("yyyy-MM-dd") + "'";
        }

        string GetBusyDataPath(string p_BusyPath)
        {
            string filename = "DP.txt";
            string filePath = System.IO.Path.Combine(p_BusyPath, "SYSTEM", filename);
            string tempStr = "";

            if (System.IO.File.Exists(filePath))
            {
                tempStr = System.IO.File.ReadAllText(filePath);
            }

            return tempStr.Trim();
        }

        string DetectBusyPath()
        {
            string busyPath = "";
            for (int i = 3; i <= 26; i++)
            {
                string driveChar = ((char)(64 + i)).ToString();
                if (System.IO.Directory.Exists(driveChar + @":\BusyWin\"))
                {
                    busyPath = driveChar + @":\BusyWin\";
                    break;
                }
            }
            return busyPath;
        }


        void FindComboIndex(ComboBox p_Combo, string p_Str)
        {
            for (int i = 0; i < p_Combo.Items.Count; i++)
            {
                if (string.Compare(p_Combo.Items[i].ToString(), p_Str, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    p_Combo.SelectedIndex = i;
                    break;
                }
            }
        }

        async Task<string> GetTallyResponseAsync(string p_TallyServer, string p_Payload, string p_ErrStr)
        {
            string apiUrl = "http://" + p_TallyServer;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");
                HttpContent content = new StringContent(p_Payload, System.Text.Encoding.UTF8, "application/xml");
                httpClient.Timeout = TimeSpan.FromSeconds(2400);

                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                    if (response.IsSuccessStatusCode)
                    {
                        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                        using (StreamReader sr = new StreamReader(responseStream))
                        {
                            char[] buffer = new char[8192];
                            StringBuilder stringBuilder = new StringBuilder();
                            int bytesRead;
                            do
                            {
                                bytesRead = await sr.ReadAsync(buffer, 0, buffer.Length);
                                if (bytesRead > 0)
                                {
                                    stringBuilder.Append(buffer, 0, bytesRead);
                                }
                            } while (bytesRead > 0);

                            return stringBuilder.ToString();
                        }
                    }
                    else
                    {
                        p_ErrStr = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    p_ErrStr = $"Exception: {ex.Message}";
                    return "";
                }
            }
        }


        string RemoveJunkChars(string p_TallyXML, int p_PartNo)
        {
            if (p_PartNo == 1)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, "&#4;", " ");
                p_TallyXML = ReplaceStr(p_TallyXML, "&quot;", "");
                p_TallyXML = ReplaceStr(p_TallyXML, "&#13;", "");
            }
            else if (p_PartNo == 2)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, "&#10;", " ");
                p_TallyXML = ReplaceStr(p_TallyXML, "\\u0002", " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)9).ToString(), " ");
            }
            else if (p_PartNo == 3)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)2).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)3).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)5).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)26).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, "UDF:", "UDF-");
            }
            else if (p_PartNo == 4)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, "&amp;", "And");
            }
            else if (p_PartNo == 5)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)1).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)4).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)6).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)7).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)8).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)11).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)12).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)14).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)15).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)16).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)17).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)18).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)19).ToString(), " ");
                p_TallyXML = ReplaceStr(p_TallyXML, ((char)20).ToString(), " ");
            }
            else if (p_PartNo == 6)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, "&", "&amp;");
            }
            else if (p_PartNo == 7)
            {
                p_TallyXML = ReplaceStr(p_TallyXML, "<", "(");
                p_TallyXML = ReplaceStr(p_TallyXML, ">", ")");
            }
            return p_TallyXML;
        }

        string ReplaceStr(string p_Payload, string p_FindStr, string p_ReplaceStr)
        {
            try
            {
                string myStr = p_Payload.Replace(p_FindStr, p_ReplaceStr);
                return myStr;
            }
            catch
            {
                return p_Payload;
            }
        }

        void DisposeObjectsInEnd()
        {

            if (FI != null)
            {
                FI.CloseDB();
                Marshal.ReleaseComObject(FI);
                FI = null;
            }

            if (FI1 != null)
            {
                Marshal.ReleaseComObject(FI1);
                FI1 = null;
            }

        }

        string ReadVerifyAPIURLFromTextFile()
        {
            string fileName = "verifyCompanyUrl.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string retval = "";

               
            if (File.Exists(filePath))
            {
                retval = File.ReadAllText(filePath);
            }

            return retval;
        }

        string ReadSetDataAPIURLFromTextFile()
        {
            string fileName = "setDataUrl.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string retval = "";


            if (File.Exists(filePath))
            {
                retval = File.ReadAllText(filePath);
            }

            return retval;
        }

        private void txtCRMUsername_TextChanged(object sender, EventArgs e)
        {
            UnvalidateCRMCreds();
        }

        void UnvalidateCRMCreds()
        {
            if(m_CRMCredsVerified)
            {
                m_CRMCredsVerified = false;
                lblCRM.ForeColor = System.Drawing.Color.Red;
                lblCRM.Text = "Credentials Not Verified";
            }
            
         }

        private void txtCRMPassword_TextChanged(object sender, EventArgs e)
        {
            UnvalidateCRMCreds();
        }

        private void txtCRMCompCode_TextChanged(object sender, EventArgs e)
        {
            UnvalidateCRMCreds();
        }
    }
}
