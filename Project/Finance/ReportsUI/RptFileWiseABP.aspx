﻿<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true" CodeFile="RptFileWiseABP.aspx.cs" Inherits="Finance_ReportsUI_RptFileWiseABP" Title="File Wise ABP" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .treeViewButton
        {
            /*width: 70px;*/
            width: 65px;
            text-align: center;
        }
        
        .marginTop
        {
        	 margin-top:3.3px;
        	}
    </style>
    <script type="text/javascript" language="javascript">
        function OpenChildWindowTree(modalpage, updateButton) 
        {
            //var checkValue = window.document.getElementById(GetClientId('HiddenField1')).value;
            var sFeatures = "dialogHeight: auto;";
            sFeatures += "dialogWidth: auto;";
            sFeatures += "center: yes;";
            sFeatures += "edge: sunken;";
            sFeatures += "scroll: yes;";
            sFeatures += "status: yes;";
            sFeatures += "resizeable: yes;";
            var url = modalpage;
            document.getElementById(GetClientId('btn_preview')).click();
            window.showModalDialog(url, 'frm_ledgerTree', sFeatures);
        }

        function printDiv() 
        {
            var divToPrint = document.getElementById(GetClientId('div_searchEmployee'));
            var newWin = window.open();
            newWin.document.open();
            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
            newWin.document.close();
            setTimeout(function() { newWin.close(); }, 10);
        }
        
    </script>
    
    
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
    <div style="background-color: Gray; border: 1px solid #C0C0C0;">
        <center>
            <div style="width: 50%;background-color: #2f2f2f; color: White; border: 1px solid Gray;">
                <div style="width: 85%;border: 1px solid #C0C0C0; background-color: #2f2f2f;
                    color: White;">                    
                    <p id="P1" runat="server" class="headerstyle">
                         &nbsp;</p>
                    <p id="P_Header_Leavel" runat="server" class="headerstyle">
                        ABP Statement Report</p>
                    <table style="background-color: #2f2f2f; color: White; padding: 0px; width: 100%;
                        text-align: left;">
                        
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
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px; text-align:right;">
                                <asp:Label ID="Label1" runat="server" Text="File No :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dd_File" runat="server" Width="300">
                                </asp:DropDownList>
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
                                &nbsp;
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
                                <asp:Button ID="btn_search" runat="server" CausesValidation="false" CssClass="standardButton" Width="100"
                                    Text="Preview" OnClick="btn_search_Click" />
                                <asp:Button ID="btn_refresh"   CssClass="marginTop" CausesValidation="false" runat="server" OnClick="btn_refresh_Click" Width ="100"
                                    Text="Refresh"  />
                                <input type="button" id="btn_preview" causesvalidation="false" runat="server" style="display: none"
                            onserverclick="testMethod"/>
                            </td>
                        </tr>
                    </table>
                </div>
                
            </div>
        </center>
        <asp:HiddenField ID="hid_FileId" runat="server" Value="" />
    </div>
</asp:Content>
