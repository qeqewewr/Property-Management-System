﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateQuitOrder.aspx.cs" Inherits="Webmag_Employe_quitorder_UpdateQuitOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 
     <title></title>
     <link rel="Stylesheet" type="text/css" href="../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../Scripts/cal.js"></script>
    <script language="javascript" type="text/javascript" src="../../Scripts/cal/datetimepicker.js"></script>


    <style type="text/css">
        .button {
	BORDER-BOTTOM: #636467 1px solid; BORDER-LEFT: #636467 1px solid; PADDING-BOTTOM: 1px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT: 12px/17px "songti"; BACKGROUND: url(images/btn_bg.gif) repeat-x 0px -1px; COLOR: #000; BORDER-TOP: #636467 1px solid; BORDER-RIGHT: #636467 1px solid; PADDING-TOP: 1px
}
    .contentCenter {
	TEXT-ALIGN: left; MARGIN: 0px auto; WIDTH: 800px ; border:1px solid #cccccc;padding-top:20px;
}

        </style>
    
    <script language="javascript" type="text/javascript">

        $(function () {
            $("#quitOrderDateTime").change(function () {
                var bookTime = $(this).val();
                $.get('../../CheckTimeHandler.ashx?t=' + escape(bookTime), function (r) {
                    var html = '<font color="red" size="4">' + r + "</font>";
                    $("#checkBookTime").html(html);
                });
            });
        });
        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var d = $("#quitOrderDirector").val();
            var dp = $("#quitOrderDirectorPhone").val();
            var gn = $("#quitOrderGoodsNum").val();
            var is = $("#quitOrderIsSure").val();
            var dt = $("#quitOrderDateTime").val();

            if ($.trim(d) == "") {
                alert("联系人不能为空，请重新输入联系人！");
                $("#quitOrderDirector").focus();
                return false;
            }

            if ($.trim(dp) != "") {
                if (!isMobilePhone(dp, "#quitOrderDirectorPhone") && !isTelephone(dp, "#quitOrderDirectorPhone")) {
                    $("#quitOrderDirectorPhone").focus();
                    return false;
                }
            } else {
                alert("联系人电话不能为空，请重新输入联系人电话！");
                $("#quitOrderDirectorPhone").focus();
                return false;
            }

            
            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(dt);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("预约时间格式有误，请重新输入！");
                $("#quitOrderDateTime").focus();
                return false;
            }
           

            //判断字符串是否是数字串
            if ($.trim(gn) == "" || isNaN($.trim(gn))) {
                alert("物品数量必须是整数,请重新输入!");
                $("#quitOrderGoodsNum").focus();
                return false;
            }

            var frm = document.getElementById("editQuitOrder");
            var nCount = frm.length;
            for (var i = 0; i < nCount; i++) {
                frm[i].disabled = false;
            }

            return true;
        }
        
    </script>
</head>
<body>
    <div id="Div1"  runat="server" >
        
    <form name="editQuitOrder" action="DoUpdate.aspx?oldid=<%= id %>&pageno=<%= pageno %>" onsubmit="return checkForm()" method="post" >
        <input type="hidden" name="action" value="<%=action %>" />
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;退租预约信息编辑&nbsp;&nbsp;
			</caption>
 

            <tr>
                <td class="leftTitle">注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
            </tr>     	        			   

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>租户
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderLessee" type="text" size="26" name="quitOrderLessee"  value="<%= quitOrder.Lessee %>"  disabled="true"/>&nbsp;&nbsp;&nbsp;
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>楼宇
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderBuildingName" type="text" size="26" name="quitOrderBuildingName" value="<%= quitOrder.BuildingName %>" disabled="true"/>&nbsp;&nbsp;&nbsp; 
               </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>房间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderRoom" type="text" size="26" name="quitOrderRoom"  value="<%= quitOrder.Room %>" disabled="true"/>&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>联系人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderDirector" type="text" size="26" name="quitOrderDirector"  value="<%= quitOrder.Director %>" <%if(role=="property"){%> disabled="true" <%}%>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>联系人号码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="quitOrderDirectorPhone" type="text" size="26" name="quitOrderDirectorPhone" value="<%= quitOrder.DirectorPhone %>" <%if(role=="property"){%> disabled="true" <%}%>/>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>预约时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="quitOrderDateTime" type="text" size="26" name="quitOrderDateTime" value="<%= quitOrder.DateTime %>" <%if(role=="property"){%> disabled="true" <%}%>/>&nbsp;&nbsp;&nbsp;<img src="../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('quitOrderDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer" <%if(role=="property"){%> disabled="true" <%}%>/>
                    &nbsp; &nbsp; &nbsp;<div id="checkBookTime"></div>
    		   </td>
            </tr>

           <tr >
               <td class="leftTitle" >
		              <font color="red"> &nbsp;*</font>物品车数(以五吨车为基准)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="quitOrderGoodsNum" type="text" size="26" name="quitOrderGoodsNum" value="<%= quitOrder.GoodsNum %>" <%if(role=="property"){%> disabled="true" <%}%>/>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否确认
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="quitOrderIsSure" style="width: 41px" <% if (role=="lessee"){%> disabled="true" <%}%>>
                    <%if (quitOrder.IsSure == true)
                      {%>
                          <option value="是">是</option>
                          <option value="否">否</option>
                    <%}
                      else
                      { %>      
                          <option value="否">否</option>
                          <option value="是">是</option>
                    <%} %>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>   
            
             <tr >
               <td class="leftTitle" >
		              &nbsp;&nbsp;备注
               </td>
              <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="6" cols="75%" id="quitOrderRemarks" name="quitOrderRemarks" <%if(role=="lessee"){%>disabled="true"<%}%>><%=quitOrder.Remarks%></textarea>
    		   </td>
            </tr>

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn" />
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewQuitOrder.aspx?pageno= <%= pageno %>&action=<%=action %>'" value=""/>										
    			</td>
    				
    		</tr>
    		
        </table>
            
     </form>
    </div>
</body>
</html>
