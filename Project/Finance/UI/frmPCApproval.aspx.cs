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

public partial class Finance_UI_frmPCApproval : System.Web.UI.Page
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

           commonfunctions.g_b_FillDropDownList(dd_SearchFile,
              "TBL_Export_LC_FileNo_BTB_Percent",
              "File_Ref_No",
              "File_Ref_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Proposal,
               "TBL_PC_Proposal",
               "SLNo",
               "Proposal_Id", "Order By SLNO DESC");

            LoadProposal();
            LoadAcceptaince();

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);

            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDatatable"] = myDt;

           
        }
    }

   
   
    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("AutoId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("FileId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("FileNo", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCNO", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PcNo", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCValueDolar", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCValueTK", typeof(string)));
        return myDataTable;

    }

    private void AddDataToTable(string autoId,
                               string fileId,
                               string fileNo,
                               string lcId,
                               string lcNo,
                               string pcNo,
                               string rate,
                               string pcValueDolar,
                               string pcValueTK,
                               DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["AutoId"] = autoId;
        row["FileId"] = fileId;
        row["FileNo"] = fileNo;
        row["LCId"] = lcId;
        row["LCNO"] = lcNo;
        row["PcNo"] = pcNo;
        row["Rate"] = rate;
        row["PCValueDolar"] = pcValueDolar;
        row["PCValueTK"] = pcValueTK;
        myTable.Rows.Add(row);
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Connection connection = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();

        Boolean b_required = true;

        // For Requart field Checking
        b_required = isrequired_Detail();

        if (b_required == false)
        {
            return;
        }

        if (hid_Addmode.Value == "N")
        {
            btnDel_Click(sender, e);
        }

        /// For Duplicate Checking
        //foreach (GridViewRow dr in gdv_Item.Rows)
        //{
        //    if (dr.Cells[4].Text == txt_Style.Text.Trim())
        //    {
        //        lblsubmsg.Visible = true;
        //        lblsubmsg.Text = "Style Already Added!";
        //        return;
        //    }
        //}

       
        AddDataToTable("0"
                    , this.dd_FileNo.SelectedValue
                    , this.dd_FileNo.SelectedItem.Text
                    , this.dd_LC.SelectedValue
                    , this.dd_LC.SelectedItem.Text
                    , this.txt_PCNO.Text
                    , this.txt_Rate.Text
                    , this.txt_AmountDollar.Text
                    , this.txt_AmountTK.Text
                    , (DataTable)ViewState["myDatatable"]
                 );

        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        this.gdv_Item.DataBind();
        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);

        //GrandTotal();
        AddClear();
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
        txt_BTB.Text = string.Empty;
        txt_BTBValue.Text = string.Empty;
        txt_LCValue.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_PCNO.Text = string.Empty;
        txt_PCValue.Text = string.Empty;
        dd_FileNo.Focus();
    }

    private void ProposalTotal()
    {
        if (hid_Proposal_Id.Value != "0")
        {
            float GTotal = 0.00f;
            for (int i = 0; i < gdv_Proposal.Rows.Count; i++)
            {
                String total = (gdv_Proposal.Rows[i].Cells[8]).Text.Trim();
                GTotal += Convert.ToSingle(total);
            }
            txt_ProposalTotal.Text = String.Format("{0:0,0.00}", GTotal); 
        }
    }


    private void GrandTotal()
    {
        if (hid_Proposal_Id.Value != "0")
        {
            float GTotal = 0.00f;
            for (int i = 0; i < gdv_Item.Rows.Count; i++)
            {
                String total = (gdv_Item.Rows[i].Cells[10]).Text.Trim();
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
            dd_FileNo_SelectedIndexChanged(sender, e);

            dd_LC.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());
            dd_LC_SelectedIndexChanged(sender, e);

            //txt_LCValue.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());
            txt_PCNO.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[7].Text.ToString());
            txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[8].Text.ToString());

            txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[9].Text.ToString());
            txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[10].Text.ToString());
            
            hid_Addmode.Value = "N";
            btn_save.Text = "Update";

        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }


    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshMode();

        CommonFunctions commonfunctions = new CommonFunctions();
        String FileId = "0";
        FileId = dd_FileNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_LC,
           "TBL_Export_LC",
           "Export_LC_No",
           "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");
    }

    private void RefreshMode()
    {
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_BTB.Text = string.Empty;
        txt_BTBValue.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_PCNO.Text = string.Empty;
        txt_PCValue.Text = string.Empty;
        //txt_Rate.Text = string.Empty;
        txt_LCValue.Text = string.Empty;
        dd_LC.SelectedValue = "0";

    }


    protected void dd_LC_SelectedIndexChanged(object sender, EventArgs e)
    {

        ExportLCValue_Load();
    }


    private void ExportLCValue_Load()
    {
        if (dd_LC.SelectedValue != "0")
        {
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_Select_returnValue = string.Empty;

            s_select = "[Proc_MasterLCWise_Value_Select]"
                       + "'"
                       + dd_LC.SelectedValue
                       + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        txt_LCValue.Text = drow["LC_Value"].ToString();
                        txt_BTB.Text = drow["BTB_Parcent"].ToString();
                        txt_PC.Text = drow["PC_Parcent"].ToString();
                        txt_BTBValue.Text = drow["BTB_Value"].ToString();
                        txt_PCValue.Text = drow["PC_Value"].ToString();
                       // txt_PCBalance.Text = drow["PC_Balance"].ToString();
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
            s_Update = "[Proc_PC_Proposal_Acceptance_UPDATE]"
            + "'"
            + hid_autoId.Value
            + "','"
            + dd_Proposal.SelectedValue
            + "','"
            + HttpUtility.HtmlDecode(txt_PCNO.Text.Trim())
            + "','"
            + dd_FileNo.SelectedValue
            + "','"
            + dd_LC.SelectedValue
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
                    string message = "PC No Already Exists!";
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
            s_save_ = "[Proc_PC_Proposal_Acceptance_Insert]"
                    + "'"
                    + dd_Proposal.SelectedValue
                    + "','"
                    + HttpUtility.HtmlDecode(txt_PCNO.Text.Trim())
                    + "','"
                    + dd_FileNo.SelectedValue
                    + "','"
                    + dd_LC.SelectedValue
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

        SqlCommand cmd = new SqlCommand("SELECT '' as FileNo,'' as PCValueTK,'' as Rate,'' as PCValueDolar,'' as LCValue,'' as LCNO ,'' as AutoId, '' as FileId,'' as LCId ", sqlconnection);

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

        SqlCommand cmd = new SqlCommand("SELECT '' as FileNo,'' as PCNO,'' as PCValueTK,'' as Rate,'' as PCValueDolar,'' as LCValue,'' as LCNO ,'' as OpenDate, '' as ExpiryDate,'' as AutoId, '' as FileId,'' as LCId ", sqlconnection);

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

        if (txt_PCNO.Text == "")
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
        txt_BTB.Text = string.Empty;
        txt_BTBValue.Text = string.Empty;
        txt_LCValue.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_PCNO.Text = string.Empty;
        txt_PCValue.Text = string.Empty;
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

        if (txt_PCNO.Text == "")
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
            s_select = "[Proc_PC_Proposal_Load]"
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
            s_select = "[Proc_PC_Acceptance_Search]"
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
        try
        {

           // Boolean b_validationReturn = true;

           // lblMsg.Visible = false;
           // b_validationReturn = isValid();

           // if (b_validationReturn == false)
           // {
           //     return;
           // }

           // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
           // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
           // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString());
           // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString());
           // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "PC Proposal");

            //// TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\RPT_PC_Proposal.rpt";

           // TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_PC_Details_Sheet"
           //                                              + "'"
           //                                              //+ hid_ProposalId.Value
           //                                              + "'";

           // Response.Redirect(GlobalVariables.g_s_URL_reportViewer);


        }

        catch (Exception)
        {

        }

    }

    protected void btn_Button1_Click(object sender, EventArgs e)
    {

        InsertMode();
        LoadAcceptaince();

        lblMsg.Text = string.Empty;
        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        hid_FileId.Value = dd_SearchFile.SelectedValue;

        if (hid_FileId.Value != "0")
        {
            //============= Proposal Details====================
            s_select = "[Proc_PC_Proposal_Searching]"
                        + "'"
                        + hid_FileId.Value
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
            s_select = "[Proc_PC_Approval_Search]"
                        + "'"
                        + hid_FileId.Value
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
    

}
