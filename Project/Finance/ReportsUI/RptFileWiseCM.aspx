<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="RptFileWiseCM.aspx.cs" Inherits="Finance_ReportsUI_RptFileWiseCM" Title="CM Loan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
    <style type="text/css">
        .style1
        {
            height: 22px;
        }
    </style>
   
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
                           CM Loan Details</p>
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
                                <asp:DropDownList ID="dd_Buyer" runat="server"  AutoPostBack="true" Width="80%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                </asp:DropDownList>
                               
                            </td>
                        </tr>
                        <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="File No :"></asp:Label>
                                </td>
                                <td>
                                   
                                     <asp:DropDownList ID="dd_FileNo" runat="server"  Width="80%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                     </asp:DropDownList>
                                
                                </td>
                        </tr>
                         <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label1" runat="server" Text="FDBC No :"></asp:Label>
                                </td>
                                <td>
                                   
                                     <asp:DropDownList ID="dd_RealizationId" runat="server"  Width="80%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                     </asp:DropDownList>
                                
                                </td>
                        </tr>
                       
                             <tr>
                                <td style=" text-align:right;" class="style1">
                                   
                                </td>
                                    <td class="style1">
                                      <asp:CheckBox ID="chkPendingFDBP" runat="server" Text="FDBP Pending" Font-Bold="true" /> 
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td style=" text-align:right;">
                                   
                                </td>
                                    <td>
                                      <asp:CheckBox ID="chkFDBP" runat="server"   Text="FDBP Summary" Font-Bold="true" /> 
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
        <asp:HiddenField ID="hid_FileId" runat="server" Value="" />
        <asp:HiddenField ID="hid_RealizationId" runat="server" Value="" />
        <asp:HiddenField ID="hid_PC_Id" runat="server" Value="" />
    </div>
</asp:Content>



