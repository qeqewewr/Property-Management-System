<%@ Page Language="C#" AutoEventWireup="true" CodeFile="surveyAdd.aspx.cs" Inherits="Webmag_Employe_surveyManage_surveyAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="Stylesheet" type="text/css" href="../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../Scripts/cal.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#endtime').simpleDatepicker({ y: 20, x: -20 });
            $("#birthCalImg").bind('click', function () { $("#endtime").click(); });

            $(".saveBtn").click(function () {

                if ($("#title").val()=='') {
                    alert('名称不能为空');
                    return false;
                }
                if ($("#endtime").val()=='') {
                    alert('结束时间不能为空');
                    return false;
                }
                return true;
            });
        });
    </script>
        <style type="text/css">
    a.btn{color:#006699; padding:0 3px;}
    </style>
    <title>调查问卷添加</title>
</head>
<body>
<form action="surveyAdd.aspx?id=<%=ID%>" method="post">
   <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
     <caption><%if (ID == null)
                { %>调查问卷添加<%}
                else
                { %>
                调查问卷编辑
                <%
                  } %>
                </caption>
     <tbody>
       <tr>
        <td><font color="red"> &nbsp*</font>名称</td>
        <td><input type="text" name="title" id="title"  class="inputText" value="<%=Name%>"  /></td>
       </tr>
       <tr>
        <td><font color="red"> &nbsp*</font>结束时间</td>
        <td><input type="text" name="endtime" id="endtime" class="inputText" value="<%=Deadline%>"  /><img id="birthCalImg"  class="datepicker" src="../../Images/cal.gif" /></td>
       </tr>
      
       <tr>
        <td>描述</td>
        <td><textarea name="desc" rows="4" cols="35"><%=Desc%></textarea></td>
       </tr>
       <tr>
        <td colspan="2"  class="buttonGroup">
            <input type="submit" value=""   class="saveBtn" />   <a href="surveyView.aspx" class="btn">返回</a>
        </td>
        
       </tr>
     </tbody>
   </table>
</form>
</body>
</html>
