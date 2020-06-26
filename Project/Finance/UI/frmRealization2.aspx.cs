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
using System.Data.OleDb;

using System.Web.Services;
using System.Collections.Generic;

public partial class Finance_UI_frmRealization2 : System.Web.UI.Page
{
    string Addmode = string.Empty;
    string BuyerAutoId = string.Empty;
    string CostingHeadAutoId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunctions commonfunctions = new CommonFunctions();
            CostingHeadAutoId = "0";

            commonfunctions.g_b_FillDropDownList(dd_Search,
                "TBL_Realization",
                "Number",
                "Realization_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_FileNo,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_AccountHead,
                "T_Distribution_Account_Head",
                "Accounts_Head",
                "Accounts_Id", string.Empty);

            txtIssueDate.Text = DateTime.Now.ToString();
            //txt_FDBPDate.Text = DateTime.Now.ToString();

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);
            BuyerAutoId = "0";
            //v_loadGridView_Order();
            v_loadGridView_Item();
            v_loadGridView_Disbursement();
            
            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDatatable"] = myDt;

            DataTable myDt_Distribution = new DataTable();
            myDt_Distribution = CreateDataTable_Distribution();
            ViewState["myDatatable_Distribution"] = myDt_Distribution;

            
        }
    }

    private void v_loadGridView_Disbursement()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as AccountId,'' as AccountHead,'' as Rate,'' as AmountDollar,'' as AmountTk, '' as Remarks   From TBL_ProformaInvoice Where PI_AutoId=0", sqlconnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_Distribution.DataSource = ds;
            gdv_Distribution.DataBind();
            int columncount = gdv_Distribution.Rows[0].Cells.Count;
            gdv_Distribution.Rows[0].Cells.Clear();
            gdv_Distribution.Rows[0].Cells.Add(new TableCell());
            gdv_Distribution.Rows[0].Cells[0].ColumnSpan = columncount;
            //gdv_Item.Rows[0].Cells[0].Text = "No Records Found";

        }
        else
        {
            gdv_Distribution.DataSource = ds;
            gdv_Distribution.DataBind();
        }
        sqlconnection.Close();
    }


    private void v_loadGridView_Item()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as Export_Id,'' as Invoice_No,'' as Invoice_Date, '' as Amount From TBL_ProformaInvoice Where PI_AutoId=0", sqlconnection);
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
            //gdv_Item.Rows[0].Cells[0].Text = "No Records Found";

        }
        else
        {
            gdv_Item.DataSource = ds;
            gdv_Item.DataBind();
        }
        sqlconnection.Close();
    }

    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("Export_Id", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Invoice_No", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Invoice_Date", typeof(DateTime)));
        myDataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
        return myDataTable;
    }

    private void AddDataToTable(string Export_Id,
                              string Invoice_No,
                              string Invoice_Date,
                              string Amount,
                              DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["Export_Id"] = Export_Id;
        row["Invoice_No"] = Invoice_No;
        row["Invoice_Date"] = Invoice_Date;
        row["Amount"] = Amount;
        myTable.Rows.Add(row);
    }



    private Boolean isrequired_Distribution()
    {
        if (dd_AccountHead.SelectedValue == "0")
        {
            lblsubmsgDistribution.Visible = true;
            lblsubmsgDistribution.Text = "Account Head Blank!";
            return false;
        }

        if (txt_Rate.Text == "" || txt_Rate.Text == "0")
        {
            lblsubmsgDistribution.Visible = true;
            lblsubmsgDistribution.Text = "Rate Blank!";
            return false;
        }

        if (txt_AmountDollar.Text == "" || txt_AmountDollar.Text == "0")
        {
            lblsubmsgDistribution.Visible = true;
            lblsubmsgDistribution.Text = "Amount($) Blank!";
            return false;
        }
        if (txt_AmountTK.Text == "" || txt_AmountTK.Text == "0")
        {
            lblsubmsgDistribution.Visible = true;
            lblsubmsgDistribution.Text = "Amount(Tk) Blank!";
            return false;
        }

        return true;
    }


    protected void btnDisburse_Add_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        Boolean b_required = true;
        lblsubmsgDistribution.Visible = false;
        b_required = isrequired_Distribution();
        if (b_required == false)
        {
            return;
        }

        if (hid_Addmode_Distribution.Value == "N")
        {
            btnDisburse_Del_Click(sender, e);
        }
        hid_Addmode_Distribution.Value = "Y";

        /// For Duplicate Checking
        foreach (GridViewRow dr in gdv_Distribution.Rows)
        {
            if (dr.Cells[1].Text == dd_AccountHead.SelectedValue)
            {
                lblsubmsgDistribution.Visible = true;
                lblsubmsgDistribution.Text = "Already Added!";
                return;
            }
        }

        string AccountId = string.Empty;
        string AccountHead = string.Empty;
        string Rate = string.Empty;
        string AmountDollar = string.Empty;
        string AmountTk = string.Empty;
        string Remarks = string.Empty;

        AccountId = dd_AccountHead.SelectedValue.ToString();
        AccountHead = dd_AccountHead.SelectedItem.ToString();
        Rate = txt_Rate.Text.ToString();
        AmountDollar = txt_AmountDollar.Text.ToString();
        AmountTk = txt_AmountTK.Text.ToString();
        Remarks = txt_DistributionRemarks.Text.ToString();

        DataTable myDatatable_Distribution = (DataTable)ViewState["myDatatable_Distribution"];
        AddDataToTable_Distribution(AccountId
                                    , AccountHead
                                    , Rate
                                    , AmountDollar
                                    , AmountTk
                                    , Remarks
                                    , (DataTable)ViewState["myDatatable_Distribution"]
                                 );

        this.gdv_Distribution.DataSource = ((DataTable)ViewState["myDatatable_Distribution"]).DefaultView;
        this.gdv_Distribution.DataBind();

        hid_DistributionRow.Value = Convert.ToString(Convert.ToDouble(hid_DistributionRow.Value) + 1);

        AddClear();
    }

    protected void btnDisburse_Del_Click(object sender, EventArgs e)
    {

        if (gdv_Distribution.SelectedIndex != -1)
        {
            hid_Addmode_Distribution.Value = "N";
            DataTable dt = (DataTable)ViewState["myDatatable_Distribution"];
            dt.Rows[gdv_Distribution.SelectedIndex].Delete();
            dt.AcceptChanges();
            gdv_Distribution.DataSource = dt;
            gdv_Distribution.DataBind();

            if (Convert.ToDouble(hid_DistributionRow.Value) > 0)
            {
                hid_DistributionRow.Value = Convert.ToString(Convert.ToDouble(hid_DistributionRow.Value) - 1);
            }
        }
    }


    private DataTable CreateDataTable_Distribution()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("AccountId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("AccountHead", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("AmountDollar", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("AmountTk", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
        return myDataTable;
    }



    private void AddDataToTable_Distribution(string AccountId,
                            string AccountHead,
                            string Rate,
                            string AmountDollar,
                            string AmountTk,
                            string Remarks,
                            DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["AccountId"] = AccountId;
        row["AccountHead"] = AccountHead;
        row["Rate"] = Rate;
        row["AmountDollar"] = AmountDollar;
        row["AmountTk"] = AmountTk;
        row["Remarks"] = Remarks;
        myTable.Rows.Add(row);
    }


    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }

    private void InsertMode_Msg()
    {
        lblMsg.Text = string.Empty;
    }

   

    protected void gdv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_Invoice.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[1].Text.ToString());
        hid_Addmode.Value = "N";
    }
    protected void gdv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_Item_RowDataBound
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
        #endregion gdv_Item_RowDataBound

    }

    
    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        String FileId = "0";
        FileId = dd_FileNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_LCNo,
           "TBL_Export_LC",
           "Export_LC_No",
           "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");
    }

    protected void dd_LCNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        String lcId = "0";
        lcId = dd_LCNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_Invoice,
            "TBL_Export",
            "Invoice_No",
            "Export_Id", "WHERE Export_LC_Id='" + lcId + "'");

    }


    protected void txt_AmountDollar_TextChanged(object sender, EventArgs e)
    {
        CommonFunctions.numeric_Validation nV_B = new CommonFunctions.numeric_Validation();

        if (nV_B.numeric_Validation_Decimal_Allow_Minus(txt_Rate.Text, 1) == false)
        {
            txt_Rate.Text = "";
        }

        if (nV_B.numeric_Validation_Decimal_Allow_Minus(txt_AmountDollar.Text, 1) == false)
        {
            txt_AmountDollar.Text = "Error!";
        }
        else
        {
            if (txt_Rate.Text != "" && txt_Rate.Text != "0" && txt_AmountDollar.Text != "" && txt_AmountDollar.Text != "0")
            {
                txt_AmountTK.Text = Convert.ToString(Convert.ToDouble(txt_AmountDollar.Text) * Convert.ToDouble(txt_Rate.Text));
            }
        }
    }
    protected void txt_AmountTK_TextChanged(object sender, EventArgs e)
    {
        CommonFunctions.numeric_Validation nV_B = new CommonFunctions.numeric_Validation();
        if (nV_B.numeric_Validation_Decimal_Allow_Minus(txt_Rate.Text, 1) == false)
        {
            txt_Rate.Text = "";
        }

        if (nV_B.numeric_Validation_Decimal_Allow_Minus(txt_AmountTK.Text, 1) == false)
        {
            txt_AmountTK.Text = "Error!";
        }
        else
        {
            if (txt_Rate.Text != "" && txt_Rate.Text != "0" && txt_AmountTK.Text != "" && txt_AmountTK.Text != "0")
            {
                txt_AmountDollar.Text = Convert.ToString(Math.Round((Convert.ToDouble(txt_AmountTK.Text) / Convert.ToDouble(txt_Rate.Text)), 2));
            }
        }
    }

    protected void gdv_Distribution_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_Distribution_RowDataBound
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
                e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_Distribution, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception exception)
        {
            //lbl_msg_StaffRequisitionDetails.ForeColor = GlobalVariables.g_clr_errorColor;
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_Distribution_RowDataBound
    }
    protected void gdv_Distribution_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_AccountHead.SelectedValue = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[1].Text.ToString());
        txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[3].Text.ToString());
        txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[4].Text.ToString());
        txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[5].Text.ToString());
        txt_DistributionRemarks.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[6].Text.ToString());
        hid_Addmode_Distribution.Value = "N";
    }


    private void InsertMode()
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        dd_FileNo.SelectedValue = "0";
        dd_Search.SelectedValue = "0";
        dd_CollectionType.SelectedValue = "0";

        txt_CollectionNo.Text = string.Empty;
        txtIssueDate.Text = DateTime.Now.ToString();
       // txt_RealizedAmount.Text = string.Empty;
        //txt_FDBPNo.Text = string.Empty;
        //txt_FDBPDate.Text = DateTime.Now.ToString();
        //txt_FDBPAmount.Text = string.Empty;
       // txt_Remarks.Text = string.Empty;

        dd_AccountHead.SelectedValue = "0";
       // dd_ExpenseHead.SelectedValue = "0";
        txt_AmountDollar.Text = string.Empty;
        txt_AmountTK.Text = string.Empty;
        txt_Rate.Text = string.Empty;
        //txt_ExpenseAmount.Text = string.Empty;
        txt_DistributionRemarks.Text = string.Empty;
        //txt_ExpenseRemarks.Text = string.Empty;

        LC_Load();
        Invoice_Load_BY_LC();
        V_LoadmaxSerial();

        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        gdv_Distribution.DataSource = null;
        gdv_Distribution.DataBind();

        commonfunctions.g_b_FillDropDownList(dd_Search,
            "TBL_Realization",
            "Number",
            "Realization_Id", string.Empty);

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        DataTable myDt_Distribution = new DataTable();
        myDt_Distribution = CreateDataTable_Distribution();
        ViewState["myDatatable_Distribution"] = myDt_Distribution;

     
        v_loadGridView_Item();
        v_loadGridView_Disbursement();
      
        hid_InvoiceRow.Value = "0";
        hid_DistributionRow.Value = "0";
        hid_ExpenseRow.Value = "0";
        dd_FileNo.Enabled = true;
        dd_LCNo.Enabled = true;

        btn_save.Text = "Save";
    }


    private void LC_Load()
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        Connection conn = new Connection();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        s_OrderLoadCondition = "SELECT Export_LC_No,Export_LC_Id FROM TBL_Export_LC Where File_Ref_Id="
                         + "'"
                         + dd_FileNo.SelectedValue
                         + "';";


        returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (conn.ResultsDataSet.Tables[0] != null)
            {
                commonfunctions.g_b_FillDropDownList(dd_LCNo, conn.ResultsDataSet.Tables[0], "Export_LC_No",
                                                    "Export_LC_Id");
            }
        }
    }



    private void Invoice_Load_BY_LC()
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        Connection conn = new Connection();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        if (dd_Search.SelectedValue != "0")
        {
            s_OrderLoadCondition = "SELECT Invoice_No,Export_Id FROM TBL_Export Where Export_LC_Id="
                             + "'"
                             + dd_LCNo.SelectedValue
                             + "';";
        }
        else
        {
            s_OrderLoadCondition = "SELECT Invoice_No,Export_Id FROM TBL_Export Where Export_LC_Id="
                             + "'"
                             + dd_LCNo.SelectedValue
                             + "' and FBP_FDBC_No='0';";
        }
        returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (conn.ResultsDataSet.Tables[0] != null)
            {
                commonfunctions.g_b_FillDropDownList(dd_Invoice, conn.ResultsDataSet.Tables[0], "Invoice_No",
                                                    "Export_Id");
            }
        }
    }



    private void V_LoadmaxSerial()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("[Proc_maxSerial] 'Realization','" + Convert.ToDateTime(DateTime.Now, new CultureInfo("fr-FR")).ToString("MM/dd/yyyy") + "'", sqlconnection);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            txt_SlNo.Text = "0001/" + DateTime.Now.Year;
        }
        else
        {
            if (Convert.ToDouble(ds.Tables[0].Rows[0][0]).ToString() == "0")
            {
                txt_SlNo.Text = "0001/" + DateTime.Now.Year;
            }
            else
            {
                txt_SlNo.Text = Convert.ToDouble(ds.Tables[0].Rows[0][0]).ToString("0000") + "/" + DateTime.Now.Year;
            }
        }

        sqlconnection.Close();
    }

    private void AddClear()
    {
        dd_Invoice.SelectedValue = "0";
        dd_AccountHead.SelectedValue = "0";
       // dd_ExpenseHead.SelectedValue = "0";
        txt_Rate.Text = string.Empty;
        txt_DistributionRemarks.Text = string.Empty;
        //txt_ExpenseRemarks.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_AmountTK.Text = string.Empty;
        //txt_ExpenseAmount.Text = string.Empty;
    }

    private Boolean isrequired()
    {
        if (dd_Invoice.SelectedValue == "0")
        {
            lblsubmsg.Visible = true;
            lblsubmsg.Text = "Invoice Blank!";
            return false;
        }

        return true;
    }

    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;


        Boolean b_required = true;
        lblsubmsg.Visible = false;
        b_required = isrequired();
        if (b_required == false)
        {
            return;
        }

        if (hid_Addmode.Value == "N")
        {
            btnDel_Click(sender, e);
        }
        hid_Addmode.Value = "Y";

        /// For Duplicate Checking
        foreach (GridViewRow dr in gdv_Item.Rows)
        {
            if (dr.Cells[1].Text == dd_Invoice.SelectedValue)
            {
                lblsubmsg.Visible = true;
                lblsubmsg.Text = "Already Added!";
                return;
            }
        }
        s_OrderLoadCondition = "[proc_Invoice_Select_For_Realization]"
                             + "'"
                             + dd_Invoice.SelectedValue
                             + "'";

        returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (conn.ResultsDataSet.Tables[0] != null)
            {

                foreach (DataRow drow in conn.ResultsDataSet.Tables[0].Rows)
                {
                    string Export_Id = string.Empty;
                    string Invoice_No = string.Empty;
                    string Invoice_Date = string.Empty;
                    string Amount = string.Empty;

                    Export_Id = drow["Export_Id"].ToString();
                    Invoice_No = drow["Invoice_No"].ToString();
                    Invoice_Date = drow["Invoice_Date"].ToString();
                    Amount = drow["Amount"].ToString();

                    DataTable myDatatable = (DataTable)ViewState["myDatatable"];
                    AddDataToTable(Export_Id
                                , Invoice_No
                                , Invoice_Date
                                , Amount
                                , (DataTable)ViewState["myDatatable"]
                             );

                    this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
                    this.gdv_Item.DataBind();

                    dd_FileNo.Enabled = false;
                    dd_LCNo.Enabled = false;
                    hid_InvoiceRow.Value = Convert.ToString(Convert.ToDouble(hid_InvoiceRow.Value) + 1);
                }
            }
        }
        //AddClear();
    }




    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (gdv_Item.SelectedIndex != -1)
        {
            hid_Addmode.Value = "N";
            DataTable dt = (DataTable)ViewState["myDatatable"];
            dt.Rows[gdv_Item.SelectedIndex].Delete();
            dt.AcceptChanges();
            gdv_Item.DataSource = dt;
            gdv_Item.DataBind();

            if (Convert.ToDouble(hid_InvoiceRow.Value) > 0)
            {
                hid_InvoiceRow.Value = Convert.ToString(Convert.ToDouble(hid_InvoiceRow.Value) - 1);
            }

            if (Convert.ToDouble(hid_InvoiceRow.Value) == 0)
            {
                dd_FileNo.Enabled = true;
                dd_LCNo.Enabled = true;
            }
        }
    }
    

}
