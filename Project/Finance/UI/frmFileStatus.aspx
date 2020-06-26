<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="frmFileStatus.aspx.cs" Inherits="Finance_UI_frmFileStatus" Title="File Status" %>


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
            <div style="width: 100%;background-color: #969696; border: 1px solid #C0C0C0; clear:both;">
                <div style="width: 50%;  clear:both;">
                    <div style="width: 100%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style="padding-top: 7px;  text-align:right; color:Maroon;">
                         File Status Setting
                        </p>
                    </div>                    
                </div>   
                <div style="width: 50%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0; clear:both;">                
             
                <div style="width: 95%;border:1px solid white; margin-top:20px;  text-align:left; background-color:  #1b4f72;">                
                    
                           <div style="width: 100%; text-align: center;  margin-top:10px; margin-bottom:10px; display:inline block;">                   
                                  <table style="text-align: left; width: 100%;">
                                        <colgroup>
                                            <col width="30%" />
                                            <col width="40%" />
                                            <col width="30%" />
                                        </colgroup>
                                      
                                        <tr>
                                            <td style="text-align: right; font-size: 12px;">
                                                <asp:Label ID="Label22" runat="server" Text="Buyer :"></asp:Label>
                                            </td>
                                            <td>
                                                  <asp:DropDownList ID="dd_Buyer" Enabled="false"  runat="server" Width="100%"  onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                            </asp:DropDownList>
                                            </td>
                                            <td>
                                                
                                            </td>
                                           
                                        </tr>
                                      
                                      <tr>
                                            <td style="text-align: right; font-size: 12px; ">
                                                <asp:Label ID="Label24" runat="server" Text="File No :"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                   <asp:DropDownList ID="dd_File"  Enabled="false" runat="server" Width="100%" onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                        onblur="this.style.backgroundColor='white'">
                                                    </asp:DropDownList>
                                            </td>
                                            <td>
                                                 
                                                
                                            </td>
                                 
                                        </tr>
                                         <tr>
                                            <td style="text-align: right; font-size: 12px;">
                                                <asp:Label ID="Label1" runat="server" Text="Status :"></asp:Label>
                                            </td>
                                            <td>
                                                  <asp:DropDownList ID="dd_Status" runat="server" Width="100%"   onfocus="disableautocompletion(this.id); this.style.backgroundColor='#ffff80'"
                                                onblur="this.style.backgroundColor='white'">
                                            </asp:DropDownList>
                                            </td>
                                            <td>
                                                
                                            </td>
                                           
                                        </tr>
                                         <tr>
                                        <td  colspan="3";  style="text-align: center;">
                                             <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                        </td>
                                        </tr>
                                                                                
                                        <tr>
                                             <td  colspan="3";  style="text-align: center;">
                                          <asp:Button ID="btn_save" runat="server" CssClass="standardButton" Text="Save" OnClick="btn_save_Click" />
                                            </td>
                                        </tr>
                                    </table>                    
                             </div>       
                           
                          <div style="width: 100%;  margin-top:20px;  display:inline block;">
                           
                            <div style="overflow: scroll; height: 450px; border: 1px solid #C0C0C0;  clear: both;">
                                        
                              <asp:GridView ID="gdv_Fabric" runat="server" Style="width: 100%; margin-left: 0px;"
                                    AutoGenerateColumns="False" HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                                    CssClass="gridViewStyle" OnRowDataBound="gdv_Fabric_RowDataBound" OnSelectedIndexChanged="gdv_Fabric_SelectedIndexChanged">
                                    <RowStyle HorizontalAlign="Center" />
                                    
                                <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />


                                <asp:BoundField DataField="Buyer_Id" HeaderText="Buyer_Id" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                                
                                <asp:BoundField DataField="Buyer" HeaderText="Buyer" ItemStyle-HorizontalAlign="Left">
                                </asp:BoundField>
                                
                               <asp:BoundField DataField="File_Ref_Id" HeaderText="File_Ref_Id" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                                
                               
                                <asp:BoundField DataField="File_Ref_No" HeaderText="File No" ItemStyle-HorizontalAlign="Left">
                                </asp:BoundField>
                                
                                <asp:BoundField DataField="Status_Id" HeaderText="Status_Id" HeaderStyle-CssClass="hidGridColumn"
                                    ItemStyle-CssClass="hidGridColumn">
                                    <HeaderStyle CssClass="hidGridColumn"></HeaderStyle>
                                    <ItemStyle CssClass="hidGridColumn"></ItemStyle>
                                </asp:BoundField>
                               
                               
                                <asp:BoundField DataField="trStatus" HeaderText="Status">
                                </asp:BoundField>
                                
                                
                             
                                   
                            </Columns>
                                <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                            </asp:GridView>                           
                               </div> 
                            </div>                                         
                            
                        
                      
                </div>
                   
           
                </div>
            </div>
        </center>
         
        <asp:HiddenField ID="hid_autoId" runat="server" Value="" />
        
    </div>
</asp:Content>




