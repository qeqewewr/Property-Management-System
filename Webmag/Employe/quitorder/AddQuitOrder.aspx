<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddQuitOrder.aspx.cs" Inherits="Webmag_Employe_quitorder_AddQuitOrder" %>

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
            $("#quitOrderLessee").change(function () {
                var lessee = $(this).val();
                $.get('../../../SelectHandler.ashx?zuhu=' + escape(lessee), function (r) {
                    var b = r.toString().split(',');
                    var htmlBuilding = '<option value="' + "BuildingName" + '">' + "请选择" + "</option>";
                    var htmlRoom = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                    for (var i = 0; b[i]; i++) {
                        htmlBuilding += '<option value="' + b[i] + '">' + b[i] + "</option>";
                    }
                    $("#quitOrderBuildingName").html(htmlBuilding);
                    $("#quitOrderRoom").html(htmlRoom);
                });
            });
        });

        $(function () {
            $("#quitOrderBuildingName").change(function () {
                var build = $(this).val();
                $.get('../../../SelectHandler.ashx?lou=' + escape(build), function (d) {

                    var rooms = d.toString().split(',');
                    var html = '<option value="' + "Room" + '">' + "请选择" + "</option>"; ;
                    for (var i = 0; rooms[i]; i++) {
                        html += '<option value="' + rooms[i] + '">' + rooms[i] + "</option>";

                    }

                    $("#quitOrderRoom").html(html);
                });
            });
        });

        $(function () {
            $("#quitOrderDateTime").change(function () {

                var bookTime = $(this).val();
                //alert(bookTime);
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
            var c = $("#quitOrderDateTime").val();
            var d = $("#quitOrderDirector").val();
            var dp = $("#quitOrderDirectorPhone").val();
            var g = $("#quitOrderGoodsNum").val();
            var l = $("#quitOrderLessee").val();
            var b = $("#quitOrderBuildingName").val();
            var r = $("#quitOrderRoom").val();


            if ($.trim(l) == "Lessee") {
                alert("请选择租户！");
                $("#quitOrderLessee").focus();
                return false;
            }

            if ($.trim(b) == "BuildingName") {
                alert("请选择楼宇！");
                $("#quitOrderBuildingName").focus();
                return false;
            }

            if ($.trim(r) == "Room") {
                alert("请选择房间号！");
                $("#quitOrderRoom").focus();
                return false;
            }
            if ($.trim(d) == "") {
                alert("联系人不能为空，请重新输入联系人！");
                $("#quitOrderDirector").focus();
                return false;
            }

            if ($.trim(dp) != "") {
                if (!isMobilePhone(dp, "#quitOrderDirectorPhone") && !isTelephone(dp, "#quitOrderDirectorPhone")) {
                    alert("您输入的联系人电话有误，请重新输入！");
                    $("#quitOrderDirectorPhone").focus();
                    return false;
                }
            } else {
                alert("联系人电话不能为空，请重新输入联系人电话！");
                $("#quitOrderDirectorPhone").focus();
                return false;
            }

            
            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(c);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("您输入的预约时间输入格式有错，请重新输入！");
                $("#quitOrderDateTime").focus();
                return false;
            }
            

            //判断字符串是否是数字串
            if (!$.trim(g) || isNaN($.trim(g))) {
                alert("搬运车数必须是整数,请重新输入!");
                $("#quitOrderGoodsNum").focus();
                return false;
            }

            var frm = document.getElementById("addQuitOrder");
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
  
    <form id= "addQuitOrder" name="addQuitOrder" action="SaveQuitOrder.aspx" onsubmit="return checkForm()" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;退租预约信息添加&nbsp;&nbsp;
			</caption>
           
			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>租户
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="quitOrderLessee" id="quitOrderLessee" style="width: 189px">
                   <% if (role == "property")
                      { %>                     
                        <option value = "Lessee">请选择</option>    
                        <%for (int i = 0; i < lesseeList.Count; i++)
                          { %>
                         <option value="<%=lesseeList[i].Name %>"><%=lesseeList[i].Name%></option>
                        <%} %>
                  <%}
                      else
                      {%>
                      <option value = "Lessee">请选择</option>    
                      <option value="<%=lessee.Name %>"><%=lessee.Name%></option>
                  <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>楼宇
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="quitOrderBuildingName" id="quitOrderBuildingName" 
                        style="width: 105px">                        
                         <option value = "BuildingName">请选择</option>
                        <%for (int i = 0; i < buildingList.Count; i++)
                          { %>
                        <option value="<%=buildingList[i].Name %>"><%=buildingList[i].Name%></option>
                        <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
           
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>房间号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="quitOrderRoom" id="quitOrderRoom" style="width: 105px">                        
                       <option value ="Room">请选择</option>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            
           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderDirector" type="text" size="26" name="quitOrderDirector" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderDirectorPhone" type="text" size="26" name="quitOrderDirectorPhone" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>预约日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderDateTime" type="text" size="26" name="quitOrderDateTime" value="" />&nbsp;&nbsp;&nbsp;<img src="../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('quitOrderDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer"/>
                   &nbsp; &nbsp; &nbsp;<div id="checkBookTime"></div>
               </td>
            </tr>    
              
             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>几车(单位:吨位)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="quitOrderGoodsNum" type="text" size="26" name="quitOrderGoodsNum" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    
            
            

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否确认
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="quitOrderIsSure" style="width: 39px" <%if(role=="lessee"){%>disabled="true"<%}%>>
                          <option value="否">否</option>
                          <option value="是">是</option>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>  
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewQuitOrder.aspx?pageno=1 '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>

</html>
