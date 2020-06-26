using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

public partial class frm_ReportViewer_SubReport : Page
{
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {
        try
        {
            Session[SessionKeys.i_count_report] = TableColumnName.Rpt_ErpReport.dct_reportsName_sql_query.Count;
            if (!IsPostBack)
            {
                Dictionary<string, DataTable> dc_reports_dataSource = new Dictionary<string, DataTable>();
                Session[SessionKeys.dc_reports_dataSource] = dc_reports_dataSource;
                Session[SessionKeys.dct_reportFormulaField] = TableColumnName.Rpt_ErpReport.dct_reportFormulaField;
                Session[SessionKeys.dct_reportsName_sql_query] = TableColumnName.Rpt_ErpReport.dct_reportsName_sql_query;

                List<string> l_reports_name = new List<string>();
                foreach (KeyValuePair<string, string> value in (Dictionary<string, string>)(Session[SessionKeys.dct_reportsName_sql_query]))
                {
                    l_reports_name.Add(value.Key);
                }
                //Session[SessionKeys.l_reports_name] = l_reports_name;
               

                //ReportDocument weekReport = new ReportDocument();
              



                ReportDocument reportDocument = new ReportDocument();

               

                foreach (string str in l_reports_name)
                {
                    int i_item_no = l_reports_name.IndexOf(str);


                    

                    if (i_item_no == 0)
                    {
                        reportDocument.Load(str);
                    }

                    if (i_item_no > 0)
                    {
                        reportDocument.OpenSubreport(str);
                       
                      


                    }

                }


                foreach (KeyValuePair<string, string> value in (Dictionary<string, string>)(Session[SessionKeys.dct_reportFormulaField]))
                {
                    reportDocument.DataDefinition.FormulaFields[value.Key].Text = "'" + value.Value + "'";
                }

               

                Session[SessionKeys.s_reportDocument] = reportDocument;
            }
            if ((int)Session[SessionKeys.i_count_report] >= 1)
            {
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
        public const string dt_dataTableForSubReport = "dt_dataTableForSubReport";
        public const string dct_reportFormulaField = "dct_reportFormulaField";
        public const string dct_subReportsName = "dct_subReportsName";
        public const string s_sqlQuery = "s_sqlQuery";
        public const string s_sr_sqlQuery = "s_sr_sqlQuery";
        public const string s_reportFilePath = "s_reportFilePath";
        public const string s_sr_reportFilePath = "s_sr_reportFilePath";
        public const string dct_reports_dataSource = "dct_reports_dataSource";
        public const string dct_reportsName_sql_query = "dct_reportsName_sql_query";
        public const string i_count_report = "i_count_report";
        public const string l_reports_name = "l_reports_name";
        public const string dc_reports_dataSource = "dc_reports_dataSource";

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ReportDocument reportDocument = new ReportDocument();
            Dictionary<string, DataTable> dct_reports_dataSource = new Dictionary<string, DataTable>();

            reportDocument = (ReportDocument)Session[SessionKeys.s_reportDocument];

            DataTable dt_dataTableForReport = new DataTable();
            DataTable dt_dataTableForSubReport = new DataTable();
            CrystalReportViewer1.DisplayGroupTree = false;
            if ((Dictionary<string, string>)(Session[SessionKeys.dct_reportsName_sql_query]) != null)
            {
                foreach (KeyValuePair<string, string> value in (Dictionary<string, string>)(Session[SessionKeys.dct_reportsName_sql_query]))
                {
                    v_build_report_data_source(value.Key, value.Value);
                }
                dct_reports_dataSource = (Dictionary<string, DataTable>)Session[SessionKeys.dc_reports_dataSource];

                int count = 1;
                if (dct_reports_dataSource != null)
                {
                    try
                    {
                        int i_count_subreports = 0;
                        foreach (KeyValuePair<string, DataTable> dic_value in dct_reports_dataSource)
                        {
                            if (count == 1)
                            {
                                reportDocument.SetDataSource(dct_reports_dataSource[dic_value.Key]);
                            }
                            else 
                            {
                                Dictionary<string, DataTable>.KeyCollection keyCollection = dct_reports_dataSource.Keys;
                                
                                foreach (string key in keyCollection)
                                {
                                    if (key.Contains(reportDocument.Subreports[i_count_subreports].Name))
                                    {
                                        reportDocument.Subreports[reportDocument.Subreports[i_count_subreports].Name].SetDataSource(dct_reports_dataSource[key]);
                                        break;
                                    }
                                }
                                //reportDocument.Subreports[i_count_subreports].SetDataSource(dic_value.Value);                                
                                i_count_subreports++;
                            }
                            count++;
                        }
                        //reportDocument.SetDataSource((DataTable)Session[SessionKeys.dt_dataTableForReport]);
                        //reportDocument.Subreports[].SetDataSource(dt_dataTableForSubReport);
                    }
                    catch (Exception)
                    {

                    }
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
    private void v_build_report_data_source(string s_subReport, string s_sqlQuery)
    {
        try
        {

            if ((int)Session[SessionKeys.i_count_report] > 0)
            {
                Dictionary<string, DataTable> dc_reports_dataSource = new Dictionary<string, DataTable>();
                dc_reports_dataSource = (Dictionary<string, DataTable>)Session[SessionKeys.dc_reports_dataSource];

                SqlDataAdapter da_sqlDataAdpapter = new SqlDataAdapter(s_sqlQuery, new SqlConnection(new Connection().connection_String(ConfigurationManager.ConnectionStrings[GlobalVariables.g_s_ConnectionStringName].ConnectionString)));
                DataSet ds_datasetForReport = new DataSet();
                da_sqlDataAdpapter.Fill(ds_datasetForReport, "datasetForReport");

                DataTable dt_dataTableForReport = new DataTable();
                dt_dataTableForReport = ds_datasetForReport.Tables["datasetForReport"];
                if (dc_reports_dataSource.ContainsKey(s_subReport) != true)
                {
                    dc_reports_dataSource.Add(s_subReport, dt_dataTableForReport);
                }

                if (dc_reports_dataSource != null)
                    Session[SessionKeys.dc_reports_dataSource] = dc_reports_dataSource;

            }
        }
        catch (Exception exception)
        {
            lbl_message.Text = exception.Message;
        }
    }
    private DataTable v_build_report_data_source1(string s_sqlQuery)
    {
        try
        {
            if (Session[SessionKeys.s_sqlQuery].ToString() != string.Empty)
            {
                SqlDataAdapter da_sqlDataAdpapter = new SqlDataAdapter(s_sqlQuery, new SqlConnection(new Connection().connection_String(ConfigurationManager.ConnectionStrings["HR_IMAGE"].ConnectionString)));
                DataSet ds_datasetForReport = new DataSet();
                da_sqlDataAdpapter.Fill(ds_datasetForReport, "datasetForReport");

                DataTable dt_dataTableForReport = new DataTable();
                dt_dataTableForReport = ds_datasetForReport.Tables["datasetForReport"];
                Session[SessionKeys.dt_dataTableForReport] = dt_dataTableForReport;

                if (dt_dataTableForReport != null)
                {
                    return dt_dataTableForReport;
                }

                else
                {
                    return null;
                }
            }
            else return null;
        }

        catch (Exception exception)
        {
            lbl_message.Text = exception.Message;
            return null;
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