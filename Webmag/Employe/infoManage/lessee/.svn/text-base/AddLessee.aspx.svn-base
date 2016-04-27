<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddLessee.aspx.cs" Inherits="Webmag_Employe_infoManage_lessee_AddLessee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>

    <link rel="stylesheet" href="../../../../kindeditor-v4.0.4/themes/default/default.css" />
	<link rel="stylesheet" href="../../../../kindeditor-v4.0.4/plugins/code/prettify.css" />
    <link rel="stylesheet" href="../../../CSS/uploadify.css" />

    <script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>

    <script type="text/javascript" language="javascript" src="../../../Scripts/webmag.js"></script>
   
    <script type="text/javascript" language="javascript" src="../../../Scripts/swfobject.js"></script>
    <script type="text/javascript" language="javascript" src="../../../Scripts/jquery.uploadify.v2.1.4.js"></script>


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
            var n = $("#lesseeName").val();
            var o = $("#lesseeOPhone").val();
            var d = $("#lesseeDPhone").val();
            var e = $("#lesseeEPhone").val();
            var w = $("#lesseeWarrant").val();
			

            if ($.trim(n) == "") {
                alert("租户名称不能为空，请输租户名称！");
                $("#lesseeName").focus();
                return false;
            }

//            if ($.trim(o) != "") {
//                if (!(isTelephone(o, "#lesseeOPhone"))) {
//					alert("办公电话格式输入错误，请重新输入！");
//                    $("#lesseeOPhone").focus();
//                    return false;

//                }
//            }



            if ($.trim(d) != "") {
                if (!(isMobilePhone(d, "#lesseeDPhone"))) {
					alert("负责人电话格式输入错误，请重新输入！");
                    $("#lesseeDPhone").focus();
                    return false;
                }
            }

            if ($.trim(e) != "") {
                if (!(isMobilePhone(e, "#lesseeEPhone"))) {
					alert("应急人电话格式输入错误，请重新输入！");
                    $("#lesseeEPhone").focus();
                    return false;
                }
            }
			
//			 if ($.trim(w) != "") {
//                if (!isFloatNum(w)) {
//					alert("担保金应为数字，请重新输入！");
//					$("#lesseeWarrant").focus();
//                    return false;
//                }
//            }

            return true;

        }


        $(function () {
            $('#fileUpload').uploadify({
                'uploader': '../../../Images/uploadify.swf',
                'script': '../../../uploadFileHandler.ashx',
                // 'script': 'SaveTravel.aspx.cs',
                'cancelImg': '../../../Images/cancel.png',
                'folder': '../../../attachment',
                'multi': true,
                'queueID': 'custom-queue',
                'removeCompleted': false,
                'onComplete': function (event, queueID, fileObj, serverData, data) {
                    var spans = "";
                    var str = fileObj.name + "#" + serverData;
                    spans += "<input type='hidden' name='ufile' value='" + str + "'>";
                    $("#fileUpload" + queueID).append(spans);
                    thisPage = false;
                },
                'sizeLimit': 10737418240,
                'onCancel': function (event, ID, fileObj, data) {
                    var id = ID;
                    if (fileObj == null) {
                        if (confirm("确定要删除该附件吗?")) {
                            $("input[name='ufile']").each(function () {
                                var s = $(this).val();
                                var seperator = s.indexOf("#");
                                var url = s.substring(seperator + 1);
                                var pid = $(this).parent().attr('id');
                                if (pid == "fileUpload" + id) {
                                    $.ajax({
                                        type: "post",
                                        url: "../../../deleteFileHandler.ashx",
                                        data: "op=delete&url=" + url,
                                        error: function (XMLHttpRequest) { alert(XMLHttpRequest.status); },
                                        success: function (data) {
                                            var fadeSpeed = 250;
                                            jQuery("#fileUpload" + ID).fadeOut(fadeSpeed, function () { jQuery("#fileUpload" + ID).remove() });
                                        }
                                    });
                                    return false;
                                }
                            });
                        }
                    }
                }
            });

        });


        KindEditor.ready(function (K) {
            var editor1 = K.create('#newsBody', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=editNews]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=editNews]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
        





        
</script>
    
</head>

<body>
    
  <div id="Div1" runat="server" >
        
      
    <form name="editDepartment" action="SaveLesseeInfo.aspx" onsubmit="return checkForm()" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;租户信息添加&nbsp;&nbsp;
			</caption>

			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>租户名(登录名)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="lesseeName" type="text" size="26" name="lesseeName" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

           <%-- <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;登录名
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeRoomNum" type="text" size="26" name="lesseeRoomNum" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>--%>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp; 地址
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeAddress" type="text" size="26" name="lesseeAddress" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;经营范围
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeOS" type="text" size="26" name="lesseeOS" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;办公电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeOPhone" type="text" size="26" name="lesseeOPhone" value="" /> &nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;负责人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeDirector" type="text" size="26" name="lesseeDirector" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;负责人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeDPhone" type="text" size="26" name="lesseeDPhone" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;应急人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeEmergency" type="text" size="26" name="lesseeEmergency" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;应急人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeEPhone" type="text" size="26" name="lesseeEPhone" value="" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

        <%--    <tr >
               <td class="leftTitle" >
		             &nbsp;担保金
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeWarrant" type="text" size="26" name="lesseeWarrant" value="" />&nbsp;&nbsp;&nbsp;元
    		   </td>
            </tr>--%>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;&nbsp;备注
               </td>
               <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="5" cols="75%"id="lesseeRemark" name="lesseeRemark"></textarea>
    		   </td>
            </tr>

              <tr class="addNewsTableTr">
                    <td class="leftTitle addNewsTableTd">附件</td>
                    <td colspan="3" class="addNewsTableTd">
						<fieldset
							style="border: 1px solid #CDCDCD; padding: 8px; padding-bottom: 0px; margin: 8px 0">
							<div id="custom-queue">

                            </div>
							<div id="fileUpload">
								You have a problem with your javascript
							</div>
							<a href="javascript:$('#fileUpload').uploadifyUpload()">开始上传</a>
							<p></p>
						</fieldset>
                     <%--<input type="text" name="ImageLink"  id="ImageLink" />--%>

                    </td> 
                </tr>
    
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewLessee.aspx?pageno=1 '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>
</html>
