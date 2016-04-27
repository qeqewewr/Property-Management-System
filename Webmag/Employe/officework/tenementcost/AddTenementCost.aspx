<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddTenementCost.aspx.cs" Inherits="Webmag_Employe_officework_tenementcost_AddTenementCost" %>

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

        </style>
   <script  type="text/javascript">  
     $(function () {
             $("#tenementCostLessee").change(function () {
                 var lessee = $(this).val();
                 $.get('../../../../SelectHandler.ashx?zuhu=' + escape(lessee), function (r) {
                     var b = r.toString().split(',');
                     var htmlBuilding = '<option value="' + "BuildingName" + '">' + "请选择" + "</option>";
                     var htmlRoom = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                     for (var i = 0; b[i]; i++) {
                        htmlBuilding += '<option value="' + b[i] + '">' + b[i] + "</option>";
                     }
                    $("#tenementCostBuildingName").html(htmlBuilding);
                    $("#tenementCostRoom").html(htmlRoom);
                 });
             });
         });

         $(function () {
             $("#tenementCostBuildingName").change(function () {
                 var build = $(this).val();
                 $.get('../../../../SelectHandler.ashx?lou=' + escape(build), function (d) {

                     var rooms = d.toString().split(',');
                     var html = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                     for (var i = 0; rooms[i]; i++) {
                         html += '<option value="' + rooms[i] + '">' + rooms[i] + "</option>";

                     }
                     $("#tenementCostRoom").html(html);
                 });
             });
         });
</script>

    <script language="javascript" type="text/javascript">

        $(function () {
            $('#tenementCostStartDate').simpleDatepicker({ y: 20, x: -20 });
            $("#startDateImg").bind('click', function () { $("#tenementCostStartDate").click(); });

            $('#tenementCostDeadline').simpleDatepicker({ y: 20, x: -20 });
            $("#deadlineCalImg").bind('click', function () { $("#tenementCostDeadline").click(); });
            $('.saveBtn').click(function () {
                return checkForm();
            });
        });

        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var l = $("#tenementCostLessee").val();
            var b = $("#tenementCostBuildingName").val();
            var r = $("#tenementCostRoom").val();
            var ft = $("#tenementCostFeeType").val();
            var f = $("#tenementCostFee").val();
            var i = $("#tenementCostInputDateTime").val();
            var d = $("#tenementCostDeadline").val();
            var s = $("#tenementCostStartDate").val();
            var ie = $("#tenementCostInputEmployId").val();
            if ($.trim(l) == "Lessee") {
                alert("请选择租户！");
                $("#tenementCostLessee").focus();
                return false;
            }

            if ($.trim(b) == "BuildingName") {
                alert("请选择楼宇！");
                $("#tenementCostBuildingName").focus();
                return false;
            }

            if ($.trim(r) == "Room") {
                alert("请选择房间号！");
                $("#tenementCostRoom").focus();
                return false;
            }

            if ($.trim(ft) == "FeeType") {
                alert("请选择费用类型！");
                $("#tenementCostFeeType").focus();
                return false;
            }
            //判断字符串是否是数字串
            if ($.trim(f) == "" || isNaN($.trim(f))) {
                alert("费用必须是数字,请重新输入!");
                $("#tenementCostFee").focus();
                return false;
            }


            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(s);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("费用起始时间输入格式有错，请重新输入时间！");
                $("#tenementCostStartDate").focus();
                return false;
            }

            theDate = $.trim(d);
            flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("费用截止日期输入格式有错，请重新输入时间！");
                $("#tenementCostDeadline").focus();
                return false;
            }

            if ($.trim(ie) == "") {
                alert("请输入录入员工姓名！");
                $("#tenementCostInputEmployId").focus();
                return false;
            }
                   
            //验证录入时间格式是否为yyyy/mm/dd
            theDate = $.trim(i);
            flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("录入时间输入格式有错，请重新输入时间！");
                $("#tenementCostInputDateTime").focus();
                return false;
            }

           
            return true;
        }

        function tenementCostInputDateTime_onclick() {

        }

    </script>
</head>

<body>
  <div id="Div1" runat="server" >
  
    <form id= "addTenementCost" name="addTenementCost" action="SaveTenementCost.aspx" onsubmit="return checkForm()" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;租户费用信息添加&nbsp;&nbsp;
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
    		       <select name="tenementCostLessee" id="tenementCostLessee" style="width: 194px">                        
                        <option value = "Lessee">请选择</option>
                        <%for (int i = 0; i < lesseeList.Count ; i++)
                          { %>
                        <option value="<%=lesseeList[i].Name %>"><%=lesseeList[i].Name%></option>
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
    		       <select name="tenementCostBuildingName" id = "tenementCostBuildingName" 
                        style="width: 103px">                        
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
    		       <select name="tenementCostRoom" id = "tenementCostRoom" style="width: 105px">                        
                       <option value = "Room">请选择</option>
                        <%for (int i = 0; i < roomList.Count; i++)
                          { %>
                        <option value="<%=roomList[i].Number %>"><%=roomList[i].Number%></option>
                        <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用类型
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="tenementCostFeeType" id="tenementCostFeeType" 
                       style="width: 105px">  
                   <option value = "FeeType">请选择</option>                      
                        <%for (int i = 0; i < feeTypeList.Count; i++)
                          { %>
                        <option value="<%=feeTypeList[i].FeeName %>"><%=feeTypeList[i].FeeName%></option>
                        <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            
           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用(单位:元)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostFee" type="text" size="26" name="tenementCostFee" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

         <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用起始日期
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostStartDate" type="text" size="26" name="tenementCostStartDate" value="" />&nbsp;&nbsp;&nbsp;<img id="startDateImg"  class="datepicker" src="../../../Images/cal.gif" />
                   
               </td>
            </tr>

            
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用截止日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostDeadline" type="text" size="26" name="tenementCostDeadline" value="" />&nbsp;&nbsp;&nbsp;<img id="deadlineCalImg"  class="datepicker" src="../../../Images/cal.gif" />
                   
               </td>
            </tr>   

          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>录入员工
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		      
                  	<input class="inputText" id="tenementCostInputEmployId" type="text" size="26" name="tenementCostInputEmployId" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>录入时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostInputDateTime" type="text" size="26" name="tenementCostInputDateTime" value="" onclick="return tenementCostInputDateTime_onclick()" />&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('tenementCostInputDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer"/>
                   
               </td>
            </tr>    
 
       
            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否已支付
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="tenementCostIsPayed" style="width: 42px">
                          <option value="否">否</option>
                          <option value="是">是</option>
                         
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>  
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewtenementCost.aspx?pageno=1 '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>

</html>
