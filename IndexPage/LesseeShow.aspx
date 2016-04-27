<%@ Page Title="企业宣传" Language="C#" AutoEventWireup="true" MasterPageFile="~/IndexPage/master/IndexMaster.master" CodeFile="LesseeShow.aspx.cs" Inherits="IndexPage_LesseeShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/LesseeAD.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="box3">
        <div class="box3_t">
            <a href="Index.aspx">首页</a>&nbsp;»&nbsp;<a href="LesseeAD.aspx?pageno=<%=pageno %>">企业特色</a>&nbsp;»&nbsp;<%=firm.Lessee %></div>
        <div class="box3_m">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" align="left">
                <tr><td height="100%" valign="top">
                <div style="margin-top:20px; margin-left:15px;">
                    <div class="news-title" style="text-align:center"><%=firm.Lessee %></div>
                    <div>
                    <center>
                         <%  int i;
                             for (i = 0; i < imagelist.Count; i++)
                             { %>
                            <img width="150" height="150" border="0" src = "../webmag/attachment/<%=pageBLL.GetFileName(imagelist[i].AttachUrl) %>"/>   
                              <% if (i % 2 != 0)
                               {%>   
                                 <br/>
                               <%}
                             } %>
                       </center>
                    </div>             
                    <div class="news-content"><%=firm.Describe %></div>
                    
                 </div>
                 </td>
               </tr>
            </table>


        </div>
    </div>

</asp:Content>
