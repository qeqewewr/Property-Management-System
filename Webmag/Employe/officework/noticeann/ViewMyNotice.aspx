<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMyNotice.aspx.cs" Inherits="Webmag_Employe_officework_noticeann_ViewNotice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	 
	<link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/> 
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>
<script>
    $(function () {
        $("a[rel=facebox]").facebox();
    });
    
</script>
</head>

<body>

    <div style="width: 100%">
        
			<table class="resultTable">

				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;通知列表：&nbsp;&nbsp;
        
        <input type="button" onclick="window.location.href='AddNotice.aspx'" title="添加表单" class="addBtn" value="" />
          
    
				</caption>     
               
				<tr class="topTitle" align="center">
					<td align="center" style="width:150px;">选 择</td>
					
					<td align="center">发布人</td>
                    <td align="center">发布时间</td>
                    <td align="center">通知类型</td>
                    <td align="center">通知内容</td>
                    <td align="center">状态</td>
					
					<td align="center">操 作</td>
				</tr> 

              <form name="pageControlForm" action="DeleteMyNotice.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&building=<%=building %>&room=<%=room %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 

                <%for (int i = 0; i < MyNoticeDetailList.Count; i++)
                  {
                      MyNoticeDetail n = MyNoticeDetailList[i];
                      %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							<td><input type="checkbox" name="selectDel"
								value="noticeList" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
                                                                                                                                                                       <td><%= n.notice.Publisher%></td>                
							<td><%= n.notice.PublishDate%></td> 
                            
                            <td><%= n.notice.NoticeType%></td> 
                            <td><a rel="facebox" href="ViewNoticeContent.aspx?id=<%=n.notice.ID %>&myid=<%=n.myNotice.ID %>&read=<%=n.myNotice.IsRead%>" >点击查看</a></td> 
                            <td><% if (n.myNotice.IsRead == "1")
                                   { 
                                       
                                       %>
                                   已读
                                   <%}
                                   else
                                   { %>
                                   未读
                                   <%} %>
                                   </td> 
                                           
                            <td>
               
                                <input type="button" value="" class="deleteBtn" title="删除" onclick="checkDeleteSingleItem('DeleteMyNotice.aspx?selectDel=<%=n.myNotice.ID %>&building=<%=building %>&room=<%=room %>')">
						    
                            
                            
                            </td>
               
						</tr>
				<%} %>
					
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                                &nbsp &nbsp 
                               
						</td>
						<td colspan="6" id="pageControl" style="text-align:left;padding-left:10px;">
                        <a href="ViewMyNotice.aspx?building=<%=building%>&room=<%=room %>&action=all">查看全部</a>
                        <a href="ViewMyNotice.aspx?building=<%=building%>&room=<%=room %>&action=unread">查看未读</a>
                        </td>

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
