<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailInfo.aspx.cs" Inherits="Webmag_Employe_infoManage_employe_DetailInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>
    
    <style type="text/css">
        .button {
	BORDER-BOTTOM: #636467 1px solid; BORDER-LEFT: #636467 1px solid; PADDING-BOTTOM: 1px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT: 12px/17px "songti"; BACKGROUND: url(images/btn_bg.gif) repeat-x 0px -1px; COLOR: #000; BORDER-TOP: #636467 1px solid; BORDER-RIGHT: #636467 1px solid; PADDING-TOP: 1px
}
    .contentCenter {
	TEXT-ALIGN: left; MARGIN: 0px auto; WIDTH: 800px ; border:1px solid #cccccc;padding-top:20px;
}

        .style1
        {
            height: 25px;
        }

    </style>

</head>


<body>
    <div id="Div1"  runat="server" >
        
      
    <form name="ViewEmploye" action="" >
        <input type="hidden" name="employeStatus" value="<%=employe.Status %>" />
      
        
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;员工详细信息查看&nbsp;&nbsp;
			</caption>

			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>员工ID
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="employeID" disabled="disabled" type="text" size="26" name="employeID" value="<%=employe.EmployeID %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>姓名
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeName" type="text" size="26" disabled="disabled" name="employeName" value="<%=employe.Name %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             身份证号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeIDNum" type="text" disabled="disabled" size="26" name="employeIDNum" value="<%=employe.IDNumber %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;性别
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="employeSex" disabled="disabled">
                    <%if (employe.Sex == "男")
                      {%>
                          <option value="男">男</option>
                          <option value="女">女</option>
                    <%}
                      else
                      { %>
                          <option value="女">女</option>
                          <option value="男">男</option>
                    <%} %>
                          
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             民族
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeNation" disabled="disabled" type="text" size="26" name="employeNation" value="<%=employe.Nation %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             出生日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeBirth" type="text" disabled="disabled" size="26" name="employeBirth" value="<%= birth %>" />&nbsp;&nbsp;&nbsp;<img id="birthCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;政治面貌
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="employePolitics" disabled="disabled">
                    <%for (int i = 0; i < politics.Count; i++)
                      { %>
                        <option value="<%=politics[i] %>"><%=politics[i] %></option>
                    <%} %>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;学历
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="employeEdu" disabled="disabled">
                    <%for (int i = 0; i < education.Count; i++)
                      { %>
                        <option value="<%=education[i] %>"><%=education[i]%></option>
                    <%} %>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;部门
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
                    <select name="employeDepart" disabled="disabled">
                        <%for (int i = 0; i < list.Count; i++)
                          { %>
                        <option value="<%=list[i].Name %>"><%=list[i].Name%></option>
                        <%} %>
                    </select>
                    <!--
    		        <input class="inputText" id="employeDepart" type="text" size="26" name="employeDepart" value="" />
                    -->
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>


    
             <tr >
               <td class="leftTitle" >
		             办公电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeOTel" type="text" disabled="disabled" size="26" name="employeOTel" value="<%=employe.OfficeTel %>" />&nbsp;&nbsp;&nbsp;<font color="red">格式应为：区号-电话号码</font>
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             家庭电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeHTel" type="text" disabled="disabled" size="26" name="employeHTel" value="<%=employe.HomeTel %>" />&nbsp;&nbsp;&nbsp;<font color="red">格式应为：区号-电话号码</font>
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             手机号码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeMobile" type="text" size="26" disabled="disabled" name="employeMobile" value="<%=employe.Mobile %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             家庭住址
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeAddress" type="text" disabled="disabled" size="60" name="employeAddress" value="<%=employe.HomeAddress %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             电子邮箱
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeEmail" type="text" disabled="disabled" size="26" name="employeEmail" value="<%=employe.Email %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             入职时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeEnter" type="text" disabled="disabled" size="26" name="employeEnter" value="<%= enterDate %>" />&nbsp;&nbsp;&nbsp;<img id="enterCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             离职时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeLeave" type="text" disabled="disabled" size="26" name="employeLeave" value="<%= leaveDate %>" />&nbsp;&nbsp;&nbsp;<img id="leaveCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>
            
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewEmploye.aspx?pageno=<%=pageno %>&keyword=<%= keyword %>&scope=<%=scope %> '" value="" />										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
</body>
</html>
