<%@ WebHandler Language="C#" Class="deleteFileHandler" %>

using System;
using System.Web;
using CEMIS.Model.Image;

public class deleteFileHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        if (HttpContext.Current.Request["attid"] != null)
        {
            string attchID = HttpContext.Current.Request["attid"];

            ImgAttachmentDAO service = new ImgAttachmentDAO();
            ImgAttachment img = service.GetImgAttachmentByID(int.Parse(attchID));
            string path = img.AttachUrl;
            //System.IO.File.Delete(path);
            try
            {
                System.IO.File.Delete(path);
            }
            catch
            {

            }
            int  flag = service.deleteImgAttachmentByID(int.Parse(attchID));
            
            

        }
        else 
        {
            string url = HttpContext.Current.Request["url"];
            string path = HttpContext.Current.Server.MapPath(context.Request["folder"]) + "\\attachment\\" + url;
            try
            {
                System.IO.File.Delete(path);
            }
            catch
            {
                 
            }
            
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}