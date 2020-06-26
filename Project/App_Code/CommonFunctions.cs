using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

public class CommonFunctions : Page
{
    public int g_i_calculateWorkingDays(DateTime from, DateTime to)
    {
        int no_ofDays = 0, totalWorkingDay = 0;
        no_ofDays = to.Subtract(from).Days + 1;
        totalWorkingDay = no_ofDays;
        for (; no_ofDays > 0; no_ofDays--)
        {
            if (from.DayOfWeek == DayOfWeek.Saturday || from.DayOfWeek == DayOfWeek.Sunday)
            {
                totalWorkingDay--;
            }
            from = from.AddDays(1);
            //no_ofDays--;
        }
        return totalWorkingDay;
    }


    public Boolean g_UserPermissionValidation(string s_UserAutoId, string sFormURL)
    {
        try
        {
            string s_UserStatus = string.Empty;
            s_UserStatus = Convert.ToString(Session[GlobalVariables.g_s_userStatus]);
            if (s_UserStatus == "Sa")
            {
                return true;
            }

            Connection connection = new Connection() { ResultsDataSet = null, connection = null };
            string dataparam = "SELECT * FROM TBL_USER_ACCESS WHERE UserAutoId=" + s_UserAutoId + " and FormAutoId=(SELECT autoId FROM TBL_FORMS_URL WHERE FrmName='" + sFormURL + "')";
            connection.connection_DB(dataparam, 0, false, false, false);
            DataSet dataSet = new DataSet();
            DataTable dataTable = connection.ResultsDataSet.Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show("You are Permitted!!");
        }

        return false;
    }


    public void g_v_setGridViewStyle(GridView gridView)
    {
        if (gridView == null) 
        {
        }
        else
        {
            gridView.BackColor = Color.Silver;
            gridView.ForeColor = Color.Black;
            gridView.AlternatingRowStyle.BackColor = Color.Gainsboro;
            if (gridView.HeaderRow != null)
            {
                gridView.HeaderRow.BackColor = Color.Black;
            }
            if (gridView.HeaderRow != null)
            {
                gridView.HeaderRow.ForeColor = Color.White;
            }
            gridView.SelectedRowStyle.BackColor = Color.DimGray;
        }
    }
    public Boolean g_b_formsEntryAuthentication()
    {
        if (Session[GlobalVariables.g_s_userAutoId] == null)
        {
            Session.RemoveAll();
            return false;
        }
        return true;
    }
    public Boolean g_b_emailAddressValidation(params string[] emailIDs)
    {
        Regex regex = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
        foreach (string emailID in emailIDs)
        {
            if (emailID == string.Empty)
            {
                return false;
            }
            else
            {
                if (!regex.IsMatch(emailID))
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    ///  must validation of textbox controls
    /// </summary>
    /// <param name="txt_textBoxName">ID of the textBox</param>    

    public Boolean g_B_mustValidationForMultipleTextbox(params TextBox[] controlToMustValidate)
    {
        foreach (TextBox txt in controlToMustValidate)
        {
            if (txt.Text == string.Empty)
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = txt.ID + GlobalVariables.g_s_MustFieldValdation;
                return false;
            }
        }
        return true;
    }

    public Boolean g_B_mustValidationForMultipleDropDownList(params DropDownList[] controlToMustValidate)
    {
        foreach (DropDownList dropDownList in controlToMustValidate)
        {
            if (dropDownList.SelectedValue == "0")
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = dropDownList.ID + GlobalVariables.g_s_MustFieldValdation;
                return false;
            }
        }
        return true;
    }

    public Boolean g_B_numeric_Validation_Decimal_ForMultipleTextBox(params TextBox[] controlToNumericValidate)
    {
        numeric_Validation numericValidation = new numeric_Validation();
        foreach (TextBox textBox in controlToNumericValidate)
        {
            if (!numericValidation.numeric_Validation_Decimal(textBox.Text, 0))
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = textBox.ID + GlobalVariables.g_s_DecimalValdation;
                return false;
            }
        }
        return true;
    }

    public Boolean g_B_numeric_Validation_Decimal_Allow_Minus_ForMultipleTextBox(params TextBox[] controlToNumericValidate)
    {
        numeric_Validation numericValidation = new numeric_Validation();
        foreach (TextBox textBox in controlToNumericValidate)
        {
            if (!numericValidation.numeric_Validation_Decimal_Allow_Minus(textBox.Text, 0))
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = textBox.ID + GlobalVariables.g_s_DecimalValdation_AllowMinus;
                return false;
            }
        }
        return true;
    }

    public Boolean g_B_numeric_Validation_Integer_ForMultipleTextBox(params TextBox[] controlToNumericValidate)
    {
        numeric_Validation numericValidation = new numeric_Validation();
        foreach (TextBox textBox in controlToNumericValidate)
        {
            if (!numericValidation.Numeric_Validation_Integer(textBox.Text, 0))
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = textBox.ID + GlobalVariables.g_s_IntegerValdation;
                return false;
            }
        }
        return true;
    }

    public Boolean g_B_numeric_Validation_Integer_Allow_Minus_ForMultipleTextBox(params TextBox[] controlToNumericValidate)
    {
        numeric_Validation numericValidation = new numeric_Validation();
        foreach (TextBox textBox in controlToNumericValidate)
        {
            if (!numericValidation.numeric_Validation_Integer_Allow_Minus(textBox.Text, 0))
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = textBox.ID + GlobalVariables.g_s_IntegerValdation_AllowMinus;
                return false;
            }
        }
        return true;
    }

    public Boolean g_B_date_Validation_ForMultipleTextBox(params TextBox[] controlToDateValidate)
    {
        Date_Validation dateValidation = new Date_Validation();
        foreach (TextBox textBox in controlToDateValidate)
        {
            if (!dateValidation.date_Validate(textBox.Text.Trim()))
            {
                Session[GlobalVariables.g_s_serverValidationErrorControlId] = textBox.ID + GlobalVariables.g_s_DateValidation;
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// for security purpose
    /// </summary>
    /// <param name="fileName">fileName</param>
    /// 

    public List<string> g_s_retrunStatus(string fName)
    {
        Connection connection = new Connection();
        DataTable dataTable = new DataTable();
        List<string> l_access_status = new List<string>();
        string sql_findPermision = string.Empty;
        sql_findPermision = Procedures.Common.Proc_findOutPermisionOfAFormByUser
                    + " '"
                    + Session[GlobalVariables.g_s_userAutoId].ToString()
                    + "','"
                    + fName
                    + "'";
        Session[GlobalVariables.g_s_procedureReturnType] = connection.connection_DB(sql_findPermision, 0, true, true, true);
        dataTable = connection.ResultsDataSet.Tables[0];

        if (dataTable.Rows.Count > 0)
        {
            foreach (DataRow datarow in dataTable.Rows)
            {
                l_access_status.Add(datarow["insert"].ToString().Trim());
                l_access_status.Add(datarow["update"].ToString().Trim());
                l_access_status.Add(datarow["delete"].ToString().Trim());
            }
        }
        else
        {
            l_access_status.Add("Y");
            l_access_status.Add("Y");
            l_access_status.Add("Y");

        }

        return l_access_status;
    }

    public String connection_String(string s_conn_string)
    {
        int i_len = s_conn_string.Length;
        string s_database = string.Empty;
        string s_server = string.Empty;
        string s_userId = string.Empty;
        string s_passward = string.Empty;
        string s_connString = string.Empty;
        string s_temp = string.Empty;
        string s = string.Empty;
        int j = 0;
        try
        {
            if (i_len > 0)
            {
                for (int i = 0; i < i_len; i++)
                {
                    s = s_conn_string.Substring(i, 1);
                    if (s != ";")
                    {
                        s_temp += s;
                    }
                    else
                    {
                        j += 1;
                        if (j == 1)
                        {
                            s_database = s_temp.Substring(9, s_temp.Length - 9).Trim().ToString();
                            s_temp = "";
                        }
                        if (j == 2)
                        {
                            s_server = s_temp.Substring(7, s_temp.Length - 7).Trim().ToString();
                            s_temp = "";
                        }
                        if (j == 3)
                        {
                            s_userId = s_temp.Substring(7, s_temp.Length - 7).Trim().ToString();
                            s_temp = "";
                        }
                        if (j == 4)
                        {
                            s_passward = s_temp.Substring(9, s_temp.Length - 9).Trim().ToString();
                            s_temp = "";
                        }
                    }
                }
                if (s_userId == "")
                {
                    s_connString = "Integrated Security=SSPI;Initial Catalog=" + s_database + ";Data Source=" + s_server + ";";
                }
                else
                {
                    s_connString = "Persist Security Info=False;User Id=" + s_userId + ";Password=" + s_passward + ";Initial Catalog=" + s_database + ";Data Source=" + s_server + ";";
                }
            }
        }
        catch (ArgumentException)
        {
            //MessageBox.Show(ex.Message);
        }
        finally
        {
            //nothing;
        }
        return s_connString;
    }

    /// <summary>
    /// To Fillup a DropDownList With Database Driven Values
    /// </summary>
    /// <param name="dd_dropDownListName">ID of the DropDownList</param>
    /// <param name="s_tableName">Table To Fill the DropDownList</param>
    /// <param name="s_colNameTextFiled">Table Column Name Used as Text of The DropDownList</param>
    /// <param name="s_colNameValueFiled">Table Column Name Used as Value of The DropDownList</param>
    /// 
    public Boolean g_b_FillDropDownList(DropDownList dd_dropDownListName, DataTable dt_TableName, string s_colNameTextFiled, string s_colNameValueFiled)
    {
        try
        {
            dd_dropDownListName.Items.Clear();
            ListItem listItemBlank = new ListItem();
            listItemBlank.Text = "# Select #";
            listItemBlank.Value = "0";
            dd_dropDownListName.Items.Add(listItemBlank);

            if (dt_TableName.Rows.Count > 0)
            {
                foreach (DataRow drow in dt_TableName.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString();
                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //return false;
            ////MessageBox.Show(ex.Message);
        }
        return false;
    }

    public bool g_b_checkDuplicationDataTable(DataTable dtTable, string duplicateFieldName, string valueToCheck)
    {
        if (dtTable != null)
        {
            DataRow[] count = dtTable.Select(duplicateFieldName + " = '" + valueToCheck.Replace(GlobalVariables.g_s_stringToReplace, GlobalVariables.g_s_stringByReplace) + "'");
            if (count.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }


    /// <summary>
    /// To Fillup a DropDownList With Database Driven Values Without # Select #
    /// </summary>
    /// <param name="dd_dropDownListName">ID of the DropDownList</param>
    /// <param name="s_tableName">Table To Fill the DropDownList</param>
    /// <param name="s_colNameTextFiled">Table Column Name Used as Text of The DropDownList</param>
    /// <param name="s_colNameValueFiled">Table Column Name Used as Value of The DropDownList</param>
    /// g_b_FillDropDownList
    public Boolean g_b_FillDropDownList(DropDownList dd_dropDownListName, DataTable dt_TableName, string s_colNameTextFiled, string s_colNameValueFiled, Boolean b_select)
    {
        try
        {
            dd_dropDownListName.Items.Clear();
            ListItem listItemBlank = new ListItem();
            if (b_select)
            {
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
            }

            if (dt_TableName.Rows.Count > 0)
            {
                foreach (DataRow drow in dt_TableName.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString();
                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //return false;
            ////MessageBox.Show(ex.Message);
        }
        return false;
    }

    public Boolean g_b_FillDropDownListLoaded(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                //ListItem listItemBlank = new ListItem();
                //listItemBlank.Text = "# Select #";
                //listItemBlank.Value = "0";
                //dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString();
                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }


    /// <summary>
    /// To Fillup a DropDownList With Database Driven Values
    /// </summary>
    /// <param name="dd_dropDownListName">ID of the DropDownList</param>
    /// <param name="s_tableName">Table Name To Fill the DropDownList</param>
    /// <param name="s_colNameTextFiled">Table Column Name Used as Text of The DropDownList</param>
    /// <param name="s_colNameValueFiled">Table Column Name Used as Value of The DropDownList</param>
    public Boolean g_b_FillDropDownList(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString();
                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }



    public Boolean g_b_FillDropDownListByProc(DropDownList dd_dropDownListName, string s_Query, string s_colNameTextFiled, string s_colNameAdditinalTextField, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            //string dataparam =s_Query "select distinct " + s_colNameTextFiled + "," + s_colNameAdditinalTextField + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            string dataparam = s_Query;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString() + " / " + drow[s_colNameAdditinalTextField].ToString();

                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }


    public Boolean g_b_FillDropDownListMultiColumn(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameAdditinalTextField, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameAdditinalTextField + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString() +" -- "+ drow[s_colNameAdditinalTextField].ToString();
                   
                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }

    public Boolean g_b_FillDropDownListByQurey(DropDownList dd_dropDownListName, string s_Qry)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = s_Qry;// "select distinct " + s_colNameTextFiled + "," + s_colNameAdditinalTextField + "," + s_colName3rdTextField + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow["ItemName"].ToString();// +" - " + drow[s_colNameAdditinalTextField].ToString() + " - " + drow[s_colName3rdTextField].ToString();

                    li.Value = drow["ItemId"].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }





    public Boolean g_b_FillDropDownList3Column(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameAdditinalTextField, string s_colName3rdTextField, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameAdditinalTextField + "," + s_colName3rdTextField + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString() + " - " + drow[s_colNameAdditinalTextField].ToString() + " - " + drow[s_colName3rdTextField].ToString();

                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }




    public Boolean g_b_FillDropDownList4Column(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameAdditinalTextField, string s_colName3rdTextField, string s_colName4thTextField, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameAdditinalTextField + "," + s_colName3rdTextField + "," + s_colName4thTextField + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString() + " - " + drow[s_colNameAdditinalTextField].ToString() + " - " + drow[s_colName3rdTextField].ToString() + " - " + drow[s_colName4thTextField].ToString();

                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }


    public Boolean g_b_FillDropDownList3ColumnWidthDate(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameAdditinalTextField, string s_colName3rdTextField, string s_colNameValueFiled, string s_condition)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameAdditinalTextField + "," + s_colName3rdTextField + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;
            returnValue = connection.connection_DB(dataparam, 0, false, false, false);
            //DataSet dataSet = new DataSet();
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {
                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    //li.Text = drow[s_colNameTextFiled].ToString() + " - " + drow[s_colNameAdditinalTextField].ToString() + " - " + drow[s_colName3rdTextField].ToString();
                    li.Text = drow[s_colNameTextFiled].ToString() + " - " + drow[s_colNameAdditinalTextField].ToString() + " - " + Convert.ToDateTime(drow[s_colName3rdTextField].ToString(), new CultureInfo("fr-FR")).ToString("dd/MM/yyyy");
                    

                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }

    /// <summary>
    /// To Fillup a DropDownList With Database Driven Values without # Select #
    /// </summary>
    /// <param name="dd_dropDownListName">ID of the DropDownList</param>
    /// <param name="s_tableName">Table Name To Fill the DropDownList</param>
    /// <param name="s_colNameTextFiled">Table Column Name Used as Text of The DropDownList</param>
    /// <param name="s_colNameValueFiled">Table Column Name Used as Value of The DropDownList</param>
    public Boolean g_b_FillDropDownList(DropDownList dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameValueFiled, string s_condition, Boolean b_select)
    {
        try
        {
            Connection connection = new Connection()
            {
                ResultsDataSet = null,
                connection = null
            };
            string dataparam = "select " + s_colNameTextFiled + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            string returnValue = string.Empty;

            connection.connection_DB(dataparam, 0, false, false, false);
            if (returnValue != GlobalVariables.g_s_connectionErrorReturnValue)
            {

                DataTable dataTable = connection.ResultsDataSet.Tables[0];
                dd_dropDownListName.Items.Clear();
                ListItem listItemBlank = new ListItem();
                if (b_select)
                {
                    listItemBlank.Text = "# Select #";
                    listItemBlank.Value = "0";
                    dd_dropDownListName.Items.Add(listItemBlank);
                }
                foreach (DataRow drow in dataTable.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = drow[s_colNameTextFiled].ToString();
                    li.Value = drow[s_colNameValueFiled].ToString();
                    dd_dropDownListName.Items.Add(li);
                }
                return true;
            }
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }


    public void g_v_RenderJSArrayWithCliendIds(Page page, params Control[] wc)
    {
        if (wc.Length > 0)
        {
            StringBuilder arrClientIDValue = new StringBuilder();
            StringBuilder arrServerIDValue = new StringBuilder();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            // Now loop through the controls and build the client and server id's
            for (int i = 0; i < wc.Length; i++)
            {
                arrClientIDValue.Append("\"" + wc[i].ClientID + "\",");
                arrServerIDValue.Append("\"" + wc[i].ID + "\",");
            }
            // Register the array of client and server id to the client
            cs.RegisterArrayDeclaration("MyClientID", arrClientIDValue.ToString().Remove(arrClientIDValue.ToString().Length - 1, 1));
            cs.RegisterArrayDeclaration("MyServerID", arrServerIDValue.ToString().Remove(arrServerIDValue.ToString().Length - 1, 1));
            // Now register the method GetClientId, used to get the client id of tthe control
            cs.RegisterStartupScript(page.GetType(), "key", "\nfunction GetClientId(serverId)\n{\nfor(i=0; i<MyServerID.length; i++)\n{\nif ( MyServerID[i] == serverId )\n{\nreturn MyClientID[i];\nbreak;\n}\n}\n}", true);
            cs.RegisterStartupScript(page.GetType(), "key1", "\nfunction GetFocus(clientId)\n{\nfor(i=0; i<MyServerID.length; i++)\n{\nif ( MyClientID[i] == clientId )\n{\n var id=MyClientID[i+1];\ndocument.getElementById(id).focus();\nbreak;\n}\n}\n}", true);
            cs.RegisterStartupScript(page.GetType(), "focusFirefox", "\nfunction GetFocusFirefox(clientId)\n{\nfor(i=0; i<MyServerID.length; i++)\n{\nif ( MyClientID[i] == clientId )\n{\n var id=MyClientID[i+1];\ndocument.getElementById(id).focus();\nif(document.getElementById(id).type != 'select-one')\ndocument.getElementById(id).select();\n}\n}\n}", true);
            cs.RegisterStartupScript(page.GetType(), "key2", "function showUpdateAlert() {\nvar controlId = document.getElementById(GetClientId('hidIsInsertMode'));\nif (controlId.value == \"False\") {\n if (confirm(\"Are you sure to update?\")) {\nreturn true;\n}\nelse\nreturn false;\n}\n}", true);
        }
    }

    public void g_v_RenderJSArrayWithCliendIds_frm_VoucherEntry(Page page, params Control[] wc)
    {
        if (wc.Length > 0)
        {
            StringBuilder arrClientIDValue = new StringBuilder();
            StringBuilder arrServerIDValue = new StringBuilder();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            // Now loop through the controls and build the client and server id's
            for (int i = 0; i < wc.Length; i++)
            {
                arrClientIDValue.Append("\"" + wc[i].ClientID + "\",");
                arrServerIDValue.Append("\"" + wc[i].ID + "\",");
            }
            // Register the array of client and server id to the client
            cs.RegisterArrayDeclaration("ElementClientID", arrClientIDValue.ToString().Remove(arrClientIDValue.ToString().Length - 1, 1));
            cs.RegisterArrayDeclaration("ElementServerID", arrServerIDValue.ToString().Remove(arrServerIDValue.ToString().Length - 1, 1));
            // Now register the method GetClientId, used to get the client id of tthe control
            cs.RegisterStartupScript(page.GetType(), "key", "\nfunction AttachEvent()\n{\nfor(i=0; i<ElementClientID.length; i++)\n{ElementClientID[i].attachEvent('onkeypress','checkCostCenterBillwiseBranchCalculation()')\n}\n}", true);
        }
    }

    public void g_v_RenderJSArrayWithCliendIds_frm_employeeEvaluationByLeader(Page page, params Control[] wc)
    {
        if (wc.Length > 0)
        {
            StringBuilder arrClientIDValue = new StringBuilder();
            StringBuilder arrServerIDValue = new StringBuilder();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = page.ClientScript;

            // Now loop through the controls and build the client and server id's
            for (int i = 0; i < wc.Length; i++)
            {
                arrClientIDValue.Append("\"" + wc[i].ClientID + "\",");
                arrServerIDValue.Append("\"" + wc[i].ID + "\",");
            }
            // Register the array of client and server id to the client
            cs.RegisterArrayDeclaration("MyClientID_frm_employeeEvaluationByLeader", arrClientIDValue.ToString().Remove(arrClientIDValue.ToString().Length - 1, 1));
            cs.RegisterArrayDeclaration("MyServerID_frm_employeeEvaluationByLeader", arrServerIDValue.ToString().Remove(arrServerIDValue.ToString().Length - 1, 1));
            // Now register the method GetClientId, used to get the client id of tthe control
            cs.RegisterStartupScript(page.GetType(), "key", "\nfunction GetClientId_frm_employeeEvaluationByLeader(serverId)\n{\nfor(i=0; i<MyServerID.length; i++)\n{\nif ( MyServerID[i] == serverId )\n{\nreturn MyClientID[i];\nbreak;\n}\n}\n}", true);
            //cs.RegisterStartupScript(page.GetType(), "key1", "\nfunction GetFocus(clientId)\n{\nfor(i=0; i<MyServerID.length; i++)\n{\nif ( MyClientID[i] == clientId )\n{\n var id=MyClientID[i+1];\ndocument.getElementById(id).focus();\nbreak;\n}\n}\n}", true);
        }
    }

    public class Date_Validation
    {   // For Validation of Date
        public Boolean date_Validate(string s_str)
        {
            bool b_isTrue = true;
            int i_length = s_str.Length;
            int j = 0;
            string s_day = String.Empty;
            string s_month = String.Empty;
            string s_year = String.Empty;
            string s = String.Empty;
            string s_temp = String.Empty;

            try
            {
                if (i_length != 10)
                {
                    i_length = 0;
                    s_str = String.Empty;
                    //MessageBox.Show("Invalid Date Format.Format should like DD/MM/YYYY.");
                    return false;
                }

                for (int i = 0; i < i_length; i++)
                {
                    if ((s_str.Substring(i, 1) == "1") || (s_str.Substring(i, 1) == "2") || (s_str.Substring(i, 1) == "3") || (s_str.Substring(i, 1) == "4") ||
                        (s_str.Substring(i, 1) == "5") || (s_str.Substring(i, 1) == "6") || (s_str.Substring(i, 1) == "7") || (s_str.Substring(i, 1) == "8") ||
                        (s_str.Substring(i, 1) == "9") || (s_str.Substring(i, 1) == "0") || (s_str.Substring(i, 1) == "/"))
                    {
                        if (s_str.Substring(i, 1) == "/")
                        {
                            j += 1;
                            if (j > 2)
                            {
                                //MessageBox.Show("Invalid Date Format.Format should like DD/MM/YYYY.");
                                s_str = String.Empty;
                                i_length = 0;
                                return false;
                            }
                        }
                    }
                }
                j = 0;
                s_str = s_str + "/";
                for (int i = 0; i < i_length + 1; i++)
                {
                    s = s_str.Substring(i, 1);
                    if (s != "/")
                    {
                        s_temp += s;
                    }
                    else
                    {
                        j += 1;
                        if (j == 1)
                        {
                            s_day = s_temp;
                            s_temp = String.Empty;
                        }
                        if (j == 2)
                        {
                            s_month = s_temp;
                            s_temp = String.Empty;
                        }
                        if (j == 3)
                        {
                            s_year = s_temp;
                            s_temp = String.Empty;
                        }
                    }
                }

                if (s_day == String.Empty)
                {
                    //MessageBox.Show("Invalid Date Format.Format should like DD/MM/YYYY.");
                    return false;
                }
                else if (Convert.ToInt16(s_day) < 1)
                {
                    //MessageBox.Show("Day can not be less then 1.");
                    return false;
                }
                else if (s_day.Length < 2)
                {
                    //MessageBox.Show("Day must be 2 digit.Exmp. -- 01,02....");
                    return false;
                }

                if (s_month == String.Empty)
                {
                    //MessageBox.Show("Invalid Date Format.Format should like DD/MM/YYYY.");
                    return false;
                }
                else if (Convert.ToInt16(s_month) < 1 || Convert.ToInt16(s_month) > 12)
                {
                    //MessageBox.Show("Month must be in between 01 to 12.");
                    return false;
                }
                else if (s_month.Length < 2)
                {
                    //MessageBox.Show("Month must be 2 digit.Exmp. -- 01,02....");
                    return false;
                }
                else if ((s_month == "04" || s_month == "06" || s_month == "09" || s_month == "11") && Convert.ToInt16(s_day) > 30)
                {
                    //MessageBox.Show("Day must be in between 01 to 30.");
                    return false;
                }
                else if ((s_month == "01" || s_month == "03" || s_month == "05" || s_month == "07" || s_month == "08" ||
                s_month == "10" || s_month == "12") && Convert.ToInt16(s_day) > 31)
                {
                    //MessageBox.Show("Day must be in between 01 to 31.");
                    return false;
                }

                if (s_year == String.Empty)
                {
                    //MessageBox.Show("Invalid Date Format.Format should like DD/MM/YYYY.");
                    return false;
                }
                else if (Convert.ToInt16(s_year) < 1754)
                {
                    //MessageBox.Show("Year can not be less then 1754.");
                    return false;
                }
                else if (s_year.Length < 4)
                {
                    //MessageBox.Show("Year must be 4 digit.Exmp. -- 2007,2008....");
                    return false;
                }
                else
                {
                    if (s_month == "02")
                    {
                        if (Convert.ToInt16(s_year) % 4 != 0)
                        {
                            if (Convert.ToInt16(s_day) > 28)
                            {
                                //MessageBox.Show("Day must be in between 01 to 28.");
                                return false;
                            }
                        }
                        else if (Convert.ToInt16(s_year) % 400 == 0)
                        {
                            if (Convert.ToInt16(s_day) > 29)
                            {
                                //MessageBox.Show("Day must be in between 01 to 29.");
                                return false;
                            }
                        }
                        else if (Convert.ToInt16(s_year) % 100 == 0)
                        {
                            if (Convert.ToInt16(s_day) > 28)
                            {
                                //MessageBox.Show("Day must be in between 01 to 28.");
                                return false;
                            }
                        }
                        else if (Convert.ToInt16(s_year) % 4 == 0)
                        {
                            if (Convert.ToInt16(s_day) > 29)
                            {
                                //MessageBox.Show("Day must be in between 01 to 29.");
                                return false;
                            }
                        }
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }


        /// <summary>
        /// For Date Format -- DD/MMM/YYYY
        /// </summary>
        /// <param name="s_date">Date In DD/MM/YYYY format</param>

        public string s_formatDate(string s_date)
        {
            try
            {

                string s_day = string.Empty;
                string s_month = string.Empty;
                string s_year = string.Empty;
                string s_monthInLetter = string.Empty;
                string s_dateSeparator = "/";
                string s_formattedDateString = string.Empty;
                int i_month;
                s_day = s_date.Substring(0, 2);
                s_month = s_date.Substring(3, 2);
                s_year = s_date.Substring(6, 4);
                i_month = Convert.ToInt32(s_month);

                if (i_month == 01)
                {
                    s_monthInLetter = "Jun";
                }

                else if (i_month == 02)
                {
                    s_monthInLetter = "Feb";
                }

                else if (i_month == 03)
                {
                    s_monthInLetter = "Mar";
                }

                else if (i_month == 04)
                {
                    s_monthInLetter = "Apr";
                }

                else if (i_month == 05)
                {
                    s_monthInLetter = "May";
                }

                else if (i_month == 06)
                {
                    s_monthInLetter = "Jun";
                }
                else if (i_month == 07)
                {
                    s_monthInLetter = "Jul";
                }

                else if (i_month == 08)
                {
                    s_monthInLetter = "Aug";
                }

                else if (i_month == 09)
                {
                    s_monthInLetter = "Sep";
                }

                else if (i_month == 10)
                {
                    s_monthInLetter = "Oct";
                }

                else if (i_month == 11)
                {
                    s_monthInLetter = "Nob";
                }

                else if (i_month == 12)
                {
                    s_monthInLetter = "Dec";
                }

                s_formattedDateString = s_day + s_dateSeparator + s_monthInLetter + s_dateSeparator + s_year;

                return s_formattedDateString;

            }

            catch (Exception)
            {
                throw;
            }



        }

        // For Date Format -- DD/MM/YYYY
        public String date_Format_Front_End(DateTime d)
        {
            string s_string = "";
            try
            {
                s_string = d.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
            }
            catch (ArgumentException)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        // For Date Format -- MM/DD/YYYY
        public String date_Format_Back_End(string s_str)
        {
            try
            {
                s_str = s_str.Substring(3, 2) + "/" + s_str.Substring(0, 2) + "/" + s_str.Substring(6, 4);
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_str;
        }
    }

    public class Numeric_To_String
    {
        //For Neumeric To String
        //Call this function
        public String number_To_String(string s_str)
        {
            string s_string = "";
            string real, fraction;
            int i, k = 0;
            try
            {
                i = s_str.Length;
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (s_str.Substring(j, 1) == ".")
                        {
                            k = j;
                        }
                    }
                }
                else
                    return s_string;

                if (k != 0)
                {
                    fraction = s_str.Substring(k + 1, 2); //return two digit after point
                    real = s_str.Substring(0, k); //return all digit before point
                    if (real != "0")
                    {
                        fraction = fraction_Number_To_String(fraction); //return after point
                        real = real_Number_To_String(real); //return before point
                        s_string = real + " Taka and " + fraction + " Paisa Only";
                    }
                    else if (real == "0")
                    {
                        fraction = fraction_Number_To_String(fraction); //if nothing before point
                        s_string = fraction + " Paisa Only";
                    }
                }
                else if (k == 0)
                {
                    real = real_Number_To_String(s_str); //if nothing after point
                    s_string = real + " Taka Only";
                }
            }
            catch (System.ArgumentException)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        private String fraction_Number_To_String(string s_str)
        {
            string s_string = "";
            string a;
            int i;
            try
            {
                i = s_str.Length;
                if (i == 1 || i == 2)
                {
                    a = convert_To_String(s_str);
                    s_string = a;
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        private String real_Number_To_String(string s_str)
        {
            string s_string = "";
            string a, b, c, d, e, f;
            int i, j = 0;

            try
            {
                i = s_str.Length;

                if (i == 1 || i == 2)
                {
                    a = convert_To_String(s_str);
                    s_string = a;
                }
                if (i == 3)
                {
                    b = convert_To_String(s_str.Substring(1, 2));
                    c = convert_To_String(s_str.Substring(0, 1)) + " Hundred ";
                    s_string = c + b;
                }

                if (i == 4)
                {
                    b = convert_To_String(s_str.Substring(2, 2));
                    c = s_str.Substring(1, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = convert_To_String(s_str.Substring(0, 1)) + " Thousand ";
                    s_string = d + c + b;
                }
                if (i == 5)
                {
                    b = convert_To_String(s_str.Substring(3, 2));
                    c = s_str.Substring(2, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = convert_To_String(s_str.Substring(0, 2)) + " Thousand ";
                    s_string = d + c + b;
                }
                if (i == 6)
                {
                    b = convert_To_String(s_str.Substring(4, 2));
                    c = s_str.Substring(3, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(1, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = convert_To_String(s_str.Substring(0, 1)) + " Lukh ";
                    s_string = e + d + c + b;
                }
                if (i == 7)
                {
                    b = convert_To_String(s_str.Substring(5, 2));
                    c = s_str.Substring(4, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(2, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = convert_To_String(s_str.Substring(0, 2)) + " Lukh ";
                    s_string = e + d + c + b;
                }
                if (i == 8)
                {
                    b = convert_To_String(s_str.Substring(6, 2));
                    c = s_str.Substring(5, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(3, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = s_str.Substring(1, 2);
                    if (e != "00")
                        e = convert_To_String(e) + " Lukh ";
                    else
                        e = "";

                    f = convert_To_String(s_str.Substring(0, 1)) + " Crore ";
                    s_string = f + e + d + c + b;
                }
                if (i == 9)
                {
                    b = convert_To_String(s_str.Substring(7, 2));
                    c = s_str.Substring(6, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(4, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = s_str.Substring(2, 2);
                    if (e != "00")
                        e = convert_To_String(e) + " Lukh ";
                    else
                        e = "";

                    f = s_str.Substring(0, 2);
                    if (f != "00")
                        f = convert_To_String(f) + " Crore ";
                    else
                        f = "";

                    s_string = f + e + d + c + b;
                }
                if (i > 9)
                {
                    b = convert_To_String(s_str.Substring(s_str.Length - 2, 2));
                    c = s_str.Substring(s_str.Length - 3, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(s_str.Length - 5, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = s_str.Substring(s_str.Length - 7, 2);
                    if (e != "00")
                        e = convert_To_String(e) + " Lukh ";
                    else
                        e = "";

                    if (i == 10)
                        j = 3;
                    else if (i == 11)
                        j = 4;
                    else if (i == 12)
                        j = 5;
                    else if (i == 13)
                        j = 6;
                    else if (i == 14)
                        j = 7;
                    else if (i == 15)
                        j = 8;
                    else if (i == 16)
                        j = 9;

                    f = real_Number_To_String_Over_Nine_Digit(s_str.Substring(0, j)) + " Crore ";
                    s_string = f + e + d + c + b;
                }
            }
            catch (System.ArgumentException)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        private String real_Number_To_String_Over_Nine_Digit(string s_str)
        {
            string s_string = "";
            string a, b, c, d, e, f;
            int i;

            try
            {
                i = s_str.Length;

                if (i == 1 || i == 2)
                {
                    a = convert_To_String(s_str);
                    s_string = a;
                }
                if (i == 3)
                {
                    b = convert_To_String(s_str.Substring(1, 2));
                    c = convert_To_String(s_str.Substring(0, 1)) + " Hundred ";
                    s_string = c + b;
                }
                if (i == 4)
                {
                    b = convert_To_String(s_str.Substring(2, 2));
                    c = s_str.Substring(1, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = convert_To_String(s_str.Substring(0, 1)) + " Thousand ";
                    s_string = d + c + b;
                }
                if (i == 5)
                {
                    b = convert_To_String(s_str.Substring(3, 2));
                    c = s_str.Substring(2, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = convert_To_String(s_str.Substring(0, 2)) + " Thousand ";
                    s_string = d + c + b;
                }
                if (i == 6)
                {
                    b = convert_To_String(s_str.Substring(4, 2));
                    c = s_str.Substring(3, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(1, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = convert_To_String(s_str.Substring(0, 1)) + " Lukh ";
                    s_string = e + d + c + b;
                }
                if (i == 7)
                {
                    b = convert_To_String(s_str.Substring(5, 2));
                    c = s_str.Substring(4, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(2, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = convert_To_String(s_str.Substring(0, 2)) + " Lukh ";
                    s_string = e + d + c + b;
                }
                if (i == 8)
                {
                    b = convert_To_String(s_str.Substring(6, 2));
                    c = s_str.Substring(5, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(3, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = s_str.Substring(1, 2);
                    if (e != "00")
                        e = convert_To_String(e) + " Lukh ";
                    else
                        e = "";

                    f = convert_To_String(s_str.Substring(0, 1)) + " Crore ";
                    s_string = f + e + d + c + b;
                }
                if (i == 9)
                {
                    b = convert_To_String(s_str.Substring(7, 2));
                    c = s_str.Substring(6, 1);
                    if (c != "0")
                        c = convert_To_String(c) + " Hundred ";
                    else
                        c = "";

                    d = s_str.Substring(4, 2);
                    if (d != "00")
                        d = convert_To_String(d) + " Thousand ";
                    else
                        d = "";

                    e = s_str.Substring(2, 2);
                    if (e != "00")
                        e = convert_To_String(e) + " Lukh ";
                    else
                        e = "";

                    f = s_str.Substring(0, 2);
                    if (f != "00")
                        f = convert_To_String(f) + " Crore ";
                    else
                        f = "";

                    s_string = f + e + d + c + b;
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        private String convert_To_String(string s_str)
        {
            string s_string = "";
            try
            {
                if (s_str == "0")
                    s_string = "Zero";
                else if (s_str == "1")
                    s_string = "One";
                else if (s_str == "2")
                    s_string = "Two";
                else if (s_str == "3")
                    s_string = "Three";
                else if (s_str == "4")
                    s_string = "Four";
                else if (s_str == "5")
                    s_string = "Five";
                else if (s_str == "6")
                    s_string = "Six";
                else if (s_str == "7")
                    s_string = "Seven";
                else if (s_str == "8")
                    s_string = "Eight";
                else if (s_str == "9")
                    s_string = "Nine";
                else if (s_str == "01")
                    s_string = "One";
                else if (s_str == "02")
                    s_string = "Two";
                else if (s_str == "03")
                    s_string = "Three";
                else if (s_str == "04")
                    s_string = "Four";
                else if (s_str == "05")
                    s_string = "Five";
                else if (s_str == "06")
                    s_string = "Six";
                else if (s_str == "07")
                    s_string = "Seven";
                else if (s_str == "08")
                    s_string = "Eight";
                else if (s_str == "09")
                    s_string = "Nine";
                else if (s_str == "10")
                    s_string = "Ten";
                else if (s_str == "11")
                    s_string = "Eleven";
                else if (s_str == "12")
                    s_string = "Twelve";
                else if (s_str == "13")
                    s_string = "Thirteen";
                else if (s_str == "14")
                    s_string = "Fourteen";
                else if (s_str == "15")
                    s_string = "Fifteen";
                else if (s_str == "16")
                    s_string = "Sixteen";
                else if (s_str == "17")
                    s_string = "Seventeen";
                else if (s_str == "18")
                    s_string = "Eighteen";
                else if (s_str == "19")
                    s_string = "Nineteen";
                else if (s_str == "20")
                    s_string = "Twenty";
                else if (s_str == "21")
                    s_string = "Twenty One";
                else if (s_str == "22")
                    s_string = "Twenty Two";
                else if (s_str == "23")
                    s_string = "Twenty Three";
                else if (s_str == "24")
                    s_string = "Twenty Four";
                else if (s_str == "25")
                    s_string = "Twenty Five";
                else if (s_str == "26")
                    s_string = "Twenty Six";
                else if (s_str == "27")
                    s_string = "Twenty Seven";
                else if (s_str == "28")
                    s_string = "Twenty Eight";
                else if (s_str == "29")
                    s_string = "Twenty Nine";
                else if (s_str == "30")
                    s_string = "Thirty";
                else if (s_str == "31")
                    s_string = "Thirty One";
                else if (s_str == "32")
                    s_string = "Thirty Two";
                else if (s_str == "33")
                    s_string = "Thirty Three";
                else if (s_str == "34")
                    s_string = "Thirty Four";
                else if (s_str == "35")
                    s_string = "Thirty Five";
                else if (s_str == "36")
                    s_string = "Thirty Six";
                else if (s_str == "37")
                    s_string = "Thirty Seven";
                else if (s_str == "38")
                    s_string = "Thirty Eight";
                else if (s_str == "39")
                    s_string = "Thirty Nine";
                else if (s_str == "40")
                    s_string = "Forty";
                else if (s_str == "41")
                    s_string = "Forty One";
                else if (s_str == "42")
                    s_string = "Forty Two";
                else if (s_str == "43")
                    s_string = "Forty Three";
                else if (s_str == "44")
                    s_string = "Forty Four";
                else if (s_str == "45")
                    s_string = "Forty Five";
                else if (s_str == "46")
                    s_string = "Forty Six";
                else if (s_str == "47")
                    s_string = "Forty Seven";
                else if (s_str == "48")
                    s_string = "Forty Eight";
                else if (s_str == "49")
                    s_string = "Forty Nine";
                else if (s_str == "50")
                    s_string = "Fifty";
                else if (s_str == "51")
                    s_string = "Fifty One";
                else if (s_str == "52")
                    s_string = "Fifty Two";
                else if (s_str == "53")
                    s_string = "Fifty Three";
                else if (s_str == "54")
                    s_string = "Fifty Four";
                else if (s_str == "55")
                    s_string = "Fifty Five";
                else if (s_str == "56")
                    s_string = "Fifty Six";
                else if (s_str == "57")
                    s_string = "Fifty Seven";
                else if (s_str == "58")
                    s_string = "Fifty Eight";
                else if (s_str == "59")
                    s_string = "Fifty Nine";
                else if (s_str == "60")
                    s_string = "Sixty";
                else if (s_str == "61")
                    s_string = "Sixty One";
                else if (s_str == "62")
                    s_string = "Sixty Two";
                else if (s_str == "63")
                    s_string = "Sixty Three";
                else if (s_str == "64")
                    s_string = "Sixty Four";
                else if (s_str == "65")
                    s_string = "Sixty Five";
                else if (s_str == "66")
                    s_string = "Sixty Six";
                else if (s_str == "67")
                    s_string = "Sixty Seven";
                else if (s_str == "68")
                    s_string = "Sixty Eight";
                else if (s_str == "69")
                    s_string = "Sixty Nine";
                else if (s_str == "70")
                    s_string = "Seventy";
                else if (s_str == "71")
                    s_string = "Seventy One";
                else if (s_str == "72")
                    s_string = "Seventy Two";
                else if (s_str == "73")
                    s_string = "Seventy Three";
                else if (s_str == "74")
                    s_string = "Seventy Four";
                else if (s_str == "75")
                    s_string = "Seventy Five";
                else if (s_str == "76")
                    s_string = "Seventy Six";
                else if (s_str == "77")
                    s_string = "Seventy Seven";
                else if (s_str == "78")
                    s_string = "Seventy Eight";
                else if (s_str == "79")
                    s_string = "Seventy Nine";
                else if (s_str == "80")
                    s_string = "Eighty";
                else if (s_str == "81")
                    s_string = "Eighty One";
                else if (s_str == "82")
                    s_string = "Eighty Two";
                else if (s_str == "83")
                    s_string = "Eighty Three";
                else if (s_str == "84")
                    s_string = "Eighty Four";
                else if (s_str == "85")
                    s_string = "Eighty Five";
                else if (s_str == "86")
                    s_string = "Eighty Six";
                else if (s_str == "87")
                    s_string = "Eighty Seven";
                else if (s_str == "88")
                    s_string = "Eighty Eight";
                else if (s_str == "89")
                    s_string = "Eighty Nine";
                else if (s_str == "90")
                    s_string = "Ninety";
                else if (s_str == "91")
                    s_string = "Ninety One";
                else if (s_str == "92")
                    s_string = "Ninety Two";
                else if (s_str == "93")
                    s_string = "Ninety Three";
                else if (s_str == "94")
                    s_string = "Ninety Four";
                else if (s_str == "95")
                    s_string = "Ninety Five";
                else if (s_str == "96")
                    s_string = "Ninety Six";
                else if (s_str == "97")
                    s_string = "Ninety Seven";
                else if (s_str == "98")
                    s_string = "Ninety Eight";
                else if (s_str == "99")
                    s_string = "Ninety Nine";
                else if (s_str == "100")
                    s_string = "One Hundred";

            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }

        private String single_Fraction_Numeric_To_String(string s_str)
        {
            string s_string = "";
            try
            {
                if (s_str == "1")
                    s_string = "Ten";
                else if (s_str == "2")
                    s_string = "Twenty";
                else if (s_str == "3")
                    s_string = "Thirty";
                else if (s_str == "4")
                    s_string = "Forty";
                else if (s_str == "5")
                    s_string = "Fifty";
                else if (s_str == "6")
                    s_string = "Sixty";
                else if (s_str == "7")
                    s_string = "Seventy";
                else if (s_str == "8")
                    s_string = "Eighty";
                else if (s_str == "9")
                    s_string = "Ninety";

            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_string;
        }
    }

    /// <summary>
    ///  must validation of textbox controls
    /// </summary>
    /// <param name="txt_textBoxName">ID of the textBox</param>
    public Boolean g_B_mustValidation(TextBox txt)
    {
        if (txt.Text == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public Boolean g_B_mustValidationForSelectedIndex(DropDownList dd)
    {
        if (dd.SelectedValue == "0")
        { return false; }
        else
        { return true; }
    }

    public class numeric_Validation
    {
        //For Neumeric validation integer
        public Boolean Numeric_Validation_Integer(string s_str, int dftMsg)
        {
            bool b_isTrue = false;
            int i_length = s_str.Length;

            try
            {
                for (int i = 0; i < i_length; i++)
                {
                    if ((s_str.Substring(i, 1) == "1") || (s_str.Substring(i, 1) == "2") || (s_str.Substring(i, 1) == "3") || (s_str.Substring(i, 1) == "4") ||
                        (s_str.Substring(i, 1) == "5") || (s_str.Substring(i, 1) == "6") || (s_str.Substring(i, 1) == "7") || (s_str.Substring(i, 1) == "8") ||
                        (s_str.Substring(i, 1) == "9") || (s_str.Substring(i, 1) == "0"))
                    {
                        b_isTrue = true;
                    }
                    else
                    {
                        if (dftMsg == 0)
                        {
                            //MessageBox.Show("Invalid Data.");
                        }
                        b_isTrue = false;
                        s_str = "";
                        i_length = 0;
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }

        // For Neumeric validation integer with minus
        public Boolean numeric_Validation_Integer_Allow_Minus(string s_str, int dftMsg)
        {
            bool b_isTrue = false;
            int i_length = s_str.Length;

            try
            {
                for (int i = 0; i < i_length; i++)
                {
                    if ((s_str.Substring(i, 1) == "1") || (s_str.Substring(i, 1) == "2") || (s_str.Substring(i, 1) == "3") || (s_str.Substring(i, 1) == "4") ||
                        (s_str.Substring(i, 1) == "5") || (s_str.Substring(i, 1) == "6") || (s_str.Substring(i, 1) == "7") || (s_str.Substring(i, 1) == "8") ||
                        (s_str.Substring(i, 1) == "9") || (s_str.Substring(i, 1) == "0") || (s_str.Substring(i, 1) == "-"))
                    {
                        b_isTrue = true;

                        if (s_str.Substring(i, 1) == "-")
                        {
                            if (i > 0)
                            {
                                if (dftMsg == 0)
                                {
                                    //MessageBox.Show("Invalid Data.");
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }
                    }
                    else
                    {
                        if (dftMsg == 0)
                        {
                            //MessageBox.Show("Invalid Data.");
                        }
                        b_isTrue = false;
                        s_str = "";
                        i_length = 0;
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }

        // For Neumeric validation decimal
        public Boolean numeric_Validation_Decimal(string s_str, int dftMsg)
        {
            bool b_isTrue = false;
            int i_length = s_str.Length;
            int j = 0;

            try
            {
                for (int i = 0; i < i_length; i++)
                {
                    if ((s_str.Substring(i, 1) == "1") || (s_str.Substring(i, 1) == "2") || (s_str.Substring(i, 1) == "3") || (s_str.Substring(i, 1) == "4") ||
                        (s_str.Substring(i, 1) == "5") || (s_str.Substring(i, 1) == "6") || (s_str.Substring(i, 1) == "7") || (s_str.Substring(i, 1) == "8") ||
                        (s_str.Substring(i, 1) == "9") || (s_str.Substring(i, 1) == "0") || (s_str.Substring(i, 1) == "."))
                    {
                        b_isTrue = true;

                        if (s_str.Substring(i, 1) == ".")
                        {
                            j += 1;

                            if (j > 1)
                            {
                                if (dftMsg == 0)
                                {
                                    //MessageBox.Show("Invalid Data.");
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }
                    }
                    else
                    {
                        if (dftMsg == 0)
                        {
                            //MessageBox.Show("Invalid Data.");
                        }
                        b_isTrue = false;
                        s_str = "";
                        i_length = 0;
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }

        // For Neumeric validation decimal with minus
        public Boolean numeric_Validation_Decimal_Allow_Minus(string s_str, int dftMsg)
        {
            bool b_isTrue = false;
            int i_length = s_str.Length;
            int j = 0;

            try
            {
                for (int i = 0; i < i_length; i++)
                {
                    if ((s_str.Substring(i, 1) == "1") || (s_str.Substring(i, 1) == "2") || (s_str.Substring(i, 1) == "3") || (s_str.Substring(i, 1) == "4") ||
                        (s_str.Substring(i, 1) == "5") || (s_str.Substring(i, 1) == "6") || (s_str.Substring(i, 1) == "7") || (s_str.Substring(i, 1) == "8") ||
                        (s_str.Substring(i, 1) == "9") || (s_str.Substring(i, 1) == "0") || (s_str.Substring(i, 1) == ".") || (s_str.Substring(i, 1) == "-"))
                    {
                        b_isTrue = true;

                        if (s_str.Substring(i, 1) == "-")
                        {
                            if (i > 0)
                            {
                                if (dftMsg == 0)
                                {
                                    //MessageBox.Show("Invalid Data.");
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }

                        if (s_str.Substring(i, 1) == ".")
                        {
                            j += 1;

                            if (j > 1)
                            {
                                if (dftMsg == 0)
                                {
                                    //MessageBox.Show("Invalid Data.");
                                }
                                b_isTrue = false;
                                s_str = "";
                                i_length = 0;
                            }
                        }
                    }
                    else
                    {
                        if (dftMsg == 0)
                        {
                            //MessageBox.Show("Invalid Data.");
                        }
                        b_isTrue = false;
                        s_str = "";
                        i_length = 0;
                    }
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return b_isTrue;
        }
    }

    public class password_Handler
    {
        // For Encryption of String
        public String encrypt_String(string s_str)
        {
            int i_length = s_str.Length;
            string s_userId = "";
            char s;

            try
            {
                for (int i = 0; i < i_length; i++)
                {
                    s = (char)((int)s_str[i] + 90);
                    s_userId += s;
                }
            }
            catch (System.ArgumentException ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_userId;
        }

        // For Decryption of String
        public String decrypt_String(string s_str)
        {
            int i_length = s_str.Length;
            string s_userId = "";
            char s;

            try
            {
                for (int i = 0; i < i_length; i++)
                {
                    s = (char)((int)s_str[i] - 90);
                    s_userId += s;
                }
            }
            catch (System.ArgumentException)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                //nothing;
            }
            return s_userId;
        }

        /** use for encrypt userId */
        public String encrypt_UserId(string userId)
        {
            int length = userId.Length;
            string s_d_userId = "";
            char s;

            for (int i = 0; i < length; i++)
            {
                s = (char)((int)userId[i] + 90);
                s_d_userId += s;
            }
            return s_d_userId;
        }

        /** use for decrypt userId */
        public String decrypt_UserId(string userId)
        {
            int length = userId.Length;
            string s_d_userId = "";
            char s;

            for (int i = 0; i < length; i++)
            {
                s = (char)((int)userId[i] - 90);
                s_d_userId += s;
            }
            return s_d_userId;
        }

        /**  use for encrypt password */
        public String encrypt_Password(string password)
        {
            int length = password.Length;
            string s_d_userId = "";
            char s;

            for (int i = 0; i < length; i++)
            {
                s = (char)((int)password[i] + 90);
                s_d_userId += s;
            }


            return s_d_userId;
        }

        /** use for decrypt_password */
        public String decrypt_Password(string password)
        {
            int length = password.Length;
            string s_d_userId = "";
            char s;

            for (int i = 0; i < length; i++)
            {
                s = (char)((int)password[i] - 90);
                s_d_userId += s;
            }
            return s_d_userId;
        }
    }


    /// <summary>
    /// To Fillup a DropDownList With Database Driven Values without # Select #
    /// </summary>
    /// <param name="dd_dropDownListName">ID of the DropDownList</param>
    /// <param name="s_tableName">Table Name To Fill the DropDownList</param>
    /// <param name="s_colNameTextFiled">Table Column Name Used as Text of The DropDownList</param>
    /// <param name="s_colNameValueFiled">Table Column Name Used as Value of The DropDownList</param>
    public Boolean g_b_ListBox(ListBox dd_dropDownListName, string s_tableName, string s_colNameTextFiled, string s_colNameValueFiled, string s_condition, Boolean b_select)
    {
        try
        {
            Connection connection = new Connection() { ResultsDataSet = null, connection = null };
            string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
            connection.connection_DB(dataparam, 0, false, false, false);
            DataSet dataSet = new DataSet();
            DataTable dataTable = connection.ResultsDataSet.Tables[0];
            dd_dropDownListName.Items.Clear();
            ListItem listItemBlank = new ListItem();
            if (b_select)
            {
                listItemBlank.Text = "# Select #";
                listItemBlank.Value = "0";
                dd_dropDownListName.Items.Add(listItemBlank);
            }
            foreach (DataRow drow in dataTable.Rows)
            {
                ListItem li = new ListItem();
                li.Text = drow[s_colNameTextFiled].ToString();
                li.Value = drow[s_colNameValueFiled].ToString();
                dd_dropDownListName.Items.Add(li);
            }
            return true;
        }
        catch (Exception)
        {
            //MessageBox.Show(ex.Message);
        }
        return false;
    }

    /// <summary>
    /// To Fillup a DropDownList With Database Driven Values without # Select #
    /// </summary>
    /// <param name="dd_dropDownListName">ID of the DropDownList</param>
    /// <param name="s_tableName">Table Name To Fill the DropDownList</param>
    /// <param name="s_colNameTextFiled">Table Column Name Used as Text of The DropDownList</param>
    /// <param name="s_colNameValueFiled">Table Column Name Used as Value of The DropDownList</param>
    //public Boolean g_b_C1ComboBox(C1ComboBox c1ComboBox, string s_tableName, string s_colNameTextFiled, string s_colNameValueFiled, string s_condition, Boolean b_select)
    //{
    //    try
    //    {
    //        Connection connection = new Connection() { ResultsDataSet = null, connection = null };
    //        string dataparam = "select distinct " + s_colNameTextFiled + "," + s_colNameValueFiled + " from " + s_tableName + " " + s_condition;
    //        connection.connection_DB(dataparam, 0, false, false, false);
    //        DataTable dataTable = connection.ResultsDataSet.Tables[0];
    //        c1ComboBox.Items.Clear();
    //        C1ComboBoxItem c1ComboBoxItem = new C1ComboBoxItem();
    //        if (b_select)
    //        {
    //            c1ComboBoxItem.Text = "# Select #";
    //            c1ComboBoxItem.Value = "0";
    //            c1ComboBox.Items.Add(c1ComboBoxItem);
    //        }

    //        C1ComboBoxBindColumn col = new C1ComboBoxBindColumn();
    //        col.FieldName = s_colNameTextFiled;
    //        C1ComboBoxBindColumn col1 = new C1ComboBoxBindColumn();
    //        col1.FieldName = s_colNameValueFiled;
    //        c1ComboBox.Columns.Add(col);
    //        c1ComboBox.Columns.Add(col1);
    //        c1ComboBox.DataTextField = s_colNameTextFiled;
    //        c1ComboBox.DataValueField = s_colNameValueFiled;
    //        c1ComboBox.DataSource = dataTable;
    //        c1ComboBox.DataBind();
    //        //C1ComboBoxItem c1ComboBoxItem = new C1ComboBoxItem();
    //        //if (b_select)
    //        //{
    //        //    c1ComboBoxItem.Text = "# Select #";
    //        //    c1ComboBoxItem.Value = "0";
    //        //    c1ComboBox.Items.Add(c1ComboBoxItem);
    //        //}
    //        //foreach (DataRow drow in dataTable.Rows)
    //        //{
    //        //    C1ComboBoxItem comboBoxItem = new C1ComboBoxItem();
    //        //    comboBoxItem.Text = drow[s_colNameTextFiled].ToString();
    //        //    comboBoxItem.Value = drow[s_colNameValueFiled].ToString();
    //        //    c1ComboBox.Items.Add(new C1ComboBoxItem(drow[s_colNameTextFiled].ToString() +"|"+ drow[s_colNameValueFiled].ToString()));
    //        //}
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message);
    //    }
    //    return false;
    //}

}
