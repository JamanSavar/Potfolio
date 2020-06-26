<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master"
    AutoEventWireup="true" CodeFile="frm_CreateUser1stTime.aspx.cs" Inherits="HumanResource_Common_frm_CreateUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 114px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div id="mainDivision" runat="server" style="top: 0px; height: 250px; left: 0px;
        width: auto;">
        <div id="divTopLeft" style="margin: 0px; padding: 0px; float: left; height: 250px;
            width: 480px;">
            <fieldset style="margin: 0px; padding: 3px; float: left; width: 480px; height: 250px;">
                <legend style="margin: 0px; padding: 0px;">Create User</legend>
                <table id="tbl_createUser" runat="server">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txt_emp_filter" runat="server" OnTextChanged="txt_emp_filter_TextChanged"
                                AutoPostBack="True" Width="230px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txt_emp_filter_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txt_emp_filter" WatermarkCssClass="wc" WatermarkText="Search">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Eployee" runat="server" Text="Employee :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_EmployeeName" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_User_Name" runat="server" Text="User Name :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_userName" runat="server" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdv_txt_User_Name" runat="server" ControlToValidate="txt_userName"
                                ErrorMessage="*" SetFocusOnError="True" Text="*">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_OldPassword" runat="server" Text="Old Password :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_PreviousPassword" runat="server" TextMode="Password" Width="230px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Password" runat="server" Text="Password :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdv_Password" runat="server" ControlToValidate="txt_Password"
                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" Enabled="False">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Confirm_Password" runat="server" Text="Confirm Password :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Confirm_Password" runat="server" TextMode="Password" Width="230px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdv_rePassword" runat="server" ErrorMessage="*" ControlToValidate="txt_Confirm_Password"
                                Display="Dynamic" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txt_Password"
                                ControlToValidate="txt_Confirm_Password" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                EnableTheming="False" EnableViewState="False" Enabled="False"></asp:CompareValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Inactive" runat="server" Text="Active :"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chk_Active" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Inactive0" runat="server" Text="User Status:"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rbl_userStatus" runat="server" BorderColor="#E0E3E7" BorderWidth="1px"
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="Ad">Company Admin</asp:ListItem>
                                <asp:ListItem Value="Sa">System Admin</asp:ListItem>
                                <asp:ListItem Value="Ge" Selected="True">General User</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="style1">
                        </td>
                        <td>
                            <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="standardButton" OnClick="btn_save_Click" />
                            <asp:Button ID="btn_remove" runat="server" Text="Remove" CssClass="standardButton"
                                CausesValidation="False" OnClick="btn_remove_Click" />
                            <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CssClass="standardButton"
                                CausesValidation="False" OnClick="btn_refresh_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table style="width: auto;">
                    <tr>
                        <td>
                            <asp:Label ID="lbl_msg" runat="server" ForeColor="#FF3300" Font-Bold="True" Font-Size="Small"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
    <div id="div_middle" style="height: 5px; width: 480px; top: 0px; left: 0px;">
    </div>
    <div id="div_Bottom" style="top: 5px; left: 0px; margin: 0px; padding-top: 5px; width: auto;
        height: 230px">
        <div id="divBottomLeft" style="float: left; left: 0px; margin: 0px; padding: 0px;
            width: 480px; height: 230px;">
            <fieldset style="margin: 0px; padding: 3px; float: left; width: 480px; height: 230px;">
                <legend style="margin: 0px; padding: 0px;">Employee Information</legend>
                <div style="margin: 0px; padding: 0px; overflow: scroll; height: 210px; width: 478px;">
                    <asp:GridView ID="gdv_employeeName" runat="server" CellPadding="4" Width="455px"
                        AutoGenerateColumns="False" OnRowDataBound="gdv_employeeName_RowDataBound"
                        OnSelectedIndexChanged="gdv_employeeName_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="true" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle CssClass="hidGridColumn" HorizontalAlign="Center" VerticalAlign="Middle">
                                </ItemStyle>
                            </asp:CommandField>
                            <asp:BoundField HeaderText="Emp AutoId" DataField="Emp_AutoId" HeaderStyle-CssClass="hidGridColumn"
                                ItemStyle-CssClass="hidGridColumn">
                                <HeaderStyle CssClass="hidGridColumn" HorizontalAlign="Left" VerticalAlign="Middle">
                                </HeaderStyle>
                                <ItemStyle CssClass="hidGridColumn" HorizontalAlign="Left" VerticalAlign="Middle">
                                </ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="LogIn AutoId" DataField="Log_AutoId" HeaderStyle-CssClass="hidGridColumn"
                                ItemStyle-CssClass="hidGridColumn">
                                <HeaderStyle CssClass="hidGridColumn" HorizontalAlign="Left" VerticalAlign="Middle">
                                </HeaderStyle>
                                <ItemStyle CssClass="hidGridColumn" HorizontalAlign="Left" VerticalAlign="Middle">
                                </ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="User Name" DataField="userName" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                            <asp:BoundField DataField="autoId" HeaderText="autoId">
                                <HeaderStyle CssClass="hidGridColumn" />
                                <ItemStyle CssClass="hidGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="empName" HeaderText="Employee Name" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left" />
                        </Columns>
                    </asp:GridView>
                </div>
            </fieldset>
        </div>
        <div>
            <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
            <asp:HiddenField ID="hid_employee_AutoId" runat="server" Value="True" />
            <asp:HiddenField ID="hid_LogIn_AutoId" runat="server" Value="True" />
        </div>
    </div>
</asp:Content>
