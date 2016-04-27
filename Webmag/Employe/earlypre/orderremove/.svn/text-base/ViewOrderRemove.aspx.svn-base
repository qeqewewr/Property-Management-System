<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewOrderRemove.aspx.cs" Inherits="Webmag_Employe_earlypre_orderremove_ViewOrderRemove" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
             $("#keyword").val($("#lessee").val());
         }

         $(function () {
             $("#search").focus();
         });

	</script>
</head>

<body>

    <div style="width: 100%">
    <%if (role == "property"&&action=="all")
      {%>
         <div class="queryArea"  style="width:100%">
            <form action="ViewOrderRemove.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 搬入预约查询  </legend> 
					<span>租户关键字查询：<input type="text" name="lessee" id="lessee" title="请输入租户名称"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699'); $("#search").focus();" />&nbsp;&nbsp;<input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>
      <%} %>
			<table class="resultTable">

				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;入住前期列表：&nbsp;&nbsp;
                 <!--
                 <%if (role == "lessee")
                   {%>
                   <%} %>
                -->
                <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onClick="window.location.href='AddOrderRemove.aspx'">
			    </span>
                
				</caption>

               
				<tr class="topTitle" align="center">
                  <%if (role == "property")
                    {%>
					<td align="center">选 择</td>
                <%} %>
					<td align="center">租户</td>
					<td align="center">楼宇</td>
                    <td align="center">房间号</td>
					<td align="center">联系人</td>
					<td align="center">联系人电话</td>
                    <td align="center">预约时间</td>
					<td align="center">几车(单位:吨位)</td>
					<td align="center"><font color="red">是否确认</font></td>
                    <td align="center">备注</td>
               
					<td align="center" colspan="2">操 作</td>
              
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                  <input type="hidden" name="keyword"  value="<%= keyword %>" />
                  <input type="hidden" name="action" value="<%=action %>" />
                <%for (int i = 0; i < orderMoveInList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                          <%if (role == "property")
                            {%>
                           
							<td>
                                 <%if (orderMoveInList[i].IsSure == false)
                                  {%>
                                <input type="checkbox" name="selectDel"
								    value="<%= orderMoveInList[i].Id %>" onclick="isAllSelected(this,'sltAll','1')" />
							     <%}%>
                            </td> 
                         <%} %>
                    
                            <td title="<%= orderMoveInList[i].Lessee %>" align="left"><%= orderMoveInList[i].Lessee%></td> 
							<td title="<%= orderMoveInList[i].BuildingName %>" ><%= orderMoveInList[i].BuildingName%></td> 
                            <td title="<%= orderMoveInList[i].Room %>"><%= orderMoveInList[i].Room%></td> 
                            <td title="<%= orderMoveInList[i].Director %>"><%= orderMoveInList[i].Director%></td> 
                            <td title="<%= orderMoveInList[i].DirectorPhone %>"><%= orderMoveInList[i].DirectorPhone%></td> 
                            <td title="<%= orderMoveInList[i].DateTime %>"><%= orderMoveInList[i].DateTime%></td> 
							<td title="<%= orderMoveInList[i].GoodsNum %>"><%= orderMoveInList[i].GoodsNum%></td> 
                            <td title="<%= orderMoveInList[i].IsSure %>"><%= pageBLL.TransformBooleanToChinese(orderMoveInList[i].IsSure)%></td> 
						    <td title="<%= orderMoveInList[i].Remarks %>"><%= orderMoveInList[i].Remarks%></td> 
                          
                            <td>
                            <%if (orderMoveInList[i].IsSure == false) 
                              {%>
                                <input type="button" value="" 
								onclick="window.location.href='UpdateOrderMoveIn.aspx?id=<%= orderMoveInList[i].Id%>&pageno=<%= pageno %>&action=<%=action %>'"
								class="updateBtn" title="编辑" <%if(orderMoveInList[i].IsSure==true) {%>disabled="true"<%} %>> 
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= orderMoveInList[i].Id%>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>')" <%if(orderMoveInList[i].IsSure==true) {%>disabled="true"<%} %>>
						   <%} %>
                            </td>
                        
						</tr>
				<%} %>
					  <%if (role == "property")
                     {%>
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="11" id="pageControl"></td>
					</tr> 
                    <%} %>
                </form>


                    <tr>
					<td colspan="12" valign="middle">
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
