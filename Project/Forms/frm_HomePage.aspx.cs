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

public partial class Forms_frm_HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect(GlobalVariables.g_s_URL_homePage);

        //if (Session[GlobalVariables.g_s_userAutoId] == null)
        //{
        //    Response.Redirect(GlobalVariables.g_s_URL_loginPage);
        //}
        //else
        //{
        //    if (Session[GlobalVariables.g_s_userAutoId].ToString() != Session[GlobalVariables.g_s_userAutoId].ToString())
        //    {
        //        Response.Redirect("~/HumanResource/LeaveManagement/frm_empLeaveApplication.aspx");
        //    }
        //}

        Label1.Text = Application["TotalOnlineUsers"].ToString(); 
    }
}
