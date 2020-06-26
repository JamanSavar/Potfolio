using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

public partial class frm_ReportViewer : Page
{
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session[SessionKeys.s_sqlQuery] = TableColumnName.Rpt_ErpReport.g_s_sql_query;
                Session[SessionKeys.s_reportFilePath] = TableColumnName.Rpt_ErpReport.g_s_rptFilePath;
                Session[SessionKeys.dct_reportFormulaField] = TableColumnName.Rpt_ErpReport.dct_reportFormulaField;

                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(Server.MapPath(Session[SessionKeys.s_reportFilePath].ToString()));

                foreach (KeyValuePair<string, string> value in (Dictionary<string, string>)(Session[SessionKeys.dct_reportFormulaField]))
                {
                    reportDocument.DataDefinition.FormulaFields[value.Key].Text = "'" + value.Value + "'";
                }

                Session[SessionKeys.s_reportDocument] = reportDocument;
            }
            if (Session[SessionKeys.s_sqlQuery].ToString() != string.Empty)
            {
                //ReportDocument reportDocument = new ReportDocument();
                //reportDocument.Load(Server.MapPath(Session[SessionKeys.s_reportFilePath].ToString()));
                //Session[SessionKeys.s_reportDocument] = reportDocument;
                setLogonInfo();
            }
        }
        catch (Exception exception)
        {
            lbl_message.Text = exception.Message;
        }
    }

    private class SessionKeys
    {
        private SessionKeys()
        { }
        public const string s_reportDocument = "s_reportDocument";
        public const string dt_dataTableForReport = "dt_dataTableForReport";
        public const string dct_reportFormulaField = "dct_reportFormulaField";
        public const string s_sqlQuery = "s_sqlQuery";
        public const string s_reportFilePath = "s_reportFilePath";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ReportDocument reportDocument = new ReportDocument();
            reportDocument = (ReportDocument)Session[SessionKeys.s_reportDocument];
            //reportDocument.DataDefinition.FormulaFields.Reset();
            CrystalReportViewer1.DisplayGroupTree = false;

            if (Session[SessionKeys.s_sqlQuery].ToString() != string.Empty)
            {
                SqlDataAdapter da_sqlDataAdpapter = new SqlDataAdapter(Session[SessionKeys.s_sqlQuery].ToString(), new SqlConnection(new Connection().connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ConnectionString)));
                DataSet ds_datasetForReport = new DataSet();
                da_sqlDataAdpapter.Fill(ds_datasetForReport, "datasetForReport");

                DataTable dt_dataTableForReport = new DataTable();
                dt_dataTableForReport = ds_datasetForReport.Tables["datasetForReport"];
                Session[SessionKeys.dt_dataTableForReport] = dt_dataTableForReport;
                if (dt_dataTableForReport != null)
                {
                    reportDocument.SetDataSource((DataTable)Session[SessionKeys.dt_dataTableForReport]);
                    CrystalReportViewer1.ReportSource = reportDocument;
                    CrystalReportViewer1.DataBind();
                }
            }
        }
        catch (Exception exception)
        {
            lbl_message.Text = exception.Message;
        }
        finally
        {
            Session.Remove(SessionKeys.dt_dataTableForReport);
        }
    }
    public void setLogonInfo()
    {
        try
        {
            TableLogOnInfo logOnInfo = new TableLogOnInfo();
            TableLogOnInfos infos = new TableLogOnInfos();
            ConnectionInfo connectionInfo = new ConnectionInfo();
            ReportDocument reportDocument = new ReportDocument();

            logOnInfo.ConnectionInfo.ServerName = new Connection().ServerName;
            logOnInfo.ConnectionInfo.DatabaseName = new Connection().DatabaseName;
            logOnInfo.ConnectionInfo.UserID = new Connection().UserId;
            logOnInfo.ConnectionInfo.Password = new Connection().Password;
            logOnInfo.TableName = "LogonInfoTable";
            infos.Add(logOnInfo);

            reportDocument = (ReportDocument)Session[SessionKeys.s_reportDocument];
            reportDocument.Database.Tables[0].ApplyLogOnInfo(logOnInfo);

            CrystalReportViewer1.LogOnInfo = infos;

        }
        catch (Exception exception)
        {
            lbl_message.Text = exception.Message;
        }
    }
}
