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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;
/// <summary>
/// Summary description for Gp
/// </summary>
public class Gp
{
    public Gp()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    static void sendMailMessage()
    {
        Connection connection = new Connection();
        connection.connection_DB(" SELECT COUNT(*) FROM "
            + TableColumnName.T_PersonalInformation.TableName, 0, false, false, false);
        if (Convert.ToInt32(connection.ResultsDataSet.Tables[0].Rows[0][0].ToString()) > 30)
        {
            StringBuilder s_body = new StringBuilder();
            MailMessage mail = new MailMessage();
            string s_htmlBody = string.Empty;
            mail.To.Add("testsa99@gmail.com");
            mail.From = new MailAddress("from@gmail.com", "jahir");
            mail.Subject = "Test Email";
            string Body = "Welcome to CodeDigest.Com!!";
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("testad99@gmail.com", "testad123456");
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            smtp.Send(mail);
        }
    }
}
