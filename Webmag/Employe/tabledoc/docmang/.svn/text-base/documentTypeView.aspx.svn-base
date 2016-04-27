<%@ Page Language="C#" AutoEventWireup="true" CodeFile="documentTypeView.aspx.cs" Inherits="Webmag_Employe_tabledoc_docmang_documentTypeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
            <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script  type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script  type="text/javascript" src="../../../Scripts/util.js"></script>
    <script  type="text/javascript" src="../../../Scripts/cal.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
</head>
<body>
<form action="documentTypeDelete.aspx" method="post" id="pageControlForm" name="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');" >
    <table  class="resultTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <caption style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;文档类型管理：&nbsp;&nbsp; <span align="right">
        <input type="button" onclick="window.location.href='documentTypeAdd.aspx'" title="添加表单" class="addBtn" value="" />
          
            </span>
        </caption>
        <thead>
            <tr  class="topTitle" align="center">
                <th>

                </th>
                <th>
                    标题
                </th>
             
                <th>操作</th>
            </tr>
        </thead>
        <tbody>
        <%
            for (int i = 0; i < doctypelist.Count; i++)
            {
          %>
                 <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                  <td><input type="checkbox" name="selectDel" value="<%= doctypelist[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" /></td>
                  <td><%=doctypelist[i].Name%></td>
             
                  <td>
<input type="button" value="" onclick="window.location.href='documentTypeAdd.aspx?id=<%= doctypelist[i].ID%>'" class="updateBtn" title="编辑" /> 
                                
<input type="button" value="" class="deleteBtn" title="删除" onclick="checkDeleteSingleItem('documentTypeDelete.aspx?selectDel=<%= doctypelist[i].ID%>')" />

                 </td>
                 </tr>
        <%     }
        %>

            <tr>	
			<td  colspan="3" style="text-align:left;padding-left:55px;"> 
			<input type="checkbox" onclick="selectAll('pageControlForm','selectDel','sltAll')" name="sltAll" title="全选"  id="sltAll"> 
            <input type="submit" title="删除全选" value="" class="deleteBtn">
                        
						</td>
					
					</tr>
                    <tr>
                     <td colspan="7">
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
    </form>
</body>
</html>
