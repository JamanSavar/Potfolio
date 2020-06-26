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

public partial class Finance_UI_frmPCProposal : System.Web.UI.Page
{

    string Addmode = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFunctions commonfunctions = new CommonFunctions();
            txtIssueDate.Text = DateTime.Now.ToString();

            hid_ProposalId.Value = "0";
            hidColorIndex.Value = "N";

           commonfunctions.g_b_FillDropDownList(dd_FileNo,
                "TBL_Export_LC_FileNo_BTB_Percent",
                "File_Ref_No",
                "File_Ref_Id", string.Empty);

           commonfunctions.g_b_FillDropDownList(dd_Proposal,
                "TBL_PC_Proposal",
                "SLNo",
                "Proposal_Id", "Order By SLNO DESC");

            btn_save.Text = "Save";

            ViewState["Addmode"] = "Y";
            Addmode = Convert.ToString(ViewState["Addmode"]);

            DataTable myDt = new DataTable();
            myDt = CreateDataTable();
            ViewState["myDatatable"] = myDt;

            maxSerial();
            v_loadGridView_Item();
            hid_ProposalId.Value = "0";
           
        }
    }

   

    protected void dd_FileNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshMode();

        CommonFunctions commonfunctions = new CommonFunctions();
        String FileId = "0";
        FileId = dd_FileNo.SelectedValue;

        commonfunctions.g_b_FillDropDownList(dd_LC,
           "TBL_Export_LC",
           "Export_LC_No",
           "Export_LC_Id", "WHERE File_Ref_Id='" + FileId + "'");
    }

    private void maxSerial()
    {
        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        s_select = "Proc_Max_SerialNo 'PCProposal'";
        s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
        if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (connection.ResultsDataSet.Tables != null)
            {
                foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                {
                    txt_SLNo.Text = drow["SLNo"].ToString();
                }
            }
        }

    }

    private void v_loadGridView_Item()
    {

        CommonFunctions commonFunctions = new CommonFunctions();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ToString()));
        sqlconnection.Open();

        SqlCommand cmd = new SqlCommand("SELECT '' as AutoId,'' as FileId ,'' as LCId,'' as PCValueDolar,'' as PCValueTK,'' as Rate,'' as FileId,'' as LCNO, '' as LCValue,'' as BTBValue,'' as PC,'' as trDate ", sqlconnection);

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
        myDataTable.Columns.Add(new DataColumn("AutoId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("FileId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCId", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCNO", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("LCValue", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("BTBValue", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCValueDolar", typeof(string)));
        myDataTable.Columns.Add(new DataColumn("PCValueTK", typeof(string)));
        return myDataTable;
       
    }

     private void AddDataToTable(string autoId,
                                string fileId,
                                string lcId,
                                string lcNo,
                                string lcValue,
                                string btbValue,
                                string rate,
                                string pcValueDolar,
                                string pcValueTK,
                                DataTable myTable)
    {
        DataRow row = myTable.NewRow();
        row["AutoId"] = autoId;
        row["FileId"] = fileId;
        row["LCId"] = lcId;
        row["LCNO"] = lcNo;
        row["LCValue"] = lcValue;
        row["BTBValue"] = btbValue;
        row["Rate"] = rate;
        row["PCValueDolar"] = pcValueDolar;
        row["PCValueTK"] = pcValueTK;
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

        /// For Duplicate Checking
        //foreach (GridViewRow dr in gdv_Item.Rows)
        //{
        //    if (dr.Cells[4].Text == txt_Style.Text.Trim())
        //    {
        //        lblsubmsg.Visible = true;
        //        lblsubmsg.Text = "Style Already Added!";
        //        return;
        //    }
        //}

        //string fileId = string.Empty;
        //string LCId = string.Empty;
        //string LCNo = string.Empty;
        //string lcValue = string.Empty;
        //string btbValue = string.Empty;
        //string Rate = string.Empty;
        //string AmountDollar = string.Empty;
        //string AmountTk = string.Empty;
        //string Remarks = string.Empty;

        //fileId = dd_FileNo.SelectedValue.ToString();
        //LCId = dd_LC.SelectedValue.ToString();
        //LCNo = dd_LC.SelectedItem.ToString();
        //lcValue = txt_LCValue.Text.ToString();
        //btbValue = txt_BTBValue.Text.ToString();
        //Rate = txt_Rate.Text.ToString();
        //AmountDollar = txt_AmountDollar.Text.ToString();
        //AmountTk = txt_AmountTK.Text.ToString();

        //DataTable myDatatable = (DataTable)ViewState["myDatatable"];

        //AddDataToTable(fileId
        //                , LCId
        //                , LCNo
        //                , lcValue
        //                , btbValue
        //                , Rate
        //                , AmountDollar
        //                , AmountTk
        //                , (DataTable)ViewState["myDatatable"]
        //             );

        AddDataToTable(hid_ProposalId.Value
                    , this.dd_FileNo.SelectedValue
                    , this.dd_LC.SelectedValue
                    , this.dd_LC.SelectedItem.Text
                    , this.txt_LCValue.Text
                    , this.txt_BTBValue.Text
                    , this.txt_Rate.Text
                    , this.txt_AmountDollar.Text
                    , this.txt_AmountTK.Text
                    , (DataTable)ViewState["myDatatable"]
                 );

        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
        this.gdv_Item.DataBind();
        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);

        hid_ProposalId.Value = "0";
        hidColorIndex.Value = "N";

        GrandTotal();
        AddClear();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        if (hidColorIndex.Value != "B" && gdv_Item.SelectedIndex != -1)
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

    //protected void btnDel_Click(object sender, EventArgs e)
    //{
    //    if (gdv_Item.SelectedIndex != -1)
    //    {
    //        ViewState["Addmode"] = "Y";
    //        Addmode = Convert.ToString(ViewState["Addmode"]);
    //        hid_Addmode.Value = "Y";
    //        DataTable dt = (DataTable)ViewState["myDatatable"];
    //        dt.Rows[gdv_Item.SelectedIndex].Delete();
    //        dt.AcceptChanges();
    //        gdv_Item.DataSource = dt;
    //        gdv_Item.DataBind();

    //        if (Convert.ToDouble(hid_Rownumber.Value) > 0)
    //        {
    //            hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) - 1);
    //        }

    //    }
    //    GrandTotal();
    //}


    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }

    private void InsertMode_Msg()
    {
        lblMsg.Text = string.Empty;
    }

    

    private void AddClear()
    {
        dd_FileNo.SelectedValue = "0";
        dd_LC.SelectedValue = "0";
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_BTB.Text = string.Empty;
        txt_BTBValue.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_PCBalance.Text = string.Empty;
        txt_PCValue.Text = string.Empty;
        dd_FileNo.Focus();
    }


    private void InsertMode()
    {
        txtIssueDate.Text = DateTime.Now.ToString();
        dd_FileNo.SelectedValue = "0";
        dd_LC.SelectedValue = "0";
        txt_SLNo.Text = string.Empty;
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_BTB.Text = string.Empty;
        txt_BTBValue.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_PCBalance.Text = string.Empty;
        txt_PCValue.Text = string.Empty;
        txt_Rate.Text = string.Empty;
        txt_LCValue.Text = string.Empty;

        gdv_Item.DataSource = null;
        gdv_Item.DataBind();

        v_loadGridView_Item();

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        hid_Rownumber.Value = "0";
        btn_save.Text = "Save";
        maxSerial();

        CommonFunctions commonfunctions = new CommonFunctions();
        commonfunctions.g_b_FillDropDownList(dd_Proposal,
               "TBL_PC_Proposal",
               "SLNo",
               "Proposal_Id", "Order By SLNO DESC");

    }

    private void RefreshMode()
    {
        txt_AmountTK.Text = string.Empty;
        txt_AmountDollar.Text = string.Empty;
        txt_BTB.Text = string.Empty;
        txt_BTBValue.Text = string.Empty;
        txt_PC.Text = string.Empty;
        txt_PCBalance.Text = string.Empty;
        txt_PCValue.Text = string.Empty;
        //txt_Rate.Text = string.Empty;
        txt_LCValue.Text = string.Empty;
        dd_LC.SelectedValue = "0";

    }




    private Boolean isrequired_Detail()
    {
        //if (dd_Unit.SelectedItem.Value == "0")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Unit Can Not Blank!";
        //    return false;
        //}


        //if (txt_Qty.Text == "")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Quantity Can Not Blank!";
        //    return false;
        //}

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



    protected void dd_LC_SelectedIndexChanged(object sender, EventArgs e)
    {

        ExportLCValue_Load();
    }


    private void ExportLCValue_Load()
    {
        if (dd_LC.SelectedValue != "0")
        {
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_Select_returnValue = string.Empty;

            s_select = "[Proc_MasterLCWise_Value_Select]"
                       + "'"
                       + dd_LC.SelectedValue
                       + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        txt_LCValue.Text = drow["LC_Value"].ToString();
                        txt_BTB.Text = drow["BTB_Parcent"].ToString();
                        txt_PC.Text = drow["PC_Parcent"].ToString();
                        txt_BTBValue.Text = drow["BTB_Value"].ToString();
                        txt_PCValue.Text = drow["PC_Value"].ToString();
                        txt_PCBalance.Text = drow["PC_Balance"].ToString();
                    }
                }
            }

        }

    }

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
            Connection connection = new Connection();
            string s_select = string.Empty;
            string s_trStatus = string.Empty;
            string s_Select_returnValue = string.Empty;

            lblMsg.Text = string.Empty;
            s_trStatus = string.Empty;

            hidColorIndex.Value = "N";

            hid_ProposalId.Value = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[2].Text.ToString());
            hid_ExportLcId.Value = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[4].Text.ToString());

            if (hid_ProposalId.Value != "0")
            {
                s_select = "[Proc_Select_ExportLC_From_Approval]" 
                             + "'"
                             + hid_ProposalId.Value
                             + "','"
                             + hid_ExportLcId.Value
                             + "'";

                s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                {
                    if (connection.ResultsDataSet.Tables != null)
                    {
                        foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                        {
                            s_trStatus = drow["trstatus"].ToString();
                        }
                    }
                }

            }

            if (s_trStatus == "D")
            {
                //hidChkColorId.Value = "0";
                hidColorIndex.Value = "B";
                lblMsg.Visible = true;
                lblMsg.Text = "Export LC Already In Approved!";
                return;
            }


            dd_FileNo.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[3].Text.ToString());
            dd_FileNo_SelectedIndexChanged(sender, e);

            dd_LC.SelectedValue = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[4].Text.ToString());
            dd_LC_SelectedIndexChanged(sender, e);

            //txt_LCValue.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[5].Text.ToString());
            //txt_BTBValue.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[6].Text.ToString());
            txt_Rate.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[8].Text.ToString());
            txt_AmountDollar.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[9].Text.ToString());
            txt_AmountTK.Text = HttpUtility.HtmlDecode(gdv_Item.Rows[gdv_Item.SelectedIndex].Cells[10].Text.ToString());
           

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
        if (dd_Proposal.SelectedValue != "0")
        {
            hid_ProposalId.Value = dd_Proposal.SelectedValue;
        }

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

        b_validationReturn = isrequired();

        if (b_validationReturn == false)
        {
            return;
        }

        if (btn_save.Text == "Update")
        {
            s_Update = "[Proc_PC_Proposal_UPDATE]"
                      + "'"
                      + dd_Proposal.SelectedValue
                      + "','"
                      + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                      + "','"
                      + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                      + "','"
                      + SessionUserId
                      + "','"
                      + SessionCompanyId
                      + "'";

            s_Update_returnValue = connection.connection_DB(s_Update, 1, true, true, false);

            if (s_Update_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {

                if (s_Update_returnValue == GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    string message = "Operation Failed!";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "Showmsgbox('" + message + "');", true);

                }
                else
                {
                    // Inserting in Details Table
                    foreach (DataRow dr in dt.Rows)
                    {
                        string fileId = string.Empty;
                        string lcId = string.Empty;
                        string dolar = string.Empty;
                        string taka = string.Empty;
                        string rate = string.Empty;
                        string qty = string.Empty;
                        string processId = string.Empty;

                        fileId = Convert.ToString(dr["FileId"]);
                        lcId = Convert.ToString(dr["LCId"]);
                        dolar = Convert.ToString(dr["PCValueDolar"]);
                        taka = Convert.ToString(dr["PCValueTK"]);
                        rate = Convert.ToString(dr["Rate"]);

                        s_save_ = "[Proc_PC_Proposal_Details_INSERT]"
                                   + "'"
                                   + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                                   + "','"
                                   + fileId
                                   + "','"
                                   + lcId
                                   + "','"
                                   + rate
                                   + "','"
                                   + dolar
                                   + "','"
                                   + taka
                                   + "'";


                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);

                    }
                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            s_save_ = "[Proc_Blank_Select]";
                            connection.connection_DB(s_save_, 1, true, false, true);
                            lblMsg.Visible = true;
                            lblMsg.Text = "Update Successfull!";
                            InsertMode();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Already Exists!";
                        }
                    }
                }
            }
        }
        else
        {
            s_save_ = "[Proc_PC_Proposal_INSERT]"
                      + "'"
                      + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                      + "','"
                      + Convert.ToDateTime(txtIssueDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
                      + "','"
                      + SessionUserId
                      + "','"
                      + SessionCompanyId
                      + "'";

            s_returnValue = connection.connection_DB(s_save_, 1, true, true, false);

            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string fileId = string.Empty;
                        string lcId = string.Empty;
                        string dolar = string.Empty;
                        string taka = string.Empty;
                        string rate = string.Empty;
                        string qty = string.Empty;
                        string processId = string.Empty;

                        fileId = Convert.ToString(dr["FileId"]);
                        lcId = Convert.ToString(dr["LCId"]);
                        dolar = Convert.ToString(dr["PCValueDolar"]);
                        taka = Convert.ToString(dr["PCValueTK"]);
                        rate = Convert.ToString(dr["Rate"]);


                        s_save_ = "[Proc_PC_Proposal_Details_INSERT]"
                                   + "'"
                                   + HttpUtility.HtmlDecode(txt_SLNo.Text.Trim())
                                   + "','"
                                   + fileId
                                   + "','"
                                   + lcId
                                   + "','"
                                   + rate
                                   + "','"
                                   + dolar
                                   + "','"
                                   + taka
                                   + "'";

                        s_returnValue = connection.connection_DB(s_save_, 1, true, false, false);

                    }
                    if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                        {
                            s_save_ = "[Proc_Blank_Select]";
                            connection.connection_DB(s_save_, 1, true, false, true);

                            lblMsg.Visible = true;
                            lblMsg.Text = "Save Successfull!";

                            InsertMode();
                        }

                        else
                        {

                            lblMsg.Visible = true;
                            lblMsg.Text = "Already Exists!";

                        }
                    }

                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Already Exists!";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Operation Failed!";
            }
        }

    }


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;

        Connection connection = new Connection();
        string s_select = string.Empty;
        string s_Select_returnValue = string.Empty;

        DataTable myDt = new DataTable();
        myDt = CreateDataTable();
        ViewState["myDatatable"] = myDt;

        hid_TotalPC.Value = "0";


        hid_ProposalId.Value = dd_Proposal.SelectedValue;

        if (hid_ProposalId.Value != "0")
        {
            s_select = "[Proc_PC_Proposal_Select]"
                        + "'"
                        + hid_ProposalId.Value
                        + "';";

            s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
            if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        txt_SLNo.Text = drow["SLNO"].ToString();
                        txtIssueDate.Text = drow["trDate"].ToString();
                    }
                    // Details Part-------------------       
                    s_select = "[Proc_PC_Proposal_Details_Search]"
                                 + "'"
                                 + hid_ProposalId.Value
                                 + "'";

                    s_Select_returnValue = connection.connection_DB(s_select, 0, false, false, false);
                    if (s_Select_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
                    {
                        if (connection.ResultsDataSet.Tables[0] != null)
                        {
                            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                            {
                                string autoId = string.Empty;
                                string FileId = string.Empty;
                                string LCId = string.Empty;
                                string LCNO = string.Empty;
                                string BTBValue = string.Empty;
                                string doler = string.Empty;
                                string taka = string.Empty;
                                string LCValue = string.Empty;
                                string Rate = string.Empty;

                                // txttotalPIAmount.Text = string.Empty;

                                autoId = drow["AutoId"].ToString();
                                FileId = drow["FileId"].ToString();
                                LCId = drow["LCId"].ToString();
                                LCNO = drow["LCNO"].ToString();
                                LCValue = drow["LCValue"].ToString();
                                BTBValue = drow["BTBValue"].ToString();
                                Rate = drow["Rate"].ToString();
                                doler = drow["PCValueDolar"].ToString();
                                taka = drow["PCValueTK"].ToString();

                                DataTable myDataTable = (DataTable)ViewState["myDatatable"];

                                AddDataToTable(autoId
                                            , FileId
                                            , LCId
                                            , LCNO
                                            , LCValue
                                            , BTBValue
                                            , Rate
                                            , doler
                                            , taka
                                            , (DataTable)ViewState["myDatatable"]
                                         );

                                        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
                                        this.gdv_Item.DataBind();

                                        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
                                       
                                        //hid_TotalPIAmount.Value = Convert.ToString(Convert.ToDouble(hid_TotalPIAmount.Value) + Convert.ToDouble(Total_Price));
                                        //txttotalPIAmount.Text = hid_TotalPIAmount.Value;

                                       // hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
                                    }
                                }
                        }
                    }
                    GrandTotal();
                    btn_save.Text = "Update";
                }
            }
        }
        

    private void GrandTotal()
    {
        if (hid_Rownumber.Value != "0")
        {
            float GTotal = 0f;
            for (int i = 0; i < gdv_Item.Rows.Count; i++)
            {
                String total = (gdv_Item.Rows[i].Cells[10]).Text.Trim();
                GTotal += Convert.ToSingle(total);
            }
            txt_TotalPC.Text = GTotal.ToString();
        }
    }

    protected void btn_Preview_Click(object sender, EventArgs e)
    {
        try
        {

            Boolean b_validationReturn = true;

            lblMsg.Visible = false;
            b_validationReturn = isValid();

            if (b_validationReturn == false)
            {
                return;
            }

            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Clear();
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Company_Name1", Session[GlobalVariables.g_s_companyName].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Address2", Session[GlobalVariables.g_s_Address].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Phone_Fax3", Session[GlobalVariables.g_s_Phone].ToString());
            TableColumnName.Rpt_ErpReport.dct_reportFormulaField.Add("Report_Name4", "PC Proposal");

            TableColumnName.Rpt_ErpReport.g_s_rptFilePath = "~\\Finance\\Reports\\RPT_PC_Proposal.rpt";

            TableColumnName.Rpt_ErpReport.g_s_sql_query = "Proc_RPT_PC_Proposal"
                                                         + "'"
                                                         + hid_ProposalId.Value
                                                         + "'";

            Response.Redirect(GlobalVariables.g_s_URL_reportViewer);


        }

        catch (Exception)
        {

        }

    }

   
}



//    protected void btnAdd_Click(object sender, EventArgs e)
//    {
//        Connection connection = new Connection();
//        CommonFunctions commonFunctions = new CommonFunctions();

//        Boolean b_required = true;

//        // For Requart field Checking
//        b_required = isrequired();

//        if (b_required == false)
//        {
//            return;
//        }

//        if (hid_Addmode.Value == "N")
//        {
//            btnDel_Click(sender, e);
//        }

//        /// For Duplicate Checking
//        //foreach (GridViewRow dr in gdv_Item.Rows)
//        //{
//        //    if (dr.Cells[4].Text == txt_Style.Text.Trim())
//        //    {
//        //        lblsubmsg.Visible = true;
//        //        lblsubmsg.Text = "Style Already Added!";
//        //        return;
//        //    }
//        //}

//        string fileId = string.Empty;
//        string LCId = string.Empty;
//        string LCNo = string.Empty;
//        string lcValue = string.Empty;
//        string btbValue = string.Empty;
//        string Rate = string.Empty;
//        string AmountDollar = string.Empty;
//        string AmountTk = string.Empty;
//        string Remarks = string.Empty;

//        fileId = dd_FileNo.SelectedValue.ToString();
//        LCId = dd_LC.SelectedValue.ToString();
//        LCNo = dd_LC.SelectedItem.ToString();
//        lcValue = txt_LCValue.Text.ToString();
//        btbValue = txt_BTBValue.Text.ToString();
//        Rate = txt_Rate.Text.ToString();
//        AmountDollar = txt_AmountDollar.Text.ToString();
//        AmountTk = txt_AmountTK.Text.ToString();
//        //Remarks = txt_DistributionRemarks.Text.ToString();



//        DataTable myDatatable = (DataTable)ViewState["myDatatable"];
//        AddDataToTable(fileId
//                        , LCId
//                        , LCNo
//                        , lcValue
//                        , btbValue
//                        , Rate
//                        , AmountDollar
//                        , AmountTk
//                        , (DataTable)ViewState["myDatatable"]
//                     );

//        this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
//        this.gdv_Item.DataBind();
//        hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
//        GrandTotal();
//        AddClear();
//    }


//    protected void btnDel_Click(object sender, EventArgs e)
//    {
//        if (gdv_Item.SelectedIndex != -1)
//        {
//            ViewState["Addmode"] = "Y";
//            Addmode = Convert.ToString(ViewState["Addmode"]);
//            hid_Addmode.Value = "Y";
//            DataTable dt = (DataTable)ViewState["myDatatable"];
//            dt.Rows[gdv_Item.SelectedIndex].Delete();
//            dt.AcceptChanges();
//            gdv_Item.DataSource = dt;
//            gdv_Item.DataBind();

//            if (Convert.ToDouble(hid_Rownumber.Value) > 0)
//            {
//                hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) - 1);
//            }

//        }
//        GrandTotal();
//    }


//    //protected void btnDel_Click(object sender, EventArgs e)
//    //{
//    //    foreach (GridViewRow gdvRow in gdv_Item.Rows)
//    //    {
//    //        CheckBox checkbox = (CheckBox)gdvRow.Cells[0].FindControl("chkApproval");
//    //        if (checkbox.Checked == true)
//    //        {
//    //            DataTable dt = (DataTable)ViewState["myDataTable"];
//    //            DataRow[] rows;

//    //            string PIid = string.Empty;
//    //            PIid = gdvRow.Cells[2].Text.Trim();

//    //            rows = dt.Select("PI_AutoId='" + PIid + "'");
//    //            foreach (DataRow dr in rows)
//    //                dt.Rows.Remove(dr);
//    //            dt.AcceptChanges();
//    //            gdv_Item.DataSource = dt;
//    //            gdv_Item.DataBind();
//    //        }
//    //    }

//    //    GrandTotal();

//    //}


//    //protected void btnAdd_Click(object sender, EventArgs e)
//    //{
//    //    Connection conn = new Connection();
//    //    CommonFunctions commonFunctions = new CommonFunctions();
//    //    string s_OrderLoadCondition = string.Empty, returnValue = string.Empty;

//    //    Boolean b_required = true;
//    //    lblMsg.Visible = false;

//    //    if (hid_TotalPC.Value == "0")
//    //    {
//    //        hid_TotalPC.Value = "0";
//    //    }


//    //    b_required = isrequired();
//    //    if (b_required == false)
//    //    {
//    //        return;
//    //    }

//    //    if (hid_Addmode.Value == "N")
//    //    {
//    //        btnDel_Click(sender, e);
//    //    }

//    //    hid_Addmode.Value = "Y";

//    //    // For Duplicate Checking
//    //    //foreach (GridViewRow dr in gdv_Item.Rows)
//    //    //{
//    //    //    if (dr.Cells[1].Text == dd_AccountHead.SelectedValue)
//    //    //    {
//    //    //        lblsubmsgDistribution.Visible = true;
//    //    //        lblsubmsgDistribution.Text = "Already Added!";
//    //    //        return;
//    //    //    }
//    //    //}

//    //    string fileId = string.Empty;
//    //    string LCId = string.Empty;
//    //    string LCNo = string.Empty;
//    //    string lcValue = string.Empty;
//    //    string btbValue = string.Empty;
//    //    string Rate = string.Empty;
//    //    string AmountDollar = string.Empty;
//    //    string AmountTk = string.Empty;
//    //    string Remarks = string.Empty;

//    //    fileId = dd_FileNo.SelectedValue.ToString();
//    //    LCId = dd_LC.SelectedValue.ToString();
//    //    LCNo = dd_LC.SelectedItem.ToString();
//    //    lcValue = txt_LCValue.Text.ToString();
//    //    btbValue = txt_BTBValue.Text.ToString();
//    //    Rate = txt_Rate.Text.ToString();
//    //    AmountDollar = txt_AmountDollar.Text.ToString();
//    //    AmountTk = txt_AmountTK.Text.ToString();
//    //    //Remarks = txt_DistributionRemarks.Text.ToString();



//    //    DataTable myDatatable = (DataTable)ViewState["myDatatable"];
//    //    AddDataToTable(fileId
//    //                    , LCId
//    //                    , LCNo
//    //                    , lcValue
//    //                    , btbValue
//    //                    , Rate
//    //                    , AmountDollar
//    //                    , AmountTk
//    //                    , (DataTable)ViewState["myDatatable"]
//    //                 );

//    //    this.gdv_Item.DataSource = ((DataTable)ViewState["myDatatable"]).DefaultView;
//    //    this.gdv_Item.DataBind();

//    //    hid_Rownumber.Value = Convert.ToString(Convert.ToDouble(hid_Rownumber.Value) + 1);
//    //    GrandTotal();
//    //    AddClear();

//    //}


//    private Boolean isrequired()
//    {
//        if (dd_LC.SelectedValue == "0")
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = "LC Blank!";
//            return false;
//        }

//        if (txt_Rate.Text == "" || txt_Rate.Text == "0")
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = "Rate Blank!";
//            return false;
//        }

//        if (txt_PCValue.Text == "" || txt_PCValue.Text == "0")
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = "Amount($) Blank!";
//            return false;
//        }
//        if (txt_AmountTK.Text == "" || txt_AmountTK.Text == "0")
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = "Amount(Tk) Blank!";
//            return false;
//        }

//        return true;
//    }

   
   
//    private void InsertMode_Msg()
//    {

//        lblMsg.Text = string.Empty;
//        lblMsg.Text = string.Empty;

//    }
//    private void InsertMode()
//    {
//        lblMsg.Text = string.Empty;
//        dd_FileNo.SelectedValue = "0";
//        dd_LC.SelectedValue = "0";

//        txtIssueDate.Text = DateTime.Now.ToString();

//        

//        gdv_Item.DataSource = null;
//        gdv_Item.DataBind();

//        DataTable myDt = new DataTable();
//        myDt = CreateDataTable();
//        ViewState["myDataTable"] = myDt;

//        CommonFunctions commonfunctions = new CommonFunctions();
//        commonfunctions.g_b_FillDropDownList(dd_Proposal,
//               "TBL_PC_Proposal",
//               "SLNO",
//               "Proposal_Id", string.Empty);

//        hid_Rownumber.Value = "0";
//        v_loadGridView_Item();
//        btn_save.Text = "Save";
//    }


