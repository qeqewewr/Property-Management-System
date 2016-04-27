<%@ Page Language="C#" AutoEventWireup="true" CodeFile="surveyView.aspx.cs" Inherits="Webmag_Employe_surveyManage_surveyView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>调查问卷查看</title>
    <link rel="Stylesheet" type="text/css" href="../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../CSS/calendar.css" />
    <script  type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script  type="text/javascript" src="../../Scripts/util.js"></script>
    <script  type="text/javascript" src="../../Scripts/cal.js"></script>
    <script type="text/javascript" src="../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../Scripts/webmag.js"></script>
    <style type="text/css">
    a.btn{color:#006699; padding:0 3px;}
    </style>
</head>
<body>
    <form action="surveyDelete.aspx" method="post" id="pageControlForm" name="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');" >
    <table  class="resultTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <caption style="text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;调查问卷列表：&nbsp;&nbsp; <span align="right">
                <input type="button" onclick="window.location.href='surveyAdd.aspx'" title="添加" class="addBtn"
                    value="" />
            </span>
        </caption>
        <thead>
            <tr  class="topTitle" align="center">
                <th>
                </th>
                <th>
                    问卷名称
                </th>
                <th>
                    问卷描述
                </th>
                <th>
                    添加时间
                </th>
                <th>
                    截止日期
                </th>
                <th>操作</th>
            </tr>
        </thead>
        <tbody>
        <%
            for (int i = 0; i < surveys.Count; i++)
            {
          %>
                 <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                  <td><input type="checkbox" name="selectDel" value="<%= surveys[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" /></td>
                  <td><%=surveys[i].Name %></td>
                  <td><%=surveys[i].Desc %></td>
                  <td><%=surveys[i].Addtime %></td>
                  <td><%=surveys[i].Deadline %></td>
                  <td><input type="button" value="" 
								onclick="window.location.href='surveyAdd.aspx?id=<%= surveys[i].ID%>'"
								class="updateBtn" title="编辑"> 
                                
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('surveyDelete.aspx?selectDel=<%= surveys[i].ID%>')" />
                                <a class="btn" href="surveyQuestionAdd.aspx?pid=<%= surveys[i].ID%>">添加题目</a>
                                <a class="btn" href="surveyQuestionView.aspx?pid=<%= surveys[i].ID%>">查看题目</a>
                                <a class="btn" href="surveyAnswerView.aspx?pid=<%= surveys[i].ID%>">统计问卷</a>
                              <!--
                                <input type="button" value="添加题目" 
								onclick="window.location.href='surveyQuestionAdd.aspx?pid=<%= surveys[i].ID%>'"
							    title="添加题目" /> 
                                 <input type="button" value="查看题目" 
								onclick="window.location.href='surveyQuestionView.aspx?pid=<%= surveys[i].ID%>'"
							    title="查看题目" />     
                                <input type="button" value="统计问卷" 
								onclick="window.location.href='surveyResultView.aspx?pid=<%= surveys[i].ID%>'"
							    title="统计问卷" />     
                                -->                       
                                </td>
                 </tr>
        <%     }
        %>

               <tr align="center">	
						<td> 
							<input type="checkbox" onclick="selectAll('pageControlForm','selectDel','sltAll')" name="sltAll" alt="全选" title="全选" id="sltAll"> <input type="submit" title="删除全选" value="" class="deleteBtn">
                               
						</td>
						<td colspan="5"></td>
					</tr>
                    <tr>
                     <td colspan="6">
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
       
        </tbody>
   
 
    </table>
    </form>
</body>
</html>
