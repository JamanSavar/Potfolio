

<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmRealization2.aspx.cs" Inherits="Finance_UI_frmRealization2" Title="Realization-2" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>

    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../../Forms/Constants/Javascript/SharedValidationFunction.js"></script>
     
     
  <script type="text/javascript">
    
    
    $(function() {
    $("[id$=txt_Delivary]").autocomplete({
            source: function(request, response) {
                $.ajax({
                url: '<%=ResolveUrl("~/Inventory/UI/frmGeneralChalan.aspx/GetDeliveryAddress") %>',
                    
                    data: '{ "prefix": "' + request.term + '"}',
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function(data) {
                        response($.map(data.d, function(item) {
                            return {
                                label: item.split('-')[0],
                                val: item.split('-')[1]
                            }
                        }))
                    },
                    error: function(response) {
                        alert(response.responseText);
                    },
                    failure: function(response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function(e, i) {
                $("[id$=hid_Composition]").val(i.item.val);
            },
            minLength: 1
        });
    }); 
    
    
     
</script>


     
   
    <style type="text/css">
        .style1
        {
            width: 100%;
            float: left;
        }
    </style>
   

   
    </asp:Content>


  
<asp:Content ID="Personal_content" ContentPlaceHolderID="mainContent" runat="Server">
    <div id="dialog" style="display: none">
</div>
     <div style="background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">
        <center>
            <div style="width: 100%;background-color: #969696; border: 1px solid #C0C0C0; clear:both;">
                <div style="width: 90%;  clear:both;">
                    <div style="width: 100%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style="padding-top: 7px;  text-align:right; color:Maroon;">
                           Document Collection & Realization
                        </p>
                    </div>                    
                </div>   
                <div style="width: 95%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">                
                
                <div style=" width: 100%;margin:0 auto;">  
                
                  <div style="width: 95%; border: 1px solid white; text-align: left;" >
                      
                   <%-- Ist Column--%>
                    
                    <div style="width: 50%;float: left; height:550px;  background-color: #1b4f72; display:inline block;">
                     <table style="text-align: left; width:100%; float:left; padding-top: 10px; ">
                                 <colgroup>
                                    <col width="30%"/>
                                    <col width="70%"/>
                                </colgroup>
                                 <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td >
                                            &nbsp;
                                        </td>
                                    </tr> 
                              <tr>
                            <td style="text-align: right; font-size: 12px; font-weight: bold;">
                                                <asp:Label ID="Label44" runat="server" Text="Search :"></asp:Label>
                                </td>
                                <td>
                                   <asp:DropDownList ID="dd_Search"
                                        runat="server" Width="81%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                        onblur="this.style.backgroundColor='white'">
                                    </asp:DropDownList>
                                
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr> 
                            
                            <tr>
                            <td style="text-align: right;">
                                        
                                               &nbsp;</td>
                                            <td>
                               <asp:Button ID="btn_Search" runat="server" CssClass="buttonCSS" 
                                Text="Search" Width="80px" Font-Bold="true" ForeColor="Blue" />&nbsp;&nbsp;
                                                    
                                <asp:Button ID="btn_Preview" runat="server" CausesValidation="false" CssClass="buttonCSS"  Width="80" Font-Bold="true"
                                    Text="Preview"  />
                            </td>
                            </tr> 
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr>
                            
                           <tr style="visibility:collapse;">
                                <td style="text-align:right;">
                                    <asp:Label ID="Label2" runat="server" Text="SL No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_SlNo" runat="server" Width="100px" Font-Bold="true" ForeColor="Red" ReadOnly="true"></asp:TextBox>
                                </td>
                                
                            </tr>            
                          
                            <tr>
                                <td style="text-align:right;">
                                     <asp:Label ID="lbl_IssueDate" runat="server" Text="Date :"></asp:Label>
                                    
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIssueDate" runat="server" Width="35%"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureName="fr-FR" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtIssueDate">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" PopupButtonID="Image_FromIssue"
                                        PopupPosition="TopLeft" TargetControlID="txtIssueDate">
                                    </cc1:CalendarExtender>
                                    <asp:Image ID="Image_FromIssue" runat="server" ImageUrl="~/Forms/Constants/Images/Calendar.png"
                                        Height="16px" ImageAlign="AbsMiddle" />
                                </td>
                                
                               

                                 </tr>                           
                                  
                            <tr>
                            
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
                                
                            </tr>         
                            <tr>
                                 <td style=" text-align:right;">
                                    <asp:Label ID="Label14" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl" runat="server" Text="Collection No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_CollectionNo" runat="server" Width="80%" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                            <td style="text-align:right;">
                                     <asp:Label ID="Label5" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_FileNo" runat="server" Text="File Ref. No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_FileNo" runat="server"  AutoPostBack="true" 
                                        Width="81%" onselectedindexchanged="dd_FileNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr> 
                            <tr>
                             <td style=" text-align:right;">
                                    <asp:Label ID="Label23" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="lbl_LCNo" runat="server" Text="Export LC No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_LCNo" runat="server"  AutoPostBack="true" 
                                        Width="81%" onselectedindexchanged="dd_LCNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                             <td style=" text-align:right;">
                                     <asp:Label ID="Label25" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="Invoice No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_Invoice" runat="server" Width="81%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td >
                                             <asp:Label ID="lblsubmsg" runat="server" CssClass="standardlabel"></asp:Label>
                                        </td>
                                    </tr> 
                                     <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td >
                                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="buttonCSS" Width="50px" Text="Add"
                                                BackColor="blue" Font-Bold="true" ForeColor="White" onblur="this.style.backgroundColor='blue'"
                                                onfocus="this.style.backgroundColor='Green'"/>
                                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDel" runat="server" Width="50px" CssClass="buttonCSS" Text="Del"
                                        Font-Bold="true" onblur="this.style.backgroundColor='White'" onfocus="this.style.backgroundColor='Red'"
                                        onmouseout="this.style.backgroundColor='White'" onmouseover="this.style.backgroundColor='Red'"
                                       OnClick="btnDel_Click" />
                                        </td>
                                    </tr> 
                            <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td >
                                            &nbsp;
                                        </td>
                                    </tr> 
                            <tr>
                                <td  colspan="2">
                                <div style="overflow: scroll; color: White; border: 1px solid #C0C0C0;
                                       height: 150px; width: 100%; margin-top: 5px;">
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
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount">
                                                    </asp:BoundField>
                                                </Columns>
                                                <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                                            </asp:GridView>
                                    </div>
                                </td>
                                
                            </tr>
                            
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                
                                <td  style="text-align:center;" colspan="2" >
                                   <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                            </tr>   
                            <tr>
                                <td style=" text-align:right;">
                                    &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                   <asp:Button ID="btn_save" Width="70px" Font-Bold="true" runat="server" CssClass="buttonCSS" Text="Save" /> 
                                    &nbsp;&nbsp;
                                <asp:Button ID="btn_refresh" Width="70px" Font-Bold="true" runat="server" Text="Refresh" CausesValidation="false"
                                                CssClass="buttonCSS"  />
                                </td>
                              </tr>
                                <tr>
                                <td >
                                    &nbsp;</td>
                                <td>
                                
                                </td>
                                
                            </tr>                                         
                           
                        </table>
                    </div> 
                    
                     <div style="width: 48%;float: right; height:550px;  background-color:  #0b5345; display:inline block;"> 
                       
                    <div style="width: 100%; float: left; display: inline block;  margin-top:10px;">
                                <table style="text-align: left; " class="style1">
                                    <colgroup>
                                        <col width="40%"/>
                                        <col width="60%"/>
                                    </colgroup>
                            
                                     <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td >
                                            &nbsp;
                                        </td>
                                    </tr> 
                               <tr>
                               <td></td>
                               
                               <td style="font-weight:bold; color:White;">
                                    <asp:Label ID="Label19" runat="server" Text="*" class="mf"></asp:Label>
                                    <asp:Label ID="Label20" runat="server" Text="*" class="mf"></asp:Label>
                                    Realizatiom Distribution 
                                </td>
                                
                               </tr>        
                            <tr>
                                
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label9" runat="server" Text="Account Head :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dd_AccountHead" runat="server" Width="220px">
                                    </asp:DropDownList>
                                </td>
                            </tr>             
                              <tr>
                                <td style=" text-align:right;">
                                    <asp:Label ID="Label10" runat="server" Text="Rate :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Rate" runat="server" Width="90px"></asp:TextBox>
                                </td>        
                              </tr>         
                            <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label11" runat="server" Text="Amount :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_AmountDollar" runat="server" Width="90px" Font-Bold="true" 
                                        ForeColor="Red" AutoPostBack="True" 
                                        ontextchanged="txt_AmountDollar_TextChanged"></asp:TextBox>
                                   $&nbsp; <asp:TextBox ID="txt_AmountTK" runat="server" Width="90px" 
                                        Font-Bold="true" ForeColor="Red" AutoPostBack="True" 
                                        ontextchanged="txt_AmountTK_TextChanged"></asp:TextBox>
                                   TK
                                </td>
                            </tr>      
                            <tr>
                                 <td style="text-align:right;">
                                    <asp:Label ID="Label12" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_DistributionRemarks" runat="server" Width="220px" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
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
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                
                                 <td style="text-align:right;">
                                          
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
                                <td></td>
                                <td  >
                                    
                                </td>
                                
                            </tr>
                            <tr>
                            <td colspan="2">
                            <div style="overflow: scroll; color: White; border: 1px solid #C0C0C0;
                               height: 300px; width: 100%; margin-top: 5px;">
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
                                <asp:BoundField DataField="AccountHead" HeaderText="Account Head">
                                </asp:BoundField>
                                <asp:BoundField DataField="Rate" HeaderText="Rate" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AmountDollar" HeaderText="Amount($)">
                                </asp:BoundField>
                                <asp:BoundField DataField="AmountTk" HeaderText="Amount(Tk)">
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
                             <div style="width: 100%; float: right; display: inline block;">
                   
                    
                </div>
                        
                     </div> 
                   
                   <div style="width: 100%;clear:both;">
                   </div>
                    
                  </div>
                
                  </div>
                </div>
            </div>
        </center>
       
          <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_formName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_tableName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_InvoiceRow" runat="server" Value="0" />
        <asp:HiddenField ID="hid_DistributionRow" runat="server" Value="0" />
        <asp:HiddenField ID="hid_ExpenseRow" runat="server" Value="0" />
        <asp:HiddenField ID="hid_autoId" runat="server" Value="True" />
        <asp:HiddenField ID="hid_CostingHead_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Currency_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Supplier_Id" runat="server" Value="0" />
        <asp:HiddenField ID="hid_Addmode" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Addmode_Distribution" runat="server" Value="Y" />
        <asp:HiddenField ID="hid_Addmode_Expense" runat="server" Value="Y" />
        
        
    </div>
</asp:Content>




