using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;
using System.IO;

public partial class Commercial_ReportsUI_RptCashLC : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();

        if (!IsPostBack)
        {
            commonfunctions.g_b_FillDropDownList(dd_FileNo,
                   "TBL_Export_LC_FileNo_BTB_Percent",
                   "File_Ref_No",
                   "File_Ref_Id", string.Empty);


            commonfunctions.g_b_FillDropDownListMultiColumn(dd_Supplier,
              "T_Supplier",
              "Name",
              "Address",
              "Supplier_Id", "WHERE  Supplier_Id IN (SELECT Pay_Supplier_Id FROM TBL_Cash_LC) ");
   

            txt_fromDate.Text = DateTime.Now.ToString();
            txt_toDate.Text = DateTime.Now.ToString();

            if (!commonfunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }
            
        }
    }

    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        CommonFunctions commonfunctions = new CommonFunctions();
        String FileId = "0";
        FileId = dd_FileNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_LC,
           "TBL_Export_LC",
           "Export_LC_No",
           "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");
    }


    void v_setEmployeeDropdown()
    {
        dd_Supplier.SelectedValue = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
        if (Convert.ToString(Session[GlobalVariables.g_s_userStatus]) == "Ge" || Convert.ToString(Session[GlobalVariables.g_s_userStatus]) == "Ad")
        {
            dd_Supplier.Enabled = false; 
        }
        else
        {
            dd_Supplier.Enabled = true;
        }
    }
    private void findDatePart()
    {
        txt_fromDate.Text = DateTime.Now.ToString();
        txt_toDate.Text = DateTime.Now.ToString();
    }
    protected void txtEmpName_TextChanged(object sender, EventArgs e)
    {
        g_b_FillDropDownList(dd_Supplier);
        dd_Supplier.Focus();
    }

    private void g_b_FillDropDownList(DropDownList dd_dropDownList)
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

            returnValue = connection.connection_DB(sql_query, 0, false, false, false);
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet == null)
                {
                    lbl_msg.Text = "Error in SQL";
                }
                else
                {
                    if (connection.ResultsDataSet.Tables == null)
                    {
                        lbl_msg.Text = "No Data Found";
                    }
                    else
                    {
                        commonFunctions.g_b_FillDropDownList(dd_dropDownList, connection.ResultsDataSet.Tables[0], "empName", "empAutoId");
                    }
                }
            }
        }
        catch (Exception exception)
        {
            lbl_msg.Text = exception.Message;
        }
    }

   
    protected void testMethod(object sender, EventArgs e)
    {
        Session[SessionKeys.EMPLOYEE_AUTOID] = dd_Supplier.SelectedValue;
        Session[SessionKeys.FROM_DATE] = txt_fromDate.Text;
        Session[SessionKeys.TO_DATE] = txt_toDate.Text;

    }
    private class SessionKeys
    {
        private SessionKeys()
        { }
        public const string EMPLOYEE_AUTOID = "EMPLOYEE_AUTOID";
        public const string FROM_DATE = "FROM_DATE";
        public const string TO_DATE = "TO_DATE";

    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            Boolean b_validationReturn = true;

            lbl_msg.Visible = false;
            b_validationReturn = isValid();

            if (b_validationReturn == false)
            {
                return;
            }

            String dateStatus = "N";

            if (chkDate.Checked == true)
            {
                dateStatus = "Y";
            }

            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "CASH LC DETAILS");

            TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\RPT_File_Wise_Cash_LC.rpt";

            TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_File_WISE_Cash_LC"
                                                          + " '"
                                                          + hid_FileId.Value.ToString()
                                                          + "','"
                                                          + hid_SupplierId.Value.ToString()
                                                          + "','"
                                                          + dateStatus
                                                          + "','"
                                                          + Convert.ToDateTime(txt_fromDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                                                          + "','"
                                                          + Convert.ToDateTime(txt_toDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                                                          + "'";


            Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

        }

        catch (Exception)
        {
            string message = "error";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
        }
    }

    private Boolean isValid()
    {
        hid_FileId.Value = "%";
        hid_SupplierId.Value = "%";

        if (dd_FileNo.SelectedValue != "0")
        {
            hid_FileId.Value = dd_FileNo.SelectedValue.ToString() + "X%";
        }

        if (dd_Supplier.SelectedValue != "0")
        {
            hid_SupplierId.Value = dd_Supplier.SelectedValue.ToString() + "X%";
        }



        CommonFunctions commonFunctions = new CommonFunctions();
        CommonFunctions.Date_Validation dv = new CommonFunctions.Date_Validation();
        if (dv.date_Validate(txt_fromDate.Text) == false)
        {
            lbl_msg.Visible = true;
            lbl_msg.Text = "From Date is Invalid!";
            return false;
        }
        if (dv.date_Validate(txt_toDate.Text) == false)
        {
            lbl_msg.Visible = true;
            lbl_msg.Text = "To Date is Invalid!";
            return false;
        }

        return true;
    }



    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        insertMode();
    }

    void insertMode()
    {
        txt_fromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txt_toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        lbl_msg.Text = string.Empty;
    }
}
