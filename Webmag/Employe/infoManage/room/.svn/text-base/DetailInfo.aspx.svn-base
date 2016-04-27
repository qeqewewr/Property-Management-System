<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailInfo.aspx.cs" Inherits="Webmag_Employe_infoManage_room_DetailInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/> 
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
       <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>
    <script type="text/javascript" src="../../../Scripts/slide/js/jquery.anythingslider.js"></script>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/slide/css/anythingslider.css"/>



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
            var b = $("#roomNum").val();


            if ($.trim(b) == "") {
                alert("房间号不能为空，请输入房间号！");
                $("#roomNum").focus();
                return false;
            }


            return true;


        }


    

    </script>
    
</head>
<body>
    <div id="Div1"  runat="server" >
        
      
    <form name="ViewRoom"  >
    
        <table class="addTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;房间信息编辑&nbsp;&nbsp;
			</caption>

			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            大楼名称
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
               <select name="roomBuild" id="roomBuild" disabled="disabled">
                    <option><%=room.BuildingName%></option>
               </select>    
               </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>管理员
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomAdmin" disabled="disabled" type="text" size="26" name="roomAdmin" value="<%=room.Admin %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>房间号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomNum" type="text" size="26" name="roomNum" value="<%= room.Number %>" disabled="disabled" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

     <%--       <tr >
               <td class="leftTitle" >
		             楼层
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomFloor" type="text" disabled="disabled" size="26" name="roomFloor" value="<%=room.Floor %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            <tr >--%>
               <td class="leftTitle" >
		             朝向
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="roomToward" id="roomToward" disabled="disabled" >
                        <option><%= room.Toward%></option>
                    </select>
    		   </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             装修情况
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select id="roomDecor"  name="roomDecor" disabled="disabled" >
                        <option><%= room.Decoration%></option>
                    </select>
    		   </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             房间面积
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomArea" type="text" disabled="disabled" size="26" name="roomArea" value="<%=room.Area %>" />&nbsp;&nbsp;&nbsp;平方米
    		   </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             室内层高
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomHeight" type="text" disabled="disabled" size="26" name="roomHeight" value="<%=room.FloorHeight %>" />&nbsp;&nbsp;&nbsp;米
    		   </td>
            </tr>
           
            <tr >
                <td class="leftTitle" >
		            房型图
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
                   <select name="roomRoomStyle" id="roomRoomStyle" disabled="disabled" >
                        <option><%= room.RoomStyle%></option>
                   </select>
                   <%roomStyle = roomStyleDAO.GetRoomStyleByName(room.RoomStyle);%>
    		       <a rel="facebox" href="DetailRoomStyle.aspx?id=<%=roomStyle.ID %>"><input type="button" class="viewBtn" id="view" name="view" onclick="View()" />
    		    </td>
            </tr>

            <tr>
               <td class="leftTitle" >
		            产权类型
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
               <%if (room.Style == false)
                 {%>
                    <input type="radio" name="roomStyle" value="false"  checked="true" disabled="disabled"/>&nbsp; &nbsp;小业主
                    <input type="radio" name="roomStyle" value="true" disabled="disabled" />&nbsp; &nbsp;开发商
               <%}
                 else
                 { %>
    		        <input type="radio" name="roomStyle" value="false" disabled="disabled" />&nbsp; &nbsp;小业主
                    <input type="radio" name="roomStyle" value="true" checked="true" disabled="disabled"/>&nbsp; &nbsp;开发商
               <%} %>
    		   </td>
            </tr>
            
            <tr >
                <td class="leftTitle" >
		            最短租期
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomMinLease" type="text" disabled="disabled" size="26" name="roomMinLease" value="<%=room.MinLease %>" />&nbsp;&nbsp;&nbsp;月
    		    </td>
            </tr>

            <tr >
                <td class="leftTitle" >
		            支付方式
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomPayMode" type="text" disabled="disabled" size="26" name="roomPayMode" value="<%=room.PayMode %>" />&nbsp;&nbsp;&nbsp;
    		    </td>
            </tr>

            <tr >
                <td class="leftTitle" >
		            租金
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomRent" type="text" disabled="disabled" size="26" name="roomRent" value="<%=room.Rent %>" />&nbsp;&nbsp;&nbsp;元
    		    </td>
            </tr>
                      

            <tr >
                <td class="leftTitle" >
		            物业管理费
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomManFee" type="text" disabled="disabled" size="26" name="roomManFee" value="<%=room.ManageFee %>" />&nbsp;&nbsp;&nbsp;元
    		    </td>
            </tr>
<%--
            <tr >
               <td class="leftTitle" >
		             税费
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomTaxes" type="text" disabled="disabled" size="26" name="roomTaxes" value="<%=room.Taxes %>" />&nbsp;&nbsp;&nbsp;元
    		   </td>
            </tr>--%>
            

             <tr>
               <td class="leftTitle" >
		            出租情况
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
               <%if (room.IsRent == true)
                 {%>
    		        <input type="radio" name="roomIsRent" value="true" checked="true" disabled="disabled" />&nbsp; &nbsp;已出租
                    <input type="radio" name="roomIsRent" value="false" disabled="disabled" />&nbsp; &nbsp;未出租
               <%}
                 else
                 { %>
                    <input type="radio" name="roomIsRent" value="true" disabled="disabled" />&nbsp; &nbsp;已出租
                    <input type="radio" name="roomIsRent" value="false" checked="true" disabled="disabled"/>&nbsp; &nbsp;未出租
               <%} %>
    		   </td>
            </tr>
            <%if (room.IsRent == true)
              {%>
            
            <tr >
               <td class="leftTitle" >
		             租住公司
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="roomLessee" id="roomLessee" disabled="disabled">
                        <option><%= room.Lessee%></option>
                    </select>
    		   </td>
            </tr>


            <tr >
               <td class="leftTitle" >
		             入住时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomRentStart" type="text" disabled="disabled" size="26" name="roomRentStart" value="<%=rentStart %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             截止时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomRentEnd" type="text" disabled="disabled" size="26" name="roomRentEnd" value="<%=rentEnd %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            <%} %>

            

             <tr >
               <td class="leftTitle" >
		             备注信息
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		      <textarea name="roomRemark" id="roomRemark" disabled="disabled"  rows="4" cols="80%"><%=room.Remark %></textarea>
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             加入房源
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
               <%if (room.IsShowed == true)
                 { %>
    		        <input type="radio" name="roomIsShowed" value="true" checked="true" disabled="disabled" />&nbsp; &nbsp;是
                    <input type="radio" name="roomIsShowed" value="false" disabled="disabled" />&nbsp; &nbsp;否
               <%}
                 else
                 { %>
                    <input type="radio" name="roomIsShowed" value="true" disabled="disabled" />&nbsp; &nbsp;是
                    <input type="radio" name="roomIsShowed" value="false" checked="true" disabled="disabled" />&nbsp; &nbsp;否
               <%} %>
    		   </td>
            </tr>
            
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
					<input name="btnBack" type="button" class="backBtn" id="btnBack" onclick="window.location.href='ViewRoom.aspx?pageno=<%=pageno %>&keyword=<%= keyword %>&scope=<%=scope %>&buildName=<%=buildName %> '" value="" />										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
</body>
</html>
