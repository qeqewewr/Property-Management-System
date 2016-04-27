<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddComplainFeedback.aspx.cs" Inherits="Webmag_Employe_officework_answercomplain_AddComplainFeedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>

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
    .perview {width:100%;background:#fff;font-size:12px; border-collapse:collapse;}
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
    
    <script language="javascript" type="text/javascript">
        KindEditor.ready(function (K) {
            var editor1 = K.create('#complainContent', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=addComplainFeedback]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=addComplainFeedback]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });

        KindEditor.ready(function (K) {
            var editor1 = K.create('#feedbackDealContent', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=addComplainFeedback]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=addComplainFeedback]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });

        $(function () {
            $("#complainFeedbackLessee").change(function () {
                var lessee = $(this).val();
                $.get('../../../../SelectHandler.ashx?zuhu=' + escape(lessee), function (r) {
                    var b = r.toString().split(',');
                    var htmlBuilding = '<option value="' + "BuildingName" + '">' + "请选择" + "</option>";
                    var htmlRoom = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                    for (var i = 0; b[i]; i++) {
                        htmlBuilding += '<option value="' + b[i] + '">' + b[i] + "</option>";
                    }
                    $("#complainFeedbackBuildingName").html(htmlBuilding);
                    $("#complainFeedbackRoom").html(htmlRoom);
                });
            });
        });

        $(function () {
            $("#complainFeedbackBuildingName").change(function () {
                var build = $(this).val();
                $.get('../../../../SelectHandler.ashx?lou=' + escape(build), function (d) {

                    var rooms = d.toString().split(',');
                    var html = '<option value="' + "Room" + '">' + "请选择" + "</option>";
                    for (var i = 0; rooms[i]; i++) {
                        html += '<option value="' + rooms[i] + '">' + rooms[i] + "</option>";

                    }
                    $("#complainFeedbackRoom").html(html);
                });
            });
        });

     
        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var l = $("#complainFeedbackLessee").val();
            var b = $("#complainFeedbackBuildingName").val();
            var r = $("#complainFeedbackRoom").val();
            var d = $("#complainDirector").val();
            var dp = $("#complainDirectorPhone").val();
            var cdt = $("#complainDateTime").val();
            var pp = $("#feedbackPicture").val();
            var fdt = $("#feedbackDateTime").val();
            var theDate, flag;

            if ($.trim(l) == "Lessee") {
                alert("请选择租户！");
                $("#complainFeedbackLessee").focus();
                return false;
            }

            if ($.trim(b) == "BuildingName") {
                alert("请选择楼宇！");
                $("#complainFeedbackBuildingName").focus();
                return false;
            }

            if ($.trim(r) == "Room") {
                alert("请选择房间号！");
                $("#complainFeedbackRoom").focus();
                return false;
            }

            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(cdt);
            var flag = isdate(theDate);
            if (theDate == "" || !flag) {
                alert("投诉时间输入格式有错，请重新输入时间！");
                $("#complainDateTime").focus();
                return false;
            }

            if ($.trim(d) == "") {
                alert("联系人不能为空，请重新输入联系人！");
                $("#complainDirector").focus();
                return false;
            }

            if ($.trim(dp) != "") {
                if (!isMobilePhone(dp, "#complainFeedbackDirectorPhone") && !isTelephone(dp, "#complainFeedbackDirectorPhone")) {
                    $("#complainDirectorPhone").focus();
                    return false;
                }
            } else {
                alert("联系人电话不能为空，请重新输入联系人电话！");
                $("#complainDirectorPhone").focus();
                return false;
            }
            <%if(role=="property") 
             {%>
                theDate = $.trim(fdt);
                flag = isdate(theDate);
                if (theDate == "" || !flag) {
                    alert("您输入的反馈时间格式有错，请重新输入！");
                    $("#feedbackDateTime").focus();
                    return false;
                }
            <%} %>
            //使得控件数据可上传到服务器
            var frm = document.getElementById("addComplainFeedback");
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
  
    <form id= "addComplainFeedback" name="addComplainFeedback" action="SaveComplainFeedback.aspx" onsubmit="return checkForm()" method="post" enctype="multipart/form-data">
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;投诉反馈信息添加&nbsp;&nbsp;
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
    		       <%if(role=="property")
					{%>
					<select name="complainFeedbackLessee" id="complainFeedbackLessee" style="width: 135px"> 
				  	
                   <option value = "Lessee">请选择</option>                           
                        <%for (int i = 0; i < lesseeList.Count ; i++)
                          { %>
                        <option value="<%=lesseeList[i].Name %>"><%=lesseeList[i].Name%></option>
                        <%}%>					
                    </select>
				<%}
				else
				{%>
                    <select name="complainFeedbackLessee" id="complainFeedbackLessee"  style="width: 135px"> 
					<option value = "Lessee">请选择</option>  
                        <option value="<%=lessee.Name %>"><%=lessee.Name%></option>				
                    </select>
				<%}%>
    		   </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>楼宇
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="complainFeedbackBuildingName" id="complainFeedbackBuildingName" style="width: 85px">
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
    		       <select name="complainFeedbackRoom" id="complainFeedbackRoom" style="width: 80px">  
                   <option value = "Room">请选择</option>                      
                       
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>投诉时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="complainDateTime" type="text" size="26" name="complainDateTime" value="" />&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('complainDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer"/>
                   
               </td>
            </tr>    

             <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> <font color="red"> &nbsp;</font>投诉内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="complainContent" name="complainContent" cols="100" 
                         style="width:99.5%;height:221px; visibility:hidden;" runat="server">  
                     </textarea>
                </td>
            </tr>
           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="complainDirector" type="text" size="26" name="complainDirector" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="complainDirectorPhone" type="text" size="26" name="complainDirectorPhone" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

          
                    <%if (role == "property")
                      {%>
                        <tr>
                           <td class="leftTitle" <%if(role=="lessee"){%> disabled="true" <%}%>>
		                        <font color="red"> &nbsp;*</font>反馈时间
                           </td>
                           <td  align="left">&nbsp; &nbsp; &nbsp; 
    				            <input class="inputText" id="feedbackDateTime" type="text" size="26" name="feedbackDateTime" value="" <%if(role=="lessee"){%> disabled="true" <%}%>/>&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('feedbackDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer"<%if(role=="lessee"){%> disabled="true" <%}%>/>
                   
                           </td>
                        </tr>    
                   <%} %>
                    <tr  <%if(role=="lessee"){%>disabled="true"<%}%>>
                        <td class="leftTitle">反馈单链接</td>
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
                        <td class="leftTitle addNewsTableTd" <%if(role=="lessee"){%> disabled="true" <%}%>> <font color="red"> &nbsp;</font>反馈意见： </td>
                        <td class="addNewsTableTd" colspan="2">
                             <textarea id="feedbackDealContent" name="feedbackDealContent" cols="100" 
                                 style="width:99.5%;height:221px; visibility:hidden;" runat="server">  
                                <%if(role == "lessee")
                                  {%>
                                    <font color="red">待管理员回复</font>
                                <%} %>
                             </textarea>
                        </td>
                    </tr>
        
            <tr >
               <td class="leftTitle" <%if(role=="lessee"){%> disabled="true" <%}%>>
		             <font color="red"> &nbsp;*</font>满意度调查
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="complainFeedbackIsDeal" style="width: 65px" disabled="true">
                          <option value="未评" selected>未评</option>
                          <option value="满意">满意</option>
                          <option value="较满意">较满意</option>
                          <option value="尚可">尚可</option>
                          <option value="不满意">不满意</option>
                    </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color="red">(提醒:请您等管理员给你反馈意见之后,再进行评价)</font>
    		   </td>
            </tr>  

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewcomplainFeedback.aspx?pageno=1 '" value="">										
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