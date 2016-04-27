<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRoom.aspx.cs" Inherits="Webmag_Employe_infoManage_room_ViewRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server">  
    <title></title>
	<meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	
    <link rel="stylesheet" type="text/css" href="../../../Scripts/facebox/facebox.css"/> 
	<link rel="stylesheet" type="text/css" href="../../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../../../Scripts/facebox/facebox.js"></script>
    <script type="text/javascript" src="../../../Scripts/slide/js/jquery.anythingslider.js"></script>
    <link rel="stylesheet" type="text/css" href="../../../Scripts/slide/css/anythingslider.css"/>

    <script type="text/javascript">
        function changeAction() {
            $("#action").val("search");
            $("#keyword").val($("#roomName").val());
            $("#buildName").val($("#roomBuildName").val());
            $("#scope").val($("#searchScope").val());
        }


        jQuery(document).ready(function ($) {
            $('a[rel=facebox]').facebox();
        })

        $(function () {
            $('#slider').anythingSlider();
        });
      
	</script>

    <style type="text/css">
    #slider { width: 700px; height: 390px; }
    </style>
    
 </head>

<body> 
   
    <div style="width: 100%">

        <div class="queryArea"  style="width:100%">
            <form action="ViewRoom.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="buildName" id="buildName" value="" />
                <input type="hidden" name="scope" id="scope" value="" />

                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 房间信息查询  </legend> 
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
                            <option>已租用</option>                            
                            <option>未租用</option> 
                        <%}
                          if (scope == "已租用")
                          { %> 
                            <option>已租用</option>
                            <option>未租用</option>
                            <option>全部</option>   
                        <%}
                            if (scope == "未租用")
                            {%>                         
                             <option>未租用</option>
                             <option>已租用</option>
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
                    <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onclick="window.location.href='AddRoom.aspx'"/>
			        </span>
				</caption>


				<tr class="topTitle" align="center">
                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
					<td align="center">选 择</td>
                    <%} %>
					<td align="center">大楼名称</td>
                    <td align="center">管理员</td>
					<td align="center">房间号</td>
                    <td align="center">朝向</td> 
                    <td align="center">面积</td> 
                    <td align="center">装修情况</td> 
                    <td align="center">房型图</td>
                    <td align="center">租金</td> 
                    <td align="center">最短租期</td>            
                    <td align="center">出租情况</td>
                    <td align="center">截止日期</td>
					<td align="center" colspan="3">操 作</td>
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
                            <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
							<td><input type="checkbox" name="selectDel"
								value="<%= roomList[i].ID %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
							<%} %>
							<td title="<%= roomList[i].BuildingName%>" align="left"><%= roomList[i].BuildingName%></td>
                            <td title="<%= roomList[i].Admin%>" align="left"><%= roomList[i].Admin%></td> 
							<td title="<%= roomList[i].Number %>"><%= roomList[i].Number %></td>          
                            <td title="<%= roomList[i].Toward %>"><%= roomList[i].Toward %></td>
                            <td title="<%= roomList[i].Area %>"><%= roomList[i].Area %></td>
                            <td title="<%= roomList[i].Decoration %>"><%= roomList[i].Decoration %></td>
                            <%--<td title="<%= roomList[i].RoomStylePath %>">点击查看详情</td> --%>   
                            <%
                                roomStyle = roomStyleDAO.GetRoomStyleByName(roomList[i].RoomStyle);
                                if (roomStyle == null)
                                {%>
                                 <td>无房型图</td>
                               <%}
                                else
                                {
                                    imageList = imageDAO.GetImgAttachmentByTypeAndID(1, roomStyle.ID.ToString());
                                    if (imageList.Count != 0)
                                    {  %>           
							             <td title="<%=roomList[i].RoomStyle %>"><a rel = "facebox" href="ImagePhoto.aspx?id=<%=roomStyle.ID %>"><%=roomList[i].RoomStyle %></a></td>   
                                    <%}
                                    else
                                    {%>
                                 <td>无房型图</td>
                                    <%}
                                }%>      
                            <td title="<%= roomList[i].Rent %>"><%= roomList[i].Rent %></td>
                            <td title="<%= roomList[i].MinLease %>"><%= roomList[i].MinLease %></td>
                            <%if (roomList[i].IsRent == false)
                              {%>
                                  <td title="<%= roomList[i].IsRent %>">未出租</td>
                            <%}
                              else
                              {%>
                                  <td title="<%= roomList[i].IsRent %>">已出租</td>
                            <%} %>
                             <%if (roomList[i].RentEnd != null)
                              { %>
                            <td title="<%= roomList[i].RentEnd %>"><%=Convert.ToDateTime(roomList[i].RentEnd).ToShortDateString()%></td>
                            <%}
                              else
                              { %>
                                 <td title="<%= roomList[i].RentEnd %>"><%=roomList[i].RentEnd %></td>
                            <%} %>
							<td><input type="button" value="" 
								onclick="window.location.href='UpdateRoom.aspx?id=<%= roomList[i].ID %>&pageno=<%= pageno %>&keyword=<%=keyword %>&scope=<%=scope %>&buildName=<%=buildName %>'"
								class="updateBtn" title="编辑"/> 
                                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= roomList[i].ID %>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>&keyword=<%=keyword %>&scope=<%=scope %>&buildName=<%=buildName %>')"/>
                                <%} %>
                                <input  type="button"
								value="" class="viewBtn" title="查看"
								onclick="window.location.href='DetailInfo.aspx?id=<%= roomList[i].ID %>&pageno=<%= pageno %>&keyword=<%=keyword %>&scope=<%=scope %>&buildName=<%=buildName %>'" />
                          
						    </td>
						</tr>
				<%} %>
					<%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
       { %>
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="14" id="pageControl"></td>
					</tr> 
                    <%} %>
                </form>


                 <tr>
					<td colspan="15" valign="middle">
						<!-- markupPage -->
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
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
								<input type="text"  style="width:20px" name="pageno1" id="pageno1" value="<%= page.PageNo %>"   />
								页  <a href="javascript:testAndGotoPage(document.getElementById('pageno1').value,<%= page.PageNo %>,<%= page.PageCount %>)"><font title="GO">GO</font></a>
								</td>
								
							</tr>
						</table> 
					</td>
				</tr>

            </table>
        </div>
 


	</div>
    
  </body>

</html>
