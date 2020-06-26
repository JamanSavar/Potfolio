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

public partial class Finance_UI_frmSundryDistribution : System.Web.UI.Page
{

    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hid_AutoId.Value = "0";

            CommonFunctions commonfunctions = new CommonFunctions();
            txtIssueDate.Text = DateTime.Now.ToString();

           commonfunctions.g_b_FillDropDownList(dd_FileNo,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

          
           commonfunctions.g_b_FillDropDownList(dd_Head,
              "T_Sundry_Distribution_Head",
              "Accounts_Head",
              "Accounts_Id", string.Empty);

        
            btn_save.Text = "Save";

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);

            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDatatable"] = myDt;

            v_loadGridView_Item();
            hid_AutoId.Value = "0";

         
           
        }
    }

    //private void TotalDistribusion()
    //{
    //    float GTotal = 0.00f;

    //    for (int i = 0; i < gdv_Distribution.Rows.Count; i++)
    //    {
    //        String total = (gdv_Distribution.Rows[i].Cells[5]).Text.Trim();
    //        GTotal += Convert.ToSingle(total);
    //    }

    //    //txt_Total.Text = String.Format("{0:0,0.00}", GTotal);
    //}

   

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


    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.Add(new DataColumn("FileId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("HeadId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Head", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Dolar", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Taka", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("trDate", typeof(DateTime)));
        myDataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
        return myDataTable;
       
    }

    private void AddDataToTable(string fileId,
                                string HeadId,
                                string Head,
                                string Dolar,
                                string Rate,
                                string Taka,
                                string date,
                                string remarks,
                                DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["FileId"] = fileId;
        row["HeadId"] = HeadId;
        row["Head"] = Head;
        row["Dolar"] = Dolar;
        row["Rate"] = Rate;
        row["Taka"] = Taka;
        row["trDate"] = date;
        row["Remarks"] = remarks;
        myTable.Rows.Add(row);
    }

   
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Connection connection = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();

        Boolean b_required = true;

        // For Requart field Checking
        b_required = isrequired_Detail();

        if (b_required == false)
        {
            return;
        }

        if (hid_Addmode.Value == "N")
        {
            btnDel_Click(sender, e);
        }

         //For Duplicate Checking
        //foreach (GridViewRow dr in gdv_Item.Rows)
        //{
        //    if (dr.Cells[6].Text == dd_Head.SelectedValue)
        //    {
        //        lblMsg.Visible = true;
        //        lblMsg.Text = "Head Already Added!";
        //        return;
        //    }
        //}

        string fileId = string.Empty;
        string dolar = string.Empty;
        string rate = string.Empty;
        string taka = string.Empty;
        string head = string.Empty;
        string headId = string.Empty;
        string date = string.Empty;
        string Remarks = string.Empty;


        fileId = dd_FileNo.SelectedValue;
        headId = dd_Head.SelectedValue;
        head = dd_Head.SelectedItem.Text;
        dolar = txt_AmountDollar.Text;
        rate = txt_Rate.Text;
        taka = txt_AmountTK.Text;
        date = txtIssueDate.Text;
        Remarks = txt_Remarks.Text;


        if (dolar == "")
        {
            dolar = "0";
        }
        if (rate == "")
        {
            rate = "0";
        }
        if (taka == "")
        {
            taka = "0";
        }


        AddDataToTable(fileId
                    , headId
                    , head
                    , dolar
                    , rate
                    , taka
                    , date
                    , Remarks
                    , (DataTable)ViewState["myDatatable"]
                 );

        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        this.gdv_Item.DataBind();
        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);

        hid_AutoId.Value = "0";

        GrandTotal();
        ClearMode();
    }


    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (gdv_Item.SelectedIndex != -1)
        {
            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);
            hid_Addmode.Value = "Y";
            DataTable dt = (DataTable)ViewState["myDatatable"];
            dt.Rows[gdv_Item.SelectedIndex].Delete();
            dt.AcceptChanges();
            gdv_Item.DataSource = dt;
            gdv_Item.DataBind();

            if (Convert.ToDouble(hid_Rownumber.Value) > 0)
            {
                hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) - 1);
            }
        }
        GrandTotal();

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
        dd_FileNo.SelectedValue = "0";
        dd_FileNo.Focus();

        txt_AmountDollar.Text = string.Empty;

        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        v_loadGridView_Item();

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        hid_Rownumber.Value = "0";
        btn_save.Text = "Save";

        
    }



    private Boolean isrequired_Detail()
    {

        if (dd_FileNo.SelectedItem.Value == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "File Can Not Blank!";
            return false;
        }

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

            dd_FileNo.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());
            dd_FileNo_SelectedIndexChanged(sender, e);

            //dd_LC.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[3].Text.ToString());
            //dd_LC_SelectedIndexChanged(sender, e);

            //dd_PC.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[4].Text.ToString());
            //dd_PC_SelectedIndexChanged(sender, e);

            dd_Head.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[3].Text.ToString());
            txt_Remarks.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());

            txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[6].Text.ToString());
            txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[7].Text.ToString());
            txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[8].Text.ToString());
            txtIssueDate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[9].Text.ToString());

            

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
        string s_save = string.Empty;
        string s_Update_returnValue = string.Empty;
        string s_Details = string.Empty;

        Boolean b_validationReturn = true;

        b_validationReturn = isValid();

        if (b_validationReturn == false)
        {
            return;
        }
        // First Time Delete All Data from Database 
        s_Details = "[Proc_File_Wise_Sundry_Delete] '" + dd_FileNo.SelectedValue + "'";

        s_Update_returnValue = connection.connection_DB(s_Details, 1, true, true, false);

        if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            // Second Time Insert All Data in  Database 
            foreach (DataRow dr in dt.Rows)
            {
                string FileId = string.Empty;
                string chargeId = string.Empty;
                string dolar = string.Empty;
                string rate = string.Empty;
                string taka = string.Empty;
                string date = string.Empty;
                string Remarks = string.Empty;
                
                FileId = Convert.ToString(dr["FileId"]);
                chargeId = Convert.ToString(dr["HeadId"]);
                dolar = Convert.ToString(dr["Dolar"]);
                rate = Convert.ToString(dr["Rate"]);
                taka = Convert.ToString(dr["Taka"]);
                Remarks = Convert.ToString(dr["Remarks"]);
                //date = Convert.ToString(dr["trDate"]);
                date = Convert.ToDateTime((dr["trDate"]), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy").ToString();


                s_save = "Proc_Sundry_Distribution_Insert"
                         + "'"
                         + FileId
                         + "','"
                         + chargeId
                         + "','"
                         + dolar
                         + "','"
                         + rate
                         + "','"
                         + taka
                         + "','"
                         + date
                         + "','"
                         + Remarks
                         + "','"
                         + SessionUserId
                         + "','"
                         + SessionCompanyId
                         + "'";

                s_returnValue = connection.connection_DB(s_save, 1, true, false, false);

            }


            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    s_save = "[Proc_Blank_Select]";
                    connection.connection_DB(s_save, 1, true, false, true);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Transaction Successfull";
                    InsertMode();

                }

                else
                {
                    string message = "Already Exists!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                }
            }

        }


    }


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        
        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;
        lblMsg.Text = string.Empty;

        v_loadGridView_Item();

        DataTable myData = new DataTable();
        myData = CreateDataTable();
        ViewState["myDatatable"] = myData;

       // hid_AutoId.Value = dd_Search.SelectedValue;

        hid_AutoId.Value = dd_FileNo.SelectedValue;

        if (hid_AutoId.Value != "0")
        {
            s_select = "[Proc_Sundry_Distribution_Search]"
                         + "'"
                         + hid_AutoId.Value
                         + "'";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables[0] != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        string headId = string.Empty;
                        string FileId = string.Empty;
                        string head = string.Empty;
                        string Dolar = string.Empty;
                        string rate = string.Empty;
                        string Taka = string.Empty;
                        string date = string.Empty;
                        string remarks = string.Empty;

                        //DateTime date ;

                        FileId = drow["FileId"].ToString();
                        headId = drow["HeadId"].ToString();
                        head = drow["Head"].ToString();
                        Dolar = drow["Dolar"].ToString();
                        rate = drow["Rate"].ToString();
                        Taka = drow["Taka"].ToString();
                        remarks = drow["Remarks"].ToString();

                        date = Convert.ToDateTime(drow["trDate"]).ToString();

                        //date =Convert.ToDateTime(drow["trDate"]);

                        DataTable myDataTable = (DataTable)ViewState["myDatatable"];

                        AddDataToTable(FileId
                                    , headId
                                    , head
                                    , Dolar
                                    , rate
                                    , Taka
                                    , date
                                    , remarks
                                    , (DataTable)ViewState["myDatatable"]
                                 );

                        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
                        this.gdv_Item.DataBind();

                        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);

                    }
                }
            }

            GrandTotal();
           // btn_save.Text = "Update";

        }

        
    }
        
    private void GrandTotal()
    {
        if (hid_Rownumber.Value != "0")
        {
            float GTotal = 0f;
            for (int i = 0; i < gdv_Item.Rows.Count; i++)
            {
                String total = (gdv_Item.Rows[i].Cells[6]).Text.Trim();
                GTotal += Convert.ToSingle(total);
            }
            txt_ToatlDolar.Text = GTotal.ToString();
        }
    }


    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }


   
}


