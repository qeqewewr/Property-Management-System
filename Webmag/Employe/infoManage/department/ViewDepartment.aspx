<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDepartment.aspx.cs" Inherits="BLL_informang_departmang_ViewDepartment" %>


<!-- 查看部门信息 -->

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
    
  </head>
  
  <body> 
   
    <div style="width: 100%">
        
			<table class="resultTable">

				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;&nbsp;部门信息列表：&nbsp;&nbsp;
                <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onClick="window.location.href='AddDepartment.aspx'"/>
			    </span>
				</caption>


				<tr class="topTitle" align="center">
                   <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>

					<td align="center">选 择</td>
                <%} %>
                    <td align="center">部门编号</td>
					<td align="center">部门名称</td>
                    <td align="center">部门主管</td>
					<td align="center">部门地址</td>
					<td align="center" colspan="2">操 作</td>
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 

                <%for (int i = 0; i<departList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                               <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                 { %>

							<td><input type="checkbox" name="selectDel"
								value="<%= departList[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" />
							</td> 
                            <%} %>
							
                            <td title="<%= departList[i].ID %>" align="left"><%= departList[i].ID%></td>
							<td title="<%= departList[i].Name %>" ><%= departList[i].Name%></td> 
                            <td title="<%= departList[i].Manager %>" ><%= departList[i].Manager%></td> 
							<td title="<%= departList[i].Address %>"><%= departList[i].Address%></td>
							
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateDepartment.aspx?id=<%= departList[i].ID%>&pageno=<%= pageno %>'"
								class="updateBtn" title="编辑"> 
                                   <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>

                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= departList[i].ID%>&pageno=<%= pageno %>&pagesize=<%= page.PageSize %>')">
						       <%} %>
                            </td>
						</tr>
				<%} %>
					   <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
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

               </table>

 


	</div>
    
  </body>
</html>
