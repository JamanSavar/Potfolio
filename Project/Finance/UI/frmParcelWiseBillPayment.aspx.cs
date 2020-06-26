using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

public partial class Finance_UI_frmParcelWiseBillPayment : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        txtIssueDate.Text = DateTime.Now.ToString();
        txtFromDate.Text = DateTime.Now.ToString();
        txtToDate.Text = DateTime.Now.ToString();

        if (!IsPostBack)
        {
            CommonFunctions commonfunctions = new CommonFunctions();

            HidReceiveFromId.Value = "";
            HidCourrierId.Value = "";
            HidParcelNo.Value = "Basher";
            HidFromdate.Value = DateTime.Now.ToString();
            HidTodate.Value = DateTime.Now.ToString();
            HidDateUse.Value = "N";


            commonfunctions.g_b_FillDropDownList(dd_CorrierName,
               "T_Courier",
               "Name",
               "Courier_Id", string.Empty);



            string SessionUserName = string.Empty;
            SessionUserName = Convert.ToString(Session[GlobalVariables.g_s_userName]);
            txt_InputBy.Text = SessionUserName;

            txtIssueDate.Focus();
           // btn_save.Text = "Save";

            v_loadGridView_ParselReceive();

        }

    }


    //protected void btn_save_Click(object sender, EventArgs e)
    //{

    //    string s_save_ = string.Empty;
    //    string s_Update = string.Empty;
    //    string s_returnValue = string.Empty;
    //    string s_Update_returnValue = string.Empty;
    //    txt_Amount.Text = "0";
    //    string SessionUserId = string.Empty;
    //    string SessionCompanyId = string.Empty;
    //    SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
    //    SessionCompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

    //    Connection connection = new Connection();

    //    Boolean b_validationReturn = true;

    //    b_validationReturn = isValid();

    //    if (b_validationReturn == false)
    //    {
    //        return;
    //    }

    //    Boolean b_UserReturn = true;
    //    b_UserReturn = isUserCheck();
    //    if (b_UserReturn == false && btn_save.Text == "Update")
    //    {
    //        return;
    //    }

    //    if (btn_save.Text == "Update")
    //    {

    //        HidSenderType.Value = dd_ReacivingFrom.SelectedItem.Text;
    //        HidSenderType.Value = HidSenderType.Value.Substring(0, 1);

    //        s_Update = "[Proc_Parcel_Receive_Update]"
    //                    + "'"
    //                    + hid_AutoId.Value
    //                    + "','"
    //                    + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
    //                    + "','"
    //                    + dd_ReacivingFrom.SelectedValue
    //                    + "','"
    //                    + HidSenderType.Value
    //                    + "','"
    //                    + dd_CorrierName.SelectedValue
    //                    + "','"
    //                    + HttpUtility.HtmlDecode(txt_CorrierNo.Text.Trim())
    //                    + "','"
    //                    + HttpUtility.HtmlDecode(txt_Amount.Text.Trim())
    //                    + "','"
    //                    + HttpUtility.HtmlDecode(txt_Remarks.Text.Trim())
    //                    + "','0','"
    //                    + SessionUserId
    //                    + "','"
    //                    + SessionCompanyId
    //                    + "'";


    //        s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, true);
    //        if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
    //        {

    //            if (s_Update_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
    //            {
    //                lblMsg.Text = GlobalVariables.g_s_updateOperationSuccessfull;
    //                InsertMode();
    //                v_loadGridView_Update();
    //            }
    //            else
    //            {
    //                lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
    //            }
    //        }
    //    }

    //    else
    //    {


    //        HidSenderType.Value = dd_ReacivingFrom.SelectedItem.Text;
    //        HidSenderType.Value = HidSenderType.Value.Substring(0, 1);

    //        s_save_ = "[Proc_Parcel_Receive_INSERT]"
    //                    + "'"
    //                    + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
    //                    + "','"
    //                    + dd_ReacivingFrom.SelectedValue
    //                    + "','"
    //                    + HidSenderType.Value
    //                    + "','"
    //                    + dd_CorrierName.SelectedValue
    //                    + "','"
    //                    + HttpUtility.HtmlDecode(txt_CorrierNo.Text.Trim())
    //                    + "','"
    //                    + HttpUtility.HtmlDecode(txt_Amount.Text.Trim())
    //                    + "','"
    //                    + HttpUtility.HtmlDecode(txt_Remarks.Text.Trim())
    //                    + "','0','"
    //                    + SessionUserId
    //                    + "','"
    //                    + SessionCompanyId
    //                    + "'";

    //        HidReceiveFromId.Value = dd_ReacivingFrom.SelectedValue.ToString() + "X";
    //        HidCourrierId.Value = dd_CorrierName.SelectedValue.ToString() + "X";
    //        HidParcelNo.Value = HttpUtility.HtmlDecode(txt_CorrierNo.Text.Trim());
    //        HidFromdate.Value = DateTime.Now.ToString();
    //        HidTodate.Value = DateTime.Now.ToString();
    //        HidDateUse.Value = "N";


    //        s_returnValue = connection.connection_DB(s_save_, 1, true, true, true);

    //        if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
    //        {

    //            if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
    //            {
    //                lblMsg.Text = GlobalVariables.g_s_insertOperationSuccessfull;
    //                InsertMode();
    //                v_loadGridView_ParselReceive();
    //            }
    //            else
    //            {
    //                lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
    //            }
    //        }
    //        else
    //        {
    //            string message = "Operation Failed!";
    //            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
    //        }
    //    }
    //}

    //protected void txt_Amount_TextChanged(object sender, EventArgs e)
    //{
    //    CommonFunctions commonfunctions = new CommonFunctions();

    //    CommonFunctions.numeric_Validation numeric_Validation = new CommonFunctions.numeric_Validation();
    //    if (numeric_Validation.numeric_Validation_Decimal_Allow_Minus(txt_Amount.Text, 1) == false)
    //    {
    //        txt_Amount.Text = "";
    //    }

    //    txt_Remarks.Focus();


    //}




    //protected void gdv_Item_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    dd_ReacivingFrom.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[1].Text.ToString());
    //    dd_CorrierName.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[3].Text.ToString());
    //    txt_CorrierNo.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());
    //    txt_Amount.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[6].Text.ToString());
    //    txt_Remarks.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[7].Text.ToString());
    //    txtIssueDate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[8].Text.ToString());
    //    txt_VoucherNo.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[9].Text.ToString());
    //    //txt_InputBy.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[10].Text.ToString());

    //    hid_AutoId.Value = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[11].Text.ToString());
    //    btn_save.Text = "Update";
    //}

    //protected void gdv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    #region gdv_Item_RowDataBound
    //    try
    //    {

    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
    //            e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
    //            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_Item, "Select$" + e.Row.RowIndex);
    //        }
    //    }
    //    catch (Exception exception)
    //    {
    //        lblMsg.Text = exception.Message;
    //    }
    //    #endregion gdv_Item_RowDataBound

    //}

    //private void v_loadGridView_Update()
    //{

    //    CommonFunctions commonFunctions = new CommonFunctions();
    //    SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
    //    sqlconnection.Open();


    //    SqlCommand cmd = new SqlCommand("proc_Parcel_GreedView_Update '" + hid_AutoId.Value + "'", sqlconnection);
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds = new DataSet();
    //    da.Fill(ds);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
    //        gdv_Item.DataSource = ds;
    //        gdv_Item.DataBind();
    //        int columncount = gdv_Item.Rows[0].Cells.Count;
    //        gdv_Item.Rows[0].Cells.Clear();
    //        gdv_Item.Rows[0].Cells.Add(new TableCell());
    //        gdv_Item.Rows[0].Cells[0].ColumnSpan = columncount;

    //    }
    //    else
    //    {
    //        gdv_Item.DataSource = ds;
    //        gdv_Item.DataBind();
    //    }
    //    sqlconnection.Close();
    //}

    //private Boolean isValid()
    //{
    //    CommonFunctions.Date_Validation dv = new CommonFunctions.Date_Validation();

    //    if (dd_ReacivingFrom.SelectedValue == "0")
    //    {
    //        string message = "Reaciving From Can Not Blank!";
    //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
    //        return false;
    //    }

    //    if (dd_CorrierName.SelectedValue == "0")
    //    {
    //        string message = "Corrier Name Can Not Blank!!";
    //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
    //        return false;
    //    }

    //    //if (txt_Amount.Text == "" || txt_Amount.Text == "0")
    //    //{
    //    //    string message = "Amount Can Not Blank!";
    //    //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
    //    //    return false;
    //    //}

    //    if (txt_CorrierNo.Text == "")
    //    {
    //        string message = "CorrierNo Can Not Blank!";
    //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
    //        return false;
    //    }



    //    return true;
    //}

    //private void InsertMode()
    //{
    //    CommonFunctions commonfunctions = new CommonFunctions();

    //    dd_ReacivingFrom.SelectedValue = "0";
    //    dd_CorrierName.SelectedValue = "0";
    //    txt_CorrierNo.Text = string.Empty;
    //    txt_Remarks.Text = string.Empty;
    //    txt_Amount.Text = "0";
    //    txtIssueDate.Text = DateTime.Now.ToString();

    //    btn_save.Text = "Save";
    //    //lblMsg.Text = string.Empty;

    //    //gdv_Style.DataSource = null;
    //    //gdv_Style.DataBind();

    //    commonfunctions.g_b_FillDropDownListByProc(dd_BuyerSupplier,
    //            "Proc_Load_Buyer_Supplier",
    //            "FromType",
    //            "FromName",
    //            "AutoId", string.Empty);

    //}

    //private Boolean isUserCheck()
    //{
    //    Connection connection = new Connection();
    //    string s_DeleteQry = string.Empty; string s_CheckUser = string.Empty;
    //    string returnValue = string.Empty;
    //    string SessionUserId = string.Empty;
    //    SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);

    //    s_CheckUser = "SELECT s.autoId as User_Id,s.UserName as UserName FROM T_Order r left outer Join T_SignIn s ON r.User_Id=s.autoId Where Order_Id="
    //                                 + "'"
    //        //+ dd_Search.SelectedValue
    //                                 + "'";

    //    returnValue = connection.connection_DB(s_CheckUser, 0, false, false, false);
    //    if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
    //    {
    //        if (connection.ResultsDataSet.Tables[0] != null)
    //        {
    //            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
    //            {
    //                string UserId = string.Empty;
    //                string UserName = string.Empty;

    //                UserId = drow["User_Id"].ToString();
    //                UserName = drow["UserName"].ToString();

    //                if (UserId != SessionUserId)
    //                {
    //                    lblMsg.Text = "Only " + UserName + " Can  Edit/Delete!";
    //                    return false;
    //                }

    //            }
    //        }
    //    }

    //    return true;
    //}


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        //HidReceiveFromId.Value = "0";
        //HidCourrierId.Value = "";
        //HidParcelNo.Value = "";
        //if (dd_BuyerSupplier.SelectedValue != "0")
        //{
        //    HidReceiveFromId.Value = dd_BuyerSupplier.SelectedValue.ToString();
        //}
        //if (dd_CourrierSearch.SelectedValue != "0")
        //{
        //    HidCourrierId.Value = dd_CourrierSearch.SelectedValue.ToString() + "X";
        //}
        //HidParcelNo.Value = HttpUtility.HtmlDecode(txt_SearchCourrier.Text.Trim());
        //HidFromdate.Value = DateTime.Now.ToString();
        //HidTodate.Value = DateTime.Now.ToString();
        //HidDateUse.Value = "N";

        //v_loadGridView_ParselReceive();

    }

    private void v_loadGridView_ParselReceive()
    {

        string SessionUserId = string.Empty;
        string SessionCompanyId = string.Empty;
        SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
        SessionCompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        HidFromdate.Value = Convert.ToDateTime(HidFromdate.Value, new CultureInfo("fr-FR")).ToString("MM/dd/yyyy");
        HidTodate.Value = Convert.ToDateTime(HidTodate.Value, new CultureInfo("fr-FR")).ToString("MM/dd/yyyy");


        SqlCommand cmd = new SqlCommand("proc_Parcel_Receive_Search '" + HidReceiveFromId.Value + "','" + HidCourrierId.Value + "','" + HidParcelNo.Value + "','" + HidFromdate.Value + "','" + HidTodate.Value + "','" + HidDateUse.Value + "','" + SessionCompanyId + "'", sqlconnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_Item.DataSource = ds;
            gdv_Item.DataBind();
            int columncount = gdv_Item.Rows[0].Cells.Count;
            gdv_Item.Rows[0].Cells.Clear();
            gdv_Item.Rows[0].Cells.Add(new TableCell());
            gdv_Item.Rows[0].Cells[0].ColumnSpan = columncount;

        }
        else
        {
            gdv_Item.DataSource = ds;
            gdv_Item.DataBind();
        }
        sqlconnection.Close();
    }

    //protected void btn_Preview_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string SessionUserId = string.Empty;
    //        string SessionCompanyId = string.Empty;
    //        SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
    //        SessionCompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

    //        HidReceiveFromId.Value = "";
    //        HidCourrierId.Value = "";
    //        HidParcelNo.Value = "";

    //        if (dd_BuyerSupplier.SelectedValue != "0")
    //        {
    //            HidReceiveFromId.Value = dd_BuyerSupplier.SelectedValue.ToString() + "X";
    //        }
    //        if (dd_CourrierSearch.SelectedValue != "0")
    //        {
    //            HidCourrierId.Value = dd_CourrierSearch.SelectedValue.ToString() + "X";
    //        }

    //        HidParcelNo.Value = HttpUtility.HtmlDecode(txt_SearchCourrier.Text.Trim());
    //        HidFromdate.Value = DateTime.Now.ToString();
    //        HidTodate.Value = DateTime.Now.ToString();
    //        HidDateUse.Value = "N";

    //        HidFromdate.Value = Convert.ToDateTime(HidFromdate.Value, new CultureInfo("fr-FR")).ToString("MM/dd/yyyy");
    //        HidTodate.Value = Convert.ToDateTime(HidTodate.Value, new CultureInfo("fr-FR")).ToString("MM/dd/yyyy");

    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString());
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone3", Session[GlobalVariables.g_s_Phone].ToString());
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Head4", "Parcel Info");

    //        TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Marchandising\\Reports\\rptParcelReceive.rpt";

    //        TableColumnName.Rpt_ErpReport.g_s_sql_query = "proc_RPT_Parcel_Receive"
    //                                                 + "'"
    //                                                 + HidReceiveFromId.Value.ToString()
    //                                                 + "','"
    //                                                 + HidCourrierId.Value.ToString()
    //                                                 + "','"
    //                                                 + HidParcelNo.Value.ToString()
    //                                                 + "','"
    //                                                 + HidFromdate.Value.ToString()
    //                                                 + "','"
    //                                                 + HidTodate.Value.ToString()
    //                                                 + "','"
    //                                                 + HidDateUse.Value.ToString()
    //                                                 + "','"
    //                                                 + SessionCompanyId
    //                                                 + "'";

    //        Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
    //    }

    //    catch (Exception)
    //    {

    //    }
    //}
}
