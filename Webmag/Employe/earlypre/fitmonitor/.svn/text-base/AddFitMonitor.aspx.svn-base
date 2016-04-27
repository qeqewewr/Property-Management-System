<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddFitMonitor.aspx.cs" Inherits="Webmag_Employe_earlypre_fitmonitor_AddFitMonitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/>
	<script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>

    <link rel="stylesheet" href="../../../../kindeditor-v4.0.4/themes/default/default.css" />
	<link rel="stylesheet" href="../../../../kindeditor-v4.0.4/plugins/code/prettify.css" />
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>
   
    <script type="text/javascript" src="../../../Scripts/CJL.0.1.min.js"></script>
	<script type="text/javascript" src="../../../Scripts/ImagePreviewd.js"></script>
	<script type="text/javascript" src="../../../Scripts/QuickUpload.js"></script> 
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal/datetimepicker.js"></script>
    <style type="text/css">
        .perview {width:100%;background:#fff;font-size:12px; border-collapse:collapse;
            height: 105px;
        }
    .perview td, .perview th {padding:5px;border:1px solid #ccc;}
    .perview th {background-color:#f0f0f0; height:20px;}
    .perview a:link, .perview a:visited, .perview a:hover, .perview a:active {color:#00F;}
    .perview table{ width:100%;border-collapse:collapse;}
    /*file样式*/
    #idPicFile {
	    width:80px;height:20px;overflow:hidden;position:relative;
	    background:url(../../../Images/o_addfile.jpg) center no-repeat;
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

    <style type="text/css">
        .button {
	BORDER-BOTTOM: #636467 1px solid; BORDER-LEFT: #636467 1px solid; PADDING-BOTTOM: 1px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT: 12px/17px "songti"; BACKGROUND: url(images/btn_bg.gif) repeat-x 0px -1px; COLOR: #000; BORDER-TOP: #636467 1px solid; BORDER-RIGHT: #636467 1px solid; PADDING-TOP: 1px
}
    .contentCenter {
	TEXT-ALIGN: left; MARGIN: 0px auto; WIDTH: 800px ; border:1px solid #cccccc;padding-top:20px;
}

        </style>

     <script type="text/javascript">

         $(function () {
             $("#fitMonitorLessee").change(function () {
                 var lessee = $(this).val();
                 $.get('../../../../SelectHandler.ashx?zuhu=' + escape(lessee), function (r) {
                     var b = r.toString().split(',');
                     var htmlBuilding = '<option value="' + "BuildingName" + '">' + "请选择" + "</option>";
                     var htmlRoom = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                     for (var i = 0; b[i]; i++) {
                        htmlBuilding += '<option value="' + b[i] + '">' + b[i] + "</option>";
                     }
                    $("#fitMonitorBuildingName").html(htmlBuilding);
                    $("#fitMonitorRoom").html(htmlRoom);
                 });
             });
         });

         $(function () {
             $("#fitMonitorBuildingName").change(function () {
                 var build = $(this).val();
                 $.get('../../../../SelectHandler.ashx?lou=' + escape(build), function (d) {
                     var rooms = d.toString().split(',');
                     var html = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                     for (var i = 0; rooms[i]; i++) {
                         html += '<option value="' + rooms[i] + '">' + rooms[i] + "</option>";

                     }
                     $("#fitMonitorRoom").html(html);
                 });
             });
         });
</script>
    <script language="javascript" type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#detailBody', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=editorderRemove]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=editorderRemove]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });

      
        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var l = $("#fitMonitorLessee").val();
            var b = $("#fitMonitorBuildingName").val();
            var r = $("#fitMonitorRoom").val();
            var c = $("#fitMonitorCheckTime").val();
            var d = $("#fitMonitorDetail").val();
            var f = $("#fitMonitorApplyTime").val();

            if ($.trim(l) == "Lessee") {
                alert("请选择租户！");
                $("#fitMonitorLessee").focus();
                return false;
            }

            if ($.trim(b) == "BuildingName") {
                alert("请选择楼宇！");
                $("#fitMonitorBuildingName").focus();
                return false;
            }

            if ($.trim(r) == "Room") {
                alert("请选择房间号！");
                $("#fitMonitorRoom").focus();
                return false;
            }
          
            var theDate = $.trim(f);
            var flag = isdate(theDate);
           //验证日期格式是否为yyyy/mm/dd
           if (!flag || theDate == "") {
                alert("申请装修时间输入格式有错，请重新输入申请装修时间！");
                $("#fitMonitorApplyTime").focus();
                return false;
            }

            <% if(role == "property") {%>
            theDate = $.trim(c);
            flag = isdate(theDate);
            //验证日期格式是否为yyyy/mm/dd
            if (!flag || theDate == "") {
                alert("检查时间输入格式有错，请重新输入检查时间！");
                $("#fitMonitorCheckTime").focus();
                return false;
            }
            <%}%> 
          
         
            return true;
            
        }
       
       
    </script>

</head>

<body>
  <div>
  
    <form id= "editFitMonitor" name="editFitMonitor" action="SaveFitMonitorInfo.aspx" onsubmit="return checkForm();" method="post" enctype="multipart/form-data">
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp; 
                  装修<%if (role == "property")
                      {%>检查<%}
                      else
                      {%>申请<%}%>信息添加&nbsp;&nbsp;
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
    		        <select name="fitMonitorLessee" id = "fitMonitorLessee" style="width: 185px">
                    <option value = "Lessee">请选择</option>  
                          <%if (role == "property")
                           {%>               
                                <%for (int i = 0; i < lesseeList.Count; i++)
                                  { %>
                                <option value="<%=lesseeList[i].Name %>"><%=lesseeList[i].Name%></option>
                                <%} %>
                          <%}
                            else
                            {%>
                                 <option value="<%=Session["UserName"].ToString() %>"><%=Session["UserName"].ToString()%></option>
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
    		       <select name="fitMonitorBuildingName" id ="fitMonitorBuildingName"  
                        style="width: 105px">
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
    		       <select name="fitMonitorRoom" id = "fitMonitorRoom" style="width: 105px">                        
                      <option value = "Room">请选择</option>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>申请装修日期
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="fitMonitorApplyTime" type="text" size="26" name="fitMonitorApplyTime" value="" />&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('fitMonitorApplyTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer"/>
                    &nbsp; &nbsp; &nbsp;<font color="red"> (时间格式:如2011/11/11 11:11:11)</font>
               </td>
            </tr> 
            <%if(role=="property"){%>
                <tr>
                   <td class="leftTitle">
		                <font color="red"> &nbsp;*</font>检查日期
                   </td>
                   <td  align="left">&nbsp; &nbsp; &nbsp; 
    				    <input class="inputText" id="fitMonitorCheckTime" type="text" size="26" name="fitMonitorCheckTime" value=""/>&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('fitMonitorCheckTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer" />
                         &nbsp; &nbsp; &nbsp; <font color="red">(时间格式:如2011/11/11 11:11:11)</font>
                   </td>
                </tr>    
                <!--
                 <tr>
                   <td class="leftTitle">
		                <font color="red"> &nbsp;*</font>具体情况
                   </td>
                   <td  align="left">&nbsp; &nbsp; &nbsp; 
    				    <input class="inputText" id="fitMonitorDetail" type="text" size="26" name="fitMonitorDetail" value="" />&nbsp;&nbsp;&nbsp;
                   
                   </td>
                </tr>    
                -->

                <tr class="addNewsTableTr">
                    <td class="leftTitle addNewsTableTd"> <font color="red"> &nbsp;</font>具体情况： </td>
                    <td class="addNewsTableTd" colspan="2">
                         <textarea id="detailBody" name="detailBody" cols="100" 
                             style="width:99.5%;height:221px; visibility:hidden;" runat="server">  
                         </textarea>
                    </td>
                </tr>
                <tr >
                   <td class="leftTitle" >
		                <font color="red"> &nbsp;</font>检查人员
                   </td>
                    <td  align="left">&nbsp; &nbsp; &nbsp; 
                    <input class="inputText" id="fitMonitorEmployeID" type="text" size="26" name="fitMonitorEmployeID" value="" />
                        &nbsp;&nbsp;&nbsp;
    		       </td>
                </tr> 

           
             
                    <tr>
                    
                        <td class="leftTitle"><font color="#CC0033">*</font>装修检查图片链接</td>
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

                <tr >
                   <td class="leftTitle" >
		                 <font color="red"> &nbsp;*</font>装修情况
                   </td>
                   <td  align="left">&nbsp; &nbsp;  
    		            &nbsp;&nbsp;<select name="fitMonitorIsPassed" style="width: 80px">
                              <option value="否">在装修</option>
                              <option value="是">已完成</option>
                        </select>&nbsp;
    		       </td>
                </tr> 
            <%}%>    
    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewFitMonitor.aspx?pageno=1 '" value="">										
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
