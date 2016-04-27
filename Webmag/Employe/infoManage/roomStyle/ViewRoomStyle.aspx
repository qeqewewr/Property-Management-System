<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewRoomStyle.aspx.cs" Inherits="Webmag_Employe_infoManage_roomStyle_ViewRoomStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    
        
        <div>
        
			<table class="resultTable" >

				<caption style="text-align: left" >
					&nbsp;&nbsp;&nbsp;&nbsp;房型图信息列表：
                    <span align="right"><input
						type="button" value="" class="addBtn" title="添加"
						onclick="window.location.href='AddRoomStyle.aspx'"/>
			        </span>
				</caption>

                <tbody>
				<tr class="topTitle" align="center">
                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                  { %>
					<td align="center">选 择</td>
                    <%} %>
					<td align="center">编号</td>
					<td align="center">名称</td>
                    <td align="center">图片</td>
					<td align="center" colspan="3">操 作</td>
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 

                <%for (int i = 0; i < roomStyleList.Count; i++)
                  { %>
				
				        <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
                            <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
							<td><input type="checkbox" name="selectDel"
								value="<%=roomStyleList[i].ID %>" onclick="isAllSelected(this,'sltAll','0')" />
							</td> 
                            <%} %>
							<td title="<%= (i+1)%>" align="left"><%= (i+1)%></td>
                            <td title="<%= roomStyleList[i].Name %>"><%= roomStyleList[i].Name%></td>
                            <%imageList = imageDAO.GetImgAttachmentByTypeAndID(1, roomStyleList[i].ID.ToString());
                              if (imageList.Count!=0)
                              { %>                          
                                     <td title="点击查看图片"><a rel = "facebox" href="ImagePhoto.aspx?id=<%=roomStyleList[i].ID %>">点击查看图片</a></td>  
                                      
							<%}
                              else
                              {%>
                               <td>无图片</td>
                            <%} %>

							<td><input type="button" value="" 
								onclick="window.location.href='UpdateRoomStyle.aspx?id=<%= roomStyleList[i].ID%>&pageno=<%= pageno %>'"
								class="updateBtn" title="编辑"/> 
                                <%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
                                  { %>
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= roomStyleList[i].ID %>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>')"/>
                                <%} %>
                                <input type="button"
								value="" class="viewBtn" title="查看"
								onclick="window.location.href='DetailInfo.aspx?id=<%= roomStyleList[i].ID%>&pageno=<%= pageno %>'"/>
						    </td>
						</tr>
				<%} %>
					<%if (adminDAO.GetAdmin(Session["UserName"].ToString()))
       { %>
					<tr>	
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"/> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />
                               
						</td>
						<td colspan="5" id="pageControl"></td>
					</tr> 
                    <%} %>
                </form>


                 <tr>
					<td colspan="6" valign="middle">
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
               </tbody>
            </table>

        </div>


	</div>
</body>
</html>
