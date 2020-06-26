using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class HumanResource_Common_frm_CreateUser : System.Web.UI.Page
{
    #region
    //private static DataTable dt_gdv_employeeName;
    //private static string s_password;
    //private static string s_confirmPassword;

    //protected override void OnPreRender(EventArgs e)
    //{
    //    #region OnPreRender
    //    //txt_Password.Attributes.Add("value", txt_Password.Text);
    //    //txt_Confirm_Password.Attributes.Add("value", txt_Confirm_Password.Text);
    //    //base.OnPreRender(e);
    //    #endregion OnPreRender
    //}
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commonFunctions = new CommonFunctions();

        commonFunctions.g_v_RenderJSArrayWithCliendIds(this, dd_EmployeeName,
                        txt_PreviousPassword, txt_Password, txt_Confirm_Password, chk_Active,
                        rbl_userStatus, btn_save, btn_refresh, hidIsInsertMode);

        #region

        //s_password = txt_Password.Text;
        //s_confirmPassword = txt_Confirm_Password.Text;

        //if (txt_Password.Text != string.Empty)
        //{
        //    txt_Password.Text = s_password;
        //    txt_Confirm_Password.Text = s_confirmPassword;
        //}
        #endregion

        if (!IsPostBack)
        {
            if (!commonFunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }
            // button key attributes for save and remove button
            btn_save.Attributes.Add(GlobalVariables.g_s_updateAlertKey,
                    GlobalVariables.g_s_updateAlertValue);
            btn_remove.Attributes.Add(GlobalVariables.g_s_updateAlertKey,
                GlobalVariables.g_s_updateAlertValue);

            Session[GlobalVariables.g_s_insertMode] = "0";

            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ge")
            {
                //tbl_createUser.Rows[2].Visible = true;
                txt_emp_filter.Enabled = false;
                dd_EmployeeName.Enabled = false;
                dd_EmployeeName.SelectedValue = Session[GlobalVariables.g_s_userAutoId].ToString();
                rbl_userStatus.Enabled = false;
                chk_Active.Enabled = false;
                btn_remove.Enabled = false;
                v_gridView_Employee(Session[GlobalVariables.g_s_userAutoId].ToString(),
                    Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                g_b_FillDropDownList(dd_EmployeeName, Session[GlobalVariables.g_s_CompanyAutoId].ToString());
            }
            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Sa")
            {
                tbl_createUser.Rows[3].Visible = false;
                v_gridView_Employee(string.Empty, Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                g_b_FillDropDownList(dd_EmployeeName, Session[GlobalVariables.g_s_CompanyAutoId].ToString());

            }
            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ad")
            {
                tbl_createUser.Rows[3].Visible = false;
                rbl_userStatus.Enabled = false;
                v_gridView_Employee(string.Empty,
                    Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                g_b_FillDropDownList(dd_EmployeeName, Session[GlobalVariables.g_s_CompanyAutoId].ToString());
            }
            v_setGridViewStyle(gdv_employeeName);
        }
    }

    private void v_setGridViewStyle(GridView gridView)
    {
        gridView.BackColor = Color.Silver;
        gridView.ForeColor = Color.Black;
        gridView.AlternatingRowStyle.BackColor = Color.Gainsboro;
        gridView.HeaderRow.BackColor = Color.Black;
        gridView.HeaderRow.ForeColor = Color.White;
    }
    private void v_gridView_Employee(string s_employeeAutoId, string s_companyAutoId)
    {
        string s_return_AcknowledgementInfo = string.Empty;

        string s_sql_ProcedureName = Procedures.humanResource.Proc_Forfrm_T_Web_Login_By_SelectEmpID;
        //const string s_sql_TableName = TableColumnName.T_Web_Login.TableName;
        string s_sql_gdv_T_Web_Login = s_sql_ProcedureName
            + "'"
            + s_employeeAutoId
            + "'"
            + ","
            + "'"
            + s_companyAutoId
            + "'";

        Connection connection = new Connection { ResultsDataSet = null };
        connection.connection_DB(s_sql_gdv_T_Web_Login, 0, false, false, false);
        if (s_return_AcknowledgementInfo != GlobalVariables.g_s_connectionErrorReturnValue && connection.ResultsDataSet.Tables[0] != null)
        {
            gdv_employeeName.DataSource = connection.ResultsDataSet.Tables[0];
            gdv_employeeName.DataBind();
        }
    }

    public void g_b_FillDropDownList(DropDownList dd_dropDownList, string companyAutoId)
    {

        try
        {
            Connection connection = new Connection { ResultsDataSet = null, connection = null };
            CommonFunctions commonFunctions = new CommonFunctions();
            string dataparam = string.Empty;
            string returnValue = string.Empty;
            string sql_query = string.Empty;
            string empname = string.Empty;
            empname = txt_emp_filter.Text.Trim();
            sql_query = Procedures.humanResource.Proc_web_select_all_employee_by_company
                        + " '"
                        + companyAutoId
                        + "','"
                        + txt_emp_filter.Text.Trim().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd)
                        + "'";
            returnValue = connection.connection_DB(sql_query, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet == null)
                {
                    lbl_msg.Text = "Error in SQL";
                }
                else
                {
                    if (connection.ResultsDataSet.Tables == null)
                    {
                        lbl_msg.Text = "No Data Found";
                    }
                    else
                    {

                        commonFunctions.g_b_FillDropDownList(dd_dropDownList, connection.ResultsDataSet.Tables[0], "empName", "empAutoId");
                        //dd_dropDownList.AppendDataBoundItems = false;
                        //dd_dropDownList.Items.Add(new ListItem("# Select #", "0"));
                        //dd_dropDownList.DataTextField = "empName";
                        //dd_dropDownList.DataValueField = "empAutoId";
                        //dd_dropDownList.DataSource = connection.ResultsDataSet.Tables[0];
                        //dd_dropDownList.DataBind();
                    }
                }
            }
        }
        catch (Exception exception)
        {
            lbl_msg.Text = exception.Message;
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (b_IsValid())
        {
            Connection connection = new Connection { ResultsDataSet = null };


            string s_Active = chk_Active.Checked ? "Y" : "N";
            string s_SystemAdmin = rbl_userStatus.SelectedValue;
            string s_DeleteUser = "N";
            string s_old_UserPassword = string.Empty;

            #region Update
            if (Session[GlobalVariables.g_s_insertMode].ToString() == "1" && btn_save.Text == "Update")
            {
                try
                {
                    if (txt_userName.Text == string.Empty)
                    {
                        lbl_msg.Text = "UserName cannot be blank";
                        //&& txt_Password.Text != string.Empty

                    }
                    else
                    {
                        #region
                        //Session[GlobalVariables.g_s_TableName] = TableColumnName.T_Web_Login.TableName;

                        //Session[GlobalVariables.g_s_ColumnName] = "" + TableColumnName.T_Web_Login.UserName
                        //    + "Ã" + TableColumnName.T_Web_Login.Active
                        //    + "Ã" + TableColumnName.T_Web_Login.UserStatus
                        //    + "Ã";

                        //Session[GlobalVariables.g_s_Parameter] = "" + txt_userName.Text.Trim().Replace(GlobalVariables.g_s_stringByReplace, GlobalVariables.g_s_stringToReplace)
                        //    + "Ã" + s_Active
                        //    + "Ã" + s_SystemAdmin
                        //    + "Ã";

                        //Session[GlobalVariables.g_s_DuplicateChecking] = "" + TableColumnName.T_Web_Login.UserName
                        //    + " = "
                        //    + "''"
                        //    + txt_userName.Text.Trim().Replace(GlobalVariables.g_s_stringByReplace, GlobalVariables.g_s_stringToReplace)
                        //    + "''"
                        //    + " AND "
                        //    + TableColumnName.AutoId
                        //    + " <> "
                        //    + "''"
                        //    + gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[4].Text.Trim()
                        //    + "''";

                        //string s_sql_Update_T_Web_Login = Procedures.humanResource.Proc_Insert_Update_Select_Independent_Tables5
                        //    + " '"
                        //    + Session[GlobalVariables.g_s_TableName].ToString()
                        //    + "','"
                        //    + Session[GlobalVariables.g_s_ColumnName].ToString()
                        //    + "','"
                        //    + Session[GlobalVariables.g_s_Parameter].ToString()
                        //    + "','"
                        //    + Session[GlobalVariables.g_s_DuplicateChecking].ToString()
                        //    + "','"
                        //    + gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[4].Text.Trim()
                        //    + "','U','R',''";
                        #endregion

                        string s_sql_Update_T_Web_Login = Procedures.humanResource.Proc_web_update_web_user
                            + " '"
                            + rbl_userStatus.SelectedValue
                            + "','"
                            + Session[GlobalVariables.g_s_userStatus].ToString()
                            + "','"
                            + gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[4].Text.Trim()
                            + "','"
                            + txt_userName.Text.Trim().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace)
                            + "','"
                            + s_Active
                            + "','"
                            + txt_Password.Text.Trim()
                            + "','"
                            + txt_Confirm_Password.Text.Trim()
                            + "','"
                            + txt_PreviousPassword.Text.Trim()
                            + "','"
                            + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                            + "'";


                        Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(s_sql_Update_T_Web_Login, 1, true, true, true);
                        if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "opw")
                        {
                            lbl_msg.Text = "Old password was wrong";
                        }
                        else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "pdm")
                        {
                            lbl_msg.Text = "Password didn't match";
                        }
                        else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "d")
                        {
                            lbl_msg.Text = "User already exists";
                        }
                        else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != GlobalVariables.g_s_connectionErrorReturnValue)
                        {
                            Session[GlobalVariables.g_s_userName] = txt_userName.Text;
                            InsertMode();

                            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ge")
                            {
                                v_gridView_Employee(Session[GlobalVariables.g_s_userAutoId].ToString(),
                                    Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                            }
                            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Sa")
                            {
                                v_gridView_Employee(string.Empty, Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                            }
                            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ad")
                            {
                                v_gridView_Employee(string.Empty,
                                    Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                            }
                            lbl_msg.Text = GlobalVariables.g_s_updateOperationSuccessfull;
                        }
                        else
                        {
                            lbl_msg.Text = GlobalVariables.g_s_updateOperationFailed;
                        }
                        //if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "pdm")
                        //{
                        //    lbl_msg.Text = "Password didn't match";
                        //}
                        //else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "opw")
                        //{
                        //    lbl_msg.Text = "Old password was wrong";
                        //}
                    }
                }
                catch (Exception ex)
                {
                    lbl_msg.Text = ex.Message;
                }
            }
            #endregion End Update

            #region Insert
            else
            {
                try
                {

                    if (txt_userName.Text == string.Empty)
                    {
                        lbl_msg.Text = "User name cannot be blank";
                    }
                    else
                    {
                        if (txt_Password.Text == txt_Confirm_Password.Text)
                        {
                            if (dd_EmployeeName.SelectedValue == "0")
                            {
                                lbl_msg.Text = "Select employee";
                            }
                            else
                            {
                                Session[GlobalVariables.g_s_TableName] = TableColumnName.T_Web_Login.TableName;

                                Session[GlobalVariables.g_s_ColumnName] = "";

                                Session[GlobalVariables.g_s_Parameter] = "" + Session[GlobalVariables.g_s_autoId].ToString()
                                    + "Ã" + dd_EmployeeName.SelectedValue.Trim()
                                    + "Ã" + txt_userName.Text.Trim().Replace(GlobalVariables.g_s_stringByReplace, GlobalVariables.g_s_stringToReplace)
                                    + "Ã" + txt_Password.Text
                                    + "Ã" + s_Active.Trim()
                                    + "Ã" + s_SystemAdmin
                                    + "Ã" + s_DeleteUser
                                    + "Ã" + txt_userName.Text.Trim().Replace(GlobalVariables.g_s_stringByReplace, GlobalVariables.g_s_stringToReplace)
                                    + "Ã" + GlobalVariables.g_s_referenceId
                                    + "Ã" + GlobalVariables.g_s_No
                                    + "Ã" + GlobalVariables.g_s_No
                                    + "Ã" + DateTime.Now.ToShortDateString().Trim()
                                    + "Ã" + Session[GlobalVariables.g_s_userLogBookAutoId].ToString().Trim()
                                    + "Ã" + Session[GlobalVariables.g_s_CompanyAutoId].ToString();

                                Session[GlobalVariables.g_s_DuplicateChecking] = "" + TableColumnName.T_Web_Login.UserName
                                    + " = "
                                    + "''"
                                    + txt_userName.Text.Trim().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace)
                                    + "''"
                                    + " OR "
                                    + TableColumnName.T_Web_Login.Employee_AutoId
                                    + " = "
                                    + "''"
                                    + dd_EmployeeName.SelectedValue.Trim()
                                    + "''";

                                string s_sql_Insert_T_Web_Login = Procedures.humanResource.Proc_Insert_Update_Select_Independent_Tables5
                                    + " '"
                                    + Session[GlobalVariables.g_s_TableName].ToString()
                                    + "','"
                                    + Session[GlobalVariables.g_s_ColumnName].ToString()
                                    + "','"
                                    + Session[GlobalVariables.g_s_Parameter].ToString()
                                    + "','"
                                    + Session[GlobalVariables.g_s_DuplicateChecking].ToString()
                                    + "','','I','R',''";

                                Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(s_sql_Insert_T_Web_Login, 1, true, true, true);
                                if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != string.Empty && Session[GlobalVariables.g_s_procedureReturnType].ToString() != "D")
                                {
                                    InsertMode();
                                    if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ge")
                                    {
                                        v_gridView_Employee(Session[GlobalVariables.g_s_userAutoId].ToString(),
                                            Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                                    }
                                    if (Session[GlobalVariables.g_s_userStatus].ToString() == "Sa")
                                    {
                                        v_gridView_Employee(string.Empty,
                                            Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                                    }
                                    if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ad")
                                    {
                                        v_gridView_Employee(string.Empty,
                                            Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                                    }
                                    lbl_msg.Text = GlobalVariables.g_s_insertOperationSuccessfull;
                                }
                                else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == GlobalVariables.g_s_procedureDuplicateReturnValue)
                                {
                                    lbl_msg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                                }
                                else
                                {
                                    lbl_msg.Text = GlobalVariables.g_s_insertOperationFailed;
                                }
                            }
                        }
                        else
                        {
                            lbl_msg.Text = "Password didn't match";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_msg.Text = ex.Message;
                }
            }
            #endregion End Insert
        }
        else
        {
            lbl_msg.Text = "Error in control " + Session[GlobalVariables.g_s_serverValidationErrorControlId].ToString();
        }
    }

    private void InsertMode()
    {
        hidIsInsertMode.Value = "True";
        txt_userName.Text = String.Empty;
        txt_Password.Text = String.Empty;
        gdv_employeeName.SelectedIndex = -1;
        dd_EmployeeName.SelectedValue = "0";
        btn_save.Text = "Save";
        lbl_msg.Text = String.Empty;
        Session[GlobalVariables.g_s_insertMode] = "0";
        chk_Active.Checked = false;
        rbl_userStatus.SelectedValue = "Ge";
        dd_EmployeeName.Focus();
    }

    private bool b_IsValid()
    {
        return true;
    }
    protected void btn_remove_Click(object sender, EventArgs e)
    {
        if (gdv_employeeName.SelectedIndex == -1)
        {
            lbl_msg.Text = "Select employee form grid";
        }
        else
        {
            if (Session[GlobalVariables.g_s_insertMode].ToString() == "1")
            {
                Connection connection = new Connection { ResultsDataSet = null };

                string returnReferenceTable = string.Empty;
                const string s_sql_procedurename = Procedures.Common.Proc_Insert_Update_Delete_Select_Independent_Tables1;
                const string s_sql_tableName = TableColumnName.T_Web_Login.TableName;
                string s_user_AutoId = hid_employee_AutoId.Value.Trim();

                string s_sql_Delete_T_Web_Login = s_sql_procedurename
                                                 + "'"
                                                 + s_sql_tableName
                                                 + "','','','','"
                                                 + gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[4].Text.Trim()
                                                 + "','D','R',''";

                returnReferenceTable = connection.connection_DB(s_sql_Delete_T_Web_Login, 1, true, true, true);
                if (returnReferenceTable == "0")
                {
                    InsertMode();
                    if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ge")
                    {
                        v_gridView_Employee(Session[GlobalVariables.g_s_userAutoId].ToString(),
                            Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                    }
                    if (Session[GlobalVariables.g_s_userStatus].ToString() == "Sa")
                    {
                        v_gridView_Employee(string.Empty, string.Empty);
                    }
                    if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ad")
                    {
                        v_gridView_Employee(string.Empty,
                            Session[GlobalVariables.g_s_CompanyAutoId].ToString());
                    }
                    lbl_msg.Text = GlobalVariables.g_s_deleteOperationSuccessfull;
                }
                else
                {
                    returnReferenceTable = GlobalVariables.g_s_procedureDuplicateReturnValue.Substring(2);
                    lbl_msg.Text = GlobalVariables.g_s_deleteOperationFailed + returnReferenceTable;
                }
            }
        }
    }
    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
    }

    protected void gdv_employeeName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
            e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(gdv_employeeName, "Select$" + e.Row.RowIndex);
        }
    }
    protected void gdv_employeeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Connection connection = new Connection { ResultsDataSet = null };
        // Change status of insert to update
        Session[GlobalVariables.g_s_insertMode] = "1";
        //dd_EmployeeName.Enabled = false;
        lbl_msg.Text = string.Empty;
        hidIsInsertMode.Value = "False";
        btn_save.Text = "Update";
        txt_userName.Text = gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[3].Text;
        hid_employee_AutoId.Value = gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[1].Text;
        hid_LogIn_AutoId.Value = gdv_employeeName.Rows[gdv_employeeName.SelectedIndex].Cells[2].Text;
        //
        if (dd_EmployeeName.Items.FindByValue(hid_employee_AutoId.Value) == null) { }
        else
        {
            dd_EmployeeName.SelectedValue = hid_employee_AutoId.Value;
        }

        string dataParam = "SELECT Active, userStatus"
            + " FROM "
            + "T_Web_Login WHERE empAutoId = "
            + hid_employee_AutoId.Value;

        string s_procedureReturnValue = connection.connection_DB(dataParam, 0, false, false, false);
        if (s_procedureReturnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (connection.ResultsDataSet.Tables != null)
            {
                string s_active = string.Empty;
                string s_userStatus = string.Empty;
                foreach (DataRow datarow in connection.ResultsDataSet.Tables[0].Rows)
                {
                    s_active = Convert.ToString(datarow["Active"]);
                    s_userStatus = Convert.ToString(datarow["userStatus"]);
                }
                if (s_active == "Y")
                {
                    chk_Active.Checked = true;
                }
                else
                {
                    chk_Active.Checked = false;
                }
                rbl_userStatus.SelectedValue = s_userStatus;

            }
        }
    }
    protected void txt_emp_filter_TextChanged(object sender, EventArgs e)
    {
        g_b_FillDropDownList(dd_EmployeeName, Session[GlobalVariables.g_s_CompanyAutoId].ToString());
        dd_EmployeeName.Focus();
    }
}

