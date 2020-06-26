<%@ Page Language="C#" MasterPageFile="~/UI/frmMasterPage.master" AutoEventWireup="true" CodeFile="frmContact.aspx.cs" Inherits="UI_frmContact" Title="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">


<div id="contact">
     <table cellpadding="0" cellspacing="0" border="0" width="100%" style="table-layout: fixed">
        <colgroup>
            <col width="45%"/>
            <col width="55%"/>                 
        </colgroup>

     <tr>
        <td valign="top" style="padding-left:20px; padding-top:100px">
           <div class="left-colum">
           <table cellpadding="0" cellspacing="0" border="0" width="100%" style="table-layout: fixed">
           <tr>
           <td align="left">
            <h2>Drop me a line...</h2>
           </td>
           </tr>

           <tr>
           <td align="left" style="padding-top:6px; padding-bottom: 6px">   
           Name :
           </td>
           </tr>
           <tr>
           <td style="padding-right: 10px; padding-top:6px; padding-bottom: 6px">                            
            <asp:TextBox ID="txtName" runat="server" CssClass="textboxCSS" Width="80%" TabIndex="1"></asp:TextBox>
           </td>
           </tr>

           <tr>
           <td align="left" style="padding-top:6px; padding-bottom: 6px">   
           Email :
           </td>
           </tr>
           <tr>
           <td style="padding-right: 10px; padding-top:6px; padding-bottom: 6px">                            
            <asp:TextBox ID="txtEmail" runat="server" CssClass="textboxCSS" Width="80%" TabIndex="2"></asp:TextBox>
           </td>
           </tr>
           <tr>
           <td align="left" style="padding-top:6px; padding-bottom: 6px">   
           Subject :
           </td>
           </tr>
          
           <tr>
           <td style="padding-right: 10px; padding-top:6px; padding-bottom: 6px">                            
            <asp:TextBox ID="txtSubject" runat="server" CssClass="textboxCSS" Width="80%" TabIndex="3"></asp:TextBox>
           </td>
           </tr>

           <tr>
           <td align="left" valign="top" style="padding-top:6px; padding-bottom: 6px">   
           Message :
           </td>
           </tr>

           <tr>
           <td style="padding-right: 10px; padding-top:6px; padding-bottom: 6px">                            
            <asp:TextBox ID="txtMessage" runat="server" CssClass="textboxCSS" Width="80%" Height="100px" TextMode="MultiLine" TabIndex="4"></asp:TextBox>
           </td>
           </tr>


           <tr>
           <td style="padding-right: 10px; padding-top:6px; padding-bottom: 6px">                            
           <asp:Label ID="lblMsg" runat="server" CssClass="standardlabel"></asp:Label>
           </td>
           </tr>

            <tr>
           <td style="padding-right: 10px; padding-top:6px; padding-bottom: 6px">                            
            
            <asp:Button ID="btn_save" runat="server" CssClass="standardButton" Text="Save" OnClick="btn_save_Click" />

           </td>
           </tr>


           </table>
           </div>
        </td>
        <td valign="top" style="padding-left:20px; padding-top:100px">
           <div class="right-colum">
           <table cellpadding="0" cellspacing="0" border="0" width="100%" style="table-layout: fixed">
           <tr align="left">
           <td>
           <h2>Lazy to fill the form ?</h2>
               <span class="email">Email: <a href="mailto:info@iamjaman.com"><strong>jaman2mail@gmail.com</strong></a></span>
               <span class="tel"><strong>  +88 01719 368485</strong></span>
               <span>Gtalk: <strong>jaman2mail</strong></span>
               <span>Skype: <strong>jaman2dhaka</strong></span>
          
           <div id="followme">
              
               <a class="circle facebook" href="https://www.facebook.com/savarJaman" target="_blank"> 
                    <span class="facebook">Facebook</span> <span class="followme">Friends?</span> </a> 
               <a class="circle in" href="https://www.linkedin.com/feed/" target="_blank"> 
                    <span class="in">Linkedin</span> <span class="followme">Conect?</span> </a> 
                <a class="circle twitter" href="http://twitter.com/rakesh_vk" target="_blank">
                    <span class="twitter">Twitter</span> <span class="followme">Follow me</span> </a>      
               <a class="circle orkut" href="http://www.orkut.com/Main#Profile?uid=11063790420624188747"> 
                    <span class="orkut">Orkut</span> <span class="followme">Friends?</span> </a> 
               <a class="circle gplus" href="https://plus.google.com/u/0/101424918039133357683/posts" target="_blank"> 
                <span class="gplus">G+</span> <span class="followme">Friends?</span> </a>
           </div>
           </td>
           </tr>
           
           </table>
           </div>
        </td>
     </tr>
     </table>


</div>


</asp:Content>
