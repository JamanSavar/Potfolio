<%@ Page Language="C#" MasterPageFile="~/UI/frmMasterPage.master" AutoEventWireup="true" CodeFile="frmHome.aspx.cs" Inherits="UI_frmHome" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<div id="HomeContainerBg">
    <div id="Home">
     <table cellpadding="0" cellspacing="0" border="0" width="100%">
     <colgroup>
        <col width="50%"/>
        <col width="50%"/>          
     </colgroup>
     
     <tr>
     <td valign="top" style="padding-top:100px; padding-bottom:100px">
      
    
    <div class="left-colum">    <%-- Left Site--%>
      <p> Beautiful Design,
        <br/>
        W3C Valid XHTML,
        <br/>
        W3C Valid CSS,
        <br/>
        Table-less CSS, markup
        <br/>
        <span> Compatible with<br/>
        Firefox,Chrome,Opera, Safari<br/>
         </span>
        </p>
      <strong class="illustrator"> Illustrator </strong> 
      <strong class="photoshop"> Photoshop </strong> 
      <strong class="flash"> Flash </strong> 
      <strong class="html"> HTML/CSS </strong> 
      <strong class="javascript"> Javascript </strong> 
      <strong class="jQuery"> jQuery </strong> 
      <strong class="php"> PHP </strong>
    </div>

    </td>

    <td valign="top" style="padding-top:100px; padding-bottom:10px">
    
      <div class="right-colum">   <%-- HomePage Right Site--%> 
      <a href="#contact" class="scroll designer"> <em>Interface</em><br/>Designer </a>
      <a href="#contact" class="scroll developer"> <em>HTML5/CSS3</em><br/>Developer </a>
      <div class="hello">Hello</div>
      <div class="article">I&#39;m Jaman, Web UI Designer &amp; Developer Based in Bangladesh.</div>
    </div>
    </td>


    </tr>
    </table>
  
    </div>
   </div>
</asp:Content>

