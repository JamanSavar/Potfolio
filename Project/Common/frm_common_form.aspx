<%@ Page Language="C#" MasterPageFile="~/Forms/Accounts/frm_MasterPage.master" AutoEventWireup="true"
    CodeFile="frm_common_form.aspx.cs" Inherits="Forms_Accounts_frm_common_form"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">


        //to navigate modal window
        window.onbeforeunload = function()
        {
            //              if ((window.event.clientX < 0) || (window.event.clientY < 0)) {
            window.returnValue = true;

            //              }
        }
          
    </script>

</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="mainContent" runat="Server">
    <div style="height: 460px; background-color: #2f2f2f; color:White; border: 1px solid #C0C0C0;">
        <center>
            <div style="width: 50%; height: 459px; background-color: #969696; border: 1px solid #C0C0C0;">
                <div style="width: 85%; height: 40%;">
                    <p id="P_Header_Leavel" runat="server" class="headerstyle">
                        Employee Level Assign</p>
                  
                    <div style="width: 100%; height: 85%;background-color: #2f2f2f; color:White; border: 1px solid #C0C0C0;
                        float: left;">
                        <asp:Table ID="tbl_commonForm" runat="server" Style="width: 90%; float: left; text-align: left;"
                            OnDataBinding="btn_save_Click">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label1" runat="server" Text="L1 :"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txt_1stColumn" runat="server" Width="88%"></asp:TextBox>
                                  
                                    <asp:RequiredFieldValidator ID="mustValidate_1stColumn" Text="*" ErrorMessage="*"
                                        Enabled="true" ControlToValidate="txt_1stColumn" runat="server"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label2" runat="server" Text="L1 :"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txt_2stColumn" runat="server" Width="88%"></asp:TextBox>
                                  
                                    <asp:RequiredFieldValidator ID="mustValidate_2stColumn" Text="*" ErrorMessage="*"
                                        Enabled="true" ControlToValidate="txt_2stColumn" runat="server"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label3" runat="server" Text="L1 :"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txt_code" runat="server" Width="88%"></asp:TextBox>
                                   
                                    <asp:RequiredFieldValidator ID="mustValidate_txt_code" Text="*" ErrorMessage="*"
                                        Enabled="true" ControlToValidate="txt_code" runat="server"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label4" runat="server" Text="L1 :"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txt_serialNo" runat="server" Width="88%"></asp:TextBox>
                               
                                    <asp:RequiredFieldValidator ID="mustValidate_txt_serialNo" Text="*" Enabled="true"
                                        ErrorMessage="*" ControlToValidate="txt_serialNo" runat="server"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                        
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:CheckBox ID="chk_active" runat="server" Text="Active" Checked="true" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                        
                                </asp:TableCell>
                                <asp:TableCell>
                       
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                        
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btn_save" Text="Save" CssClass="standardButton" runat="server" OnClick="btn_save_Click" />
                                    <asp:Button ID="btn_remove" Text="Remove" CssClass="standardButton" OnClick="btn_remove_Click"
                                        runat="server" />
                                    <asp:Button ID="btn_refresh" Text="Refresh" CssClass="standardButton" runat="server"
                                        OnClick="btn_refresh_Click" CausesValidation="False" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                        
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </div>
                <div style="width: 85%; height: 55%;">
                    <div style="overflow: scroll; background-color: #2f2f2f; color:White; border: 1px solid #C0C0C0;
                        height: 95%; width: 100%; margin-top: 5px; margin-bottom: 5px;">
                        <asp:GridView ID="gdv_commonForm" runat="server" Style="width: 100%;" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="gridViewHeaderStyle" OnRowDataBound="gdv_commonForm_RowDataBound"
                            AlternatingRowStyle-CssClass="gridViewAlternateRowStyle" SelectedRowStyle-CssClass="gridViewSelectedRowStyle"
                            CssClass="gridViewStyle" OnSelectedIndexChanged="gdv_commonForm_SelectedIndexChanged">
                            <RowStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </center>
        <asp:HiddenField ID="hidIsInsertMode" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_formName" runat="server" Value="True" />
        <asp:HiddenField ID="hid_s_tableName" runat="server" Value="True" />
    </div>
</asp:Content>
