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

public partial class Finance_UI_frmCMProposal : System.Web.UI.Page
{

    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hid_ProposalId.Value = "0";
            hidColorIndex.Value = "N";
            txt_Tax.Text = "1";

            CommonFunctions commonfunctions = new CommonFunctions();
            txtIssueDate.Text = DateTime.Now.ToString();

           commonfunctions.g_b_FillDropDownList(dd_FileNo,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

           commonfunctions.g_b_FillDropDownList(dd_Search,
                "TBL_CM_Proposal",
                "SLNo",
                "Proposal_Id", "Order By SLNO DESC");

            btn_save.Text = "Save";

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);

            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDatatable"] = myDt;

            maxSerial();
            v_loadGridView_Item();
            hidAutoId.Value = "0";
           
        }
    }


    private void Invoice_Load()
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        Connection conn = new Connection();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        hid_LcId.Value = dd_LC.SelectedValue;

        if (dd_Search.SelectedValue == "0")
        {
            s_OrderLoadCondition = "[Proc_ExportedInvoice_Load]"
                             + "'"
                             + hid_LcId.Value
                             + "','"
                             + "Y"
                             + "'";
        }
       
        else
        {
            s_OrderLoadCondition = "[Proc_ExportedInvoice_Load]"
                             + "'"
                             + hid_LcId.Value
                             + "','"
                             + "N"
                             + "'";
        }

        returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (conn.ResultsDataSet.Tables[0] != null)
            {
                commonfunctions.g_b_FillDropDownList(dd_Invoice, conn.ResultsDataSet.Tables[0], "ItemName", "ItemId");
            }
        }
 
    }


    protected void txt_BTBOpened_TextChanged(object sender, EventArgs e)
    {
        TextBox9.Text = "0";

        CommonFunctions.numeric_Validation numeric_Validation = new CommonFunctions.numeric_Validation();
        if (numeric_Validation.numeric_Validation_Decimal_Allow_Minus(txt_BTBOpened.Text, 1) == false)
        {
            txt_BTBOpened.Text = "Error!";
        }
        else
        {
            if (txt_BTBOpened.Text != "" && txt_BTBOpened.Text != "0" && txt_FileValue.Text != "" && txt_FileValue.Text != "0")
            {
                string Value = Convert.ToString(Convert.ToDouble(txt_BTBOpened.Text) * 100 / Convert.ToDouble(txt_FileValue.Text));
                TextBox9.Text = Convert.ToString(Convert.ToDecimal(Value).ToString("####.00"));

            }
        }
    }

    protected void txt_PCOpened_TextChanged(object sender, EventArgs e)
    {
        TextBox8.Text = "0";

        CommonFunctions.numeric_Validation numeric_Validation = new CommonFunctions.numeric_Validation();
        if (numeric_Validation.numeric_Validation_Decimal_Allow_Minus(txt_PCOpened.Text, 1) == false)
        {
            txt_PCOpened.Text = "Error!";
        }
        else
        {
            if (txt_PCOpened.Text != "" && txt_PCOpened.Text != "0" && txt_FileValue.Text != "" && txt_FileValue.Text != "0")
            {
                string Value = Convert.ToString(Convert.ToDouble(txt_PCOpened.Text) * 100 / Convert.ToDouble(txt_FileValue.Text));
                TextBox8.Text = Convert.ToString(Convert.ToDecimal(Value).ToString("####.00"));
            }
        }
    }

    protected void txt_CommissionOpen_TextChanged(object sender, EventArgs e)
    {
        TextBox7.Text = "0";

        CommonFunctions.numeric_Validation numeric_Validation = new CommonFunctions.numeric_Validation();
        if (numeric_Validation.numeric_Validation_Decimal_Allow_Minus(txt_CommissionOpen.Text, 1) == false)
        {
            txt_CommissionOpen.Text = "Error!";
        }
        else
        {
            if (txt_CommissionOpen.Text != "" && txt_CommissionOpen.Text != "0" && txt_FileValue.Text != "" && txt_FileValue.Text != "0")
            {
                string Value = Convert.ToString(Convert.ToDouble(txt_CommissionOpen.Text) * 100 / Convert.ToDouble(txt_FileValue.Text));
                TextBox7.Text = Convert.ToString(Convert.ToDecimal(Value).ToString("####.00"));
            }
        }
    }

    protected void txt_CM_TextChanged(object sender, EventArgs e)
    {
        txt_CMDolar.Text = "0";

        CommonFunctions.numeric_Validation numeric_Validation = new CommonFunctions.numeric_Validation();
        if (numeric_Validation.numeric_Validation_Decimal_Allow_Minus(txt_CM.Text, 1) == false)
        {
            txt_CM.Text = "Error!";
        }
        else
        {
            if (txt_CM.Text != "" && txt_CM.Text != "0" && txt_InvoiceValue.Text != "" && txt_InvoiceValue.Text != "0")
            {
                txt_CMDolar.Text = Convert.ToString(Convert.ToDouble(txt_InvoiceValue.Text) * Convert.ToDouble(txt_CM.Text) / 100);
            }
        }
    }

    private void maxSerial()
    {
        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        s_select = "Proc_Max_SerialNo 'CMProposal'";
        s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
        if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (connection.ResultsDataSet.Tables != null)
            {
                foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                {
                    txt_SLNo.Text = drow["SLNo"].ToString();
                }
            }
        }

    }

    private void v_loadGridView_Item()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as AutoId,'' as FileId ,'' as Rate,'' as CMDolar,'' as CMTK,'' as LCId,'' as PC,'' as InvoiceId,'' as InvoiceNo,'' as InvoiceValue,'' as FileId,'' as LCNO, '' as LCValue,'' as BTB,'' as PC,'' as SourchTax,'' as BankCharge,'' as PCIntarest, '' as Commission,'' as CM ", sqlconnection);

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


    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("AutoId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("FileId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCNO", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCValue", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("InvoiceId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("InvoiceNo", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("InvoiceValue", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("BTB", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PC", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Commission", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("BankCharge", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCIntarest", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("SourchTax", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("CM", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("CMDolar", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("CMTK", typeof(string)));
        return myDataTable;
       
    }

     private void AddDataToTable(string autoId,
                                string fileId,
                                string lcId,
                                string lcNo,
                                string lcValue,
                                string InvoiceId,
                                string InvoiceNo,
                                string InvoiceValue,
                                string btb,
                                string pc,
                                string Commission,
                                string BankCharge,
                                string PCIntarest,
                                string SourchTax,
                                string CM,
                                string CMDolar,
                                string Rate,
                                string CMTK, 
                                DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["AutoId"] = autoId;
        row["FileId"] = fileId;
        row["LCId"] = lcId;
        row["LCNO"] = lcNo;
        row["LCValue"] = lcValue;
        row["InvoiceId"] = InvoiceId;
        row["InvoiceNo"] = InvoiceNo;
        row["InvoiceValue"] = InvoiceValue;
        row["BTB"] = btb;
        row["PC"] = pc;
        row["Commission"] = Commission;
        row["BankCharge"] = BankCharge;
        row["PCIntarest"] = PCIntarest;
        row["SourchTax"] = SourchTax;
        row["CM"] = CM;
        row["CMDolar"] = CMDolar;
        row["Rate"] = Rate;
        row["CMTK"] = CMTK; 
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

         //For Duplicate Checking
        foreach (GridViewRow dr in gdv_Item.Rows)
        {
            if (dr.Cells[7].Text == dd_Invoice.SelectedValue)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Invoice Already Added!";
                return;
            }
        }


        string fileId = string.Empty;
        string LcId = string.Empty;
        string LcNo = string.Empty;
        string invoiceId = string.Empty;
        string invoiceNo = string.Empty;
        string invoiceValue = string.Empty;
        string btb = string.Empty;
        string pc = string.Empty;
        string Commission = string.Empty;
        string BankCharge = string.Empty;
        string PCIntarest = string.Empty;
        string rate = string.Empty;
        string AmountDollar = string.Empty;
        string AmountTK = string.Empty;
        string cm = string.Empty;
        string tax = string.Empty;
        string LcValue = string.Empty;


        fileId = dd_FileNo.SelectedValue;
        LcId = dd_LC.SelectedValue;
        LcNo = dd_LC.SelectedItem.Text;
        LcValue = txt_InvoiceValue.Text;
        invoiceId = dd_Invoice.SelectedValue;
        invoiceNo = dd_Invoice.SelectedItem.Text;
        invoiceValue = txt_InvoiceValue.Text;

        btb = txt_BTB.Text;
        pc = txt_PC.Text;
        Commission = txt_Commission.Text;
        BankCharge = txt_BankCharge.Text;
        PCIntarest = txt_PCIntarest.Text;
        tax = txt_Tax.Text;
        cm = txt_CM.Text;
        AmountDollar = txt_AmountDollar.Text;
        rate = txt_Rate.Text;
        AmountTK = txt_AmountTK.Text;


        if (btb == "")
        {
            btb = "0";
        }
        if (pc == "")
        {
            pc = "0";
        }
        if (Commission == "")
        {
            Commission = "0";
        }
        if (BankCharge == "")
        {
            BankCharge = "0";
        }

        if (PCIntarest == "")
        {
            PCIntarest = "0";
        }
        if (AmountDollar == "")
        {
            AmountDollar = "0";
        }
        if (rate == "")
        {
            rate = "0";
        }
        if (AmountTK == "")
        {
            AmountTK = "0";
        }
       

        AddDataToTable(hidAutoId.Value
                    , fileId
                    , LcId
                    , LcNo
                    , LcValue
                    , invoiceId
                    , invoiceNo
                    , invoiceValue
                    , btb
                    , pc
                    , Commission
                    , BankCharge
                    , PCIntarest
                    , tax
                    , cm
                    , AmountDollar
                    , rate
                    , AmountTK
                    , (DataTable)ViewState["myDatatable"]
                 );

        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        this.gdv_Item.DataBind();
        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);

        hid_ProposalId.Value = "0";
        hidColorIndex.Value = "N";

        GrandTotal();
        ClearMode();
    }


    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (hidColorIndex.Value != "B" && gdv_Item.SelectedIndex != -1)
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

    private void InsertMode_Msg()
    {
        lblMsg.Text = string.Empty;
    }

    private void ClearMode()
    {
        dd_FileNo.SelectedValue = "0";
        dd_LC.SelectedValue = "0";
        dd_Invoice.SelectedValue = "0";
        dd_FileNo.Focus();

        txt_BTBLimite.Text = string.Empty;
        txt_PCLimit.Text = string.Empty;
        txt_CommissionOpen.Text = string.Empty;
        txt_BTBOpened.Text = string.Empty;
        txt_PCOpened.Text = string.Empty;
        txt_BTB1.Text = string.Empty;
        txt_PC1.Text = string.Empty;
        TextBox9.Text = string.Empty;
        TextBox8.Text = string.Empty;
        TextBox7.Text = string.Empty;

        txt_BTB.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_CM.Text = string.Empty;
        txt_Commission.Text = string.Empty;
        txt_PCIntarest.Text = string.Empty;
        txt_BankCharge.Text = string.Empty;
        txt_CMDolar.Text = string.Empty;

        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_CM.Text = string.Empty;
        txt_FileValue.Text = string.Empty;
        txt_InvoiceValue.Text = string.Empty;

    }


    private void InsertMode()
    {
        dd_FileNo.SelectedValue = "0";
        dd_LC.SelectedValue = "0";
        dd_Invoice.SelectedValue = "0";
        dd_FileNo.Focus();

        txt_BTBLimite.Text = string.Empty;
        txt_PCLimit.Text = string.Empty;
        txt_CommissionOpen.Text = string.Empty;
        txt_BTBOpened.Text = string.Empty;
        txt_PCOpened.Text = string.Empty;
        txt_BTB1.Text = string.Empty;
        txt_PC1.Text = string.Empty;
        TextBox9.Text = string.Empty;
        TextBox8.Text = string.Empty;
        TextBox7.Text = string.Empty;

        txt_BTB.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_CM.Text = string.Empty;
        txt_Commission.Text = string.Empty;
        txt_PCIntarest.Text = string.Empty;
        txt_BankCharge.Text = string.Empty;
        txt_CMDolar.Text = string.Empty;

        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_CM.Text = string.Empty;
        txt_FileValue.Text = string.Empty;
        txt_InvoiceValue.Text = string.Empty;


        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        v_loadGridView_Item();

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        hid_Rownumber.Value = "0";
        btn_save.Text = "Save";
        maxSerial();

        CommonFunctions commonfunctions = new CommonFunctions();
        commonfunctions.g_b_FillDropDownList(dd_Search,
               "TBL_CM_Proposal",
               "SLNo",
               "Proposal_Id", "Order By SLNO DESC");

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
        
        if (dd_Invoice.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Invoice Can Not Blank!";
            return false;
        }

        if (txt_CMDolar.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "CM Can Not Blank!";
            return false;
        }

        if (txt_CM.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "CM Can Not Blank!";
            return false;
        }


        return true;
    }



    private Boolean isrequired()
    {

        if (hid_Rownumber.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Item Grid Can Not Blank!";
            return false;
        }

        //if (txt_Delivary.Text == "")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Delivery To Can Not Blank!";
        //    return false;
        //}

        return true;
    }


    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        File_Wise_Value_Load();
        txt_BTBOpened_TextChanged(sender, e);
        txt_PCOpened_TextChanged(sender, e);
        txt_CommissionOpen_TextChanged(sender, e);

        CommonFunctions commonfunctions = new CommonFunctions();
        String FileId = "0";
        FileId = dd_FileNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_LC,
           "TBL_Export_LC",
           "Export_LC_No",
           "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");

    }

    protected void dd_LC_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ExportLCValue_Load();
        Invoice_Load();
    }


    private void File_Wise_Value_Load()
    {
        if (dd_FileNo.SelectedValue != "0")
        {
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_Select_returnValue = string.Empty;

            s_select = "[Proc_File_Wise_Value]"  
                       + "'"
                       + dd_FileNo.SelectedValue
                       + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        txt_buyer.Text = drow["Buyer"].ToString();
                        txt_FileValue.Text = drow["File_Value"].ToString();
                        txt_BTB1.Text = drow["BTB_Parcent"].ToString();
                        txt_PC1.Text = drow["PC_Parcent"].ToString();
                        txt_BTBLimite.Text = drow["BTB_Value"].ToString();
                        txt_PCLimit.Text = drow["PC_Value"].ToString();
                        txt_BTBOpened.Text = drow["BTB_Opened"].ToString();
                        txt_PCOpened.Text = drow["PC_Opened"].ToString();
                        txt_CommissionOpen.Text = drow["AgentCommission"].ToString();
                    }
                }
            }

            //CommonFunctions commonfunctions = new CommonFunctions();
            //String LcId = "0";
            //LcId = dd_LC.SelectedValue;

            //commonfunctions.g_b_FillDropDownList(dd_Invoice,
            //   "TBL_Export",
            //   "Invoice_No",
            //   "Export_Id", "WHERE Export_LC_Id='" + LcId + "'");

            //if (dd_LC.SelectedValue != "0")
            //{
            //    CommonFunctions commonfunctions = new CommonFunctions();

            //    string qry = string.Empty;
            //    qry = "Proc_ExportedInvoice_Load";
            //    commonfunctions.g_b_FillDropDownListByQurey(dd_Invoice, qry);
            //}

        }

    }

    private void ExportLCValue_Load()
    {
        if (dd_LC.SelectedValue != "0")
        {
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_Select_returnValue = string.Empty;

            s_select = "[Proc_MasterLCWise_Value]"  
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
                        //txt_LCValue.Text = drow["LC_Value"].ToString();
                    }
                }
            }

            //CommonFunctions commonfunctions = new CommonFunctions();
            //String LcId = "0";
            //LcId = dd_LC.SelectedValue;

            //commonfunctions.g_b_FillDropDownList(dd_Invoice,
            //   "TBL_Export",
            //   "Invoice_No",
            //   "Export_Id", "WHERE Export_LC_Id='" + LcId + "'");



            //if (dd_LC.SelectedValue != "0")
            //{
            //    CommonFunctions commonfunctions = new CommonFunctions();

            //    string qry = string.Empty;
            //    qry = "Proc_ExportedInvoice_Load";
            //    commonfunctions.g_b_FillDropDownListByQurey(dd_Invoice, qry);
            //}

            Invoice_Load();

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
                        txt_InvoiceValue.Text = drow["InvoiceValue"].ToString();
                        //lblInvoiceValue.Text = drow["InvoiceValue"].ToString();
                    }
                }
            }
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
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_trStatus = string.Empty;
            string s_Select_returnValue = string.Empty;

            lblMsg.Text = string.Empty;
            s_trStatus = string.Empty;

            hidColorIndex.Value = "N";

            string fileId = string.Empty;
            hid_ExportId.Value = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());


            if (hid_ProposalId.Value != "0")
            {
                s_select = "[Proc_Select_InvoiceNo_From_Approval]"
                             + "'"
                             + hid_ExportId.Value
                             + "'";

                s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                {
                    if (connection.ResultsDataSet.Tables != null)
                    {
                        foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                        {
                            s_trStatus = drow["trstatus"].ToString();
                        }
                    }
                }

            }

            if (s_trStatus == "D")
            {
                //hidChkColorId.Value = "0";
                hidColorIndex.Value = "B";
                lblMsg.Visible = true;
                lblMsg.Text = "Invoice Already In Approved!";
                return;
            }


           
            dd_FileNo.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[3].Text.ToString());
            dd_FileNo_SelectedIndexChanged(sender, e);

            dd_LC.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[4].Text.ToString());
            dd_LC_SelectedIndexChanged(sender, e);

            dd_Invoice.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[7].Text.ToString());

            txt_InvoiceValue.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[9].Text.ToString());
            txt_BTB.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[10].Text.ToString());
            txt_PC.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[11].Text.ToString());
            txt_Commission.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[12].Text.ToString());
            txt_BankCharge.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[13].Text.ToString());
            txt_PCIntarest.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[14].Text.ToString());
            txt_Tax.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[15].Text.ToString());
            txt_CM.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[16].Text.ToString());

            txt_CMDolar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[17].Text.ToString());
            txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[17].Text.ToString());
            //txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[18].Text.ToString());
            txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[19].Text.ToString());


            hid_Addmode.Value = "N";
            btn_save.Text = "Update";

        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }




    private Boolean isValid()
    {
        if (dd_Search.SelectedValue != "0")
        {
            hid_ProposalId.Value = dd_Search.SelectedValue;
        }

        //---------------------------------------
        //if (dd_FileNo.SelectedValue == "0")
        //{
        //    string message = "File No Can Not Blank!";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
        //    dd_FileNo.Focus();
        //    return false;
        //}

        return true;
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

        b_validationReturn = isrequired();

        if (b_validationReturn == false)
        {
            return;
        }

        if (btn_save.Text == "Update")
        {
            s_Update = "[Proc_CM_Proposal_UPDATE]"
                      + "'"
                      + dd_Search.SelectedValue
                      + "','"
                      + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                      + "','"
                      + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                      + "','"
                      + SessionUserId
                      + "','"
                      + SessionCompanyId
                      + "'";

            s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, false);

            if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {

                if (s_Update_returnValue == GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    string message = "Operation Failed!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                }
                else
                {
                    // Inserting in Details Table
                    foreach (DataRow dr in dt.Rows)
                    {
                        string fileId = string.Empty;
                        string lcId = string.Empty;
                        string InvoiceId = string.Empty;
                        string InvoiceValue = string.Empty;
                        string BTB = string.Empty;
                        string PC = string.Empty;
                        string Commission = string.Empty;
                        string BankCharge = string.Empty;
                        string PCIntarest = string.Empty;
                        string dolar = string.Empty;
                        string taka = string.Empty;
                        string SourchTax = string.Empty;
                        string CMDolar = string.Empty;
                        string CM = string.Empty;
                        string Rate = string.Empty;
                        string CMTK = string.Empty;

                        fileId = Convert.ToString(dr["FileId"]);
                        lcId = Convert.ToString(dr["LCId"]);
                        InvoiceId = Convert.ToString(dr["InvoiceId"]);
                        InvoiceValue = Convert.ToString(dr["InvoiceValue"]);
                        BTB = Convert.ToString(dr["BTB"]);
                        PC = Convert.ToString(dr["PC"]);
                        Commission = Convert.ToString(dr["Commission"]);
                        PCIntarest = Convert.ToString(dr["PCIntarest"]);
                        BankCharge = Convert.ToString(dr["BankCharge"]);
                        SourchTax = Convert.ToString(dr["SourchTax"]);
                        CM = Convert.ToString(dr["CM"]);
                        CMDolar = Convert.ToString(dr["CMDolar"]);
                        Rate = Convert.ToString(dr["Rate"]);
                        CMTK = Convert.ToString(dr["CMTK"]);

                        s_save_ = "[Proc_CM_Proposal_Details_INSERT]"
                                   + "'"
                                   + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                                   + "','"
                                   + fileId
                                   + "','"
                                   + lcId
                                   + "','"
                                   + InvoiceId
                                   + "','"
                                   + InvoiceValue
                                   + "','"
                                   + BTB
                                   + "','"
                                   + PC
                                   + "','"
                                   + Commission
                                   + "','"
                                   + PCIntarest
                                   + "','"
                                   + BankCharge
                                   + "','"
                                   + SourchTax
                                   + "','"
                                   + CM
                                   + "','"
                                   + CMDolar
                                   + "','"
                                   + Rate
                                   + "','"
                                   + CMTK
                                   + "'";


                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);

                    }
                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            s_save_ = "[Proc_Blank_Select]";
                            connection.connection_DB(s_save_, 1, true, false, true);
                            lblMsg.Visible = true;
                            lblMsg.Text = "Update Successfull!";
                            InsertMode();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Already Exists!";
                        }
                    }
                }
            }
        }
        else
        {
            s_save_ = "[Proc_CM_Proposal_INSERT]"
                      + "'"
                      + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                      + "','"
                      + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                      + "','"
                      + SessionUserId
                      + "','"
                      + SessionCompanyId
                      + "'";

            s_returnValue = connection.connection_DB(s_save_, 1, true, true, false);

            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string fileId = string.Empty;
                        string lcId = string.Empty;
                        string InvoiceId = string.Empty;
                        string InvoiceValue = string.Empty;
                        string BTB = string.Empty;
                        string PC = string.Empty;
                        string Commission = string.Empty;
                        string BankCharge = string.Empty;
                        string PCIntarest = string.Empty;
                        string dolar = string.Empty;
                        string taka = string.Empty;
                        string SourchTax = string.Empty;
                        string CMDolar = string.Empty;
                        string CM = string.Empty;
                        string Rate = string.Empty;
                        string CMTK = string.Empty;

                        fileId = Convert.ToString(dr["FileId"]);
                        lcId = Convert.ToString(dr["LCId"]);
                        InvoiceId = Convert.ToString(dr["InvoiceId"]);
                        InvoiceValue = Convert.ToString(dr["InvoiceValue"]);
                        BTB = Convert.ToString(dr["BTB"]);
                        PC = Convert.ToString(dr["PC"]);
                        Commission = Convert.ToString(dr["Commission"]);
                        PCIntarest = Convert.ToString(dr["PCIntarest"]);
                        BankCharge = Convert.ToString(dr["BankCharge"]);
                        SourchTax = Convert.ToString(dr["SourchTax"]);
                        CM = Convert.ToString(dr["CM"]);
                        CMDolar = Convert.ToString(dr["CMDolar"]);
                        Rate = Convert.ToString(dr["Rate"]);
                        CMTK = Convert.ToString(dr["CMTK"]);

                        s_save_ = "[Proc_CM_Proposal_Details_INSERT]"
                                   + "'"
                                   + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                                   + "','"
                                   + fileId
                                   + "','"
                                   + lcId
                                   + "','"
                                   + InvoiceId
                                   + "','"
                                   + InvoiceValue
                                   + "','"
                                   + BTB
                                   + "','"
                                   + PC
                                   + "','"
                                   + Commission
                                   + "','"
                                   + PCIntarest
                                   + "','"
                                   + BankCharge
                                   + "','"
                                   + SourchTax
                                   + "','"
                                   + CM
                                   + "','"
                                   + CMDolar
                                   + "','"
                                   + Rate
                                   + "','"
                                   + CMTK
                                   + "'";


                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);

                    }
                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            s_save_ = "[Proc_Blank_Select]";
                            connection.connection_DB(s_save_, 1, true, false, true);

                            lblMsg.Visible = true;
                            lblMsg.Text = "Save Successfull!";

                            InsertMode();
                        }

                        else
                        {

                            lblMsg.Visible = true;
                            lblMsg.Text = "Already Exists!";

                        }
                    }

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Already Exists!";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Operation Failed!";
            }
        }

    }


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;

        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        hid_TotalPC.Value = "0";

        hid_ProposalId.Value = dd_Search.SelectedValue;

        if (hid_ProposalId.Value != "0")
        {
            s_select = "[Proc_CM_Proposal_Select]"
                        + "'"
                        + hid_ProposalId.Value
                        + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        txt_SLNo.Text = drow["SLNO"].ToString();
                        txtIssueDate.Text = drow["trDate"].ToString();
                    }
                    // Details Part-------------------       
                    s_select = "[Proc_CM_Proposal_Details_Search]"
                                 + "'"
                                 + hid_ProposalId.Value
                                 + "'";

                    s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                    if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (connection.ResultsDataSet.Tables[0] != null)
                        {
                            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                string autoId = string.Empty;
                                string FileId = string.Empty;
                                string LCId = string.Empty;
                                string LCNO = string.Empty;
                                string BTB = string.Empty;
                                string PC = string.Empty;
                                string InvoiceValue = string.Empty;
                                string LCValue = string.Empty;
                                string InvoiceNo = string.Empty;
                                string intarest = string.Empty;
                                string InvoiceId = string.Empty;
                                string commission = string.Empty;
                                string bankCharge = string.Empty;
                                string Tax = string.Empty;
                                string CM = string.Empty;
                                string cmDolar = string.Empty;
                                string Rate = string.Empty;
                                string cmTk = string.Empty;

                                //autoId = drow["AutoId"].ToString();
                                FileId = drow["FileId"].ToString();
                                LCId = drow["LCId"].ToString();
                                LCNO = drow["LCNO"].ToString();
                                LCValue = drow["LCValue"].ToString();
                                InvoiceId = drow["InvoiceId"].ToString();
                                InvoiceNo = drow["InvoiceNo"].ToString();
                                InvoiceValue = drow["InvoiceValue"].ToString();
                                BTB = drow["BTB"].ToString();
                                PC = drow["PC"].ToString();
                                commission = drow["commission"].ToString();
                                bankCharge = drow["BankCharge"].ToString();
                                intarest = drow["Intarest"].ToString();
                                Tax = drow["Tax"].ToString();
                                CM = drow["CM"].ToString();
                                cmDolar = drow["CMDolar"].ToString();
                                Rate = drow["Rate"].ToString();
                                cmTk = drow["CMTK"].ToString();

                                DataTable myDataTable = (DataTable)ViewState["myDatatable"];

                                AddDataToTable(autoId
                                            , FileId
                                            , LCId
                                            , LCNO
                                            , LCValue
                                            , InvoiceId
                                            , InvoiceNo
                                            , InvoiceValue
                                            , BTB
                                            , PC
                                            , commission
                                            , bankCharge
                                            , intarest
                                            , Tax
                                            , CM
                                            , cmDolar
                                            , Rate
                                            , cmTk
                                            , (DataTable)ViewState["myDatatable"]
                                         );

                                        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
                                        this.gdv_Item.DataBind();

                                        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
                                       
                                        //hid_TotalPIAmount.Value = Convert.ToString(Convert.ToDouble(hid_TotalPIAmount.Value) + Convert.ToDouble(Total_Price));
                                        //txttotalPIAmount.Text = hid_TotalPIAmount.Value;

                                       
                                    }
                                }
                        }
                    }
                    GrandTotal();
                    btn_save.Text = "Update";
                }
            }
        }
        
       
    


    private void GrandTotal()
    {
        //if (hid_Rownumber.Value != "0")
        //{
        //    float GTotal = 0f;
        //    for (int i = 0; i < gdv_Item.Rows.Count; i++)
        //    {
        //        String total = (gdv_Item.Rows[i].Cells[9]).Text.Trim();
        //        GTotal += Convert.ToSingle(total);
        //    }
        //    txt_TotalPC.Text = GTotal.ToString();
        //}
    }


    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }


    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {

            Boolean b_validationReturn = true;

            lblMsg.Visible = false;
            b_validationReturn = isValid();

            if (b_validationReturn == false)
            {
                return;
            }

            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "CM Purchase Proposal");

            TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\RPT_CM_Proposal.rpt";

            TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_CM_Proposal"
                                                         + "'"
                                                         + hid_ProposalId.Value
                                                         + "'";

            Response.Redirect(GlobalVariables.g_s_URL_reportViewer);


        }

        catch (Exception)
        {

        }

    }

   
   
}


