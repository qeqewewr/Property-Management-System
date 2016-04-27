<%@ Page Language="C#" AutoEventWireup="true" CodeFile="surveyQuestionAdd.aspx.cs" Inherits="Webmag_Employe_surveyManage_surveyQuestionAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>添加问卷题目</title>
    <link rel="Stylesheet" type="text/css" href="../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../CSS/calendar.css" />
    <script  type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script  type="text/javascript" src="../../Scripts/util.js"></script>
    <script  type="text/javascript" src="../../Scripts/cal.js"></script>
    <script type="text/javascript" src="../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../Scripts/webmag.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".saveBtn").click(function () {
                if ($("#question").val() == '') {
                    alert('问题不能为空');
                    return false;
                }
                return true;
            });        
        });

    </script>
        <style type="text/css">
    a.btn{color:#006699; padding:0 3px;}
    </style>
</head>
<body>
<form action="surveyQuestionAdd.aspx?id=<%=surveyQuestion.ID%>" method="post">
   <table class="addTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
     <caption><%if (surveyQuestion.ID == null)
                { %>调查问卷问题添加<%}
                else
                { %>
                调查问卷问题编辑
                <%} %>
                </caption>
     <tbody>
       <tr>
        <td><font color="red"> &nbsp*</font>调查问卷<input type="hidden" name="pid" value="<%=surveyQuestion.PID%>" /></td>
        <td><%=survey.Name%></td>
       </tr>
       <tr>
        <td><font color="red"> &nbsp*</font>问题</td>
        <td><input type="text" name="question" id="question" class="inputText" value="<%=surveyQuestion.Question%>"  /></td>
       </tr>
      
       <tr>
        <td>选项A</td>
        <td><textarea name="answerA" rows="3" cols="20"><%=surveyQuestion.AnswerA%></textarea></td>
       </tr>
       <tr>
        <td>选项B</td>
        <td><textarea name="answerB" rows="3" cols="20"><%=surveyQuestion.AnswerB%></textarea></td>
       </tr>
       <tr>
        <td>选项C</td>
        <td><textarea name="answerC" rows="3" cols="20"><%=surveyQuestion.AnswerC%></textarea></td>
       </tr>
       <tr>
        <td>选项D</td>
        <td><textarea name="answerD" rows="3" cols="20"><%=surveyQuestion.AnswerD%></textarea></td>
       </tr>
       <tr>
        <td colspan="2"  class="buttonGroup">
            <input type="submit" value=""   class="saveBtn" />
            <a class="btn" href="surveyQuestionView.aspx?pid=<%=survey.ID %>">查看该问卷题目</a>
        </td>
        
       </tr>
     </tbody>
   </table>
   </form>
</body>
</html>
