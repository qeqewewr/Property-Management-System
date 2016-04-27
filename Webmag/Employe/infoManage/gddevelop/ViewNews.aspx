<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNews.aspx.cs" Inherits="Webmag_Employe_infoManage_gddevelop_ViewNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	 
	<link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>

        <script type="text/javascript">
            function changeAction() {
                $("#action").val("search");
                $("#keyword").val($("#newsTitle").val());
            }

            $(function () {
                $("#search").focus();
            });

	</script>

</head>
<body>
    <div style="width: 100%">

        <div class="queryArea"  style="width:100%">
            <form action="ViewNews.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 新闻标题查询  </legend> 
					<span>标题关键字查询：<input type="text" name="newsTitle" id="newsTitle" title="请输入标题"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699'); $("#search").focus();" /> &nbsp;&nbsp;<input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>
        <div>
        
			<table class="resultTable" >

				<caption style="text-align: left" >
					&nbsp;&nbsp;&nbsp;&nbsp;光大动态列表：
                    <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onclick="window.location.href='AddNews.aspx'"/>
			        </span>
				</caption>

                <tbody>
				<tr class="topTitle" align="center">
                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
					<td align="center">选 择</td>
                    <%} %>
					<td align="center">编号</td>
					<td align="center">标题</td>
                    <td align="center">发布时间</td>

					<td align="center" colspan="3">操 作</td>
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 

                <input type="hidden" name="keyword"  value="<%= keyword %>" />

                <%for (int i = 0; i < newsList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                            <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
							<td><input type="checkbox" name="selectDel"
								value="<%=newsList[i].ID %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
							<%} %>
							<td title="编号" align="left"><%= (i+1) %></td> 
							<td title="<%= newsList[i].Title %>"><%= newsList[i].Title %></td>
                            
                             <%if (newsList[i].PublishTime != null)
                              { %>
                            <td title="<%= newsList[i].PublishTime %>"><%=Convert.ToDateTime(newsList[i].PublishTime).ToShortDateString()%></td>
                            <%}
                              else
                              { %>
                                 <td title="<%= newsList[i].PublishTime %>"><%=newsList[i].PublishTime %></td>
                            <%} %>
							
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateNews.aspx?id=<%= newsList[i].ID%>&pageno=<%= pageno %>&keyword=<%=keyword %>'"
								class="updateBtn" title="编辑"/> 
                                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= newsList[i].ID %>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>&keyword=<%=keyword %>')"/>
                                <%} %>
                                <input  type="button"
								value="" class="viewBtn" title="查看"
								onclick="window.location.href='DetailNews.aspx?id=<%= newsList[i].ID%>&pageno=<%= pageno %>&keyword=<%=keyword %>'" />
						    </td>
						</tr>
				<%} %>
					<%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"/> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="6" id="pageControl"></td>
					</tr> 
                    <%} %>
                </form>


                 <tr>
					<td colspan="7" valign="middle">
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
								
							</tr>
						</table> 
					</td>
				</tr>
               </tbody>
            </table>

        </div>


	</div>
</body>
</html>
