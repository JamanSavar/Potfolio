<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_login.aspx.cs" Inherits="HumanResource_Common_frm_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<link href="../cssSTM.css" rel="stylesheet" type="text/css" />--%>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ERP Management System</title>
    <link href="../Forms/stylelogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style=" height: 900px;  ">
   
        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
           
            <tr>
                <td>
                    <%--<img src="../Forms/Constants/Images/blank.gif" width="5" height="85" alt="" border="0" />--%>
                    <img src="../Forms/Constants/Images/blank.gif" width="5" height="85" alt="" border="0" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="900"  align="center"  cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="158" valign="top"  >
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <img src="../Forms/Constants/Images/blank.gif" width="1" height="16" alt="" border="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                          
                                                <tr>
                                                    <td width="1%">
                                                        <%--<img src="../../Forms/Constants/Images/logo.jpg" width="192" height="74" alt="" border="0"/>--%>
                                                    </td>
                                                    <td width="99%" align="left">
                                                <%--        <img src="../../Forms/Constants/Images/software_name.gif" width="351" height="42"
                                                            style="padding-right: 10px;" alt="" />--%>
                                                       <asp:Label ID="Label1" runat="server" Text="ERP Management System" ForeColor="Red" Font-Size="30px"   Font-Bold="true" Height="42px" ></asp:Label>
                                                       <%--<marquee behavior="Alternate">for Footbed Footwear Limited.</marquee>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" >
                                                <tr>
                                                    <td width="50%" height="300" valign="top" style=" padding-top: 100px; padding-left: 10px;">
                                                       <%--<img src="../Forms/Constants/Images/stmlogo.jpg" width="503px"  style="background-color:Red; margin-bottom:150px;" height="158px"
                                                            alt="" />--%>
                                                            
                                                            <img src="../Forms/Constants/Images/excomlogo.jpg" width="503px"  style="background-color:Red; margin-bottom:150px;" height="158px"
                                                            alt="" />
                                                            
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
                                                            <tr>
                                                                <td style="font-size:11px; font-weight:bold;">
                                                                  <%--<marquee  behavior="Alternate">   Developed by : STM Software Limited.</marquee>--%>
                                                                  Developed by : Excom Fashions Ltd.
                                                                </td>
                                                            </tr>
                                                            </table>
                                                    </td>
                                                    <td width="7%">
                                                        <img src="../Forms/Constants/Images/blank.gif" width="65" height="20" alt="" border="0" />
                                                    </td>
                                                    <td width="43%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="78%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="login_tex">
                                                                                User ID:
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="10">
                                                                                <asp:TextBox ID="txt_userName" runat="server" class="input_box" Width="249px" Font-Bold="true" ForeColor="White" BackColor="Black"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="login_txt_ex">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Forms/Constants/Images/blank.gif" width="5" height="25" alt="" border="0" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="login_tex">
                                                                                Password:
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="10" class="login_tex">
                                                                                <asp:TextBox ID="txt_password" runat="server" TextMode="Password" class="input_box"
                                                                                    Width="249px" Font-Bold="true" ForeColor="White" BackColor="Black"></asp:TextBox>
                                                                                <%--<asp:TextBox ID="TextBox1" runat="server" TextMode="Password" class="input_box"
                                                                                    Width="249px">jahirhstu@gmail.com</asp:TextBox>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Forms/Constants/Images/blank.gif" height="10" alt="" border="0" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Forms/Constants/Images/blank.gif" width="5" height="10" alt="" border="0" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr visible="false" >
                                                                            <td class="login_tex">
                                                                                Company Name:
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td  class="login_tex">
                                                                                <asp:DropDownList ID="dd_companyName" runat="server" Width="253px" class="dd_box" Visible="true" Font-Bold="true"  >
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                                                    ControlToValidate="dd_companyName" Display="Dynamic" InitialValue="0">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Forms/Constants/Images/blank.gif" height="10" alt="" border="0" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="34" class="login_tex">
                                                                                <label>
                                                                                    <asp:Button ID="btn_login" runat="server" Text="Sign in" OnClick="btn_login_Click" Width="120px" Font-Bold="true"
                                                                                        CssClass="button" />
                                                                                    &nbsp;<asp:Button ID="btn_exit" CssClass="button" runat="server" 
                                                                                    Text="Exit" OnClick="btn_exit_Click" Visible="False" />
                                                                                </label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr> 
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
