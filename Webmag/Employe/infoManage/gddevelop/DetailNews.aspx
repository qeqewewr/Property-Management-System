<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailNews.aspx.cs" Inherits="Webmag_Employe_infoManage_gddevelop_DetailNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>

    <link rel="stylesheet" href="../../../../kindeditor-v4.0.4/themes/default/default.css" />
	<link rel="stylesheet" href="../../../../kindeditor-v4.0.4/plugins/code/prettify.css" />
    <link rel="stylesheet" href="../../../CSS/uploadify.css" />
    <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/> 

	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>

    <script type="text/javascript" language="javascript" src="../../../Scripts/webmag.js"></script>
   
    <script type="text/javascript" language="javascript" src="../../../Scripts/swfobject.js"></script>
    <script type="text/javascript" language="javascript" src="../../../Scripts/jquery.uploadify.v2.1.4.js"></script>
    <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>

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

          function Close() {
              window.opener.location.reload();
              window.close();
          }

           jQuery(document).ready(function ($) {
             $('a[rel=facebox]').facebox();
         })
        
    </script>

</head>

<body>

    <div>
        <form name="ViewNews"  >

        <input type="hidden" name="newsID" id="newsID" value="<%= news.ID %>" />
        
        <table class="addNewsTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;动态详情查看窗口&nbsp;&nbsp;
			</caption>

			<tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd" width="150"> <font color="#cc0033">*</font>标 题： </td>
                <td class="addNewsTableTd">
                    <input id="newsTitle" class="inputText" disabled="disabled" type="text" size="90" name="newsTitle" value="<%=news.Title %>"/>
                    
                </td>
            </tr>

            	<tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd" width="150">  &nbsp;幻灯片显示： </td>
                <td class="addNewsTableTd">
                <%if (news.LunBo == "1")
                  {%>
                    <input id="lunbo" class="lunbo" type="checkbox"  name="lunbo" value="1" checked="checked"/>
                <%}
                  else
                  { %>
                    <input id="Checkbox1" class="lunbo" type="checkbox"  name="lunbo" value="1"/>
                <%} %>
                </td>
            </tr>   

           <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> 文章内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     
                        <%= news.Body %>
                    
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

                   <tr class="addNewsTableTr">
                    <td class="leftTitle addNewsTableTd"  >房型图预览</td>
                    <td class="addNewsTableTd" >
                    <%for (int i = 0; i < imageList.Count; i++)
                      { %>                   
                        <a rel="facebox" href="facebox.aspx?id=<%=imageList[i].ID %>"><img alt="" width="250" height="200" name="<%= imageList[i].AttachName %>" src="<%= imageList[i].AttachUrl %>" /></a>&nbsp;&nbsp;&nbsp;&nbsp;
                    <%  if((i+1)%4==0)
                        {%><br />
                      <%}
                      } %>
                      
                      
                    </td>
                </tr>

                
    		<tr class="addNewsTableTr">
                <td class="addNewsTableTd leftTitle">发布时间：</td>
                <td class="addNewsTableTd">
                    <input id="Text1" name="newsTime" disabled="disabled" type="text" size="50" value="<%= news.PublishTime %>" />
                </td>
            </tr>

            <tr class="addNewsTableTr">				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
					<input name="btnBack" type="button" class="backBtn" id="btnClose" onclick="window.location.href='ViewNews.aspx?pageno=<%= pageno %>&keyword=<%=keyword %> '" value=""/>										
    			</td>
    				
    		</tr>
        </table>  
            
         </form>
    
       </div>

</body>

</html>
