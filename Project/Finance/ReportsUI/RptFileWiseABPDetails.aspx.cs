using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;
using System.IO;

public partial class Commercial_ReportsUI_RptFileWiseABPDetails : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();
        if (!IsPostBack)
        {
            commonfunctions.g_b_FillDropDownList(dd_File,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Buyer,
              "T_Buyer",
              "Name",
              "Buyer_Id", "WHERE  Buyer_Id IN (SELECT BuyerId FROM TBL_Order_CheckList) Order By Name ");

            if (!commonfunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }
        }
    }

    protected void dd_Buyer_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();

        String buyerId = "0";
        buyerId = dd_Buyer.SelectedValue;

        if (buyerId != "0")
        {
            string qry = string.Empty;
            qry = "Proc_BuyerWise_File_Load '" + buyerId + "'";
            commonfunctions.g_b_FillDropDownListByQurey(dd_File, qry);

        }
        else
        {
            commonfunctions.g_b_FillDropDownList(dd_File,
               "TBL_Export_LC_FileNo_BTB_Percent",
               "File_Ref_No",
               "File_Ref_Id", string.Empty);
        }
    }

    protected void txtEmpName_TextChanged(object sender, EventArgs e)
    {
        g_b_FillDropDownList(dd_File);
        dd_File.Focus();
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
            //DataSet dataSet = new DataSet();
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

    private Boolean isValid()
    {
        CommonFunctions commonFunctions = new CommonFunctions();

        hid_FileId.Value = "%";

        if (dd_File.SelectedValue != "0")
        {
            hid_FileId.Value = dd_File.SelectedValue.ToString() + "X%";
        }

        return true;
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            string CompanyId = string.Empty;
            CompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

            Boolean b_validationReturn = true;

            lbl_msg.Visible = false;
            b_validationReturn = isValid();

            if (b_validationReturn == false)
            {
                return;
            }


            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());


            if (chkABPDue.Checked == true)
            {
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "FILE WISE ABP LIBALITY");

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\File_Wise_ABP_Libality.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_ABP_Due_Sheet"
                                                              + "'"
                                                              + hid_FileId.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
            }

            else
            {


                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "File Wise ABP Details");

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\File_Wise_ABP_Details.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_File_Wise_ABP_Details"
                                                              + "'"
                                                              + hid_FileId.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }
        }

        catch (Exception)
        {
            string message = "error";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
        }
    }


    protected void testMethod(object sender, EventArgs e)
    {
        Session[SessionKeys.EMPLOYEE_AUTOID] = dd_File.SelectedValue;
        //Session[SessionKeys.FROM_DATE] = txt_fromDate.Text;
        //Session[SessionKeys.TO_DATE] = txt_toDate.Text;

    }


    private class SessionKeys
    {
        private SessionKeys()
        { }
        public const string EMPLOYEE_AUTOID = "EMPLOYEE_AUTOID";
        public const string FROM_DATE = "FROM_DATE";
        public const string TO_DATE = "TO_DATE";

    }


   

    

}