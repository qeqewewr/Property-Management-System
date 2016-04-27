<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEmploye.aspx.cs" Inherits="Webmag_Employe_infoManage_employe_ViewEmploye" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">  
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
            $("#keyword").val($("#employeName").val());
            $("#scope").val($("#searchScope").val());
        }

        $(function () {
            $(".LeaveJob").click(function () {
                var url = $(this).attr('url');
                var a = confirm("确定离职？");
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
            <form action="ViewEmploye.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="scope" id="scope" value="" />
                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 员工信息查询  </legend> 
					<span>姓名查询：<input type="text" name="employeName" id="employeName" title="请输入姓名"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;&nbsp;查询范围：
                        <select name="searchScope" id="searchScope" >
                        <%if (scope == null||scope=="在职")
                          { %>
                            <option>在职</option>
                            <option>全部</option>                            
                            <option>离职</option> 
                        <%}
                            if (scope == "离职")
                            { %> 
                            <option>离职</option>
                            <option>在职</option>
                            <option>全部</option>   
                        <%}
                            if (scope == "全部")
                            {%>                         
                             <option>全部</option> 
                             <option>离职</option>
                             <option>在职</option>
                            
                        <%} %>
                        </select>
                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>

        <div>
			<table class="resultTable" >

				<caption style="text-align: left" >
					&nbsp;&nbsp;&nbsp;&nbsp;员工信息列表：
                    <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onclick="window.location.href='AddEmploye.aspx'"/>
			        </span>
				</caption>



                <tr class="topTitle" align="center">
                   <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
					<td align="center">选 择</td>
                    <%} %>
					<td align="center">部门</td>
					<td align="center">办公电话</td>
                    <td align="center">性名</td>
                    <td align="center">性别</td>
                    <td align="center">手机号码</td>
                    <td align="center">电子邮箱</td>
                    <td align="center">在职状况</td>
					<td align="center" colspan="4">操 作</td>
				</tr> 

             


                <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                
                <input type="hidden" name="keyword"  value="<%=keyword %>" />
                <input type="hidden" name="scope"  value="<%=scope %>" />

                <%for (int i = 0; i < employeList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                               <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
							<td><input type="checkbox" name="selectDel"
								value="<%= employeList[i].EmployeID %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td>
                             <%} %>
							<td title="<%= employeList[i].Department %>"><%= employeList[i].Department %></td>
                            <td title="<%= employeList[i].OfficeTel %>"><%= employeList[i].OfficeTel %></td>						
							<td title="<%= employeList[i].Name %>"><%= employeList[i].Name %></td>
                            <td title="<%= employeList[i].Sex %>"><%= employeList[i].Sex %></td>
                           <td title="<%= employeList[i].Mobile %>" align="left"><%= employeList[i].Mobile%></td> 
                            <td title="<%= employeList[i].Email %>"><%= employeList[i].Email %></td>
                            <%if (employeList[i].Status == false)
                              {%>
                                  <td title="<%= employeList[i].Status %>">在职</td>
                            <%}
                              else
                              {%>
                                  <td title="<%= employeList[i].Status %>">离职</td>
                            <%} %>
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateEmploye.aspx?id=<%= employeList[i].EmployeID %>&pageno=<%= pageno %>&keyword=<%=keyword %>&scope=<%=scope %>'"
								class="updateBtn" title="编辑"/> 
                                   <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                     { %>
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= employeList[i].EmployeID %>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>&keyword=<%=keyword %>&scope=<%=scope %>')"/>
                                 <%} %>
                                 <input  type="button"
								value="" class="viewBtn" title="查看"
								onclick="window.location.href='DetailInfo.aspx?id=<%= employeList[i].EmployeID %>&pageno=<%= pageno %>&keyword=<%=keyword %>&scope=<%=scope %>'" />
                                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
                             <%if (scope != "离职")
                               { %>
                                <input type="button" class="LeaveJob" style="background-repeat:repeat-x;width:56px; height:20px; cursor:hand;"
								value="离职"  title="离职" url="LeaveJob.aspx?id=<%= employeList[i].EmployeID %>&pageno=<%= pageno %>"  />
                             <%} %>
                               
                                 <input  type="button"
								value="" class="resetPwdBtn" title="密码重置"
								onclick="window.location.href='ResetPSW.aspx?id=<%= employeList[i].EmployeID %>&pageno=<%= pageno %>&keyword=<%=keyword %>&scope=<%=scope %>'" />
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
						<td colspan="12" id="pageControl"></td>
					</tr> 
                    <%} %>
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
								
							</tr>
						</table> 
					</td>
				</tr>

            </table>
        </div>
 


	</div>
    
  </body>
</html>
