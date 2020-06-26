using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for DateLock "========Basher Added========"
/// </summary>
public class DateLockService
{
    public string fromDate;
    public string toDate;
	public DateLockService()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    public string GetDataLockService()
    {
        DateTime fdt = DateTime.Parse(fromDate);
        DateTime tdt = DateTime.Parse(toDate);
        if ((tdt - fdt).TotalDays >5)
        {
            return "Software Locked!Can not Change!!";
        }
        return "";
    }

}
