<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="Webmag_Employe_infoManage_gddevelop_AddNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

     <link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"  />

    <script type="text/javascript" language="javascript" src="../../../Scripts/webmag.js"></script>

    <script type="text/javascript" src="../../../Scripts/CJL.0.1.min.js"></script>
	<script type="text/javascript" src="../../../Scripts/ImagePreviewd.js"></script>
	<script type="text/javascript" src="../../../Scripts/QuickUpload.js"></script> 


 
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
        
        
      .perview {width:100%;background:#fff;font-size:12px; border-collapse:collapse;}
    .perview td, .perview th {padding:5px;border:1px solid #ccc;}
    .perview th {background-color:#f0f0f0; height:20px;}
    .perview a:link, .perview a:visited, .perview a:hover, .perview a:active {color:#00F;}
    .perview table{ width:100%;border-collapse:collapse;}
    /*file样式*/
    #idPicFile {
	    width:80px;height:20px;overflow:hidden;position:relative;
	    background:url(../../../Images/o_addfile.jpg) center no-repeat;
    }
    #idPicFile input {
	    font-size:20px;cursor:pointer;
	    position:absolute;right:0;bottom:0;
	    filter:alpha(opacity=0);opacity:0;
	    outline:none;hide-focus:expression(this.hideFocus=true);
    }

    </style>


    

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


         $(function () {

         });

         function checkForm() {
             var s = $("#newsTitle").val();
             if ($.trim(s) == "") {
                 alert("新闻标题不能为空，请输入新闻标题！");
                 $("#newsTitle").focus();
                 return false;
             }
             if ($("#lunbo").attr('checked') == true) {
                 if ($("#idPicList tr").length < 1) {
                     alert('首页幻灯片至少添加一张图片！');
                     return false;
                 } 


             }

             $("#idPicFile").empty();
      
             return true;
             
         }
        
    </script>


</head>


<body>
  <div id="Div1" runat="server" >
        <form id="editNews" name="editNews" action="SaveNewsInfo.aspx" onsubmit="return checkForm()" method="post" enctype="multipart/form-data" >
    
    
        <table class="addNewsTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;最新动态发布窗口&nbsp;&nbsp;
			</caption>

			<tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd" width="150"> <font color="#cc0033">*</font>标 题： </td>
                <td class="addNewsTableTd">
                    <input id="newsTitle" class="inputText" type="text" size="90" name="newsTitle"/>
                    
                </td>
            </tr>

        		<tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd" width="150">  &nbsp;幻灯片显示： </td>
                <td class="addNewsTableTd">
                    <input id="lunbo" type="checkbox"  name="lunbo" value="1"/>
                    
                </td>
            </tr>    

            <tr class="addNewsTableTr">
                <td class="addNewsTableTd"> 文章内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="newsBody" name="newsBody" cols="100" rows="8" style="width:99.5%;height:310px;visibility:hidden;" runat="server">
                        
                     </textarea>
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

                <tr class="addNewsTableTr">
                    <td class="leftTitle addNewsTableTd">图片链接</td>
                    <td colspan="3"  class="addNewsTableTd">
                        <%--<input type="text" name="ImageLink"  id="ImageLink" />--%>
                        <div>
                        <table class="perview">
	                        <tr>
		                        <th align="right"> 选择图片： </th>
		                        <td width="80%"> <div id="idPicFile"> </div> </td>
	                        </tr>
	                        <tr>
		                        <td colspan="2">
                                <table>
				                    <thead>
					                    <tr>
						                    <th> 文件路径 </th>
						                    <th width="30%"> 预览图 </th>
						                    <th width="20%"> 操作 </th>
					                    </tr>
				                    </thead>
				                    <tbody id="idPicList">
					                    <tr>
						                    <td></td>
						                    <td align="center" class="pic"></td>
						                    <td align="center"><a href="#">移除</a></td>
					                    </tr>

				                    </tbody>
                                
			                    </table>
                                </td>
	                        </tr>
                        </table>

                        </div>

                    </td> 
          
			    </tr>

    		<tr class="addNewsTableTr">				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn"/>
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewNews.aspx?pageno=1 '" value=""/>										
    			</td>
    				
    		</tr>
    		
         </table>     
            
    </form>
  </div>
    
</body>
</html>


 <script type="text/javascript">
     var table = $$("idPicList"), model = table.removeChild(table.rows[0]);
     var fileIndex = 1;
     function AddPreview() {
         var file = document.createElement("input"),
		img = document.createElement("img"),
		ip = new ImagePreview(file, img, {
		    maxWidth: 150,
		    maxHeight: 100,
		    action: "../../../ImagePreview.ashx",
		    onErr: function () { alert("载入预览出错！"); ResetFile(file); },
		    onCheck: CheckPreview,
		    onShow: ShowPreview
		});
         file.type = "file";
         file.name = 'pic' + fileIndex;

         fileIndex++;
         file.onchange = function () { ip.preview(); };
         $$("idPicFile").appendChild(file);
     }

     //检测程序
     var exts = "jpg|gif|bmp", paths = "|";
     function CheckPreview() {
         var value = this.file.value, check = true;
         if (!value) {
             check = false; alert("请先选择文件！");
         } else if (!RegExp("\.(?:" + exts + ")$$", "i").test(value)) {
             check = false; alert("只能上传以下类型：" + exts);
         } else if (paths.indexOf("|" + value + "|") >= 0) {
             check = false; alert("已经有相同文件！");
         }
         check || ResetFile(this.file);
         return check;
     }

     //显示预览
     function ShowPreview() {
         var row = table.appendChild(model.cloneNode(true)),
		file = this.file, value = file.value, oThis = this;

         row.appendChild(file).style.display = "none";
         row.cells[0].innerHTML = value;
         row.cells[1].appendChild(this.img);

         row.getElementsByTagName("a")[0].onclick = function () {
             oThis.dispose(); table.removeChild(row);
             paths = paths.replace(value, ""); return false;
         };

         paths += value + "|";
         AddPreview();
     }

     AddPreview();


     function ResetFile(file) {
         file.value = ""; //ff chrome safari
         if (file.value) {
             if ($$B.ie) {//ie
                 with (file.parentNode.insertBefore(document.createElement('form'), file)) {
                     appendChild(file); reset(); removeNode(false);
                 }
             } else {//opera
                 file.type = "text"; file.type = "file";
             }
         }
     }


    </script>  