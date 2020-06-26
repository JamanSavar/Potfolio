using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;
using System.IO;

public partial class Finance_ReportsUI_RptRealization : System.Web.UI.Page
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

            commonfunctions.g_b_FillDropDownList(dd_RealizationId,
                 "TBL_Realization",
                 "FDBC_No",
                 "Realization_Id", string.Empty);

           
            if (!commonfunctions.g_b_formsEntryAuthentication())
            {
                Response.Redirect(GlobalVariables.g_s_URL_loginPage);
            }
        }
    }

    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {
            string CompanyId = string.Empty;
            CompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

            Boolean b_validationReturn = true;

            lbl_msg.Visible = false;
            b_validationReturn = isReportValid();

            if (b_validationReturn == false)
            {
                return;
            }

            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString() + "," + Session[GlobalVariables.g_s_City].ToString() + "," + Session[GlobalVariables.g_s_Country].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString() + "," + Session[GlobalVariables.g_s_Fax].ToString() + "," + Session[GlobalVariables.g_s_Email].ToString());



            if (chkPendingFDBC.Checked == true)
            {

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "Pending FDBC Info");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_FDBC_Panding_Info.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_FDBC_Panding_Info"
                                                              + "'"
                                                              + hid_BuyerId.Value.ToString()
                                                              + "','"
                                                              + hid_FileId.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }
            
            if (chkPendingRealization.Checked == true)
            {

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "Pending Realization Info");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_Realization_Panding.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_Realization_Panding_Info"
                                                          + "'"
                                                          + CompanyId
                                                          + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }

            if (chkFDBC.Checked == true)
            {

                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "FDBC Details Sheet");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_FDBC_Details_Sheet.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_FDBC_Details_Sheet"
                                                          + "'"
                                                          + hid_BuyerId.Value.ToString()
                                                          + "','"
                                                          + hid_FileId.Value.ToString()
                                                          + "','"
                                                          + hid_RealizationId.Value.ToString()
                                                          + "','"
                                                          + CompanyId
                                                          + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }
            if (chkRealization.Checked == true)
            {
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "Realization Details Summary");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_Realization_Allocations.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_Realization_Allocations"
                                                          + "'"
                                                          + hid_BuyerId.Value.ToString()
                                                          + "','"
                                                          + hid_FileId.Value.ToString()
                                                          + "','"
                                                          + hid_RealizationId.Value.ToString()
                                                          + "','"
                                                          + CompanyId
                                                          + "'";

                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
            }

            if (chkDistribution.Checked == true)
            {
                //TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "Realization Distribution Details");
                //TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_Realization_Distribution.rpt";

                //TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_Realization_Distribution"
                //                                          + "'"
                //                                          + hid_FileId.Value.ToString()
                //                                          + "'";

                //Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
            }

            
            else 
            {
                    
            }
        }

        catch (Exception)
        {
            string message = "error";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
        }
    }


    private Boolean isReportValid()
    {
        hid_BuyerId.Value = "%";
        hid_FileId.Value = "%";
        hid_RealizationId.Value = "%";
        hid_PC_Id.Value = "%";

        if (dd_Buyer.SelectedValue != "0")
        {
            hid_BuyerId.Value = dd_Buyer.SelectedValue.ToString() + "X%";
        }

        if (dd_FileNo.SelectedValue != "0")
        {
            hid_FileId.Value = dd_FileNo.SelectedValue.ToString() + "X%";
        }

        if (dd_RealizationId.SelectedValue != "0")
        {
            hid_RealizationId.Value = dd_RealizationId.SelectedValue.ToString() + "X%";
        }

        

        return true;
    }
}