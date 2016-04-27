<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Webmag_Employe_changePSW_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../CSS/webmag.css" />

    <script type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../Scripts/webmag.js"></script>

    <script language="javascript" type="text/javascript">

        $(function () {
            $('.saveBtn').click(function () {
                return checkForm();
            });
        });

        function checkForm() {
            var p = $("#psw").val();
            var op = $("#oldPsw").val();
            var np = $("#newPsw").val();
            var rnp = $("#reNewPsw").val();
            if ($.trim(op) == "") {
                alert("原密码不能为空，请重新输入！");
                $("#oldPsw").focus();
                return false;
            }
            if ($.trim(p) != $.trim(op)) {
                alert("原密码错误，请重新输入");
                $("#oldPsw").val("");
                $("#newPsw").val("");
                $("#reNewPsw").val("");
                $("#oldPsw").focus();
                return false;
            }
            if ($.trim(np) == "") {
                alert("新密码不能为空，请重新输入！");
                $("#newPsw").focus();
                return false;
            }
            if ($.trim(rnp) == "") {
                alert("请再次输入新密码！");
                $("#reNewPsw").focus();
                return false;
            }
            if ($.trim(np) != $.trim(rnp)) {
                alert("两次密码输入不一致,请重新输入");
                $("#newPsw").val("");
                $("#reNewPsw").val("");
                $("#newPsw").focus();
                return false;
            }
            var a = confirm("确定修改密码？");
            if (!a)
                return false;
            return true;
        }   
        
    </script>

</head>
<body>
    <div id="Div1"  runat="server" >
        
      
    <form name="changePsw" action="DoChange.aspx" method="post" >

        <input type="hidden" id="psw" name="psw" value="<%=password %>" />
       
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;密码修改&nbsp;&nbsp;
			</caption>  	        			   
            
            <tr>
               <td class="leftTitle">
		           登录名
               </td>
               <%if (role == "lessee")
                 { %>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="lesseeName" disabled="disabled" type="text" size="26" name="userName" value="<%= lessee.Name %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
               <%}
                 else
                 { %>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="empoyeName" disabled="disabled" type="text" size="26" name="userName" value="<%= employe.EmployeID %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
               <%} %>
            </tr>
            

            <tr >
               <td class="leftTitle" >
		             请输入旧密码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="oldPsw" type="password" size="26" name="oldPsw" value="" />&nbsp;&nbsp;&nbsp;初始化密码为：<font color="red">123456</font>
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		            请输入新密码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="newPsw" type="password" size="26" name="newPsw" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		            请再次输入密码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="reNewPsw" type="password" size="26" name="reNewPsw" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn" />
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
</body>
</html>
