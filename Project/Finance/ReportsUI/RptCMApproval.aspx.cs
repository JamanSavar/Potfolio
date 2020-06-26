using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;
using System.IO;

public partial class Commercial_ReportsUI_RptCMApproval : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFunctions commonfunctions = new CommonFunctions();

        if (!IsPostBack)
        {
            commonfunctions.g_b_FillDropDownList(dd_Buyer,
               "T_Buyer",
               "Name",
               "Buyer_Id", "WHERE  Buyer_Id IN (SELECT BuyerId FROM TBL_Order_CheckList) ");

            commonfunctions.g_b_FillDropDownList(dd_FileNo,
                  "TBL_Export_LC_FileNo_BTB_Percent",
                  "File_Ref_No",
                  "File_Ref_Id", string.Empty);

         
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

           
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());

            if (chkApproved.Checked == true)
            {

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "CM PURCHASE APPROVAL");
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Period_8", "Period : " + Convert.ToDateTime(txt_fromDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy") + " --- " + Convert.ToDateTime(txt_toDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy"));

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_CM_Purchase_Details.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_CM_Purchase_Details"
                                                              + "'"
                                                              + hid_BuyerId.Value.ToString()
                                                              + "','"
                                                              + hid_File_Id.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }
            if (chkNoPropose.Checked == true)
            {

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "CM PURCHASE NOT PROPOSE");
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Period_8", "Period : " + Convert.ToDateTime(txt_fromDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy") + " --- " + Convert.ToDateTime(txt_toDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MMM, dd yyyy"));

                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_CM_Purchase_Not_Proposed.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_CM_Purchase_Not_Proposed"
                                                              + "'"
                                                              + hid_BuyerId.Value.ToString()
                                                              + "','"
                                                              + hid_File_Id.Value.ToString()
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

        if (dd_Buyer.SelectedValue != "0")
        {
            hid_BuyerId.Value = dd_Buyer.SelectedValue.ToString() + "X%";
        }

        if (dd_FileNo.SelectedValue != "0")
        {
            hid_File_Id.Value = dd_FileNo.SelectedValue.ToString() + "X%";
        }

        

       // CommonFunctions commonFunctions = new CommonFunctions();
        //CommonFunctions.Date_Validation dv = new CommonFunctions.Date_Validation();
        //if (dv.date_Validate(txt_fromDate.Text) == false)
        //{
        //    lbl_msg.Visible = true;
        //    lbl_msg.Text = "From Date is Invalid!";
        //    return false;
        //}
        //if (dv.date_Validate(txt_toDate.Text) == false)
        //{
        //    lbl_msg.Visible = true;
        //    lbl_msg.Text = "To Date is Invalid!";
        //    return false;
        //}

        return true;
    }



   
}