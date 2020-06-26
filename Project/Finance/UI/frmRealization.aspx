<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmRealization.aspx.cs" Inherits="Finance_UI_frmRealization" Title="Realization" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />

  
   <script language="javascript" type="text/javascript" src="../../Forms/Constants/Javascript/SharedValidationFunction.js"></script>
      
      
      <script language="javascript" type="text/javascript"> 
      
        function Calculate() 
                     {
                         var Rate = document.getElementById('<%= txt_Rate.ClientID %>').value;
                         if (Rate == "") { Rate = 0; };
                         
                         var taka = document.getElementById('<%= txt_AmountTK.ClientID %>').value;
                         if (taka == "") { taka = 0; };

                         if (Rate != ""){
                             var doler = parseFloat(taka) / parseFloat(Rate) ;
                         }
                         else{var doler = 0;}; 
                           
                          document.getElementById('<%= txt_AmountDollar.ClientID %>').value = doler.toString();  

                     }
                     
                     
           function CalculateCM() 
                     {
                         var Rate = document.getElementById('<%= txt_FDBP_Rate.ClientID %>').value;
                         if (Rate == "") { Rate = 0; };
                         
                         var taka = document.getElementById('<%= txt_FDBP_Taka.ClientID %>').value;
                         if (taka == "") { taka = 0; };

                         if (Rate != ""){
                             var doler = parseFloat(taka) / parseFloat(Rate) ;
                         }
                         else{var doler = 0;}; 
                           
                          document.getElementById('<%= txt_FDBP_Dolar.ClientID %>').value = doler.toString();  

                     }
    </script>

    </asp:Content>


  
<asp:Content ID="Personal_content" ContentPlaceHolderID="mainContent" runat="Server">
<div id="dialog" style="display: none">
</div>
     <div style="background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">
        <center>
            <div style="width: 100%;background-color: #969696; border: 1px solid #C0C0C0; clear:both;">
                <div style="width: 80%;  clear:both;">
                    <div style="width: 100%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style="padding-top: 7px;  text-align:right; color:Maroon;">
                         Document Collection & Realization
                        </p>
                    </div>                    
                </div>   
                <div style="width: 80%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">                
                
                <div style=" width: 100%;margin:0 auto;">  
                
                  <div style="width: 95%;  border: 1px solid white; background-color: #0b5345; margin-top: 10px;">
                       
                    <div style="width:100%; margin-top: 5px;">
                   
                     <div  style="width:100%; float:left">
                        
                          <table style="text-align: left; width:100%;  padding-bottom:10px; float: left;">
                            <colgroup>
                                <col width="10%"/>
                                <col width="15%"/>
                                <col width="10%"/>
                                <col width="10%"/>
                                <col width="10%"/>
                                <col width="10%"/>
                                <col width="10%"/>
                                <col width="10%"/>
                            </colgroup>
                          <tr >
                                <td style="text-align:right;">
                                    
                                </td>
                                <td>
                                  
                                </td>
                                 <td style="text-align:right;font-weight:bold;">
                                   <asp:Label ID="Label24" runat="server" Text="Search :"></asp:Label>
                                </td>
                                 <td>
                                    <asp:DropDownList ID="dd_Search" runat="server" Width="100%">
                                 </asp:DropDownList>
                                </td>
                                <td>
                                  <asp:Button ID="btn_Search" runat="server" CausesValidation="false" CssClass="buttonCSS"
                                                    Text="Search" Width="70px" Font-Bold="true" ForeColor="Blue" OnClick="btn_Search_Click"/>
                                </td>
                                 <td >
                                    
                                </td>
                                <td>
                                    
                                </td>
                                <td >
                                    
                                </td>
                           </tr>
                            
                            <tr >
                                <td style="text-align:right;">
                                    <asp:Label ID="Label9" runat="server" Text="SL No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_SlNo" runat="server" Width="100px" Font-Bold="true" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                                </td>
                                 <td style="text-align:right;">
                                    <asp:Label ID="lbl_IssueDate" runat="server" Text="FDBC Date :"></asp:Label>
                                </td>
                                 <td>
                                    <asp:TextBox ID="txtIssueDate" runat="server" Width="80px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIssueDate">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_From"
                                        PopupPosition="TopLeft" TargetControlID="txtIssueDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_From" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                        Height="16px" ImageAlign="AbsMiddle" />
                                   </td>
                                <td style=" text-align:right;">
                                 <asp:Label ID="Label27" runat="server" Text="Realized Date :"></asp:Label>
                                </td>
                                <td>
                                <asp:TextBox ID="txt_RealizedDate" runat="server" Width="80px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_RealizedDate">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_Realize"
                                        PopupPosition="TopLeft" TargetControlID="txt_RealizedDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_Realize" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                        Height="16px" ImageAlign="AbsMiddle" />
                                
                                </td>
                                <td style=" text-align:right;">
                                 <asp:Label ID="Label6" runat="server" Text="FDBP Date :"></asp:Label>
                                </td>
                                <td>
                                 <asp:TextBox ID="txt_FDBPDate" runat="server" Width="80px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txt_FDBPDate">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_FDBP"
                                        PopupPosition="TopLeft" TargetControlID="txt_FDBPDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_FDBP" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                        Height="16px" ImageAlign="AbsMiddle" />
                                
                                </td>
                            </tr> 
                             
                             <tr>
                             <td style="text-align:right;">
                                     <asp:Label ID="Label5" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="File Ref. No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_FileNo" runat="server"  AutoPostBack="true" 
                                        Width="100%" onselectedindexchanged="dd_FileNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                             <td style=" text-align:right;">
                                    <asp:Label ID="Label15" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" Text="Collection Type :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_CollectionType" runat="server" Width="81%">
                                        <asp:ListItem Selected="True" Value="0"># Select #</asp:ListItem>
                                        <asp:ListItem>FDBC</asp:ListItem>
                                        <asp:ListItem>LDBC</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                             <td style="text-align:right;">
                                    <asp:Label ID="Label26" runat="server" Text="Bank Name :"></asp:Label>
                                </td>
                                <td >
                                    <asp:DropDownList ID="dd_Bank" AutoPostBack="true"  onselectedindexchanged="dd_Bank_SelectedIndexChanged"  Enabled="false" runat="server" Width="102px">
                                    </asp:DropDownList>
                                </td>
                                 
                                  <td style=" text-align:right;">
                                    <asp:Label ID="Label4" runat="server" Text="FDBP No :" ></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_FDBPNo" runat="server" Width="100px"></asp:TextBox>
                                </td> 
                            </tr> 
                          
                                  
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label23" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_LCNo" runat="server" Text="Export LC No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_LCNo" runat="server"  AutoPostBack="true" 
                                        Width="100%" onselectedindexchanged="dd_LCNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                 <td style=" text-align:right;">
                                    <asp:Label ID="Label14" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl" runat="server" Text="FDBC No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_FDBCNo" runat="server" Width="100px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label18" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="Realized Value :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_RealizedAmount" onkeyup="ShortRealization()" runat="server" Width="100px" Font-Bold="true" ForeColor="Red" ></asp:TextBox>
                                </td>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label30" runat="server" Text="Dolar Rate :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_FDBP_Rate" onkeyup="CalculateCM()" runat="server" Width="100px" Font-Bold="true"  ForeColor="Red"></asp:TextBox>
                                 </td>
                              
                            </tr>      
                            <tr>
                                <td style=" text-align:right;">
                                     <asp:Label ID="Label25" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_InvoiceNo" runat="server" Text="Invoice No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_Invoice" runat="server" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                 <td style=" text-align:right;">
                                     <asp:Label ID="Label7" runat="server" Text="FDBC Value :"></asp:Label>
                                </td>
                                <td>
                                 <asp:TextBox ID="txt_FDBCAmount" ReadOnly="true" runat="server" Width="100px" Font-Bold="true"  ForeColor="Red"></asp:TextBox>

                           
                                </td>
                                 <td style=" text-align:right;">
                                   <asp:Label ID="Label12" runat="server" Text="T. Invoice Value :"></asp:Label>
                                </td>
                                <td>
                              
                                <asp:TextBox ID="txt_InvoiceTotal" ReadOnly="true" runat="server" Width="100px" Font-Bold="true"  ForeColor="Red"></asp:TextBox>
                                </td>
                                  <td style=" text-align:right;">
                                 <asp:Label ID="Label29" runat="server" Text="FDBP Taka :"></asp:Label>
                                </td>
                                 <td >
                                 
                                   <asp:TextBox ID="txt_FDBP_Taka" onkeyup="CalculateCM()" runat="server" Width="100px" Font-Bold="true"  ForeColor="Red"></asp:TextBox>

                                 </td>
                                 
                            </tr>  
                            
                            <tr>
                                <td style=" text-align:right;">
                                    
                                </td>
                                <td>
                                     <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="buttonCSS" Width="50px" Text="Add"
                                                BackColor="blue" Font-Bold="true" ForeColor="White" onblur="this.style.backgroundColor='blue'"
                                                onfocus="this.style.backgroundColor='Green'"/>
                                              
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                     <asp:Button ID="btnDel" runat="server" Width="50px" CssClass="buttonCSS" Text="Del"
                                        Font-Bold="true" onblur="this.style.backgroundColor='White'" onfocus="this.style.backgroundColor='Red'"
                                        onmouseout="this.style.backgroundColor='White'" onmouseover="this.style.backgroundColor='Red'"
                                       OnClick="btnDel_Click" />
                                   
                                </td>
                                <td>
                                <asp:Label ID="lblsubmsg" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                                 <td style=" text-align:right;">
                                   
                               
                                </td>
                                 <td>
                               
                                </td>
                               
                               <td>
                               
                                </td>
                                 <td style=" text-align:right;">
                                    <asp:Label ID="Label2" runat="server" Text="FDBP Dolar :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_FDBP_Dolar" runat="server" Width="100px" Font-Bold="true"  ForeColor="Red"></asp:TextBox>
                                  
                                </td>
                               
                            </tr> 
                             
                        </table>
                        
                    </div>      
                    
                    </div>
                    <div style="overflow: scroll; color: White; border: 1px solid #C0C0C0;
                        height: 120px; width: 100%; margin-top: 5px;">
                        <asp:GridView ID="gdv_Item" runat="server" 
                            Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            CssClass="gridViewStyle" onrowdatabound="gdv_Item_RowDataBound" 
                            onselectedindexchanged="gdv_Item_SelectedIndexChanged">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                
                                <asp:BoundField DataField="Export_Id" HeaderText="Export_Id" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Invoice_Date" HeaderText="Invoice Date" DataFormatString="{0:d}"> 
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Amount"  HeaderText="Invoice Value">
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                  
                  </div>
                  
                  
                  
                   <div style="width: 95%;  border: 1px solid white; background-color: #1b4f72; margin-top: 10px;">
                      
                   
                   <div style="width: 50%; float: left; display: inline block;">
                                <table style="text-align: left; width: 100%; float: left;">
                                    <colgroup>
                                        <col width="40%" />
                                        <col width="60%" />
                                    </colgroup>
                                    <tr>
                                <td style="text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style="font-weight:bold; color:White;">
                                    <asp:Label ID="Label19" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label20" runat="server" Text="*" class="mf"></asp:Label>
                                    Realizatiom Distribution 
                                </td>
                            </tr>   
                                               
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label8" runat="server" Text="Account Head :"></asp:Label>
                                </td>
                                <td>
                                     <asp:DropDownList ID="dd_AccountHead" runat="server" AutoPostBack="true" Width="80%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                        onblur="this.style.backgroundColor='white'">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                            <td style=" text-align:right;">
                                    <asp:Label ID="Label28" runat="server" Text="PC No :"></asp:Label>
                            </td>
                            <td>
                            <asp:DropDownList ID="dd_PC" runat="server" AutoPostBack="true" Width="80%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                        onblur="this.style.backgroundColor='white'">
                                    </asp:DropDownList>
                            
                            </td>
                            
                            </tr>                      
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label10" runat="server" Text="Rate :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Rate" onkeyup="Calculate()" runat="server" Width="90px"></asp:TextBox>
                                </td>
                            </tr>                           
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label11" runat="server" Text="Amount (TK) :"></asp:Label>
                                </td>
                                <td>
                                 <asp:TextBox ID="txt_AmountTK" runat="server" Width="90px" 
                                        Font-Bold="true" ForeColor="Red" AutoPostBack="True" onkeyup="Calculate()"></asp:TextBox> 
                                
                                    <asp:TextBox ID="txt_AmountDollar" runat="server" Width="90px" Font-Bold="true"  onkeyup="Calculate()"
                                        ForeColor="Red" AutoPostBack="True" ></asp:TextBox> Dollar
                                   
                                  
                                  
                                </td>
                            </tr>                        
                               
                            
                            <tr style="visibility:collapse;">
                                <td style="width: 110px; text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblsubmsgDistribution" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                            </tr> 
                            <tr>
                                <td style="text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnDisburse_Add" runat="server" CssClass="buttonCSS" 
                                        Text="Add" onclick="btnDisburse_Add_Click" BackColor="blue" Font-Bold="true" ForeColor="White" onblur="this.style.backgroundColor='blue'"
                                                onfocus="this.style.backgroundColor='Green'"/> &nbsp;&nbsp;&nbsp;
                                                
                                    <asp:Button ID="btnDisburse_Del" runat="server" CssClass="buttonCSS" 
                                        Text="Del" onclick="btnDisburse_Del_Click" Font-Bold="true" onfocus="this.style.backgroundColor='Red'"
                                        onmouseout="this.style.backgroundColor='White'" onmouseover="this.style.backgroundColor='Red'"/>
                                        
                                        
                                </td>
                            </tr> 
                            <tr>
                            <td colspan="2">
                            <div style="overflow: scroll; color: White; border: 1px solid #C0C0C0;
                               height: 150px; width: 100%; margin-top: 5px;">
                           <asp:GridView ID="gdv_Distribution" runat="server" 
                            Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            CssClass="gridViewStyle" onrowdatabound="gdv_Distribution_RowDataBound" 
                                onselectedindexchanged="gdv_Distribution_SelectedIndexChanged" >
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                
                                <asp:BoundField DataField="AccountId" HeaderText="A/C Id" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                
                                <asp:BoundField DataField="AccountHead" HeaderText="Account Head"  ItemStyle-HorizontalAlign="Left">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="PCId" HeaderText="PCId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                
                                <asp:BoundField DataField="PCNo" HeaderText="PC No">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="AmountTk" HeaderText="Amount(Tk)" ItemStyle-HorizontalAlign="Right">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="AmountDollar" HeaderText="Amount($)" ItemStyle-HorizontalAlign="Right">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Rate" HeaderText="Rate">
                                </asp:BoundField>
                                
                              
                            </Columns>
                            <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                        </asp:GridView>
                            </div>
                            </td>
                            </tr> 
                                </table>
                            </div>
                            <%--Right Colomn --%>
                            <div style="width: 48%; float: right; display: inline block;">
                                <table style="width: 100%;">
                                    <colgroup>
                                        <col width="30%" />
                                        <col width="70%" />
                                    </colgroup>
                                     <tr>
                                <td style="text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td style=" font-weight:bold; color:White;">
                                    <asp:Label ID="Label21" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label22" runat="server" Text="*" class="mf"></asp:Label>
                                    Expenses From CD Account
                                </td>
                            </tr> 
                             
                                          
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label13" runat="server" Text="Expense Head :"></asp:Label>
                                </td>
                                <td style=" text-align:left;">
                                    <asp:DropDownList ID="dd_ExpenseHead" runat="server" AutoPostBack="true" Width="70%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                        onblur="this.style.backgroundColor='white'">
                                    </asp:DropDownList>
                                </td>
                            </tr>                                
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label16" runat="server" Text="Amount (TK):"></asp:Label>
                                </td>
                                <td style=" text-align:left;">
                                    <asp:TextBox ID="txt_ExpenseAmount" runat="server" Width="100px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>                            
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label17" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                 <td style=" text-align:left;">
                                    <asp:TextBox ID="txt_ExpenseRemarks" runat="server" Width="200px" ></asp:TextBox>
                                </td>
                            </tr>       
                             <tr>
                                <td style="width: 110px; text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                            </tr> 
                            <tr style="visibility:collapse;">
                                <td style="width: 110px; text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    
                                </td>
                            </tr> 
                            <tr>
                                <td style=" text-align:right;">
                                    
                                </td>
                                <td style="font-weight:bold; color:White;">
                                    <asp:Label ID="lblsubmsgExpense" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                            </tr>  
                            <tr>
                                <td style="text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td >
                                    
                                    <asp:Button ID="btnExpense_Add" runat="server" CssClass="buttonCSS" 
                                        Text="Add" onclick="btnExpense_Add_Click"  BackColor="blue" Font-Bold="true" ForeColor="White" onblur="this.style.backgroundColor='blue'"
                                                onfocus="this.style.backgroundColor='Green'"/>   &nbsp;&nbsp;&nbsp;
                                           
                                    <asp:Button ID="btnExpense_Del" runat="server" CssClass="buttonCSS" 
                                        Text="Del" Font-Bold="true" onclick="btnExpense_Del_Click" onfocus="this.style.backgroundColor='Red'"
                                        onmouseout="this.style.backgroundColor='White'" onmouseover="this.style.backgroundColor='Red'"/>
                                </td>
                            </tr> 
                            
                            <tr>
                            <td colspan="2">
                            <div style="overflow: scroll; color: White; border: 1px solid #C0C0C0;
                             height: 150px; width: 100%; margin-top: 5px;">
                            <asp:GridView ID="gdv_Expense" runat="server" 
                            Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            CssClass="gridViewStyle" onrowdatabound="gdv_Expense_RowDataBound" 
                                onselectedindexchanged="gdv_Expense_SelectedIndexChanged" >
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                <asp:BoundField DataField="ExpenseId" HeaderText="ExpenseId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ExpenseHead" HeaderText="Expense Head">
                                </asp:BoundField>
                                <asp:BoundField DataField="Amount" HeaderText="Amount(Tk)">
                                </asp:BoundField>
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" HeaderStyle-CssClass="hidGridColumn"
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
                            </td>
                            </tr>
                            
                            
                                </table>
                            </div>
                            <div style="width: 95%; height: 1%; clear: both;">
                            
                            </div>    
                   <div style="width: 90%;  text-align: center; display:inline block;  margin: 0 auto;">
                               
                                 <table style="text-align: left; width:70%; padding-top: 5px; padding-bottom:5px; margin:0 auto;">
                                    <colgroup>
                                        <col width="30%" />
                                        <col width="40%" />
                                        <col width="30%" />
                                        
                                    </colgroup>
                                    
                                     <tr>
                                         <td style=" text-align:center">
                                        Total Tk:
                                        <asp:TextBox ID="txt_Total" ReadOnly="true"  runat="server" Width="100px" Font-Bold="true"  ForeColor="Red"></asp:TextBox>
                                        </td>
                                       <td style="text-align:center">
                                            <asp:Button ID="btn_save" runat="server" CssClass="standardButton" Text="Save" OnClick="btn_save_Click" />
                                            <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CausesValidation="false"
                                                CssClass="standardButton" OnClick="btn_refresh_Click" />
                                            
                                            <asp:Button ID="btn_remove" runat="server" CausesValidation="false" CssClass="standardButton"
                                                Text="Delete" OnClick="btn_remove_Click" />
                                        </td>
                                         <td style=" text-align:center">
                                            <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                        </td>
                                    </tr>
                                </table> 
                                </div>
                        <div style="width: 95%; height: 1%; clear: both;">
                        </div>
                            
                     
                    </div>
                </div>
            </div>
            </div>
        </center>
         
        <asp:HiddenField ID="hid_InvoiceRow" runat="server" Value="0" />
        <asp:HiddenField ID="hid_DistributionRow" runat="server" Value="0" />
        <asp:HiddenField ID="hid_ExpenseRow" runat="server" Value="0" />
        <asp:HiddenField ID="hid_autoId" runat="server" Value="True" />
        <asp:HiddenField ID="hid_Addmode" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Addmode_Distribution" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Addmode_Expense" runat="server" Value="Y" />
        
        
    </div>
</asp:Content>


