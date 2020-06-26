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

public partial class Finance_UI_frmOpeningBalance : System.Web.UI.Page
{

    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hid_AutoId.Value = "0";

            CommonFunctions commonfunctions = new CommonFunctions();
            txtIssueDate.Text = DateTime.Now.ToString();
          
           commonfunctions.g_b_FillDropDownList(dd_Head,
              "T_Distribution_Account_Head",
              "Accounts_Head",
              "Accounts_Id", string.Empty);

          
            btn_save.Text = "Save";

            v_loadGridView_Item();
            Load_Account_Opening_Balance();
            hid_AutoId.Value = "0";
 
        }
    }


    protected void Load_Account_Opening_Balance()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("Proc_Select_Account_Opening_Balance", sqlconnection);
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


    private void FileWise_PC_Load()
    {
        //CommonFunctions commonfunctions = new CommonFunctions();
        //Connection conn = new Connection();
        //string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

        //hid_LcId.Value = dd_LC.SelectedValue;

        //if (dd_Search.SelectedValue == "0")
        //{
        //    s_OrderLoadCondition = "[Proc_LC_Wise_PC_Load]"
        //                     + "'"
        //                     + hid_LcId.Value
        //                     + "','"
        //                     + "Y"
        //                     + "'";
        //}
       
        //else
        //{
        //    s_OrderLoadCondition = "[Proc_LC_Wise_PC_Load]"
        //                     + "'"
        //                     + hid_LcId.Value
        //                     + "','"
        //                     + "N"
        //                     + "'";
        //}

        //returnValue = conn.connection_DB(s_OrderLoadCondition, 0, false, false, false);
        //if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        //{
        //    if (conn.ResultsDataSet.Tables[0] != null)
        //    {
        //        commonfunctions.g_b_FillDropDownList(dd_PC, conn.ResultsDataSet.Tables[0], "ItemName", "ItemId");
        //    }
        //}
 
    }

    private void v_loadGridView_Item()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as FileId ,'' as Dolar,'' as Taka,'' as Remarks, '' as Rate,'' as HeadId,'' as Head, '' as trDate ", sqlconnection);

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

    private void InsertMode_Msg()
    {
        lblMsg.Text = string.Empty;
    }

    private void ClearMode()
    {
        //dd_FileNo.SelectedValue = "0";
        //dd_LC.SelectedValue = "0";
        //dd_PCNo.SelectedValue = "0";
        //dd_FileNo.Focus();

        dd_Head.SelectedValue = "0";
        txt_AmountDollar.Text = string.Empty;
        
    }


    private void InsertMode()
    {

        txt_AmountDollar.Text = string.Empty;

        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        v_loadGridView_Item();

        hid_Rownumber.Value = "0";
        btn_save.Text = "Save";

        
    }



    private Boolean isrequired_Detail()
    {


        if (dd_Head.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Head Can Not Blank!";
            return false;
        }

        if (txt_AmountDollar.Text == "" || txt_AmountDollar.Text == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Amount Doler  Blank!!";
            txt_AmountDollar.Focus();
            return false;
        }

        return true;
    }



    private Boolean isrequired()
    {

        if (hid_Rownumber.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Item Grid Can Not Blank!";
            return false;
        }

        //if (txt_Delivary.Text == "")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Delivery To Can Not Blank!";
        //    return false;
        //}

        return true;
    }


    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        //CommonFunctions commonfunctions = new CommonFunctions();
        //String FileId = "0";
        //FileId = dd_FileNo.SelectedValue;

        //commonfunctions.g_b_FillDropDownList(dd_LC,
        //   "TBL_Export_LC",
        //   "Export_LC_No",
        //   "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");
    }



    //protected void dd_LC_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FileWise_PC_Load();
    //}

    //protected void dd_PC_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (dd_PC.SelectedValue != "0")
    //    {
    //        Connection connection = new Connection();
    //        string s_select = string.Empty;
    //        string s_Select_returnValue = string.Empty;

    //        s_select = "[Proc_PC_Wise_Value]"
    //                   + "'"
    //                   + dd_PC.SelectedValue
    //                   + "';";

    //        s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
    //        if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
    //        {
    //            if (connection.ResultsDataSet.Tables != null)
    //            {
    //                foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
    //                {
    //                    txt_PCValue.Text = drow["PCValue"].ToString();
    //                }
    //            }
    //        }
    //    }
       
    //}

   
    protected void gdv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_ChildrenInfo_RowDataBound
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
        #endregion gdv_ChildrenInfo_RowDataBound
    }


    protected void gdv_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region gdv_ChildrenInfo_SelectedIndexChanged
        
        try
        {
           
            hid_AutoId.Value = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());

            //dd_FileNo.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());
            //dd_FileNo_SelectedIndexChanged(sender, e);

            dd_Head.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());
            txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[4].Text.ToString());
            txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());
            txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[6].Text.ToString());
            txt_Remarks.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[7].Text.ToString());
            txtIssueDate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[8].Text.ToString());

            hid_Addmode.Value = "N";
            btn_save.Text = "Update";

        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }




    private Boolean isValid()
    {
        //if (dd_Search.SelectedValue != "0")
        //{
        //    hid_AutoId.Value = dd_Search.SelectedValue;
        //}

        //---------------------------------------
        //if (dd_FileNo.SelectedValue == "0")
        //{
        //    string message = "File No Can Not Blank!";
        //    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
        //    dd_FileNo.Focus();
        //    return false;
        //}

        return true;
    }


    protected void btn_save_Click(object sender, EventArgs e)
    {

        Connection connection = new Connection();
        DataTable dt = (DataTable)ViewState["myDatatable"];
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
            //s_Update = "[Proc_Inv_Goods_Opening_Balance_UPDATE]"
            //+ "'"
            //+ hid_autoId.Value
            //+ "','"
            //+ Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            //+ "','"
            //+ "0"
            //+ "','"
            //+ dd_ItemHead.SelectedValue
            //+ "','"
            //+ dd_Item.SelectedValue
            //+ "','"
            //+ "0"
            //+ "','"
            //+ HttpUtility.HtmlDecode(txt_Qty.Text.Trim())
            //+ "','"
            //+ dd_Unit.SelectedValue
            //+ "','"
            //+ HttpUtility.HtmlDecode(txt_UnitPrice.Text.Trim())
            //+ "','"
            //+ HttpUtility.HtmlDecode(txt_TTLVal.Text.Trim())
            //+ "'";

            //s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, true);

            //if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            //{
            //    if (s_Update_returnValue == GlobalVariables.g_s_procedureDuplicateReturnValue)
            //    {
            //        string message = "Value Exists!";
            //        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
            //    }
            //    else
            //    {
            //        lblMsg.Visible = true;
            //        lblMsg.Text = "Update Successfull!";
            //        //string message = "Update Successfull!";
            //        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
            //        InsertMode();

            //    }
            //}
        }
        else
        {
            s_save_ = "[Proc_Account_Opening_Balance_INSERT]"
                    + "'"
                    + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                    + "','"
                    + dd_Head.SelectedValue
                    + "','"
                    + HttpUtility.HtmlDecode(txt_AmountDollar.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_AmountTK.Text.Trim())
                    + "','"
                    + HttpUtility.HtmlDecode(txt_Rate.Text.Trim())
                    + "','"
                    + SessionUserId
                    + "','"
                    + SessionCompanyId
                    + "'";

            s_returnValue = connection.connection_DB(s_save_, 1, true, true, true);


            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Saved Successfull!";
                    //string message = "Saved Successfull!";
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
                    InsertMode();
                }
                else
                {
                    string message = "Already Exists!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);
                }

            }
            else
            {
                string message = "Operation Failed!";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

            }

        }


    }


    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }


   
}


