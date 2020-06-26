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


public partial class Finance_UI_frmFileStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunctions commonfunctions = new CommonFunctions();

            commonfunctions.g_b_FillDropDownList(dd_File,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);


            commonfunctions.g_b_FillDropDownList(dd_Status,
                "T_Status",
                "trStatus",
                "Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_Buyer,
              "T_Buyer",
              "Name",
              "Buyer_Id", string.Empty);

            commonfunctions.g_b_FillDropDownList(dd_File,
             "TBL_Export_LC_FileNo_BTB_Percent",
             "File_Ref_No",
             "File_Ref_Id", string.Empty);

            v_loadGridView_Fabric();
            Load_All_Active_Files();

        }

    }

    //protected void dd_Buyer_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    CommonFunctions commonfunctions = new CommonFunctions();

    //    String buyerId = "0";
    //    buyerId = dd_Buyer.SelectedValue;


    //    if (buyerId != "0")
    //    {
    //        string qry = string.Empty;
    //        qry = "Proc_Buyer_Wise_File_Load '" + buyerId + "'";
    //        commonfunctions.g_b_FillDropDownListByQurey(dd_File, qry);

    //    }
    //    else
    //    {

    //        commonfunctions.g_b_FillDropDownList(dd_File,
    //           "TBL_Export_LC_FileNo_BTB_Percent",
    //           "File_Ref_No",
    //           "File_Ref_Id", string.Empty);
    //    }
    //}



    protected void gdv_Fabric_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        #region gdv_ChildrenInfo_RowDataBound
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = GlobalVariables.g_s_style_onmouseover;
                e.Row.Attributes["onmouseout"] = GlobalVariables.g_s_style_onmouseout;
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gdv_Fabric, "Select$" + e.Row.RowIndex);
            }
        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_RowDataBound
    }


    protected void gdv_Fabric_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region gdv_ChildrenInfo_SelectedIndexChanged
        try
        {
            dd_Buyer.SelectedValue = HttpUtility.HtmlDecode(gdv_Fabric.Rows[gdv_Fabric.SelectedIndex].Cells[1].Text.ToString());
            dd_File.SelectedValue = HttpUtility.HtmlDecode(gdv_Fabric.Rows[gdv_Fabric.SelectedIndex].Cells[3].Text.ToString());
            dd_Status.SelectedValue = HttpUtility.HtmlDecode(gdv_Fabric.Rows[gdv_Fabric.SelectedIndex].Cells[5].Text.ToString());

            btn_save.Text = "Update";
        }
        catch (Exception exception)
        {
            lblMsg.Text = exception.Message;
        }
        #endregion gdv_ChildrenInfo_SelectedIndexChanged
    }

    private void v_loadGridView_Fabric()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as Buyer_Id, '' as File_Ref_Id ,'' as Status_Id,'' as File_Ref_No ,'' as Buyer ,'' as trStatus ", sqlconnection);

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_Fabric.DataSource = ds;
            gdv_Fabric.DataBind();
            int columncount = gdv_Fabric.Rows[0].Cells.Count;
            gdv_Fabric.Rows[0].Cells.Clear();
            gdv_Fabric.Rows[0].Cells.Add(new TableCell());
            gdv_Fabric.Rows[0].Cells[0].ColumnSpan = columncount;
        }
        else
        {
            gdv_Fabric.DataSource = ds;
            gdv_Fabric.DataBind();
        }

        sqlconnection.Close();
    }


    private void InsertMode()
    {
        lblMsg.Text = string.Empty;
             
        gdv_Fabric.DataSource = null;
        gdv_Fabric.DataBind();

    }


    protected void Load_All_Active_Files()
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("Proc_Select_All_Active_File", sqlconnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count == 0)
        {
            ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            gdv_Fabric.DataSource = ds;
            gdv_Fabric.DataBind();
            int columncount = gdv_Fabric.Rows[0].Cells.Count;
            gdv_Fabric.Rows[0].Cells.Clear();
            gdv_Fabric.Rows[0].Cells.Add(new TableCell());
            gdv_Fabric.Rows[0].Cells[0].ColumnSpan = columncount;

        }
        else
        {
            gdv_Fabric.DataSource = ds;
            gdv_Fabric.DataBind();

        }
        sqlconnection.Close();

    }


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        //lblMsg.Text = string.Empty;

        //CommonFunctions commonFunctions = new CommonFunctions();
        //SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        //sqlconnection.Open();

        //SqlCommand cmd = new SqlCommand("Proc_Search_Color_From_Additional_Cost '" + dd_SearchOrder.SelectedValue + "'", sqlconnection);
        //SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataSet ds = new DataSet();
        //da.Fill(ds);
        //if (ds.Tables[0].Rows.Count == 0)
        //{
        //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
        //    gdv_Fabric.DataSource = ds;
        //    gdv_Fabric.DataBind();
        //    int columncount = gdv_Fabric.Rows[0].Cells.Count;
        //    gdv_Fabric.Rows[0].Cells.Clear();
        //    gdv_Fabric.Rows[0].Cells.Add(new TableCell());
        //    gdv_Fabric.Rows[0].Cells[0].ColumnSpan = columncount;
        //}
        //else
        //{
        //    gdv_Fabric.DataSource = ds;
        //    gdv_Fabric.DataBind();
        //}

        //sqlconnection.Close();

    }

   


    private Boolean RequiredForBody()
    {
        //foreach (GridViewRow gdvrow in gdv_Fabric.Rows)
        //{
            //string fabUnit = string.Empty;
            //DropDownList ddUnit = (DropDownList)gdvrow.Cells[14].FindControl("ddlFabricUnit");
            //fabUnit = Convert.ToString(ddUnit.SelectedValue);

            //if (fabUnit == "0" || fabUnit == "#Select#")
            //{
            //    lblMsg.Visible = true;
            //    lblMsg.Text = "Pls Select Fabric Unit !";
            //    ddUnit.Focus();
            //    return false;
            //}
            
            
            //string Width = string.Empty;
            //DropDownList ddWidth = (DropDownList)gdvrow.Cells[16].FindControl("ddlWidth");
            //Width = Convert.ToString(ddWidth.SelectedValue);

            //if (Width == "0" || Width == "#Select#")
            //{
            //    lblMsg.Visible = true;
            //    lblMsg.Text = "Pls Select Fabric Width !";
            //    ddWidth.Focus();
            //    return false;
            //}

            

       // }

        return true;
    }

    private Boolean isValid()
    {

        if (dd_File.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Select File !";
            return false;
        }

        if (dd_Status.SelectedValue == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Select Status !";
            return false;
        }

        return true;
    }



    protected void btn_save_Click(object sender, EventArgs e)
    {

        string s_save_ = string.Empty;
        string s_Update = string.Empty;
        string s_returnValue = string.Empty;
        string s_Update_returnValue = string.Empty;
        string SessionUserId = string.Empty;
        string SessionCompanyId = string.Empty;

        SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
        SessionCompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

        Connection connection = new Connection();

        Boolean b_validationReturn = true;

        b_validationReturn = isValid();

        if (b_validationReturn == false)
        {
            return;
        }


        if (btn_save.Text == "Update")
        {
            s_Update = "[Proc_File_Status_Update]"
                         + "'"
                         + dd_File.SelectedValue
                         + "','"
                         + dd_Status.SelectedValue
                         + "'";


            s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, true);
            if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {

                if (s_Update_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Updated Successfull ! ";

                    Load_All_Active_Files();
                    //InsertMode();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Already Exists!";
                }
            }
        }

        
    }


   
    private void BodyFabricInsertMode()
    {
        gdv_Fabric.DataSource = null;
        gdv_Fabric.DataBind();

    }

    
}
