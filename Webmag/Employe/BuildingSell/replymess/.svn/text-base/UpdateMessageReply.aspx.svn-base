<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMessageReply.aspx.cs" Inherits="Webmag_Employe_BuildingSell_replymess_UpdateMessageReply" %>

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
            var editor1 = K.create('#leaveMessage', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=editMessageReply]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=editMessageReply]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });

        KindEditor.ready(function (K) {
            var editor1 = K.create('#replyMessage', {
                cssPath: '../../../../kindeditor-v4.0.4/plugins/code/prettify.css',
                uploadJson: '../../../../upload_json.ashx',
                fileManagerJson: '../../../../file_manager_json.ashx',
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=editMessageReply]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=editMessageReply]')[0].submit();
                    });
                }
            });
            prettyPrint();
        });

        $(function () {
            $('#messageReplyTime').simpleDatepicker({ y: 20, x: -20 });
            $("#replyTimeCalImg").bind('click', function () { $("#messageReplyTime").click(); });
            $('.saveBtn').click(function () {
                return checkForm();
            });
        });

        function Close() {
            window.opener.location.reload();
            window.close();
        }

        function checkForm() {
        /*
            var r = $("#messageReplyTime").val();
            //验证日期格式是否为yyyy/mm/dd
            var theDate = $.trim(r);
            var flag = isdate(theDate);
            if (!flag || theDate == "") {
                alert("回复时间格式有错，请重新输入时间！");
                $("#messageReplyTime").focus();
                return false;
            }
            */
            return true;
        }
        
    </script>
</head>

<body>
  <div id="Div1" runat="server" >
  
    <form id= "editMessageReply" name="editMessageReply" action="DoUpdate.aspx?oldid=<%= id %>&pageno=<%= pageno %>" onsubmit="return checkForm()" method="post" >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;留言回复&nbsp;&nbsp; 
			</caption>
           
			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>        	        			   

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;&nbsp*</font>编号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="messageReplyId" type="text" size="26" name="messageReplyId" disabled="disabled" value="<%= messageReply.Id %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
           <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>留言时间
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="messageLeaveTime" type="text" size="26" name="messageLeaveTime" value="<%= messageReply.LeaveTime %>" disabled = "disabled"/>&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>    

       
             <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> <font color="red"> &nbsp;</font>留言内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="leaveMessage" name="leaveMessage" cols="100"  
                         style="width:99.5%;height:221px; visibility:hidden;" runat="server">  
                         <%=messageReply.LeaveMessage%>
                     </textarea>
                </td>

          

         

           
              
               <tr class="addNewsTableTr">
                <td class="leftTitle addNewsTableTd"> <font color="red"> &nbsp;</font>回复内容： </td>
                <td class="addNewsTableTd" colspan="2">
                     <textarea id="replyMessage" name="replyMessage" cols="100"  
                         style="width:99.5%;height:221px; visibility:hidden;" runat="server">  
                         <%=messageReply.Reply%>
                     </textarea>
                </td>
                </tr>
            <tr >
               <td class="leftTitle" >
		             <font color="red"> &nbsp;*</font>留言是否发布
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <select name="messageIsReplyed" style="width: 42px">
                          <%if (messageReply.IsReplyed == true)
                      {%>
                          <option value="是">是</option>
                          <option value="否">否</option>
                    <%}
                      else
                      { %>
                          <option value="否">否</option>
                          <option value="是">是</option>
                    <%} %>
                    </select>&nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>  

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
                    <input type="submit" value=""   class="saveBtn">
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewMessageReply.aspx?pageno=1 '" value="">										
    			</td>
    				
    		</tr>
    		
        </table>     
            
     </form>
    </div>
    
</body>

</html>
