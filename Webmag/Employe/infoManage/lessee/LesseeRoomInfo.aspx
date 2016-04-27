<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LesseeRoomInfo.aspx.cs" Inherits="Webmag_Employe_infoManage_lessee_LesseeRoomInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>

</head>
<body>
    
  <div id="Div1" runat="server" >								
        
      
    <form name="LesseeRoomInfo" action="ViewLessee.aspx?pageno=<%= pageno %>&keyword=<%= keyword %>&scope=<%=scope %>" method="post" >
       

        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>&nbsp;&nbsp;租户租赁情况&nbsp;&nbsp;</caption>
            <tbody>
            <%for (int i = 0; i < buildList.Count; i++)
              {
                  string roomInfo = "";%>
            <tr>
               <td class="leftTitle">
		            <font color="red"><%=buildList[i]%></font>
               </td>
               <%for (int j = 0; j < room[i].Count; j++)
                 {
                     roomInfo += room[i][j];
                     if (j < room[i].Count - 1)
                         roomInfo += ",       ";
                 }%>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input  class="inputText"  id="roomList" type="text" size="26" name="roomList" value="<%=roomInfo %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
            <%} %>  
                     
           <% if (buildList.Count == 0)
              { %>
              <tr>
               <td  align="center">
		            <font color="red">该租户没有租用的房间！！</font>
               </td>
              </tr>
         <%} %>

    		<tr>				
    			<td class="buttonGroup" colspan="2">&nbsp; &nbsp; &nbsp;
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewLessee.aspx?pageno=<%=pageno %>&keyword=<%= keyword %>&scope=<%=scope %> '" value=""/>										
    			</td>
    				
    		</tr>
          </tbody>
    		
        </table>    
            
     </form>
    </div>
    
    
</body>
</html>
