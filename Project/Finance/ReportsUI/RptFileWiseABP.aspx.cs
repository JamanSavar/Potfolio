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

public partial class Finance_ReportsUI_RptFileWiseABP : System.Web.UI.Page
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

            if (!commonfunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }
        }
    }

    
    // MY Developed-------------------------

    //protected void btn_search_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Boolean b_validationReturn = true;

    //        lbl_msg.Visible = false;
    //        b_validationReturn = isValid();

    //        if (b_validationReturn == false)
    //        {
    //            return;
    //        }

    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();

    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());
    //        TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "ABP STATEMENT");

    //        TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\RPT_ABP_Statement.rpt";

    //        TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_File_Wise_ABP_Statement"
    //                                                      + " '"
    //                                                      + hid_SupplierId.Value.ToString()
    //                                                      + "'";

    //        Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

    //    }

    //    catch (Exception)
    //    {

    //    }

    //}


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

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());

               
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "FILE WISE ABP");

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_BTB_With_ABP_Statement_New.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_File_Wise_ABP_Statement_Info" //Proc_File_Wise_ABP_Statement
                                                              + "'"
                                                              + hid_FileId.Value.ToString()
                                                              + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
            
        }

        catch (Exception)
        {

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
    private Boolean isValid()
    {
        CommonFunctions commonFunctions = new CommonFunctions();

        CommonFunctions.Date_Validation dv = new CommonFunctions.Date_Validation();

        hid_FileId.Value = "0";
        if (dd_File.SelectedValue == "0")
        {
            lbl_msg.Visible = true;
            lbl_msg.Text = "File No Blank!";
            return false;
        }
        else
        {
            hid_FileId.Value = dd_File.SelectedValue.ToString();
        }

        return true;
    }

    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        insertMode();
    }

    void insertMode()
    {
        //txt_fromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //txt_toDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        dd_File.SelectedValue = "0";
        lbl_msg.Text = string.Empty;
    }
}