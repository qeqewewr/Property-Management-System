<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailInfo.aspx.cs" Inherits="Webmag_Employe_infoManage_building_DetailInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../../CSS/webmag.css" />
    <script language="javascript" type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>


    <style type="text/css">
        .button {
	BORDER-BOTTOM: #636467 1px solid; BORDER-LEFT: #636467 1px solid; PADDING-BOTTOM: 1px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; FONT: 12px/17px "songti"; BACKGROUND: url(images/btn_bg.gif) repeat-x 0px -1px; COLOR: #000; BORDER-TOP: #636467 1px solid; BORDER-RIGHT: #636467 1px solid; PADDING-TOP: 1px
}
    .contentCenter {
	TEXT-ALIGN: left; MARGIN: 0px auto; WIDTH: 800px ; border:1px solid #cccccc;padding-top:20px;
}

        .style1
        {
            height: 25px;
        }

    </style>
    
    
    
</head>
<body>
    
  <div id="Div1" runat="server" >
        
      
    <form name="ViewBuilding"  >
    
        <table class="addTable" width="100%" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
            <caption>
					&nbsp;&nbsp;大楼信息查看&nbsp;&nbsp;
			</caption>

			<tr >
				<td class="leftTitle"> 注：<font color="red">*</font>为必填项</td>
                <td class="inputText" align="left">&nbsp;</td>
			</tr>   
                 	        			   
             <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>大楼编号
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="buildingID" disabled="disabled" type="text" size="26" name="buildingID" value="<%= build.ID %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
               
            </tr>

            <tr>
               <td class="leftTitle">
		            <font color="red"> &nbsp;*</font>大楼名称
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="buildingName" disabled="disabled" type="text" size="26" name="buildingName" value="<%=build.Name %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>

            <tr >
               <td class="leftTitle" rowspan="2">
		            管理员ID
               </td>
               <td  align="left" rowspan="2" >&nbsp;&nbsp;&nbsp;&nbsp;部门
                   
                    <select name="depart" id="depart" disabled="disabled" >   
                     <%if (employe != null)
                       { %>
                        <option><%=employe.Department%></option>
                    <%}
                      else
                      { %>
                        <option>请选择部门</option>
                    <%} %>
                    </select>
                    &nbsp;员工
                    <select name="employe" id="employe" disabled="disabled">
                    <%if (employe != null)
                       { %>
                        <option><%= employe.Name%></option>
                    <%}
                      else
                      { %>
                        <option>请选择员工</option>
                    <%} %>                
                                           
                    </select>
                   
                    <br />
    				&nbsp; &nbsp; &nbsp; 
                    <input class="inputText" id="buildingAdmin" disabled="disabled"  name="buildingAdmin" type="text" size="26" value="<%= build.AdminID %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
            <tr></tr>
            <tr>
               <td class="leftTitle">
		           &nbsp;&nbsp;位置
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    				<input class="inputText" id="buildingPos" disabled="disabled" type="text" size="26" name="buildingPos" value="<%= build.Position %>" />&nbsp;&nbsp;&nbsp;
                   
               </td>
            </tr>
     

            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;面积
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="buildingArea" disabled="disabled" type="text" size="26" name="buildingArea" value="<%= build.Area %>" />&nbsp;&nbsp;&nbsp;平方米
    		   </td>
            </tr>
            
            <tr >
               <td class="leftTitle" >
		             &nbsp;&nbsp;层数
               </td>
               <td  align="left">&nbsp; &nbsp; &nbsp; 
    		        <input class="inputText" id="buildingFloor" disabled="disabled" type="text" size="26" name="buildingFloor" value="<%= build.Floor %>" />&nbsp;&nbsp;&nbsp;层
    		   </td>
            </tr>

               <tr>
               <td class="leftTitle">
		           简介
               </td>
               <td  colspan="2">&nbsp; &nbsp; &nbsp; 
    				<textarea id="buildingIntro" disabled="disabled" name="buildingIntro" cols="100" rows="6" >
                    </textarea>
                   
               </td>
            </tr>

            <tr>
                    <td class="leftTitle" >大楼图预览</td>
                    <td>
                    <%for (int i = 0; i < imageList.Count; i++)
                      { %>                   
                        <img alt="" width="250" height="200" name="<%= imageList[i].AttachName %>" src="<%= imageList[i].AttachUrl %>" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <%  if ((i + 1) % 4 == 0)
                        {%><br />
                        <%}
                      } %>
                      
                      
                    </td>
                </tr>

    		<tr>				
    			<td class="buttonGroup" colspan="3">&nbsp; &nbsp; &nbsp;
					<input name="btnClose" type="button" class="closeBtn" id="btnClose" onclick="window.location.href='ViewBuilding.aspx?pageno=<%=pageno %> '" value=""/>										
    			</td>
    				
    		</tr>
    		
        </table>  
      </form>
      
      </div>       
   
    
</body>
</html>
