<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewIntroduce.aspx.cs" Inherits="Webmag_Employe_infoManage_introduce_ViewIntroduce" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>

    <link rel="stylesheet" href="../../../../kindeditor-v4.0.4/themes/default/default.css" />
	<link rel="stylesheet" href="../../../../kindeditor-v4.0.4/plugins/code/prettify.css" />
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>
  
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
    	$(function () {
    		var acceptypes = ['jpg', 'jpeg', 'gif', 'png'];
    		var valid = true;
    		$("#viewIntroduce").submit(function () {
    			$("#p1,#p2").each(function () {
    				var filename = $(this).val().toString();
    				var type = filename.substr(filename.lastIndexOf('.') + 1).toLowerCase();
    				if ($(this).val() != "") {
    					if ($.inArray(type, acceptypes) == -1) {
    						alert('只接受类型为' + acceptypes.join(',') + '的文件');
							$(this).val('');
    						$("#filename").val('');
    						valid = false;
    					}
    				}
    			});
    			return valid;
    		});

    	});

        KindEditor.ready(function (K) {
            var editor1 = K.create('#introIntroduction', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=viewIntroduce]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=viewIntroduce]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });


        function Close() {
            window.opener.location.reload();
            window.close();
        }

       
        
    </script>

</head>
<body> 
   
    <div id="Div1" runat="server" >
        
      
    <form name="viewIntroduce" id="viewIntroduce" action="SaveIntroduce.aspx"  method="post" enctype="multipart/form-data" >
        

        <table class="addNewsTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;物业介绍&nbsp;&nbsp;
			</caption>
           

            <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> 内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="introIntroduction" name="introIntroduction" cols="100" rows="8" style="width:99.5%;height:310px;visibility:hidden;" runat="server">
                        <%=intro.Introduction %>
                     </textarea>
                </td>
            </tr>

            <tr class="addNewsTableTr">
                 <td class="leftTitle addNewsTableTd"> 联系地址： </td>
                <td class="addNewsTableTd" >
                    <input type="text" name="introAddress" id="introAddress" size="40" value="<%=intro.Address %>"/>
                </td>
            </tr>

            <tr class="addNewsTableTr">
                 <td class="leftTitle addNewsTableTd"> 联系电话： </td>
                <td class="addNewsTableTd" >
                    <input type="text" name="introTele" id="introTele" size="40" value="<%=intro.Telephone %>"/>
                </td>
            </tr>
    
            <tr class="addNewsTableTr">
                 <td class="leftTitle addNewsTableTd"> 电子邮箱： </td>
                <td class="addNewsTableTd" >
                    <input type="text" name="introEmail" id="introEmail" size="40" value="<%=intro.Email %>"/>
                </td>
            </tr>
            <tr class="addNewsTableTr">
                 <td class="leftTitle addNewsTableTd"> 首页顶部图片： </td>
                <td class="addNewsTableTd" >
                    <input type="file" name="p1" id="p1" />(570*100)
                </td>
            </tr>
			            <tr class="addNewsTableTr">
                 <td class="leftTitle addNewsTableTd"> 首页左下角图片： </td>
                <td class="addNewsTableTd" >
                    <input type="file" name="p2" id="p2" />(228*230)
                </td>
            </tr>
    		<tr class="addNewsTableTr">				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="updateBtn"/>
					
    			</td>
    				
    		</tr>
    		
         </table> 
            
     </form>
    </div>
    
  </body>
</html>
