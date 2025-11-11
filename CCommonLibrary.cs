using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoSync
{
    public static class g_CL
    {
        public const bool DEBUG_MODE = false;

        public const int AGRP_MAST = 1;
        public const int ACC_MAST = 2;
        public const int CCGRP_MAST = 3;
        public const int CC_MAST = 4;
        public const int IGRP_MAST = 5;
        public const int ITEM_MAST = 6;
        public const int CUR_MAST = 7;
        public const int UNIT_MAST = 8;
        public const int BS_MAST = 9;
        public const int MCGRP_MAST = 10;
        public const int MC_MAST = 11;
        public const int FORM_MAST = 12;
        public const int ST_MAST = 13;
        public const int PT_MAST = 14;
        public const int BOM_MAST = 15;
        public const int UNITCON_MAST = 16;
        public const int CURCON_MAST = 17;
        public const int SN_MAST = 18;
        public const int BROKER_MAST = 19;
        public const int AUTHOR_MAST = 20;
        public const int SERIES_MAST = 21;
        public const int TDS_MAST = 22;
        public const int PARTY_MAST = 23;
        public const int BRANCH_MAST = 24;
        public const int TAX_CATEGORY_MAST = 25;
        public const int MAST_SERIES_GRP_MAST = 26;
        public const int EMPLOYEE_MAST = 27;
        public const int EMP_GRP_MAST = 28;
        public const int SALARY_COMPONENT_MAST = 29;
        public const int DS_MAST = 30;
        public const int MS_MAST = 31;
        public const int SCHEME_MAST = 32;
        public const int EXECUTIVE_MAST = 33;
        public const int CONT_GRP_MAST = 34;
        public const int CONTACT_MAST = 36;
        public const int VCH_SERIES_GRP_MAST = 51;
        public const int BILL_REFGRP_MAST = 52;
        public const int BATCH_REFGRP_MAST = 53;
        public const int ORDER_REFGRP_MAST = 54;
        public const int COUNTRY_MAST = 55;
        public const int STATE_MAST = 56;
        public const int CITY_MAST = 57;
        public const int REGION_MAST = 58;
        public const int AREA_MAST = 59;
        public const int CONT_DEPT_MAST = 60;
        public const int CRM_SOURCE_MAST = 61;
        public const int CALL_CLOSE_SUB_STATUS_MAST = 62;
        public const int NEXT_ACTION_MAST = 63;
        public const int SALUTATION_MAST = 64;
        public const int CALL_OPEN_SUB_STATUS_MAST = 65;
        public const int CALL_CATEGORY_ENQUIRY_MAST = 66;
        public const int CALL_CATEGORY_SUPPORT_MAST = 67;
        public const int TRADE_MAST = 68;
        public const int ITEM_CATEGORY_MAST = 69;
        public const int ACC_CATEGORY_MAST = 70;
        public const int USER_MAST = 71;
        public const int NMCATEGORY_MAST = 101;
        public const int FAQ_GRP_ENQUIRY_MAST = 102;
        public const int FAQ_GRP_SUPPORT_MAST = 103;


        public const int AG_SUNDRY_DEBTORS = 116;
        public const int AG_SUNDRY_CREDITORS = 117;

        public static string GetQryStr(string p_Str)
        {
            return "'" + p_Str.Replace("'", "''").ToString() + "'";
        }

        public static string GetDateTimeQryStr(DateTime p_DateTime, bool p_ForAccess)
        {
            if (p_ForAccess)
            {
                // For Access: #MM/dd/yyyy HH:mm:ss#
                return "#" + p_DateTime.ToString("MM/dd/yyyy HH:mm:ss") + "#";
            }
            else
            {
                // For SQL Server: 'yyyy-MM-dd HH:mm:ss'
                return "'" + p_DateTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
        }

        public static string GetBusyDataPath(string p_BusyPath)
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

        public static string DetectBusyPath()
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

        public static string GetTallyPayLoad(DateTime p_FromDate, DateTime p_ToDate, DateTime p_CurrDate)
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

        public static string RemoveJunkChars(string p_TallyXML, int p_PartNo)
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

        public static string ReplaceStr(string p_Payload, string p_FindStr, string p_ReplaceStr)
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


        public static async Task<string> GetTallyResponseAsync(string p_TallyServer, string p_Payload, string p_ErrStr)
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

        public static string GetTallyMasterPayload(string p_Master)
        {
            string xmlPayload = "<ENVELOPE><HEADER><VERSION>1</VERSION><TALLYREQUEST>Export</TALLYREQUEST><TYPE>Collection</TYPE><ID>All Masters</ID></HEADER>";
            xmlPayload += "<BODY><DESC><STATICVARIABLES><SVEXPORTFORMAT>$$SysName:XML</SVEXPORTFORMAT></STATICVARIABLES>";
            xmlPayload += "<TDL><TDLMESSAGE><COLLECTION NAME=\"All Masters\" ISMODIFY=\"No\"><TYPE>" + p_Master + "</TYPE><FETCH>*.*</FETCH></COLLECTION></TDLMESSAGE></TDL>";
            xmlPayload += "</DESC></BODY></ENVELOPE>";

            return xmlPayload;
        }

        public static void SetAllControlsEnabled(Control parent, bool enabled)
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
        public static void FindComboIndex(ComboBox p_Combo, string p_Str)
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

        public static string getVerifyCRMCredsAPIUrl()
        {
            string fileName = "verifyCompanyUrl.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string retval = "";

            if (File.Exists(filePath))
            {
                retval = File.ReadAllText(filePath);
            }
            else
            {
                retval = "https://crm.algofast.in/api/integration/verifyUserCompanyPair";
            }

            return retval;
        }

        public static string getSetDataAPIUrl()
        {
            string fileName = "setDataUrl.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string retval = "";

            if (File.Exists(filePath))
            {
                retval = File.ReadAllText(filePath);
            }
            else
            {
                retval = "https://crm.algofast.in/api/integration/setData";
            }

            return retval;
        }

       
    }
}
