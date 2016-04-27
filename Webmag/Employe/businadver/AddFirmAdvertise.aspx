﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFirmAdvertise.aspx.cs" Inherits="Webmag_Employe_businadver_AddFirmAdvertise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">
    <title></title>
    <meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	 
	<link rel="stylesheet" type="text/css" href="../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../Scripts/webmag.js"></script>

     <link rel="stylesheet" href="../../../kindeditor-v4.0.4/themes/default/default.css" />
	<link rel="stylesheet" href="../../../kindeditor-v4.0.4/plugins/code/prettify.css" />
	<script type="text/javascript" charset="utf-8" src="../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>
    
    <script type="text/javascript" src="../../Scripts/CJL.0.1.min.js"></script>
	<script type="text/javascript" src="../../Scripts/ImagePreviewd.js"></script>
	<script type="text/javascript" src="../../Scripts/QuickUpload.js"></script> 

    <style type="text/css">
    .perview {width:100%;background:#fff;font-size:12px; border-collapse:collapse;}
    .perview td, .perview th {padding:5px;border:1px solid #ccc;}
    .perview th {background-color:#f0f0f0; height:20px;}
    .perview a:link, .perview a:visited, .perview a:hover, .perview a:active {color:#00F;}
    .perview table{ width:100%;border-collapse:collapse;}
    /*file样式*/
    #idPicFile {
	    width:80px;height:20px;overflow:hidden;position:relative;
	    background:url(../../Images/o_addfile.jpg) center no-repeat;
            top: 0px;
            left: 0px;
        }
    #idPicFile input {
	    font-size:20px;cursor:pointer;
	    position:absolute;right:0;bottom:0;
	    filter:alpha(opacity=0);opacity:0;
	    outline:none;hide-focus:expression(this.hideFocus=true);
    }
    </style>

    <script language="javascript" type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#detailBody', {
                cssPath: '../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../upload_json.ashx',
                fileManagerJson: '../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=addFirmAdvertise]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=addFirmAdvertise]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
        </script>

        <script type="text/javascript">
            function checkForm() {
                $("#idPicFile").empty();

                var frm = document.getElementById("addFirmAdvertise");
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
  
    <form id= "addFirmAdvertise" name="addFirmAdvertise" action="SaveFirmAdvertise.aspx" onsubmit="return checkForm()" method="post" enctype="multipart/form-data">
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;企业宣传信息添加&nbsp;&nbsp;
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
    		       <select name="firmAdvertiseLessee" style="width: 179px">
                   <%if (role == "property")
                     {%>                        
                        <%for (int i = 0; i < lesseeList.Count; i++)
                          { %>
                        <option value="<%=lesseeList[i].Name %>"><%=lesseeList[i].Name%></option>
                        <%} %>
                    <% }
                     else {%>
                     <option value = "<%=lessee.Name %>"><%=lessee.Name %></option>
                    <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            
             
                <tr>
                    <td class="leftTitle"><font color="#CC0033">*</font>图片链接</td>
                    <td colspan="3">
                       
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

             <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> <font color="red"> &nbsp;</font>描述： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="detailBody" name="detailBody" cols="100" 
                         style="width:99.5%;height:221px; visibility:hidden;" runat="server">  
                     </textarea>
                </td>
            </tr>
            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>是否确认<%if(role == "lessee"){%>(待管理员确认)<%} %>
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="firmAdvertiseIsSure" style="width: 44px" disabled="true">
                         <option value="否" selected>否</option>
                         <option value="是">是</option>
                         
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            
             <tr >
               <td class="leftTitle" >
		              &nbsp;&nbsp;建议
               </td>
              <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="6" cols="75%" id="firmAdvertiseRemarks" name="firmAdvertiseRemarks"></textarea>
    		   </td>
            </tr>
              
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewFirmAdvertise.aspx?pageno=1 '" value="">										
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
		    action: "../../ImagePreview.ashx",
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