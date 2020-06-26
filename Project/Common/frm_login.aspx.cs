using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class HumanResource_Common_frm_login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        # region css registry

        String csname = "css_Script";
        String csurl = "~/Forms/Accounts/cssSTM.css";
        Type cstype = this.GetType();

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        // Check to see if the include script exists already.
        if (!cs.IsClientScriptIncludeRegistered(cstype, csname))
        {
            cs.RegisterClientScriptInclude(cstype, csname,
            ResolveClientUrl(csurl));

        }

        #endregion

        btn_login.CssClass = "standardButton";
        btn_exit.CssClass = "standardButton";

        //txt_userName.Text = "stm_liton@yahoo.com";

        //txt_userName.Text = "Basher";
        //txt_password.Text = "123456";

        CommonFunctions commonFunctions = new CommonFunctions();
        commonFunctions.g_v_RenderJSArrayWithCliendIds(this
                                                        , txt_userName
                                                        , txt_password
                                                        , btn_login
                                                        , btn_exit);
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["cId"] != null)
                {
                    dd_companyName.SelectedValue = Request.QueryString["cId"].ToString().Trim();
                }
                if (Request.QueryString["userId"] != null)
                {
                    txt_userName.Text = Request.QueryString["userId"].ToString().Trim();
                }
            }

            //commonFunctions.g_b_FillDropDownList(dd_companyName, ""
            //    + TableColumnName.T_Company_Info.TableName
            //    + "", ""
            //    + TableColumnName.T_Company_Info.CompName
            //    + "", ""
            //    + TableColumnName.Company_Id
            //    + "", "");

            //commonFunctions.g_b_FillDropDownList(dd_companyName,
            //    TableColumnName.T_CompanyInfo.TableName,
            //    TableColumnName.T_CompanyInfo.CompName,
            //    TableColumnName.T_CompanyInfo.AutoId, "", false);

            commonFunctions.g_b_FillDropDownList(dd_companyName,
                "T_CompanyInfo",
                "compName",
                "autoId", string.Empty);
            dd_companyName.SelectedValue = "5";
            //commonFunctions.g_b_FillDropDownListLoaded(dd_companyName,
            //    "T_CompanyInfo",
            //    "compName",
            //    "autoId", string.Empty);


        }
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        if (txt_userName.Text == string.Empty)
        {
            lblMsg.Text = "UserID cann't be blank";
        }
        else
        {
            if (txt_password.Text == string.Empty)
            {
                lblMsg.Text = "Password cann't be blank";
            }
            else
            {
                Connection connection = new Connection();
                CommonFunctions.password_Handler password_Handler = new CommonFunctions.password_Handler();
                string s_cryptUserName = string.Empty, s_cryptPwd = string.Empty,
                                        issertUserLog = string.Empty,
                                        s_sql_findUser = string.Empty,
                                        return_autoId = string.Empty,
                                        redirectPageURL = string.Empty;
                decimal i_row = 0;
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["pageURL"] != null)
                    {
                        redirectPageURL = Request.QueryString["pageURL"].ToString().Replace("@", "&");
                    }

                    if (Request.QueryString["s_pageURL_feedBack"] != null)
                    {
                        redirectPageURL = Request.QueryString["s_pageURL_feedback"].ToString().Replace("@", "&");
                    }
                }

                s_cryptUserName = txt_userName.Text;
                s_cryptPwd = txt_password.Text;

                s_sql_findUser = "proc_frm_SignIn_For_validUser"
                                    + "'"
                                    + txt_userName.Text
                                    + "','"
                                    + txt_password.Text
                                    + "','"
                                    + dd_companyName.SelectedValue
                                    + "'";

                Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(s_sql_findUser, 0, true, false, false);
                if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != GlobalVariables.g_s_connectionErrorReturnValue)
                {
                    if (connection.ResultsDataSet != null)
                    {
                        if (connection.ResultsDataSet.Tables != null)
                        {
                            if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                            {
                                i_row = Convert.ToDecimal(connection.ResultsDataSet.Tables[0].Rows.Count.ToString());
                                if (connection.ResultsDataSet.Tables[0].Rows[0]["password"].ToString() == txt_password.Text)
                                {

                                }
                                else
                                {
                                    i_row = 0;
                                }
                            }
                        }
                    }
                }
                if (i_row > 0)
                {

                    //insert start into Table T_UserLogBook
                    string user_autoId = string.Empty;
                    string s_sql_selectCompanyInfo = string.Empty;
                    DataTable dt_companyInformation = new DataTable();
                    CommonFunctions.Date_Validation date_validation = new CommonFunctions.Date_Validation();

                    foreach (DataRow datarow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        Session[GlobalVariables.g_s_userName] = datarow["UserName"].ToString();
                        Session[GlobalVariables.g_s_userAutoId] = datarow["autoId"].ToString();
                        Session[GlobalVariables.g_s_CompanyAutoId] = dd_companyName.SelectedValue;
                        string CompanyAutoID = Session[GlobalVariables.g_s_CompanyAutoId].ToString();
                        Session[GlobalVariables.g_s_userStatus] = datarow["userStatus"].ToString();
                        Session[GlobalVariables.g_s_userLevel] = "";                       
                    }

                    // track down company Information

                    s_sql_selectCompanyInfo = Procedures.humanResource.Proc_Web_frm_login_Select_CompanyInformation
                                                + " '"
                                                + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
                                                + "'";
                    Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(s_sql_selectCompanyInfo, 0, true, false, false);
                    dt_companyInformation = connection.ResultsDataSet.Tables[0];

                    if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != GlobalVariables.g_s_connectionErrorReturnValue)
                    {

                        if (dt_companyInformation != null)
                        {
                            foreach (DataRow datarow_companyInformation in dt_companyInformation.Rows)
                            {
                                Session[GlobalVariables.g_s_GroupName] = Convert.ToString(datarow_companyInformation["groupName"].ToString());
                                Session[GlobalVariables.g_s_companyName] = Convert.ToString(datarow_companyInformation["compName"].ToString());
                                Session[GlobalVariables.g_s_Address] = Convert.ToString(datarow_companyInformation["address"].ToString());
                                Session[GlobalVariables.g_s_City] = Convert.ToString(datarow_companyInformation["city"].ToString());
                                Session[GlobalVariables.g_s_Zip] = Convert.ToString(datarow_companyInformation["zip"].ToString());
                                Session[GlobalVariables.g_s_Country] = Convert.ToString(datarow_companyInformation["country"].ToString());
                                Session[GlobalVariables.g_s_Phone] = Convert.ToString(datarow_companyInformation["phoneNo"].ToString());
                                Session[GlobalVariables.g_s_Fax] = Convert.ToString(datarow_companyInformation["fax"].ToString());
                                Session[GlobalVariables.g_s_Email] = Convert.ToString(datarow_companyInformation["email"].ToString());
                                Session[GlobalVariables.g_s_Code] = Convert.ToString(datarow_companyInformation["Code"].ToString());
                                Session[GlobalVariables.g_s_autoId] = "0";
                            }
                        }
                    }

                    // end track down company Information

                    issertUserLog = Procedures.humanResource.Proc_Web_Insert_UserLogBook
                                    + "'" + Session[GlobalVariables.g_s_userAutoId].ToString() +
                                    "','" + DateTime.Now.ToString("MM/dd/yyyy") +
                                    "','" + DateTime.Now.ToString(new CultureInfo("en-US")) +
                                    "','" + DateTime.Now.ToString(new CultureInfo("en-US")) +
                                    "'";

                    return_autoId = connection.connection_DB(issertUserLog, 1, true, true, true);
                    Session["company_AutoId"] = dd_companyName.SelectedValue;
                    if (return_autoId != string.Empty)
                    {
                        Session[GlobalVariables.g_s_userLogBookAutoId] = return_autoId;
                        txt_userName.EnableViewState = true;
                    }
                    Session["Isvalid"] = "true";
                    Session["autoId"] = return_autoId.ToString();
                    if (Request.QueryString.Count > 0)
                    {
                        Response.Redirect(redirectPageURL);
                    }
                    else
                    {
                        Response.Redirect(GlobalVariables.g_s_URL_homePage);
                    }

                    //End insert start into Table T_UserLogBook
                }
                else
                {
                    Session["Isvalid"] = "false";
                    lblMsg.Text = string.Empty;
                    lblMsg.Text = "Invalid user name or password";
                }
            }
        }
    }
    protected void btn_exit_Click(object sender, EventArgs e)
    {

    }
}
