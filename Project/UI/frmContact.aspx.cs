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

public partial class UI_frmContact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        Connection connection = new Connection();

        string SessionUserId = string.Empty;
        string SessionCompanyId = string.Empty;
        SessionUserId = Convert.ToString(Session[GlobalVariables.g_s_userAutoId]);
        SessionCompanyId = Convert.ToString(Session[GlobalVariables.g_s_CompanyAutoId]);

        string s_returnValue = string.Empty;
        string s_save_ = string.Empty;
        string s_Update_returnValue = string.Empty;
        string s_Update = string.Empty;

        string Active = string.Empty;
        string Release = string.Empty;
        string UnRelease = string.Empty;

        Active = "N";
        Release = "N";
        UnRelease = "N";

        Boolean b_validationReturn = true;

        b_validationReturn = isValid();

        if (b_validationReturn == false)
        {
            return;
        }


        if (btn_save.Text == "Update")
        {

            //s_Update = "[Proc_CustomerInfo_Update]"
            //            + "'"
            //            + hid_autoId.Value
            //            + "','"
            //            + HttpUtility.HtmlDecode(txt_ID.Text.Trim())
            //            + "','"
            //            + HttpUtility.HtmlDecode(txt_Name.Text.Trim())
            //            + Convert.ToDateTime(txtJoinDate.Text.Trim(), new CultureInfo("fr-FR")).ToString("MM/dd/yyyy")
            //            + "','"
            //            + SessionCompanyId
            //            + "'";


            s_returnValue = connection.connection_DB(s_Update, 1, true, true, true);

            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    //s_save_ = "[Proc_Blank_Select]";
                    //connection.connection_DB(s_save_, 1, true, false, true);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Update Successfull";
                    InsertMode();
                }
                else
                {
                    string message = "Alrady Used In Order Info";
                    lblMsg.Text = message;
                }
            }
            else
            {
                string message = "Data Error!";
                lblMsg.Text = message;
            }
        }
        else
        {

            s_save_ = "[Proc_ContactInfo_Insert]"
                       + "'"
                       + HttpUtility.HtmlDecode(txtName.Text.Trim())
                       + "','"
                       + HttpUtility.HtmlDecode(txtEmail.Text.Trim())
                       + "','"
                       + HttpUtility.HtmlDecode(txtSubject.Text.Trim())
                       + "','"
                       + HttpUtility.HtmlDecode(txtMessage.Text.Trim())
                       + "'";

            s_returnValue = connection.connection_DB(s_save_, 1, true, true, true);

            if (s_returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                if (s_returnValue != GlobalVariables.g_s_procedureDuplicateReturnValue)
                {
                    //s_save_ = "[Proc_Blank_Select]";
                    //connection.connection_DB(s_save_, 1, true, false, true);
                    lblMsg.Visible = true;
                    lblMsg.Text = "Saved Successfull";
                    InsertMode();
                }
                else
                {
                    string message = "EmpId/CardId Already Exists";
                    lblMsg.Text = message;
                }
            }
            else
            {
                //string message = "Data Error!";
                string message = "Data Error!";
                lblMsg.Text = message;
            }

        }
    }


    protected void btn_refresh_Click(object sender, EventArgs e)
    {
        InsertMode();
        InsertMode_Msg();
    }

    private void InsertMode_Msg()
    {
        //lblMsg.Text = string.Empty;
    }


    private void InsertMode()
    {

        //dd_EmployeeId.SelectedValue = "0";

        txtName.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtMessage.Text = string.Empty;
        txtSubject.Text = string.Empty;
        
        btn_save.Text = "Save";

    }



    private Boolean isValid()
    {

       

        //if (txt_Name.Text == "")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Name Can Not Blank!";
        //    txt_Name.Focus();
        //    return false;
        //}

        //if (txt_FatherName.Text == "")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Father Name Can Not Blank!";
        //    txt_FatherName.Focus();
        //    return false;
        //}



        //if (dd_Nationality.Text == "0")
        //{
        //    lblMsg.Visible = true;
        //    lblMsg.Text = "Nationality Can Not Blank!";
        //    dd_Nationality.Focus();
        //    return false;
        //}

       
       
        return true;

    }
}
