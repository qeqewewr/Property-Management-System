<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateRepairTable.aspx.cs" Inherits="Webmag_Employe_officework_repairtable_UpdateRepairTable" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
  <%--  <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>--%>
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.1.js"></script>
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
    }
    #idPicFile input {
	    font-size:20px;cursor:pointer;
	    position:absolute;right:0;bottom:0;
	    filter:alpha(opacity=0);opacity:0;
	    outline:none;hide-focus:expression(this.hideFocus=true);
    }
    </style>

    <script type="text/javascript" charset="utf-8"src="../../../scripts/jquery.uploadify.v2.1.4.js"></script>

    <style type="text/css">
        .button {
	BORDER-BOTTOM: #636467 1px solid; BORDER-LEFT: #636467 1px solid; PADDING-BOTTOM: 1px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT: 12px/17px "songti"; BACKGROUND: url(images/btn_bg.gif) repeat-x 0px -1px; COLOR: #000; BORDER-TOP: #636467 1px solid; BORDER-RIGHT: #636467 1px solid; PADDING-TOP: 1px
}
    .contentCenter {
	TEXT-ALIGN: left; MARGIN: 0px auto; WIDTH: 800px ; border:1px solid #cccccc;padding-top:20px;
}

        </style>
    
    <script language="javascript" type="text/javascript">
      <%if(role=="lessee") {%>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#repairTableContent', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=editRepairTable]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=editRepairTable]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });
        <%}%>

        $(function () {
            $(".DeleteImage").click(function () {
                var url = $(this).attr('href');
                var a = confirm("是否删除该图片？");
                if (a) {
                    window.location.href = url;
                }
                else {
                    return false;
                }
            });
        });

        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
            var c = $("#repairTableContent").val();
            var d = $("#repairTableDirector").val();
            var dp = $("#repairTableDirectorPhone").val();
            var dt = $("#repairTableDateTime").val();
            var pp = $("#repairTablePicturePath").val();
            var f = $("#repairTableFee").val();

            if ($.trim(d) == "") {
                alert("联系人不能为空，请重新输入联系人！");
                $("#repairTableDirector").focus();
                return false;
            }

            if ($.trim(dp) != "") {
                if (!isMobilePhone(dp, "#repairTableDirectorPhone") && !isTelephone(dp, "#repairTableDirectorPhone")) {
                    $("#repairTableDirectorPhone").focus();
                    return false;
                }
            } else {
                alert("联系人电话不能为空，请重新输入联系人电话！");
                $("#repairTableDirectorPhone").focus();
                return false;
            }

//            //验证日期格式是否为yyyy/mm/dd
//            var theDate = $.trim(dt);
//            var flag = isdate(theDate);
//            if (theDate == "" || !flag) {
//                alert("报修时间输入格式有错，请重新输入时间！");
//                $("#repairTableDateTime").focus();
//                return false;
//            }

            //判断字符串是否是数字串
            if ($.trim(f) == "" || isNaN($.trim(f))) {
                alert("维修费用必须是数字串,请重新输入!");
                $("#repairTableFee").focus();
                return false;
            }

            var frm = document.getElementById("editRepairTable");
            var nCount = frm.length;
            for (var i = 0; i < nCount; i++)
                frm[i].disabled = false;

                return true;
        }
        
    </script>
</head>

<body>
  <div id="Div1" runat="server" >
  
    <form id= "editRepairTable" name="editRepairTable" action="DoUpdate.aspx?oldid=<%= id %>&pageno=<%= pageno %>&keyword=<%= keyword %>&endtime=<%= endtime %>" onsubmit="return checkForm()" method="post" enctype="multipart/form-data">
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;维修表单信息编辑&nbsp;&nbsp;
			</caption>
           
			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>租户
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableLessee" type="text" size="26" name="repairTableLessee"  value="<%= repairTable.Lessee %>" disabled="true"/>&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>楼宇
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableBuildingName" type="text" size="26" name="repairTableBuildingName"  value="<%= repairTable.BuildingName %>" disabled="true"/>&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>房间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableRoom" type="text" size="26" name="repairTableRoom"  value="<%= repairTable.Room %>" disabled="true"/>&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
             <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> <font color="red"> &nbsp;</font>报修内容： </td>
                <%if (role == "lessee")
                  {%>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="repairTableContent" name="repairTableContent" cols="100" 
                         style="width:99.5%;height:221px; visibility:hidden;">
                         <%= repairTable.RepairContent%>  
                     </textarea>
                </td>
                <%}
                  else
                  {%>
                  <td class="addNewsTableTd" colspan="2">&nbsp; &nbsp; &nbsp;
                  <!--
                      <textarea  name="repairTableContent" cols="100" 
                             style="width:99.5%;height:200px; " disabled="true">    
                      </textarea>
                      -->
                       <%= repairTable.RepairContent%>  
                  </td>
                <%} %>
           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableDirector" type="text" size="26" name="repairTableDirector" value="<%= repairTable.Director %>" <%if(role == "property") {%>disabled="true"<%} %>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

          <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>联系人电话
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableDirectorPhone" type="text" size="26" name="repairTableDirectorPhone" value="<%= repairTable.DirectorPhone %>" <%if(role == "property") {%>disabled="true"<%} %>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>报修日期和时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableDateTime" type="text" size="26" name="repairTableDateTime" value="<%= repairTable.DateTime %>" <%if(role == "property") {%>disabled="true"<%} %>/>&nbsp;&nbsp;&nbsp;<img src="../../../Scripts/cal/images2/cal.gif" onclick="javascript:NewCssCal('repairTableDateTime','yyyyMMdd','dropdown',true,24,true)" style="cursor:pointer" <%if(role == "property") {%>disabled="true"<%} %>/>
                   
               </td>
            </tr>    
              
             
             <tr>
                    <td class="leftTitle" width="150">维修单预览</td>
                    <td>
                    
                    <%for (int i = 0; i < imageList.Count; i++)
                      { %>                   
                        <img alt="" width="250" height="200" name="<%= imageList[i].AttachName %>" src="<%= imageList[i].AttachUrl %>" />&nbsp;&nbsp;
                        &nbsp;&nbsp;
                        <img alt="" src="../../../Images/cancel.png" class="DeleteImage" href="DeleteImage.aspx?id=<%=id%>&imageID=<%=imageList[i].ID %>&pageno=<%=pageno %>"<%if(role == "lessee") {%>disabled="true"<%} %>/> 
                             <%  if ((i + 1) % 4 == 0)
                                {%><br />
                                 <%}
                      } %>
                    </td>
                </tr>
            <%if(role == "property") 
             {%>
                <tr >
                    <td class="leftTitle"><font color="#CC0033">*</font>维修单图</td>
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
           <%} %>
            
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>维修费用(单位:元) 
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="repairTableFee" type="text" size="26" name="repairTableFee" value="<%= repairTable.Fee %>" <%if(role == "lessee") {%>disabled="true"<%} %>/>&nbsp;&nbsp;&nbsp;
                   
               </td>
          </tr>    

            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>装修满意度
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="repairTableIsFinish" style="width: 64px" <%if(role == "property") {%>disabled="true"<%} %>>
                    <%if (repairTable.IsFinish == 0)
                      {%>
                           <option value="未评">未评</option>
                          <option value="满意" selected>满意</option>
                          <option value="较满意">较满意</option>
                          <option value="尚可">尚可</option>
                          <option value="不满意">不满意</option>
                    <%}
                      else if (repairTable.IsFinish == 1)
                      { %>
                          <option value="未评">未评</option>
                           <option value="满意">满意</option>
                          <option value="较满意" selected>较满意</option>
                          <option value="尚可">尚可</option>
                          <option value="不满意">不满意</option>
                    <%}
                      else if (repairTable.IsFinish == 2)
                      {
                          %>
                           <option value="未评">未评</option>
                          <option value="满意">满意</option>
                          <option value="较满意">较满意</option>
                          <option value="尚可" selected>尚可</option>
                          <option value="不满意">不满意</option>
                     <%}
                      else if (repairTable.IsFinish == 3)
                      {
                      %>
                          <option value="未评">未评</option>
                          <option value="满意">满意</option>
                          <option value="较满意">较满意</option>
                          <option value="尚可">尚可</option>
                          <option value="不满意" selected>不满意</option>
                      <%}
                      else
                      {%>
                          <option value="未评" selected>未评</option>
                          <option value="满意">满意</option>
                          <option value="较满意">较满意</option>
                          <option value="尚可">尚可</option>
                          <option value="不满意">不满意</option>
                      <%} %>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>  

             <tr >
               <td class="leftTitle" >
		              &nbsp;&nbsp;备注
               </td>
              <td  colspan="2">&nbsp; &nbsp; &nbsp; 
                    <textarea rows="6" cols="75%" id="repairTableRemarks" name="repairTableRemarks" <%if(role == "lessee") {%>disabled="true"<%} %>><%=repairTable.Remarks%></textarea>
    		   </td>
            </tr>

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewRepairTable.aspx?pageno=1 '" value="">										
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
