﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Security.Cryptography;

public partial class HumanResource_Common_frm_changePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Request.Url.Query.
                //J+Fi3cckJGykN93BzxEj5ofKKC5mmeLQxTmlM16/kk0P9Vma7virrNAvnfLWttJ8H1qIsJeCgTcdvEs6zWB4rahyeCcZ4SDQ6OCkYFzvn+g= .Replace("%2f", "/")
                if (Request.QueryString != null)
                {
                    //Uri uri = new Uri(Request.Url.AbsoluteUri, UriKind.Absolute);

                    if (!string.IsNullOrEmpty(Request.QueryString.ToString()))
                    {
                        string decryptedQueryString = Encryption64.Decrypt(HttpUtility.UrlDecode(Convert.ToString(Request.QueryString)), GlobalVariables.g_s_encryptionKey);
                        //string[] queryStringArray = decryptedQueryString.Split('&');
                        NameValueCollection queryString = new NameValueCollection();
                        //foreach (string value in queryStringArray)
                        //{
                        //    string[] splitValues = value.Split('=');
                        //    queryString.Add(splitValues[0], splitValues[1]);
                        //}
                        queryString = HttpUtility.ParseQueryString(decryptedQueryString);
                        if (queryString["empAutoId"] != null && queryString["oldPassword"] != null && queryString["companyAutoId"] != null)
                        {
                            hid_empAutoId.Value = queryString["empAutoId"];
                            hid_oldPassword.Value = queryString["oldPassword"];
                            hid_companyAutoId.Value = queryString["companyAutoId"];
                            //hid_empAutoId.Value = Convert.ToString(Request.QueryString["empAutoId"]);
                            //hid_oldPassword.Value = Convert.ToString(Request.QueryString["oldPassword"]);
                            g_b_FillDropDownList(cmbEmployee);
                            cmbEmployee.Enabled = false;
                            cmbEmployee.SelectedValue = Convert.ToString(hid_empAutoId.Value);
                            txtOldPassword.Text = Convert.ToString(hid_oldPassword.Value);
                        }
                        //txtOldPassword.TextMode = TextBoxMode.Password;
                    }
                }
            }
        }
        catch (FormatException)
        {
            Response.Redirect(GlobalVariables.g_s_URL_permissionDenied);
        }
        catch (CryptographicException)
        {
            btnUpdate.Enabled = false;
            lblMsg.Text = "URL Invalid";
        }
        catch (Exception ex)
        {
            btnUpdate.Enabled = false;
            lblMsg.Text = ex.Message;            
            lblMsg.ForeColor = System.Drawing.Color.Tomato;
        }
    }

    public void g_b_FillDropDownList(DropDownList dd_dropDownList)
    {

        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            CommonFunctions commonFunctions = new CommonFunctions();
            string dataparam = string.Empty;
            string returnValue = string.Empty;
            string sql_query = string.Empty;
            string empname = string.Empty;

            sql_query = Procedures.humanResource.Proc_web_select_all_employee_by_company
                                        + " '"
                                        + hid_companyAutoId.Value.Trim()
                                        + "','"
                                        + "%"//txtEmpName.Text.Trim().ToString().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd)
                                        + "'";
            returnValue = connection.connection_DB(sql_query, 0, false, false, false);

            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet == null)
                {
                    lblMsg.Text = "Error in SQL";
                }
                else
                {
                    if (connection.ResultsDataSet.Tables == null)
                    {
                        lblMsg.Text = "No Data Found";
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
            lblMsg.Text = exception.Message;
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = string.Empty;
            if (IsMatch() == false)
                return;
            Connection connection = new Connection();
            string s_changePwdDataParam = string.Empty;
            s_changePwdDataParam = Procedures.humanResource.Proc_web_frm_changePassword_update
                                    + " '"
                                    + Convert.ToString(txtNewPassword.Text.Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd))
                                    + "','"
                                    + Convert.ToString(hid_empAutoId.Value)
                                    + "','"
                                    + txtOldPassword.Text.Trim().Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplaceFrontEnd)
                                    + "'";
            ViewState[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(s_changePwdDataParam, 1, true, true, true);

            if (Convert.ToString(ViewState[GlobalVariables.g_s_procedureReturnType]) != string.Empty)
            {
                if (Convert.ToString(ViewState[GlobalVariables.g_s_procedureReturnType]) == "Y")
                {
                    lblMsg.Text = GlobalVariables.g_s_updateOperationSuccessfull;
                    Response.Redirect(GlobalVariables.g_s_URL_loginPage);
                    lblMsg.ForeColor = System.Drawing.Color.DarkGreen;
                }
                else if (Convert.ToString(ViewState[GlobalVariables.g_s_procedureReturnType]) == "N")
                {
                    lblMsg.Text = "Old password was wrong";
                    lblMsg.ForeColor = System.Drawing.Color.Tomato;
                }
                else
                {
                    lblMsg.Text = GlobalVariables.g_s_updateOperationFailed;
                    lblMsg.ForeColor = System.Drawing.Color.Tomato;
                }

            }

            else
            {
                lblMsg.Text = GlobalVariables.g_s_updateOperationFailed;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }



        }

        catch (Exception)
        {

        }


    }

    private Boolean IsMatch()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        //if (txtNewPassword.Text.Length >= 12)
        //{

            if (commonFunctions.g_B_mustValidationForMultipleTextbox(txtNewPassword) != false)
            {
                if (commonFunctions.g_B_mustValidationForMultipleTextbox(txtConfirmPassword) != false)
                {
                    if (txtNewPassword.Text.Trim().ToString() == txtConfirmPassword.Text.Trim().ToString())
                    {
                        if (!txtNewPassword.Text.Contains("#") && !txtNewPassword.Text.Contains("&") && !txtNewPassword.Text.Contains("'"))
                        {
                            return true;
                        }
                        else
                        {
                            lblMsg.Text = "#,',& characters not allowed";
                            lblMsg.ForeColor = System.Drawing.Color.Tomato;
                            return false;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Password did not match!";
                        lblMsg.ForeColor = System.Drawing.Color.Tomato;
                        return false;
                    }

                }
                else
                {
                    lblMsg.Text = "Confirm password is required";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return false;
                }

            }
            else
            {
                lblMsg.Text = "New password is required";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }
        //}
        //else
        //{
        //    lblMsg.Text = "Password should be at least 12 characters";
        //    lblMsg.ForeColor = System.Drawing.Color.Tomato;
        //    return false;
        //}
    }
}
