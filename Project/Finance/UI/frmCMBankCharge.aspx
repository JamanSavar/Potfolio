<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmCMBankCharge.aspx.cs" Inherits="Finance_UI_frmCMBankCharge" Title="CM Bank Charge" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />


    <script language="javascript" type="text/javascript" src="../../Forms/Constants/Javascript/SharedValidationFunction.js"></script>
      
      
      
    <script language="javascript" type="text/javascript">
             
            
    </script>
      
      
     
       

    
</asp:Content>




  
<asp:Content ID="Personal_content" ContentPlaceHolderID="mainContent" runat="Server">
<div id="dialog" style="display: none">
</div>
     <div style="background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">
        <center>
            <div style="width: 100%;background-color: #969696; border: 1px solid #C0C0C0; clear:both;">
                <div style="width: 65%;  clear:both;">
                    <div style="width: 100%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style="padding-top: 7px;  text-align:right; color:Maroon;">
                         CM Bank Charge
                        </p>
                    </div>                    
                </div>   
                <div style="width: 95%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">                
                
                
                  <div style="width: 70%;  border: 1px solid white; background-color: #0b5345; margin-top: 20px;">
                      
                   
                   <div  style="margin-top:10px;">
                        
                          <table style="text-align: left; padding-bottom:10px;">
                            <colgroup>
                                <col width="15%" />
                                <col width="20%" />
                                <col width="10%" />
                            </colgroup>
                            
                           
                             <tr>
                               
                                
                               <td style="text-align:right;">
                                     
                                    <asp:Label ID="Label31" Visible="false" runat="server" Text="Search :"></asp:Label>
                                </td>
                                 <td>
                                     <asp:DropDownList ID="dd_Search" Visible="false" runat="server" AutoPostBack="true"   onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%"></asp:DropDownList>
                            
                                   </td>
                               
                                 <td >
                                
                                </td>
                            
                            </tr> 
                             
                            <tr>
                                 <td></td>
                                 <td>
                                 &nbsp; &nbsp;
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>      
                            
                             
                            
                            
                             <tr>
                               
                               
                                 <td style="text-align:right;">
                                  <asp:Label ID="Label6" runat="server" Text="*" class="mf"></asp:Label>
                                 <asp:Label ID="Label10" runat="server" Text="File No :"></asp:Label>
                                 </td>
                                <td>
                                 <asp:DropDownList ID="dd_FileNo" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%" onselectedindexchanged="dd_FileNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            
                             <tr>
                               
                               
                                 <td style="text-align:right;">
                                  <asp:Label ID="Label5" runat="server" Text="*" class="mf"></asp:Label>
                                 <asp:Label ID="Label27" runat="server" Text="LC No :"></asp:Label>
                                 </td>
                                <td>
                                <asp:DropDownList ID="dd_LC" runat="server"  AutoPostBack="true"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%" onselectedindexchanged="dd_LC_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            
                            <tr>
                               
                               
                                 <td style="text-align:right;">
                                  <asp:Label ID="Label8" runat="server" Text="*" class="mf"></asp:Label>
                                 <asp:Label ID="lbl_BTBType" runat="server" Text="CM No :"></asp:Label>
                                 </td>
                                <td>
                                 <asp:DropDownList ID="dd_CM" runat="server" AutoPostBack="true"  onselectedindexchanged="dd_CM_SelectedIndexChanged" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%" >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                
                                </td>
                            </tr>
                            <tr>
                                
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label13" runat="server" Text="CM Value :"></asp:Label>
                                </td>
                                <td>
                                <asp:TextBox ID="txt_PCValue"  runat="server"  Width="100px"   Font-Bold="true">
                                  </asp:TextBox>
                                   &nbsp; &nbsp; &nbsp; &nbsp;
                                  <asp:Button ID="btn_Search" runat="server" CssClass="buttonCSS"
                                                    Text="Search" Width="80px" Font-Bold="true" ForeColor="Blue" OnClick="btn_Search_Click"/>
                                  
                                </td>
                                <td>
                                
                                </td>
                            </tr> 
                      
                             <tr>
                                
                                 <td></td>
                                 <td>
                                 
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>    
                            <tr>
                                
                                 <td></td>
                                 <td>
                               
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>      
                             <tr>
                              
                                
                               <td style="text-align:right;">
                                     
                                    <asp:Label ID="Label28" runat="server" Text="Date :"></asp:Label>
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
                               
                                 <td >
                                </td>
                            
                            </tr>   
                             <tr>
                                
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label14" runat="server"  Text="Charge Head :"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="dd_Head" runat="server"   onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                            onblur="this.style.backgroundColor='white'" Width="80%" >
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label25" runat="server"  Text="Amount :"></asp:Label>
                                </td>
                                <td>
                                  <asp:TextBox ID="txt_Amount" runat="server"  Width="100px"  Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>
                                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender47" runat="server" FilterType="Numbers,Custom"
                                        ValidChars="." TargetControlID="txt_Amount" />
                                  
                                </td>
                                <td></td>
                            </tr>
                           
                              <tr>
                                
                                 <td></td>
                                 <td>
                                 <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>        
                          
                                 
                                 <tr>
                                
                                 <td></td>
                                 <td style="text-align:right;">
                                 
                                </td>
                                <td>
                               &nbsp; &nbsp;
                                </td>
                            </tr>    
                            <tr>
                                
                                 <td>
                                 
                                 </td>
                                <td>
                                 <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="buttonCSS" Width="50px" Text="Add"
                                                BackColor="blue" Font-Bold="true" ForeColor="White" onblur="this.style.backgroundColor='blue'"
                                                onfocus="this.style.backgroundColor='Green'"/>
                                                
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDel" runat="server" Width="50px" CssClass="buttonCSS" Text="Del"
                                        Font-Bold="true" onblur="this.style.backgroundColor='White'" onfocus="this.style.backgroundColor='Red'"
                                        onmouseout="this.style.backgroundColor='White'" onmouseover="this.style.backgroundColor='Red'"
                                       OnClick="btnDel_Click" />
                                       
                                       &nbsp;&nbsp;&nbsp;&nbsp;
                                       <asp:Button ID="btn_save" runat="server" Font-Bold="true" Width="80px" ForeColor="Blue" CssClass="standardButton" Text="Save" onclick="btn_save_Click"  />
                                  &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" Font-Bold="true" Width="80px" ForeColor="Blue" CssClass="standardButton" Text="Delete" onclick="btn_Delete_Click"  />
                                </td>
                                <td>
                                   <asp:TextBox ID="txt_Total" runat="server" AutoPostBack="true" Enabled="false" Width="100px"  Font-Bold="true" ForeColor="Red">
                                  </asp:TextBox>Taka
                                     

                             
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
                             
                                 <asp:BoundField DataField="CMId" HeaderText="CMId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="CMNo" HeaderText="CM No">
                                </asp:BoundField>
                                
                                 <asp:BoundField DataField="HeadId" HeaderText="HeadId" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Head" HeaderText="Head">
                                </asp:BoundField>
                                
                               
                                <asp:BoundField DataField="Amount" HeaderText="Amount">
                                </asp:BoundField> 
                                
                                <asp:BoundField DataField="EfectiveDate" HeaderText="Efective Date"  DataFormatString="{0:d}"> 
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
        <asp:HiddenField ID="hid_Addmode" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Rownumber" runat="server" Value="0" />
        <asp:HiddenField ID="hid_AutoId" runat="server" Value="0" />
        <asp:HiddenField ID="hid_LcId" runat="server" Value="0" />
        
    </div>
</asp:Content>


