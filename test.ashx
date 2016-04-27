<%@ WebHandler Language="C#" Class="test" %>

using System;
using System.IO;
using System.Web;


public class test : IHttpHandler {
    
    
    
    public void ProcessRequest(HttpContext context)
    {
        string imgType = "";
        context.Response.ContentType = "text/plain";
        HttpPostedFile file = context.Request.Files["FileData"];
        string uploadpath = HttpContext.Current.Server.MapPath(context.Request["folder"]) + "\\";
        if (file != null)
        {
            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }

            char[] separtor = { '.' };
            string[] spotArray = file.FileName.Split(separtor);
            for (int j = 0; j < spotArray.Length; j++)
            {
                imgType = "." + spotArray[j];
            }

            string newFileName = GetNewFileName(file.FileName);
      //      System.Random random = new Random(10);
       //     string newFileName = System.DateTime.Now.ToString().Replace("/", "").Replace("-", "").Replace(":", "").Replace(" ", "") + random.Next(10000).ToString();

            file.SaveAs(uploadpath + newFileName);
        //    file.SaveAs(uploadpath + newFileName + imgType);
            context.Response.Write(newFileName);
        }
        else
        {
            context.Response.Write("0");
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    //跟据文伯名产生一个由时间+随机数组成的一个新的文件名
    public static string GetNewFileName(string FileName)
    {
        string newfilename = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
        + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
        + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString()
        + DateTime.Now.Millisecond.ToString()
            //+ rand.Next(1000).ToString() 
        + FileName.Substring(FileName.LastIndexOf("."), FileName.Length - FileName.LastIndexOf("."));
        return newfilename;
    }


}