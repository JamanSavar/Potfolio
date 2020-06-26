using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ConnectionImage
/// </summary>
public class ConnectionImage
{

    public SqlConnection connection;
    private SqlCommand cmd;
    private SqlDataReader reader;
    private SqlDataAdapter da;
    public DataSet ResultsDataSet;
    private SqlTransaction transaction;

    // For Insert,Update,Delete
    // s_Quary = SQL Statemant
    // i_QuaryState = 0 -- For Select Statemant
    // i_QuaryState = 1 -- For Insert,Update,Delete Statemant
    // b_IsReturnValue = false for Return Nothing From SQL Statement
    // b_IsReturnValue = true for Return Value From SQL Statement
    // For Single Statement --
    // Example -- connection_DB(sql Statement,1,false,true,true)
    // For Multiple Statement --
    // Beginning of Insert,Update,Delete Statement --
    // Example -- connection_DB(sql Statement,1,true,true,false)
    // Middle of Insert,Update,Delete Statement --
    // Example -- connection_DB(sql Statement,1,true,false,false)
    // End of Insert,Update,Delete --
    // Example -- connection_DB(sql Statement,1,true,false,true)

    /// <summary>
    /// For Insert,Update,Delete
    /// For Single Statement --
    /// Example -- connection_DB(sql Statement,1,false,true,true)
    /// For Multiple Statement --
    /// Beginning of Insert,Update,Delete Statement --
    /// Example -- connection_DB(sql Statement,1,true,true,false)
    /// Middle of Insert,Update,Delete Statement --
    /// Example -- connection_DB(sql Statement,1,true,false,false)
    /// End of Insert,Update,Delete --
    /// Example -- connection_DB(sql Statement,1,true,false,true)
    /// </summary>
    /// <param name="s_Quary">SQL Statemant</param>
    /// <param name="i_QuaryState">0 -- For Select Statemant, 1 -- For Insert,Update,Delete Statemant</param>
    /// <param name="b_IsReturnValue">false for Return Nothing From SQL Statement, true for Return Value From SQL Statement</param>
    /// <param name="b_Trans">True -- Begin Transaction</param>
    /// <param name="b_Commit">True -- Commit Transaction</param>
    /// <returns>String</returns>
	public ConnectionImage()
	{
        connection = new SqlConnection(connection_String(ConfigurationManager.ConnectionStrings["HR_IMAGE"].ToString()));  
	}
    public String connection_DB(string s_Quary, int i_QuaryState, bool b_IsReturnValue, bool b_Trans, bool b_Commit)
    {
        string s_Str = String.Empty;
        bool b_Rollback = false;
        try
        {
            connection = new SqlConnection(connection_String(ConfigurationManager.ConnectionStrings["HR_IMAGE"].ToString()));
            ResultsDataSet = new DataSet();

            if (i_QuaryState == 0)   // For Select
            {
                b_Rollback = false;
                da = new SqlDataAdapter(s_Quary, connection);
                SqlCommandBuilder scb = new SqlCommandBuilder(da);
                da.Fill(ResultsDataSet);
            }
            else if (i_QuaryState == 1) // For Insert,Update,Delete
            {
                b_Rollback = true;
                if (connection.State == ConnectionState.Closed && b_Trans == true)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandTimeout = 0;
                    transaction = connection.BeginTransaction();
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                }
                cmd.CommandText = s_Quary;
                if (b_IsReturnValue == false) // For Return Nothing From SQL Statement
                {
                    cmd.ExecuteNonQuery();
                }
                else if (b_IsReturnValue == true) // For Return Value From SQL Statement
                {
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    s_Str = reader[0].ToString();
                    reader.Close();
                }
                if (b_Commit == true)
                {
                    transaction.Commit();
                }
            }
        }
        catch (Exception)
        {
            try
            {
                //MessageBox.Show(e.Message.ToString());                    
                if (b_Rollback == true)
                {
                    transaction.Rollback();
                    transaction.Dispose();
                }
                connection.Close();
                s_Str = GlobalVariables.g_s_connectionErrorReturnValue;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MessageBox.Show(ex.Message + " - " + ex.Number.ToString());
                s_Str = GlobalVariables.g_s_connectionErrorReturnValue;
            }
        }
        finally
        {
            if (connection.State == ConnectionState.Open && b_Commit == true)
            {
                connection.Close();
                transaction.Dispose();
            }
        }
        return s_Str;
    }
    // For Save Image Only
    public void connection_DB_Image(int i_QuaryState, string s_LinkAutoId, byte[] b_Image)
    {
        string qry = string.Empty;
        try
        {
            connection = new SqlConnection(connection_String(ConfigurationManager.ConnectionStrings["HR_IMAGE"].ToString()));
            if (i_QuaryState == 0)
            {
                qry = "insert into T_Image values(@linkAutoId, @Image)";
            }
            else
            {
                qry = "update T_Image set Image = @Image where linkAutoId = @linkAutoId";
            }
            cmd = new SqlCommand(qry, connection);
            cmd.Parameters.Add(new SqlParameter("@linkAutoId", (object)s_LinkAutoId));
            cmd.Parameters.Add(new SqlParameter("@Image", (object)b_Image));
            connection.Open();
            transaction = connection.BeginTransaction();
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            cmd.ExecuteNonQuery();
            transaction.Commit();
        }
        catch (Exception e)
        {
            try
            {
                transaction.Rollback();
                connection.Close();
                transaction.Dispose();
                //MessageBox.Show(e.Message.ToString());
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //MessageBox.Show(ex.Message + " - " + ex.Number.ToString());
            }
        }
        finally
        {
            connection.Close();
            transaction.Dispose();
        }
    }
    private string databaseName = string.Empty;
    public string DatabaseName
    {
        get
        {
            return databaseName;
        }
        set
        {
            databaseName = value;
        }
    }

    private string serverName = string.Empty;
    public string ServerName
    {
        get
        {
            return serverName;
        }
        set
        {
            serverName = value;
        }
    }

    private string userId = string.Empty;
    public string UserId
    {
        get
        {
            return userId;
        }
        set
        {
            userId = value;
        }
    }

    private string password = string.Empty;
    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }

    private string connectionString = string.Empty;
    public string ConnectionString
    {
        get
        {
            return connectionString;
        }
        set
        {
            connectionString = value;
        }
    }

    // For Getting Info From Configuration File
    public String connection_String(string s_conn_string)
    {
        int i_len = s_conn_string.Length;
        string s_database = "";
        string s_server = "";
        string s_userId = "";
        string s_passward = "";
        string s_connString = "";
        string s_temp = "";
        string s = "";
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
                            DatabaseName = s_database;
                            s_temp = "";
                        }
                        if (j == 2)
                        {
                            s_server = s_temp.Substring(7, s_temp.Length - 7).Trim().ToString();
                            ServerName = s_server;
                            s_temp = "";
                        }
                        if (j == 3)
                        {
                            s_userId = s_temp.Substring(7, s_temp.Length - 7).Trim().ToString();
                            UserId = s_userId;
                            s_temp = "";
                        }
                        if (j == 4)
                        {
                            s_passward = s_temp.Substring(9, s_temp.Length - 9).Trim().ToString();
                            Password = s_passward;
                            s_temp = "";
                        }
                    }
                }
                if (s_userId == "")
                {
                    s_connString = "Integrated Security=SSPI;Initial Catalog=" + s_database + ";Data Source=" + s_server + ";";
                    ConnectionString = s_connString;
                }
                else
                {
                    s_connString = "Persist Security Info=False;User Id=" + s_userId + ";Password=" + s_passward + ";Initial Catalog=" + s_database + ";Data Source=" + s_server + ";";
                    ConnectionString = s_connString;
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
        return s_connString;
    }
}
