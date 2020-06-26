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

public partial class Finance_UI_frmRealization : System.Web.UI.Page
{

    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunctions commonfunctions = new CommonFunctions();

            txtIssueDate.Text = DateTime.Now.ToString();
            txt_FDBPDate.Text = DateTime.Now.ToString();
            txt_RealizedDate.Text = DateTime.Now.ToString();


            commonfunctions.g_b_FillDropDownList(dd_Search,
                "TBL_Realization",
                "FDBC_No",
                "Realization_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_FileNo,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

            //commonfunctions.g_b_FillDropDownList(dd_PC,
            //  "TBL_PC_Approval",
            //  "PC_Number",
            //  "AutoId", string.Empty);

            //commonfunctions.g_b_FillDropDownList(dd_AccountHead,
            //    "T_Distribution_Account_Head",
            //    "Accounts_Head",
            //    "Accounts_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_ExpenseHead,
                "T_CD_Expense_Head",
                "Expense_Head",
                "Expense_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Bank,
              "T_Bank",
              "Name",
              "Bank_Id", string.Empty);

          
            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDatatable"] = myDt;

            DataTable myDt_Distribution = new DataTable();
            myDt_Distribution = CreateDataTable_Distribution();
            ViewState["myDatatable_Distribution"] = myDt_Distribution;

            DataTable myDt_Expense = new DataTable();
            myDt_Expense = CreateDataTable_Expense();
            ViewState["myDatatable_Expense"] = myDt_Expense;

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);

            v_loadGridView_Item();
            v_loadGridView_Disbursement();
            v_loadGridView_Expense();

        }
    }




    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LC_Load();
    }


    private void LC_Load()
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        String FileId = "0";
        FileId = dd_FileNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_LCNo,
           "TBL_Export_LC",
           "Export_LC_No",
           "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");


        commonfunctions.g_b_FillDropDownList(dd_PC,
           "TBL_PC_Approval",
           "PC_Number",
           "AutoId", "WHERE File_Ref_Id='" + FileId + "'");
    }


    protected void dd_LCNo_SelectedIndexChanged(object sender, EventArgs e)
    {
     
        if (dd_LCNo.SelectedValue != "0")
        {
            String lcId = "0";
            lcId = dd_LCNo.SelectedValue;

            CommonFunctions commonfunctions = new CommonFunctions();
            //commonfunctions.g_b_FillDropDownList(dd_Invoice,
            //    "TBL_Export",
            //    "Invoice_No",
            //    "Export_Id", "WHERE Export_LC_Id='" + lcId + "'");


            commonfunctions.g_b_FillDropDownList(dd_Invoice,
               "TBL_Export",
               "Invoice_No",
               "Export_Id", "WHERE Export_LC_Id='" + lcId + "' And Relization_Id='0' ");



            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_Select_returnValue = string.Empty;
            string s_c = string.Empty;

            s_select = "[Proc_LC_Wise_Bank_Search]"
                       + "'"
                       + dd_LCNo.SelectedValue
                       + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        dd_Bank.SelectedValue = drow["Bank_Id"].ToString();
                        dd_Bank_SelectedIndexChanged(sender,e);
                    }
                }
            }
 
        }

    }

    protected void dd_Bank_SelectedIndexChanged(object sender, EventArgs e)
    {

      BankWise_AccountHead_Load(); 

    }


    private void BankWise_AccountHead_Load()
    {

        if (dd_Bank.SelectedValue != "0")
        {
            CommonFunctions commonfunctions = new CommonFunctions();

            String bankId = "0";
            bankId = dd_Bank.SelectedValue;

            //commonfunctions.g_b_FillDropDownListMultiColumn(dd_AccountHead,
            //     "T_Distribution_Account_Head",
            //     "Accounts_Head",
            //     "Account_No",
            //     "Accounts_Id", "WHERE  Bank_Id= '" + bankId + "'  Order By Accounts_Head ");

            commonfunctions.g_b_FillDropDownList(dd_AccountHead,
               "T_Distribution_Account_Head",
               "Accounts_Head",
               "Accounts_Id", "WHERE  Bank_Id= '" + bankId + "'  Order By Accounts_Head ");

        }
        else
        {
            //CommonFunctions commonfunctions = new CommonFunctions();
            //string SessionUserId = string.Empty;
            //SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);

            //String buyerId = "0";
            //buyerId = dd_Buyer.SelectedValue;

            //string qry = string.Empty;
            //qry = "proc_Load_Styles_For_OrderInfo '" + buyerId + "','" + SessionUserId + "'";
            //commonfunctions.g_b_FillDropDownListByQurey(dd_Order, qry);

        }

        
        
        
        
        //CommonFunctions commonfunctions = new CommonFunctions();
        //Connection conn = new Connection();
        //string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        //s_OrderLoadCondition = "SELECT Accounts_Head ,Accounts_Id FROM T_Distribution_Account_Head Where Bank_Id="
        //                 + "'"
        //                 + dd_Bank.SelectedValue
        //                 + "' ORDER BY Accounts_Head;";


        //returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        //if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        //{
        //    if (conn.ResultsDataSet.Tables[0] != null)
        //    {
        //        commonfunctions.g_b_FillDropDownList(dd_AccountHead, conn.ResultsDataSet.Tables[0], "Accounts_Head",
        //                                            "Accounts_Id");
        //    }
        //}

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

    private DataTable CreateDataTable_Distribution()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("AccountId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("AccountHead", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCNo", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("AmountDollar", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("AmountTk", typeof(string)));
        return myDataTable;
    }

    private void AddDataToTable_Distribution(string AccountId,
                            string AccountHead,
                            string PCId,
                            string PCNo,
                            string Rate,
                            string AmountDollar,
                            string AmountTk,
                            DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["AccountId"] = AccountId;
        row["AccountHead"] = AccountHead;
        row["PCId"] = PCId;
        row["PCNo"] = PCNo;
        row["Rate"] = Rate;
        row["AmountDollar"] = AmountDollar;
        row["AmountTk"] = AmountTk;
        myTable.Rows.Add(row);
    }



    private DataTable CreateDataTable_Expense()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("ExpenseId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("ExpenseHead", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Amount", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
        return myDataTable;
    }


    private void AddDataToTable_Expense(string ExpenseId,
                                string ExpenseHead,
                                string Amount,
                                string Remarks,
                                DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["ExpenseId"] = ExpenseId;
        row["ExpenseHead"] = ExpenseHead;
        row["Amount"] = Amount;
        row["Remarks"] = Remarks;
        myTable.Rows.Add(row);
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


    private void v_loadGridView_Disbursement()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as AccountId,'' as AccountHead, '' as PCNo,'' as PCId,'' as Rate,'' as AmountDollar,'' as AmountTk, '' as Remarks   From TBL_ProformaInvoice Where PI_AutoId=0", sqlconnection);
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
    private void v_loadGridView_Expense()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as ExpenseId,'' as ExpenseHead,'' as Amount, '' as Remarks   From TBL_ProformaInvoice Where PI_AutoId=0", sqlconnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_Expense.DataSource = ds;
            gdv_Expense.DataBind();
            int columncount = gdv_Expense.Rows[0].Cells.Count;
            gdv_Expense.Rows[0].Cells.Clear();
            gdv_Expense.Rows[0].Cells.Add(new TableCell());
            gdv_Expense.Rows[0].Cells[0].ColumnSpan = columncount;
            //gdv_Item.Rows[0].Cells[0].Text = "No Records Found";

        }
        else
        {
            gdv_Expense.DataSource = ds;
            gdv_Expense.DataBind();
        }
        sqlconnection.Close();
    }


   
    protected void btn_save_Click(object sender, EventArgs e)
    {
        Connection connection = new Connection();
        DataTable dt = (DataTable)ViewState["myDatatable"];
        DataTable dtd = (DataTable)ViewState["myDatatable_Distribution"];
        DataTable dte = (DataTable)ViewState["myDatatable_Expense"];

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


        Boolean b_UserReturn = true;
        b_UserReturn = isUserCheck();
        if (b_UserReturn == false && btn_save.Text == "Update")
        {
            return;
        }

        if (btn_save.Text == "Update")
        {
            s_Update = "[Proc_Realization_UPDATE]"
            + "'"
            + dd_Search.SelectedValue
            + "','"
            + HttpUtility.HtmlDecode(txt_SlNo.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(dd_CollectionType.SelectedValue)
            + "','"
            + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_InvoiceTotal.Text.Trim())
            + "','"
            + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + dd_LCNo.SelectedValue
            + "','"
            + HttpUtility.HtmlDecode(txt_RealizedAmount.Text.Trim())
            + "','"
            + Convert.ToDateTime(txt_RealizedDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + ""       //HttpUtility.HtmlDecode(txt_Remarks.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_FDBPNo.Text.Trim())
            + "','"
            + Convert.ToDateTime(txt_FDBPDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            + "','"
            + HttpUtility.HtmlDecode(txt_FDBP_Taka.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_FDBP_Dolar.Text.Trim())
            + "','"
            + HttpUtility.HtmlDecode(txt_FDBP_Rate.Text.Trim())
            + "','"
            + ""
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

                    //lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                    string message = "Alrady Exists!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                }

                else
                {
                    /// Invoice Details Insert
                    foreach (DataRow dr in dt.Rows)
                    {
                        string Export_Id = string.Empty;
                        Export_Id = Convert.ToString(dr["Export_Id"]);

                        s_save_ = "Proc_Realization_Attatch_With_Invoice"
                                 + "'"
                                 + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                                 + "','"
                                 + Export_Id
                                 + "'";
                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);
                    }

                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            /// Distribution Details Insert
                            foreach (DataRow dr in dtd.Rows)
                            {
                                string AccountId = string.Empty;
                                string PCId = string.Empty;
                                string Rate = string.Empty;
                                string AmountDollar = string.Empty;
                                string AmountTk = string.Empty;
                                string Remarks = string.Empty;

                                AccountId = Convert.ToString(dr["AccountId"]);
                                PCId = Convert.ToString(dr["PCId"]);
                                Rate = Convert.ToString(dr["Rate"]);
                                AmountDollar = Convert.ToString(dr["AmountDollar"]);
                                AmountTk = Convert.ToString(dr["AmountTk"]);
                               
                                s_save_ = "Proc_Realization_Distribution_INSERT"
                                         + "'"
                                         + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                                         + "','"
                                         + AccountId
                                         + "','"
                                         + PCId
                                         + "','"
                                         + Rate
                                         + "','"
                                         + AmountDollar
                                         + "','"
                                         + AmountTk
                                         + "','"
                                         + ""           //Remarks
                                         + "','"
                                         + SessionUserId
                                         + "'";
                                s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);
                            }

                            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                            {
                                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                                {

                                    /// Expense Details Insert
                                    foreach (DataRow dr in dte.Rows)
                                    {
                                        string ExpenseId = string.Empty;
                                        string Amount = string.Empty;
                                        string Remarks = string.Empty;

                                        ExpenseId = Convert.ToString(dr["ExpenseId"]);
                                        Amount = Convert.ToString(dr["Amount"]);
                                        Remarks = Convert.ToString(dr["Remarks"]);

                                        s_save_ = "Proc_Realization_CD_Expense_INSERT"
                                                 + "'"
                                                 + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                                                 + "','"
                                                 + ExpenseId
                                                 + "','"
                                                 + Amount
                                                 + "','"
                                                 + Remarks
                                                 + "','"
                                                 + SessionUserId
                                                 + "'";

                                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);
                                    }

                                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                                    {
                                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                                        {
                                            s_save_ = "[Proc_Blank_Select]";
                                            connection.connection_DB(s_save_, 1, true, false, true);
                                            //lblMsg.Text = GlobalVariables.g_s_updateOperationSuccessfull;
                                            string message = "Update Successfull!";
                                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                                            InsertMode();
                                        }

                                        else
                                        {
                                            //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                                            string message = "Already Exists!";
                                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                                        }
                                    }
                                    /// Expense Details Insert
                                }

                                else
                                {
                                    //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                                    string message = "Already Exists!";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                                }
                            }
                            /// Distribution Details Insert
                        }

                        else
                        {
                            //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                            string message = "Already Exists!";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                        }
                    }
                    /// Invoice Details Insert
                }
            }
        }
        else
        {
            s_save_ = "[Proc_Realization_INSERT]"
                    + "'"
                    + HttpUtility.HtmlDecode(txt_SlNo.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(dd_CollectionType.SelectedValue)
                    + "','"
                    + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_InvoiceTotal.Text.Trim())
                    + "','"
                    + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + dd_LCNo.SelectedValue
                    + "','"
                    + HttpUtility.HtmlDecode(txt_RealizedAmount.Text.Trim())
                    + "','"
                    + Convert.ToDateTime(txt_RealizedDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + ""        //HttpUtility.HtmlDecode(txt_Remarks.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_FDBPNo.Text.Trim())
                    + "','"
                    + Convert.ToDateTime(txt_FDBPDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + HttpUtility.HtmlDecode(txt_FDBP_Taka.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_FDBP_Dolar.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_FDBP_Rate.Text.Trim())
                    + "','"
                    + ""
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
                    /// Invoice Details Insert
                    foreach (DataRow dr in dt.Rows)
                    {
                        string Export_Id = string.Empty;
                        Export_Id = Convert.ToString(dr["Export_Id"]);

                        s_save_ = "Proc_Realization_Attatch_With_Invoice"
                                 + "'"
                                 + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                                 + "','"
                                 + Export_Id
                                 + "'";
                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);
                    }

                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            /// Distribution Details Insert
                            foreach (DataRow dr in dtd.Rows)
                            {
                                string AccountId = string.Empty;
                                string PCId = string.Empty;
                                string Rate = string.Empty;
                                string AmountDollar = string.Empty;
                                string AmountTk = string.Empty;
                                string Remarks = string.Empty;

                                AccountId = Convert.ToString(dr["AccountId"]);
                                PCId = Convert.ToString(dr["PCId"]);
                                Rate = Convert.ToString(dr["Rate"]);
                                AmountDollar = Convert.ToString(dr["AmountDollar"]);
                                AmountTk = Convert.ToString(dr["AmountTk"]);
                               
                                s_save_ = "Proc_Realization_Distribution_INSERT"
                                         + "'"
                                         + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                                         + "','"
                                         + AccountId
                                         + "','"
                                         + PCId
                                         + "','"
                                         + Rate
                                         + "','"
                                         + AmountDollar
                                         + "','"
                                         + AmountTk
                                         + "','"
                                         + ""           //Remarks
                                         + "','"
                                         + SessionUserId
                                         + "'";
                                s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);
                            }

                            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                            {
                                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                                {

                                    /// Expense Details Insert
                                    foreach (DataRow dr in dte.Rows)
                                    {
                                        string ExpenseId = string.Empty;
                                        string Amount = string.Empty;
                                        string Remarks = string.Empty;

                                        ExpenseId = Convert.ToString(dr["ExpenseId"]);
                                        Amount = Convert.ToString(dr["Amount"]);
                                        Remarks = Convert.ToString(dr["Remarks"]);

                                        s_save_ = "Proc_Realization_CD_Expense_INSERT"
                                                 + "'"
                                                 + HttpUtility.HtmlDecode(txt_FDBCNo.Text.Trim())
                                                 + "','"
                                                 + ExpenseId
                                                 + "','"
                                                 + Amount
                                                 + "','"
                                                 + Remarks
                                                 + "','"
                                                 + SessionUserId
                                                 + "'";

                                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);
                                    }

                                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                                    {
                                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                                        {
                                            s_save_ = "[Proc_Blank_Select]";
                                            connection.connection_DB(s_save_, 1, true, false, true);
                                            //lblMsg.Text = GlobalVariables.g_s_insertOperationSuccessfull;
                                            string message = "Saved Successfull!";
                                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                                            InsertMode();
                                        }

                                        else
                                        {
                                            //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                                            string message = "Already Exists!";
                                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                                        }
                                    }
                                    /// Expense Details Insert
                                }

                                else
                                {
                                    //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                                    string message = "Already Exists!";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                                }
                            }
                            /// Distribution Details Insert
                        }

                        else
                        {
                            //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                            string message = "Already Exists!";
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                        }
                    }
                    /// Invoice Details Insert
                }
                else
                {
                    //lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                    string message = "Already Exists!";
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
   
    protected void btn_remove_Click(object sender, EventArgs e)
    {
        Connection connection = new Connection();
        string s_DeleteQry = string.Empty;

        Boolean b_UserReturn = true;
        b_UserReturn = isUserCheck();
        if (b_UserReturn == false && btn_save.Text == "Update")
        {
            return;
        }
        else if (b_UserReturn == true && btn_save.Text == "Save")
        {
            return;
        }

        s_DeleteQry = "Proc_Realization_DELETE"
                     + "'"
                     + dd_Search.SelectedValue
                     + "'";

        string s_returnValue = string.Empty;
        s_returnValue = connection.connection_DB(s_DeleteQry, 1, true, true, true);

        if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
            {
                lblMsg.Text = GlobalVariables.g_s_deleteOperationSuccessfull;
                InsertMode();
            }
            else
            {
                lblMsg.Text = "Already Status Completed!";
            }
        }
        else
        {
            lblMsg.Text = "Connection Error";
        }



    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }
    private void InsertMode_Msg()
    {
        lblMsg.Text = string.Empty;
        lblsubmsg.Text = string.Empty;
        lblsubmsgDistribution.Text = string.Empty;
        lblsubmsgExpense.Text = string.Empty;

    }

    private void InsertMode()
    {
        CommonFunctions commonfunctions = new CommonFunctions();

        commonfunctions.g_b_FillDropDownList(dd_Search,
              "TBL_Realization",
              "FDBC_No",
              "Realization_Id", string.Empty);


        dd_FileNo.SelectedValue = "0";
        dd_Search.SelectedValue = "0";
        dd_CollectionType.SelectedValue = "0";
        dd_AccountHead.SelectedValue = "0";
        dd_ExpenseHead.SelectedValue = "0";

        txt_FDBCNo.Text = string.Empty;
        txtIssueDate.Text = DateTime.Now.ToString();
        txt_RealizedAmount.Text = string.Empty;
        txt_FDBPNo.Text = string.Empty;
        txt_FDBPDate.Text = DateTime.Now.ToString();
        txt_FDBP_Taka.Text = string.Empty;
        txt_FDBP_Taka.Text = string.Empty;
        txt_FDBP_Dolar.Text = string.Empty;
        txt_FDBP_Rate.Text = string.Empty;
        txt_AmountTK.Text = string.Empty;
        txt_InvoiceTotal.Text = string.Empty;
        txt_FDBCAmount.Text = string.Empty;
        txt_Rate.Text = string.Empty;
        txt_ExpenseAmount.Text = string.Empty;
        txt_ExpenseRemarks.Text = string.Empty;

        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        gdv_Distribution.DataSource = null;
        gdv_Distribution.DataBind();

        gdv_Expense.DataSource = null;
        gdv_Expense.DataBind();
       
        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        DataTable myDt_Distribution = new DataTable();
        myDt_Distribution = CreateDataTable_Distribution();
        ViewState["myDatatable_Distribution"] = myDt_Distribution;

        DataTable myDt_Expense = new DataTable();
        myDt_Expense = CreateDataTable_Expense();
        ViewState["myDatatable_Expense"] = myDt_Expense;

        v_loadGridView_Item();
        v_loadGridView_Disbursement();
        v_loadGridView_Expense();

        LC_Load();
        Invoice_Load_BY_LC();
        V_LoadmaxSerial();


        hid_InvoiceRow.Value = "0";
        hid_DistributionRow.Value = "0";
        hid_ExpenseRow.Value = "0";
        dd_FileNo.Enabled = true;
        dd_LCNo.Enabled = true;

        btn_save.Text = "Save";
    }


    private Boolean isValid()
    {

        CommonFunctions.Date_Validation dv = new CommonFunctions.Date_Validation();
        CommonFunctions.numeric_Validation NV = new CommonFunctions.numeric_Validation();

        if (txt_RealizedAmount.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Realized Value Blank!";
            return false;
        }
        else
        {
            if (NV.numeric_Validation_Decimal_Allow_Minus(txt_RealizedAmount.Text, 1) == false)
            {
                txt_RealizedAmount.Text = "Error!";
                return false;
            }
        }

        if (dv.date_Validate(txtIssueDate.Text) == false)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "FDBC Date Invalid!";
            return false;
        }
        if (dv.date_Validate(txt_FDBPDate.Text) == false)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "FDBP Date Invalid!";
            return false;
        }

        if (txt_FDBP_Taka.Text == "")
        {
            txt_FDBP_Taka.Text = "0";
        }
        else
        {
            if (NV.numeric_Validation_Decimal_Allow_Minus(txt_FDBP_Taka.Text, 1) == false)
            {
                txt_FDBP_Taka.Text = "Error!";
                return false;
            }
        }


        if (txt_FDBP_Dolar.Text == "")
        {
            txt_FDBP_Dolar.Text = "0";
        }
        else
        {
            if (NV.numeric_Validation_Decimal_Allow_Minus(txt_FDBP_Dolar.Text, 1) == false)
            {
                txt_FDBP_Taka.Text = "Error!";
                return false;
            }
        }

        if (txt_FDBP_Rate.Text == "")
        {
            txt_FDBP_Rate.Text = "0";
        }

        if (dd_FileNo.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "File Blank!";
            return false;
        }

        if (dd_CollectionType.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Collection Type Blank!";
            return false;
        }

        if (txt_FDBCNo.Text == "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "FDBC No Blank!";
            return false;
        }

        if (dd_LCNo.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "LC No Blank!";
            return false;
        }

        if (hid_InvoiceRow.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Invoice Grid Blank!";
            return false;
        }

        if (hid_DistributionRow.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Distribution Grid Blank!";
            return false;
        }

        if (hid_ExpenseRow.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Expense Grid Blank!";
            return false;
        }

        return true;
    }

   

    protected void gdv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        //dd_Invoice.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[1].Text.ToString());
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
                    Amount = drow["Invoice_Value"].ToString();

                    Amount = Convert.ToString(Convert.ToDecimal(Amount).ToString("####.000"));

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

                    TotalInvoiceValue();
                }
            }
        }
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
                TotalInvoiceValue();
            }

            if (Convert.ToDouble(hid_InvoiceRow.Value) == 0)
            {
                dd_FileNo.Enabled = true;
                dd_LCNo.Enabled = true;
            }
        }

    }
    private void AddClear()
    {
        dd_Invoice.SelectedValue = "0";
        dd_AccountHead.SelectedValue = "0";
        dd_ExpenseHead.SelectedValue = "0";
        dd_PC.SelectedValue = "0";
        //txt_Rate.Text = string.Empty;

        txt_AmountDollar.Text = string.Empty;
        txt_AmountTK.Text = string.Empty;
        txt_ExpenseAmount.Text = string.Empty;
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

   
    protected void btn_Search_Click(object sender, EventArgs e)
    {

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        DataTable myDt_Distribution = new DataTable();
        myDt_Distribution = CreateDataTable_Distribution();
        ViewState["myDatatable_Distribution"] = myDt_Distribution;

        DataTable myDt_Expense = new DataTable();
        myDt_Expense = CreateDataTable_Expense();
        ViewState["myDatatable_Expense"] = myDt_Expense;

        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;


        if (dd_Search.SelectedValue != "0")
        {
            s_select = "[Proc_Realization_Search]"
                        + "'"
                        + dd_Search.SelectedValue
                        + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {

                        dd_CollectionType.SelectedValue = drow["Realization_Mode"].ToString();

                        dd_FileNo.SelectedValue = drow["File_Ref_Id"].ToString();
                        dd_FileNo_SelectedIndexChanged(sender, e);

                        dd_LCNo.SelectedValue = drow["Export_LC_Id"].ToString();
                        dd_LCNo_SelectedIndexChanged(sender, e);

                        dd_Bank.SelectedValue = drow["Bank_Id"].ToString();
                        dd_Bank_SelectedIndexChanged(sender, e);

                        txt_FDBCNo.Text = drow["FDBC_No"].ToString();
                        txtIssueDate.Text = drow["FDBC_Date"].ToString();
                        txt_FDBCAmount.Text = drow["FDBC_Amount"].ToString();
                        txt_RealizedAmount.Text = drow["Realization_Amount"].ToString();
                        txt_RealizedDate.Text = drow["Realization_date"].ToString();
                        txt_SlNo.Text = drow["SLNO"].ToString();
                        txt_FDBPNo.Text = drow["RP_No"].ToString();

                        if (txt_FDBPNo.Text == "")
                        {
                            txt_FDBPDate.Text = DateTime.Now.ToString();
                            txt_FDBP_Taka.Text = string.Empty;
                            txt_FDBP_Dolar.Text = string.Empty;
                        }
                        else
                        {
                            txt_FDBPDate.Text = drow["RP_Date"].ToString();
                            txt_FDBP_Taka.Text = drow["RP_Amount"].ToString();
                            txt_FDBP_Dolar.Text = drow["RP_Dolar"].ToString();
                            txt_FDBP_Rate.Text = drow["RP_Rate"].ToString();
                        }

                    }

                    // Invoice Part       
                    s_select = "[Proc_Invoice_Search_By_Realization]"
                                 + "'"
                                 + dd_Search.SelectedValue
                                 + "'";

                    s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                    if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (connection.ResultsDataSet.Tables[0] != null)
                        {
                            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                string Export_Id = string.Empty;
                                string Invoice_No = string.Empty;
                                string Invoice_Date = string.Empty;
                                string Amount = string.Empty;

                                Export_Id = drow["Export_Id"].ToString();
                                Invoice_No = drow["Invoice_No"].ToString();
                                Invoice_Date = drow["Invoice_Date"].ToString();
                                Amount = drow["Invoice_Value"].ToString();

                                Amount = Convert.ToString(Convert.ToDecimal(Amount).ToString("####.000"));

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

                                TotalInvoiceValue();
                            }
                        }
                    }
                    
                    //Distribution Part   
                    s_select = "[Proc_Distribution_Search_By_Realization]"
                                         + "'"
                                         + dd_Search.SelectedValue
                                         + "'";

                    s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                    if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (connection.ResultsDataSet.Tables[0] != null)
                        {
                            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                string AccountId = string.Empty;
                                string AccountHead = string.Empty;
                                string PCId = string.Empty;
                                string PCNo = string.Empty;
                                string Rate = string.Empty;
                                string AmountDollar = string.Empty;
                                string AmountTk = string.Empty;
                                
                                AccountId = drow["AccountId"].ToString();
                                AccountHead = drow["AccountHead"].ToString();
                                PCId = drow["PCId"].ToString();
                                PCNo = drow["PCNo"].ToString();
                                Rate = drow["Rate"].ToString();
                                AmountDollar = drow["AmountDollar"].ToString();
                                AmountTk = drow["AmountTk"].ToString();
                               
                                DataTable myDatatable_Distribution = (DataTable)ViewState["myDatatable_Distribution"];
                                AddDataToTable_Distribution(AccountId
                                                            , AccountHead
                                                            , PCId
                                                            , PCNo
                                                            , Rate
                                                            , AmountDollar
                                                            , AmountTk
                                                            , (DataTable)ViewState["myDatatable_Distribution"]
                                                         );

                                this.gdv_Distribution.DataSource = ((DataTable)ViewState["myDatatable_Distribution"]).DefaultView;
                                this.gdv_Distribution.DataBind();

                                hid_DistributionRow.Value = Convert.ToString(Convert.ToDouble(hid_DistributionRow.Value) + 1);

                                TotalDistribusion();
                            }
                        }
                    }
                    ///Distribution Part

                    ///Expense Part   
                    s_select = "[Proc_Expense_Search_By_Realization]"
                                         + "'"
                                         + dd_Search.SelectedValue
                                         + "'";

                    s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                    if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (connection.ResultsDataSet.Tables[0] != null)
                        {
                            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                string ExpenseId = string.Empty;
                                string ExpenseHead = string.Empty;
                                string Amount = string.Empty;
                                string Remarks = string.Empty;

                                ExpenseId = drow["ExpenseId"].ToString();
                                ExpenseHead = drow["ExpenseHead"].ToString();
                                Amount = drow["Amount"].ToString();
                                Remarks = drow["Remarks"].ToString();

                                DataTable myDatatable_Expense = (DataTable)ViewState["myDatatable_Expense"];
                                AddDataToTable_Expense(ExpenseId
                                                     , ExpenseHead
                                                     , Amount
                                                     , Remarks
                                                     , (DataTable)ViewState["myDatatable_Expense"]
                                                     );

                                this.gdv_Expense.DataSource = ((DataTable)ViewState["myDatatable_Expense"]).DefaultView;
                                this.gdv_Expense.DataBind();
                                hid_ExpenseRow.Value = Convert.ToString(Convert.ToDouble(hid_ExpenseRow.Value) + 1);
                            }
                        }
                    }
                   
                    btn_save.Text = "Update";
                }
            }
        }
    }

    protected void gdv_Expense_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_Expense_RowDataBound
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
                e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_Expense, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception exception)
        {
            //lbl_msg_StaffRequisitionDetails.ForeColor = GlobalVariables.g_clr_errorColor;
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_Expense_RowDataBound
    }
    protected void gdv_Expense_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_ExpenseHead.SelectedValue = HttpUtility.HtmlDecode(gdv_Expense.Rows[gdv_Expense.SelectedIndex].Cells[1].Text.ToString());
        txt_ExpenseAmount.Text = HttpUtility.HtmlDecode(gdv_Expense.Rows[gdv_Expense.SelectedIndex].Cells[3].Text.ToString());
        txt_ExpenseRemarks.Text = HttpUtility.HtmlDecode(gdv_Expense.Rows[gdv_Expense.SelectedIndex].Cells[4].Text.ToString());
        hid_Addmode_Expense.Value = "N";
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
        dd_PC.SelectedValue = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[3].Text.ToString());
        txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[5].Text.ToString());
        txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[6].Text.ToString());
        txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Distribution.Rows[gdv_Distribution.SelectedIndex].Cells[7].Text.ToString());
        hid_Addmode_Distribution.Value = "N";
    }

    private Boolean isrequired_Distribution()
    {
        if (dd_AccountHead.SelectedValue == "0")
        {
            lblsubmsgDistribution.Visible = true;
            lblsubmsgDistribution.Text = "Account Head Blank!";
            return false;
        }

        if (dd_AccountHead.SelectedItem.Text == "PC" && dd_PC.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Pls Select PC No !";
            dd_PC.Focus();
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
            if (dr.Cells[1].Text == dd_AccountHead.SelectedValue && dr.Cells[3].Text == dd_PC.SelectedValue)
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
        string pcId = string.Empty;
        string PcNo = string.Empty;

        AccountId = dd_AccountHead.SelectedValue.ToString();
        AccountHead = dd_AccountHead.SelectedItem.ToString();
        //pcId = dd_PC.SelectedValue.ToString();
        //PcNo = dd_PC.SelectedItem.ToString();
        Rate = txt_Rate.Text.ToString();
        AmountDollar = txt_AmountDollar.Text.ToString();
        AmountTk = txt_AmountTK.Text.ToString();


        if (dd_AccountHead.SelectedItem.Text == "PC")
        {
            pcId = dd_PC.SelectedValue.ToString();
            PcNo = dd_PC.SelectedItem.ToString();
        }
        else
        {
            pcId = "0";
            PcNo = "";
        }

        DataTable myDatatable_Distribution = (DataTable)ViewState["myDatatable_Distribution"];
        AddDataToTable_Distribution(AccountId
                                    , AccountHead
                                    , pcId
                                    , PcNo
                                    , Rate
                                    , AmountDollar
                                    , AmountTk
                                    , (DataTable)ViewState["myDatatable_Distribution"]
                                 );

        this.gdv_Distribution.DataSource = ((DataTable)ViewState["myDatatable_Distribution"]).DefaultView;
        this.gdv_Distribution.DataBind();

        hid_DistributionRow.Value = Convert.ToString(Convert.ToDouble(hid_DistributionRow.Value) + 1);

        TotalDistribusion();

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

            TotalDistribusion();
        }
    }


    private void TotalDistribusion()
    {
        float GTotal = 0.00f;

        for (int i = 0; i < gdv_Distribution.Rows.Count; i++)
        {
            String total = (gdv_Distribution.Rows[i].Cells[5]).Text.Trim();
            GTotal += Convert.ToSingle(total);
        }

        txt_Total.Text = String.Format("{0:0,0.00}", GTotal); 
    }

    private void TotalInvoiceValue()
    {
        float GTotal = 0f;
        for (int i = 0; i < gdv_Item.Rows.Count; i++)
        {
            String total = (gdv_Item.Rows[i].Cells[4]).Text.Trim();
            GTotal += Convert.ToSingle(total);
        }
        txt_InvoiceTotal.Text = GTotal.ToString();
    }

    //private void TotalInvoiceValue()
    //{
    //    float GTotal = 0.00f;
    //    for (int i = 0; i < gdv_Item.Rows.Count; i++)
    //    {
    //        String total = (gdv_Item.Rows[i].Cells[4]).Text.Trim();
    //        GTotal += Convert.ToSingle(total);
    //    }
    //    txt_InvoiceTotal.Text = String.Format("{0:0,0.00}", GTotal); 
    //}


    private Boolean isrequired_Expense()
    {
        if (dd_ExpenseHead.SelectedValue == "0")
        {
            lblsubmsgExpense.Visible = true;
            lblsubmsgExpense.Text = "Expense Head Blank!";
            return false;
        }

        if (txt_ExpenseAmount.Text == "" || txt_ExpenseAmount.Text == "0")
        {
            lblsubmsgExpense.Visible = true;
            lblsubmsgExpense.Text = "Amount Blank!";
            return false;
        }

        return true;
    }

    protected void btnExpense_Add_Click(object sender, EventArgs e)
    {
        Connection conn = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();
        string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        Boolean b_required = true;
        lblsubmsgExpense.Visible = false;
        b_required = isrequired_Expense();
        if (b_required == false)
        {
            return;
        }

        if (hid_Addmode_Expense.Value == "N")
        {
            btnExpense_Del_Click(sender, e);
        }
        hid_Addmode_Expense.Value = "Y";

        /// For Duplicate Checking
        foreach (GridViewRow dr in gdv_Expense.Rows)
        {
            if (dr.Cells[1].Text == dd_ExpenseHead.SelectedValue)
            {
                lblsubmsgExpense.Visible = true;
                lblsubmsgExpense.Text = "Already Added!";
                return;
            }
        }

        string ExpenseId = string.Empty;
        string ExpenseHead = string.Empty;
        string Amount = string.Empty;
        string Remarks = string.Empty;

        ExpenseId = dd_ExpenseHead.SelectedValue.ToString();
        ExpenseHead = dd_ExpenseHead.SelectedItem.ToString();
        Amount = txt_ExpenseAmount.Text.ToString();
        Remarks = txt_ExpenseRemarks.Text.ToString();

        DataTable myDatatable_Expense = (DataTable)ViewState["myDatatable_Expense"];
        AddDataToTable_Expense(ExpenseId
                             , ExpenseHead
                             , Amount
                             , Remarks
                             , (DataTable)ViewState["myDatatable_Expense"]
                             );

        this.gdv_Expense.DataSource = ((DataTable)ViewState["myDatatable_Expense"]).DefaultView;
        this.gdv_Expense.DataBind();
        hid_ExpenseRow.Value = Convert.ToString(Convert.ToDouble(hid_ExpenseRow.Value) + 1);

        AddClear();
    }
    protected void btnExpense_Del_Click(object sender, EventArgs e)
    {

        if (gdv_Expense.SelectedIndex != -1)
        {
            hid_Addmode_Expense.Value = "N";
            DataTable dt = (DataTable)ViewState["myDatatable_Expense"];
            dt.Rows[gdv_Expense.SelectedIndex].Delete();
            dt.AcceptChanges();
            gdv_Expense.DataSource = dt;
            gdv_Expense.DataBind();

            if (Convert.ToDouble(hid_ExpenseRow.Value) > 0)
            {
                hid_ExpenseRow.Value = Convert.ToString(Convert.ToDouble(hid_ExpenseRow.Value) - 1);
            }
        }
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


    

    private Boolean isUserCheck()
    {
        Connection connection = new Connection();
        string s_DeleteQry = string.Empty; string s_CheckUser = string.Empty;
        string returnValue = string.Empty;
        string SessionUserId = string.Empty;
        SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);

        s_CheckUser = "SELECT s.autoId as User_Id,s.UserName as UserName FROM T_Realization r left outer Join T_SignIn s ON r.User_Id=s.autoId Where Realization_Id="
                                     + "'"
                                     + dd_Search.SelectedValue
                                     + "'";

        returnValue = connection.connection_DB(s_CheckUser, 0, false, false, false);
        if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (connection.ResultsDataSet.Tables[0] != null)
            {
                foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                {
                    string UserId = string.Empty;
                    string UserName = string.Empty;

                    UserId = drow["User_Id"].ToString();
                    UserName = drow["UserName"].ToString();

                    if (UserId != SessionUserId)
                    {
                        //lblMsg.Text = "Only " + UserName + " can  Edit/Delete!";
                        string message = "Only " + UserName + " can  Edit/Delete!";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
                        return false;
                    }

                }
            }
        }

        return true;
    }

}
