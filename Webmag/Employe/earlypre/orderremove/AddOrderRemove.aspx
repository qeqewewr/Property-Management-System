<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddOrderRemove.aspx.cs" Inherits="Webmag_Employe_earlypre_orderremove_AddOrderRemove" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

        #checkBookTimeBtn
        {
            width: 169px;
        }

        </style>
    
    
     <script type="text/javascript">

         $(function () {
             $("#orderRemoveLessee").change(function () {
                 var lessee = $(this).val();
                 $.get('../../../../SelectHandler.ashx?zuhu=' + escape(lessee), function (r) {
                     var b = r.toString().split(',');
                     var htmlBuilding = '<option value="' + "BuildingName" + '">' + "请选择" + "</option>";
                     var htmlRoom = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                     for (var i = 0; b[i]; i++) {
                         htmlBuilding += '<option value="' + b[i] + '">' + b[i] + "</option>";
                     }
                     $("#orderRemoveBuildingName").html(htmlBuilding);
                     $("#orderRemoveRoom").html(htmlRoom);
                 });
             });
         });

         $(function () {
             $("#orderRemoveBuildingName").change(function () {
                 var build = $(this).val();
                 $.get('../../../../SelectHandler.ashx?lou=' + escape(build), function (d) {
                     var rooms = d.toString().split(',');
                     var html = '<option value="' + "Room" + '">' + "请选择" + "</option>"; ;
                     for (var i = 0; rooms[i]; i++) {
                         html += '<option value="' + rooms[i] + '">' + rooms[i] + "</option>";

                     }

                     $("#orderRemoveRoom").html(html);
                 });
             });
         });

         $(function () {
             $("#orderRemoveDateTime").change(function () {
                 var bookTime = $(this).val();
                 $.get('../../../CheckTimeHandler.ashx?t=' + escape(bookTime), function (r) {
                     var html = '<font color="red" size="4">' + r + "</font>";
                     $("#checkBookTime").html(html);
                 });
             });
         });
</script>

    <script language="javascript" type="text/javascript">

        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var c = $("#orderRemoveDateTime").val();
            var d = $("#orderRemoveDirector").val();
            var dp = $("#orderRemoveDirectorPhone").val();
            var g = $("#orderRemoveGoodsNum").val();

            var l = $("#orderRemoveLessee").val();
            var b = $("#orderRemoveBuildingName").val();
            var r = $("#orderRemoveRoom").val();
         

            if ($.trim(l) == "Lessee") {
                alert("请选择租户！");
                $("#orderRemoveLessee").focus();
                return false;
            }

            if ($.trim(b) == "BuildingName") {
                alert("请选择楼宇！");
                $("#orderRemoveBuildingName").focus();
                return false;
            }

            if ($.trim(r) == "Room") {
                alert("请选择房间号！");
                $("#orderRemoveRoom").focus();
                return false;
            }

            if ($.trim(d) == "") {
                 alert("联系人不能为空，请重新输入联系人！");
                $("#orderRemoveDirector").focus();
                return false;
            }
            
            if ($.trim(dp) != "") {
                if (!isMobilePhone(dp, "#orderRemoveDirectorPhone") && !isTelephone(dp, "#orderRemoveDirectorPhone")) {
                    $("#orderRemoveDirectorPhone").focus();
                    return false;
                }
            } else {
                alert("联系人电话不能为空，请重新输入联系人电话！");
                $("#orderRemoveDirectorPhone").focus();
                return false;
            }       
            
            
            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(c);
            var flag = isdate(theDate);
            if ( theDate == "" || !flag) {
                alert("预约时间输入格式有错，请重新输入预约时间！");
                $("#orderRemoveDateTime").focus();
                return false;
            }
            
            //判断字符串是否是数字串
            if (!$.trim(g) || isNaN($.trim(g))) {
                alert("搬运车数必须是整数,请重新输入!");
                $("#orderRemoveGoodsNum").focus();
                return false;
            }

            var frm = document.getElementById("addOrderRemove");
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
  
    <form id= "addOrderRemove" name="addOrderRemove" action="SaveOrderRemove.aspx" onsubmit="return checkForm()" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;搬入预约信息添加&nbsp;&nbsp;
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
    		       <select name="orderRemoveLessee" id = "orderRemoveLessee" 
                        style="width: 190px; margin-bottom: 0px;">  
                         <option value = "Lessee">请选择</option> 
                          <%if (role == "property")
                            {%>                       
                                <%for (int i = 0; i < lesseeList.Count; i++)
                                  { %>
                                <option value="<%=lesseeList[i].Name %>"><%=lesseeList[i].Name%></option>
                                <%} %>
                        <%}
                            else
                            {%>
                                <option value="<%=Session["UserName"].ToString() %>"><%=Session["UserName"].ToString()%></option>
                          <%}%>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>楼宇
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="orderRemoveBuildingName" id = "orderRemoveBuildingName" 
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
    		       <select name="orderRemoveRoom" id = "orderRemoveRoom" style="width: 105px">                        
                        <option value = "Room">请选择</option>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            
           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderRemoveDirector" type="text" size="26" name="orderRemoveDirector" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderRemoveDirectorPhone" type="text" size="26" name="orderRemoveDirectorPhone" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>预约日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderRemoveDateTime" type="text" size="26" name="orderRemoveDateTime" value="" />&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('orderRemoveDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer"/>
                    &nbsp; &nbsp; &nbsp;
                    <div id="checkBookTime"></div>
                   </td>
             
            </tr>    
              
             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>几车(单位:吨位)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="orderRemoveGoodsNum" type="text" size="26" name="orderRemoveGoodsNum" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    
            
            

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否确认
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="orderRemoveIsSure" style="width: 43px" <%if(role=="lessee"){%>disabled="true"<%}%>>
                          <option value="否">否</option>
                          <option value="是">是</option>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>  
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewOrderRemove.aspx?pageno=1 '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>

</html>
