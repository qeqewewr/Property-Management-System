<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewLessee.aspx.cs" Inherits="Webmag_Employe_infoManage_lessee_ViewLessee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">  
    
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

<script type="text/javascript">
    function changeAction() {
        $("#action").val("search");
        $("#keyword").val($("#lesseeName").val());
        $("#scope").val($("#searchScope").val());
    }

    jQuery(document).ready(function ($) {
        $('a[rel=facebox]').facebox();
    })

    $(function () {
        $(".Leave").click(function () {
            var url = this.url;
            var a = confirm("确定搬离？");
            if (a) window.location.href = url;
        });
        /*
        var a = confirm("确定要让该员工离职吗？");
        if (a) {
        $(".LeaveJob").click(window.location.herf = "LeaveJob.aspx?id="+$()+"&pageno=<%= pageno %>")
        }
        else {
        history.go(-1);
        }
        */
    });

        


      
	</script>
    
 </head>


<body> 
   
    <div style="width: 100%">
        <div class="queryArea"  style="width:100%">
            <form action="ViewLessee.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="scope" id="scope" value="" />
                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 租户信息查询  </legend> 
					<span>姓名查询：<input type="text" name="lesseeName" id="lesseeName" title="请输入姓名"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;&nbsp;查询范围：
                        <select name="searchScope" id="searchScope" >
                        <%if (scope == null||scope=="租用中")
                          { %>
                            <option>租用中</option>
                            <option>已搬离</option>                            
                            <option>全部</option> 
                        <%}
                            if (scope == "已搬离")
                            { %> 
                            <option>已搬离</option>
                            <option>租用中</option>
                            <option>全部</option>   
                        <%}
                            if (scope == "全部")
                            {%>                         
                             <option>全部</option> 
                             <option>已搬离</option>
                             <option>租用中</option>
                            
                        <%} %>
                        </select>
                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>


        <div>
			<table class="resultTable"  cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
				<caption style="text-align: left" >
					&nbsp;&nbsp;&nbsp;&nbsp;租户信息列表：
                    <span align="right">
                    <input type="button" value="" class="addBtn" title="添加" onclick="window.location.href='AddLessee.aspx'"/>
			        </span>
				</caption>
                <tbody>
				<tr class="topTitle" align="center">
                 <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
					<td align="center">选 择</td>
                    <%} %>
					<td align="center">租户名(登录名)</td>
                   <%-- <td align="center">登录名</td>--%>
				   <%--<td align="center">注册地址</td>--%>
                    <td align="center">经营范围</td>
                    <td align="center">办公电话</td>
                    <td align="center">负责人</td>
                    <td align="center">负责人电话</td>
               <%--     <td align="center">应急联系人</td>
                    <td align="center">应急联系人电话</td>--%>
                    <td align="center">入驻情况</td>
                    <td align="center">租赁情况</td>
					<td align="center" colspan="4">操 作</td>
				</tr> 
                
              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
               
                <input type="hidden" name="keyword"  value="<%=keyword %>" />
                <input type="hidden" name="scope"  value="<%=scope %>" />

                <%for (int i = 0; i < lesseeList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                             <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
							<td><input type="checkbox" name="selectDel"
								value="<%=lesseeList[i].ID %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
							<%} %>
							<td title="<%= lesseeList[i].Name %>" ><%= lesseeList[i].Name%></td>
                            <%--<td title="<%= lesseeList[i].RoomNum %>" ><%= lesseeList[i].RoomNum %></td>  
							<td title="<%= lesseeList[i].Address %>" ><%= lesseeList[i].Address%></td> --%>
                            <td title="<%= lesseeList[i].OperationScope %>" ><%= lesseeList[i].OperationScope %></td> 
                            <td title="<%= lesseeList[i].OfficePhone %>" ><%= lesseeList[i].OfficePhone %></td> 
                            <td title="<%= lesseeList[i].Director %>" ><%= lesseeList[i].Director %></td> 
                            <td title="<%= lesseeList[i].DirectorPhone %>" ><%= lesseeList[i].DirectorPhone %></td> 
                            <%--<td title="<%= lesseeList[i].Emergency  %>" ><%= lesseeList[i].Emergency %></td> 
                            <td title="<%= lesseeList[i].EmergencyPhone  %>" ><%= lesseeList[i].EmergencyPhone %></td> --%>

                            <%if (lesseeList[i].Status == false)
                              {%>
                                  <td title="<%= lesseeList[i].Status %>">租用中</td>
                            <%}
                              else
                              {%>
                                  <td title="<%= lesseeList[i].Status %>">已搬离</td>
                            <%} %>
							
                             <td title="点击查看租用情况" ><a rel="facebox" href="LesseeRoomInfo.aspx?id=<%=lesseeList[i].ID %>&pageno=<%= pageno %>&keyword=<%= keyword %>&scope=<%=scope %>">点击查看详情</a></td>
                             <%--<td title="点击查看租用情况" ><a href="LesseeRoomInfo.aspx?id=<%=lesseeList[i].ID %>&pageno=<%= pageno %>&keyword=<%= keyword %>&scope=<%=scope %>">点击查看详情</a></td> --%>
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateLessee.aspx?id=<%= lesseeList[i].ID %>&pageno=<%= pageno %>&keyword=<%= keyword %>&scope=<%=scope %>'"
								class="updateBtn" title="编辑"> 
                                 <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= lesseeList[i].ID %>&pageno=<%= pageno %>&pagesize=<%= page.PageSize %>&rowcount=<%=page.RowCount %>&keyword=<%= keyword %>&scope=<%=scope %>')">
                                <%} %>
                                <input  type="button"
								value="" class="viewBtn" title="查看"
								onclick="window.location.href='DetailInfo.aspx?id=<%= lesseeList[i].ID %>&pageno=<%= pageno %>&keyword=<%= keyword %>&scope=<%=scope %>'" />
                              <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                { %>
                             <%if (scope != "已搬离" || lesseeList[i].Status == true)
                               { %>
                                <input type="button" class="Leave" style="background-repeat:repeat-x;width:56px; height:20px; cursor:hand;"
								value="搬离"  title="搬离" url="Leave.aspx?id=<%= lesseeList[i].ID %>&pageno=<%= pageno %>"  />
                             <%}
                                }%>
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
						<td colspan="13" id="pageControl"></td>
					</tr> 
                    <%} %>
                </form>


                 <tr>
					<td colspan="14" valign="middle">
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
