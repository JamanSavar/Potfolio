<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmPCProposal.aspx.cs" Inherits="Finance_UI_frmPCProposal" Title="PC Proposal" %>


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
                         
                         var dolar = document.getElementById('<%= txt_AmountDollar.ClientID %>').value;
                         if (dolar == "") { dolar = 0; };

                         if (Rate != ""){
                             var taka = parseFloat(Rate) * parseFloat(dolar);
                         }
                         else{var taka = 0;};             
                         document.getElementById('<%= txt_AmountTK.ClientID %>').value = taka.toString();
                     }
        </script>
    
    <style type="text/css">
        .style1
        {
            width: 80%;
            float: right;
        }
    </style>
       
   

    
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
                         PC Proposal
                        </p>
                    </div>                    
                </div>   
                <div style="width: 95%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">                
                
                
                  <div style="width: 80%;  border: 1px solid white; background-color: #0b5345; margin-top: 20px;">
                      
                   
                   <div  style="margin-top:20px;">
                        
                          <table style="text-align: left; padding-bottom:10px;">
                            <colgroup>
                                <col width="30%" />
                                <col width="40%" />
                                <col width="10%" />
                                <col width="20%" />
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
                                   <asp:Label ID="Label12" runat="server" Text="Proposal No :"></asp:Label>
                                   </td>
                                   <td>
                                   <asp:DropDownList ID="dd_Proposal" runat="server" AutoPostBack="true"   onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%"></asp:DropDownList>
                                   </td>
                            </tr>
                            
                              <tr>
                                <td style=" text-align:right;">
                                   
                                    <asp:Label ID="lbl" runat="server" Text="Proposal No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_SLNo"  Enabled="false" runat="server" Width="100px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td></td>
                                <td>
                                <asp:Button ID="btn_Search" runat="server" CssClass="buttonCSS"
                                                    Text="Search" Width="80px" Font-Bold="true" ForeColor="Blue" OnClick="btn_Search_Click"/>

                                </td>
                            </tr>
                            
                               
                             
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label50" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_Buyer" runat="server" Text="File No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_FileNo" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="70%" onselectedindexchanged="dd_FileNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    
                                 
                                </td>
                                <td>
                                
                            </td>
                                <td >
                                <asp:Button ID="btn_Preview" runat="server"  CssClass="buttonCSS" Text="Preview" OnClick="btn_Preview_Click" Width="80px" Font-Bold="true" ForeColor="Blue"/> 
                            </td>
                            
                            </tr>  
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label11" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="Master LC No :"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="dd_LC" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="70%" onselectedindexchanged="dd_LC_SelectedIndexChanged">
                                    </asp:DropDownList> 
                                </td>
                                <td></td>
                                <td>
                                
                                </td>
                            </tr>  
                            
                            
                             
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="lbl_BTBType" runat="server" Text="Master LC Value :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_LCValue"  runat="server"  Width="100px" ReadOnly="true"   Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox> 
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                             <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label1" runat="server" Text="BTB Value :"></asp:Label>
                                </td>
                                <td>
                                     <asp:TextBox ID="txt_BTBValue" runat="server" Width="100px" ReadOnly="true"></asp:TextBox>
                                     &nbsp;&nbsp;&nbsp;
                                     <asp:TextBox ID="txt_BTB" runat="server" ReadOnly="true" Width="100px"></asp:TextBox>&nbsp;%
                                </td>
                                <td>
                                 
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label3" runat="server" Text="PC Value :"></asp:Label>
                                </td>
                                <td>
                                
                                <asp:TextBox ID="txt_PCValue" runat="server" Width="100px" ReadOnly="true" ></asp:TextBox>
                                     &nbsp;&nbsp;&nbsp;
                                 <asp:TextBox ID="txt_PC" ReadOnly="true" runat="server" Width="100px" ></asp:TextBox>&nbsp;%
                                </td>
                                <td>
                                 
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label4" runat="server" Text="PC Balance :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_PCBalance" runat="server" Width="100px"></asp:TextBox>
                                </td>
                                
                                 <td>
                                 
                                </td>
                                <td>
                                
                                </td>
                            </tr> 
                              
                            <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label6" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label10" runat="server" Text="Rate :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Rate" Font-Bold="true" ForeColor="Red" onkeyup="Calculate()" runat="server" Width="100px">
                                    </asp:TextBox>
                                </td>
                                
                                 <td>
                                 
                                </td>
                                <td>
                                
                                </td>
                            </tr>   
                              <tr>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label7" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="Amount :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AmountDollar" runat="server" onkeyup="Calculate()" Width="100px" Font-Bold="true" 
                                        ForeColor="Red" AutoPostBack="True" > 
                                      
                                    </asp:TextBox>
                                   $&nbsp; 
                                   <asp:TextBox ID="txt_AmountTK" runat="server" Width="100px" 
                                        Font-Bold="true" ForeColor="Blue" AutoPostBack="True" onkeyup="Calculate()"  >
                                      
                                   </asp:TextBox>
                                   TK
                                </td>
                                <td>
                                 <asp:Label ID="Label5" runat="server" Text="Total Amount :"></asp:Label>
                                </td>
                                <td>
                                <asp:TextBox ID="txt_TotalPC" runat="server" 
                                Font-Bold="true" ForeColor="Red" ReadOnly="True" style="text-align:right;" Width="81px" ></asp:TextBox>
                                 TK
                                </td>
                            </tr>        
                          
                                 
                            <tr>
                                <td style=" text-align:right;">
                                    
                                </td>
                                <td>
                                   <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label> 
                                </td>
                                
                                <td colspan="2" style=" text-align:center;">
                                
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align:right;">
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
                            <tr>
                                <td style=" text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
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
                                <td></td>
                                <td>
                                    <asp:Button ID="btn_save" runat="server" Font-Bold="true" Width="80px" ForeColor="Blue" CssClass="standardButton" Text="Save" onclick="btn_save_Click"  />
                                      
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
                                
                                <asp:BoundField DataField="LCNO" HeaderText="Master LC No">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="LCValue" HeaderText="Master LC Value">
                                </asp:BoundField>
                                
                                
                                <asp:BoundField DataField="BTBValue" HeaderText="BTB Value">
                                </asp:BoundField>
                                
                                  <asp:BoundField DataField="Rate" HeaderText="Rate">
                                </asp:BoundField>
                             
                                
                                <asp:BoundField DataField="PCValueDolar" HeaderText="PC Value($)" ItemStyle-HorizontalAlign="Right">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="PCValueTK" HeaderText="PC Value(Tk)" ItemStyle-HorizontalAlign="Right">
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
        </center>
         
        <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_ProposalId" runat="server" Value="0" />
        <asp:HiddenField ID="hid_ExportLcId" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Addmode" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Rownumber" runat="server" Value="0" />
        <asp:HiddenField ID="hid_TotalPC" runat="server" Value="0" />
        <asp:HiddenField ID="hidColorIndex" runat="server" Value="" />
       
        
    </div>
</asp:Content>


