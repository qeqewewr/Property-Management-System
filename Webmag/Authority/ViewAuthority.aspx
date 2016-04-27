<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAuthority.aspx.cs" Inherits="Webmag_Authority_ViewAuthority" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="../CSS/webmag.css"/> 
	<script type="text/javascript" src="../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../Scripts/webmag.js"></script>

     <script type="text/javascript">
         function changeAction() {
             $("#action").val("search");
             $("#keyword").val($("#lookByName").val());
             //            $("#scope").val($("#searchScope").val());
         }

         $(function () {
             $("#search").focus();
         });
	</script>

</head>
  <body> 
   
    <div style="width: 100%">
    <div class="queryArea"  style="width:100%">
            <form action="ViewAuthority.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="scope" id="scope" value="" />
               <%-- <input type="hidden" name="condition" id="condition" value="<%= condition %>" />--%>

				<fieldset>
					<legend style="color: #006699;"> 员工信息查询  </legend> 
					<span>员工姓名查询：<input type="text" name="lookByName" id="lookByName" title="请输入员工姓名"
						value="<%=keyword %>"
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> 
                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>

        
        <div>
			<table class="resultTable">
				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;&nbsp;员工信息列表：&nbsp;&nbsp;
<%--                <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onClick="window.location.href='AddCleaner.aspx'">
			    </span>
               --%>
				</caption>


				<tr class="topTitle" align="center">
					<!-- <td align="center">选 择</td>  -->
					<td align="center">员工姓名</td>
					<td align="center">所属</td>
					<td align="center" colspan="2">操 作</td>
				</tr> 

              <form name="pageControlForm" action="ViewAuthority.aspx?page=<%= pageno %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                <input type="hidden" name="comName" id="comName" value="<%=keyword %>" />
                <%for (int i = 0; i < employeList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
						<!--	<td><input type="checkbox" name="selectDel"
								value="<%=employeList[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" />
							</td> 
							-->
							<td title="<%= employeList[i].Name %>" align="left"><%= employeList[i].Name%></td> 
							<td title="<%= employeList[i].Department %>"><%= employeList[i].Department%></td>
							
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateAuthority.aspx?id=<%= employeList[i].ID%>&pageno=<%= pageno %>'"
								class="roleBtn" title="权限编辑">
						    </td>
						</tr>
				<%} %>
					
				<!--	<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="4" id="pageControl"></td>
					</tr> 
                -->
				
				
				</form>


                    <tr>
					<td colspan="5" valign="middle">
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
								<%--<td style="width:15px;"></td> --%>
							</tr>
						</table> 
					</td>
				</tr>

               </table>
               </div>
            </div>
    
  </body>

</html>
