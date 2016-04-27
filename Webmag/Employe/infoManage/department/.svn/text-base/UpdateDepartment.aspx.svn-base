<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateDepartment.aspx.cs" Inherits="Webmag_Employe_infoManage_department_UpdateDepartment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>


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

        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var s = $("#departmentID").val();
            var n = $("#departmentName").val();
            if ($.trim(s) == "") {
                alert("部门编号不能为空，请输入部门编号！");
                $("#departmentID").focus();
                return false;
            }
            else {
                if ($.trim(n) == "") {
                    alert("部门名称不能为空，请输入部门名称！");
                    $("#departmentName").focus();
                    return false;
                }
                else
                    return true;
            }
        }
        
    </script>
    
</head>


<body>
    
  <div runat="server" >
        
      
  <form name="updateEmploye" action="DoUpdate.aspx?oldid=<%= depart.ID %>&pageno=<%= pageno %>" onsubmit="return checkForm()" method="post" >
        

        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;部门信息编辑&nbsp;&nbsp;
			</caption>
            
			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>    
            
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>部门编号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="departmentID" type="text" readonly="readonly" size="26" name="departmentID" value="<%= depart.ID %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>    	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>部门名称
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="departmentName" type="text" readonly="readonly" size="26" name="departmentName" value="<%= depart.Name %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;部门主管
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="Text1" type="text" size="26" name="departmentManager" value="<%= depart.Manager %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;部门地址
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="departmentAddress" type="text" size="26" name="departmentAddress" value="<%= depart.Address %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
    
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="updateBtn" />
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewDepartment.aspx?pageno=<%=pageno %> '" value="" />										
    			</td>
    				
    		</tr>
    		
        </table> 
            
     </form>
    </div>
    
</body>
</html>
