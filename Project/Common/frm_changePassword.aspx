﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frm_changePassword.aspx.cs"
    Inherits="HumanResource_Common_frm_changePassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR & Finance Management - Change Password</title>
    <link href="../../Forms/cssSTM.css" rel="stylesheet" type="text/css" />
</head>
<body style="font-family:Helvetica;font-size:14px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: auto; height: 700px; background-color: #666666;">
        <center>
            <div style="max-width: 600px; min-width: 50%; background-color: Gray; border: solid 1px #C0C0C0;
                height: 300px; padding: 50px 0px 0px 0px;">                   
                <div style="width: 500px; background-color: DimGray; border: solid 1px #C0C0C0;text-align:left;">
                    <b style="color:White;">Change Password</b>
                    <table style="text-align: left; width: 100%;margin:10px 0px 0px 0px;">
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="Employee Name"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbEmployee" runat="server" AutoPostBack="True" 
                                    Width="301px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOldPassword" runat="server" Width="296px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPassword"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="296px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPassword"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <%--<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtNewPassword"
                                        WatermarkText="At least 12 characters" WatermarkCssClass="wc">
                                    </cc1:TextBoxWatermarkExtender>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Confirm Password"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="296px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmPassword"
                                    Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label17" ForeColor="White" runat="server" Text="Password should be at least 12 characters." Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnUpdate" runat="server" Height="22px" Style="cursor: hand;" Text="Update"
                                    Width="64px" OnClick="btnUpdate_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server"  CssClass="standardlabel"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </center>
    </div>
    <asp:HiddenField ID="hid_empAutoId" runat="server" />
    <asp:HiddenField ID="hid_oldPassword" runat="server" />
    <asp:HiddenField ID="hid_companyAutoId" runat="server" />
    </form>
</body>
</html>
