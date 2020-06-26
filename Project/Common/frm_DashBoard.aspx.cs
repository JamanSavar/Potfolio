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

public partial class Common_DashBoard : Page
{
    //private string g_s_userLogBookAutoId ;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            v_loadGridView_CostingHead();
          
            //v_loadGridView_For_CompanyInfo();

        }


    }
    
    private void v_loadGridView_CostingHead()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("proc_DashBoard '%','%'", sqlconnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_costingHead.DataSource = ds;
            gdv_costingHead.DataBind();
            int columncount = gdv_costingHead.Rows[0].Cells.Count;
            gdv_costingHead.Rows[0].Cells.Clear();
            gdv_costingHead.Rows[0].Cells.Add(new TableCell());
            gdv_costingHead.Rows[0].Cells[0].ColumnSpan = columncount;
            //gdv_ChildrenInfo.Rows[0].Cells[0].Text = "No Records Found";

        }
        else
        {
            gdv_costingHead.DataSource = ds;
            gdv_costingHead.DataBind();
        }
        sqlconnection.Close();
    }



    protected void btn_save_Click(object sender, EventArgs e)
    {

        Connection connection = new Connection();
       
        string UserAutoId = Session[GlobalVariables.g_s_userAutoId].ToString();
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
            s_Update = "[proc_frm_CDExpenseHead_Update_T_CDExpenseHead]"
            + "'"
            + gdv_costingHead.Rows[gdv_costingHead.SelectedIndex].Cells[1].Text.Trim()
            + "','"
            + HttpUtility.HtmlDecode(txt_GroupName.Text.Trim())
            + "'";


            s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, true);
            //s_Update_returnValue = connection.connection_DB(s_Update, 1, false, true, true);


            if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {

                if (s_Update_returnValue == GlobalVariables.g_s_procedureDuplicateReturnValue)
                {

                    //lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                    lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                    
                }

                else
                {
                    lblMsg.Text = GlobalVariables.g_s_updateOperationSuccessfull;
                    v_loadGridView_CostingHead();
                    InsertMode();

                }
            }
        }
        else
        {



                                        s_save_ = "[proc_frm_CDExpenseHead_Insert_T_CD_Expense_Head]"
                                                + "'"
                                                + HttpUtility.HtmlDecode(txt_GroupName.Text.Trim())
                                                + "','"
                                                + UserAutoId
                                                + "'";


                                    s_returnValue = connection.connection_DB(s_save_, 1, true, true, true);


                                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                                    {
                                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                                        {
                                            lblMsg.Text = GlobalVariables.g_s_insertOperationSuccessfull;
                                            v_loadGridView_CostingHead();
                                            InsertMode();
                                        }
                                        else
                                        {
                                            lblMsg.Text = GlobalVariables.g_s_duplicateCheckWarningMessage;
                                        }

                                    }
                                    else
                                    {
                                        lblMsg.Text = GlobalVariables.g_s_insertOperationFailed;
                                    }



        }
        

    }
    protected void gdv_costingHead_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_ChildrenInfo_RowDataBound
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
                e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_costingHead, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception exception)
        {
            //lbl_msg_StaffRequisitionDetails.ForeColor = GlobalVariables.g_clr_errorColor;
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_RowDataBound
    }
    protected void gdv_costingHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region gdv_ChildrenInfo_SelectedIndexChanged
        try
        {

            txt_GroupName.Text = HttpUtility.HtmlDecode(gdv_costingHead.Rows[gdv_costingHead.SelectedIndex].Cells[2].Text.ToString());
            btn_save.Text = "Update";



        }
        catch (Exception exception)
        {

            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }
    //protected void btn_remove_Click(object sender, EventArgs e)
    //{
    //    Connection connection = new Connection();

    //    string S_Delete_T_LeaveAssignByHR = string.Empty;
    //    S_Delete_T_LeaveAssignByHR = "proc_frm_CompanyInfo_Delete_T_CompanyInfo_LCM"
    //         + "'"
    //         + gdv_costingHead.Rows[gdv_costingHead.SelectedIndex].Cells[1].Text.Trim()
    //         + "'";


    //    string S_DeleteReturn_T_LeaveAssignByHR = string.Empty;
    //    S_DeleteReturn_T_LeaveAssignByHR = connection.connection_DB(S_Delete_T_LeaveAssignByHR, 1, false, true, true);

    //    if (S_DeleteReturn_T_LeaveAssignByHR != GlobalVariables.g_s_connectionErrorReturnValue)
    //    {


    //        lblMsg.Text = GlobalVariables.g_s_deleteOperationSuccessfull;
    //        v_loadGridView_CostingHead();
    //        InsertMode();

    //    }
    //    else
    //    {
    //        lblMsg.Text = GlobalVariables.g_s_deleteOperationFailed;
    //    }
    //}
    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        //InsertMode();
        //InsertMode_Msg();
        v_loadGridView_CostingHead();
    }
    private void InsertMode_Msg()
    {

        btn_save.Text = "Save";
        lblMsg.Text = string.Empty;
    }

    private Boolean isValid()
    {
        //CommonFunctions commonFunctions = new CommonFunctions();

        if (txt_GroupName.Text == "")
        {

            lblMsg.Visible = true;
            lblMsg.Text = "Costing Head Can Not Blank!";
            return false;
        }

        return true;
    }

    private void InsertMode()
    {
        btn_save.Text = "Save";
        txt_GroupName.Text = string.Empty;
    }
    private void NoOfDatesBetweenTwoDates()
    {
        //string year_ = Convert.ToDateTime(txtTo.Text, new CultureInfo("fr-FR")).ToString("yyyy");
        //int i_year_ = Convert.ToInt32(year_);
        //string month_ = Convert.ToDateTime(txtTo.Text, new CultureInfo("fr-FR")).ToString("MM");
        //int i_month_ = Convert.ToInt32(month_);
        //string day_ = Convert.ToDateTime(txtTo.Text, new CultureInfo("fr-FR")).ToString("dd");
        //int i_day_ = Convert.ToInt32(day_);

        //string year = Convert.ToDateTime(txtFrom.Text, new CultureInfo("fr-FR")).ToString("yyyy");
        //int i_year = Convert.ToInt32(year);
        //string month = Convert.ToDateTime(txtFrom.Text, new CultureInfo("fr-FR")).ToString("MM");
        //int i_month = Convert.ToInt32(month);
        //string day = Convert.ToDateTime(txtFrom.Text, new CultureInfo("fr-FR")).ToString("dd");
        //int i_day = Convert.ToInt32(day);

        //DateTime d1 = new DateTime(i_year_, i_month_, i_day_);
        //string s_Date = Convert.ToString(d1.AddDays(1));
        //DateTime d2 = new DateTime(i_year, i_month, i_day);



        //TimeSpan TS = Convert.ToDateTime(s_Date) - d2;
        //double NrOfDays = TS.TotalDays;

        ////txtNoOfDays.Text = Convert.ToString(NrOfDays);
    }
    
    //protected void txtTo_TextChanged(object sender, EventArgs e)
    //{

    //    NoOfDatesBetweenTwoDates();

    //}
}
