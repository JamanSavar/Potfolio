using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Forms_Accounts_frm_masterpage_modal : System.Web.UI.MasterPage
{
    //protected override void OnInit(EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    //    Response.Cache.SetNoStore();
    //    base.OnInit(e);
    //}

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Session.Timeout = 50;
        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";
    }
    protected override void AddedControl(Control control, int index)
    {

        if (Request.ServerVariables["http_user_agent"].IndexOf("Safari", StringComparison.CurrentCultureIgnoreCase) != -1)
            this.Page.ClientTarget = "uplevel";
        base.AddedControl(control, index);
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        String csname = "Ideal_Script";
        String csurl = "~/Forms/Constants/Javascript/CommonJScript.js";
        Type cstype = this.GetType();

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        // Check to see if the include script exists already.
        if (!cs.IsClientScriptIncludeRegistered(cstype, csname))
        {
            cs.RegisterClientScriptInclude(cstype, csname,
            ResolveClientUrl(csurl));

        }
    }
}
