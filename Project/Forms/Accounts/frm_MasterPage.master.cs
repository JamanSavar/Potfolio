using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Forms_Accounts_frm_MasterPage : MasterPage
{
    private static string s_backRootText;
    private const string s_backText = "Back";
    private static string s_rootElementText;
    private static Boolean b_isLeafSelected = true;
    private static TreeNode tn_lastTreeNode;

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
        Connection connection = new Connection();
        //CommonFunctions commonFunctions = new CommonFunctions();
        //commonFunctions.g_v_RenderJSArrayWithCliendIds(this,lnk_logout);
        //string directory = Server.MapPath(string.Empty);
        // Define the name, type and url of the client script on the page.
        String csname = "Ideal_Script";
        String csurl = "~/Forms/Constants/Javascript/CommonJScript.js";
        Type cstype = this.GetType();
        bool pollOperator = false;
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;

        CommonFunctions commonfunctions = new CommonFunctions();
        if (!commonfunctions.g_b_formsEntryAuthentication())
        {
            Response.Redirect(GlobalVariables.g_s_URL_loginPage);
        }
        // Check to see if the include script exists already.
        if (!cs.IsClientScriptIncludeRegistered(cstype, csname))
        {
            cs.RegisterClientScriptInclude(cstype, csname,
            ResolveClientUrl(csurl));
        }
        
        connection.ResultsDataSet = null;
        string sql_select_logedon_companyInfo = string.Empty;
        sql_select_logedon_companyInfo = Procedures.Common.Proc_Com_frm_masterpage_select_logedon_companyInfo 
            + "'" 
            + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
            + "'";
        connection.connection_DB(sql_select_logedon_companyInfo, 0, false, true, true);
        foreach (DataRow datarow in connection.ResultsDataSet.Tables[0].Rows)
        {
            Session[GlobalVariables.g_s_Address] = datarow["address"].ToString();
            Session[GlobalVariables.g_s_companyDefaultCurrencySymbol] = datarow["symbol"].ToString();
            Session[GlobalVariables.g_s_companyName] = datarow["companyName"].ToString();
            Session[Session[GlobalVariables.g_s_CompanyAutoId].ToString()] = datarow["Com_company_autoId"].ToString();
            Session[GlobalVariables.g_s_Email] = datarow["email"].ToString();
            Session[GlobalVariables.g_s_Phone] = datarow["otherNo"].ToString();
            Session[GlobalVariables.g_s_Fax] = datarow["fax"].ToString();
            Session[GlobalVariables.g_s_companyDefaultCurrencyAutoId] = datarow["Acc_Currency_autoId"].ToString();
            Session[GlobalVariables.g_s_financialYearFrom] = datarow[TableColumnName.T_Com_Company.FinancialYearFrom].ToString();
        }

        if (connection.connection_DB("proc_web_frm_vote_select_pollOperator'"
                            + Session[GlobalVariables.g_s_userAutoId].ToString()
                            + "'", 0, false, false, false) != GlobalVariables.g_s_connectionErrorReturnValue)
        {
            if (connection.ResultsDataSet != null)
            {
                if (connection.ResultsDataSet.Tables != null)
                {
                    if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                    {
                        pollOperator = connection.ResultsDataSet.Tables[0].Rows[0][0].ToString() == GlobalVariables.g_s_Yes ? true : false;
                    }
                }
            }
        }

        // Go to login form load event -- g_s_userStatus

        if (Session[GlobalVariables.g_s_userStatus].ToString() == "Sa")
        {
            systemAdminMenu.Visible = true;
            //systemAdminMenu.Visible =  false;
        }
        else if (Session[GlobalVariables.g_s_userStatus].ToString() == "MA")
        {
            MarchandiserMenu.Visible = true;
            //MarchandiserMenu.Visible = true;
        }
        else if (Session[GlobalVariables.g_s_userStatus].ToString() == "ST")
        {
            StoreMenu.Visible = true;
            //StoreMenu.Visible = true;
        }


        if (!Page.IsPostBack)
        {   
            #region
            //string selectEmployeeInfo = string.Empty, returnValue = string.Empty;
            //selectEmployeeInfo = Procedures.humanResource.Proc_web_frm_masterPage_select_EmployeeDeatils_By_EmployeeId
            //                    + "'" + Session[GlobalVariables.g_s_CompanyAutoId].ToString()
            //                    + "','" + Session[GlobalVariables.g_s_userAutoId].ToString() +
            //                    "'";
            //Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(selectEmployeeInfo, 0, false, false, false);
            //if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != GlobalVariables.g_s_connectionErrorReturnValue)
            //{
            //    if (connection.ResultsDataSet.Tables != null)
            //    {
            //        if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
            //        {
            //            foreach (DataRow datarow in connection.ResultsDataSet.Tables[0].Rows)
            //            {
            //                Session[GlobalVariables.g_s_userName] = datarow["empName"].ToString();
            //                Session[GlobalVariables.g_s_userPresentEmail] = datarow["presentEmail"].ToString();
            //                Session[GlobalVariables.g_s_userEmergencyEmail] = datarow["emergencyEmail"].ToString();
            //                lbl_fullUserName.Text = Session[GlobalVariables.g_s_userName].ToString() + "   /";
            //                //lblUserFullName.Text = "";
            //            }
            //        }
            //    }
            //}
            #endregion

            //lblleftFooter.Text =  " Company Name :  "+Session[GlobalVariables.g_s_companyName] + "   ";
            lbl_fullUserName.Text = Session[GlobalVariables.g_s_companyName] + "                  ||       " + Session[GlobalVariables.g_s_userName].ToString() + "                  ||       ";
            //lbl_fullUserName.Text = Session[GlobalVariables.g_s_userName].ToString() + "   /";
            s_rootElementText = Session[GlobalVariables.g_s_companyName].ToString();
            s_backRootText = string.Empty;

            if (Session["check"] == null)
            {
                Session["check"] = true;               
            }
            else
            {
                if (tn_lastTreeNode != null)
                {
                    string[] rootNodeKey1 = tn_lastTreeNode.Value.Split('@');
                    string lastElement = rootNodeKey1.ElementAt<string>(rootNodeKey1.Length - 2);
                    lastElement = tn_lastTreeNode.Value.Replace(lastElement + "@", string.Empty);
                    Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB("SELECT " + TableColumnName.T_Com_FloatingMenu.MenuLabel +
                                               " FROM " + TableColumnName.T_Com_FloatingMenu.TableName +
                                               " WHERE " + TableColumnName.T_Com_FloatingMenu.NodeKey +
                                               " = '" + lastElement + "'", 0, false, false, false);
                    if (GlobalVariables.g_s_connectionErrorReturnValue != Session[GlobalVariables.g_s_procedureReturnType].ToString())
                    {
                        if (connection.ResultsDataSet.Tables[0].Rows != null)
                        {
                            if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                            {
                                s_backRootText = connection.ResultsDataSet.Tables[0].Rows[0][0].ToString();
                            }
                        }
                    }
                }
                else
                {
                }
            }
        }
        
    }
    public void Logout()
    {
        Connection connection = new Connection();
        CommonFunctions.Date_Validation date_validation = new CommonFunctions.Date_Validation();
        string s_upadateLogbook = string.Empty;
        s_upadateLogbook = Procedures.Common.Proc_Web_Update_UserLogBook
            + "'"
            + Session[GlobalVariables.g_s_userLogBookAutoId].ToString()
            + "','"
            + DateTime.Now.ToString(new CultureInfo("en-US"))
            + "'";
        connection.connection_DB(s_upadateLogbook, 1, false, true, true);
        Session.RemoveAll();
        Response.Redirect(GlobalVariables.g_s_URL_loginPage); 
    }
    protected void lnk_logout_Click(object sender, EventArgs e)
    {
        Logout();
    }
    private TreeView v_LoadTreeView(TreeView tree_costCenter, TreeNode rootTreeNode)
    {
        try
        {
            Connection connection = new Connection();
            string returnValue = string.Empty;
            CommonFunctions commonFunctions = new CommonFunctions();
            string rootNodeKey = string.Empty;
            string isVisiblePermitted = "N";
            tree_costCenter.Nodes.Clear();
            tree_costCenter.Dispose();

            string s_sqlCostCenterTree = "SELECT " + TableColumnName.T_Com_FloatingMenu.MenuLabel
                + "," + TableColumnName.T_Com_FloatingMenu.SubHead
                + "," + TableColumnName.T_Com_FloatingMenu.URL
                + "," + TableColumnName.T_Com_FloatingMenu.NodeKey
                + "," + TableColumnName.T_Com_FloatingMenu.FormName
                + " FROM " + TableColumnName.T_Com_FloatingMenu.TableName
                + " WHERE " + TableColumnName.T_Com_FloatingMenu.ParentKey
                + "= '" + rootTreeNode.Value
                + "' order by " + TableColumnName.T_Com_FloatingMenu.AutoID;

            returnValue = connection.connection_DB(s_sqlCostCenterTree, 0, false, false, false);

            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue && connection.ResultsDataSet != null)
            {
                if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                {
                    //if (b_isLeafSelected == false)
                        tree_costCenter.Nodes.Add(rootTreeNode);

                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        if (drow[TableColumnName.T_Com_FloatingMenu.SubHead].ToString() == "N")
                        {
                           
                            Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(Procedures.Common.Proc_com_frm_MasterPage_Select_Permission_By_FormName_LeftMenu +
                                            " '" + Session[GlobalVariables.g_s_CompanyAutoId].ToString() +
                                            "','" + drow[TableColumnName.T_Com_FloatingMenu.FormName].ToString() +
                                            "','" + Session[GlobalVariables.g_s_userAutoId].ToString() +
                                            "'", 0, false, false, false);

                            if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != GlobalVariables.g_s_connectionErrorReturnValue && connection.ResultsDataSet != null)
                            {
                                if (connection.ResultsDataSet.Tables[0].Rows != null)
                                {
                                    if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                                    {
                                        isVisiblePermitted = connection.ResultsDataSet.Tables[0].Rows[0][0].ToString();
                                    }
                                }
                            }
                            TreeNode newNode = new TreeNode();
                            if (isVisiblePermitted == GlobalVariables.g_s_Yes)
                            {
                                newNode = new TreeNode(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                                    rootTreeNode.Value,
                                    string.Empty, Request.ApplicationPath + drow[TableColumnName.T_Com_FloatingMenu.URL].ToString(),
                                    "_self");
                            }
                            else
                            {
                                newNode = new TreeNode(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                                   rootTreeNode.Value,
                                   string.Empty, Request.ApplicationPath + "/Forms/frm_permissionDenied.aspx",
                                   "_self");
                            }
                            rootTreeNode.ChildNodes.Add(newNode);
                            tn_lastTreeNode = rootTreeNode;
                            b_isLeafSelected = true;
                        }
                        else
                        {
                            TreeNode newNode = new TreeNode(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                                drow[TableColumnName.T_Com_FloatingMenu.NodeKey].ToString());
                            rootTreeNode.ChildNodes.Add(newNode);
                        }
                    }
                    if (rootTreeNode.Value != string.Empty)
                    {
                        string[] rootNodeKey1 = rootTreeNode.Value.Split('@');
                        string lastElement = rootNodeKey1.ElementAt<string>(rootNodeKey1.Length - 2);
                        lastElement = rootTreeNode.Value.Replace(lastElement + "@", string.Empty);
                        string backParentKey = string.Empty;                       
                        rootTreeNode.ChildNodes.Add(new TreeNode(s_backText, lastElement));
                    }
                }
                tree_costCenter.ExpandAll();
            }
        }
        catch
        {
        }
        return tree_costCenter;
    }
    protected void tv_leftNavigation_SelectedNodeChanged(object sender, EventArgs e)
    {
        try
        {
            TreeNode selectedTreeNode = (TreeNode)((TreeView)sender).SelectedNode;
            TreeNode parentOfselectedTreeNode = (TreeNode)((TreeView)sender).SelectedNode.Parent;
            //tn_lastTreeNode = (TreeNode)((TreeView)sender).SelectedNode;
            if (selectedTreeNode.Text == s_backText)
            {
                if (selectedTreeNode.Value == string.Empty)
                {
                    s_backRootText = s_rootElementText;
                }
            }
            else
            {
                s_backRootText = parentOfselectedTreeNode.Text;
            }
        }
        catch
        {
        }
    }
    protected void mnu_leftNav_MenuItemClick(object sender, MenuEventArgs e)
    {
        try
        {
            //MenuItem selectedTreeNode = (TreeNode)((TreeView)sender).SelectedNode; e.Item.Value;
            //TreeNode parentOfselectedTreeNode = (TreeNode)((TreeView)sender).SelectedNode.Parent;

            if (e.Item.Text == s_backText)
            {
                if (e.Item.Value == string.Empty)
                {
                    s_backRootText = s_rootElementText;
                }
            }
            else
            {
                s_backRootText = e.Item.Parent.Text;
            }
        }
        catch
        {
        }
    }
    private Menu v_LoadTreeView(Menu tree_costCenter, MenuItem rootTreeNode)
    {
        try
        {
            Connection connection = new Connection();
            string returnValue = string.Empty;
            CommonFunctions commonFunctions = new CommonFunctions();
            string rootNodeKey = string.Empty;
            string isVisiblePermitted = "N";            
            tree_costCenter.Items.Clear();
            tree_costCenter.Dispose();

            string s_sqlCostCenterTree = "SELECT " + TableColumnName.T_Com_FloatingMenu.MenuLabel
                + "," + TableColumnName.T_Com_FloatingMenu.SubHead
                + "," + TableColumnName.T_Com_FloatingMenu.URL
                + "," + TableColumnName.T_Com_FloatingMenu.NodeKey
                + "," + TableColumnName.T_Com_FloatingMenu.FormName
                + " FROM " + TableColumnName.T_Com_FloatingMenu.TableName
                + " WHERE " + TableColumnName.T_Com_FloatingMenu.ParentKey
                + "= '" + rootTreeNode.Value
                + "' order by " + TableColumnName.T_Com_FloatingMenu.AutoID;

            returnValue = connection.connection_DB(s_sqlCostCenterTree, 0, false, false, false);

            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue && connection.ResultsDataSet != null)
            {
                if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                {
                    tree_costCenter.Items.Add(rootTreeNode);
                    foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
                    {
                        MenuItem newNode = new MenuItem();
                        newNode = new MenuItem(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                            drow[TableColumnName.T_Com_FloatingMenu.NodeKey].ToString());
                        tree_costCenter.Items.Add(newNode);
                        //rootTreeNode.ChildItems.Add(newNode);
                        v_LoadChildNode(newNode);
                    }                    
                }
            }
        }
        catch
        {
        }
        return tree_costCenter;
    }   
    private void v_LoadChildNode(MenuItem parentNode)
    {
        Connection connection = new Connection() { ResultsDataSet = null, connection = null };
        CommonFunctions commonFunctions = new CommonFunctions();
        string rootNodeKey = string.Empty;
        string isVisiblePermitted = "N";

        string sqlParameter =  "SELECT " + TableColumnName.T_Com_FloatingMenu.MenuLabel
                + "," + TableColumnName.T_Com_FloatingMenu.SubHead
                + "," + TableColumnName.T_Com_FloatingMenu.URL
                + "," + TableColumnName.T_Com_FloatingMenu.NodeKey
                + "," + TableColumnName.T_Com_FloatingMenu.FormName
                + " FROM " + TableColumnName.T_Com_FloatingMenu.TableName
                + " WHERE " + TableColumnName.T_Com_FloatingMenu.ParentKey
                + "= '" + parentNode.Value
                + "' order by " + TableColumnName.T_Com_FloatingMenu.AutoID;

        connection.connection_DB(sqlParameter, 0, false, true, true);

        if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
        {
            MenuItem newNode = new MenuItem();
            foreach (DataRow drow in connection.ResultsDataSet.Tables[0].Rows)
            {
                if (drow[TableColumnName.T_Com_FloatingMenu.SubHead].ToString() == "N")
                {
                    //newNode.a
                    Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(Procedures.Common.Proc_com_frm_MasterPage_Select_Permission_By_FormName_LeftMenu +
                               " '" + Session[GlobalVariables.g_s_CompanyAutoId].ToString() +
                               "','" + drow[TableColumnName.T_Com_FloatingMenu.FormName].ToString() +
                               "','" + Session[GlobalVariables.g_s_userAutoId].ToString() +
                               "'", 0, false, false, false);

                    if (Session[GlobalVariables.g_s_procedureReturnType].ToString() != GlobalVariables.g_s_connectionErrorReturnValue && connection.ResultsDataSet != null)
                    {
                        if (connection.ResultsDataSet.Tables[0].Rows != null)
                        {
                            if (connection.ResultsDataSet.Tables[0].Rows.Count > 0)
                            {
                                isVisiblePermitted = connection.ResultsDataSet.Tables[0].Rows[0][0].ToString();
                            }
                        }
                    }
                    if (isVisiblePermitted == GlobalVariables.g_s_Yes)
                    {
                        newNode = new MenuItem(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                            drow[TableColumnName.T_Com_FloatingMenu.NodeKey].ToString(),
                            string.Empty, Request.ApplicationPath + drow[TableColumnName.T_Com_FloatingMenu.URL].ToString(),
                            "_self");
                        isVisiblePermitted = GlobalVariables.g_s_No;
                    }
                    else
                    {
                        newNode = new MenuItem(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                           drow[TableColumnName.T_Com_FloatingMenu.NodeKey].ToString(),
                           string.Empty, Request.ApplicationPath + "/Forms/frm_permissionDenied.aspx",
                           "_self");
                    }
                    //parentNode.ChildItems.Add(newNode); 
                    //newNode = new MenuItem(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(), drow[TableColumnName.T_Com_FloatingMenu.NodeKey].ToString());
                }
                else
                {
                    newNode = new MenuItem(drow[TableColumnName.T_Com_FloatingMenu.MenuLabel].ToString(),
                          drow[TableColumnName.T_Com_FloatingMenu.NodeKey].ToString(),
                          string.Empty, string.Empty,
                          "_self");
                }
                parentNode.ChildItems.Add(newNode);
                v_LoadChildNode(newNode);
            }
        }
    }
    protected void lnk_home_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Forms/frm_HomePage.aspx");
    }
}
