<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMessageReply.aspx.cs" Inherits="Webmag_Employe_BuildingSell_replymess_ViewMessageReply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	 <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/>
	<link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/> 
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>
    <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>
    <script type="text/javascript" src="../../../Scripts/util.js"></script>
    <script type="text/javascript">
        function changeAction() {
            var s = $("#searchStarttime").val();
            var e = $("#searchEndtime").val();
          
            var theDate, flag;
            //验证日期格式是否为yyyy/mm/dd
            if (s != "") {
                theDate = $.trim(s);
                flag = isdate(theDate);
                if (!flag) {
                    alert("您搜索的留言开始时间格式有误，请重新输入！");
                    $("#searchStarttime").focus();
                    return false;
                }
            }
            if (e != "") {
                theDate = $.trim(e);
                flag = isdate(theDate);
                if (!flag) {
                    alert("您搜索的留言结束时间格式有误，请重新输入！");
                    $("#searchEndtime").focus();
                    return false;
                }
            }

            $("#action").val("search");
            $("#keyword").val($("#searchStarttime").val());
            $("#endtime").val($("#searchEndtime").val());
        }

        $(function () {
            $("#search").focus();
        });

        jQuery(document).ready(function ($) {
            $('a[rel=facebox]').facebox();
        })

        $(function () {
            $('#searchStarttime').simpleDatepicker({ y: 20, x: -20 });
            $("#starttimeCalImg").bind('click', function () { $("#searchStarttime").click(); });
            $('#searchEndtime').simpleDatepicker({ y: 20, x: -20 });
            $("#endtimeCalImg").bind('click', function () { $("#searchEndtime").click(); });
            $('.saveBtn').click(function () {
                return checkForm();
            });
        });
	</script>
</head>

<body>

    <div style="width: 100%">
         
        <div class="queryArea"  style="width:100%">
            <form action="ViewMessageReply.aspx?pageno=1" name="searchForm" 
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="endtime" id="endtime" value="" />
                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 留言回复信息查询  </legend> 
					<span>留言开始时间：<input type="text" name="searchStarttime" id="searchStarttime" title="请输入查询开始时间"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;<img id="starttimeCalImg"  class="datepicker" src="../../../Images/cal.gif" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        结束时间 <input type="text" name="searchEndtime" id="searchEndtime" title="请输入查询结束时间"
						<%if (condition){%> value="<%=endtime %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;<img id="endtimeCalImg"  class="datepicker" src="../../../Images/cal.gif" />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>
			<table class="resultTable">

				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;留言回复列表：&nbsp;&nbsp;
                <span align="right">
			    </span>
				</caption>     
               
				<tr class="topTitle" align="center">
					<td align="center">选 择</td>
					<td align="center">编号</td>
					<td align="center">留言时间</td>
                    <td align="center">留言内容</td>
                    <td align="center">回复时间</td>
                    <td align="center">回复内容</td>
                    <td align="center">留言是否发布</td>
					<td align="center" colspan="2">操 作</td>
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                  
                  <input type="hidden" name="keyword"  value="<%=keyword %>" />
                  <input type="hidden" name="endtime"  value="<%=endtime %>" />

                <%for (int i = 0; i < messageReplyList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							<td><input type="checkbox" name="selectDel"
								value="<%= messageReplyList[i].Id %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
                                                                                                                                                                                      
							<td title="<%= messageReplyList[i].Id %>" ><%= messageReplyList[i].Id%></td> 
                            <td title="<%= messageReplyList[i].LeaveTime %>" ><%= messageReplyList[i].LeaveTime%></td>
                           <td title="<%= pageBLL.GetShrotInfo() %>"><a rel="facebox" href="facebox.aspx?id=<%=messageReplyList[i].Id %>&flag=0">点击查看详情</a></td> 
                             <td title="<%= messageReplyList[i].ReplyTime %>" ><%= messageReplyList[i].ReplyTime%></td>
                           <td title="<%= pageBLL.GetShrotInfo() %>"><a rel="facebox" href="facebox.aspx?id=<%=messageReplyList[i].Id %>&flag=1">点击查看详情</a></td> 
                              <td title="<%= pageBLL.TransformBooleanToChinese(messageReplyList[i].IsReplyed) %>" ><%=pageBLL.TransformBooleanToChinese(messageReplyList[i].IsReplyed)%></td>                  
                            <td><input type="button" value="" class ="replyBtn" title="回复"
								onclick="window.location.href='UpdateMessageReply.aspx?id=<%= messageReplyList[i].Id%>&pageno=<%= pageno %>'"
								class="updateBtn" title="编辑"> 
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeleteMessageReply.aspx?id=<%= messageReplyList[i].Id%>&pageno=<%= pageno %>pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>')">
						       <input type="button"
								value="" class="publishBtn" title="发布"
								onclick="isPublishMessage('PublishMessageReply.aspx?id=<%= messageReplyList[i].Id%>&pageno=<%= pageno %>')"/>
                            </td>
						</tr>
				<%} %>
					
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="8" id="pageControl"></td>
					</tr> 
                </form>


                    <tr>
					<td colspan="9" valign="middle">
						<!-- markupPage -->
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
							<tr style="border:0px;">
								<td style="border:0px;">
									<span>[总数:<%=page.RowCount %>条]</span> <span>[每页:<%= page.PageSize %>条]</span> [页次:<span title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo %></span>/<%= page.PageCount %>]
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
					</td>
				</tr>

               </table>


	</div>
</body>
</html>
