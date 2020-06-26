<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage_Report.master"
    AutoEventWireup="true" CodeFile="frm_ReportViewer_SubReport.aspx.cs" Inherits="frm_ReportViewer_SubReport" Title="Inventory Management Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="Server">
   
    
     <div id="div_reportViewerHolder"  runat="server" style="height: auto; width: 1110px;
         position: relative; background-color:White;  z-index: 0; ">
        <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
        <div style="width: 100%; height: 100%; background-color: White; overflow:scroll;">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  
                HasRefreshButton="True" Width="1110px" Height="1110px" OnInit="CrystalReportViewer1_Init" />
     </div>
        
        
    </div>
    
</asp:Content>
