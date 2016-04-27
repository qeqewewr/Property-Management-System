<%@ Page Title="租赁手续" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true" CodeFile="RentProcedure.aspx.cs" Inherits="RentProcedure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="box3">
<div class="box3_t"><a href="Index.aspx">首页</a>&nbsp;»&nbsp;租赁手续</div>
<div class="box3_m">
<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
<tr><td height="100%" valign="top">
<div style="margin-top:10px; margin-left:15px;">
<%if (IsExist)
  { %>
    <%= rentPro.LeaseContent%>
<%} %>

    </div>
    </td></tr>
</table>
</div>
</asp:Content>

