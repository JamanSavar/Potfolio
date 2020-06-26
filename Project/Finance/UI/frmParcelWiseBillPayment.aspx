<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmParcelWiseBillPayment.aspx.cs" Inherits="Finance_UI_frmParcelWiseBillPayment" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    </asp:Content>

 <asp:Content ID="Personal_content" ContentPlaceHolderID="mainContent" runat="Server">


<div id="dialog" style="display: none">
</div>
    <div style="background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">
        <center>
            <div style="width: 90%;background-color: #969696; border: 1px solid #C0C0C0; clear:both;">
                <div style="width: 85%; clear:both;">
                    <div style="width: 100%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style="padding-top: 7px;  text-align:right; color:Maroon;">
                            Parcel Wise Bill Payment
                        </p>
                    </div>                    
                </div>
                
                <div style="width: 85%; height: 1%; clear:both;">
                </div>
                
                
                <div style="width: 90%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">
                
                
                
                
                
                
                
                
                    <div style="width: 100%;float: left;">
                        <div style="width: 50%; margin: 0 auto;">
                        <table style="text-align: left;  float: left; padding-top: 10px; padding-bottom: 10px;">
                            
                             <tr>
                              <td colspan="2" style=" text-align:center; border: 1px solid; font-size:14px; font-weight:bold;">

                                Searching Parcel Info
                                </td>
                                
                             </tr>
                             
                             
                            <tr>
                              <td style="text-align:right;">      
                                    <asp:Label ID="Label5" runat="server" Text="Courrier Name :"></asp:Label>
                                </td>
                                <td> 
                                    <asp:DropDownList ID="dd_CorrierName" runat="server" Width="253px" AutoPostBack="true"  onfocus="this.style.backgroundColor='#ffff80'"  onblur="this.style.backgroundColor='white'">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                                                       
                           <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label25" runat="server" Text="Courrier No :"></asp:Label>
                                </td>
                                <td> 
                                     <asp:TextBox ID="txt_SearchCourrier" runat="server" Width="250px"  onfocus="this.style.backgroundColor='#ffff80'"  onblur="this.style.backgroundColor='white'"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label1" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td> 
                                
                                <asp:TextBox ID="txtFromDate" runat="server" Width="100px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtFromDate">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_FromDate"
                                        PopupPosition="TopLeft" TargetControlID="txtFromDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_FromDate" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png" Height="16px" ImageAlign="AbsMiddle" />
                                           
                                </td>
                            </tr>  
                            <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label7" runat="server" Text="To Date :"></asp:Label>
                                </td>
                                <td> 
                                
                                <asp:TextBox ID="txtToDate" runat="server" Width="100px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtToDate">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_ToDate"
                                        PopupPosition="TopLeft" TargetControlID="txtToDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_ToDate" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png" Height="16px" ImageAlign="AbsMiddle" />
                                </td>
                            </tr> 
                              
                             
                                   
                             <tr>
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
                                <asp:Button ID="btn_Search" runat="server" CssClass="standardButton"  Text="Search" onclick="btn_Search_Click"  />
                                </td>
                            </tr>
                              
                        </table>
                        </div> 
                                      
                    </div>
                    
                        
                   
                                                              
                    <div style="overflow: scroll; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;
                        height: 200px; width: 100%; margin-top: 15px; margin-bottom: 5px;">
                        <asp:GridView ID="gdv_Item" runat="server" 
                            Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle" CssClass="gridViewStyle">
                             <RowStyle HorizontalAlign="Center" />
                              <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                
                                <%-- GrideView Colom no/1--%>
                                <asp:BoundField DataField="ReceiveFromId" HeaderText="ReceiveFromId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <%-- GrideView Colom no/2--%>
                                <asp:BoundField DataField="FromName" HeaderText="Parcel From">
                                </asp:BoundField>
                                
                                <%-- GrideView Colom no/3--%>
                                <asp:BoundField DataField="CourrierAutoId" HeaderText="CourrierAutoId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                 <%-- GrideView Colom no/4--%>
                                <asp:BoundField DataField="Courrier" HeaderText="Courrier Name">
                                </asp:BoundField>
                                
                                 <%-- GrideView Colom no/5--%>
                                <asp:BoundField DataField="ParcelNo" HeaderText="Courrier No">
                                </asp:BoundField>
                                
                               
                                
                                <%-- GrideView Colom no/7--%>
                                <asp:BoundField DataField="Remarks" HeaderText="Status">
                                </asp:BoundField>
                                
                                <%-- GrideView Colom no/7--%>
                                <asp:BoundField DataField="trAmount" HeaderText="Amount">
                                </asp:BoundField>
                                
                                
                                <%-- GrideView Colom no/8--%>
                                <asp:BoundField DataField="trDate" DataFormatString="{0:d}" HeaderText="Date">
                                </asp:BoundField>
                                
                                <%-- GrideView Colom no/9--%>
                                <asp:BoundField DataField="JournalAutoId" HeaderText="JournalAutoId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <%-- GrideView Colom no/10--%>
                                <asp:BoundField DataField="ReceiveFromId" HeaderText="ReceiveFromId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <%-- GrideView Colom no/11--%>
                                <asp:BoundField DataField="parcelAutoId" HeaderText="parcelAutoId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                            </Columns>
                                <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                            </asp:GridView>
                    </div>                  
                        
                        
                         <div style="width: 95%; height: 1%; clear:both;">
                    </div>
                    
                   <div style="width: 100%; text-align: center; display:inline block;">
                   
                        <table style="text-align: left; width:50%; padding-top: 20px; margin:0 auto;">
                            
                           <tr>
                                <td style="width: 100px; text-align:right;">
                                    <asp:Label ID="Label9" runat="server" Text="Entry Date :"></asp:Label>
                                </td>
                                  <td>
                                    <asp:TextBox ID="txtIssueDate" ReadOnly="true" runat="server" Width="100px" onfocus="this.style.backgroundColor='#ffff80'"  onblur="this.style.backgroundColor='white'"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIssueDate">
                                    </cc1:MaskedEditExtender>
                                   <%-- <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_From"
                                        PopupPosition="TopLeft" TargetControlID="txtIssueDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_From" Visible="false" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                        Height="16px" ImageAlign="AbsMiddle" />--%>
                                   </td>        
                            </tr>          
                           
                             <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label6" runat="server" Text="Input By :"></asp:Label>
                                </td>
                                 <td>
                                 <asp:TextBox ID="txt_InputBy" runat="server" ReadOnly="true" ForeColor="red" Width="250px"  onfocus="this.style.backgroundColor='#ffff80'"  onblur="this.style.backgroundColor='white'"></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                            <tr>
                             <td >&nbsp;</td>
                            <td>
                                 <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                            </td>
                            </tr>
                            
                           <%-- <tr>
                                <td >&nbsp;</td>
                                <td >&nbsp;</td>
                            </tr>--%>
                            
                            <tr>
                            <td></td>
                                <td>
                                    <asp:Button ID="btn_save" runat="server" CssClass="standardButton" Text="Save" />
                                    <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CausesValidation="false"  CssClass="standardButton" />                               
                                    <asp:Button ID="Button4" runat="server" CausesValidation="false" CssClass="standardButton" Text="Delete" />
                                    <asp:Button ID="btn_Preview" runat="server" CausesValidation="false" CssClass="standardButton" Text="Preview"/>
                                </td>
                            </tr>
                               
                        </table>
                       
                    </div>
                    
                    <div style="width: 100%;clear:both;">&nbsp;
                    </div>            
                  
                </div>
            </div>
        </center>
        
        
        <asp:HiddenField ID="HidSenderType" runat="server" Value="" />
         <asp:HiddenField ID="HidReceiveFromId" runat="server" Value="" />
         <asp:HiddenField ID="HidCourrierId" runat="server" Value="" />
         <asp:HiddenField ID="HidParcelNo" runat="server" Value="" />
         <asp:HiddenField ID="HidFromdate" runat="server" Value="" />
         <asp:HiddenField ID="HidTodate" runat="server" Value="" />
         <asp:HiddenField ID="HidDateUse" runat="server" Value="" />

         <asp:HiddenField ID="hid_AutoId" runat="server" Value="0"/> 
         
         
         

    </div>

</asp:Content>
    

