<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImagePhoto.aspx.cs" Inherits="Webmag_Employe_officework_repairtable_ImagePhoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="../../../Scripts/slide/js/jquery.anythingslider.js"></script>
     <link rel="stylesheet" type="text/css" href="../../../Scripts/slide/css/anythingslider.css"/>
     <script type="text/javascript">
         $(function () {
             $('#slider').anythingSlider();
         });
	</script>

    <style type="text/css">
    #slider { width: 700px; height: 390px; }
 
    </style>
</head>
<body id="simple">
  <ul id="slider">

       <%for (int i = 0; i < imageList.Count; i++)
         {
        %>
        <li><img src="<%=imageList[i].AttachUrl %>" alt="维修表单"/></li>
        <%} %>
		
	</ul>
</body>
</html>
