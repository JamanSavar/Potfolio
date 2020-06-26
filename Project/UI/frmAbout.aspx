<%@ Page Language="C#" MasterPageFile="~/UI/frmMasterPage.master" AutoEventWireup="true" CodeFile="frmAbout.aspx.cs" Inherits="UI_frmAbout" Title="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
     
<div id="about">
     <table cellpadding="0" cellspacing="0" border="0" width="100%">
     <colgroup>
        <col width="30%"/>
        <col width="70%"/>          
     </colgroup>
     
     <tr>
      
      <td style="padding-top:100px; padding-bottom:50px"> <%--  Left Site --%>
      <div class="left-colum">
      <div class="photoFrame"> 
        <strong class="experience">Comleted<br/>8 Year in this<br/>web world</strong>
        <strong class="livingin">Living in<br/>Savar<br/>dhaka</strong> 
        <strong class="jobTitle">Web Designer<br/>Frontend<br/>developer</strong>
        <div class="photo"></div>
      </div>
    </div>
      
      </td>

      <td style="padding-top:100px; padding-bottom:50px"> <%--  Right Site  --%>
             
         <div class="right-colum">
          <div style="text-align: left">
      <h1>I'm Jaman, Web UI Designer and Developer.</h1>
        <p> Originally i am from the gods own country (Dhaka, 
            Bangladesh), I'm passionate about building simple, clean Websites and User Interfaces that are easy to use and beautiful to look at.
             I do web design (Responsive) from the scratch including logo, beautiful website design, W3C Valid HTML5, W3C Valid CSS3, iPhone/iPad/Android UI Design and anything that's creative.
            <br/>
            <br/>
             I can help convert your Photoshop design (PSD) into well-written SEO friendly XHTML/HTML5 and CSS3 code that's clean, pixel perfect and meets current world standards.
        </p>
        </div>

          <div id="follow"> 
            <%--<a class="circle"> <span class="process">IDEA<br/>+<br/>DESIGN</span> </a>--%> 
            <a class="circle"> <span class="process">HTML</span> </a> 
            <a class="circle"> <span class="process">CSS</span> </a> 
            <a class="circle"> <span class="process">JQUERY</span> </a> 
            <a class="circle"> <span class="process">SEO</span> </a>
            <a class="circle"> <span class="process">ASP.NET</span> </a>
            <a class="circle"> <span class="process">SQL</span> </a>
        </div>

          <div class="skills">  
         <img  src="../images/skills.png" alt="Skills" />
      </div>
      </div>

      </td>

     </tr>
     </table>
     </div>

</asp:Content>


