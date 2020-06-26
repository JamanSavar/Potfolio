<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_DashBoard.aspx.cs" Inherits="Common_DashBoard"
    Title="DashBoard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="master_content" ContentPlaceHolderID="head" runat="Server">

    <script language="javascript" type="text/javascript" src="../../Forms/Constants/Javascript/SharedValidationFunction.js"></script>
 <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    
    <script language ="javascript" >
        var tmp;
        function Page_Load() {
            tmp = setTimeout("callitrept()", 2000);
        }
        function callitrept() {
            document.getElementById("btn_refresh").click();
        }
    </script>
    

    <style type="text/css">
        .style1
        {
            height: 38px;
        }
    </style>
</asp:Content>
<asp:Content ID="Personal_content" ContentPlaceHolderID="mainContent" runat="Server">
    <div style="background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;">
        <center>        
            <div style="width: 100%;background-color: #969696; border: 1px solid #C0C0C0;">                
                <div style="width: 99%;">
                <%--Left--%>
                <%--<div style="width: 30%;background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;float:left;height:200Px;">--%>
                <div style="width: 12%;color: White; float:left;height:600Px;font-size:10px;">
                     <%--HR--%>
                     <div style="width: 100%;background-color: #132538; color: White; border: 2px solid #C0C0C0; float:left;clear:both;">
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;background-color:Maroon;">*** HR STATUS</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Employee </p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">900</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Present</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">800</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Absent</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">30</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Leave</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">70</p>                        
                     </div>
                     <%--/HR--%>
                     <%--Finance--%>
                     <div style="width: 100%;background-color: #132538; color: White; border: 2px solid #C0C0C0;margin-top:10px; float:left;clear:both;">
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;background-color:Maroon;">*** FINANCIAL STATUS</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">BANK </p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">900</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">CASH</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">800</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Liability</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">30</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Receivable</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">70</p>                        
                     </div>
                     <%--/Finance--%>
                     <%--Inventory--%>                     
                     <div style="width: 100%;background-color: #132538; color: White; border: 2px solid #C0C0C0;margin-top:10px; float:left;clear:both;">
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;background-color:Maroon;">*** INVENTORY STATUS</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">BANK </p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">900</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">CASH</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">800</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total stock</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">30</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Receivable</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">70</p>                        
                     </div>
                     <%--/Inventory--%>
                     <%--Notice--%>                                    
                     <div style="width: 100%;background-color: #132538; color: White; border: 2px solid #C0C0C0;margin-top:10px; float:left;clear:both;">
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;background-color:Maroon;">*** NOTICE</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">BANK </p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">900</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">CASH</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">800</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total stock</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">30</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">Total Receivable</p>
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;">70</p>                        
                     </div>
                     <%--/Notice--%>
                     
                </div>
                <%--/Left--%>
                <%--Right--%>
                <div style="width: 87%;background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;float:right;">            
                     <%--Marchandising--%>     
                     <div style="width: 100%;background-color: #132538; color: White; border: 2px solid #C0C0C0;float:left;clear:both;">
                        <p style="width: 100%;border-bottom:1px solid; font-weight:bold;background-color:Maroon;">*** Order Status</p>
                     </div>                
                     <div style="overflow: scroll; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;
                        width: 100%;height:590Px; margin-top: 5px; ">
                        <asp:GridView ID="gdv_costingHead" runat="server" Style="width: 100%; margin-left: 0px;" AutoGenerateColumns="False" Font-Size="10px"
                            HeaderStyle-CssClass="gridViewHeaderStyle" AlternatingRowStyle-CssClass="gridViewAlternateRowStyle"
                            CssClass="gridViewStyle" OnRowDataBound="gdv_costingHead_RowDataBound" OnSelectedIndexChanged="gdv_costingHead_SelectedIndexChanged">
                            <RowStyle HorizontalAlign="Center" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" HeaderStyle-CssClass="hidGridColumn" ItemStyle-CssClass="hidGridColumn" />
                                <asp:TemplateField HeaderText="SL#">
                                <ItemTemplate>
                                <%# Container.DisplayIndex + 1 %>
                                </ItemTemplate>
                                </asp:TemplateField>                                
                                <asp:BoundField DataField="trDate" DataFormatString="{0:d}" HeaderText="Date">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="BuyerName" HeaderText="Buyer Name">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="OrderNo" HeaderText="Order">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="StyleNo" HeaderText="Style">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Export_Item" HeaderText="Garment Type">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Color" HeaderText="Color">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Qty" HeaderText="Qty">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Unit" HeaderText="Unit">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Rate" HeaderText="Rate">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="Amount" HeaderText="Amount">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="ShipDate" HeaderText="Ship Date">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="ShipMode" HeaderText="Ship Type">
                                </asp:BoundField>                               
                                <asp:BoundField DataField="trStatus" HeaderText="Status">
                                </asp:BoundField>                          
                                <asp:BoundField DataField="trUser" HeaderText="User">
                                </asp:BoundField>                          
                                <asp:BoundField DataField="trCompany" HeaderText="Company">
                                </asp:BoundField>
                            </Columns>
                            <SelectedRowStyle CssClass="gridViewSelectedRowStyle"></SelectedRowStyle>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <AlternatingRowStyle CssClass="gridViewAlternateRowStyle"></AlternatingRowStyle>
                        </asp:GridView>
                    </div>
                     <%--/Commercial--%>
                </div>
                <%--/Right--%>
                
                <div style="clear:both;"></div>
                </div>                
            </div>
            
            
            
            
            <%--Old--%>
            
            <div style="width: 100%;background-color: #969696; border: 1px solid #C0C0C0; visibility:collapse;">
                <div style="width: 98%;">
                    <div style="width: 100%; height: 12%;">
                        <p id="P_Header_Leavel" runat="server" class="headerstyle" style=" padding-top: 7px;  text-align:right; color:Maroon;">
                           Dash Board
                        </p>
                    </div>
                    
                </div>
                <div style="width: 85%; background-color: #2f2f2f; color: White; border: 1px solid #C0C0C0;">
                    <div style="width: 100%; float: left;">
                        <table style="text-align: left;  float: left; padding-top: 10px;  padding-left: 10px;">
                            <tr>
                                <td style="width: 110px;">
                                    <asp:Label ID="lbl_GroupName" runat="server" Text="Expense Head :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_GroupName" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
     
                    <div style="width: 100%;">
                        <table style="text-align: left; float: left; padding-left: 10px;">
                            <tr>
                                <td style="width: 110px;">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btn_save" runat="server" CssClass="standardButton" Text="Save" OnClick="btn_save_Click" />
                                    <asp:Button ID="btn_refresh" runat="server" Text="Refresh" CausesValidation="false"
                                        CssClass="standardButton" OnClick="btn_refresh_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    
                </div>      
                        
            </div>
        </center>
        <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_formName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_tableName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_autoId" runat="server" Value="True" />
    </div>
</asp:Content>
