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

using System.Web.Services;
using System.Collections.Generic;

public partial class Finance_UI_frmCMApproval : System.Web.UI.Page
{
    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtIssueDate.Text = DateTime.Now.ToString();
            txtExpiryDate.Text = DateTime.Now.ToString();
            
            CommonFunctions commonfunctions = new CommonFunctions();

           commonfunctions.g_b_FillDropDownList(dd_FileNo,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Proposal,
               "TBL_CM_Proposal",
               "SLNo",
               "Proposal_Id", "Order By SLNO DESC");

            commonfunctions.g_b_FillDropDownList(dd_LC,
              "TBL_Export_LC",
              "Export_LC_No",
              "Export_LC_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Invoice,
               "TBL_Export",
               "Invoice_No",
               "Export_Id", string.Empty);

            LoadProposal();
            LoadAcceptaince();
 
        }
    }

    protected void gdv_Proposal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_ChildrenInfo_RowDataBound
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
                e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_Proposal, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception exception)
        {
            //lbl_msg_StaffRequisitionDetails.ForeColor = GlobalVariables.g_clr_errorColor;
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_RowDataBound
    }

    protected void gdv_Proposal_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region gdv_ChildrenInfo_SelectedIndexChanged
        try
        {
            dd_FileNo.SelectedValue = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[2].Text.ToString());
            dd_LC.SelectedValue = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[4].Text.ToString());
            dd_Invoice.SelectedValue = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[6].Text.ToString());
            txt_InvoiceValue.Text = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[8].Text.ToString());
            //txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[10].Text.ToString());
            //txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[11].Text.ToString());
            //txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Proposal.Rows[gdv_Proposal.SelectedIndex].Cells[12].Text.ToString());

            hid_Addmode.Value = "N";
            btn_save.Text = "Update";
            dd_Invoice.Focus();

        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }



    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (gdv_Item.SelectedIndex != -1)
        {
            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);
            hid_Addmode.Value = "Y";
            DataTable dt = (DataTable)ViewState["myDatatable"];
            dt.Rows[gdv_Item.SelectedIndex].Delete();
            dt.AcceptChanges();
            gdv_Item.DataSource = dt;
            gdv_Item.DataBind();

            if (Convert.ToDouble(hid_Rownumber.Value) > 0)
            {
                hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) - 1);
            }
        }
        GrandTotal();
    }

    private void AddClear()
    {
        dd_FileNo.SelectedValue = "0";
        dd_LC.SelectedValue = "0";
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_FDBP.Text = string.Empty;
        dd_FileNo.Focus();
    }

    private void ProposalTotal()
    {
        if (hid_Proposal_Id.Value != "0")
        {
            float GTotal = 0f;
            for (int i = 0; i < gdv_Proposal.Rows.Count; i++)
            {
                String total = (gdv_Proposal.Rows[i].Cells[11]).Text.Trim();
                GTotal += Convert.ToSingle(total);
            }
            txt_ProposalTotal.Text = GTotal.ToString();
        }
    }


    private void GrandTotal()
    {
        if (hid_Proposal_Id.Value != "0")
        {
            float GTotal = 0.00f;
            for (int i = 0; i < gdv_Item.Rows.Count; i++)
            {
                String total = (gdv_Item.Rows[i].Cells[12]).Text.Trim();
                GTotal += Convert.ToSingle(total);
            }
            txt_TotalPC.Text = String.Format("{0:0,0.00}", GTotal); 
        }
    }

    protected void gdv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_ChildrenInfo_RowDataBound
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
                e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_Item, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception exception)
        {
            //lbl_msg_StaffRequisitionDetails.ForeColor = GlobalVariables.g_clr_errorColor;
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_RowDataBound
    }

    protected void gdv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region gdv_ChildrenInfo_SelectedIndexChanged
        try
        {

            hid_autoId.Value = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());
            dd_FileNo.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[3].Text.ToString());
            dd_LC.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());
            dd_Invoice.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[8].Text.ToString());
            txt_FDBP.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[7].Text.ToString());
            txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[10].Text.ToString());
            txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[11].Text.ToString());
            txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[12].Text.ToString());
            
            hid_Addmode.Value = "N";
            btn_save.Text = "Update";
            dd_Invoice.Focus();

        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }


    private void RefreshMode()
    {
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_FDBP.Text = string.Empty;
        //txt_Rate.Text = string.Empty;
        dd_LC.SelectedValue = "0";

    }


    protected void dd_LC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dd_LC.SelectedValue != "0")
        {
            CommonFunctions commonfunctions = new CommonFunctions();

            string qry = string.Empty;
            qry = "Proc_Invoice_Load_BY_LC '" + dd_LC.SelectedValue + "'";
            commonfunctions.g_b_FillDropDownListByQurey(dd_Invoice, qry);
        }
    }




    protected void dd_Invoice_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (dd_Invoice.SelectedValue != "0")
        {
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_Select_returnValue = string.Empty;

            s_select = "[Proc_InvoiceWise_Value_Select]"
                       + "'"
                       + dd_Invoice.SelectedValue
                       + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        //txt_buyer.Text = drow["Buyer"].ToString();
                        txt_InvoiceValue.Text = drow["InvoiceValue"].ToString();
                    }
                }
            }
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {

        Connection connection = new Connection();
        DataTable dt = (DataTable)ViewState["myDatatable"];
        string SessionUserId = string.Empty;
        string SessionCompanyId = string.Empty;
        SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
        SessionCompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

        string s_returnValue = string.Empty;
        string s_save_ = string.Empty;
        string s_Update_returnValue = string.Empty;
        string s_Update = string.Empty;

        Boolean b_validationReturn = true;

        b_validationReturn = isValid();

        if (b_validationReturn == false)
        {
            return;
        }


        if (btn_save.Text == "Update")
        {
            s_Update = "[Proc_CM_Approval_UPDATE]"
            + "'"
            + hid_autoId.Value
            + "','"
            + dd_FileNo.SelectedValue
            + "','"
            + dd_LC.SelectedValue
            + "','"
            + dd_Invoice.SelectedValue
            + "','"
            + HttpUtility.HtmlDecode(txt_FDBP.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_Rate.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_AmountDollar.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_AmountTK.Text.Trim())
            + "','"
            + Convert.ToDateTime(DateTime.Now.ToString(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + Convert.ToDateTime(txtExpiryDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + SessionUserId
            + "','"
            + SessionCompanyId
            + "'";


            s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, true);

            if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_Update_returnValue == GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    //lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                    string message = "FDBP No Already Exists!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                }
                else
                {
                    //lblMsg.Text = GlobalVariables.g_s_updateOperationSuccessfull;
                    string message = "Update Successfull!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                    InsertMode();
                }
            }
        }
        else
        {
            s_save_ = "[Proc_CM_Approval_Insert]"
                    + "'"
                    + dd_Proposal.SelectedValue
                    + "','"
                    + HttpUtility.HtmlDecode(txt_FDBP.Text.Trim())
                    + "','"
                    + dd_FileNo.SelectedValue
                    + "','"
                    + dd_LC.SelectedValue
                    + "','"
                    + dd_Invoice.SelectedValue
                    + "','"
                    + HttpUtility.HtmlDecode(txt_Rate.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_AmountDollar.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_AmountTK.Text.Trim())
                    + "','"
                    + Convert.ToDateTime(DateTime.Now.ToString(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + Convert.ToDateTime(txtExpiryDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + SessionUserId
                    + "','"
                    + SessionCompanyId
                    + "'";

            s_returnValue = connection.connection_DB(s_save_, 1, true, true, true);

            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    //lblMsg.Text = GlobalVariables.g_s_insertOperationSuccessfull;
                    string message = "Saved Successfull!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                    InsertMode();
                }
                else
                {
                    //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                    string message = "PC No Already Exists!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                }

            }
            else
            {
                //lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                string message = "Operation Failed!";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

            }

        }


    }

  
  
    private void LoadProposal()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as ExportId,'' as FileNo,'' as InvoiceNo,'' as InvoiceValue,'' as CM_Taka,'' as Rate,'' as CM_Dolar,'' as LCValue,'' as LCNO ,'' as AutoId, '' as FileId,'' as LCId ", sqlconnection);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_Proposal.DataSource = ds;
            gdv_Proposal.DataBind();
            int columncount = gdv_Proposal.Rows[0].Cells.Count;
            gdv_Proposal.Rows[0].Cells.Clear();
            gdv_Proposal.Rows[0].Cells.Add(new TableCell());
            gdv_Proposal.Rows[0].Cells[0].ColumnSpan = columncount;
        }
        else
        {
            gdv_Proposal.DataSource = ds;
            gdv_Proposal.DataBind();
        }

        sqlconnection.Close();
    }

    private void LoadAcceptaince()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as FileNo,'' as InvoiceId,'' as FDBP_No,'' as PCNO,'' as InvoiceNo,'' as InvoiceValue,'' as CMDolar,'' as Rate,'' as CMTaKa,'' as LCValue,'' as LCNO ,'' as OpenDate, '' as ExpiryDate,'' as AutoId, '' as FileId,'' as LCId ", sqlconnection);

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

    private Boolean isrequired_Detail()
    {
        if (dd_FileNo.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "File Can Not Blank!";
            return false;
        }

        if (dd_LC.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "LC Can Not Blank!";
            return false;
        }

        if (txt_FDBP.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "PC No Can Not Blank!";
            return false;
        }

        if (txt_Rate.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Rate Can Not Blank!";
            return false;
        }

        if (txt_AmountDollar.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Doler Can Not Blank!";
            return false;
        }

        return true;
    }


    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
    }


    private void InsertMode()
    {
        dd_FileNo.SelectedValue = "0";
        dd_LC.SelectedValue = "0";
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_FDBP.Text = string.Empty;
        dd_FileNo.Focus();
        txt_ProposalTotal.Text = "0";
        txt_TotalPC.Text = "0";

        gdv_Proposal.DataSource = null;
        gdv_Proposal.DataBind();

        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

       
        //hid_Rownumber.Value = "0";
        //btn_save.Text = "Save";
        //LoadProposal();
      
    }
    private Boolean isValid()
    {
        if (dd_Proposal.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Proposal Can Not Blank!!";
            return false;
        }

        if (dd_FileNo.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "File Can Not Blank!";
            return false;
        }

        if (dd_LC.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "LC Can Not Blank!";
            return false;
        }

        if (txt_FDBP.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "PC No Can Not Blank!";
            return false;
        }

        if (txt_Rate.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Rate Can Not Blank!";
            return false;
        }

        if (txt_AmountDollar.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Doler Can Not Blank!";
            return false;
        }

       
        //if (hid_Rownumber.Value == "0")
        //{
        //    string message = "Item Grid Can Not Blank!";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

        //    return false;
        //}

        return true;
    }


  
    protected void btn_Search_Click(object sender, EventArgs e)
    {

        InsertMode();
        LoadAcceptaince();

        lblMsg.Text = string.Empty;
        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;
        
        hid_Proposal_Id.Value = dd_Proposal.SelectedValue;

        if (hid_Proposal_Id.Value != "0")
        {
            //============= Proposal Details====================
            s_select = "[Proc_CM_Proposal_Load]"
                        + "'"
                        + hid_Proposal_Id.Value
                        + "'";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables[0] != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        this.gdv_Proposal.DataSource = connection.ResultsDataSet.Tables[0];
                        this.gdv_Proposal.DataBind();
                        ProposalTotal();
                    }
                }
            }

            //============= Acceptance Details====================
            s_select = "[Proc_CM_Approval_Select]"
                        + "'"
                        + hid_Proposal_Id.Value
                        + "'";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables[0] != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        this.gdv_Item.DataSource = connection.ResultsDataSet.Tables[0];
                        this.gdv_Item.DataBind();

                        GrandTotal();
                    }  
                }
            }
        }
    }

    protected void btn_Preview_Click(object sender, EventArgs e)
    {
       

    }
    

}
