using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;
using System.IO;

public partial class Finance_ReportsUI_RptFileWisePC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();

        if (!IsPostBack)
        {
            txt_fromDate.Text = DateTime.Now.ToString();
            txt_toDate.Text = DateTime.Now.ToString();

            commonfunctions.g_b_FillDropDownList(dd_Buyer,
               "T_Buyer",
               "Name",
               "Buyer_Id", "WHERE  Buyer_Id IN (SELECT BuyerId FROM TBL_Order_CheckList) ");

            commonfunctions.g_b_FillDropDownList(dd_FileNo,
                  "TBL_Export_LC_FileNo_BTB_Percent",
                  "File_Ref_No",
                  "File_Ref_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_PCNO,
                 "TBL_PC_Approval",
                 "PC_Number",
                 "AutoId", string.Empty);


         
            if (!commonfunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }

            AcceptedLC_Load();
        }
    }

    private void AcceptedLC_Load()
    {
        CommonFunctions commonfunctions = new CommonFunctions();

        string qry = string.Empty;
        qry = "Proc_AcceptedLC_Load";
        commonfunctions.g_b_FillDropDownListByQurey(dd_LC, qry);

    }

    protected void dd_Buyer_SelectedIndexChanged(object sender, EventArgs e)
    {

        //CommonFunctions commonfunctions = new CommonFunctions();

        //String buyerId = "0";
        //buyerId = dd_Buyer.SelectedValue;

        //commonfunctions.g_b_FillDropDownList(dd_Buyer,
        //      "TBL_Export_LC",
        //      "Name",
        //      "Buyer_Id", "WHERE  Buyer_Id IN (SELECT BuyerId FROM TBL_Order_CheckList) ");


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



    protected void btn_Preview_Click(object sender, EventArgs e)
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

            String dateStatus = "N";

            if (chkDate.Checked == true)
            {
                dateStatus = "Y";
            }

            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());


            if (chkPending.Checked == true)
            {
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "Pending PC Info");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_PC_Pending.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_PC_Pending"
                                                              + "'"
                                                              + CompanyId
                                                              + "'";


                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }

            if (chkTaken.Checked == true)
            {

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "FILE WISE PC SUMMARY");
                // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Period_8", "Period : " + Convert.ToDateTime(txt_fromDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy") + " --- " + Convert.ToDateTime(txt_toDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy"));

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\File_Wise_PC.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_PC_Details_Sheet"
                                                              + "'"
                                                              + hid_BuyerId.Value.ToString()
                                                              + "','"
                                                              + hid_File_Id.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
            }

            if (chkPCWise.Checked == true)
            {
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "LC WISE PC DETAIS");
                // TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Period_8", "Period : " + Convert.ToDateTime(txt_fromDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy") + " --- " + Convert.ToDateTime(txt_toDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy"));

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\RPT_PC_Details_LCWise.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_PC_Details_LCWise"
                                                              + "'"
                                                              + hid_BuyerId.Value.ToString()
                                                              + "','"
                                                              + hid_File_Id.Value.ToString()
                                                              + "','"
                                                              + hid_PC_Id.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";



                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
            }

            if (chkAdjust.Checked == true)
            {
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "PC Loan Details Info");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_PC_Details_Info.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_PC_Details_Info"
                                                              + "'"
                                                              + hid_BuyerId.Value.ToString()
                                                              + "','"
                                                              + hid_File_Id.Value.ToString()
                                                              + "','"
                                                              + hid_PC_Id.Value.ToString()
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


    private Boolean isValid()
    {
        hid_BuyerId.Value = "%";
        hid_File_Id.Value = "%";
        hid_PC_Id.Value = "%";

        if (dd_Buyer.SelectedValue != "0")
        {
            hid_BuyerId.Value = dd_Buyer.SelectedValue.ToString() + "X%";
        }

        if (dd_FileNo.SelectedValue != "0")
        {
            hid_File_Id.Value = dd_FileNo.SelectedValue.ToString() + "X%";
        }

        if (dd_PCNO.SelectedValue != "0")
        {
            hid_PC_Id.Value = dd_PCNO.SelectedValue.ToString() + "X%";
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



   
}