<%@ WebHandler Language="C#" Class="uploadFileHandler" %>

using System;
using System.Web;
using System.IO;
using CEMIS.Util;

public class uploadFileHandler : IHttpHandler {

  public void ProcessRequest (HttpContext context) {
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

            System.Random random = new Random(Global.GetSeed());
            string newFileName = System.DateTime.Now.ToString().Replace("/", "").Replace("-", "").Replace(":", "").Replace(" ", "") + random.Next(10000).ToString();

            file.SaveAs(uploadpath + newFileName + imgType);
            context.Response.Write(newFileName + imgType);
        }
        else
        {
            context.Response.Write("0");
        }
 
     }
  
    public bool IsReusable {
         get {
             return false;
         }
     }

}