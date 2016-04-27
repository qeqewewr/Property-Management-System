<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNoticeType.aspx.cs" Inherits="Webmag_Employe_tabledoc_docmang_documentTypeView" %>

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
<form action="DeleteNoticeType.aspx" method="post" id="pageControlForm" name="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');" >
    <table  class="resultTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <caption style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;文档管理：&nbsp;&nbsp; <span align="right">
        <input type="button" onclick="window.location.href='AddNoticeType.aspx'" title="添加表单" class="addBtn" value="" />
          
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
<input type="button" value="" onclick="window.location.href='AddNoticeType.aspx?id=<%= doctypelist[i].ID%>'" class="updateBtn" title="编辑" /> 
                                
<input type="button" value="" class="deleteBtn" title="删除" onclick="checkDeleteSingleItem('DeleteNoticeType.aspx?selectDel=<%= doctypelist[i].ID%>')" />

                 </td>
                 </tr>
        <%     }
        %>

            <tr>	
			<td  colspan="3" style="text-align:left;padding-left:55px;"> 
			<input type="checkbox" onclick="selectAll('pageControlForm','selectDel','sltAll')" name="sltAll" title="全选"  id="sltAll"> 
            <input type="submit" title="删除全选" value="" class="deleteBtn">
                    &nbsp; <a href="ViewNotice.aspx">返回浏览通知</a>    
						</td>
					
					</tr>

              
       
        </tbody>
   
 
    </table>
    </form>
</body>
</html>
