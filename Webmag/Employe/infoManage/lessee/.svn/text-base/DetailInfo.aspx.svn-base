<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailInfo.aspx.cs" Inherits="Webmag_Employe_infoManage_lessee_DetailInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>


    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
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
    
 <script>
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


           <script language="javascript" type="text/javascript">

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
 
 </script>
    
</head>

<body>
    
  <div id="Div1" runat="server" >
        
      
    <form name="ViewDepartment" >
       

        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>&nbsp;&nbsp;租户信息编辑&nbsp;&nbsp;</caption>
            <tbody>

			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>租户名(登录名)
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input  class="inputText" id="lesseeName" disabled="disabled" type="text" size="26" name="lesseeName" value="<%= lessee.Name %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

           <%-- <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;登录名
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeRoomNum" disabled="disabled" type="text" size="26" name="lesseeRoomNum" value="<%= lessee.RoomNum %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>--%>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;地址
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeAddress" disabled="disabled" type="text" size="26" name="lesseeAddress" value="<%= lessee.Address %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;经营范围
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeOS" disabled="disabled" type="text" size="26" name="lesseeOS" value="<%= lessee.OperationScope %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;办公电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeOPhone" disabled="disabled" type="text" size="26" name="lesseeOPhone" value="<%= lessee.OfficePhone %>" /> &nbsp;&nbsp;&nbsp;<font color="red" >格式为：区号-号码</font>
    		   </td>
            </tr>

             <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;负责人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeDirector" disabled="disabled" type="text" size="26" name="lesseeDirector" value="<%= lessee.Director %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;负责人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeDPhone" disabled="disabled" type="text" size="26" name="lesseeDPhone" value="<%= lessee.DirectorPhone %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;应急人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeEmergency" disabled="disabled" type="text" size="26" name="lesseeEmergency" value="<%= lessee.Emergency %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

            <tr >
               <td class="leftTitle" >
		             &nbsp;应急人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeEPhone" disabled="disabled" type="text" size="26" name="lesseeEPhone" value="<%= lessee.EmergencyPhone %>" />&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
          <%--   <tr >
               <td class="leftTitle" >
		             &nbsp;担保金
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="lesseeWarrant" disabled="disabled" type="text" size="26" name="lesseeWarrant" value="<%=lessee.WarrantMon %>" />&nbsp;&nbsp;&nbsp;元
    		   </td>
            </tr>--%>
     
            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;&nbsp;&nbsp;备注
               </td>
                   <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="5" cols="75%"id="lesseeRemark" disabled="disabled" name="lesseeRemark"><%= lessee.Remark %></textarea>
    		   </td>
            </tr>
    
             <tr class="addNewsTableTr">
                    <td class="leftTitle addNewsTableTd">附件</td>
                    <td colspan="3" class="addNewsTableTd">
                     <%--<input type="text" name="ImageLink"  id="ImageLink" value="<%=cleaner.ImageLink%>"/>--%>
                     <fieldset
							style="border: 1px solid #CDCDCD; padding: 8px; padding-bottom: 0px; margin: 8px 0">
							<div id="custom-queue">
                                <%for (int i = 0; i < attachList.Count; i++)
                                  { %>
                                <div class="uploadifyQueueItem completed"
										id="fileUpload<%= attachList[i].ID%>">
										<%--<div class="cancel">
											<a href="javascript:delUpload(<%=attachList[i].ID %>)"> <img alt=""
													border="0" src="../../../Images/cancel.png"/></a>
										</div>--%>
										<span class="fileName"><a href="<%= path+attachList[i].AttachUrl%>" class="attatchHref" ><%= attachList[i].AttachName%></a></span>
										<span class="percentage"> - Completed</span>
								</div>
                                <%} %> 
                            </div>
							<%--<div id="fileUpload">
								You have a problem with your javascript
							</div>
							<a href="javascript:$('#fileUpload').uploadifyUpload()">开始上传</a> 
							<p></p>--%>
						</fieldset>
                    </td> 
                </tr>
            
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewLessee.aspx?pageno=<%=pageno %>&keyword=<%=keyword %>&scope=<%=scope %> '" value=""/>										
    			</td>
    				
    		</tr>
          </tbody>
    		
        </table>    
            
     </form>
    </div>
    
    
</body>

</html>
