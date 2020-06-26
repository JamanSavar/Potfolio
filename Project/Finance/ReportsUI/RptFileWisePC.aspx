<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="RptFileWisePC.aspx.cs" Inherits="Finance_ReportsUI_RptFileWisePC" Title="File Wise PC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
    

<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" Runat="Server">

 <div style="background-color: Gray; border: 1px solid #C0C0C0;">
        <center>
            <div style="width: 50%;background-color: #2f2f2f; color: White; border: 1px solid Gray;">
                <div style="width: 85%;border: 1px solid #C0C0C0; background-color: #2f2f2f;
                    color: White;">                  
                    <p id="P1" runat="server" class="headerstyle">
                         &nbsp;</p>
                        <p id="P_Header_Leavel" runat="server" class="headerstyle">
                           PC INFO DETAILS</p>
                    <table style="background-color: #2f2f2f; color: White; padding: 0px; width: 100%;
                        text-align: left;">
                                <colgroup>
                                    <col width="30%" />
                                    <col width="70%" />
                                </colgroup>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                         <tr>
                            <td style="text-align:right;">
                                <asp:Label ID="Label4" runat="server" Text="Buyer :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dd_Buyer" runat="server"  onselectedindexchanged="dd_Buyer_SelectedIndexChanged"  AutoPostBack="true" Width="70%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                </asp:DropDownList>
                               
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right;">
                                <asp:Label ID="Label2" runat="server" Text="File No :"></asp:Label>
                            </td>
                            <td>
                                   
                                     <asp:DropDownList ID="dd_FileNo" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="70%" onselectedindexchanged="dd_FileNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                                <td style="text-align:right;">
                                   
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="Master LC No :"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="dd_LC" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="70%" >
                                    </asp:DropDownList> 
                                </td>
                                
                            </tr>
                        <tr>
                            <td style="text-align:right;">
                                <asp:Label ID="Label5" runat="server" Text="PC No :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dd_PCNO" runat="server"  Width="300px" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                </asp:DropDownList>
                               
                            </td>
                        </tr> 
                            
                        <tr>
                        <td style="text-align: right;">
                                <asp:Label ID="Label1"  runat="server" Text="From Date :"></asp:Label>
                            
                            </td>
                            <td >
                            <asp:TextBox ID="txt_fromDate" runat="server" Width="100px"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="txt_fromDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_fromDate">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="txt_fromDate_CalendarExtender" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupButtonID="calaenderImage1" PopupPosition="TopLeft" TargetControlID="txt_fromDate">
                                </cc1:CalendarExtender>
                                <asp:Image ID="calaenderImage1" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                    Height="16px" ImageAlign="AbsMiddle" /><cc1:MaskedEditValidator ID="MaskedEditValidator1"
                                        runat="server" ControlExtender="txt_fromDate_MaskedEditExtender" ControlToValidate="txt_fromDate"
                                        Display="Dynamic" ErrorMessage="*" InvalidValueMessage="*" SetFocusOnError="True"
                                        TooltipMessage="Enter a Valid Date"></cc1:MaskedEditValidator>
                            </td>
                                        
                        </tr>
                        <tr>
                        <td style="text-align:right;">
                            <asp:Label ID="Label3" runat="server" Text="To Date :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_toDate" runat="server" Width="100px"></asp:TextBox>
                                <asp:Image ID="calaenderImage" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                    ImageAlign="AbsMiddle" /><cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                        ControlExtender="txt_toDate_MaskedEditExtender" ControlToValidate="txt_toDate"
                                        Display="Dynamic" ErrorMessage="*" InvalidValueMessage="*" SetFocusOnError="True"
                                        TooltipMessage="Enter a Valid Date"></cc1:MaskedEditValidator>
                                <cc1:MaskedEditExtender ID="txt_toDate_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_toDate">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="txt_toDate_CalendarExtender" runat="server" Enabled="True"
                                    Format="dd/MM/yyyy" PopupButtonID="calaenderImage" PopupPosition="TopLeft" TargetControlID="txt_toDate">
                                </cc1:CalendarExtender>
                                &nbsp;&nbsp;&nbsp;
                                 <asp:CheckBox ID="chkDate" runat="server"  AutoPostBack="True" 
                                    Text="Date Wise"  Font-Bold="true" />
                                
                            </td>
                        </tr>
                         <tr>
                                <td style=" text-align:right;">
                                   
                                </td>
                                    <td>
                                      <asp:CheckBox ID="chkPending" runat="server" Text="PC Pending" Font-Bold="true" /> 
                                </td>
                            </tr>
                         
                        <tr>
                            <td style=" text-align:right;">
                               
                            </td>
                              <td>
                                  <asp:CheckBox ID="chkTaken" runat="server" Text="PC Taken" Font-Bold="true" /> 
                                </td>
                            </tr>
                        <tr>
                            <td style=" text-align:right;">
                               
                            </td>
                              <td>
                                  <asp:CheckBox ID="chkPCWise" runat="server" Text="PC Wise Approval" Font-Bold="true" /> 
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align:right;">
                                   
                                </td>
                                    <td>
                                      <asp:CheckBox ID="chkAdjust"  runat="server"   Text="PC Adjust Summary" Font-Bold="true" /> 
                                </td>
                            </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="lbl_msg" runat="server" CssClass="standardlabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btn_Preview" runat="server" CausesValidation="false" CssClass="standardButton"  Width="120" Font-Bold="true"
                                    Text="Preview" OnClick="btn_Preview_Click" />
                                <asp:Button ID="btn_refresh" runat="server" CausesValidation="false" CssClass="standardButton"  Width="120" Font-Bold="true"
                                    Text="Refresh"  />
                             
                            </td>
                        </tr>
                    </table>
                </div>
                
            </div>
        </center>
         <asp:HiddenField ID="hid_BuyerId" runat="server" Value="" />
        <asp:HiddenField ID="hid_LcId" runat="server" Value="" />
        <asp:HiddenField ID="hid_File_Id" runat="server" Value="" />
        <asp:HiddenField ID="hid_PC_Id" runat="server" Value="" />
    </div>
</asp:Content>



