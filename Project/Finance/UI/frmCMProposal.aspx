<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmCMProposal.aspx.cs" Inherits="Finance_UI_frmCMProposal" Title="CM Proposal" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />


    <script language="javascript" type="text/javascript" src="../../Forms/Constants/Javascript/SharedValidationFunction.js"></script>
      
      
      
      <script language="javascript" type="text/javascript">
             
             
            function CalculetCM() 
             {
                
                 var invoiceVal = 100;
                 
                 var BTB = document.getElementById('<%= txt_BTB.ClientID %>').value;
                 if (BTB == "") { BTB = 0; };
                 
                 var PC = document.getElementById('<%= txt_PC.ClientID %>').value;
                 if (PC == "") { PC = 0; };
                 
                 var Commission = document.getElementById('<%= txt_Commission.ClientID %>').value;
                 if (Commission == "") { Commission = 0; };
                 
                 var Charge = document.getElementById('<%= txt_BankCharge.ClientID %>').value;
                 if (Charge == "") { Charge = 0; };
                 
                 var Intarest = document.getElementById('<%= txt_PCIntarest.ClientID %>').value;
                 if (Intarest == "") { Intarest = 0; };
                 
                 var Tax = document.getElementById('<%= txt_Tax.ClientID %>').value;
                 if (Tax == "") { Tax = 0; };

                 if (BTB != ""){
                     var Purchase = parseFloat(invoiceVal - BTB - PC - Commission - Charge - Intarest - Tax);
                 }
                 else{var Purchase = 0;};             
                 document.getElementById('<%= txt_CM.ClientID %>').value = Purchase.toString();
             }
            
             
             
             function MyDolar() 
             {
                 var invoiceVal = document.getElementById('<%= txt_InvoiceValue.ClientID %>').value;
                 if (invoiceVal == "") { invoiceVal = 0; };
                 
                 var CM = document.getElementById('<%= txt_CM.ClientID %>').value;
                 if (CM == "") { CM = 0; };

                 if (invoiceVal != ""){
                     var Dolar = parseFloat(invoiceVal * CM / 100);
                 }
                 else{var Persent = 0;};             
                 document.getElementById('<%= txt_CMDolar.ClientID %>').value = Dolar.toString();
             }
             
             
            
            function Commission() 
             {
                 var invoiceVal = document.getElementById('<%= txt_InvoiceValue.ClientID %>').value;
                 if (invoiceVal == "") { invoiceVal = 0; };
                 
                 var Commission = document.getElementById('<%= txt_Commission.ClientID %>').value;
                 if (Commission == "") { Commission = 0; };

                 if (Commission != ""){
                     var Persent = parseFloat(Commission * 100 / invoiceVal);
                 }
                 else{var Persent = 0;};             
                 document.getElementById('<%= txt_Commission.ClientID %>').value = Persent.toString();
             }
            


                function Calculate() 
                     {
                         var Rate = document.getElementById('<%= txt_Rate.ClientID %>').value;
                         if (Rate == "") { Rate = 0; };
                         
                         var dolar = document.getElementById('<%= txt_AmountDollar.ClientID %>').value;
                         if (dolar == "") { dolar = 0; };

                         if (Rate != ""){
                             var taka = parseFloat(Rate) * parseFloat(dolar);
                         }
                         else{var taka = 0;};             
                         document.getElementById('<%= txt_AmountTK.ClientID %>').value = taka.toString();
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
                         CM Purchase Proposal
                        </p>
                    </div>                    
                </div>   
                <div style="width: 95%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">                
                
                
                  <div style="width: 90%;  border: 1px solid white; background-color: #0b5345; margin-top: 20px;">
                      
                   
                   <div  style="margin-top:10px;">
                        
                          <table style="text-align: left; padding-bottom:10px;">
                            <colgroup>
                                <col width="20%" />
                                <col width="25%" />
                                <col width="15%" />
                                <col width="20%" />
                                <col width="10%" />
                            </colgroup>
                            
                             
                            
                            <tr>
                               
                               <td style="text-align:right;">
                                     
                                    <asp:Label ID="lbl_IssueDate" runat="server" Text="Date :"></asp:Label>
                                </td>
                                 <td>
                                    <asp:TextBox ID="txtIssueDate" runat="server" Width="100px"></asp:TextBox>
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
                               
                                 <td style="text-align:right;">
                                    
                                    <asp:Label ID="Label5" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Text="Master LC :"></asp:Label>
                                 </td>
                                <td>
                                
                                <asp:DropDownList ID="dd_LC" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="100%" onselectedindexchanged="dd_LC_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td >
                                </td>
                            
                            </tr>  
                            <tr>
                               
                                <td style=" text-align:right;">
                                   
                                    <asp:Label ID="lbl" runat="server" Text="SL No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_SLNo"  Enabled="false" runat="server" Width="100px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                               
                                 <td style="text-align:right;">
                                  <asp:Label ID="Label8" runat="server" Text="*" class="mf"></asp:Label>
                                 <asp:Label ID="lbl_BTBType" runat="server" Text="Invoice No :"></asp:Label>
                                 </td>
                                <td>
                                 <asp:DropDownList ID="dd_Invoice" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="100%" onselectedindexchanged="dd_Invoice_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                           
                            <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label4" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                <td>
                                   
                                    <asp:TextBox ID="txt_buyer" runat="server" Width="80%" Enabled="false" ForeColor="red"></asp:TextBox>
                                
                                </td>
                                
                                
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label13" runat="server" Text="Invoice Value :"></asp:Label>
                                </td>
                                <td>
                                <asp:TextBox ID="txt_InvoiceValue" onkeyup="MyDolar()"  runat="server"  Width="100px"   Font-Bold="true">
                                  </asp:TextBox>
                                  <asp:Label ID="lblInvoiceValue" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                                <td>
                                
                                </td>
                            </tr>  
                             <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label11" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="File No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_FileNo" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%" onselectedindexchanged="dd_FileNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                   
                                </td>
                                
                                
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label14" runat="server"  Text="BTB(%) :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_BTB" onkeyup="CalculetCM()" runat="server"   Width="100px"  Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label23" runat="server" Text="File Value :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_FileValue"  runat="server"  Width="100px" ReadOnly="true"   Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>  
                                </td>
                                
                                
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label25" runat="server"  Text="PC(%) :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_PC" onkeyup="CalculetCM()" runat="server"  Width="100px"  Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                           
                            <tr>
                               
                               <td style=" text-align:right;">
                                    <asp:Label ID="Label9" runat="server" Text="BTB Limite :"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_BTBLimite"  ReadOnly="true" runat="server"  Width="100px"   Font-Bold="true" >
                                   </asp:TextBox> 
                                    &nbsp;  &nbsp;
                                   <asp:TextBox ID="txt_BTB1" runat="server" Width="70px" Font-Bold="true" ForeColor="Blue"  > 
                                   </asp:TextBox>&nbsp; %
                                </td>
                               
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label15" runat="server"  Text="Agent Com.(%) :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_Commission" onkeyup="CalculetCM()"  runat="server"  Width="100px"  Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                </td>
                                <td></td>
                            </tr>
                           
                             <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label24" runat="server" Text="PC Limite :"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_PCLimit"  ReadOnly="true" runat="server"  Width="100px"   Font-Bold="true" >
                                   </asp:TextBox> 
                                    &nbsp;  &nbsp;
                                   <asp:TextBox ID="txt_PC1" runat="server" Width="70px" Font-Bold="true" ForeColor="Blue"  > 
                                   </asp:TextBox>&nbsp; %
                                </td>
                                
                                <td style="text-align:right;">
                                 <asp:Label ID="Label16" runat="server" Text="Bank Charge(%) :"></asp:Label>
                                 
                                 </td>
                                <td>
                                
                                  <asp:TextBox ID="txt_BankCharge" onkeyup="CalculetCM()"  runat="server"  Width="100px"   Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            <tr>
                                
                                 <td style=" text-align:right;">
                                    <asp:Label ID="Label22" runat="server" Text="BTB Opened :"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_BTBOpened"  ReadOnly="true" ontextchanged="txt_BTBOpened_TextChanged"   runat="server"  Width="100px"   Font-Bold="true" >
                                   </asp:TextBox> 
                                   &nbsp;  &nbsp;
                                   <asp:TextBox ID="TextBox9" runat="server" Width="70px" Font-Bold="true" ForeColor="Blue"  > 
                                   </asp:TextBox>&nbsp; %
                                </td>
                                
                                
                                 <td style="text-align:right;">
                                 <asp:Label ID="Label18" runat="server" Text="PC Intarest(%) :"></asp:Label>
                                 </td>
                                <td>
                                  <asp:TextBox ID="txt_PCIntarest" onkeyup="CalculetCM()" runat="server"  Width="100px"   Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            
                           
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label1" runat="server" Text="PC Opened :"></asp:Label>
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_PCOpened" ontextchanged="txt_PCOpened_TextChanged"    ReadOnly="true" runat="server"  Width="100px"   Font-Bold="true" >
                                   </asp:TextBox>
                                   &nbsp;  &nbsp;
                                   <asp:TextBox ID="TextBox8" runat="server" Width="70px" Font-Bold="true" ForeColor="Blue"  > 
                                   </asp:TextBox>&nbsp; % 
                                </td>
                                  <td style="text-align:right;">
                                 <asp:Label ID="Label19" runat="server" Text="Sourch Tax(%) :"></asp:Label>
                                 </td>
                                <td>
                                  
                                  <asp:TextBox ID="txt_Tax" ReadOnly="true" onkeyup="CalculetCM()"  runat="server"  Width="100px"   Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                </td>
                                <td>
                                
                                </td>
                            </tr>   
                            <tr>
                               <td style="text-align:right;">
                                    <asp:Label ID="Label3" runat="server" Text="Agent Com. :"></asp:Label>
                                </td>
                                <td>
                                <asp:TextBox ID="txt_CommissionOpen" ontextchanged="txt_CommissionOpen_TextChanged"    ReadOnly="true" runat="server"  Width="100px"   Font-Bold="true">
                                  </asp:TextBox>
                                  &nbsp;  &nbsp;
                                   <asp:TextBox ID="TextBox7" runat="server" Width="70px" Font-Bold="true" ForeColor="Blue"  > 
                                   </asp:TextBox>&nbsp; %
                                </td>
                                 <td style=" text-align:right;">
                                    <asp:Label ID="Label20" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label21" runat="server" Text="CM(%) :"></asp:Label>
                                </td>
                                 <td>
                                 <asp:TextBox ID="txt_CM" onkeyup="MyDolar()" ontextchanged="txt_CM_TextChanged" runat="server" Font-Bold="true"  ForeColor="Blue" Width="100px"></asp:TextBox>
                                  $
                                 <asp:TextBox ID="txt_CMDolar"  runat="server" Font-Bold="true"  ForeColor="Blue" Width="100px"></asp:TextBox>
                                </td>
                               
                                <td>
                                 
                                </td>
                            </tr>   
                              <tr>
                                <td style="text-align:right;">
                                    &nbsp; &nbsp;
                                </td>
                                <td>
                                   &nbsp; &nbsp;
                                  
                                </td>
                                 <td></td>
                                 <td style="text-align:right;">
                                 
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>        
                          
                                 
                            <tr>
                                 <td style="text-align:right;">
                                   <asp:Label ID="Label12" runat="server" Text="Search :"></asp:Label>
                                   </td>
                                   <td>
                                   <asp:DropDownList ID="dd_Search" runat="server" AutoPostBack="true"   onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%"></asp:DropDownList>
                                   </td>
                                  <td style=" text-align:right;">
                                 <asp:Label ID="Label7" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="Amount :"></asp:Label>
                                 </td>
                                <td>
                                 <asp:TextBox ID="txt_AmountDollar" runat="server" onkeyup="Calculate()" Width="100px" Font-Bold="true" 
                                        ForeColor="Red" AutoPostBack="True" > 
                                    </asp:TextBox>
                                   $
                                   <asp:TextBox ID="txt_AmountTK" runat="server" Width="100px" 
                                        Font-Bold="true" ForeColor="Blue" AutoPostBack="True" onkeyup="Calculate()"  >
                                      
                                   </asp:TextBox>
                                   TK
                                </td>
                                <td  style=" text-align:center;">
                                
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align:right;">
                                    &nbsp;
                                </td>
                                <td>
                                <asp:Button ID="btn_Search" runat="server" CssClass="buttonCSS"
                                                    Text="Search" Width="80px" Font-Bold="true" ForeColor="Blue" OnClick="btn_Search_Click"/>
                                  
                                </td>
                                 <td style=" text-align:right;">
                                 <asp:Label ID="Label17" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label26" runat="server" Text="Rate :"></asp:Label>
                                 </td>
                                
                                 <td>
                                 <asp:TextBox ID="txt_Rate" Font-Bold="true" ForeColor="Red" onkeyup="Calculate()" runat="server" Width="100px">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                                </tr>
                                 <tr>
                                <td style="text-align:right;">
                                    &nbsp; &nbsp;
                                </td>
                               <td style=" text-align:right;">
                                  <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                  
                                </td>
                                 <td></td>
                                 <td style="text-align:right;">
                                 
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>    
                            <tr>
                                <td style=" text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                 <asp:Button ID="btn_Preview" runat="server"  CssClass="buttonCSS" Text="Preview" OnClick="btn_Preview_Click" Width="80px" Font-Bold="true" ForeColor="Blue"/> 
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btn_Refresh" runat="server"  CssClass="buttonCSS" Text="Refresh" OnClick="btn_Refresh_Click" Width="80px" Font-Bold="true" ForeColor="Blue"/> 

                                   
                                
                                </td>
                                 <td>
                                 <asp:Button ID="btn_save" runat="server" Font-Bold="true" Width="80px" ForeColor="Blue" CssClass="standardButton" Text="Save" onclick="btn_save_Click"  />
                                 </td>
                                <td>
                                 <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="buttonCSS" Width="50px" Text="Add"
                                                BackColor="blue" Font-Bold="true" ForeColor="White" onblur="this.style.backgroundColor='blue'"
                                                onfocus="this.style.backgroundColor='Green'"/>
                                                
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDel" runat="server" Width="50px" CssClass="buttonCSS" Text="Del"
                                        Font-Bold="true" onblur="this.style.backgroundColor='White'" onfocus="this.style.backgroundColor='Red'"
                                        onmouseout="this.style.backgroundColor='White'" onmouseover="this.style.backgroundColor='Red'"
                                       OnClick="btnDel_Click" />
                                
                                </td>
                                <td>
                                    
                             
                                </td>
                                
                            </tr>  
                        </table>
                       
                    </div>      
                  
                    <div style="overflow: scroll; color: White; border: 1px solid #C0C0C0;
                        height: 250px; width: 100%; margin-top: 5px;">
                       <asp:GridView ID="gdv_Item" runat="server" 
                            Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            CssClass="gridViewStyle" OnRowDataBound="gdv_Item_RowDataBound" OnSelectedIndexChanged="gdv_Item_SelectedIndexChanged">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                
                                <asp:TemplateField  HeaderText="Select" >
                                    <ItemTemplate >
                                        <asp:CheckBox ID="chkApproval" runat="server" />
                                    </ItemTemplate>
                                 </asp:TemplateField>
                                 
                               <asp:BoundField DataField="AutoId" HeaderText="AutoId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                               </asp:BoundField>
                                
                               <asp:BoundField DataField="FileId" HeaderText="FileId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="LCId" HeaderText="LCId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="LCNO" HeaderText="LC No">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="LCValue" HeaderText="LC Value">
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="InvoiceId" HeaderText="InvoiceId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="InvoiceValue" HeaderText="Invoice Value">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="BTB" HeaderText="BTB(%)">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="PC" HeaderText="PC(%)" >
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="Commission" HeaderText="Com(%)">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="BankCharge" HeaderText="B.Charge(%)" >
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="PCIntarest" HeaderText="PC Int.(%)">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="SourchTax" HeaderText="Tax(%)" >
                                </asp:BoundField>
                              
                                <asp:BoundField DataField="CM" HeaderText="CM(%)">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="CMDolar" HeaderText="CM($)">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="CMTK" HeaderText="CM(tk)">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Rate" HeaderText="Rate">
                                </asp:BoundField>                             
                               
                              
                            </Columns>
                            <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                        </asp:GridView>
                    
               
                </div>
                 <div style="width: 95%; height: 1%; clear:both;">
                 </div>
                    
                 
                </div>
            </div>
            </div>
        </center>
         
        <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_ProposalId" runat="server" Value="0" />
        <asp:HiddenField ID="hid_ExportId" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Addmode" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Rownumber" runat="server" Value="0" />
        <asp:HiddenField ID="hid_TotalPC" runat="server" Value="0" />
        <asp:HiddenField ID="hidAutoId" runat="server" Value="0" />
        <asp:HiddenField ID="hidColorIndex" runat="server" Value="" />
        <asp:HiddenField ID="hid_LcId" runat="server" Value="0" />
        
    </div>
</asp:Content>


