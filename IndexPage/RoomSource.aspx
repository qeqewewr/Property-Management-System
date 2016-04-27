<%@ Page Title="房源信息" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true" CodeFile="RoomSource.aspx.cs" Inherits="RoomSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/TableStyle.css" rel="Stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script>
function gotoPage(pagenum){
	var url = 'RoomSource.aspx?pageno=';
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
<div class="box3_t"><a href="index.aspx">首页</a>&nbsp;»&nbsp;房源信息</div>
<div class="box3_m">


<table class="gv gv1" cellspacing="1" rules="all" border="1" style="width:99%;">
  <tbody>
    <tr class="gvHeader">
      <th scope="col">楼宇</th>
      <th scope="col">房间号</th>
      <th scope="col">楼层</th>
      <th scope="col">面积/平方米</th>
   
      <th scope="col">租金(月/平方米)</th>
      <th scope="col">朝向</th>
      <th scope="col">装修情况</th>
      <th scope="col">最短租期/月</th>
    </tr>
    <%for (int i = 0; i < roomList.Count; i++)
      { %>
    <tr <%if(i % 2 == 0){ %>class="gvRow" style="color:#4A3C8C;background-color:#E7E7FF;text-align:center;" <%}else{ %>class="gvAlternatingRow" style="color:#4A3C8C;background-color:#F7F7F7;text-align:center;"<%} %>   >
      <td><%=roomList[i].BuildingName%></td>
      <td><%=roomList[i].Number %></td>
      <td style="width:50px;"><%=roomList[i].Floor %></td>
      <td><%=roomList[i].Area %></td>
  
      <td><%=roomList[i].Rent %></td>
      <td style="width:50px;"><%=roomList[i].Toward %> </td>
      <td><%=roomList[i].Decoration %></td>
      <td><%=roomList[i].MinLease %></td>
    </tr>
    <%} %>
	
 

  </tbody>
</table>

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

