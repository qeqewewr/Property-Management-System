<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNoticeType.aspx.cs" Inherits="Webmag_Employe_tabledoc_docmang_documentTypeAddaspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>文档上传</title>
        <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
 
</head>
<body>
<form action="AddNoticeType.aspx?id=<%=noticeType.ID %>" method="post" enctype="multipart/form-data">
   <table class="addTable" width="800" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
     <caption>通知类型编辑</caption>
     <tbody>
       <tr>
        <td><font color="red"> &nbsp*</font>类型名称</td>
        <td><input type="text" name="typename" id="typename"  class="inputText" value="<%=noticeType.Name %>" /></td>
       </tr>
   
   
      <tr>
        <td colspan="2"  class="buttonGroup">
            <input type="submit" value=""   class="saveBtn" /> &nbsp <a href="ViewNoticeType.aspx">返回查看通知类型</a>
        </td>
        
       </tr>
     </tbody>
   </table>
</form>
</body>
</html>
<script type="text/javascript">
    $(function () 
        $('.saveBtn').click(function () {
            if ($("#typename").val() == '') {
                alert("名称不能为空");
                return false;
        });
    })

</script>