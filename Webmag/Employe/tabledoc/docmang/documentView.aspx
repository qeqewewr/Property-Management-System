<%@ Page Language="C#" AutoEventWireup="true" CodeFile="documentView.aspx.cs" Inherits="Webmag_Employe_tabledoc_docmang_docmanage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
        <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <link rel="Stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css" />
    <script  type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script  type="text/javascript" src="../../../Scripts/util.js"></script>
    <script  type="text/javascript" src="../../../Scripts/cal.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>
    <script>
        $(function () {
            $("a[rel=facebox]").facebox();
        })
    </script>
</head>
<body>
<form action="documentDelete.aspx" method="post" id="pageControlForm" name="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');" >
    <table  class="resultTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <caption style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;文档管理：&nbsp;&nbsp; <span align="right">
			<%if(role=="property")
		{%>
        <input type="button" onclick="window.location.href='documentAdd.aspx'" title="添加表单" class="addBtn" value="" />
		<%}%>
          
            </span>
        </caption>
        <thead>
            <tr  class="topTitle" align="center">
                <th></th>
                <th>
                    标题
                </th>
                <th>
                    文件名
                </th>
                <th>
                    路径下载
                </th>
                <th>
                    文档类型
                </th>
                <th>
                    描述
                </th>
                <th>
                    上传者
                </th>
                <th>
                    更新日期
                </th>
				<%if(role=="property")
				{%>
                <th>操作</th>
				<%}%>
            </tr>
        </thead>
        <tbody>
        <%
			for (int i = 0;i< doclist.Count; i++)
            {
          %>
                 <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
				<%if(role=="property")
				{%>
                  <td><input type="checkbox" name="selectDel" value="<%= doclist[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" /></td>
                <%}%>  
				  <td><%=doclist[i].Title%></td>
                  <td><%=doclist[i].FileName%></td>
                  <td>
                  <%if (System.IO.File.Exists(Server.MapPath(doclist[i].FileUrl)))
                    { %><a href="<%=doclist[i].FileUrl%>">点击查看或下载</a><%}
                    else
                    { %>
                    文件不存在或被删除
                  <%} %>      
                        
                        </td>
                  <td><a href="documentView.aspx?typeid=<%=doclist[i].TypeID %>"> <%=doclist[i].TypeName%></a></td>
                 <td>
                 <%if (doclist[i].FileDesc.Trim() != "")
                   { %>
                 <a rel="facebox" href="documentDescView.aspx?id=<%= doclist[i].ID %>">点击查看</a>
                 <%}
                   else
                   { %>
                   没有描述
                 <%} %>
                 </td>
                 <td><%=doclist[i].UploadName%></td>
                 <td><%=doclist[i].FileUpDate%></td>
				 <%if(role=="property")
				{%>
                  <td>
<input type="button" value="" onclick="window.location.href='documentAdd.aspx?id=<%= doclist[i].ID%>'" class="updateBtn" title="编辑" /> 
                                
<input type="button" value="" class="deleteBtn" title="删除" onclick="checkDeleteSingleItem('documentDelete.aspx?selectDel=<%= doclist[i].ID%>')" />

                 </td>
				<%}%>
                 </tr>
        <%     }
        %>
		<%if(role=="property")
		{%>
            <tr align="center">	
			<td colspan="8" style="text-align:left;padding-left:14px;"> 
			<input type="checkbox" onclick="selectAll('pageControlForm','selectDel','sltAll')" name="sltAll" title="全选"  id="sltAll"> 
            <input type="submit" title="删除全选" value="" class="deleteBtn">
                               <select id="typeselect" url="documentView.aspx?typeid=">
<option value="" >所有类型</option>
<%for (int ii = 0; ii < doctypelist.Count; ii++)
  { %>
  <option value="<%=doctypelist[ii].ID %>" <%if(doctypelist[ii].ID == typeid){ %>selected="selected" <%} %>><%=doctypelist[ii].Name %></option>
<%} %>
</select>
						</td>
			
					</tr>
			<%}%>
                    <tr>
                     <td colspan="8">
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
<script>
    $("#typeselect").change(function () {
        var url = $(this).attr('url') + $(this).val();
        if(url != window.location.href)
        window.location.href = url;
    });
</script>