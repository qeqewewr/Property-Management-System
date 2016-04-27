<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateTenementCost.aspx.cs" Inherits="Webmag_Employe_officework_tenementcost_UpdateTenementCost" %>

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
            var f = $("#tenementCostFee").val();
            var i = $("#tenementCostInputDateTime").val();
            var d = $("#tenementCostDeadline").val();

            //判断字符串是否是数字串
            if ($.trim(f) == "" || isNaN($.trim(f))) {
                alert("费用必须是整数,请重新输入!");
                $("#tenementCostFee").focus();
                return false;
            }
            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(i);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("录入时间输入格式有错，请重新输入时间！");
                $("#tenementCostInputDateTime").focus();
                return false;
            }

            theDate = $.trim(d);
            flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("截止日期输入格式有错，请重新输入时间！");
                $("#tenementCostDeadline").focus();
                return false;
            }

            var frm = document.getElementById("editTenementCost");
            var nCount = frm.length;
            for (var i = 0; i < nCount; i++)
                frm[i].disabled = false;

                return true;
        }
        
    </script>
</head>

<body>
  <div id="Div1" runat="server" >
  
    <form id= "editTenementCost" name="editTenementCost" action="DoUpdate.aspx?oldid=<%= id %>&pageno=<%= pageno %>" onsubmit="return checkForm()" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;租户费用信息编辑&nbsp;&nbsp;
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
    				<input class="inputText" id="tenementCostLessee" type="text" size="26" name="tenementCostLessee" disabled="disabled" value="<%= tenementCost.Lessee %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>楼宇
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostBuildingName" type="text" size="26" name="tenementCostBuildingName" disabled="disabled" value="<%= tenementCost.BuildingName %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>房间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostRoom" type="text" size="26" name="tenementCostRoom" disabled="disabled" value="<%= tenementCost.Room %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
               <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用类型
               </td>
              
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="tenementCostFeeType" style="width: 80px" <% if(role=="lessee"){%>disabled="true"<%}%>>                        
                        <%for (int i = 0; i < feeTypeList.Count; i++)
                          {
                              if (tenementCost.FeeType == feeTypeList[i].FeeName)
                              {%>
                                 <option value="<%=feeTypeList[i].FeeName %>" selected><%=feeTypeList[i].FeeName%></option>
                             <% } 
                            else 
                            {%>
                                <option value="<%=feeTypeList[i].FeeName %>"><%=feeTypeList[i].FeeName%></option>
                           <%}
				}%>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
               
            </tr>
            <tr>
               <td class="leftTitle">
		           &nbsp;&nbsp;费用(单位:元)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostFee" type="text" size="26" name="tenementCostFee" value="<%=tenementCost.Fee%>" <% if(role=="lessee"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

              <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用起始日期
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostStartDate" type="text" size="26" name="tenementCostStartDate" value="<%= tenementCost.StartDate %>" <% if(role=="lessee"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;<img id="startDateImg"  class="datepicker" src="../../../Images/cal.gif" <% if(role=="lessee"){%>disabled="true"<%}%>/>
                   
               </td>
            </tr>
           
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>费用截止日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostDeadline" type="text" size="26" name="tenementCostDeadline" value="<%=tenementCost.Deadline%>" <% if(role=="lessee"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;<img id="deadlineCalImg"  class="datepicker" src="../../../Images/cal.gif" <% if(role=="lessee"){%>disabled="true"<%}%>/>
                   
               </td>
            </tr>    
          
          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>录入员工
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		      
                  	<input class="inputText" id="tenementCostInputEmployId" type="text" size="26" name="tenementCostInputEmployId" value="<%=tenementCost.InputEmployId %>" <% if(role=="lessee"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
          
             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>录入时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="tenementCostInputDateTime" type="text" size="26" name="tenementCostInputDateTime" value="<%=tenementCost.InputDateTime%>" <% if(role=="lessee"){%>disabled="true"<%}%>/>&nbsp;&nbsp;&nbsp;<img 
                       src="../../../Scripts/cal/images2/cal.gif" 
                       onclick="javascript:NewCssCal('tenementCostInputDateTime','yyyyMMdd','dropdown',true,24,true)" 
                       style="cursor:pointer; margin-top: 0px;" <% if(role=="lessee"){%>disabled="true"
                       <%}%>/>
                   
               </td>
            </tr>    

       
            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否已支付
               </td>
              
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="tenementCostIsPayed" style="width: 42px">
                          <%if (tenementCost.IsPayed == true)
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
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewTenementCost.aspx?pageno=1 '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>
</html>
