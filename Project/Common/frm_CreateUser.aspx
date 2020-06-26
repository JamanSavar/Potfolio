<%@ Page Title="Manage User" Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master"
    AutoEventWireup="true" CodeFile="frm_CreateUser.aspx.cs" Inherits="HumanResource_Common_frm_CreateUser"
    MaintainScrollPositionOnPostback="true" Buffer="true" EnableSessionState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../Forms/Constants/Javascript/JScript_GridViewSearch.js" type="text/javascript"></script>

    <%--<script type="text/javascript" language="javascript">

        function SearchGridViewInDiv(divId, gridId, indexToSearch, searchForId) {
            var div = document.getElementById(GetClientId(divId));
            var searchControll = document.getElementById(GetClientId(searchForId));
            var divHeight = 0;
            var searchColumns = "";
            var searchColumn = "";
            var searchText = "";
            var foundText = "";
            var matchedRowNumber = 0;
            var scrollTopHeight = 0;
            var gridRowHeight = "0px";
            if (div != null) {
                divHeight = div.style.height;
                var gridView = document.getElementById(GetClientId(gridId));
                if (gridView != null) {
                    var gridRows = gridView.getElementsByTagName("TR");
                    if (gridRows != null) {
                        if (gridRows.length > 1) {
                            if (searchControll != null) {
                                searchFor = searchControll.value;
                            }
                            for (count = 1; count < gridRows.length; count++) {
                                searchColumns = gridRows[count].getElementsByTagName("TD");
                                if (searchColumns != null) {
                                    searchColumn = searchColumns[indexToSearch];
                                    searchText = searchColumn.innerHTML;
                                    if (searchFor != "") {
                                        searchFor = searchFor.replace(/[^a-zA-Z 0-9]+/g, '').toUpperCase();
                                        searchText = searchText.replace(/[^a-zA-Z 0-9]+/g, '').toUpperCase();
                                        if (searchText.indexOf(searchFor) == -1) {

                                        }
                                        else {
                                            matchedRowNumber = count;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (matchedRowNumber != 0) {
                                gridRowHeight = gridRows[gridRows.length - 1].style.height;
                                gridRowHeight = gridRowHeight.replace("px", "");
                                gridRows[matchedRowNumber].style.backgroundColor = "Tomato";
                                scrollTopHeight = parseInt(gridRowHeight) * matchedRowNumber;
                                div.scrollTop = parseInt(scrollTopHeight);
                            }
                        }
                    }
                }
            }
     
        }
  </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div id="mainDivision" runat="server" style="height: 500px; background-color: Gray;
        border: 1px solid #C0C0C0;">
        <center>
            <div style="width: 60%; height: 500px; background-color: #969696; border: 1px solid #C0C0C0;">
                <div id="divTopLeft" style="width: 85%; height: 52%; background-color: #2F2F2F; color: White;
                    border: 1px solid #C0C0C0;">
                    <p id="p_createUser" class="headerstyle" style="text-align: left; float: left; clear: left;
                        padding: 0px 0px 0px 0px;" runat="server">
                    </p>
                    <table id="tbl_createUser" style="text-align: left; float: left; clear: left; padding: 20px 0px 0px 0px;"
                        runat="server">
                        <tr>
                            <td>
                            </td>
                            <td>
                                Employe Name
                            </td>
                            <td>
                                <asp:TextBox ID="txt_emp_filter" runat="server" OnTextChanged="txt_emp_filter_TextChanged"
                                    AutoPostBack="True" Width="300px"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txt_emp_filter_TextBoxWatermarkExtender" runat="server"
                                    Enabled="True" TargetControlID="txt_emp_filter" WatermarkCssClass="wc" WatermarkText="Search">
                                </cc1:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_Eployee" runat="server" Text="Employee :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dd_EmployeeName" runat="server" Width="304px" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="dd_EmployeeName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_User_Name" runat="server" Text="User Name :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_userName" runat="server" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rdv_txt_User_Name" runat="server" ControlToValidate="txt_userName"
                                    ErrorMessage="*" SetFocusOnError="True" Text="*">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_OldPassword" runat="server" Text="Old Password :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_PreviousPassword" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_Password" runat="server" Text="Password :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rdv_Password" runat="server" ControlToValidate="txt_Password"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" Enabled="False">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_Confirm_Password" runat="server" Text="Confirm Password :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_Confirm_Password" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rdv_rePassword" runat="server" ErrorMessage="*" ControlToValidate="txt_Confirm_Password"
                                    Display="Dynamic" SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txt_Password"
                                    ControlToValidate="txt_Confirm_Password" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"
                                    EnableTheming="False" EnableViewState="False" Enabled="False"></asp:CompareValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lbl_Inactive" runat="server" Text="Active :"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="chk_Active" runat="server" />
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="standardButton" OnClick="btn_save_Click" />
                                <asp:Button ID="btn_remove" runat="server" Text="Remove" CssClass="standardButton"
                                    CausesValidation="False" OnClick="btn_remove_Click" />
                                <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CssClass="standardButton"
                                    CausesValidation="False" OnClick="btn_refresh_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lbl_msg" runat="server" CssClass="standardlabel"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <%--                <div id="div_middle" style="height: 5px; width: 520px; top: 0px; left: 0px;">
                </div>--%>
                <div id="divBottomLeft" style="width: 85%; height: 48%; background-color: #2F2F2F;
                    color: White; border: 1px solid #C0C0C0;">
                    <p id="p_employeeInformation" class="headerstyle" style="text-align: left; padding: 0px 0px 5px 0px;"
                        runat="server">
                    </p>
                    <div style="height: 10%; width: 100%; background-color: Gray; clear: both; text-align: left;">
                        <input type="text" id="txt_gridViewSearch" style="width: 85%;" runat="server" />
                        <input type="button" class="standardButton" value="Search" onclick="SearchGridViewInDiv('div_employeeName','gdv_employeeName',5,'txt_gridViewSearch')" />
                        <%--<asp:Button runat="server" ID="btn_gridRefresh" Text="Refresh" />--%>
                    </div>
                    <div style="margin: 0px; padding: 0px; overflow: scroll; height: 185px; width: 100%;"
                        runat="server" id="div_employeeName">
                        <asp:GridView ID="gdv_employeeName" Style="float: left; clear: left;" runat="server"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            SelectedRowStyle-CssClass="gridViewSelectedRowStyle" CssClass="gridViewStyle"
                            AutoGenerateColumns="False" OnRowDataBound="gdv_employeeName_RowDataBound" RowStyle-Height="15px"
                            OnSelectedIndexChanged="gdv_employeeName_SelectedIndexChanged" Width="100%">
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
                </div>
            </div>
        </center>
    </div>
    <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
    <asp:HiddenField ID="hid_employee_AutoId" runat="server" Value="True" />
    <asp:HiddenField ID="hid_LogIn_AutoId" runat="server" Value="True" />
</asp:Content>
