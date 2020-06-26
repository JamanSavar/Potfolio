using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.UI;
using System.IO;

public partial class Finance_ReportsUI_RptFileWiseCM : System.Web.UI.Page
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


            if (chkPendingFDBP.Checked == true)
            {

                //TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "Pending FDBP Info");
                //TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_FDBP_Pending_Info.rpt";

                //TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_FDBP_Pending_Info"
                //                                          + "'"
                //                                          + CompanyId
                //                                          + "'";

                //Response.Redirect(GlobalVariables.g_s_URL_reportViewer);

            }
           
            
            if (chkFDBP.Checked == true)
            {
                TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "FDBP Details Sheet");
                TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\Rpt_FDBP_Details_Info.rpt";

                TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_FDBP_Details_Info"
                                                              + "'"
                                                              + hid_RealizationId.Value.ToString()
                                                              + "','"
                                                              + CompanyId
                                                              + "'";
                Response.Redirect(GlobalVariables.g_s_URL_reportViewer);
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