<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Webmag_Employe_earlypre_orderremove_Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
    <script type="text/javascript">
        var req;
        function ChangeSelect() {
            var building = document.getElementById(""building"").value;
            var url = "test.aspx?=" + building;
            if (window.XMLHttpRequest)
                req = new XMLHttpRequest();
            else if (window.ActiveXObject) {
                req = new ActiveXObject("Microsoft.XMLHTTP");
            }
            if (req) {
                req.open("POST", url, true);
                req.onreadystatechange = callback;
                req.send(null);
            }
        }
        function callback() {
            if (req.readyState == 4) {
                if (req.status == 200) {
                    parseMessage();
                }
                else {
                    alert("error");
                }
            }

        }

        function parseMessage() {
            var text = rep.responseText;
            var _root = document.getElementById(""room"");

        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>楼宇
               </td>
                <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select name="building" onChange="ChangeSelect()" style="width: 85px">                        
                        <%for (int i = 0; i < buildingList.Count; i++)
                          { %>
                        <option value="<%=buildingList[i].Name %>"><%=buildingList[i].Name%></option>
                        <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
           
            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>房间号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		       <select id = "room" name="room" style="width: 80px">                        
                        <%for (int i = 0; i < roomList.Count; i++)
                          { %>
                        <option value="<%=roomList[i].Number %>"><%=roomList[i].Number%></option>
                        <%} %>
                    </select>
                    &nbsp;&nbsp;&nbsp;
    		   </td>
            </tr>
    </div>
    </form>
</body>
</html>
