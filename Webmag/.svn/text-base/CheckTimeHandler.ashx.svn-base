<%@ WebHandler Language="C#" Class="CheckTimeHandler" %>

using System;
using System.Web;
using System.Collections.Generic;
using CEMIS.Model.Employe;
using CEMIS.BLL;
using CEMIS.Util;

public class CheckTimeHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       
       
        context.Response.ContentType = "text/plain";
        string result = "";
        string t = context.Request["t"];
        bool flag = CheckTime(t);
        if (!flag)
        {
            result = "预约时间有冲突，请您换个预约时间!";
        }
        else
        {
            result = "预约时间没有冲突，您可预约!";
        }
        context.Response.Write(result);
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

    public bool CheckTime(string t)
    {
        OrderMoveInDAO orderMoveInDAO = new OrderMoveInDAO();
        List<DateTime> list = new List<DateTime>();
        DateTime r;
        bool flag = true;
        list = orderMoveInDAO.GetDateTimeList();
       
       
        DateTime.TryParse(t, out r);

        for (int i = 0; i < list.Count; i++)
        {
            if (r.Year == list[i].Year) 
            {
                if(r.Month == list[i].Month) 
                {
                    if (r.Day == list[i].Day)
                    {
                      if ((r.Hour >=list[i].Hour && r.Hour <=list[i].Hour + 1))
                         flag = false;
                    }
                }
            }
         
        }
            return flag;
    }
}