<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectRoom.aspx.cs" Inherits="Webmag_SelectRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="System.Collections" %>

<form class="selectRooms">
<div class="builds">
<%for (int i = 0; i < Builds.Count; i++)
  { %>
<span><%=Builds[i]%></span>
<%} %>
</div>

<div class="rooms">
    <%for(int i=0;i<Rooms.Count;i++)
      { 
          %>
          <% string build = Builds[i]; %>
        <ul class="<%=build  %>">
            <% List<string> rooms = Rooms[i]; %>
            <%for (int j = 0; j < rooms.Count; j++)
              {
            
                  %>
                <li class="<%=rooms[j]%>"><input type="checkbox" name="<%=build %>" value="<%=rooms[j] %>" /><%=rooms[j] %> </li>
                
            <%} %>
        </ul>
    <%} %>
    <div style="height:0; clear:both;"></div>
</div>
<input type="button" value="" class="selectBtn" />
<input type="reset" value="重置" />
</form>