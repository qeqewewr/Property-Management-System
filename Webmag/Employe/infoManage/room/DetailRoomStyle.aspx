<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailRoomStyle.aspx.cs" Inherits="Webmag_Employe_infoManage_room_DetailRoomStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"  />
     <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/> 

    <script type="text/javascript" language="javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>

    <script type="text/javascript">

        jQuery(document).ready(function ($) {
            $('a[rel=facebox]').facebox();
        })
    </script>
</head>

<body>
   

    <div>
        <form id="example" action="">
            <input type="hidden" name="roomStyleID" id="roomStyle" value="<%=roomStyle.ID  %>" />

            <table width="100%" class="addTable" cellpadding="0"
					cellspacing="0" style="border-collapse: collapse;"> 
                <caption>					
					房型图信息查看
				</caption>
                <tr>
                    <td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                    <td></td>
                </tr>
                <tr>
                    <td class="leftTitle" width="150"><font color="#cc0033">*</font>房型图名称</td>
                    <td><input type="text" disabled="disabled" name="roomStyleName"  id="roomStyleName"  value="<%=roomStyle.Name %>"/></td>
                </tr>
                
                <tr>
                    <td class="leftTitle"  >房型图预览</td>
                    <td >
                    <%for (int i = 0; i < imageList.Count; i++)
                      { %>                   
                         <a rel="facebox" href="facebox.aspx?id=<%=imageList[i].ID %>"><img alt="" width="250" height="200" name="<%= imageList[i].AttachName %>" src="<%= imageList[i].AttachUrl %>" /></a>&nbsp;&nbsp;&nbsp;&nbsp;
                    <%  if((i+1)%4==0)
                        {%><br />
                      <%}
                      } %>
                      
                      
                    </td>
                </tr>
                
                <tr>
				    <td colspan="2" class="buttonGroup">
					    <input name="backClose" type="button" class="backBtn" id="backClose" onclick="history.go(-1)" value=""/>	
					
				    </td>
			    </tr>
			
            

            </table>
        </form>
    </div>
   

</body>

</html>
