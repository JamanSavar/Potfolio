using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionKesy
/// </summary>
public class EnvironmentKeys
{
	private EnvironmentKeys()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public class SessionKeys
    {
        private SessionKeys()
        { }
    }

    public class ViewStateKeys
    {
        private ViewStateKeys()
        { }
        /// <summary>
        /// Form Name: frm_voucherEntry
        /// </summary>
        public const string s_ViewState_DataTable_CostCenter = "ViewState_DataTable_CostCenter";
        public const string s_ViewState_DataTableCollection_CostCenter = "ViewState_DataTableCollection_CostCenter";

        public const string s_ViewState_DataTable_Branch = "ViewState_DataTable_Branch";
        public const string s_ViewState_DataTableCollection_Branch = "ViewState_DataTableCollection_Branch";
    }

    public const string s_s_nodeKeySession = "sessionSelectedNodeValue";
    public const string s_s_parentKeySession = "sessionParentNodeValue";



    public class QueryStringKeys
    {
        private QueryStringKeys()
        { }
        /// <summary>
        /// Form Name: frm_voucherEntry
        /// </summary>
        public const string s_QS_journalInfoAutoId = "journalInfoAutoId";
        public const string s_QS_voucherType = "voucherType";
    }
}
