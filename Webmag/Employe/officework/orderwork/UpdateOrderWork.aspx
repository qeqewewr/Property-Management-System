<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOrderWork.aspx.cs" Inherits="Webmag_Employe_officework_orderwork_UpdateOrderWork" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>

    <link rel="stylesheet" href="../../../../kindeditor-v4.0.4/themes/default/default.css" />
	<link rel="stylesheet" href="../../../../kindeditor-v4.0.4/plugins/code/prettify.css" />
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>

      <script language="javascript" type="text/javascript" src="../../../Scripts/cal/datetimepicker.js"></script>
    <style type="text/css">
        .button {
	BORDER-BOTTOM: #636467 1px solid; BORDER-LEFT: #636467 1px solid; PADDING-BOTTOM: 1px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT: 12px/17px "songti"; BACKGROUND: url(images/btn_bg.gif) repeat-x 0px -1px; COLOR: #000; BORDER-TOP: #636467 1px solid; BORDER-RIGHT: #636467 1px solid; PADDING-TOP: 1px
}
    .contentCenter {
	TEXT-ALIGN: left; MARGIN: 0px auto; WIDTH: 800px ; border:1px solid #cccccc;padding-top:20px;
}

        </style>
    
    <script language="javascript" type="text/javascript">
   
        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var ds = $("#orderWorkDayStart").val();
            var de = $("#orderWorkDayEnd").val();
            var ts = $("#orderWorkTimeStart").val();
            var te = $("#orderWorkTimeEnd").val();
            var f = $("#orderWorkFee").val();
            var n = $("#orderWorkNum").val();

            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(ds);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("您输入的加班开始时间格式有错，请重新输入！");
                $("#orderWorkDayStart").focus();
                return false;
            }

            var theDate = $.trim(de);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("您输入的加班结束时间格式有错，请重新输入！");
                $("#orderWorkDayEnd").focus();
                return false;
            }

            if ($.trim(n) == "" || isNaN($.trim(n))) {
                alert("加班人数必须是数字串,请重新输入!");
                $("#orderWorkNum").focus();
                return false;
            }


            //判断字符串是否是数字串
            if ($.trim(f) == "" || isNaN($.trim(f))) {
                alert("加班费用必须是数字串,请重新输入!");
                $("#orderWorkFee").focus();
                return false;
            }


           

            //使得控件数据可上传到服务器
            var frm = document.getElementById("editOrderWork");
            var nCount = frm.length;
            for (var i = 0; i < nCount; i++) {
                frm[i].disabled = false;
            }

            return true;
        }
        
    </script>
</head>

<body>
  <div id="Div1" runat="server" >
  
    <form id= "editOrderWork" name="editOrderWork" action="DoUpdate.aspx?oldid=<%= id %>&pageno=<%= pageno %>" onsubmit="return checkForm()" method="post" >
        <input type="hidden" name="action" value="<%= action %>" />
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;加班预约信息编辑&nbsp;&nbsp;
			</caption>
           
			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>租户
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkLessee" type="text" size="26" name="orderWorkLessee" disabled="disabled" value="<%= orderWork.Lessee %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>楼宇
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkBuildingName" type="text" size="26" name="orderWorkBuildingName" disabled="disabled" value="<%= orderWork.BuildingName %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>房间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkRoom" type="text" size="26" name="orderWorkRoom" disabled="disabled" value="<%= orderWork.Room %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
           
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班开始时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkDayStart" type="text" size="26" name="orderWorkDayStart" value="<%=orderWork.DayStart %>" <%if(role=="property"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('orderWorkDayStart','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer" <%if(role=="property"){%>disabled="true"<%}%>/>
                   &nbsp;&nbsp;&nbsp;<font color="red"> 时间格式如:2011/11/11 13:04:06</font>
                   
               </td>
          </tr>    

          
          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班结束时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkDayEnd" type="text" size="26" name="orderWorkDayEnd" value="<%=orderWork.DayEnd %>" <%if(role=="property"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('orderWorkDayEnd','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer" <%if(role=="property"){%>disabled="true"<%}%>/>
                   &nbsp;&nbsp;&nbsp;<font color="red"> 时间格式如:2011/11/11 13:04:06</font>
               </td>
          </tr> 

           <!--
          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班开始日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkDayStart" type="text" size="26" name="orderWorkDayStart" value="<%= orderWork.DayStart %>" />&nbsp;&nbsp;&nbsp;<img id="dayStartCalImg"  class="datepicker" src="../../../Images/cal.gif" />
                   
               </td>
          </tr>    

        <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班结束日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkDayEnd" type="text" size="26" name="orderWorkDayEnd" value="<%= orderWork.DayEnd %>" />&nbsp;&nbsp;&nbsp;<img id="dayEndCalImg"  class="datepicker" src="../../../Images/cal.gif" />
                   
               </td>
          </tr>   
          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班开始时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkTimeStart" type="text" size="26" name="orderWorkTimeStart" value="<%= orderWork.TimeStart %>" />&nbsp;&nbsp;&nbsp;<font color="red"> 时间格式如:13:04:06</font>
                   
               </td>
          </tr>     
          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班结束时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkTimeEnd" type="text" size="26" name="orderWorktimeEnd" value="<%= orderWork.TimeEnd %>" />&nbsp;&nbsp;&nbsp;<font color="red"> 时间格式如:13:04:06</font>
                   
               </td>
          </tr>     
         -->
            

           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班人数(单位:个)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkNum" type="text" size="26" name="orderWorkNum" value="<%= orderWork.Num %>" <%if(role=="property"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    
            
    	    <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;&nbsp;所需服务
               </td>
                   <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="5" cols="75%"id="orderWorkService" name="orderWorkService" <%if(role=="property"){%>disabled="true"<%}%>><%= orderWork.Service%></textarea>
    		   </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>加班费用(单位:元) 
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderWorkFee" type="text" size="26" name="orderWorkFee" value="<%= orderWork.Fee %>" <%if(role == "lessee"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;&nbsp;备注
               </td>
                   <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="5" cols="75%"id="orderWorkRemark" name="orderWorkRemark" <%if(role == "lessee"){%>disabled="true"<%}%>><%= orderWork.Remark %></textarea>
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否确认
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="orderWorkIsSure" style="width: 44px" <%if(orderWork.Fee == -1 || role == "property"){%>disabled="true"<%}%>>
                          <option value="是">是</option>
                          <option value="否" selected>否</option>
                    </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">(提示:管理员填写完加班费用后，您方可确认，确认后表单封存不可修改)</font>
    		   </td>
            </tr>  
          
          <tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewOrderWork.aspx?pageno=1&action=<%=action %> '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>
</html>
