using System.Text;
using System.Web;

/// <summary>
/// Summary description for MessagebOX
/// </summary>
public class MessageBox
{
    public MessageBox()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void Show(string s_message)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script language='javascript'>");
        sb.Append(@"alert( """ + s_message + @""" );");
        sb.Append(@"</script>");
        HttpContext.Current.Response.Write(sb);
    }
}
