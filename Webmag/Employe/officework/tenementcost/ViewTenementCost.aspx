<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTenementCost.aspx.cs" Inherits="Webmag_Employe_officework_tenementcost_ViewTenementCost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    

	<script type="text/javascript" src="../../../Scripts/util.js"></script>
	<link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
    <script type="text/javascript">
        function changeAction() {
            var s = $("#searchFeeMonth").val();

            var theDate, flag;
            //验证日期格式是否为yyyy/mm/dd
            if (s != "") {
                theDate = $.trim(s);
                flag = isdateOne(theDate);
                if (!flag) {
                    alert("您搜索的费用日期时间格式有误，请重新输入！");
                    $("#searchFeeMonth").focus();
                    return false;
                }
            }
            $("#action").val("search");
            $("#keyword").val($("#lessee").val());
            $("#feeMonth").val($("#searchFeeMonth").val());
        }

        $(function () {
            $("#search").focus();
        });

	</script>
</head>

<body>
    
    <div style="width: 100%">
         <div style="width: 100%">
         <%if (role == "property")
           {%>
             <div class="queryArea"  style="width:100%">
                <form action="ViewTenementCost.aspx?pageno=1" name="searchForm"
				    id="searchForm" method="post">
                    <input type="hidden" name="keyword" id="keyword" value="" />
                    <input type="hidden" name="feeMonth" id="feeMonth" value="" />
                    <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				    <fieldset>
					    <legend style="color: #006699;"> 租户费用查询  </legend> 
					    <span>租户关键字查询：<input type="text" name="lessee" id="lessee" title="请输入租户名称"
						    <%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						    size="30" class="inputText"
						    onfocus="$(this).css('border-color','#ff0000')"
						    onblur="$(this).css('border-color','#006699'); $("#search").focus();" /> 费用日期<font color="red">(查询格式:yyy-mm-dd)</font>：
                           <input type="text" name="searchFeeMonth" id="searchFeeMonth" title="请输入费用月份"
						    <%if (condition){%> value="<%=feeMonth %>"<%}else{ %>value=""<%} %> 
						    size="30" class="inputText"
						    onfocus="$(this).css('border-color','#ff0000')"
						    onblur="$(this).css('border-color','#006699')" /><input id="search"
						    type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				    </fieldset>
                
			    </form>
            </div>
        <%} %>
			<table class="resultTable">

				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;租户费用列表：&nbsp;&nbsp;
                <span align="right">
                <%if (role == "property") {%>
                <input type="button" value="" class="addBtn" title="添加"
						onClick="window.location.href='AddTenementCost.aspx'">
                        <%} %>
			        </span>
                
				</caption>     

				<tr class="topTitle" align="center">
				<%if(role=="property")
				{%>
					<td align="center">选 择</td>
				<%}%>
					<td align="center">租户</td>
					<td align="center">楼宇</td>
                    <td align="center">房间号</td>
                    <td align="center">费用类型</td>
                    <td align="center">费用<font color="red">(单位:元)</font></td>
					<td align="center">费用起始日期</td>
                    <td align="center">费用截止日期</td> 
					<td align="center">录入员工</td>
                    <td align="center">录入时间</td>
					       
					<td align="center">是否已支付 </td>
				<%if(role=="property")
				{%>
					<td align="center" colspan="2">操 作</td>
				<%}%>
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');">
                  
                 <input type="hidden" name="keyword"  value="<%= keyword %>" />
                 <input type="hidden" name="feeMonth"  value="<%= feeMonth %>" />

                <%for (int i = 0; i < tenementCostList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
						<%if(role=="property")
						{%>
							<td> 
                            <%if (tenementCostList[i].IsPayed == false) {%>
                              <input type="checkbox" name="selectDel"
								value="<%=tenementCostList[i].Id %>" onclick="isAllSelected(this,'sltAll','1')" />
							   <%} %>
                            </td> 
						<%}%>
                    
                            <td title="<%= tenementCostList[i].Lessee %>" align="left"><%= tenementCostList[i].Lessee%></td> 
							<td title="<%= tenementCostList[i].BuildingName %>" ><%= tenementCostList[i].BuildingName%></td> 
                            <td title="<%= tenementCostList[i].Room %>"><%= tenementCostList[i].Room%></td> 
                            <td title="<%= tenementCostList[i].FeeType %>"><%= tenementCostList[i].FeeType%></td> 
                            <td title="<%= tenementCostList[i].Fee %>"><%= tenementCostList[i].Fee%></td> 
                            <td title="<%= tenementCostList[i].StartDate %>"><%= tenementCostList[i].StartDate%></td> 
                            <td title="<%= tenementCostList[i].Deadline %>"><%= tenementCostList[i].Deadline%></td> 
                            <td title="<%= tenementCostList[i].InputEmployId %>"><%= tenementCostList[i].InputEmployId%></td> 
                            <td title="<%= tenementCostList[i].InputDateTime %>"><%= tenementCostList[i].InputDateTime%></td> 
							
                            <td title="<%= pageBLL.TransformBooleanToChinese(tenementCostList[i].IsPayed) %>"><%=pageBLL.TransformBooleanToChinese(tenementCostList[i].IsPayed)%></td> 

                            <td><%if (!tenementCostList[i].IsPayed)
                                  {%>
                            <input type="button" value="" 
								onclick="window.location.href='UpdateTenementCost.aspx?id=<%= tenementCostList[i].Id%>&pageno=<%= pageno %>'"
								class="updateBtn" title="编辑"> 
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= tenementCostList[i].Id%>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>')">
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
                   
						<td colspan="12" id="pageControl" style="text-align:left;padding-left:20px;">
                        
                          <a href="ViewFeeType.aspx">查看费用类型</a>&nbsp  &nbsp 
                          <a href="AddFeeType.aspx">添加费用类型</a></td>
                        </td>
                   <%} 
                    %>
					</tr> 
                </form>


                    <tr>
					<td colspan="13" valign="middle">
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
