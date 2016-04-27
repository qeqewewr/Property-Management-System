<%@ Page Title="首页" Language="C#" MasterPageFile="~/IndexPage/master/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Master_Index" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" src="scripts/slide.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="present">
        <!--<img src="pic/indexpic.jpg" width="660" height="500" />  -->
        <div id="two_frame">
         

             <div class="f_l">
          
                <!--首页新闻  begin--> <%--动态新闻--%>
                <div class="box2 slide">
                    <ul>
                    <%for (int i = 0; i < imageList.Count&&i<4; i++)
                      { %>
                        <li><a href="ShowNews.aspx?id=<%= newsImageList[i].ID %>&pageno=1">
                            <img alt="" src="<%=path+urls[i] %>" width="320" height="230" /></a></li>
                   <%} %>
                   
                    </ul>
                    <div class="focus_opacity">
                    </div> 
                  
                </div>
                <!--首页新闻  end-->
            </div>


            <div class="f_r" style="margin-right:15px;">
                <!--关于我们  begin-->
                <div class="box22">
                    <div class="box22_t">
                        <div class="more">
                            <a href="NewsList.aspx?pageno=1">更多&nbsp;»</a></div>
                        <span>XX动态</span></div>
                    <div class="box22_m">
                        <!-- start news-->
                        <ul id="newslist0">
                        <%for (int i = 0; i < newsList.Count&&i<7; i++)
                          { %>
                            <li>
                                <div class="time">
                                    (<%=((DateTime)newsList[i].PublishTime).ToShortDateString()%>)
                                </div>
                                <a href="ShowNews.aspx?id=<%=newsList[i].ID %>&pageno=1" title="<%=newsList[i].Title %>">
                                <%if (newsList[i].Title.Length >= 15)
                                  { %><%=newsList[i].Title.Substring(0, 15)%>...
                                <%}
                                  else
                                  { %><%=newsList[i].Title%>
                                <%} %></a> </li>
                            
                        <%} %>
                                
                        </ul>
                    </div>
                </div>
                <!--关于我们  end-->
            </div>
        </div>
        <div class="clear" style="height:20px;">
        </div>
        <div class="box2">
            <div class="box2_t">
                <div class="more">
                    <a href="LesseeAD.aspx?pageno=1">更多&nbsp;»</a></div>
                <span>企业特色</span></div>
                <div style="height:2px;"></div>
            <!--推荐  begin-->
            <div>
                <table align="left" width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
               <%--         <%for(int i=0;i<firmAdvertiseList.Count&&i<4;i++)
                          { %>
                            <td align="center" valign="top">
                                <div style="width: 160px;" id="tuijian_pro_"+<%= i%>+">
                                    <div style="width: 160px;" class="tuijian_pro_name">
                                        <div class="tl">
                                            <a href="LesseeShow.aspx?pageno=<%=pageno %>&id=<%=firmAdvertiseList[i].Id %>">某某公司一 </a>
                                        </div>
                                    </div>
                                    <div class="tuijian_pro_img">
                                        <a href="productshow.asp?id=357&amp;bid=8&amp;sid=0">
                                            <img width="150" height="150" border="0" src="pic/second/08.jpg"></a>
                                    </div>
                                </div>
                            </td>
                        <%} %>--%>
                         <% for (int i = 0; i < firmImageList.Count && i < 4; i++)
                            { %>
                          
                             <td align="center" valign="top">
                                <div style="width: 160px;" id="tuijian_pro_"+<%= i%>+">
                                    <div style="width: 160px;" class="tuijian_pro_name">
                                        <div class="tl">
                                            <a href="LesseeShow.aspx?pageno=<%=pageno %>&id=<%=firmAdvertiseList[i].Id %>"><%=firmAdvertiseList[i].Lessee%></a>
                                        </div>
                                    </div>
                                    <div class="tuijian_pro_img">
                                       <a href="LesseeShow.aspx?pageno=<%=pageno %>&id=<%=firmAdvertiseList[i].Id %>">
                                           <%if (firmImageList[i] != null)
                                      { %>
                             
                                        <img width="150" height="150" border="0" src="../webmag/attachment/<%=pageBLL.GetFileName(firmImageList[i].AttachUrl) %>">
                                    <%}
                                      else
                                      {%>
                                        <img width="150" height="150" border="0" src="../IndexPage/pic/nopicutre.jpg">
                                    <%} %>
                                            </a>
                                    </div>
                                </div>
                            </td>
                            <%} %>
                             <!--
                            <td align="center" valign="top">
                                <div style="width: 160px;" id="tuijian_pro_1">
                                    <div style="width: 160px;" class="tuijian_pro_name">
                                        <div class="tl">
                                            <a href="productshow.asp?id=356&amp;bid=7&amp;sid=0">某某公司一  </a>
                                        </div>
                                    </div>
                                    <div class="tuijian_pro_img">
                                        <a href="productshow.asp?id=356&amp;bid=7&amp;sid=0">
                                            <img width="150" height="150" border="0" src="pic/second/07.jpg"></a>
                                    </div>
                                </div>
                            </td>
                           
                            <td align="center" valign="top">
                                <div style="width: 160px;" id="tuijian_pro_1">
                                    <div style="width: 160px;" class="tuijian_pro_name">
                                        <div class="tl">
                                            <a href="productshow.asp?id=355&amp;bid=6&amp;sid=0">某某公司一  </a>
                                        </div>
                                    </div>
                                    <div class="tuijian_pro_img">
                                        <a href="productshow.asp?id=355&amp;bid=6&amp;sid=0">
                                            <img width="150" height="150" border="0" src="pic/second/06.jpg"></a>
                                    </div>
                                </div>
                            </td>
                            <td align="center" valign="top">
                                <div style="width: 160px;" id="tuijian_pro_1">
                                    <div style="width: 160px;" class="tuijian_pro_name">
                                        <div class="tl">
                                            <a href="productshow.asp?id=354&amp;bid=5&amp;sid=0">某某公司一  </a>
                                        </div>
                                    </div>
                                    <div class="tuijian_pro_img">
                                        <a href="productshow.asp?id=354&amp;bid=5&amp;sid=0">
                                            <img width="150" height="150" border="0" src="pic/second/05.jpg"></a>
                                    </div>
                                </div>
                            </td>
                            -->
                        </tr>
                
                    </tbody>
                </table>
            </div>
            <!--推荐  end-->
        </div>
    </div>
</asp:Content>
