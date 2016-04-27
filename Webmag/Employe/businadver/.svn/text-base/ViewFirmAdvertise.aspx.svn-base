<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFirmAdvertise.aspx.cs" Inherits="Webmag_Employe_businadver_ViewFirmAdvertise" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    <meta http-equiv="pragma" content="no-cache"/>
	<meta http-equiv="cache-control" content="no-cache"/>
	<meta http-equiv="expires" content="0"/>    
	<link rel="stylesheet" type="text/css" href="../../Scripts/facebox/facebox.css"/>
	<link rel="stylesheet" type="text/css" href="../../CSS/webmag.css"/> 
	<script type="text/javascript" src="../../Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../../Scripts/markupPage.js"></script>
    <script type="text/javascript" src="../../Scripts/webmag.js"></script>
    <script type="text/javascript" src="../../Scripts/facebox/facebox.js"></script>
    <script type="text/javascript" src="../../Scripts/slide/js/jquery.anythingslider.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Scripts/slide/css/anythingslider.css"/>
      <script type="text/javascript">
          function changeAction() {
              $("#action").val("search");
              $("#keyword").val($("#lesseeName").val());
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
          <% if (role == "property")
             {%>
          <div class="queryArea"  style="width:100%">
            <form action="ViewFirmAdvertise.aspx?pageno=1" name="searchForm"
				id="searchForm" method="post">
                <input type="hidden" name="keyword" id="keyword" value="" />
                <input type="hidden" name="condition" id="condition" value="<%= condition %>" />

				<fieldset>
					<legend style="color: #006699;"> 企业宣传信息查询  </legend> 
					<span>租户名称：<input type="text" name="lesseeName" id="lesseeName" title="请输入名称"
						<%if (condition){%> value="<%=keyword %>"<%}else{ %>value=""<%} %> 
						size="30" class="inputText"
						onfocus="$(this).css('border-color','#ff0000')"
						onblur="$(this).css('border-color','#006699')" /> &nbsp;&nbsp;<input id="search"
						type="submit" value=" " class="queryBtn" title="查询" onclick="changeAction()" /> </span>
				</fieldset>
                
			</form>
        </div>
        <%} %>
			<table class="resultTable">

				<caption style="text-align: left">
					&nbsp;&nbsp;&nbsp;企业宣传信息列表：&nbsp;&nbsp;
                    
                <span align="right">
                <input
						type="button" value="" class="addBtn" title="添加"
						onClick="window.location.href='AddFirmAdvertise.aspx'">
			        </span>
				</caption>     

				<tr class="topTitle" align="center">
                <%if (role == "property")
                  {%>
					<td align="center">选 择</td>
                    <%} %>
					<td align="center">租户</td>
					<td align="center">图片</td>
                    <td align="center">描述</td>
					<td align="center"><font color="red">是否确认</font></td>
                    <td align="center">建议 </td>
                   
					<td align="center" colspan="2">操 作</td>
                   
				</tr> 

              <form name="pageControlForm" action="DeletePageInfo.aspx?page=<%= pageno %>&size=<%= page.PageSize %>&rowcount=<%=page.RowCount%>" method="post"
				 id="pageControlForm" onsubmit="return checkDeleteSubmit('pageControlForm');"> 
                 <input type="hidden" name="keyword"  value="<%= keyword %>" />
                
                


                <%for (int i = 0; i < firmAdvertiseList.Count; i++)
                  {
                      %>
                    
				          <tr onMouseOver="this.style.backgroundColor='#f3f3f3';return true;"
							onMouseOut="this.style.backgroundColor='';">
							<%if (role == "property")
                             {%>
                            <td>
                            <input type="checkbox" name="selectDel"
								value="<%=firmAdvertiseList[i].Id %>" onclick="isAllSelected(this,'sltAll','1')" />
							</td> 
                             <%} %>
                            <td title="<%= firmAdvertiseList[i].Lessee %>" align="left"><%= firmAdvertiseList[i].Lessee%></td> 
							 <%
                                 int  flag = imageDAO.HasImgAttachmentByTypeAndID(7, firmAdvertiseList[i].Id.ToString());
                                if (flag != 0)
                                {
                                    //string newFileName = pageBLL.GetFileName(imageList[0].AttachUrl);
                                              %>
                                            <!--<td title="点击查看图片"><a rel = "facebox" href="../../attachment/newFileName ">点击查看图片</a></td>          -->           
							                <td title="点击查看图片"><a rel = "facebox" href="ImagePhoto.aspx?id=<%=firmAdvertiseList[i].Id %>">点击查看图片</a></td>   
                                            <%}
                                else
                                {%>
                                 <td>无图片</td>
                               <%} %>
                            <td title="<%= pageBLL.GetShrotInfo() %>"><a rel="facebox" href="facebox.aspx?id=<%=firmAdvertiseList[i].Id %>">点击查看详情</a></td> 
                            <td title="<%= firmAdvertiseList[i].IsSure %>"><%=pageBLL.TransformBooleanToChinese(firmAdvertiseList[i].IsSure)%></td> 
                            <td title="<%= firmAdvertiseList[i].Remarks %>"><%=firmAdvertiseList[i].Remarks%></td> 
                            
                            <td>
                            <input type="button" value="" 
								onclick="window.location.href='UpdateFirmAdvertise.aspx?id=<%= firmAdvertiseList[i].Id%>&pageno=<%= pageno %>'"
								class="updateBtn" title="编辑"> 
                                <input type="button"
								value="" class="deleteBtn" title="删除"
								onclick="checkDeleteSingleItem('DeletePageInfo.aspx?id=<%= firmAdvertiseList[i].Id%>&pageno=<%= pageno %>&pagesize=<%=page.PageSize %>&rowcount=<%=page.RowCount %>')">
                            </td>
                             
						</tr>
				  <%  
                  }//for %>
					
         

                 <%if (role == "property")
                       {%>
					<tr>	
                       
						<td> 
							<input type="checkbox" id="sltAll" title="全选" alt="全选" name="sltAll"
								onclick="selectAll('pageControlForm','selectDel','sltAll')"> <input
								type="submit" class="deleteBtn" value="" title="删除全选"  />   
						</td>
						<td colspan="6" id="pageControl">&nbsp;</td>
                        
					</tr> 
                      <%} %>
                </form>


               
                    <tr>
					<td colspan="7" valign="middle">
						<!-- markupPage -->
						<table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
							<tr style="border:0px;">
								<td style="border:0px;">
									<span>[总数:<%=page.RowCount%>条]</span> <span>[每页:<%= page.PageSize%>条]</span> [页次:<span title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo%></span>/<%= page.PageCount%>]
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
								<td style="width:15px;"></td> 
							</tr>
						</table> 
					</td>
				</tr>
            
               </table>


	</div>


            
          
</body>
</html>
