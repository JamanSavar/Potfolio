<%@ WebHandler Language="C#" Class="ShowImage" %>

using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public class ShowImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        Int32 EmpAutoId;
        if (context.Request.QueryString["qs_id"] != null)
            EmpAutoId = Convert.ToInt32(context.Request.QueryString["qs_id"]);
        else
            throw new ArgumentException("No parameter specified");

        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowEmpImage(EmpAutoId);
        byte[] buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);

        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }  
              
    }

    public Stream ShowEmpImage(int EmpAutoId)
    {

        Connection connection = new Connection();
        CommonFunctions commonFunctions = new CommonFunctions();
        ConnectionImage connectionImage = new ConnectionImage();
        SqlConnection sqlconnection = new SqlConnection(commonFunctions.connection_String(ConfigurationManager.ConnectionStrings["HR_IMAGE"].ToString()));


        string sql = "SELECT picture FROM T_EmployeePicture WHERE autoId = @autoId";
        SqlCommand cmd = new SqlCommand(sql, sqlconnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@autoId", EmpAutoId);
        sqlconnection.Open();
        object img = cmd.ExecuteScalar();
        try
        {
            return new MemoryStream((byte[])img);
        }
        catch
        {
            return null;
        }
        finally
        {
            sqlconnection.Close();
        }
    }
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}