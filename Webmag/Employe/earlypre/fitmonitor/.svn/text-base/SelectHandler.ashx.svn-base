<%@ WebHandler Language="C#" Class="SelectHandler" %>

using System;
using System.Web;
using CEMIS.Model.Employe.RoomInformation;
using CEMIS.BLL;
using CEMIS.Util;
using System.Collections.Generic;

public class SelectHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        RoomInfoDAO roomDAO = new RoomInfoDAO();
        context.Response.ContentType = "text/plain";
        string lessee = context.Request["zuhu"];
        string build = context.Request["lou"];
        
        if (lessee != null)
        {
            //br= 楼宇号+房间号
         //   List<string> br = roomDAO.ListBuildingNameAndRoomByLesseeName(lessee);
            List<string> br = roomDAO.ListBuildingNameByLesseeName(lessee);
            string result = "";
            for (int i = 0; i < br.Count; i++)
            {
                if (i != br.Count - 1)
                    result += br[i] + ",";
                else
                    result += br[i];
            }
                context.Response.Write(result);
        }
        
        
        if (build != null)
        {
            List<string> roomList = roomDAO.ListRoomNumberByBuildingName(build);
            string rooms = "";
            for (int i = 0; i < roomList.Count; i++)
            {
                if (i != roomList.Count - 1)
                    rooms += roomList[i] + ",";
                else
                    rooms += roomList[i];
            }
            context.Response.Write(rooms);
        }
       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}