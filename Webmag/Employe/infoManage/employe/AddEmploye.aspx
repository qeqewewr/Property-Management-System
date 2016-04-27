<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEmploye.aspx.cs" Inherits="Webmag_Employe_infoManage_employe_AddEmploye" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    
    <script language="javascript" type="text/javascript">
        $(function () {

            $('#employeBirth').simpleDatepicker({ y: 20, x: -20 });
            $("#birthCalImg").bind('click', function () { $("#employeBirth").click(); });
			
			
			
            $('#employeEnter').simpleDatepicker({ y: 20, x: -20 });
            $("#enterCalImg").bind('click', function () { $("#employeEnter").click(); });
            $('#employeLeave').simpleDatepicker({ y: 20, x: -20 });
            $("#leaveCalImg").bind('click', function () { $("#employeLeave").click(); });
            $('.saveBtn').click(function () {
                return checkForm();
            });
        });



        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var s = $("#employeID").val();
            var b = $("#employeName").val();
            //            var o = $("#employeOTel").val();
            var h = $("#employeHTel").val();
            var m = $("#employeMobile").val();
            var e = $("#employeEmail").val();
            var i = $("#employeIDNum").val();
            var et = $("#employeEnter").val();
            var lt = $("#employeLeave").val();

            if ($.trim(s) == "") {
                alert("员工ID不能为空，请输入员工ID！");
                $("#employeID").focus();
                return false;
            }

            if ($.trim(b) == "") {
                alert("员工姓名不能为空，请输入员工姓名！");
                $("#employeName").focus();
                return false;
            }

            if ($.trim(i) != "") {
                if (!(isIDNum(i))) {
                    alert("身份证号输入错误，请重新输入！");
                    $("#employeIDNum").focus();
                    return false;
                }
            }
            var birth = $("#employeBirth");
            var birthVal = $.trim(birth.val());
            var birthReg = /^\d{4}\/\d{1,2}\/\d{1,2}$/;
            if (birthVal != "") {
                if (!birthReg.test(birthVal)) {
                    alert("请输入正确的日期格式，如 2011/12/1");
                    birth.focus();
                    return false;
                }
            }
            //            if ($.trim(o) != "") {
            //                if (!(isTelephone(o, "#employeOTel"))) {
            //					alert("办公电话格式输入错误，请重新输入！");
            //                    $("#employeOTel").focus();
            //                    return false;
            //                }
            //            }

            if ($.trim(h) != "") {
                if (!(isTelephone(h, "#employeHTel"))) {
                    alert("家庭电话格式输入错误，请重新输入！");
                    $("#employeHTel").focus();
                    return false;
                }
            }

            if ($.trim(m) != "") {
                if (!(isMobilePhone(m, "#employeMobile"))) {
                    alert("手机号码格式输入错误，请重新输入！");
                    $("#employeMobile").focus();
                    return false;
                }
            }

            if ($.trim(e) != "") {
                if (!(isEmail(e, "#employeEmail"))) {
                    alert("电子邮箱格式输入错误，请重新输入！");
                    $("#employeEmail").focus();
                    return false;
                }
            }

            if ($.trim(et) == "" && $.trim(lt) != "") {
                alert("请输入入职时间！");
                $("#employeEnter").focus();
                return false;
            }

            return true;

        }


        function birthCalImg_onclick() {

        }

    </script>
    
</head>

<body>
    <div  runat="server" >
        
      
    <form name="editEmploye" action="SaveEmployeInfo.aspx" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;员工信息添加&nbsp;&nbsp;
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
    				<input class="inputText" id="employeID" type="text" size="26" name="employeID" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>姓名
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeName" type="text" size="26" name="employeName" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             身份证号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeIDNum" type="text" size="26" name="employeIDNum" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;性别
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="employeSex">
                          <option value="男">男</option>
                          <option value="女">女</option>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             密码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" disabled="disabled" id="employePsw" type="password" size="10" name="employePsw" value="******"/>&nbsp;&nbsp;&nbsp;初始密码：<font color="red">123456</font>
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             民族
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeNation" type="text" size="26" name="employeNation" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             出生日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeBirth" type="text" size="26" name="employeBirth" value="" />&nbsp;&nbsp;&nbsp;<img id="birthCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;政治面貌
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="employePolitics">
                          <option value="党员">党员</option>
                          <option value="预备党员">预备党员</option>
                          <option value="团员">团员</option>
                          <option value="群众">群众</option>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;学历
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="employeEdu">
                          <option value="本科">本科</option>
                          <option value="硕士">硕士</option>
                          <option value="高中">高中</option>
                          <option value="博士">博士</option>
                          <option value="大专">大专</option>
                          <option value="中专">中专</option>
                          <option value="初中">初中</option>
                          <option value="小学">小学</option>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;部门
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
                    <select name="employeDepart">
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
    		        <input class="inputText" id="employeOTel" type="text" size="26" name="employeOTel" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             家庭电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeHTel" type="text" size="26" name="employeHTel" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             手机号码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeMobile" type="text" size="26" name="employeMobile" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             家庭住址
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeAddress" type="text" size="60" name="employeAddress" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             电子邮箱
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeEmail" type="text" size="26" name="employeEmail" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             入职时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeEnter" type="text" size="26" name="employeEnter" value="" />&nbsp;&nbsp;&nbsp;<img id="enterCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             离职时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="employeLeave" type="text" size="26" name="employeLeave" value="" />&nbsp;&nbsp;&nbsp;<img id="leaveCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>
            
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn" />
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewEmploye.aspx?pageno=1 '" value="" />										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
</body>
</html>
