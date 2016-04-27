<%@ Page Title="企业宣传" Debug="true" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master"
    AutoEventWireup="true" CodeFile="LesseeAD.aspx.cs" Inherits="LesseeAD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/LesseeAD.css" rel="Stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" href="../Webmag/CSS/webmag.css"/> 
	<script type="text/javascript" src="../Webmag/Scripts/jquery-1.4.min.js"></script>
    <script type="text/javascript" src="../Webmag/Scripts/webmag.js"></script>
    <script type="text/javascript" src="../Webmag/Scripts/markupPage.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script>
       var gotoPage = function (pagenum) {
           /*
           var el = document.createElement("input");
           el.type = "hidden";
           el.name = "pageno";
           el.value = pagenum

           document.aspnetForm.appendChild(el);
           document.aspnetForm.submit();
           */
           var url = 'LesseeAD.aspx?pageno=' + pagenum;
           window.location.href = url;
       }

   </script>
    <div class="box3">
        <div class="box3_t">
            <a href="Index.aspx">首页</a>&nbsp;»&nbsp;企业特色</div>
        <div class="box3_m">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" align="left">
                <tbody>
                
                    <tr> 
                    <%for (int i = 0; i < firmList.Count; i++)
                      { %>
                      
                        <td align="center" valign="top">                       
                            <div id="tuijian_pro_"+<%=i %> style="width: 160px;">
                                <div class="tuijian_pro_name" style="width: 160px;">
                                    <div class="tl">
                                       <a href="LesseeShow.aspx?pageno=<%=pageno %>&id=<%=firmList[i].Id %>"><center><font size="1"><%=firmList[i].Lessee%></font></center></a>
                                    </div>
                                </div>
                                <div class="tuijian_pro_img">
                                    <a href="LesseeShow.aspx?pageno=<%=pageno %>&id=<%=firmList[i].Id %>">
                                    <%if (imagelist[i] != null)
                                      { %>
                             
                                        <img width="150" height="150" border="0" src="../webmag/attachment/<%=pageBLL.GetFileName(imagelist[i].AttachUrl) %>">
                                    <%}
                                      else
                                      {%>
                                        <img width="150" height="150" border="0" src="../IndexPage/pic/nopicutre.jpg">
                                    <%} %>
                                    </a>
                                </div>
                                <div class="tuijian_pro_introduce"><center><%=firmList[i].Lessee %></center></div>
                            </div>
                        </td>
                     <%if (i % 4 == 3)
                       { %></tr><tr>
                     <%}
                     } %>
                        
                    </tr>
             
                </tbody>
            </table>
   <div class="newslist-page">
		
<div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" id="Table1" >
							 
			<tr style="border:0px;">
				<td style="border:0px;">
					<span>[总数:<%=page.RowCount %>条]</span> <span>[每页:<%= page.PageSize %>条]</span> [页次:<font title="当前第<%= page.PageNo %>页" style="color:#FF0000"><%= page.PageNo %></font>/<%= page.PageCount %>]
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
    
    </div> 
	</div>


        </div>
    </div>
   
</asp:Content>
