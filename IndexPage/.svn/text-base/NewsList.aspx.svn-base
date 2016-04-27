<%@ Page Title="光大动态" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="IndexPage_NewsList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/TableStyle.css" rel="Stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="../Webmag/CSS/webmag.css"/> 
	<script type="text/javascript" src="../Webmag/Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../Webmag/Scripts/webmag.js"></script>
   

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script>
function gotoPage(pagenum){
	var url = 'NewsList.aspx?pageno=';
	window.location.href = url + pagenum;
} 

function testAndGotoPage(pagenum,pageno,pagecount){
var p =/^\d+$/;
if(!p.test(pagenum)){
alert(pagenum+" 不是数字，请输入正整数");
return;
}else if(pagenum==pageno){
return;
}else{
if(pagenum>pagecount){
pagenum=pagecount;
}else if(pagenum==0){
pagenum=1;
}
gotoPage(pagenum);
return;
}
return;
} 

</script>
    <div class="box3">
			<div class="box3_t"><a href="Index.aspx">首页</a>&nbsp;»&nbsp;光大动态</div>
			<div class="box3_m">
            
<ul class="newslist">
<%for (int i = 0; i < newsList.Count; i++)
  { %>  

<li><span class="news-content"><a href="ShowNews.aspx?pageno=<%=pageno %>&id=<%= newsList[i].ID %>" title="<%=newsList[i].Title %>"><%=newsList[i].Title%></a></span>
<span class="news-time">
	<%=((DateTime)newsList[i].PublishTime).ToShortDateString()%>
</span>
</li>
<%} %>

</ul>

<div class="newslist-page">
		
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
			<tr style="border:0px;">
				<td style="border:0px;">
					<span>[总数:<%=page.RowCount %>条]</span> <span>[每页:<%= page.PageSize %>条]</span> [页次:<font title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo %></font>/<%= page.PageCount %>]
				</td> 
				<td align="right"  style="border:0px;">
                    <%if (page.PageNo == 1)
                        { %>
                        <font title="首页">首页</font> <font title="前一页">前一页</font>
                    <%}
                        else
                        {%>
							<a href="javascript:gotoPage(1)"><font title="首页">首页</font></a> <a href="javascript:gotoPage(<%= page.PrePage %>)"><font title="前一页">前一页</font></a>
					<%} %>
                    <%if (page.PageNo == page.PageCount)
                        { %>
                            <font title="下一页">下一页</font> <font title="最后一页">最后一页</font>
                    <%}
                        else
                        {%>
							<a href="javascript:gotoPage(<%= page.NextPage %>)"><font title="下一页" >下一页</font></a> <a href="javascript:gotoPage(<%= page.PageCount %>)"><font title="最后一页">最后一页</font></a>

					<%} %>
		
					跳到
				<input type="text"  style="width:20px" name="pageno1" id="pageno1" value="<%= page.PageNo %>"   />
				页  <a href="javascript:testAndGotoPage(document.getElementById('pageno1').value,<%= page.PageNo %>,<%= page.PageCount %>)"><font title="GO">GO</font></a>
				</td>
				<td style="width:15px;"></td> 
			</tr>
		</table> 
    
    </div>

	</div>
    
            </div>
	</div>

</asp:Content>
