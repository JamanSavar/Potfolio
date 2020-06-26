/// <summary>
///  Purpuse: for common 1 column or 2 column table
///  Form Name : frm_commonForm.aspx
///  Menu Caption : 
///  Created By : Md. Fahim Bhuyan
///  Designed By :  Md. Fahim Bhuyan
///  programmed By:  Md. Fahim Bhuyan
///  Tested By :  Md. Fahim Bhuyan
///  Date of Creation :26/08/2010
///  Date of Last Modification :05/09/2010
///  Master Table Name : ""
/// </summary>

using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.IO;
using System.Web;

public partial class Forms_Accounts_frm_common_form : System.Web.UI.Page
{
    //for security implementation
    //private string s_formName = string.Empty;
    //private string s_Insert = string.Empty;
    //private string s_update = string.Empty;
    //private string s_delete = string.Empty;
    //private static List<string> l_access_status = new List<string>(5);
    //private DataTable dtbl = new DataTable();

    //private string s_tableName = string.Empty;
    //private List<string> s_labelName = new List<string>(5);
    //private List<string> s_columnName = new List<string>(4);
    //private List<string> s_duplicateCheck = new List<string>(4);
    //private List<string> s_dataValidation = new List<string>(4);
    //private List<string> s_variableType = new List<string>(4);
    //private List<string> s_visible = new List<string>(4);
    //private List<string> s_mustValidation = new List<string>(4);

    protected override void OnPreInit(EventArgs e)
    {
        if (Request.QueryString["check"] == "Y")
            this.MasterPageFile = "~/Forms/Accounts/frm_masterpage_modal.master";
        base.OnPreInit(e);
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
        txt_1stColumn.Focus();
        CommonFunctions commonFunctions = new CommonFunctions();
     

        if (!IsPostBack)
        {
            if (!commonFunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }
            if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ge")
            {
                Response.Redirect(GlobalVariables.g_s_URL_permissionDenied);
            }
            //if (Session[GlobalVariables.g_s_userStatus].ToString() == "Sa")
            //{
               
            //}
            //if (Session[GlobalVariables.g_s_userStatus].ToString() == "Ad")
            //{
              
            //}

            //addEmptyReference();
            List<string> s_labelName = new List<string>(5);
            s_labelName.Clear();

            List<string> s_columnName = new List<string>(4);
            s_columnName.Clear();

            List<string> s_duplicateCheck = new List<string>(4);
            s_duplicateCheck.Clear();

            List<string> s_dataValidation = new List<string>(4);
            s_dataValidation.Clear();

            List<string> s_variableType = new List<string>(4);
            s_variableType.Clear();

            List<string> s_visible = new List<string>(4);
            s_visible.Clear();

            List<string> s_mustValidation = new List<string>(4);
            s_mustValidation.Clear();

            List<string> l_access_status = new List<string>(5);
            l_access_status.Clear();

            s_labelName.Add(Request.QueryString["l1"]);
            s_labelName.Add(Request.QueryString["l2"]);
            s_labelName.Add(Request.QueryString["l3"]);
            s_labelName.Add(Request.QueryString["l4"]);

            P_Header_Leavel.InnerText = Request.QueryString["l1"].ToString();



            s_columnName.Add(Request.QueryString["col1"]);
            s_columnName.Add(Request.QueryString["col2"]);
            s_columnName.Add(Request.QueryString["col3"]);
            s_columnName.Add(Request.QueryString["col4"]);
            s_columnName.Add(Request.QueryString["col5"]);

            s_duplicateCheck.Add(Request.QueryString["Dup1"]);
            s_duplicateCheck.Add(Request.QueryString["Dup2"]);
            s_duplicateCheck.Add(Request.QueryString["Dup3"]);
            s_duplicateCheck.Add(Request.QueryString["Dup4"]);

            s_dataValidation.Add(Request.QueryString["D1"]);
            s_dataValidation.Add(Request.QueryString["D2"]);
            s_dataValidation.Add(Request.QueryString["D3"]);
            s_dataValidation.Add(Request.QueryString["D4"]);

            s_mustValidation.Add(Request.QueryString["M1"]);
            s_mustValidation.Add(Request.QueryString["M2"]);
            s_mustValidation.Add(Request.QueryString["M3"]);
            s_mustValidation.Add(Request.QueryString["M4"]);

            s_variableType.Add("Y");
            s_variableType.Add("Y");
            s_variableType.Add("Y");
            s_variableType.Add("Y");

            s_visible.Add(Request.QueryString["v1"]);
            s_visible.Add(Request.QueryString["v2"]);
            s_visible.Add(Request.QueryString["v3"]);
            s_visible.Add(Request.QueryString["v4"]);
            s_visible.Add(Request.QueryString["v5"]);

            if (s_visible[0] == "Y" && s_mustValidation[0] == "N")
            {
                mustValidate_1stColumn.Enabled = false;
            }

            if (s_visible[1] == "Y" && s_mustValidation[1] == "N")
            {
                mustValidate_2stColumn.Enabled = false;
            }

            if (s_visible[2] == "Y" && s_mustValidation[2] == "N")
            {
                mustValidate_txt_code.Enabled = false;
            }

            if (s_visible[3] == "Y" && s_mustValidation[3] == "N")
            {
                mustValidate_txt_serialNo.Enabled = false;
            }

            commonFunctions.g_v_RenderJSArrayWithCliendIds(this, txt_1stColumn, txt_2stColumn, txt_code, txt_serialNo, chk_active);

            if (s_visible[0] == "Y")
            {
                //Label1.Text = v_defColumnHeader(s_columnName[0]) + ":";
                Label1.Text = s_labelName[0];
            }


            if (s_visible[1] == "Y")
            {
                //Label2.Text = v_defColumnHeader(s_columnName[1]) + ":";
                Label2.Text = s_labelName[1];
            }
            if (s_visible[2] == "Y")
            {
                //Label3.Text = v_defColumnHeader(s_columnName[2]) + ":";
                Label3.Text = s_labelName[2];
            }

            if (s_visible[3] == "Y")
            {
                //Label4.Text = v_defColumnHeader(s_columnName[3]) + ":";
                Label4.Text = s_labelName[3];
            }

            if (s_visible[0] == "N")
            {
                tbl_commonForm.Rows[0].Visible = false;
            }
            if (s_visible[1] == "N")
            {
                tbl_commonForm.Rows[1].Visible = false;
            }
            if (s_visible[2] == "N")
            {
                tbl_commonForm.Rows[2].Visible = false;
            }
            if (s_visible[3] == "N")
            {
                tbl_commonForm.Rows[3].Visible = false;

            }

            #region Security Portion

            //if (Session["Isvalid"] == null)
            //{
            //    Response.Redirect("~/Forms/Common/Security/login.aspx");
            //}
            //if (Session["Isvalid"] != "true")
            //{
            //    Response.Redirect("~/Forms/Common/Security/login.aspx");
            //}

            #endregion
            #region Security Implementation by user


            Session[GlobalVariables.g_s_TableName] = "_" + Request.QueryString["tableName"];
            if (Session[GlobalVariables.g_s_TableName].ToString() 
                == "_" + TableColumnName.T_Web_PerformanceTabDescription.TableName)
            {
                txt_1stColumn.ReadOnly = true;
            }

            hid_s_formName.Value = Path.GetFileName(Request.PhysicalPath).Replace(".aspx", "").Trim().ToString() + Session[GlobalVariables.g_s_TableName].ToString();
            //l_access_status = commonFunctions.g_s_retrunStatus(s_formName);
            l_access_status.Add("Y");
            l_access_status.Add("Y");
            l_access_status.Add("Y");
            #endregion

            string data_for_b1 = string.Empty, data_for_b2 = string.Empty, data_for_b3 = string.Empty, data_for_b4 = string.Empty, data_for_b5 = string.Empty, data_for_b6 = string.Empty;
            data_for_b1 = "autoId";
            data_for_b2 = s_columnName[0];
            data_for_b3 = s_columnName[1];
            data_for_b4 = s_columnName[2];
            data_for_b5 = s_columnName[3];
            data_for_b6 = s_columnName[4];
            ViewState[ViewStateKeys.S_labelName] = s_labelName;
            ViewState[ViewStateKeys.S_columnName] = s_columnName;
            ViewState[ViewStateKeys.S_duplicateCheck] = s_duplicateCheck;
            ViewState[ViewStateKeys.S_dataValidation] = s_dataValidation;
            ViewState[ViewStateKeys.S_variableType] = s_variableType;
            ViewState[ViewStateKeys.S_visible] = s_visible;
            ViewState[ViewStateKeys.S_mustValidation] = s_mustValidation;
            ViewState[ViewStateKeys.V_l_access_status] = l_access_status;
            v_createBoundField(data_for_b1, data_for_b2, data_for_b3, data_for_b4, data_for_b5, data_for_b6);
            Session[GlobalVariables.g_s_insertMode] = "0";
            v_loadGridView();

        }

    }

    private class ViewStateKeys
    {
        private ViewStateKeys()
        { }

        public const string S_labelName = "S_labelName";
        public const string S_columnName = "S_columnName";
        public const string S_duplicateCheck = "S_duplicateCheck";
        public const string S_dataValidation = "S_dataValidation";
        public const string S_variableType = "S_variableType";
        public const string S_visible = "S_visible";
        public const string S_mustValidation = "S_mustValidation";
        public const string V_l_access_status = "V_l_access_status";
        
    }

    private string v_defColumnHeader( string s_colName)
    
    {
        string old_value = string.Empty;
        old_value = s_colName.Substring(0, 1);
        string new_value = string.Empty;
        new_value = s_colName.Substring(0, 1).ToUpper();
        return s_colName.Replace(old_value,new_value).Replace("_", " ");
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        List<string> s_columnName = new List<string>(4);
        s_columnName = (List<string>)ViewState[ViewStateKeys.S_columnName];

        List<string> l_access_status = new List<string>(4);
        l_access_status = (List<string>)ViewState[ViewStateKeys.V_l_access_status];

        CommonFunctions.Date_Validation dataValidation = new CommonFunctions.Date_Validation();

        Connection connection = new Connection();

        if (b_biult_mustValidation() == false) { return; }
        if (s_biult_NumericValidation() == false) { return; }

        Session[GlobalVariables.g_s_TableName] = Request.QueryString["tableName"];
        try
        {

            string s_checkField_forDuplicateValue = string.Empty;

            s_checkField_forDuplicateValue = s_columnName[0];
            string s_activeValue = string.Empty;

            if (chk_active.Checked == true)
            {
                s_activeValue = "Y";
            }

            else
            {
                s_activeValue = "N";
            }

            if (Convert.ToString(Session[GlobalVariables.g_s_insertMode]) == "1" && l_access_status[1] == "Y")
            {
                Session[GlobalVariables.g_s_ColumnName] = s_biult_ColumnName();
                Session[GlobalVariables.g_s_Parameter] = s_biult_Parameter()
                                                 + s_activeValue + "Ã"
                                                 + txt_1stColumn.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "Ã";

                Session[GlobalVariables.g_s_DuplicateChecking] = "(" + s_biult_DuplicateChecking()
                                                           + ") AND " + "autoId"
                                                           + "<>" + "''" + gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[0].Text + "''";


                string sql_Update = Procedures.Common.Proc_Insert_Update_Select_Independent_Tables5
                        + " '"
                        + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_TableName].ToString()) 
                        + "','"
                        + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_ColumnName].ToString())
                        + "','"
                        + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_Parameter].ToString())
                        + "','"
                        + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_DuplicateChecking].ToString())
                        + "','"
                        + HttpUtility.HtmlDecode(gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[0].Text)
                        + "','U','R',''";
                Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(sql_Update, 1, true, true, true);

                if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != string.Empty && Session[GlobalVariables.g_s_procedureReturnType].ToString() != "D")
                {

                    v_loadGridView();
                    //insertMode();
                    btn_refresh_Click(new object(), new EventArgs());
                    lblMsg.Text = GlobalVariables.g_s_updateOperationSuccessfull;


                }
                else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "D")
                {

                    lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;

                }
                else
                {
                    lblMsg.Text = GlobalVariables.g_s_updateOperationFailed;
                }

            }

            else
            {
                if (Convert.ToString(Session[GlobalVariables.g_s_insertMode]) == "1" && l_access_status[1] == "N")
                {
                    lblMsg.Text = string.Empty;
                    lblMsg.Visible = true;
                    lblMsg.Text = GlobalVariables.g_s_updateSecurityMessage;
                }

                if (b_checkAttributeRatings())
                {
                    string sql_save = string.Empty;
                    if (Convert.ToString(Session[GlobalVariables.g_s_insertMode]) == "0" && l_access_status[0] == "Y")
                    {
                        if (Session[GlobalVariables.g_s_TableName].ToString() == TableColumnName.T_Web_PerformanceTabDescription.TableName)
                        {
                            lblMsg.Text = "Please select from grid";
                        }
                        else
                        {
                            Session[GlobalVariables.g_s_ColumnName] = "";
                            Session[GlobalVariables.g_s_Parameter] = "" + Session[GlobalVariables.g_s_autoId].ToString() + "Ã"
                                                               + s_biult_Parameter()
                                                               + txt_1stColumn.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "Ã"
                                                               + GlobalVariables.g_s_referenceId + "Ã"
                                                               + Session[GlobalVariables.g_s_CompanyAutoId].ToString() + "Ã"
                                                               + GlobalVariables.g_s_No + "Ã"
                                                               + GlobalVariables.g_s_No + "Ã"
                                                               + dataValidation.date_Format_Back_End(dataValidation.date_Format_Front_End(DateTime.Today)) + "Ã"
                                                               + Session[GlobalVariables.g_s_userLogBookAutoId].ToString();

                            Session[GlobalVariables.g_s_DuplicateChecking] = "" + s_biult_DuplicateChecking();

                            sql_save = Procedures.Common.Proc_Insert_Update_Select_Independent_Tables5
                            + " '"
                            + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_TableName].ToString())
                            + "','"
                            + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_ColumnName].ToString())
                            + "','"
                            + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_Parameter].ToString())
                            + "','"
                            + HttpUtility.HtmlDecode(Session[GlobalVariables.g_s_DuplicateChecking].ToString())
                            + "','','I','R',''";

                            Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(sql_save, 1, true, true, true);
                            if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != string.Empty && Session[GlobalVariables.g_s_procedureReturnType].ToString() != "D")
                            {

                                v_loadGridView();
                                insertMode();
                                lblMsg.Text = GlobalVariables.g_s_insertOperationSuccessfull;


                            }
                            else if (Session[GlobalVariables.g_s_procedureReturnType].ToString() == "D")
                            {

                                lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;

                            }
                            else
                            {
                                lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                            }

                        }

                        if (Convert.ToString(Session[GlobalVariables.g_s_insertMode]) == "0" && l_access_status[0] == "N")
                        {
                            lblMsg.Text = string.Empty;
                            lblMsg.Visible = true;
                            lblMsg.Text = GlobalVariables.g_s_insertSecurityMessage;
                        }
                    }

                }

                else
                {
                    lblMsg.Text = GlobalVariables.g_s_attributeRatingCheck;
                }
            }
        }
        catch (Exception)
        {

        }
    }

    private bool b_checkAttributeRatings()
    {

        try
        {

            Connection connection = new Connection();

            List<string> s_columnName = new List<string>(4);
            s_columnName = (List<string>)ViewState[ViewStateKeys.S_columnName];

            bool b_chkValue = false;
            if (TableColumnName.T_Web_AttributesRaitings.TableName == Request.QueryString["tableName"])
            {
                string s_return_Value = string.Empty, s_sql_DataParamn = string.Empty;
                //s_sql_DataParamn = Procedures.humanResource.Proc_T_Web_AttributesRaitings_By_Select_Count;
                s_sql_DataParamn = "SELECT * FROM " + TableColumnName.T_Web_AttributesRaitings.TableName;
                connection.connection_DB(s_sql_DataParamn, 0, false, false, false);
                if (s_return_Value != GlobalVariables.g_s_connectionErrorReturnValue)
                {
                    if (connection.ResultsDataSet.Tables[0] != null)
                    {
                        if (Convert.ToInt32(connection.ResultsDataSet.Tables[0].Rows.Count) < 5)
                        {
                            b_chkValue = true;
                            return b_chkValue;
                        }

                        else
                        {
                            b_chkValue = false;
                            return b_chkValue;
                        }

                    }

                    else
                    {
                        b_chkValue = true;
                        return b_chkValue;
                    }

                }

                else return false;

            }
            else return true;
            
            
        }
        catch (Exception)
        {
            throw;
        }
       
    }

    private string s_biult_ColumnName()
    {
        List<string> s_columnName = new List<string>(4);
        s_columnName = (List<string>)ViewState[ViewStateKeys.S_columnName];

        List<string> s_visible = new List<string>(4);
        s_visible = (List<string>)ViewState[ViewStateKeys.S_visible];

        Session[GlobalVariables.g_s_ColumnName] = string.Empty;
        int i_ind;

        for (i_ind = 0; i_ind <= 4; i_ind++)
        {
            if (s_visible[i_ind] == "Y")
            {
                Session[GlobalVariables.g_s_ColumnName] = Session[GlobalVariables.g_s_ColumnName].ToString() + s_columnName[i_ind] + "Ã";
            }
        }
        return Session[GlobalVariables.g_s_ColumnName].ToString();
    }

    private string s_biult_Parameter()
    {
        List<string> s_visible = new List<string>(4);
        s_visible = (List<string>)ViewState[ViewStateKeys.S_visible];
        
        Session[GlobalVariables.g_s_Parameter] = string.Empty;
        if (s_visible[0] == "Y")
        {
            Session[GlobalVariables.g_s_Parameter] = Session[GlobalVariables.g_s_Parameter].ToString() + txt_1stColumn.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "Ã";
        }
        if (s_visible[1] == "Y")
        {
            Session[GlobalVariables.g_s_Parameter] = Session[GlobalVariables.g_s_Parameter].ToString() + txt_2stColumn.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "Ã";
        }
        if (s_visible[2] == "Y")
        {
            Session[GlobalVariables.g_s_Parameter] = Session[GlobalVariables.g_s_Parameter].ToString() + txt_code.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "Ã";
        }
        if (s_visible[3] == "Y")
        {
            Session[GlobalVariables.g_s_Parameter] = Session[GlobalVariables.g_s_Parameter].ToString() + txt_serialNo.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "Ã";
        }

        if (s_visible[4] == "Y")
        {
            string s_activeValue = string.Empty;
            if (chk_active.Checked == true)
            {
                s_activeValue = "Y";
            }

            else
            {
                s_activeValue = "N";
            }

            Session[GlobalVariables.g_s_Parameter] = Session[GlobalVariables.g_s_Parameter].ToString() + s_activeValue + "Ã";
        }

        return Session[GlobalVariables.g_s_Parameter].ToString();
    }


    private Boolean b_biult_mustValidation()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        List<string> s_visible = new List<string>(4);
        s_visible = (List<string>)ViewState[ViewStateKeys.S_visible];

        List<string> s_mustValidation = new List<string>(4);
        s_mustValidation = (List<string>)ViewState[ViewStateKeys.S_mustValidation];


        if (s_visible[0] == "Y" && s_mustValidation[0] == "Y")
        {
            if (commonFunctions.g_B_mustValidation(txt_1stColumn) == false)
            {
                lblMsg.Text = "This field can not be blank";

                //m_image.Visible = true;
                txt_1stColumn.Focus();
                return false;
            }
        }
        if (s_visible[1] == "Y" && s_mustValidation[1] == "Y")
        {
            if (commonFunctions.g_B_mustValidation(txt_2stColumn) == false)
            {
                lblMsg.Text = "This field can not be blank";
                //m_image1.Visible = true;
                txt_2stColumn.Focus();
                return false; 
            }
        }
        if (s_visible[2] == "Y" && s_mustValidation[2] == "Y")
        {
            if (commonFunctions.g_B_mustValidation(txt_code) == false)
            {
                lblMsg.Text = "This field can not be blank";
                //m_image2.Visible = true;
                txt_code.Focus();
                return false; 
            }
        }
        if (s_visible[3] == "Y" && s_mustValidation[3] == "Y")
        {
            if (commonFunctions.g_B_mustValidation(txt_serialNo) == false)
            {
                lblMsg.Text = "This field can not be blank";
                //m_image3.Visible = true;
                txt_serialNo.Focus();
                return false; 
            }
        }
        return true;
    }

    private Boolean s_biult_NumericValidation()
    {
        List<string> s_dataValidation = new List<string>(4);
        s_dataValidation = (List<string>)ViewState[ViewStateKeys.S_dataValidation];

        List<string> s_visible = new List<string>(4);
        s_visible = (List<string>)ViewState[ViewStateKeys.S_visible];

        CommonFunctions.numeric_Validation Numeric_Validation = new CommonFunctions.numeric_Validation();
        if (s_visible[0] == "Y" && s_dataValidation[0] != "N")
        {
            if (s_dataValidation[0] == "I")
            {
                if (Numeric_Validation.Numeric_Validation_Integer(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Integer is Allowed!";
                    txt_1stColumn.Focus();
                    return false;
                }
            }
            if (s_dataValidation[0] == "D")
            {
                if (Numeric_Validation.numeric_Validation_Decimal(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Decimal is Allowed!";
                    txt_1stColumn.Focus();
                    return false;
                }
            }
        }
        if (s_visible[1] == "Y" && s_dataValidation[1] != "N")
        {
            if (s_dataValidation[1] == "I")
            {
                if (Numeric_Validation.Numeric_Validation_Integer(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Integer is Allowed!";
                    txt_2stColumn.Focus();
                    return false;
                }
            }
            if (s_dataValidation[1] == "D")
            {
                if (Numeric_Validation.numeric_Validation_Decimal(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Decimal is Allowed !";
                    txt_2stColumn.Focus();
                    return false;
                }
            }
        }

        if (s_visible[2] == "Y" && s_dataValidation[2] != "N")
        {
            if (s_dataValidation[2] == "I")
            {
                if (Numeric_Validation.Numeric_Validation_Integer(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Integer is Allowed!";
                    txt_code.Focus();
                    return false;
                }
            }
            if (s_dataValidation[2] == "D")
            {
                if (Numeric_Validation.numeric_Validation_Decimal(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Decimal is Allowed !";
                    txt_code.Focus();
                    return false;
                }
            }
        }

        if (s_visible[3] == "Y" && s_dataValidation[3] != "N")
        {
            if (s_dataValidation[3] == "I")
            {
                if (Numeric_Validation.Numeric_Validation_Integer(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Integer is Allowed!";
                    txt_serialNo.Focus();
                    return false;
                }
            }
            if (s_dataValidation[3] == "D")
            {
                if (Numeric_Validation.numeric_Validation_Decimal(txt_serialNo.Text, 1) == false)
                {
                    lblMsg.Text = "Only Decimal is Allowed !";
                    txt_serialNo.Focus();
                    return false;
                }
            }
        }
        return true;
    }

    private string s_biult_DuplicateChecking()
    {
        List<string> s_columnName = new List<string>(4);
        s_columnName = (List<string>)ViewState[ViewStateKeys.S_columnName];

        List<string> s_duplicateCheck = new List<string>(4);
        s_duplicateCheck = (List<string>)ViewState[ViewStateKeys.S_duplicateCheck];

        Boolean b_and;
        b_and = false;

        Session[GlobalVariables.g_s_DuplicateChecking] = string.Empty;
        if (s_duplicateCheck[0] == "Y")
        {
            //if (b_and == true)
            //{
            //    Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + " OR ";
            //}
            Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + ""
                                                    + s_columnName[0]
                                                    + "=" + "''" + txt_1stColumn.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "''";
            b_and = true;
        }

        if (s_duplicateCheck[1] == "Y")
        {
            if (b_and == true)
            {
                Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + " OR ";
            }
            Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + ""
                                                    + s_columnName[1]
                                                    + "=" + "''" + txt_2stColumn.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "''";
            b_and = true; 
        }

        if (s_duplicateCheck[2] == "Y")
        {
            if (b_and == true)
            {
                Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + " OR ";
            }
            Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + ""
                                                    + s_columnName[2]
                                                    + "=" + "''" + txt_code.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "''";
            b_and = true;
        }

        if (s_duplicateCheck[3] == "Y")
        {
            if (b_and == true)
            {
                Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + " OR ";
            }
            Session[GlobalVariables.g_s_DuplicateChecking] = Session[GlobalVariables.g_s_DuplicateChecking].ToString() + ""
                                                    + s_columnName[3]
                                                    + "=" + "''" + txt_serialNo.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "''";
            b_and = true;
        }



        return Session[GlobalVariables.g_s_DuplicateChecking].ToString();
    }

    protected void btn_remove_Click(object sender, EventArgs e)
    {
        List<string> l_access_status = new List<string>(4);
        l_access_status = (List<string>)ViewState[ViewStateKeys.V_l_access_status];
        try
        {
            if (Session[GlobalVariables.g_s_TableName].ToString()
                == TableColumnName.T_Web_PerformanceTabDescription.TableName)
            {
                lblMsg.Text = "Permission Denied";
            }
            else
            {
                if (l_access_status[2] == "Y" && Convert.ToString(Session[GlobalVariables.g_s_insertMode]) == "1")
                {
                    CommonFunctions commonFunctions = new CommonFunctions();
                    Connection connection = new Connection();
                    string g_s_tableName = string.Empty;
                    g_s_tableName = Request.QueryString["tableName"];
                    string g_s_tableColName = string.Empty;
                    string g_s_checkingValue = string.Empty;
                    g_s_checkingValue = "autoId";
                    string g_s_referenceChecking = string.Empty;
                    //g_s_referenceChecking = "T_Com_Item,color_autoIdÃ";

                    string sqlDelete = string.Empty;

                    Session[GlobalVariables.g_s_deleteValue] = gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[0].Text.ToString();
                    sqlDelete = Procedures.Common.Proc_Delete_Any_Tables_With_Reference_Checking + " '"
                    + g_s_tableName + "','"
                    + g_s_checkingValue + "','" + g_s_referenceChecking + "','" + Session[GlobalVariables.g_s_deleteValue].ToString() + "'";

                    Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(sqlDelete, 1, true, true, true);

                    Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(sqlDelete, 1, true, true, true);
                    if (Convert.ToString(Session[GlobalVariables.g_s_procedureReturnType]) == "0")
                    {

                        v_loadGridView();
                        btn_refresh_Click(new object(), new EventArgs());

                        insertMode();
                        lblMsg.Text = GlobalVariables.g_s_deleteOperationSuccessfull;
                    }
                    else
                    {
                        string ReferenceTable = Session[GlobalVariables.g_s_procedureReturnType].ToString().Substring(2);

                        lblMsg.Text = GlobalVariables.g_s_deleteOperationFailed + ReferenceTable;
                    }
                }

                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = GlobalVariables.g_s_deleteSecurityMessage;
                }
            }
        }
        catch(Exception)
        {
        }

    }

    
    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        insertMode();
       
       
    }

    private void insertMode()

    {
        Session[GlobalVariables.g_s_insertMode] = "0";
        //m_image.Visible = false;
        //m_image1.Visible = false;
        //m_image2.Visible = false;
        //m_image3.Visible = false;
        hidIsInsertMode.Value = "True";

        gdv_commonForm.SelectedIndex = -1;
        //chk_active.Checked = true;
        btn_save.Text = "Save";
        lblMsg.Text = String.Empty;
        txt_1stColumn.Text = string.Empty;
        txt_2stColumn.Text = string.Empty;
        txt_code.Text = string.Empty;
        txt_serialNo.Text = string.Empty;
    }



    private void v_loadGridView()
    {
        try
        {

            Connection connection = new Connection();

            hid_s_tableName.Value = Request.QueryString["tableName"];
            string s_sqlGridView = "select * from " + hid_s_tableName.Value;
            connection.connection_DB(s_sqlGridView, 0, false, true, true);
            gdv_commonForm.DataSource = connection.ResultsDataSet.Tables[0];
            gdv_commonForm.DataBind();
        }

        catch
        {

        }
    }

    //private void v_loadGridView()
    //{
    //    try
    //    {

    //        Connection connection = new Connection();

    //        hid_s_tableName.Value = Request.QueryString["tableName"];
    //        string s_sqlGridView = "select * from  " + hid_s_tableName.Value+" order by serial_no";
    //        connection.connection_DB(s_sqlGridView, 0, false, true, true);
    //        gdv_commonForm.DataSource = connection.ResultsDataSet.Tables[0];
    //        gdv_commonForm.DataBind();
    //    }

    //    catch
    //    {

    //    }
    //}

    public void v_createBoundField(string data_forB1, string data_forB2, string data_forB3, string data_forB4, string data_forB5, string data_forB6)
    {
        List<string> s_labelName = new List<string>(5);        
        s_labelName = (List<string>)ViewState[ViewStateKeys.S_labelName];

        List<string> s_visible = new List<string>(4);
        s_visible = (List<string>)ViewState[ViewStateKeys.S_visible];

        BoundField b1 = new BoundField();
        b1.HeaderText = data_forB1.ToUpper().Replace("_"," ");
        b1.DataField = data_forB1;

        b1.HeaderStyle.CssClass = "hidGridColumn";
        b1.ItemStyle.CssClass = "hidGridColumn"; 
        gdv_commonForm.Columns.Add(b1);
        
        if (s_visible[0] == "Y")
        {
            BoundField b2 = new BoundField();

            b2.HeaderText = s_labelName[0];
            b2.DataField = data_forB2;

            gdv_commonForm.Columns.Add(b2);
         
        }
        if (s_visible[1] == "Y")
        {
            BoundField b3 = new BoundField();

            b3.HeaderText = s_labelName[1];
            b3.DataField = data_forB3;
      
            gdv_commonForm.Columns.Add(b3);
        }
        if (s_visible[2] == "Y")
        {

            BoundField b4 = new BoundField();
           
            b4.HeaderText = s_labelName[2];
            b4.DataField = data_forB4;
            gdv_commonForm.Columns.Add(b4);
        }
        if (s_visible[3] == "Y")
        {

            BoundField b5 = new BoundField();

            b5.HeaderText = s_labelName[3];
            b5.DataField = data_forB5;
            gdv_commonForm.Columns.Add(b5);
        }
        if (s_visible[4] == "Y")
        {

            BoundField b6 = new BoundField();

            b6.HeaderText = "Active";
            b6.DataField = data_forB6;
            gdv_commonForm.Columns.Add(b6);
        }
        

   

        CommandField commandField = new CommandField();
        commandField.ShowSelectButton = true;
        commandField.HeaderStyle.CssClass = "hidGridColumn";
        commandField.ItemStyle.CssClass = "hidGridColumn";
        gdv_commonForm.Columns.Add(commandField);

    }

    protected void gdv_commonForm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
            e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_commonForm, "Select$" + e.Row.RowIndex);
        }
    }
    protected void gdv_commonForm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonFunctions.Date_Validation dateValidation = new CommonFunctions.Date_Validation();

            List<string> s_visible = new List<string>(4);
            s_visible = (List<string>)ViewState[ViewStateKeys.S_visible];

            hidIsInsertMode.Value = "False";
            btn_save.Text = "Update";
            gdv_commonForm.EnableModelValidation = false;

            int i_ind=1;

            if (s_visible[0] == "Y")
            {
                txt_1stColumn.Text = HttpUtility.HtmlDecode(gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[i_ind].Text);
                i_ind += 1;
            }
            if (s_visible[1] == "Y")
            {
                txt_2stColumn.Text = HttpUtility.HtmlDecode(gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[i_ind].Text);
                i_ind += 1;
            }
            if (s_visible[2] == "Y")
            {
                txt_code.Text = HttpUtility.HtmlDecode(gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[i_ind].Text);
                i_ind += 1;
            }
            if (s_visible[3] == "Y")
            {
                txt_serialNo.Text = HttpUtility.HtmlDecode(gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[i_ind].Text);
                i_ind += 1;
            }
            if (s_visible[4] == "Y")
            {
                if (HttpUtility.HtmlDecode(gdv_commonForm.Rows[gdv_commonForm.SelectedIndex].Cells[i_ind].Text.Trim().ToString()) == "Y")
                {
                    chk_active.Checked = true;
                }
                else
                {
                chk_active.Checked = false ;
                }
                i_ind += 1;
            }
            
            Session[GlobalVariables.g_s_insertMode] = "1";
        }
        catch
        {
        }
    }
}
