using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Specialized;

public partial class HumanResource_TopicEvents_frm_mailingList_voting : System.Web.UI.Page
{
    private class ViewStateKeys
    {
        public const string s_dtselectedEmployeeList = "dt_selectedEmployeeList";
    }


    //protected override void OnInit(EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    //    Response.Cache.SetNoStore();
    //    base.OnInit(e);
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CommonFunctions commonFunctions = new CommonFunctions();
            commonFunctions.g_v_RenderJSArrayWithCliendIds(this, div_allEmpMailingList
                , txt_gridViewSearch, gdv_allEmpMailingList);
            if (!Page.IsPostBack)
            {
                tbl_letterSearch.Rows[0].Visible = false;
                chk_applyChangePwd.Checked = true;
                

                v_load_PersonalInfo_DropDownList();

                g_b_FillDropDownList_employeeName(dd_Employee);
                txt_DOB_Start.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txt_DOB_End.Text = DateTime.Now.ToString("dd/MM/yyyy");
                v_load_TopicsName();
            }

        }
        catch (Exception exception)
        {

            lbl_message.Text = exception.Message;

        }

    }

    private void v_load_TopicsName()
    {
        try
        {

            CommonFunctions commonFunctions = new CommonFunctions();
            commonFunctions.g_b_FillDropDownList(dd_topicsName,
                TableColumnName.T_Web_Topics.TableName,
                TableColumnName.T_Web_Topics.TopicsName,
                TableColumnName.AutoId,
                " WHERE "
                + TableColumnName.T_Web_Topics.TopicsStatus
                + " = "
                + "'N' AND "
                + TableColumnName.Company_autoId1
                + " = '"
                + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                + "'");

        }
        catch (Exception exception)
        {

            lbl_message.Text = exception.Message;

        }
    }

    private void v_load_PersonalInfo_DropDownList()
    {
        #region Load DropDownList

        try
        {

            CommonFunctions commonFunctions = new CommonFunctions();

            commonFunctions.g_b_FillDropDownList(dd_Company, TableColumnName.T_CompanyInfo.TableName,
                TableColumnName.T_CompanyInfo.CompName,
                TableColumnName.AutoId,
                string.Empty);

            commonFunctions.g_b_FillDropDownList(dd_PIN, TableColumnName.T_PersonalInformation.TableName,
                TableColumnName.T_PersonalInformation.PIN,
                TableColumnName.AutoId,
                " WHERE " + TableColumnName.Company_autoId
                + " = "
                + "'"
                + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
                + "'");

            commonFunctions.g_b_FillDropDownList(dd_CardID, TableColumnName.T_PersonalInformation.TableName,
                TableColumnName.T_PersonalInformation.CardId,
                TableColumnName.AutoId,
                " WHERE " + TableColumnName.Company_autoId
                + " = "
                + "'"
                + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
                + "'");

            commonFunctions.g_b_FillDropDownList(dd_Religion,
                "T_Religion",
                "Religion",
                "autoId",
                string.Empty);

            commonFunctions.g_b_FillDropDownList(dd_BloodGroup,
                "T_BloodGroup",
                "BloodGroup",
                "autoId",
                string.Empty);

            commonFunctions.g_b_FillDropDownList(dd_Gender,
                "T_Gender",
                "Gender",
                "autoId",
                string.Empty);

            commonFunctions.g_b_FillDropDownList(dd_Nationality,
                "T_Nationality",
                "Nationality",
                "autoId",
                string.Empty);

            commonFunctions.g_b_FillDropDownList(dd_NationalID, TableColumnName.T_PersonalInformation.TableName,
                TableColumnName.T_PersonalInformation.NationalIdNo,
                TableColumnName.AutoId,
                " WHERE " + TableColumnName.Company_autoId
                + " = "
                + "'"
                + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
                + "'");

            commonFunctions.g_b_FillDropDownList(dd_PlaceOfBirth, TableColumnName.T_PersonalInformation.TableName,
               TableColumnName.T_PersonalInformation.BirthPlace,
               TableColumnName.AutoId,
               " WHERE " + TableColumnName.Company_autoId
               + " = "
               + "'"
               + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
               + "'");

            commonFunctions.g_b_FillDropDownList(dd_MaritalStatus,
                "T_MaritalStatus",
                "MaritalStatus",
                "autoId",
                string.Empty);

            commonFunctions.g_b_FillDropDownList(dd_TIN, TableColumnName.T_PersonalInformation.TableName,
              TableColumnName.T_PersonalInformation.TIN,
              TableColumnName.AutoId,
              " WHERE " + TableColumnName.Company_autoId
              + " = "
              + "'"
              + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
              + "'");

            commonFunctions.g_b_FillDropDownList(dd_DrivingLicense, TableColumnName.T_PersonalInformation.TableName,
              TableColumnName.T_PersonalInformation.DrivingLicense,
              TableColumnName.AutoId,
              " WHERE " + TableColumnName.Company_autoId
              + " = "
              + "'"
              + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
              + "'");

            commonFunctions.g_b_FillDropDownList(dd_PassportNo, TableColumnName.T_PersonalInformation.TableName,
              TableColumnName.T_PersonalInformation.PassportNo,
              TableColumnName.AutoId,
              " WHERE " + TableColumnName.Company_autoId
              + " = "
              + "'"
              + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId])
              + "'");

            commonFunctions.g_b_FillDropDownList(dd_designation,
                TableColumnName.T_Designation.TableName,
                TableColumnName.T_Designation.designation,
                TableColumnName.T_Designation.designation,
                string.Empty);
        }
        catch (Exception exception)
        {

            lbl_message.Text = exception.Message;

        }


        #endregion
    }

    private Boolean g_b_FillDropDownList_employeeName(DropDownList dd_dropDownList)
    {
        try
        {
            Connection connection = new Connection { ResultsDataSet = null, connection = null };
            CommonFunctions commonFunctions = new CommonFunctions();
            string s_dataParam = string.Empty;
            string s_returnValue = string.Empty;
            string s_sqlQuery = string.Empty;
            string s_employeeName = string.Empty;

            s_employeeName = txt_employeeFilter.Text.ToString();
            s_sqlQuery = Procedures.humanResource.Proc_web_select_all_employee_by_company
                + " '"
                + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                + "','"
                + s_employeeName
                + "'";
            s_returnValue = connection.connection_DB(s_sqlQuery, 0, false, false, false);
            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet == null)
                {
                    //lbl_message.Text = "Error in SQL";
                }
                else
                {
                    if (connection.ResultsDataSet == null)
                    {
                        //lbl_message.Text = "No data found";
                    }
                    else
                    {
                        commonFunctions.g_b_FillDropDownList(dd_Employee, connection.ResultsDataSet.Tables[0], "empName", "empAutoId");
                    }
                }
            }
            return true;
        }
        catch (Exception exception)
        {
            lbl_message.Text = exception.Message;
        }
        return false;
    }

    protected void txt_employeeFilter_TextChanged(object sender, EventArgs e)
    {
        g_b_FillDropDownList_employeeName(dd_Employee);
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        #region btn_search

        try
        {

            string s_sql_MailingList = string.Empty;
            string s_Employee = string.Empty;
            string s_data_Param = string.Empty;
            string s_sql_ReturnValue = string.Empty;
            string s_PIN = string.Empty;
            string s_CardID = string.Empty;
            string s_Religion = string.Empty;
            string s_BloodGroup = string.Empty;
            string s_Gender = string.Empty;
            string s_Nationality = string.Empty;
            string s_NationalID = string.Empty;
            string s_PlaceOfBirth = string.Empty;
            string s_MaritalStatus = string.Empty;
            string s_TIN = string.Empty;
            string s_DrivingLicense = string.Empty;
            string s_PassportNo = string.Empty;
            string s_DOB_Start = string.Empty;
            string s_DOB_End = string.Empty;
            int s_AgeBetween_Start = 0;
            int s_AgeBetween_End = 0;

            //string s_company_AutoId = Session[GlobalVariables.g_s_CompanyAutoId].ToString();
            string s_company_AutoId = string.Empty;
            string s_BirthDateUse = chk_Age_Status.Checked ? "Y" : "N";
            string s_ageUse = chk_DOB_Status.Checked ? "Y" : "N";
            string s_designation = string.Empty;
            DataTable dt_selectedEmployeeList = new DataTable();
            buildSelectedEmployeeDataTable();

            if (dd_Employee.SelectedValue == "0")
            {
                s_Employee = "%";
            }
            else
            {
                s_Employee = dd_Employee.SelectedValue + "X%";
            }

            if (dd_Company.SelectedValue == "0")
            {
                s_company_AutoId = "%";
            }
            else
            {
                s_company_AutoId = dd_Company.SelectedValue + "X%";
            }

            if (dd_PIN.SelectedValue == "0")
            {
                s_PIN = "%";
            }
            else
            {
                s_PIN = dd_PIN.SelectedValue + "X%";
            }

            if (dd_PIN.SelectedValue == "0")
            {
                s_PIN = "%";
            }
            else
            {
                s_PIN = dd_PIN.SelectedValue + "X%";
            }

            if (dd_CardID.SelectedValue == "0")
            {
                s_CardID = "%";
            }
            else
            {
                s_CardID = dd_CardID.SelectedValue + "X%";
            }

            if (dd_Religion.SelectedValue == "0")
            {
                s_Religion = "%";
            }
            else
            {
                s_Religion = dd_Religion.SelectedValue + "X%";
            }

            if (dd_BloodGroup.SelectedValue == "0")
            {
                s_BloodGroup = "%";
            }
            else
            {
                s_BloodGroup = dd_BloodGroup.SelectedValue + "X%";
            }

            if (dd_Gender.SelectedValue == "0")
            {
                s_Gender = "%";
            }
            else
            {
                s_Gender = dd_Gender.SelectedValue + "X%";
            }

            if (dd_Nationality.SelectedValue == "0")
            {
                s_Nationality = "%";
            }
            else
            {
                s_Nationality = dd_Nationality.SelectedValue + "X%";
            }

            if (dd_NationalID.SelectedValue == "0")
            {
                s_NationalID = "%";
            }
            else
            {
                s_NationalID = dd_NationalID.SelectedValue + "X%";
            }

            if (dd_PlaceOfBirth.SelectedValue == "0")
            {
                s_PlaceOfBirth = "%";
            }
            else
            {
                s_PlaceOfBirth = dd_PlaceOfBirth.SelectedValue + "X%";
            }

            if (dd_MaritalStatus.SelectedValue == "0")
            {
                s_MaritalStatus = "%";
            }
            else
            {
                s_MaritalStatus = dd_MaritalStatus.SelectedValue + "X%";
            }

            if (dd_TIN.SelectedValue == "0")
            {
                s_TIN = "%";
            }
            else
            {
                s_TIN = dd_TIN.SelectedValue + "X%";
            }

            if (dd_DrivingLicense.SelectedValue == "0")
            {
                s_DrivingLicense = "%";
            }
            else
            {
                s_DrivingLicense = dd_DrivingLicense.SelectedValue + "X%";
            }

            if (dd_PassportNo.SelectedValue == "0")
            {
                s_PassportNo = "%";
            }
            else
            {
                s_PassportNo = dd_PassportNo.SelectedValue + "X%";
            }

            if (txt_DOB_Start.Text == string.Empty)
            {
                s_DOB_Start = "%";
            }
            else
            {
                s_DOB_Start = Convert.ToDateTime(txt_DOB_Start.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy");
            }

            if (txt_DOB_End.Text == string.Empty)
            {
                s_DOB_End = "%";
            }
            else
            {
                s_DOB_End = Convert.ToDateTime(txt_DOB_End.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy");
            }

            if (txt_AgeBetween_Start.Text == string.Empty)
            {
                s_AgeBetween_Start = 0;
            }
            else
            {
                s_AgeBetween_Start = Convert.ToInt32(txt_AgeBetween_Start.Text.Trim());
            }

            if (txt_AgeBetween_End.Text == string.Empty)
            {
                s_AgeBetween_End = 0;
            }
            else
            {
                s_AgeBetween_End = Convert.ToInt32(txt_AgeBetween_End.Text.Trim());
            }

            if (dd_designation.SelectedValue == "0")
            {
                s_designation = string.Empty;
            }
            else
            {
                s_designation = dd_designation.SelectedItem.Text.Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd);
            }
            s_sql_MailingList = Procedures.humanResource.Proc_frm_mailingList_UN_PW_select_employee
                + " '"
                + s_company_AutoId
                + "','"
                + s_PIN
                + "','"
                + s_CardID
                + "','"
                + s_Religion
                + "','"
                + s_BloodGroup
                + "','"
                + s_Gender
                + "','"
                + s_Nationality
                + "','"
                + s_NationalID
                + "','"
                + s_DOB_Start
                + "','"
                + s_DOB_End
                + "','"
                + s_PlaceOfBirth
                + "','"
                + s_MaritalStatus
                + "','"
                + s_TIN
                + "','"
                + s_DrivingLicense
                + "','"
                + s_PassportNo
                + "','"
                + s_BirthDateUse
                + "','"
                + s_AgeBetween_Start
                + "','"
                + s_AgeBetween_End
                + "','"
                + s_ageUse
                + "','"
                + s_Employee
                + "','"
                + s_designation
                + "'";

            Connection connection = new Connection { ResultsDataSet = null, connection = null };
            s_sql_ReturnValue = connection.connection_DB(s_sql_MailingList, 0, false, false, false);
            if (s_sql_ReturnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    gdv_allEmpMailingList.DataSource = connection.ResultsDataSet.Tables[0];
                    gdv_allEmpMailingList.DataBind();
                }
            }
        }
        catch (Exception exception)
        {

            lbl_message.Text = exception.Message;
        }

        #endregion
    }

    private void buildSelectedEmployeeDataTable()
    {
        try
        {

            DataTable dt_selectedEmployeeList = new DataTable();
            dt_selectedEmployeeList.Columns.Add(new DataColumn("empAutoId", typeof(string)));
            dt_selectedEmployeeList.Columns.Add(new DataColumn("PIN", typeof(string)));
            dt_selectedEmployeeList.Columns.Add(new DataColumn("Card_ID", typeof(string)));
            dt_selectedEmployeeList.Columns.Add(new DataColumn("empName", typeof(string)));
            dt_selectedEmployeeList.Columns.Add(new DataColumn("PresentEmailAddress", typeof(string)));
            dt_selectedEmployeeList.Columns.Add(new DataColumn("EmergencyEmailAddress", typeof(string)));
            dt_selectedEmployeeList.Columns.Add(new DataColumn("designation", typeof(string)));
            ViewState[ViewStateKeys.s_dtselectedEmployeeList] = dt_selectedEmployeeList;

        }
        catch (Exception exception)
        {

            lbl_message.Text = exception.Message;
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            Connection connection = new Connection();
            string s_mailMessage = string.Empty;
            string s_htmlBody = string.Empty;
            MailMessage mail = new MailMessage();
            DataTable dt_selectedEmployeeList = (DataTable)ViewState[ViewStateKeys.s_dtselectedEmployeeList];
            mail.Subject = txtSubject.Text.Trim();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["SMTP"];//"202.168.254.21";
            //smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FROMEMAIL"], ConfigurationManager.AppSettings["FROMPWD"]);

            CommonFunctions commonFunctions = new CommonFunctions();
            if (commonFunctions.g_b_emailAddressValidation(Session[GlobalVariables.g_s_userPresentEmail].ToString()))
            {
                mail.From = new MailAddress(Session[GlobalVariables.g_s_userPresentEmail].ToString(), Session[GlobalVariables.g_s_userName].ToString());
            }
            else
            {
                if (commonFunctions.g_b_emailAddressValidation(GlobalVariables.g_s_fromEamilAddress))
                {
                    mail.From = new MailAddress(GlobalVariables.g_s_fromEamilAddress);
                }
            }
            List<string> list_failedEmpAutoId = new List<string>();
            list_failedEmpAutoId.Clear();
            foreach (DataRow dataRow in dt_selectedEmployeeList.Rows)
            {
                string s_currentPwd = string.Empty;
                StringBuilder stringBuilder = new StringBuilder();
                string s_fullName = string.Empty, s_currentUserName = string.Empty;
                string s_selectPwdDataParam = string.Empty;
                string s_returnValue = string.Empty;

                hid_empAutoId.Value = Convert.ToString(dataRow[0]);
                s_selectPwdDataParam = Procedures.humanResource.Proc_web_frm_mailingList_UN_PW_ResetPassowrd 
                                        + " '" 
                                        + Convert.ToString(hid_empAutoId.Value) 
                                        + "'";
                s_returnValue = connection.connection_DB(s_selectPwdDataParam, 0, false, false, false);
                if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                {
                    if (connection.ResultsDataSet != null)
                    {
                        if (connection.ResultsDataSet.Tables != null)
                        {
                            foreach (DataRow DataRowSelcectedEmpAutoId in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                s_currentPwd = DataRowSelcectedEmpAutoId[0].ToString();
                                s_fullName = DataRowSelcectedEmpAutoId[1].ToString();
                                s_currentUserName = DataRowSelcectedEmpAutoId[2].ToString();
                            }

                            mail.To.Clear();
                            mail.To.Add(dataRow[TableColumnName.T_Web_MailingList.PresentEmailAddress].ToString());

                            string s_URL = v_load_URL(dataRow["empAutoId"].ToString());
                            //string en
                            mail.Subject = txtSubject.Text.Trim().ToString();

                            mail.Body = s_bulidMailMessage(s_fullName, s_currentPwd, Convert.ToString(dataRow[0]), s_currentUserName);

                            if (mail.To.Count > 0 && mail.From.Address != string.Empty)
                            {
                                smtp.EnableSsl = true;
                                try
                                {
                                    ServicePointManager.ServerCertificateValidationCallback =
                                        delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                                        {
                                            return true;
                                        };
                                    smtp.Send(mail);
                                    lbl_message.Text = "Mail Sent Successfully";
                                }

                                catch (Exception)
                                {
                                    list_failedEmpAutoId.Add(Convert.ToString(dataRow[0]));
                                }
                            }
                        }
                    }
                }
            }

            if (list_failedEmpAutoId != null)
            {
                if (list_failedEmpAutoId.Count > 0)
                {
                    int i_count = 0;
                    string s_fullName = string.Empty;
                    i_count = list_failedEmpAutoId.Count - 1;
                    lbl_message.Text = "To ";
                    for (int i = 0; i <= i_count; i++)
                    {
                        string s_selectPwdDataParam = string.Empty;
                        hid_empAutoId.Value = Convert.ToString(list_failedEmpAutoId[i]);
                        s_selectPwdDataParam = Procedures.humanResource.Proc_web_frm_mailingList_UN_PW + " '" + Convert.ToString(hid_empAutoId.Value) + "'";
                        connection.connection_DB(s_selectPwdDataParam, 0, false, false, false);

                        foreach (DataRow DataRowSelcectedEmpAutoId in connection.ResultsDataSet.Tables[0].Rows)
                        {
                            s_fullName = DataRowSelcectedEmpAutoId[1].ToString();
                            if (i != i_count)
                            {
                                lbl_message.Text += s_fullName + ',';
                            }
                            else
                            {
                                lbl_message.Text += s_fullName + " mail could not be sent";

                            }
                        }
                    }
                }
            }

            #region Insert

            //string s_returnedValue = string.Empty;
            //string s_procedureParameterValues = string.Empty;

            //CommonFunctions.Date_Validation date_Validation = new CommonFunctions.Date_Validation();
            //sqlConnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings["HR"].ToString()));
            //sqlConnection.Open();
            //sqlCommand = sqlConnection.CreateCommand();
            //sqlTransaction = sqlConnection.BeginTransaction();
            //sqlCommand.Connection = sqlConnection;
            //sqlCommand.Transaction = sqlTransaction;

            //s_procedureParameterValues = " '"
            //    + dd_topicsName.SelectedValue
            //    + "','"
            //    + txtSubject.Text.Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd)
            //    + "','"
            //    + txtMailDescrioption.Text.Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd)
            //    + "','"
            //    + dd_topicsName.SelectedValue
            //    + "','"
            //    + GlobalVariables.g_s_referenceId
            //    + "','"
            //    + GlobalVariables.g_s_No
            //    + "','"
            //    + GlobalVariables.g_s_No
            //    + "','"
            //    + DateTime.Now.ToString(new CultureInfo("en-US"))
            //    + "','"
            //    + Session[GlobalVariables.g_s_userLogBookAutoId].ToString()
            //    + "','"
            //    + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
            //    + "'";

            //sqlCommand.CommandText = Procedures.humanResource.Proc_Web_LetterIssue_For_Voting_Insert
            //    + s_procedureParameterValues;
            //sqlDataReader = sqlCommand.ExecuteReader();
            //sqlDataReader.Read();
            //if (sqlDataReader.FieldCount > 0)
            //{
            //    s_returnedValue = sqlDataReader[0].ToString();
            //    hid_LetterIssueForVoting_AutoId.Value = s_returnedValue;
            //}
            //sqlDataReader.Close();

            //if (s_returnedValue == string.Empty)
            //{
            //    sqlTransaction.Rollback();
            //    lbl_message.Text = GlobalVariables.g_s_insertOperationFailed;
            //    return;
            //}
            //else if (s_returnedValue == "D")
            //{
            //    lbl_message.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
            //    sqlTransaction.Rollback();
            //    return;
            //}
            //else
            //{
            //    foreach (DataRow dataRow in dt_selectedEmployeeList.Rows)
            //    {
            //        string s_received = "N";
            //        s_returnedValue = string.Empty;
            //        s_procedureParameterValues = " '"
            //            + hid_LetterIssueForVoting_AutoId.Value
            //            + "','"
            //            + dataRow["empAutoId"].ToString().Trim()
            //            + "','"
            //            + s_received
            //            + "','"
            //            + hid_LetterIssueForVoting_AutoId.Value
            //            + "','"
            //            + GlobalVariables.g_s_referenceId
            //            + "','"
            //            + GlobalVariables.g_s_No
            //            + "','"
            //            + GlobalVariables.g_s_No
            //            + "','"
            //            + DateTime.Now.ToString(new CultureInfo("en-US"))
            //            + "','"
            //            + Session[GlobalVariables.g_s_userLogBookAutoId].ToString()
            //            + "','"
            //            + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
            //            + "'";

            //        sqlCommand.CommandText = Procedures.humanResource.Proc_Web_LetterIssue_For_Voting_Detail_Insert
            //            + s_procedureParameterValues;
            //        sqlDataReader = sqlCommand.ExecuteReader();
            //        sqlDataReader.Read();
            //        if (sqlDataReader.FieldCount > 0)
            //            s_returnedValue = sqlDataReader[0].ToString();
            //        sqlDataReader.Close();
            //        if (s_returnedValue == string.Empty)
            //        {

            //            lbl_message.Text = GlobalVariables.g_s_insertOperationFailed;
            //            sqlTransaction.Rollback();
            //            return;
            //        }

            //        mail.To.Add(dataRow[TableColumnName.T_Web_MailingList.PresentEmailAddress].ToString());

            //        string s_URL = v_load_URL(dataRow["empAutoId"].ToString());

            //        s_mailMessage = s_buildMessageFinalAproval(dataRow["empName"].ToString(),
            //            txtSubject.Text, txtMailDescrioption.Text,
            //            dd_topicsName.SelectedItem.Text, s_URL,
            //            dt_selectedEmployeeList);

            //        s_htmlBody = "<table bordercolor = '#000000'; bgcolor = '#FFFFFF';><tr><td>"
            //            + Convert.ToString(s_mailMessage)
            //            + "<td><tr></table>";

            //        mail.Body = s_htmlBody;

            //        if (mail.To.Count > 0 && mail.From.Address != string.Empty)
            //        {
            //            smtp.Send(mail);
            //            lbl_message.Text = "Mail Sent successfully";
            //        }
            //        else
            //        {
            //            lbl_message.Text = "Mail Sent Failed ";
            //            sqlTransaction.Rollback();
            //            return;
            //        }

            //    }

            //    if (s_returnedValue == string.Empty)
            //    {
            //        lbl_message.Text = GlobalVariables.g_s_insertOperationFailed;
            //        sqlTransaction.Rollback();
            //        return;
            //    }

            //}

            //sqlTransaction.Commit();

            #endregion End
        }
        catch (Exception exception)
        {

            lbl_message.Text = exception.Message;
        }
        //finally
        //{
        //    sqlConnection.Close();
        //}

        InsertMode();

    }

    private string s_bulidMailMessage(string s_FullName, string s_CurrentPwd, string s_EmpAutoId, string s_CurrentUserName)
    {
        string s_message = string.Empty;
        string s_pageurl = string.Empty;
        string s_appRootDirectory = string.Empty, s_queryString = string.Empty, s_encryptedQueryString = string.Empty;
        if (Request.ApplicationPath == "/")
        {
            s_appRootDirectory = string.Empty;
        }
        else
        {
            s_appRootDirectory = Request.ApplicationPath;
        }
        if (chk_applyChangePwd.Checked == true)
        {
            NameValueCollection nvc_queryStringKeyValue = new NameValueCollection();
            nvc_queryStringKeyValue.Add("empAutoId",s_EmpAutoId);
            nvc_queryStringKeyValue.Add("oldPassword",s_CurrentPwd);
            nvc_queryStringKeyValue.Add("companyAutoId",Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]));

            s_queryString = "empAutoId="
                           + s_EmpAutoId
                           + "&oldPassword="
                           + s_CurrentPwd
                           + "&companyAutoId="
                           + Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

            s_encryptedQueryString = Encryption64.Encrypt(s_queryString, GlobalVariables.g_s_encryptionKey);
            
            //CryptoQueryStringHandler.EncryptQueryStrings(nvc_queryStringKeyValue, "12345678");
            //s_encryptedQueryString = Encryption64.Encrypt("abc12356287491238471298347192847asdkfhasdfj", "12345678");


            s_pageurl = "<a href='http://" + ConfigurationManager.AppSettings["IPADDRESS_PORT"].ToString()
                                           + s_appRootDirectory + "/"
                                           + "HumanResource/Common/frm_changePassword.aspx?"
                                           + HttpUtility.UrlEncode(s_encryptedQueryString)
                                           + "'>Click here to change your password</a>";
        }
        else
        {
            s_pageurl = string.Empty;
        }


        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Dear " + s_FullName + "," + "<br>");
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your current User ID \""
                                    + s_CurrentUserName
                                    + "\" and password \""
                                    + s_CurrentPwd
                                    + "\" for the software HR & Finanace Management System.");

        s_message = "<table bordercolor = '#000000'; bgcolor = '#FFFFFF';><tr><td>"
                        + "<tr>"
                            + "<td>"
                            + "Subject: "
                            + txtSubject.Text.Trim().ToString()
                            + "</td>"
                        + "</tr>"
                        + "<br>"
                        + "<tr>"
                            + "<td>"
                                + "Description: "
                            + "</td>"
                        + "</tr>"

                        + "<tr>"
                            + "<td>"
                                + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                + txtMailDescrioption.Text.Trim().ToString()
                            + "</td>"
                        + "</tr>"
                        + "<br>"
                        + "<tr>"
                            + "<td>"
                                + stringBuilder.ToString()
                            + "</td>"
                        + "</tr>"
                        + "<br>"
                        + "<tr>"
                            + "<td>"
                                + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                + s_pageurl.ToString()
                            + "</td>"
                        + "</tr>"
                    + "</table>";
        return s_message;


    }

    private string v_load_URL(string s_employeeAutoId)
    {
        string URL = string.Empty;

        try
        {
            string s_appRootDirectory = string.Empty;
            string s_pageURL = string.Empty;
            string dataparam = string.Empty;
            string returnValue = string.Empty;
            string s_letterIssuedEmpAutoId = string.Empty;
            string s_letterIssuedEmpUserName = string.Empty;
            string s_letterIssuedEmpPassword = string.Empty;

            dataparam = "SELECT ISNULL([userName],'') AS userName,ISNULL([password],'')"
                + " AS password FROM [T_Web_Login]"
                + " WHERE Active = 'Y' AND empAutoId='"
                + s_employeeAutoId
                + "' AND companyAutoId='"
                + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                + "'";

            Connection connection = new Connection { ResultsDataSet = null, connection = null };
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        s_letterIssuedEmpUserName = dataTable.Rows[0]["userName"].ToString();
                        s_letterIssuedEmpPassword = dataTable.Rows[0]["password"].ToString();
                    }
                }
            }

            if (Request.ApplicationPath == "/")
            {
                s_appRootDirectory = string.Empty;
            }
            else
            {
                s_appRootDirectory = Request.ApplicationPath;
            }

            s_pageURL = "http://" + ConfigurationManager.AppSettings["IPADDRESS_PORT"].ToString()
                + s_appRootDirectory + "/"
                + "HumanResource/TopicEvents/frm_TopicsVotings.aspx?companyAutoId="
                + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                + "@empautoId="
                + s_employeeAutoId
                + "@topicsautoId="
                + dd_topicsName.SelectedValue;

            URL = "<a href='http://" + ConfigurationManager.AppSettings["IPADDRESS_PORT"].ToString()
                + s_appRootDirectory + "/"
                + "HumanResource/Common/frm_login.aspx?empAutoId="
                + s_employeeAutoId
                + "&cId=" + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                + "&userId=" + s_letterIssuedEmpUserName
                + "&userPassword=" + s_letterIssuedEmpPassword
                + "&pageURL=" + s_pageURL
                + "'>Click here to process the request</a>";

            return URL;
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }

        return URL;
    }

    private string s_buildMessageFinalAproval(string toName, string subject, string description,
        string topicsName, string URL, DataTable dt_selectedEmployeeList)
    {
        string s_htmlBody = string.Empty;
        string s_votingType = string.Empty;
        try
        {
            StringBuilder mailMessageBuilder = new StringBuilder();
            StringBuilder sb_empLeaveInfo = new StringBuilder();
            StringBuilder sb_tableFooter = new StringBuilder();

            mailMessageBuilder.AppendLine("Dear " + toName + ",\n");
            mailMessageBuilder.AppendLine();
            mailMessageBuilder.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "
                               + " You are requested to vote at the following link :");
            mailMessageBuilder.AppendLine();
            sb_tableFooter.AppendLine("\n&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + URL);
            sb_tableFooter.AppendLine();
            //sb_tableFooter.AppendLine("\nThank You");

            s_htmlBody = ""
                     + "<table>"
                     + s_buildHtmlFormat(Convert.ToString(mailMessageBuilder))
                     + "</table>"
                     + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                     + "<table border = '1px' bordercolor = '#000000' align='center';>"
                     + s_buildEmpInfoTable(dt_selectedEmployeeList, subject, description, topicsName)
                     + "</table>"
                     + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                     + "<table>" + s_buildHtmlFormat(Convert.ToString(sb_tableFooter))
                     + "</table>";

            return s_htmlBody;
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }

        return s_htmlBody;
    }

    private StringBuilder s_buildEmpInfoTable(DataTable dt_selectedEmployeeList, string subject, string description, string topicsName)
    {
        StringBuilder sb_empLeaveInfo = new StringBuilder();
        CommonFunctions commonFunctions = new CommonFunctions();
        string s_selectLeaveInfo = string.Empty;

        try
        {

            if (dt_selectedEmployeeList == null)
            {
                lbl_message.Text = "Employee leave Information not found";
            }
            else
            {
                foreach (DataRow dataRow in dt_selectedEmployeeList.Rows)
                {
                    sb_empLeaveInfo.Append("<tr>");
                    sb_empLeaveInfo.Append("<td>");
                    sb_empLeaveInfo.Append("Voting Topics");
                    sb_empLeaveInfo.Append("</td>");
                    sb_empLeaveInfo.Append("<td>");
                    sb_empLeaveInfo.Append(subject);
                    sb_empLeaveInfo.Append("</td>");
                    sb_empLeaveInfo.Append("</tr>");

                    sb_empLeaveInfo.Append("<tr>");
                    sb_empLeaveInfo.Append("<td>");
                    sb_empLeaveInfo.Append("Topics Name");
                    sb_empLeaveInfo.Append("</td>");
                    sb_empLeaveInfo.Append("<td>");
                    sb_empLeaveInfo.Append(topicsName);
                    sb_empLeaveInfo.Append("</td>");
                    sb_empLeaveInfo.Append("</tr>");

                    sb_empLeaveInfo.Append("<tr>");
                    sb_empLeaveInfo.Append("<td>");
                    sb_empLeaveInfo.Append("Voting Description");
                    sb_empLeaveInfo.Append("</td>");
                    sb_empLeaveInfo.Append("<td>");
                    sb_empLeaveInfo.Append(description);
                    sb_empLeaveInfo.Append("</td>");
                    sb_empLeaveInfo.Append("</tr>");

                    sb_empLeaveInfo.AppendLine();
                }
            }

            return sb_empLeaveInfo;
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }

        return sb_empLeaveInfo;
    }

    private string s_buildHtmlFormat(string s_mailMessage)
    {
        StringBuilder mailMessageBuilder = new StringBuilder();
        try
        {
            string[] stringSeparators = new string[] { "\n" };
            string[] splitted = s_mailMessage.ToString().Split(stringSeparators, StringSplitOptions.None);

            string perLineString = string.Empty;
            foreach (string s_messageLine in splitted)
            {
                perLineString = s_messageLine;
                mailMessageBuilder.Append("<tr>");
                mailMessageBuilder.Append("<td>");
                mailMessageBuilder.Append(perLineString);
                mailMessageBuilder.Append("<td>");
                mailMessageBuilder.Append("</tr>");
            }
            return Convert.ToString(mailMessageBuilder);
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }

        return Convert.ToString(mailMessageBuilder);
    }

    protected void chk_all_MailList_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_checkedAll = (CheckBox)gdv_allEmpMailingList.HeaderRow.FindControl("chk_all");
            if (chk_checkedAll.Checked == true)
            {
                foreach (GridViewRow gridViewRow in gdv_allEmpMailingList.Rows)
                {
                    CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chk_employee");
                    checkBox.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gridViewRow in gdv_allEmpMailingList.Rows)
                {
                    CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chk_employee");
                    checkBox.Checked = false;
                }
            }
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }
    }

    protected void btn_remove_Click(object sender, EventArgs e)
    {
        try
        {
            if (gdv_selectedList != null)
            {
                DataTable dataTable = (DataTable)(ViewState[ViewStateKeys.s_dtselectedEmployeeList]);
                foreach (GridViewRow gridViewRow in gdv_selectedList.Rows)
                {
                    string s_chk_employee = ((CheckBox)gridViewRow.FindControl("chk_employee")).Checked ? GlobalVariables.g_s_Yes : GlobalVariables.g_s_No;
                    DataRow dataRow = dataTable.NewRow();
                    if (s_chk_employee == GlobalVariables.g_s_Yes)
                    {
                        dataRow = dataTable.Rows[gridViewRow.RowIndex];
                        dataTable.Rows[gridViewRow.RowIndex].Delete();
                        dataTable.AcceptChanges();
                        ViewState[ViewStateKeys.s_dtselectedEmployeeList] = dataTable;
                    }
                }

                gdv_selectedList.DataSource = (DataTable)ViewState[ViewStateKeys.s_dtselectedEmployeeList];
                gdv_selectedList.DataBind();

            }
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }
    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            buildSelectedEmployeeDataTable();
            DataTable dt_selectedEmployeeList = (DataTable)(ViewState[ViewStateKeys.s_dtselectedEmployeeList]);
            foreach (GridViewRow gdv_allEmailList_Row in gdv_allEmpMailingList.Rows)
            {
                string s_chk_employee = ((CheckBox)gdv_allEmailList_Row.FindControl("chk_employee")).Checked ? GlobalVariables.g_s_Yes : GlobalVariables.g_s_No;
                if (s_chk_employee == GlobalVariables.g_s_Yes)
                {
                    if (checkDuplication(dt_selectedEmployeeList, "empAutoId", gdv_allEmailList_Row.Cells[1].Text.Trim()))
                    {
                        dt_selectedEmployeeList.NewRow();
                        dt_selectedEmployeeList.Rows.Add(gdv_allEmailList_Row.Cells[1].Text.Trim().Replace("&nbsp;", string.Empty),
                                                         gdv_allEmailList_Row.Cells[2].Text.Trim().Replace("&nbsp;", string.Empty),
                                                         gdv_allEmailList_Row.Cells[3].Text.Trim().Replace("&nbsp;", string.Empty),
                                                         gdv_allEmailList_Row.Cells[4].Text.Trim().Replace("&nbsp;", string.Empty),
                                                         gdv_allEmailList_Row.Cells[5].Text.Trim().Replace("&nbsp;", string.Empty),
                                                         gdv_allEmailList_Row.Cells[6].Text.Trim().Replace("&nbsp;", string.Empty));

                    }
                }
            }
            gdv_selectedList.DataSource = dt_selectedEmployeeList;
            gdv_selectedList.DataBind();
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }

    }

    private bool checkDuplication(DataTable dataTable, string s_duplicateFieldName, string s_valueTocheck)
    {
        try
        {
            if (dataTable != null)
            {
                DataRow[] count = dataTable.Select(s_duplicateFieldName + " = " + s_valueTocheck);
                if (count.Length > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }
        return false;
    }

    protected void gdv_selectedList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt_selectedEmployeeList = (DataTable)(ViewState[ViewStateKeys.s_dtselectedEmployeeList]);
            dt_selectedEmployeeList.Rows.RemoveAt(e.RowIndex);
            dt_selectedEmployeeList.AcceptChanges();
            gdv_selectedList.DataSource = dt_selectedEmployeeList;
            gdv_selectedList.DataBind();
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }
    }
    protected void chk_all_MailList_Select_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk_checkedAll = (CheckBox)gdv_selectedList.HeaderRow.FindControl("chk_all");
            if (chk_checkedAll.Checked == true)
            {
                foreach (GridViewRow gridViewRow in gdv_selectedList.Rows)
                {
                    CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chk_employee");
                    checkBox.Checked = true;
                }
            }
            else
            {
                foreach (GridViewRow gridViewRow in gdv_selectedList.Rows)
                {
                    CheckBox checkBox = (CheckBox)gridViewRow.FindControl("chk_employee");
                    checkBox.Checked = false;
                }

            }
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }

    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        try
        {
            InsertMode();
            gdv_selectedList.DataSource = null;
            gdv_selectedList.DataBind();
            lbl_message.Text = string.Empty;
            //txtMailDescrioption.Text = string.Empty;
            //txtSubject.Text = string.Empty;
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }
    }

    private void InsertMode()
    {
        try
        {
            hidIsInsertMode.Value = "True";
            txt_AgeBetween_End.Text = string.Empty;
            txt_AgeBetween_Start.Text = string.Empty;
            txtMailDescrioption.Text = string.Empty;
            txt_employeeFilter.Text = string.Empty;
            txtMailDescrioption.Text = string.Empty;
            txtSubject.Text = string.Empty;
            chk_Age_Status.Checked = false;
            chk_DOB_Status.Checked = false;
            chk_applyChangePwd.Checked = true;
            txt_employeeFilter.Focus();

            dd_topicsName.SelectedValue = "0";
            dd_TIN.SelectedValue = "0";
            dd_Religion.SelectedValue = "0";
            dd_PlaceOfBirth.SelectedValue = "0";
            dd_PIN.SelectedValue = "0";
            dd_PassportNo.SelectedValue = "0";
            dd_MaritalStatus.SelectedValue = "0";
            dd_Gender.SelectedValue = "0";
            dd_Employee.SelectedValue = "0";
            dd_DrivingLicense.SelectedValue = "0";
            dd_Company.SelectedValue = "0";
            dd_CardID.SelectedValue = "0";
            dd_BloodGroup.SelectedValue = "0";
            dd_NationalID.SelectedValue = "0";
            dd_Nationality.SelectedValue = "0";
        }
        catch (Exception ex)
        {
            lbl_message.Text = ex.Message;
        }
    }
}
