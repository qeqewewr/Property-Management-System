<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Webmag_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>光大物业</title>
</head>
<frameset rows="80,*" frameborder="0" border="1"> 
        <frame name="top" src="AdminTop.aspx" scrolling="no" noresize > 
        <frameset cols="150,*"> 
            <frame name="left" src="AdminLeft.aspx" scrolling="no" > 
            <frame name="mainFrame" src="AdminMain.aspx"  > 
        </frameset> 
</frameset>  
</html>
