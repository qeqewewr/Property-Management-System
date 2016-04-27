<%@ Page Title="光大物业" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true" CodeFile="PropertyIntroduction.aspx.cs" Inherits="PropertyIntroduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/PropertyIntroduction.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="box3">
<div class="box3_t"><a href="index.aspx">首页</a>&nbsp;»&nbsp;光大介绍</div>

  <div class="box3_m">
	

<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
<%if (IsExist)
  { %>
<tr><td height="100%" valign="top">
<div style="margin-top:20px; margin-left:15px;">
    <%--a<sp:Label ID="labelMessage" runat="server"></asp:Label>
    <div class="line">联系地址：<asp:Label ID="address" runat="server"></asp:Label></div>
    <div class="line">联系电话：<asp:Label ID="telephone" runat="server"></asp:Label></div>
    <div class="line">电子邮箱：<asp:Label ID="email" runat="server"></asp:Label></div>	--%>
    <%= intro.Introduction %>
    <div class="line">联系地址：<%=intro.Address %></div>
    <div class="line">联系电话：<%=intro.Telephone %></div>    
    <div class="line">电子邮箱：<%=intro.Email %></div>
    </div>
    </td></tr>
<%} %>
</table>
</div>
  </div>
</asp:Content>

