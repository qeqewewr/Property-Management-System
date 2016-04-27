<%@ Page Title="光大动态" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true"  CodeFile="ShowNews.aspx.cs" Inherits="IndexPage_ShowNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/TableStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div class="box3">
		<div class="box3_t"><a href="Index.aspx">首页</a>&nbsp;»&nbsp;<a href="NewsList.aspx?pageno=<%=pageno %>">光大动态</a>&nbsp;»&nbsp;<!--<%=news.Title %>--></div>
		<div class="box3_m">
	
            <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                <tr><td height="100%" valign="top">
                <div style="margin-top:20px; margin-left:15px;">
                    <div class="news-title " style="text-align:center"><%=news.Title %></div>
                    <div class="news-time" style="text-align:center"><%=((DateTime)news.PublishTime).ToShortDateString()%></div>
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

                    <div class="news-content"><%=news.Body %></div>
                    
                 </div>
                 </td>
               </tr>
            </table>
            </div>
	</div>

</asp:Content>