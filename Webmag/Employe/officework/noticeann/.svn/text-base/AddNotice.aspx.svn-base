<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNotice.aspx.cs" Inherits="Webmag_Employe_tabledoc_uploaddoc_DocumentAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布通知</title>
        <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <link rel="Stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>

    <script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/kindeditor.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/lang/zh_CN.js"></script>
	<script type="text/javascript" charset="utf-8" src="../../../../kindeditor-v4.0.4/plugins/code/prettify.js"></script>

    <script language="javascript" type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>

    <script>
   
    </script>
    <style>
    div.builds span{ padding:4px 10px; color:#1A4963; background-color:orange; cursor:pointer; display:inline-block; margin:2px; }
    div.builds span.active{ background-color:#1A4963; color:White; }
    div.rooms ul{float:left; display:inline-block; padding-left:0;}
    div.rooms ul li{ float:left; display:inline-block; padding:5px 8px; list-style:none; list-style-position:inside;}
</style>
</head>
<body>
<form action="AddNotice.aspx?id=<%=notice.ID %>" method="post">
   <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
     <caption>发布通知</caption>
     <tbody>
       <tr>
        <td><font color="red"> &nbsp*</font>发布者</td>
        <td><input type="text" name="publisher" id="publisher"  class="inputText" value="<%=notice.Publisher %>" /></td>
       </tr>
        <tr>
        <td><font color="red"> &nbsp*</font>发布日期</td>
        <td><input type="text" name="publishDate" id="publishDate"  class="inputText" value="<%=notice.PublishDate %>" /><img id="birthCalImg"  class="datepicker" src="../../../Images/cal.gif" /></td>
       </tr>
      
        <tr>
        <td><font color="red"> &nbsp*</font>通知类别</td>
        <td><select id="typeselect" name="noticetypeid"> 
            <option value="-1">请选择类别</option>
            <% for (int i = 0; i < noticetypelist.Count; i++)
               { %>
            <option value="<%=noticetypelist[i].ID %>"  <%if(noticetypelist[i].ID == notice.ID){ %>selected <%} %> ><%=noticetypelist[i].Name %></option>
            <%} %>
            </select>
            <input type="hidden" value="" name="noticetype" id="noticetype" />
            </td>
       </tr>
                  <tr>
        <td><font color="red"> &nbsp*</font>通知房间号</td>
        <td><textarea name="rooms" rows="3" cols="45" id="roomsGroup"><%=notice.Rooms%></textarea>
        <a href="../../../SelectRoom.aspx" id="selectroom">点击选择房间号</a>
         
        </td>
       </tr>
      
         <tr>
        <td><font color="red"> &nbsp*</font>通知内容</td>
        <td><textarea name="content" id="content" rows="7" cols="75"><%=notice.NoticeContent%></textarea></td>
       </tr>



      <tr>
        <td colspan="2">
            <input type="submit" value="" class="saveBtn" /> &nbsp&nbsp<a href="ViewNotice.aspx">浏览通知</a>
        </td>
        
       </tr>
     </tbody>
   </table>
</form>
<div id="wrap" style="display:none;"></div>
</body>
</html>
<script type="text/javascript">
    var selectRoomNum = 0;
    var mark = 0;
    var Rooms = {

};

KindEditor.ready(function (K) {
    window.editor1 = K.create('#content', {
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
    //prettyPrint();
});

$(function () {


    $('#publishDate').simpleDatepicker({ y: 20, x: -20 });
    $("#birthCalImg").bind('click', function () { $("#publishDate").click(); });

    $("#typeselect").change(function () {
        if ($(this).val() != "-1") {
            var val = $(this).find("option:selected").html();
            $("#noticetype").val(val);
        } else {
            $("#noticetype").val("");
        }
    });



    $("#typeselect").trigger("change");
    $(document).bind('reveal.facebox', function () {
        var $facebox = $("#facebox");
        $facebox.find("span").each(function (i) {
            $(this).click(function () {
                $facebox.find("span").removeClass('active');
                $(this).addClass('active');
                $facebox.find("ul").hide().eq(i).show();
            });
        }).eq(0).trigger('click');
        $facebox.find(":checkbox").each(function () {
            var build = $(this).attr('name');
            var room = $(this).val();

            if (Rooms[build] && Rooms[build][room]) {
                $(this).attr('checked', true);
            }
        });
        $facebox.find("input.selectBtn").click(function () {
            selectRoomNum = 0;
            var rooms = [];
            $facebox.find(":checkbox").each(function () {
                if ($(this).attr("checked") == true) {
                    selectRoomNum++;

                    var build = $(this).attr('name');
                    var room = $(this).val();
                    if (!Rooms[build]) Rooms[build] = {};
                    Rooms[build][room] = 1;
                    rooms.push($.trim(build + room));
                }
            });
            $("#roomsGroup").val(rooms.join(','));
            $.facebox.close();
        });

    });

    $("#roomsGroup").focus(function () {
        $(this).blur();
        $("#selectroom").trigger('click');
    });

    $("#selectroom").click(function () {
        if (mark == 0) {
            var url = this.href;
            $.get(url, function (data) {
                $("#wrap").html(data);
                $.facebox({ div: '#wrap' });
                mark = 1;
            });
        } else {
            $.facebox({ div: '#wrap' });
        }


        return false;
    });


    $("#typeid").change(function () {
        if ($(this).val() != "-1") {
            var key = $(this).val();
            $("#typename").val(types[key]);
        }
    });

    $('.saveBtn').click(function () {
        if ($("#publiser").val() == '') {
            alert("发布者不能为空");
            return false;
        }

        if ($("#publishDate").val() == '') {
            alert("发布日期为空");
            return false;
        }

        if ($("#typeselect").val() == '-1') {
            alert("类型不能为空");
            return false;
        }
        if (editor1.html() == '') {
            alert("内容不能为空");
            return false;
        }
        if ($("#roomsGroup").val() == '') {
            alert("通知房间号不能为空，请点击右边的提示进行选择");
            return false;
        }


        for (var build in Rooms) {
            $("form:first").append('<input type="hidden" name="builds" value="' + $.trim(build) + '" />');
            for (var room1 in Rooms[build]) {
                $("form").append('<input type="hidden" name="' + build + '" value="' + $.trim(room1) + '" />');
            }

        }

        return true;
    });


})

</script>