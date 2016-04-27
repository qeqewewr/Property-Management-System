<%@ Page Title="留言回复" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" Debug ="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/TableStyle.css" rel="Stylesheet" type="text/css" />
<link href="css/MessageStyle.css" rel="Stylesheet" type="text/css" />


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script type="text/javascript">
function gotoPage(pagenum){
	var url = 'Message.aspx?pageno=';
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
<div class="box3_t"><a href="Index.aspx">首页</a>&nbsp;»&nbsp;查看留言</div>
<div class="box3_m">

<!--
<table class="gv" cellspacing="0" rules="all" border="1" style="width:100%;border-collapse:collapse;" >
  <tbody>
    <tr class="gvHeader">
      <th scope="col">留言日期</th>
      <th scope="col">留言</th>
      <th scope="col">回复日期</th>
      <th scope="col">回复</th>
    </tr>
    <%for (int i = 0, k = 0; i < messReplyList.Count; i++)
      {
       
    %>
    <tr <%if(i % 2 == 0){ %>class="gvRow" style="color:#4A3C8C;background-color:#E7E7FF;" <%}else{ %>class="gvAlternatingRow" style="color:#4A3C8C;background-color:#F7F7F7;"<%} %> >
    
      <td valign="top" style="width:90px;padding-bottom:10px;"><%=messReplyList[i].LeaveTime.ToShortDateString()%></td>
      <td valign="top"  align="left" style="width:235px;padding-bottom:10px;"><a href = "MessageDetail.aspx?id=<%=messReplyList[i].Id %>&pageno=<%=page.PageNo %>"><%=GetContent(messReplyList[i].LeaveMessage)%></a></td>
      <td valign="top"  style="width:90px;padding-bottom:10px;"><%=messReplyList[i].ReplyTime.ToShortDateString()%></td>
      <td valign="top"  align="left" style="width:235px;padding-bottom:10px;"><%=GetContent(messReplyList[i].Reply)%></td>
    </tr>
    <%  
     }
    %>
    
  </tbody>
</table>

-->
 <%for (int i = 0, k = 0; i < messReplyList.Count; i++)
   {  
 %>
    <div class="yiques">
    <div class="yi01">
        <div class="yiq">&nbsp;&nbsp;&nbsp; 发表人：游客&nbsp;&nbsp;&nbsp;&nbsp;<%=messReplyList[i].LeaveTime%></div>
        <div class="yiq01"><%=messReplyList[i].LeaveMessage%></div>
        <div  class="yia">
        <font color="#565656">管理员回复：<%=messReplyList[i].Reply%></font>
            <br />
            <br />
        </div>
    </div>
    </div>
<%}%>
<div class="newslist-page">
		
<div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
			<tr style="border:0px;">
				<td style="border:0px;">
					<span>[总数:<%=page.RowCount%>条]</span> <span>[每页:<%= page.PageSize %>条]</span> [页次:<font title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo %></font>/<%= page.PageCount %>]
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



<div id="leaveMessage">
    <div class="start">留言：</div>
    <div id="letter">
    
        <textarea name="Message" rows="9" cols="25" id="Message" class="messageTextbox" style="height:105px;width:100%;overflow:auto"></textarea> 
        <div id="saveButton">
            <input type="submit" name="ctl00$Save" class="saveMessageBtn"  value="提交留言" id="SaveMessageBtn"  />
        </div>
    </div>
   </div>

 <script type="text/javascript">
 $("#SaveMessageBtn").click(function(){
 	var url = 'SaveMessage.aspx';
	var content = $("#Message").val();
	if(content == '' )
	{
		alert('留言内容不能为空，请重新输入！');
		return false;
	}
	$.post(url,{Message:content},function(d){
		if(d == 'success')
		{
			alert('留言成功,请等待管理员审核!');
			window.location.reload();
		}
	});
	return false;
 });

 </script>
  </div> 

</asp:Content>

