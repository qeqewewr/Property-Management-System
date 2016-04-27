<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBuilding.aspx.cs" Inherits="Webmag_Employe_infoManage_building_AddBuilding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../../Scripts/webmag.js"></script>
	<script type="text/javascript" language="javascript" src="../../../Scripts/util.js"></script>
	
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

    </style>

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
    
    <script language="javascript" type="text/javascript">

        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {

	    var area=$("#buildingArea").val();
	    var	floor=$("#buildingFloor").val();

            if ($.trim($("#buildingID").val()) == "") {
                alert("大楼编号不能为空！");
                $("#buildingID").focus();
                return false;
            }
            if ($.trim($("#buildingName").val()) == "") {
                alert("大楼名称不能为空！");
                $("#buildingName").focus();
                return false;
            }
	    
	    if ($.trim(area) != "") {
                if(!isFloatNum(area))
				{
		alert("面积应为数字，请重新输入！");
		$("#buildingArea").focus();
              
                return false;
            }
		}
			
	    
	   if ($.trim(floor) != "") {
                if(!isNum(floor)){
		alert("层数应为整数，请重新输入！");
		$("#buildingFloor").focus();
              
                return false;
            }
		}
            $("#idPicFile").empty();
            return true;
        }
	    
           


        function getEmploye() {
            var depart = $.trim($("#depart").val());
            var employe = $("#employe");

            for (var j = 0; j < employe[0].options.length; j++) {
                employe[0].options.remove(j);
            }

                $.ajax({

                    url: "AjaxgetEmploye.aspx",
                    data: "depart=" + depart,
                    dataType: "xml",
                    type: "post",
                    error: function (XMLHttpRequest, textStatus) { alert(XMLHttpRequest.status + textStatus); },
                    success: function (xml) {
                        var count = $(xml).find("mess").text();
                        for (var i = 0; i < count; i++) {
                            var id = $(xml).find("mess" + i + "").text();
                            i++;
                            var name = $(xml).find("mess" + i + "").text();

                            //                            employe[0].options.add(new Option(name, id));
                           employe[0].options.add(new Option(name, id));
                        }

                    }
                });
        }

        function getEmployeID() {
            var id = $("#employe").val();             
            $("#buildingAdmin").val(id);
            
        }
        
    </script>
    
</head>

<body>
    
  <div id="Div1" runat="server" >
        
      
    <form name="addBuilding" action="SaveBuildingInfo.aspx" id="example" onsubmit="return checkForm()" method="post" enctype="multipart/form-data">
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;大楼信息添加&nbsp;&nbsp;
			</caption>

			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
                 
			</tr>   
                 	        			   
             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>大楼编号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input  class="inputText" id="buildingID" type="text" size="26" name="buildingID" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
               
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>大楼名称
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="buildingName" type="text" size="26" name="buildingName" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr >
               <td class="leftTitle" rowspan="2">
		            管理员ID
               </td>
               <td  align="left" rowspan="2" >&nbsp;&nbsp;&nbsp;&nbsp;部门
                    <select name="depart" id="depart" onchange="getEmploye()">
                    <option>请选择部门</option>
                    <%for (int i = 0; i < departlist.Count; i++)
                      {%>
                        <option><%=departlist[i].Name%></option>
                    <%} %>
                    </select>
                    &nbsp;员工
                    <select name="employe" id="employe">
                        <option>请选择员工</option>
                    </select>
                    &nbsp;<input type="button" class="okBtn" name="choose" id="choose" onclick="getEmployeID()" />
                    <br />
    				&nbsp; &nbsp; &nbsp; 
                    <input class="inputText" id="buildingAdmin"  name="buildingAdmin" type="text" size="26" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
            <tr></tr>
            <tr>
               <td class="leftTitle">
		           &nbsp;&nbsp;位置
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="buildingPos" type="text" size="26" name="buildingPos" value="" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
     

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;面积
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="buildingArea" type="text" size="26" name="buildingArea" value="" />&nbsp;&nbsp;&nbsp;平方米
    		   </td>
            </tr>
            
            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;层数
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="buildingFloor" type="text" size="26" name="buildingFloor" value="" />&nbsp;&nbsp;&nbsp;层
    		   </td>
            </tr>

               <tr>
               <td class="leftTitle">
		           简介
               </td>
               <td  colspan="2">&nbsp; &nbsp; &nbsp; 
    				<textarea id="buildingIntro" name="buildingIntro" cols="100" rows="6" >
                    </textarea>
                   
               </td>
            </tr>

            <tr>
                    <td class="leftTitle">大楼图片</td>
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
    			<td class="buttonGroup" colspan="3">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn"/>
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewBuilding.aspx?pageno=1 '" value=""/>										
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