<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRoom.aspx.cs" Inherits="Webmag_Employe_infoManage_room_AddRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/> 
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>
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
        $(function () {

            $('#roomRentStart').simpleDatepicker({ y: 20, x: -20 });
            $("#startCalImg").bind('click', function () { $("#roomRentStart").click(); });
            $('#roomRentEnd').simpleDatepicker({ y: 20, x: -20 });
            $("#endCalImg").bind('click', function () { $("#roomRentEnd").click(); });
            
            $('.saveBtn').click(function () {
                return checkForm();
            });
        });



        function Close() {
            window.opener.location.reload();
            window.close();
        }


        function getAdmin() {
            var build = $.trim($("#roomBuild").val());
            var buildID = $("#buildID");
            var employe = $("#roomAdmin");

//            buildID.val("");

//            employe.val("");

            $.ajax({

                url: "AjaxGetAdmin.aspx",
                data: "build=" + build,
                dataType: "xml",
                type: "post",
                error: function (XMLHttpRequest, textStatus) { alert(XMLHttpRequest.status + textStatus); },
                success: function (xml) {
                    $("#buildID").val($(xml).find("mess").text())  ;

                    $("#roomAdmin").val($(xml).find("mess1").text())  ;

                }
            });
        }

        function getPic() {
            var roomStyle = $.trim($("#roomRoomStyle").val());

            $.ajax({

                url: "AjaxGetPic.aspx",
                data: "roomStyle=" + roomStyle,
                dataType: "xml",
                type: "post",
                error: function (XMLHttpRequest, textStatus) { alert(XMLHttpRequest.status + textStatus); },
                success: function (xml) {
                    var id = $(xml).find("mess").text();                                        
                    $("#viewPic").val(id);
                   
                }
            });
       }

       function View() {
           var id = $("#viewPic").val();
              var url = "ImagePhoto.aspx?id=";
              url+=id;
              window.location.href = url;
       }

        function checkForm() {
            var b = $("#roomNum").val();
			var floor=$("#roomFloor").val();
			var area=$("#roomArea").val();
			var height=$("#roomHeight").val();
			var minLease=$("#roomMinLease").val();
			var rent=$("#roomRent").val();
			var fee=$("roomManFee").val();
			var taxes=$("roomTaxes").val();
			
           

            if ($.trim(b) == "") {
                alert("房间号不能为空，请输入房间号！");
                $("#roomNum").focus();
                return false;
            }

            if ($.trim(floor) != "") {
                if (!isNum(floor)) {
                    alert("楼层应为整数，请重新输入！");
                    $("#roomFLoor").val("");
                    $("#roomFLoor").focus();
                    return false;
                }
            }
			
			if ($.trim(area) != "") {
			    if (!isFloatNum(area)) {
			        alert("面积应为数字，请重新输入！");
			        $("#roomNum").val("");
			        $("#roomNum").focus();
			        return false;
			    }
            }
			
			if ($.trim(height) != "") {
			    if (!isFloatNum(height)) {
			        alert("层高应为数字，请重新输入！");
			        $("#roomHeight").val("");
			        $("#roomHeight").focus();
			        return false;
			    }
            }

            if ($.trim(minLease) != "") {
                if (!isNum(minLease)) {
                    alert("最短租期应为整数，请重新输入！");
                    $("#roomMinLease").val("");
                    $("#roomMinLease").focus();
                    return false;
                }
            }
			
//			if ($.trim(rent) != "") {
//				if(!isFloatNum(rent))
//				{
//                alert("租金应为数字，请重新输入！");
//                $("#roomRent").focus();
//                return false;
//				}
//            }
			
			if ($.trim(fee) != "") {
				if(isFloatNum(fee))
				{
                alert("管理费用应为数字，请重新输入！");
                $("#roomManFee").focus();
                return false;
				}
            }
//			if ($.trim(taxes) != "") {
//				if(isFloatNum(taxes))
//				{
//                alert("税费应为数字，请重新输入！");
//                $("#roomTaxes").focus();
//                return false;
//				}
//            }
			
            return true;

         
        }
        //$("#radio").attr('checked');
        function checkShow() {
         

            if ( $("#IsRent").attr('checked')) {
               /* $("#roomLessee1").css("display", "block");
                $("#roomRentStart1").css("display", "block");
                $("#roomRentEnd1").css("display", "block");
                */
                $("#roomRentEnd1,#roomLessee1,#roomRentStart1").show();
            }else if($("#NotRent").attr('checked'))
            {
		        /*
                $("#roomLessee1").css("display", "none");
                $("#roomRentStart1").css("display", "none");
                $("#roomRentEnd1").css("display", "none");
                */
                $("#roomLessee1,#roomRentStart1,#roomRentEnd1").hide();
            }
        }

        jQuery(document).ready(function ($) {
            $('a[rel=facebox]').facebox();
        })

        $(function () {
            $('#slider').anythingSlider();

          
        });


//            $(function () {
//            $(".viewBtn").click(function () {
//                var id= $("#viewPic").val();
//                var url = "ImagePhoto.aspx?id=";
//                url+=id;
//                window.location.href = url;
//            });
            
    

    </script>

     <style type="text/css">
    #slider { width: 700px; height: 390px; }
    </style>
    
</head>

<body>

    <div id="Div1"  runat="server" >
        
      
    <form name="editRoom" action="SaveRoomInfo.aspx" method="post" >

    <input type="hidden" name="buildID" id="buildID" value="" />

        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;房间信息添加&nbsp;&nbsp;
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
               <select name="roomBuild" id="roomBuild"  onchange="getAdmin()">
    				 <%for (int i = 0; i < buNameList.Count; i++)
                      {%>
                        <option><%= buNameList[i]%></option>
                    <%} %>
               </select>    
               </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>管理员
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomAdmin" type="text" size="26" name="roomAdmin" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp*</font>房间号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomNum" type="text" size="26" name="roomNum" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

          <%--  <tr >
               <td class="leftTitle" >
		             楼层
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomFloor" type="text" size="26" name="roomFloor" value="" />&nbsp;&nbsp;&nbsp;层
    		   </td>
            </tr>--%>
            <tr >
               <td class="leftTitle" >
		             朝向
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="roomToward" id="roomToward" >
                        <option>东</option>
                        <option>南</option>
                        <option>西</option>
                        <option>北</option>
                        <option>东南</option>
                        <option>西南</option>
                        <option>东北</option>
                        <option>西北</option>
                    </select>
    		   </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             装修情况
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select id="roomDecor"  name="roomDecor" >
                        <option>精装修</option>
                        <option>普通装修</option>
                        <option>毛坯</option>
                    </select>
    		   </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             房间面积
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomArea" type="text" size="26" name="roomArea" value="" />&nbsp;&nbsp;&nbsp;平方米
    		   </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             室内层高
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomHeight" type="text" size="26" name="roomHeight" value="" />&nbsp;&nbsp;&nbsp;米
    		   </td>
            </tr>
           
            <tr >
                <td class="leftTitle" >
		            房型图
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
                   <select name="roomRoomStyle" id="roomRoomStyle" onclick="getPic()">
                   <%for (int i = 0; i < rStyleNameList.Count; i++)
                     { %>
                        <option><%= rStyleNameList[i]%></option>
                   <%} %>
                   </select>
    		       <input type="button" class="viewBtn" id="view" name="view" onclick="View()" />
                   <input type="hidden" id="viewPic" name="viewPic" value="" />
    		    </td>
            </tr>
            
           <%--  <tr >
                <td class="leftTitle" >
		            房型图预览
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <img alt="" id="roomStyleView" width="250" height="200" name="roomStyleView" src="" />
    		    </td>
            </tr>
--%>
            <tr>
               <td class="leftTitle" >
		            产权类型
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
                    <input type="radio" name="roomStyle" value="false" />&nbsp; &nbsp;小业主
                    <input type="radio" name="roomStyle" value="true" checked="checked" />&nbsp; &nbsp;开发商
    		        
    		   </td>
            </tr>
            
            <tr >
                <td class="leftTitle" >
		            最短租期
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomMinLease" type="text" size="26" name="roomMinLease" value="" />&nbsp;&nbsp;&nbsp;月
    		    </td>
            </tr>

            <tr >
                <td class="leftTitle" >
		            支付方式
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomPayMode" type="text" size="26" name="roomPayMode" value="" />&nbsp;&nbsp;&nbsp;
    		    </td>
            </tr>

            <tr >
                <td class="leftTitle" >
		            租金
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomRent" type="text" size="26" name="roomRent" value="" />&nbsp;&nbsp;&nbsp;
    		    </td>
            </tr>
                      

            <tr >
                <td class="leftTitle" >
		            物业管理费
                </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <input class="inputText" id="roomManFee" type="text" size="26" name="roomManFee" value="" />&nbsp;&nbsp;&nbsp;元
    		    </td>
            </tr>

          

             <tr>
               <td class="leftTitle" >
		            出租情况
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input type="radio" name="roomIsRent" id="IsRent" value="true" onclick="checkShow()" />&nbsp; &nbsp;已出租
                    <input type="radio" name="roomIsRent" id="NotRent" value="false" checked="checked" onclick="checkShow()"/>&nbsp; &nbsp;未出租
    		   </td>
            </tr>
 
      

       
            <tr style="display:none" id="roomLessee1">
               <td class="leftTitle" >
		             租住公司
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="roomLessee" id="roomLessee">
                    <%for (int i = 0; i < lsNameList.Count; i++)
                      {%>
                        <option><%= lsNameList[i]%></option>
                    <%} %>
                    </select>
    		   </td>
            </tr>


            <tr style="display:none" id="roomRentStart1">
               <td class="leftTitle" >
		             入住时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomRentStart" type="text" size="26" name="roomRentStart" value="" />&nbsp;&nbsp;&nbsp;<img id="startCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>

            <tr style="display:none" id="roomRentEnd1" >
               <td class="leftTitle" >
		             截止时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="roomRentEnd" type="text" size="26" name="roomRentEnd" value="" />&nbsp;&nbsp;&nbsp;<img id="endCalImg"  class="datepicker" src="../../../Images/cal.gif" />
    		   </td>
            </tr>



             <tr >
               <td class="leftTitle" >
		             备注信息
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		      <textarea name="roomRemark" id="roomRemark"  rows="4" cols="80%"></textarea>
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             加入房源
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input type="radio" name="roomIsShowed" value="true" />&nbsp; &nbsp;是
                    <input type="radio" name="roomIsShowed" value="false"  checked="checked"/>&nbsp; &nbsp;否
    		   </td>
            </tr>
            
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn" />
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewRoom.aspx?pageno=1 '" value="" />										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
</body>
</html>
