<%@ Page Language="C#" AutoEventWireup="true" CodeFile="navAdd.aspx.cs" Inherits="Webmag_Employe_tabledoc_uploaddoc_DocumentAdd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>文档上传</title>
        <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <link rel="Stylesheet" type="text/css" href="../../../CSS/calendar.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/util.js"></script>
    <script language="javascript" type="text/javascript" src="../../../Scripts/cal.js"></script>

</head>
<body>
<form action="navAdd.aspx?id=<%=nav.ID %>" method="post" >
   <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
     <caption>编辑菜单</caption>
     <tbody>
       <tr>
        <td><font color="red"> &nbsp*</font>菜单名称</td>
        <td><input type="text" name="name" id="name"  class="inputText" value="<%=nav.Name %>" /></td>
       </tr>
          <tr>
      <td><font color="red"> &nbsp*</font>链接地址</td>
        <td>
           <input type="text" name="url" id="url"  class="inputText" value="<%=nav.Url %>" />

        </td>
        </tr>

    
      <tr>
        <td colspan="2"  class="buttonGroup">
            <input type="submit" value=""   class="saveBtn" /> &nbsp&nbsp<a href="navView.aspx">返回浏览菜单</a>
        </td>
        
       </tr>
     </tbody>
   </table>
</form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        $('.saveBtn').click(function () {
            if ($("#name").val() == '') {
                alert("菜单名称不能为空");
                return false;
            }
            if ($("#url").val() == '') {
                alert("链接地址不能为空");
                return false;
            }
            return true;

        });

    })

</script>