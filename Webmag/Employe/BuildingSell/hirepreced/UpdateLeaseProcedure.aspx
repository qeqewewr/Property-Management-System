<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateLeaseProcedure.aspx.cs" Inherits="Webmag_Employe_BuildingSell_hirepreced_UpdateLeaseProcedure" %>

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
            var editor1 = K.create('#leaseContent', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=editLeaseProcedure]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=editLeaseProcedure]')[0].submit();
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
          
            return true;
        }
        
    </script>
</head>
<body>

    <div>
        <form id = "editLeaseProcedure"name="editLeaseProcedure" action="DoUpdate.aspx?id=1>" onsubmit="return checkForm()" method="post" >

     
        
        <table class="addNewsTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;租赁手续编辑窗口&nbsp;&nbsp;
			</caption>


            <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> 租赁手续具体内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="leaseContent" name="leaseContent" cols="100" rows="8" style="width:99.5%;height:310px;visibility:hidden;" runat="server">
                        <%= leaseProcedure.LeaseContent%>
                     </textarea>
                </td>
            </tr>
    
    		<tr>				
    			<td class="buttonGroup" colspan="4">&nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                    <input type="submit" value=""   class="saveBtn"></td>
    				
    		</tr>
    		
           
        </table>  
            
         </form>
    
       </div>

</body>
</html>
