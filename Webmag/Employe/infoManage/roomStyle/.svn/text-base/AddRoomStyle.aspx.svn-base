<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRoomStyle.aspx.cs" Inherits="Webmag_Employe_infoManage_roomStyle_AddRoomStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"  />

    <script type="text/javascript" language="javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../../Scripts/webmag.js"></script>

    <script type="text/javascript" src="../../../Scripts/CJL.0.1.min.js"></script>
	<script type="text/javascript" src="../../../Scripts/ImagePreviewd.js"></script>
	<script type="text/javascript" src="../../../Scripts/QuickUpload.js"></script> 


    <style type="text/css">
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

    <script type="text/javascript">
        function checkForm() {
            if ($.trim($("#roomStyleName").val()) == "") {
                alert("房型图名称不能为空！");
                $("#roomStyleName").focus();
                return false;
            }
            $("#idPicFile").empty();
            return true;
        }
    </script>


</head>

<body>
   

    <div>
        <form action="SaveRoomStyleInfo.aspx" method="post" id="example" onsubmit="return checkForm();" enctype="multipart/form-data">
            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					房型图信息添加
				</caption>
                <tr>
                    <td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                    <td></td>
                </tr>
                <tr>
                    <td class="leftTitle" width="150"><font color="#cc0033">*</font>房型图名称</td>
                    <td><input type="text" name="roomStyleName"  id="roomStyleName" /></td>
                </tr> 
                
             
                <tr>
                    <td class="leftTitle"><font color="#CC0033">*</font>图片链接</td>
                    <td colspan="3">
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
						                    <td align="center"></td>
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
				

                <tr>
				    <td colspan="4" class="buttonGroup">
					    <input type="submit" value=""   class="saveBtn"/>
					    <input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewRoomStyle.aspx?pageno=1 '" value=""/>	
					
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