<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRoomInformation.aspx.cs" Inherits="Webmag_Employe_BuildingSell_roominform_ViewRoomInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1"   runat="server">  
    <title></title>
	<meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	 
	<link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../../../Scripts/RoomInfor.js"></script>
    <script type="text/javascript">
        function changeAction() {
            $("#action").val("search");
            $("#keyword").val($("#roomName").val());
            $("#buildName").val($("#roomBuildName").val());
            $("#scope").val($("#searchScope").val());
        }

 
      
	</script>
    <script type="text/javascript">
        $(function () {
            $(".addRoomSource").click(function () {
                $("#pageControlForm").append("<input type='hidden' name='action' value='add' />").submit();
                return false;
            });
        });
        $(function () {
            $(".deleteRoomSource").click(function () {
                $("#pageControlForm").append("<input type='hidden' name='action' value='delete' />").submit();
                return false;
            });
        });
        
    </script>
    
     <style type="text/css">
         .style1
         {
             width: 215px;
         }
     </style>

    
 </head>

<body> 
   
    <div style="width: 100%">

        <div class="queryArea"  style="width:100%">
            <form action="ViewRoomInformation.aspx?pageno=1" name="searchForm"
				id="Form1" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="buildName" id="buildName" value="" />
                <input type="hidden" name="scope" id="scope" value="" />

                <input type="hidden" name="condition" id="Hidden4" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 房源信息查询  </legend> 
					<span>房号查询：<input type="text" name="roomName" id="roomName" title="请输入房号"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="20" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;&nbsp;
                        大楼名：
                        <select name="roomBuildName" id="roomBuildName">
                     <%--   <%if (buildName == ""||buildName==null)
                          { %>
                            <option>请选择大楼名</option>
                        <%} %>--%>
                        <%for (int i = 0; i < buildNameList.Count; i++)
                          { %>
                            <option ><%=buildNameList[i]%></option>
                        <%} %>    
                        </select>
                         &nbsp;&nbsp; &nbsp;&nbsp;查询范围：
                        <select name="searchScope" id="searchScope" >
                        <%if (scope == null||scope=="全部")
                          { %>
                            <option>全部</option>
                            <option>已展示</option>                            
                            <option>未展示</option> 
                        <%}
                          if (scope == "已展示")
                          { %> 
                            <option>已展示</option>
                            <option>未展示</option>
                            <option>全部</option>   
                        <%}
                            if (scope == "未展示")
                            {%>                         
                             <option>未展示</option>
                             <option>已展示</option>
                             <option>全部</option> 
                            
                        <%} %>
                        </select>
                        <input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>

        <div>
			<table class="resultTable" >

				<caption style="text-align: left" >
					&nbsp;&nbsp;&nbsp;&nbsp;房间信息列表：
                    
				</caption>


				<tr class="topTitle" align="center">
					<td align="center" class="style1">选 择</td>
					<td align="center">大楼名称</td>
					<td align="center">房间号</td>
                    <td align="center">朝向</td>
                    <td align="center">面积(单位:平方米)</td>
                    <td align="center">装修情况</td>
                    <td align="center">当前租户</td> 
                    <td align="center">最短租期(单位:月)</td> 
                    <td align="center">租金(单位:元)</td> 
                    <td align="center">当前出租到期日</td>          
                    <td align="center"><font color="red">是否已展示</font></td>
					
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                
                <input type="hidden" name="keyword"  value="<%=keyword %>" />
                <input type="hidden" name="scope"  value="<%=scope %>" />
                <input type="hidden" name="buildName" value="<%=buildName %>" />

                <%for (int i = 0; i < roomList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							<td class="style1"><input type="checkbox" name="selectDel"
								value="<%= roomList[i].ID %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
							
							<td title="<%= roomList[i].BuildingName%>" align="left"><%= roomList[i].BuildingName%></td> 
							<td title="<%= roomList[i].Number %>"><%= roomList[i].Number %></td>
                            <td title="<%= roomList[i].Toward %>"><%= roomList[i].Toward%></td>
                            <td title="<%= roomList[i].Area %>"><%= roomList[i].Area%></td>
                            <td title="<%= roomList[i].Decoration %>"><%= roomList[i].Decoration%></td>
                            <td title="<%= roomList[i].Lessee %>"><%= roomList[i].Lessee %></td>
                            <td title="<%= roomList[i].MinLease %>"><%= roomList[i].MinLease%></td>
                            <td title="<%= roomList[i].Rent %>"><%= roomList[i].Rent%></td>
                            <td title="<%= roomList[i].RentEnd %>"><%= roomList[i].RentEnd%></td>          
                            <td title="<%= pageBLL.TransformBooleanToChinese(roomList[i].IsShowed) %>"><%=pageBLL.TransformBooleanToChinese(roomList[i].IsShowed)%></td>          
						</tr>
				<%} %>
					
					<tr>	
						<td class="style1"> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> 
                               <a href="#" class="addRoomSource">添加房源</a>
                                 <a href="#" class="deleteRoomSource">删除房源</a>
                               <!-- <input type="submit" class="deleteBtn" value="" title="删除房源"  />-->
						</td>
						<td colspan="10" id="Td1"></td>
					</tr> 
                </form>


                 <tr>
					<td colspan="11" valign="middle">
						<!-- markupPage -->
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table2" >
							 
							<tr style="border:0px;">
								<td style="border:0px;">
									<span>[总数:<%=page.RowCount %>条]</span> <span>[每页:<%= page.PageSize %>条]</span> [页次:<span title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo %></span>/<%= page.PageCount %>]
								</td> 
								<td align="right"  style="border:0px;">
                                    <%if (page.PageNo == 1)
                                      { %>
                                        <font title="首页">首页</font> <font title="前一页">前一页</font>
                                    <%}
                                      else
                                      {%>
									        <a href="javascript:gotoPage(1)"><font title="首页">首页</font></a> <a href="javascript:gotoPage(<%= page.PrePage %>)"><font title="前一页">前一页</font></a>
									<%} %>
                                    <%if (page.PageNo == page.PageCount)
                                      { %>
                                            <font title="下一页">下一页</font> <font title="最后一页">最后一页</font>
                                    <%}
                                      else
                                      {%>
									        <a href="javascript:gotoPage(<%= page.NextPage %>)"><font title="下一页" >下一页</font></a> <a href="javascript:gotoPage(<%= page.PageCount %>)"><font title="最后一页">最后一页</font></a>

									<%} %>
		
									跳到
								<input type="text"  style="width:20px" name="pageno1" id="Text2" value="<%= page.PageNo %>"   />
								页  <a href="javascript:testAndGotoPage(document.getElementById('pageno1').value,<%= page.PageNo %>,<%= page.PageCount %>)"><font title="GO">GO</font></a>
								</td>
								<td style="width:15px;"></td> 
							</tr>
						</table> 
					</td>
				</tr>

            </table>
        </div>
 


	</div>
    
  </body>
</html>
