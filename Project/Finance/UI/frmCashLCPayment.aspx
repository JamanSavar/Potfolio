<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true"
    CodeFile="frmCashLCPayment.aspx.cs" Inherits="Finance_UI_frmCashLCPayment"
    Title="Cash LC Payment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>

    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script language="javascript" src="../../Forms/Constants/Javascript/SharedValidationFunction.js"
        type="text/javascript"></script>

   

</asp:Content>
<asp:Content ID="Personal_content" ContentPlaceHolderID="mainContent" runat="Server">
    <div id="dialog" style="display: none">
    </div>
    <div style="background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear: both;">
        <center>
            <div style="width: 100%; background-color: #969696; border: 1px solid #C0C0C0; clear: both;">
                <div style="width: 80%; clear: both;">
                    <div style="width: 100%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style="padding-top: 7px;
                            text-align: right; color: Maroon;">
                            Cash LC Payment
                        </p>
                    </div>
                </div>
                <div style="width: 95%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;
                    clear: both;">
                    <div style="width: 100%; margin: 0 auto;">
                        <div style="width: 80%; border: 1px solid white; margin-top: 10px; text-align: left;
                            background-color: #1b4f72; clear: both;">
                            <div style="width: 100%; margin-top: 10px; text-align: left; clear: both;">
                                
                                <div runat="server" style="width: 100%; text-align: center; float: left;">
                                    <table style="text-align: left; width: 100%;">
                                        <colgroup>
                                            <col width="15%" />
                                            <col width="10%" />
                                            <col width="25%" />
                                            <col width="15%" />
                                            <col width="25%" />
                                        </colgroup>
                                      
                                      <tr>
                                            <td>
                                               
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label16" runat="server" Text="*" class="mf"></asp:Label>
                                                <asp:Label ID="Label1" runat="server" Text="PO Supplier :"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:DropDownList ID="dd_POSupplier" runat="server"  Width="100%" >
                                                  </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right;">
                                             
                                           </td>
                                        <td>
                                                  
                                        </td>
                                            
                                        </tr>
                                      
                                        <tr>
                                            <td>
                                               
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label14" runat="server" Text="*" class="mf"></asp:Label>
                                                <asp:Label ID="Label5" runat="server" Text="PI Supplier :"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:DropDownList ID="dd_Supplier" runat="server" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="dd_Supplier_SelectedIndexChanged" onfocus="this.style.backgroundColor='#ffff80'"
                                                    onblur="this.style.backgroundColor='white'">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right;">
                                             
                                           </td>
                                        <td>
                                                  
                                        </td>
                                            
                                        </tr>
                                      <tr>
                                            <td>
                                               
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label10" runat="server" Text="*" class="mf"></asp:Label>
                                               <asp:Label ID="lbl_CostingHead" runat="server" Text="Costing Head :"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dd_CostingHead" runat="server"  Width="50%" AutoPostBack="true"   onselectedindexchanged="dd_CostingHead_SelectedIndexChanged"
                                                onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                              </asp:DropDownList>
                                            </td>
                                           
                                <td style="text-align:right;">
                                  
                                </td>
                                <td>
                                    
                                </td>
                                 
                                        </tr>
                                        <tr>
                                            <td>
                                               
                                            </td>
                                            <td style="text-align:right;">
                                                <asp:Label ID="Label6" runat="server" Text="*" class="mf"></asp:Label>
                                                <asp:Label ID="lbl_Currency" runat="server"  Text="Currency :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dd_Currency" runat="server"  Width="50%" AutoPostBack="true"   onselectedindexchanged="dd_Currency_SelectedIndexChanged"
                                                        onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                        onblur="this.style.backgroundColor='white'">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right;">
                                               
                                            </td>
                                        <td>
                                                
                                        </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                               
                                            </td>
                                            <td style=" text-align:right;">
                                                <asp:Label ID="Label4" runat="server" Text="*" class="mf"></asp:Label>
                                                <asp:Label ID="lbl_Pi" runat="server" Text="PI No :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dd_PI" runat="server"  Width="50%"
                                                        onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                        onblur="this.style.backgroundColor='white'">
                                                </asp:DropDownList>
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
                                <div style="width: 100%; clear: both;">
                                </div>
                            </div>
                            <div style="width: 100%; margin-top: 5px; text-align: center; display: inline block;">
                                <div style="overflow: scroll; border: 1px solid red; color: White; border: 1px solid #C0C0C0;
                                    width: 100%; height: 250px; margin-top: 0px; clear: both;">
                                    <asp:GridView ID="gdv_Item" runat="server" 
                            Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            CssClass="gridViewStyle">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                
                                <asp:TemplateField  HeaderText="Select" >
                                    <ItemTemplate >
                                        <asp:CheckBox ID="chkApproval" runat="server" />
                                    </ItemTemplate>
                                 </asp:TemplateField>
                                
                                <asp:BoundField DataField="PI_AutoId" HeaderText="PI Id" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Supplier" HeaderText="Supplier">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="PI_No" HeaderText="PI NO">
                                </asp:BoundField>
                              
                               <asp:BoundField DataField="PI_Date" HeaderText="PI Date"  DataFormatString="{0:d}"> 
                               </asp:BoundField>
                              
                                <asp:BoundField DataField="Total_Price" HeaderText="Amount">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Currency" HeaderText="Currency">
                                </asp:BoundField>
                                
                            </Columns>
                            <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                        </asp:GridView>
                                </div>
                            </div>
                       
                              
                                <div style="width: 100%; clear: both;">
                                </div>
                           
                        </div>
                        <%--/Fabric--%>
                        <div style="width: 80%; border: 1px solid white; margin-top: 10px; text-align: left;
                            background-color: #0b5345;">
                            
                             <div style="width: 100%; margin-top: 10px; text-align: left; clear: both;">
                             
                                <div  style="width: 100%; text-align: center; margin-bottom:8px; float: left;">
                                    <table style="text-align: left; width: 100%;">
                                        <colgroup>
                                            <col width="15%" />
                                            <col width="10%" />
                                            <col width="25%" />
                                            <col width="15%" />
                                            <col width="25%" />
                                        </colgroup>
                                        
                                        <tr>
                                            <td style="text-align: center;">
                                                
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label8" runat="server" Text="Date :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIssueDate" runat="server" Width="30%"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                                    CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIssueDate">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_Delidery"
                                                    PopupPosition="TopLeft" TargetControlID="txtIssueDate">
                                                </cc1:CalendarExtender>
                                                <asp:Image ID="Image_Delidery" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                                    Height="16px" ImageAlign="AbsMiddle" />
                                            </td>
                                            
                                            <td style="text-align: right; font-size: 12px; font-weight: bold;">
                                                <asp:Label ID="Label15" runat="server" Text="Voucher No :"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="dd_CashId" runat="server" AutoPostBack="true"   onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'" Width="50%"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center;">
                                                
                                            </td>
                                            <td style="text-align:right;">
                                                <asp:Label ID="lbl_BTBType" runat="server" Text="Voucher Type :"></asp:Label>
                                            </td>
                                            <td>
                                                 <asp:DropDownList ID="dd_VoucherType" runat="server"  Width="153px"  >
                                                </asp:DropDownList>
                                            </td>
                                            <td style="text-align: right; font-size: 12px; font-weight: bold;">
                                               
                                            </td>
                                            <td style="text-align: left;">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                        <td style="text-align: center;">
                                        
                                            </td>     
                                         <td style=" text-align:right;">
                                            <asp:Label ID="lbl" runat="server" Text="Voucher No :"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_VoucherNo" ReadOnly="true" runat="server" Width="150px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                        </td>
                                        <td style="text-align: right;">
                                                &nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" CausesValidation="false" CssClass="buttonCSS"
                                                    Text="Search" Width="100px" Font-Bold="true" ForeColor="Blue" onclick="btnSearch_Click"
                                                   />
                                                     
                                            </td>
                                        </tr>
                                        <tr>
                                <td style="text-align: right;">
                                                &nbsp;</td>
                                <td style="text-align:right;">
                                    <asp:Label ID="Label17" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="File Ref. No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_FileNo"  runat="server"    Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td>
                                
                                </td>
                            </tr>  
                                        <tr>
                                        <td style="text-align: center;">
                                                
                                            </td>
                                         <td style="text-align:right;">
                                    <asp:Label ID="Label7" runat="server" Text="Bank Name :"></asp:Label>
                                            </td>
                                            <td>
                                               <asp:DropDownList ID="dd_Bank" runat="server"  Width="100%" AutoPostBack="true"   
                                                        onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                        onblur="this.style.backgroundColor='white'">
                                                </asp:DropDownList>
                                        </td>
                                       <td style="text-align: right;">
                                       
                                                &nbsp;</td>
                                            <td>
                                            <asp:Button ID="btn_Preview" runat="server" CausesValidation="false" CssClass="buttonCSS"
                                                Text="Preview" Width="100px" Font-Bold="true" ForeColor="Blue" />
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                        </td>
                                        <td style=" text-align:right;">

                                    <asp:Label ID="Label11" runat="server" Text="Check No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_CheckNo" runat="server" Width="150px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                               
                                        <td style="text-align:center">
                                            &nbsp;</td>
                                        <td style="text-align:right;">
                                      
                                        </td>
                                    
                                        </tr>
                                        <tr>
                                        <td></td>
                                          <td style=" text-align:right;">
                                            <asp:Label ID="Label2" runat="server" Text="PI Amount :"></asp:Label>
                                        </td>
                                        <td>
                                        <asp:TextBox ID="txttotalPIAmount" runat="server" 
                                        Font-Bold="true" ForeColor="Red" ReadOnly="True"  Width="150px" ></asp:TextBox>
                                        
                                        </td>
                                        <td></td>
                                        <td>
                                          <asp:Button ID="btn_save" runat="server" CausesValidation="false" CssClass="buttonCSS" onclick="btn_save_Click"
                                                Text="Save" Width="100px" Font-Bold="true" ForeColor="Blue" />
                                            
                                        </td>
                                        </tr>
                                       
                             <tr>
                                        <td></td>
                                          <td style=" text-align:right;">
                                            <asp:Label ID="Label3" runat="server" Text="Recived By :"></asp:Label>
                                        </td>
                                        <td>
                                        <asp:TextBox ID="txt_RecivedBy" runat="server" 
                                        Font-Bold="true"  Width="100%" ></asp:TextBox>
                                        
                                        </td>
                                        <td></td>
                                        <td>  <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label></asp:Label></td>
                                        </tr>
                                         <tr>
                                        <td></td>
                                          <td style=" text-align:right;">
                                            <asp:Label ID="Label9" runat="server" Text="Note :"></asp:Label>
                                        </td>
                                        <td>
                                        <asp:TextBox ID="txt_Note" runat="server" 
                                        Font-Bold="true"  Width="100%" ></asp:TextBox>
                                        
                                        </td>
                                        <td></td>
                                        <td></td>
                                        </tr>
                            
                            
                                        <tr>
                                              <td style="text-align: right;">
                                       
                                                &nbsp;</td>
                                                
                                              <td style="text-align: right;">
                                       
                                                &nbsp;</td>
                                                
                                            <td style="colspan="2">
                                            
                                            </td>
                                            
                                            
                                              <td style="text-align: right;">
                                       
                                                &nbsp;</td>
                                                <td style="text-align: right;">
                                       
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            
                            </div>
                            
                            <div style="width: 100%;clear: both;">
                        </div>
                            
                        </div>
                        <div style="width: 100%;clear: both;">
                        </div>
                    </div>
                </div>
            </div>
        </center>
       <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_formName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_tableName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_autoId" runat="server" Value="0" />
        <asp:HiddenField ID="hid_CostingHead_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Currency_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Supplier_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_File_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Addmode" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Rownumber" runat="server" Value="0" />
        <asp:HiddenField ID="hid_TotalPIAmount" runat="server" Value="0" />
        
    </div>
</asp:Content>
