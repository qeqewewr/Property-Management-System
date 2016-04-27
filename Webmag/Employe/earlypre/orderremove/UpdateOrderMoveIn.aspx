<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateOrderMoveIn.aspx.cs" Inherits="Webmag_Employe_earlypre_orderremove_UpdateOrderMoveIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
     <title></title>
     <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>
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
        $(function () {
            $("#orderMoveInDateTime").change(function () {

                var bookTime = $(this).val();
                //alert(bookTime);
                $.get('../../../CheckTimeHandler.ashx?t=' + escape(bookTime), function (r) {
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
            var d = $("#orderMoveInDirector").val();
            var dp = $("#orderMoveInDirectorPhone").val();
            var gn = $("#orderMoveInGoodsNum").val();
            var is = $("#orderMoveInIsSure").val();
            var dt = $("#orderMoveInDateTime").val();
            
            if ($.trim(d) == "") {  
                alert("联系人不能为空，请重新输入联系人！");
                $("#orderMoveInDirector").focus();
                return false;
            }
          
          <%if(role == "lessee") {%>
            if ($.trim(dp) != "") {
                if (!isMobilePhone(dp, "#orderMoveInDirectorPhone") && !isTelephone(dp, "#orderMoveInDirectorPhone")) {
                    alert("联系人电话格式有误，请重新输入联系人电话！");
                    $("#orderMoveInDirectorPhone").focus();
                    return false;
                }
            } else {
                alert("联系人电话不能为空，请重新输入联系人电话！");
                $("#orderMoveInDirectorPhone").focus();
                return false;
            }
        <%} %>


           //验证日期格式是否为yyyy/mm/dd 
            var theDate = $.trim(dt);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
               alert("时间格式有错，请重新输入时间！");
                $("#orderMoveInDateTime").focus();
                return false;
            }
          
            //判断字符串是否是数字串
            if ($.trim(gn) == "" || isNaN($.trim(gn))) {
                alert("物品数量必须是整数,请重新输入!");
                $("#orderMoveInGoodsNum").focus();
                 return false;
            }

             var frm = document.getElementById("editOrderMoveIn");
             var nCount = frm.length;
             for (var i = 0; i < nCount; i++)
                 frm[i].disabled = false;

            return true;
        }
        
    </script>
</head>
<body>
    <div id="Div1"  runat="server" >
        
      
    <form id="editOrderMoveIn" name="editOrderMoveIn" action="DoUpdate.aspx?oldid=<%= id %>&pageno=<%=pageno%>" onsubmit="return checkForm()" method="post" >
       <input type="hidden" name="action" id="action" value="<%=action %>" />
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;搬入预约信息编辑&nbsp;&nbsp;
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
    				<input class="inputText" id="orderMoveInLessee" type="text" size="26" name="orderMoveInLessee" disabled="true" value="<%= orderMoveIn.Lessee %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>楼宇
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderMoveInBuildingName" type="text" size="26" name="orderMoveInBuildingName" disabled="true" value="<%= orderMoveIn.BuildingName %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>房间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderMoveInRoom" type="text" size="26" name="orderMoveInRoom" disabled="true" value="<%= orderMoveIn.Room %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>联系人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderMoveInDirector" type="text" size="26" name="orderMoveInDirector" value="<%= orderMoveIn.Director %>" <%if(role=="property"){ %>disabled="true"<%} %> />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>联系人号码
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="orderMoveInDirectorPhone" type="text" size="26" name="orderMoveInDirectorPhone"  value="<%=orderMoveIn.DirectorPhone%>" <%if(role=="property"){%>disabled="true"<%} %> />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>预约时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="orderMoveInDateTime" type="text" size="26" name="orderMoveInDateTime"  value="<%= orderMoveIn.DateTime %>" <%if(role=="property"){%>disabled="true"<%} %> />&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('orderMoveInDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer" <%if(role=="property"){%>disabled="true"<%} %> />
    		           &nbsp; &nbsp; &nbsp;<div id="checkBookTime"></div>
               </td>
            </tr>

           <tr >
               <td class="leftTitle" >
		              <font color="red"> &nbsp;*</font>几车(单位:吨位)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="orderMoveInGoodsNum" type="text" size="26" name="orderMoveInGoodsNum" value="<%= orderMoveIn.GoodsNum %>" <%if(role=="property"){%>disabled="true"<%} %> />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否确认
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="orderMoveInIsSure" id="orderMoveInIsSure" style="width: 45px" <% if(role=="lessee"){%>disabled="true"<%} %>>
                    <%if (orderMoveIn.IsSure == true)
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
                    <textarea rows="6" cols="75%" id="orderMoveInRemarks" name="orderMoveInRemarks" <%if(role=="lessee"){%>disabled="true"<%}%>><%=orderMoveIn.Remarks%></textarea>
    		   </td>
            </tr>

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn" />
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewOrderRemove.aspx?pageno= <%= pageno %>&action=<%=action %>'" value=""/>										
    			</td>
    				
    		</tr>
    		
        </table>
            
     </form>
    </div>
</body>
</html>
