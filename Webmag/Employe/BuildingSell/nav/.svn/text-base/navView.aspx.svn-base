<%@ Page Language="C#" AutoEventWireup="true" CodeFile="navView.aspx.cs" Inherits="Webmag_Employe_tabledoc_docmang_docmanage" %>

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
<form action="navDelete.aspx" method="post" id="pageControlForm" name="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');" >
    <table  class="resultTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <caption style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;导航管理：&nbsp;&nbsp; <span align="right">
        <input type="button" onclick="window.location.href='navAdd.aspx'" title="添加主菜单" class="addBtn" value="" />
          
            </span>
        </caption>
        <thead>
            <tr  class="topTitle" align="center">
                <th>

                </th>
                <th>
                    菜单名称
                </th>
                <th>
                    链接地址
                </th>
       
                <th>操作</th>
            </tr>
        </thead>
        <tbody>
        <%
            for (int i = 0; i < navlist.Count; i++)
            {
          %>
                 <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                  <td><input type="checkbox" name="selectDel" value="<%= navlist[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" /></td>
                  <td><%=navlist[i].Name%></td>
                  <td><%=navlist[i].Url%></td>
                
                  <td>
<input type="button" value="" onclick="window.location.href='navAdd.aspx?id=<%= navlist[i].ID%>'" class="updateBtn" title="编辑" /> 
                 </td>
                 </tr>
        <%     }
        %>

         
         <!--   <tr align="center">	
			<td colspan="8" style="text-align:left;padding-left:14px;"> 
			<input type="checkbox" onclick="selectAll('pageControlForm','selectDel','sltAll')" name="sltAll" title="全选"  id="sltAll"> 
            <input type="submit" title="删除全选" value="" class="deleteBtn">
                          
						</td>
			
					</tr>
                    -->

        </tbody>
   
 
    </table>
    </form>
</body>
</html>
