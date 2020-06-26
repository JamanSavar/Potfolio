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

public partial class Finance_UI_frmCashLCPayment : System.Web.UI.Page
{
    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunctions commonfunctions = new CommonFunctions();


            commonfunctions.g_b_FillDropDownList(dd_FileNo,
                 "TBL_Export_LC_FileNo_BTB_Percent",
                 "File_Ref_No",
                 "File_Ref_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_CashId,
               "TBL_Cash_LC",
               "Voucher_No",
               "Cash_Id", string.Empty);



            commonfunctions.g_b_FillDropDownList(dd_CostingHead,
                "T_Costing_Head",
                "Costing_Head",
                "Costing_Head_Id", string.Empty);



            commonfunctions.g_b_FillDropDownList(dd_VoucherType,
               "T_Voucher_Type",
               "Voucher_Type",
               "Id", string.Empty);

            commonfunctions.g_b_FillDropDownListMultiColumn(dd_POSupplier,
               "T_Supplier",
               "Name",
               "Address",
               "Supplier_Id", string.Empty);

            commonfunctions.g_b_FillDropDownListMultiColumn(dd_Supplier,
               "T_Supplier",
               "Name",
               "Address",
               "Supplier_Id", "WHERE  Supplier_Id IN (SELECT Supplier_Id FROM TBL_ProformaInvoice) ");

            commonfunctions.g_b_FillDropDownList(dd_Bank,
               "T_Bank",
               "Name",
               "Bank_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Currency,
                "T_Currency",
                "Currency_Type",
                "Currency_Type_Id", string.Empty);

            txtIssueDate.Text = DateTime.Now.ToString();

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);

            v_loadGridView_Item();

            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDataTable"] = myDt;


        }
    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }


    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PI_AutoId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PI_No", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PI_Date", typeof(DateTime)));
        myDataTable.Columns.Add(new DataColumn("Total_Price", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Currency", typeof(string)));
        return myDataTable;
    }

    private void AddDataToTable(string Supplier,
                                string PI_Id,
                                string PI_No,
                                string PI_Date,
                                string Total_Price,
                                string Currency,
                                DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["Supplier"] = Supplier;
        row["PI_AutoId"] = PI_Id;
        row["PI_No"] = PI_No;
        row["PI_Date"] = PI_Date;
        row["Total_Price"] = Total_Price;
        row["Currency"] = Currency;
        myTable.Rows.Add(row);
    }


    private void maxPaymentNo()
    {
        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        s_select = "Proc_Max_Voucher_No'" + dd_Supplier.SelectedValue + "'";

        s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
        if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (connection.ResultsDataSet.Tables != null)
            {
                foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                {
                    txt_VoucherNo.Text = drow["SLNo"].ToString();
                }
            }
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDataTable"] = myDt;

        hid_TotalPIAmount.Value = "0";
        if (dd_CashId.SelectedValue != "0")
        {
            s_select = "[Proc_Cash_LC_Search]"
                        + "'"
                        + dd_CashId.SelectedValue
                        + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        dd_FileNo.SelectedValue = drow["File_Ref_Id"].ToString();
                        dd_CostingHead.SelectedValue = drow["Costing_Head_Id"].ToString();
                        txt_VoucherNo.Text = drow["Voucher_No"].ToString();
                        txtIssueDate.Text = drow["trDate"].ToString();
                        txt_CheckNo.Text = drow["Check_No"].ToString();
                        txt_Note.Text = drow["Note"].ToString();
                        txt_RecivedBy.Text = drow["Received_By"].ToString();
                        dd_VoucherType.SelectedValue = drow["Voucher_Type"].ToString();
                        dd_Bank.SelectedValue = drow["Bank_Id"].ToString();
                        dd_Supplier.SelectedValue = drow["Pay_Supplier_Id"].ToString();
                        dd_POSupplier.SelectedValue = drow["PO_Supplier_Id"].ToString();
                        dd_Currency.SelectedValue = drow["Currency_Id"].ToString();

                        PI_Load();
                    }
                    // Order Discription Part       
                    s_select = "[Proc_CashLC_With_PI_Search]"
                                         + "'"
                                         + dd_CashId.SelectedValue
                                         + "'";

                    s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                    if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (connection.ResultsDataSet.Tables[0] != null)
                        {
                            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                string Supplier = string.Empty;
                                string PI_Id = string.Empty;
                                string PI_No = string.Empty;
                                string PI_Date = string.Empty;
                                string Total_Price = string.Empty;
                                string Currency = string.Empty;
                                string trState = string.Empty;
                                trState = "Add";

                                txttotalPIAmount.Text = string.Empty;
                                Supplier = drow["Supplier"].ToString();
                                PI_Id = drow["PI_AutoId"].ToString();
                                PI_No = drow["PI_No"].ToString();
                                PI_Date = drow["PI_Date"].ToString();
                                Total_Price = drow["Total_Price"].ToString();
                                Currency = drow["Currency"].ToString();

                                foreach (GridViewRow dr in gdv_Item.Rows)
                                {
                                    if (dr.Cells[1].Text == PI_Id && dr.Cells[2].Text == Supplier) //Duplicate Cheack For Same color Same Brand
                                    {
                                        trState = "Dell";
                                    }
                                }

                                if (trState == "Add")
                                {

                                    DataTable myDataTable = (DataTable)ViewState["myDatatable"];

                                    AddDataToTable(Supplier
                                                , PI_Id
                                                , PI_No
                                                , PI_Date
                                                , Total_Price
                                                , Currency
                                                , (DataTable)ViewState["myDataTable"]
                                             );

                                    this.gdv_Item.DataSource = ((DataTable)ViewState["myDataTable"]).DefaultView;
                                    this.gdv_Item.DataBind();

                                    hid_TotalPIAmount.Value = Convert.ToString(Convert.ToDouble(hid_TotalPIAmount.Value) + Convert.ToDouble(Total_Price));
                                    txttotalPIAmount.Text = hid_TotalPIAmount.Value;

                                    hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
                                }
                            }
                        }
                    }
                    //PI Discription Part

                    PI_Load();
                    btn_save.Text = "Update";
                }
            }
        }
    }



    protected void dd_Supplier_SelectedIndexChanged(object sender, EventArgs e)
    {

        string supplierId = string.Empty;
        supplierId = "0";
        supplierId = dd_Supplier.SelectedValue;

        CommonFunctions commonfunctions = new CommonFunctions();
        commonfunctions.g_b_FillDropDownList(dd_CashId,
            "TBL_Cash_LC",
            "Voucher_No",
            "Cash_Id", "Where Pay_Supplier_Id='" + supplierId + "' Order by Voucher_No asc");


        maxPaymentNo();
        PI_Load();


    }

    protected void dd_CostingHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        PI_Load();

    }

    protected void dd_Currency_SelectedIndexChanged(object sender, EventArgs e)
    {
        PI_Load();
    }


    private void PI_Load()
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        Connection conn = new Connection();
        string s_PILoadCondition = string.Empty, returnValue = string.Empty;

        hid_Supplier_Id.Value = dd_Supplier.SelectedValue;
        hid_CostingHead_Id.Value = dd_CostingHead.SelectedValue;
        hid_Currency_Id.Value = dd_Currency.SelectedValue;

        if (dd_CashId.SelectedValue == "0")
        {
            s_PILoadCondition = "[Proc_Load_PI_For_CashLC]"
                                 + " '"
                                 + Convert.ToString(hid_Supplier_Id.Value)
                                 + "','"
                                 + Convert.ToString(hid_CostingHead_Id.Value)
                                 + "','"
                                 + Convert.ToString(hid_Currency_Id.Value)
                                 + "','"
                                 + "0"
                                 + "','"
                                 + "N"
                                 + "'";
        }
        else
        {
            s_PILoadCondition = "[Proc_Load_PI_For_CashLC]"
                                 + " '"
                                 + Convert.ToString(hid_Supplier_Id.Value)
                                 + "','"
                                 + Convert.ToString(hid_CostingHead_Id.Value)
                                 + "','"
                                 + Convert.ToString(hid_Currency_Id.Value)
                                 + "','"
                                 + dd_CashId.SelectedValue
                                 + "','"
                                 + "Y"
                                 + "'";
        }

        returnValue = conn.connection_DB(s_PILoadCondition, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (conn.ResultsDataSet.Tables[0] != null)
            {
                commonfunctions.g_b_FillDropDownList(dd_PI, conn.ResultsDataSet.Tables[0], "PI_No", "PI_AutoId");
            }
        }

    }





    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;


        Boolean b_required = true;
        lblMsg.Visible = false;

        if (hid_TotalPIAmount.Value == "0")
        {
            hid_TotalPIAmount.Value = "0";
        }

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

        //Duplicate PI Checking
        foreach (GridViewRow dr in gdv_Item.Rows)
        {
            if (dr.Cells[2].Text == dd_PI.SelectedValue)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "PI Already Added!";
                return;
            }
        }


        hid_TotalPIAmount.Value = "0";
        s_OrderLoadCondition = "[proc_Search_PI_For_BTB]"
                                 + "'"
                                 + dd_PI.SelectedValue
                                 + "'";

        returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (conn.ResultsDataSet.Tables[0] != null)
            {

                foreach (DataRow drow in conn.ResultsDataSet.Tables[0].Rows)
                {
                    string Supplier = string.Empty;
                    string PI_Id = string.Empty;
                    string PI_No = string.Empty;
                    string PI_Date = string.Empty;
                    string Total_Price = string.Empty;
                    string Currency = string.Empty;

                    Supplier = drow["Supplier"].ToString();
                    PI_Id = drow["PI_AutoId"].ToString();
                    PI_No = drow["PI_No"].ToString();
                    PI_Date = drow["PI_Date"].ToString();
                    Total_Price = drow["Total_Price"].ToString();
                    Currency = drow["Currency"].ToString();

                    DataTable myDataTable = (DataTable)ViewState["myDataTable"];

                    AddDataToTable(Supplier
                                , PI_Id
                                , PI_No
                                , PI_Date
                                , Total_Price
                                , Currency
                                , (DataTable)ViewState["myDataTable"]
                             );

                    this.gdv_Item.DataSource = ((DataTable)ViewState["myDataTable"]).DefaultView;
                    this.gdv_Item.DataBind();
                    hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
                }
            }
        }

        GrandTotal();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gdvRow in gdv_Item.Rows)
        {
            CheckBox checkbox = (CheckBox)gdvRow.Cells[0].FindControl("chkApproval");
            if (checkbox.Checked == true)
            {
                DataTable dt = (DataTable)ViewState["myDataTable"];
                DataRow[] rows;

                string PIid = string.Empty;
                PIid = gdvRow.Cells[2].Text.Trim();

                rows = dt.Select("PI_AutoId='" + PIid + "'");
                foreach (DataRow dr in rows)
                    dt.Rows.Remove(dr);
                dt.AcceptChanges();
                gdv_Item.DataSource = dt;
                gdv_Item.DataBind();
            }
        }

        GrandTotal();

    }

    private void GrandTotal()
    {
        if (hid_Rownumber.Value != "0")
        {
            float GTotal = 0f;
            for (int i = 0; i < gdv_Item.Rows.Count; i++)
            {
                String total = (gdv_Item.Rows[i].Cells[6]).Text.Trim();
                GTotal += Convert.ToSingle(total);
            }
            txttotalPIAmount.Text = GTotal.ToString();
        }
    }

    private void AddClear()
    {
        dd_PI.SelectedValue = "0";

    }


    private void v_loadGridView_Item()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as PI_AutoId ,'' as Currency,'' as Amount, '' as Supplier,'' as PI_No,'' as Supplier,'' as PI_Date ,'' as Total_Price,'' as Currency", sqlconnection);

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


    protected void btn_save_Click(object sender, EventArgs e)
    {

        Connection connection = new Connection();
        DataTable dt = (DataTable)ViewState["myDataTable"];

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
            s_Update = "[Proc_CashLC_Payment_UPDATE]"
            + "'"
            + dd_CashId.SelectedValue
            + "','"
            + HttpUtility.HtmlDecode(txt_VoucherNo.Text.Trim())
            + "','"
            + dd_VoucherType.SelectedValue
            + "','"
            + dd_Bank.SelectedValue
            + "','"
            + HttpUtility.HtmlDecode(txt_CheckNo.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_RecivedBy.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_Note.Text.Trim())
            + "','"
            + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + dd_CostingHead.SelectedValue
            + "','"
            + dd_FileNo.SelectedValue
            + "','"
            + dd_POSupplier.SelectedValue
            + "','"
            + dd_Supplier.SelectedValue
            + "','"
            + dd_Currency.SelectedValue
            + "','"
            + "1.00"
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
                    lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                }
                else
                {
                    // PI Details Insert
                    foreach (DataRow dr in dt.Rows)
                    {
                        string PI_Id = string.Empty;
                        PI_Id = Convert.ToString(dr["PI_AutoId"]);

                        s_save_ = "Proc_CashLC_With_PI_INSERT"
                                 + "'"
                                 + HttpUtility.HtmlDecode(txt_VoucherNo.Text.Trim())
                                 + "','"
                                 + PI_Id
                                 + "'";

                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);

                    }
                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            s_save_ = "[Proc_Blank_Select]";
                            connection.connection_DB(s_save_, 1, true, false, true);
                            string message = "Update Successfull!";
                            lblMsg.Text = message;
                            InsertMode();
                        }

                        else
                        {
                            string message = "Already Exists!";
                            lblMsg.Text = message;
                        }
                    }
                }
            }
        }
        else
        {
            s_save_ = "[Proc_CashLC_Payment_INSERT]"
                    + "'"
                    + HttpUtility.HtmlDecode(txt_VoucherNo.Text.Trim())
                    + "','"
                    + dd_VoucherType.SelectedValue
                    + "','"
                    + dd_Bank.SelectedValue
                    + "','"
                    + HttpUtility.HtmlDecode(txt_CheckNo.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_RecivedBy.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_Note.Text.Trim())
                    + "','"
                    + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + dd_CostingHead.SelectedValue
                    + "','"
                    + dd_FileNo.SelectedValue
                    + "','"
                    + dd_POSupplier.SelectedValue
                    + "','"
                    + dd_Supplier.SelectedValue
                    + "','"
                    + dd_Currency.SelectedValue
                    + "','"
                    + "1.00"
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
                    // PI Details Insert
                    foreach (DataRow dr in dt.Rows)
                    {
                        string PI_Id = string.Empty;
                        PI_Id = Convert.ToString(dr["PI_AutoId"]);

                        s_save_ = "Proc_CashLC_With_PI_INSERT"
                                 + "'"
                                 + HttpUtility.HtmlDecode(txt_VoucherNo.Text.Trim())
                                 + "','"
                                 + PI_Id
                                 + "'";

                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);

                    }
                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            s_save_ = "[Proc_Blank_Select]";
                            connection.connection_DB(s_save_, 1, true, false, true);
                            string message = "Save Successfull!";
                            lblMsg.Text = message;
                            InsertMode();
                        }
                        else
                        {
                            string message = "Already Exists!";
                            lblMsg.Text = message;
                        }
                    }
                }
                else
                {
                    string message = "Already Exists!";
                    lblMsg.Text = message;
                }
            }
            else
            {
                string message = "Operation Failed!";
                lblMsg.Text = message;
            }
        }
    }




    private void InsertMode_Msg()
    {
        lblMsg.Text = string.Empty;
    }

    private void InsertMode()
    {
        hid_autoId.Value = "0";
        dd_POSupplier.SelectedValue = "0";
        dd_Supplier.SelectedValue = "0";

        dd_Currency.SelectedValue = "0";
        dd_CostingHead.SelectedValue = "0";
        dd_FileNo.SelectedValue = "0";
        //dd_Search.SelectedValue = "0";

        txtIssueDate.Text = DateTime.Now.ToString();

        txt_VoucherNo.Text = string.Empty;
        txttotalPIAmount.Text = string.Empty;

        CommonFunctions commonfunctions = new CommonFunctions();
        commonfunctions.g_b_FillDropDownList(dd_CashId,
            "TBL_Cash_LC",
            "Voucher_No",
            "Cash_Id", string.Empty);


        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDataTable"] = myDt;

        hid_Rownumber.Value = "0";
        v_loadGridView_Item();
        btn_save.Text = "Save";
    }
    private Boolean isValid()
    {

        Connection conn = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();
        string s_FileIdNeeded = string.Empty, returnValue = string.Empty;

        CommonFunctions.Date_Validation dv = new CommonFunctions.Date_Validation();
        if (dv.date_Validate(txtIssueDate.Text) == false)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "BTB Issue Date Invalid!";
            return false;
        }

        if (dd_Supplier.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Supplier Can Not Blank!";
            return false;
        }

        if (dd_POSupplier.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Supplier(Purchase From) Can Not Blank!";
            return false;
        }



        //if (txt_BTBNo.Text == "")
        //{
        //    lblsubmsg.Visible = true;
        //    lblsubmsg.Text = "BTB No Can Not Blank!";
        //    return false;
        //}

        if (dd_Currency.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Currency Can Not Blank!";
            return false;
        }

        if (hid_Rownumber.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "PI Grid Can Not Blank!";
            return false;
        }

        hid_File_Id.Value = "0";
        if (dd_FileNo.SelectedValue != "0")
        {
            s_FileIdNeeded = "SELECT File_Ref_Id FROM TBL_Export_LC Where Export_LC_Id='" + dd_FileNo.SelectedValue + "'";
            returnValue = conn.connection_DB(s_FileIdNeeded, 0, false, false, false);
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (conn.ResultsDataSet.Tables[0] != null)
                {
                    foreach (DataRow drow in conn.ResultsDataSet.Tables[0].Rows)
                    {
                        hid_File_Id.Value = drow["File_Ref_Id"].ToString();
                    }
                }
            }
        }

        return true;
    }


    private Boolean isrequired()
    {

        //if (txt_BTBNo.Text == "")
        //{
        //    lblsubmsg.Visible = true;
        //    lblsubmsg.Text = "BTB No Blank!";
        //    txt_BTBNo.Focus();
        //    return false;
        //}

        return true;
    }



}
