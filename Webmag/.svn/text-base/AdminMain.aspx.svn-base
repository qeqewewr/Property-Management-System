<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminMain.aspx.cs" Inherits="Webmag_AdminMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<link rel="stylesheet" type="text/css" href="CSS/webmag.css"/> 
    <link rel="stylesheet" type="text/css" href="Scripts/facebox/facebox.css"/> 

	<script type="text/javascript" src="Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="Scripts/facebox/facebox.js"></script>
<head>
    <title></title>
</head>
<body>
<% if (role == "lessee")
   {
	 %>
   <iframe src="Employe/officework/noticeann/ViewLesseeNotice.aspx?action=unread" style="border-width:0; width:100%; height:auto" ></iframe>
    <iframe src="Employe/surveyManage/surveyLesseeView.aspx" style="border-width:0; width:100%; height:250px;" ></iframe>
    <%} 
   else
   {%>
   <iframe src="Employe/earlypre/orderremove/ViewOrderRemove.aspx?action=notSure&pageno=1" style="border-width:0; width:100%; height:auto" ></iframe>
         <iframe src="Employe/officework/answercomplain/ViewComplainFeedback.aspx?action=notBack&pageno=1" style="border-width:0; width:100%; height:auto" ></iframe>
         <iframe src="Employe/officework/orderwork/ViewOrderWork.aspx?action=notSure&pageno=1" style="border-width:0; width:100%; height:auto" ></iframe>
           <iframe src="Employe/quitorder/ViewQuitOrder.aspx?action=notSure&pageno=1" style="border-width:0; width:100%; height:auto" ></iframe>
   <%} %>


</body>
</html>
