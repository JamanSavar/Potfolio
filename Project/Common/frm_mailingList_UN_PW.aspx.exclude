<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master"
    AutoEventWireup="true" CodeFile="frm_mailingList_UN_PW.aspx.cs" Inherits="HumanResource_TopicEvents_frm_mailingList_voting" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../../Forms/Constants/Javascript/JScript_GridViewSearch.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function divScrool(id,step)
        {
            document.getElementById(GetClientId(id)).scrollTop = step;
        }

        //    function SearchGridViewInDiv(divId, gridId, indexToSearch, searchForId) {
        //        var div = document.getElementById(GetClientId(divId));
        //        var searchControll = document.getElementById(GetClientId(searchForId));
        //        var divHeight = 0;
        //        var searchColumns = "";
        //        var searchColumn = "";
        //        var searchText = "";
        //        var foundText = "";
        //        var matchedRowNumber = 0;
        //        var scrollTopHeight = 0;
        //        var gridRowHeight = "0px";
        //        if (div != null) {
        //            divHeight = div.style.height;
        //            var gridView = document.getElementById(GetClientId(gridId));
        //            if (gridView != null) {
        //                var gridRows = gridView.getElementsByTagName("TR");
        //                if (gridRows != null) {
        //                    if (gridRows.length > 1) {
        //                        if (searchControll != null) {
        //                            searchFor = searchControll.value;
        //                        }
        //                        for (count = 1; count < gridRows.length; count++) {
        //                            searchColumns = gridRows[count].getElementsByTagName("TD");
        //                            if (searchColumns != null) {
        //                                searchColumn = searchColumns[indexToSearch];
        //                                searchText = searchColumn.innerHTML;
        //                                if (searchFor != "") {
        //                                    searchFor = searchFor.replace(/[^a-zA-Z 0-9]+/g, '').toUpperCase();
        //                                    searchText = searchText.replace(/[^a-zA-Z 0-9]+/g, '').toUpperCase();
        //                                    if (searchText.indexOf(searchFor) == -1) {

        //                                    }
        //                                    else {
        //                                        matchedRowNumber = count;
        //                                        break;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        if (matchedRowNumber != 0) {
        //                            gridRowHeight = gridRows[gridRows.length - 1].style.height;
        //                            gridRowHeight = gridRowHeight.replace("px", "");
        //                            gridRows[matchedRowNumber].style.backgroundColor = "Tomato";
        //                            scrollTopHeight = parseInt(gridRowHeight) * matchedRowNumber;
        //                            div.scrollTop = parseInt(scrollTopHeight);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
    </script>

    <style type="text/css">
        .panel_options
        {
            width: 180px;
            height: auto;
        }
        .newStyle1
        {
            border-width: thin;
            border-style: solid;
        }
        .radioList
        {
            float: left;
            top: 0px;
            padding: 0px;
            margin: 0px;
        }
        .buttonAddCss
        {
            width: 61px;
            width: 55px\9;
            text-align: center;
            vertical-align: middle;
            margin: 100px 5px 0px 10px;
        }
        .buttonRemoveCss
        {
            width: 61px;
            width: 55px\9;
            text-align: center;
            vertical-align: middle;
            margin: 5px 5px 0px 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div style="height: 780px;">
        <div style="height: 42%;">
            <div style="float: left; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;
                height: 97%;">
                <p class="headerstyle">
                    Send Email To User (User ID - Password)
                </p>
                <table width="100%" cellpadding="2" cellspacing="2" style="text-align: left;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            Employee Name
                        </td>
                        <td>
                            <asp:TextBox ID="txt_employeeFilter" runat="server" OnTextChanged="txt_employeeFilter_TextChanged"
                                AutoPostBack="True" Width="296px">
                            </asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txt_employeeFilter_TextBoxWatermarkExtender" runat="server"
                                Enabled="True" TargetControlID="txt_employeeFilter" WatermarkCssClass="wc" WatermarkText="Search">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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
                            <asp:Label ID="lbl_Employee" runat="server" Text="Employee "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_Employee" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_PIN" runat="server" Text="PIN "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_PIN" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Company" runat="server" Text="Company "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_Company" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_CardID" runat="server" Text="Card ID "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_CardID" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Religion" runat="server" Text="Religion "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_Religion" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_BloodGroup" runat="server" Text="Blood Group "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_BloodGroup" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Gender" runat="server" Text="Gender "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_Gender" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_Nationality" runat="server" Text="Nationality "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_Nationality" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_NationalID" runat="server" Text="National ID "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_NationalID" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_PlaceOfBirth" runat="server" Text="Place Of Birth "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_PlaceOfBirth" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_MaritalStatus" runat="server" Text="Marital Status "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_MaritalStatus" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_TIN" runat="server" Text="TIN "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_TIN" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_DrivingLicense" runat="server" Text="Driving License "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_DrivingLicense" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_PassportNo" runat="server" Text="Passport No "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="dd_PassportNo" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_DOB" runat="server" Text="Date of Birth "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_DOB_Start" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdv_DOB_Star" runat="server" ControlToValidate="txt_DOB_Start"
                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="gdv_one"
                                Text="*">* 
                            </asp:RequiredFieldValidator>
                            <cc1:MaskedEditExtender ID="txt_DOB_Start_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" TargetControlID="txt_DOB_Start" Mask="99/99/9999" CultureName="fr-FR"
                                MaskType="Date" MessageValidatorTip="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="txt_DOB_Start_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txt_DOB_Start" Format="dd/MM/yyyy" PopupButtonID="calendarImage0">
                            </cc1:CalendarExtender>
                            <asp:Image ID="calendarImage0" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                AlternateText="Click to show calendar" />
                            &nbsp;&nbsp;To&nbsp;&nbsp;
                            <asp:TextBox ID="txt_DOB_End" runat="server" Width="90px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rdv_DOB_End" runat="server" ControlToValidate="txt_DOB_End"
                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="gdv_one"
                                Text="*">* 
                            </asp:RequiredFieldValidator>
                            <asp:Image ID="calendarImage1" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                AlternateText="Click to show calendar" />
                            <cc1:MaskedEditExtender ID="txt_DOB_End_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" TargetControlID="txt_DOB_End" Mask="99/99/9999" CultureName="fr-FR"
                                MaskType="Date">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="txt_DOB_End_CalendarExtender" runat="server" Enabled="True"
                                TargetControlID="txt_DOB_End" Format="dd/MM/yyyy" PopupButtonID="calendarImage1">
                            </cc1:CalendarExtender>
                            &nbsp;<asp:CheckBox ID="chk_DOB_Status" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Designation "></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="dd_designation" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_AgeBetween" runat="server" Text="Age Between "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_AgeBetween_Start" runat="server" Width="100px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;To&nbsp;&nbsp;
                            <asp:TextBox ID="txt_AgeBetween_End" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chk_Age_Status" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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
                            &nbsp;
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click"
                                CssClass="standardButton" />
                            <%--<asp:Button ID="btn_searchGrid" runat="server" Text="Search Grid" OnClientClick="divScrool(100)" CssClass="standardButton"/>--%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="height: 35%;">
            <div style="text-align: left; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;
                height: 97%;">
                <p class="headerstyle">
                    Select Employee to Send Email
                </p>
                <div style="width: 100%; height: 90%; float: left; margin-left: 10px;">
                    <div style="height: 10%; width: 100%;">
                        <input type="text" id="txt_gridViewSearch" style="width: 39.7%;" runat="server" />
                        <input type="button" class="standardButton" value="Search" onclick="SearchGridViewInDiv('div_allEmpMailingList','gdv_allEmpMailingList',4,'txt_gridViewSearch')" />
                    </div>
                    <div style="height: 90%; width: 100%;">
                        <div runat="server" id="div_allEmpMailingList" style="height: 100%; width: 45%; overflow: scroll;
                            float: left; border: 1px solid #C0C0C0;">
                            <asp:GridView ID="gdv_allEmpMailingList" runat="server" AutoGenerateColumns="False"
                                HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                                SelectedRowStyle-CssClass="gridViewSelectedRowStyle" CssClass="gridViewStyle">
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="15px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_all" runat="server" AutoPostBack="True" OnCheckedChanged="chk_all_MailList_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_employee" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="empAutoId" HeaderText="Employee AutoId" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="PIN" HeaderText="PIN" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="Card_ID" HeaderText="Card ID" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="empName" HeaderText="Employee Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70%"></asp:BoundField>
                                    <asp:BoundField DataField="PresentEmailAddress" HeaderText="Present Email" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%"></asp:BoundField>
                                    <asp:BoundField DataField="EmergencyEmailAddress" HeaderText="Emergency Email" HeaderStyle-CssClass="hidGridColumn"
                                        ItemStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="designation" HeaderText="Designation" HeaderStyle-CssClass="hidGridColumn"
                                        ItemStyle-CssClass="hidGridColumn"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div style="top: 0px; left: 0px; padding: 0px; margin: 0px; float: left; width: 8%;
                            height: 100%; text-align: center;">
                            <asp:Button ID="btn_Add" CssClass="buttonAddCss" runat="server" Text="Add>>" OnClick="btn_Add_Click" />
                            <asp:Button ID="btn_remove" CssClass="buttonRemoveCss" runat="server" Text="Remove"
                                OnClick="btn_remove_Click" Visible="False" />
                        </div>
                        <div style="height: 100%; width: 45%; overflow: scroll; text-align: right; float: left;
                            border: 1px solid #C0C0C0;">
                            <asp:GridView ID="gdv_selectedList" runat="server" AutoGenerateColumns="False" HeaderStyle-CssClass="gridViewHeaderStyle"
                                AlternatingRowStyle-CssClass="gridViewAlternateRowStyle" SelectedRowStyle-CssClass="gridViewSelectedRowStyle"
                                CssClass="gridViewStyle" OnRowDeleting="gdv_selectedList_RowDeleting">
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100%" />
                                <Columns>
                                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Select" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chk_all" runat="server" AutoPostBack="True" OnCheckedChanged="chk_all_MailList_Select_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_employee" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                        <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="empAutoId" HeaderText="Employee AutoId" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="PIN" HeaderText="PIN" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="Card_ID" HeaderText="Card ID" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="empName" HeaderText="Employee Name" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="250"></asp:BoundField>
                                    <asp:BoundField DataField="PresentEmailAddress" HeaderText="Present Email" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left"></asp:BoundField>
                                    <asp:BoundField DataField="EmergencyEmailAddress" HeaderText="Emergency Email" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                    <asp:BoundField DataField="designation" HeaderText="Designation" ItemStyle-CssClass="hidGridColumn"
                                        HeaderStyle-CssClass="hidGridColumn"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="height: 23%;">
            <div style="width: 100%; background-color: #2f2f2f; color: White; float: left; height: 100%;">
                <p class="headerstyle">
                    Send Email
                </p>
                <div style="margin: 0px; padding: 0px; top: 0px; left: 0px; float: left; height: auto;
                    width: auto;">
                    <div style="width: 100%; height: auto; text-align: center;">
                        <div style="width: 100%; text-align: center;">
                            <table id="tbl_letterSearch" runat="server" style="text-align: left;">
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <table id="tbl1" runat="server" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_topicsName" runat="server" Text="Topics Name :"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dd_topicsName" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rdv_topicsName" runat="server" ControlToValidate="dd_topicsName"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="gdv_one"
                                            Text="*" Enabled="False"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chk_applyChangePwd" runat="server" Text="Apply change password"
                                            ForeColor="#66CCFF" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_subject" runat="server" Text="Subject "></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSubject" runat="server" Width="397px"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender WatermarkCssClass="wc" WatermarkText="Letter Subject"
                                            ID="txtSubject_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtSubject">
                                        </cc1:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_Email_Description" runat="server" Text="Email Description" Style="text-align: justify;
                                            padding: 0px 0px 0px 0px;">
                                        </asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMailDescrioption" runat="server" TextMode="MultiLine" Width="399px"
                                            Height="31px"></asp:TextBox>
                                        <cc1:TextBoxWatermarkExtender ID="TextBox1_TextBoxWatermarkExtender" runat="server"
                                            Enabled="True" WatermarkCssClass="wc" WatermarkText="Email Description" TargetControlID="txtMailDescrioption">
                                        </cc1:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="height: 22px; width: 200px; overflow: auto;">
                            <asp:Label ID="lbl_message" runat="server" CssClass="standardlabel"></asp:Label>
                        </div>
                        <br />
                        <asp:Button ID="btn_save" runat="server" OnClick="btn_save_Click" Text="Send" CssClass="standardButton"
                            ValidationGroup="gdv_one" />
                        <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CssClass="standardButton"
                            OnClick="btn_refresh_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_LetterIssueForVoting_AutoId" runat="server" Value="True" />
        <asp:HiddenField ID="hid_acknowledgementEmployee_AutoId" runat="server" Value="True" />
        <asp:HiddenField ID="hid_empAutoId" runat="server" />
    </div>
</asp:Content>
