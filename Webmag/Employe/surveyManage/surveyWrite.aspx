<%@ Page Language="C#" AutoEventWireup="true" CodeFile="surveyWrite.aspx.cs" Inherits="Webmag_Employe_surveyManage_surveyWrite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
         <title>问卷调查填写</title>
      <link rel="Stylesheet" type="text/css" href="../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../CSS/calendar.css" />
    <script  type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script  type="text/javascript" src="../../Scripts/util.js"></script>
    <script type="text/javascript" src="../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../Scripts/webmag.js"></script>
</head>
<body>
     <form action="surveyWrite.aspx?pid=<%=survey.ID%>" method="post" id="pageControlForm" name="pageControlForm" >
    <table  class="resultTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
        <caption style="text-align: left">
            &nbsp;&nbsp;<%=survey.Name%>&nbsp;&nbsp; 
        </caption>
        <thead>
            <tr  class="topTitle" align="center">
           
                <th>
                    问题
                </th>
                <th>
                    选项A
                </th>
                <th>
                    选项B
                </th>
                <th>
                    选项C
                </th>
                <th>
                    选项D
                </th>

            </tr>
        </thead>
        <tbody>
        <%
            for (int i = 0; i < surveyQuestionLists.Count; i++)
            {
          %>
                 <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
               
                  <td><%=surveyQuestionLists[i].Question%></td>
                  <td><%=surveyQuestionLists[i].AnswerA%>
                        <br />
                     <input type="radio" name="id<%=surveyQuestionLists[i].ID  %>" value="A" /> 
                  </td>
                  <td><%=surveyQuestionLists[i].AnswerB%>                        <br />
				    <input type="radio" name="id<%=surveyQuestionLists[i].ID  %>" value="B" /> 
                      </td>
                  <td><%=surveyQuestionLists[i].AnswerC%>                        <br />
				  <input type="radio"  name="id<%=surveyQuestionLists[i].ID  %>" value="C" /> 
                      </td>
                  <td><%=surveyQuestionLists[i].AnswerD%>                        <br />
				  <input type="radio" name="id<%=surveyQuestionLists[i].ID  %>"  value="D" /> 
                     </td>
            
                 </tr>
        <%     }
        %>

                    <tr>
                     <td colspan="7">
						<input type="submit" value="提交" />

							<input type="reset" value="重置"  style="margin-left:20px;"/>
                     </td>
                    </tr>
       
        </tbody>
   
 
    </table>
    </form>
</body>
</html>
