<%@ Page Language="C#" AutoEventWireup="true" CodeFile="documentAdd.aspx.cs" Inherits="Webmag_Employe_tabledoc_uploaddoc_DocumentAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>文档上传</title>
        <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>
    <script>
        var types = {};
          <%for (int j = 0; j < doctypelist.Count; j++)
            { %>
            types['<%=doctypelist[j].ID %>'] = '<%=doctypelist[j].Name %>';
          <%} %>
    </script>
</head>
<body>
<form action="documentAdd.aspx?id=<%=doc.ID %>" method="post" enctype="multipart/form-data">
   <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
     <caption>文档上传</caption>
     <tbody>
       <tr>
        <td><font color="red"> &nbsp*</font>标题</td>
        <td><input type="text" name="title" id="title"  class="inputText" value="<%=doc.Title %>" /></td>
       </tr>
          <tr>
      <td><font color="red"> &nbsp*</font>选择上传文档</td>
        <td>
            <input type="file" value="" name="file" id="file" />

        </td>
        </tr>

       <tr>
        <td><font color="red"> &nbsp*</font>文件名</td>

        <td><input type="text" name="filename" id="filename" class="inputText" value="<%=doc.FileName %>"  />
                              <%if (doc.ID != null) { %>
                <input type="hidden" name="fileurl" value="<%=doc.FileUrl %>" />
            <%} %>   
        </td>
       </tr>
              <tr>
        <td><font color="red"> &nbsp*</font>文件类型</td>
        <td>
        <input type="hidden" name="typename" id="typename" value="" />
        <select id="typeid" name="typeid">
        <option value="-1">请选择类别</option>
          <%for (int i = 0; i < doctypelist.Count; i++)
            { %>
            <option value="<%=doctypelist[i].ID %>"><%=doctypelist[i].Name %></option>
          <%} %>
        </select></td>
       </tr>
           <tr>
        <td><font color="red"> &nbsp*</font>上传者</td>
        <td><input type="text" name="uploadname" id="uploadname"  class="inputText" value="<%=doc.UploadName%>" /></td>
       </tr>
       <tr>
        <td>描述</td>
        <td><textarea name="filedesc" rows="3" cols="45"><%=doc.FileDesc%></textarea></td>
       </tr>
   
      <tr>
        <td colspan="2"  class="buttonGroup">
            <input type="submit" value=""   class="saveBtn" /> &nbsp&nbsp<a href="documentView.aspx">浏览文档</a>
        </td>
        
       </tr>
     </tbody>
   </table>
</form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        if (window.action && window.action === 'eddit') {
            $("#file").closest("tr").remove();
            $("form").removeAttr('enctype');
        }

        $("#file").change(function () {
            if ($(this).val() != "") {
                var filename = $(this).val().toString();
                var type = filename.substr(filename.lastIndexOf('.') + 1).toLowerCase();
                console.log(type);
                var acceptypes = ['jpg', 'jpeg', 'doc', 'docx', 'ppt', 'gif', 'png', 'zip', 'rar','txt'];
                if ($.inArray(type, acceptypes) == -1) {
                    alert('只接受类型为' + acceptypes.join(',') + '的文件');
                    $(this).val('');
                    $("#filename").val('');
                    return false;
                }
                //filename = filename.substr(0, filename.lastIndexOf("."));
                filename = filename.substr(filename.lastIndexOf('\\') + 1);
                $("#filename").val(filename);
            }
        });

        $("#typeid").change(function () {
            if ($(this).val() != "-1") {
                var key = $(this).val();
                $("#typename").val(types[key]);
            }
        });

        $('.saveBtn').click(function () {
            if ($("#title").val() == '') {
                alert("标题不能为空");
                return false;
            }

            if (!window.action || window.action !== 'eddit') {
                if ($("#file").val() == "") {
                    alert("请选择上传文件");
                    return false;
                }
            }

            if ($("#filename").val() == '') {
                alert("文件名不能为空");
                return false;
            }
            if ($("#typeid").val() == '-1') {
                alert("请选择文档类型");
                return false;
            }

            if ($("#uploadname").val() == '') {
                alert("上传者不能为空");
                return false;
            }

        });
        if (window.typeid && window.typeid != "") {
            $("#typename").val(types[window.typeid]);
            $("#typeid option").each(function () {
                if ($(this).val() == window.typeid) $(this).attr("selected", "selected");
            });
        }

    })

</script>