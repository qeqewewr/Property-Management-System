using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_gddevelop_SaveNewsInfo : System.Web.UI.Page
{
    public News news = new News();
    public NewsDAO newsDAO = new NewsDAO();

    private List<ImgAttachment> img = new List<ImgAttachment>();
    private ImgAttachmentDAO imgDAO = new ImgAttachmentDAO();

    private ImgAttachment attach = new ImgAttachment();
    private ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    public string title;
    public string body;
    public string lunbo = "0";
    public DateTime publishTime;

    private int m;
    private int flag;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;

            title = Request.Form["newsTitle"].Trim();
            body = Request.Form["newsBody"].Trim();
            publishTime = new DateTime();
            if (Request.Form["lunbo"] != null && Request.Form["lunbo"].ToString().Trim() == "1")
            {
                lunbo = "1";
            }


            news = new News();
            news.Title = title;
            news.Body = body;
            news.PublishTime = DateTime.Now;
            news.LunBo = lunbo;
            flag = newsDAO.AddNews(news);

            //string uploadpath = "E:\\光大物业\\实验\\CEMIS\\Webmag\\attachment\\";
            //string uploadpath = "../../../attachment/";
            string args = Request["ufile"];
            if (args != null&&flag>0)
            {
                char[] sep = { ',' };
                string[] fileArray = args.Split(sep);
                for (int i = 0; i < fileArray.Length; i++)
                {

                    char[] c = { '#' };
                    string fileNameArray = (fileArray[i].Split(c))[1];
                    ImgAttachment imgAttach = new ImgAttachment();
                    imgAttach.AttachName = fileNameArray;
                    imgAttach.AddDate = DateTime.Now;
                    //imgAttach.AttachUrl = uploadpath + fileArray[i].Split(c)[1];
                    imgAttach.AttachUrl = fileArray[i].Split(c)[1];
                    imgAttach.AttachType = 3; //光大动态附件
                    if (flag >= 0)
                    {
                        imgAttach.ModuleID = flag.ToString();
                        //m = imgService.Add(imgAttach);
                        m = imgDAO.AddImgAttachment(imgAttach);

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                    }
                }

                string lname = "";
                try
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile file = Request.Files[i];
                        string type = System.IO.Path.GetExtension(file.FileName);
                        char[] c = { '\\' };
                        string[] nameArray = file.FileName.Split(c);
                        for (int j = 0; j < nameArray.Length; j++)
                        {
                            lname = nameArray[j];
                        }
                        string singlefilename = lname.Substring(0, lname.LastIndexOf('.')) + DateTime.Now.ToString("yyyy-mm-dd-yhh-mm-ss") + type;
                        file.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename);
                        attach = new ImgAttachment();
                        attach.AddDate = DateTime.Now;
                        attach.AttachName = file.FileName;
                        attach.AttachType = 9;
                        //attach.AttachUrl = System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename;
                        attach.AttachUrl = "../../../attachment/" + singlefilename;
                        attach.ModuleID = flag.ToString();

                        attachDAO.AddImgAttachment(attach);
                    }
                    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddNews.aspx');</script>");
                }
                catch (System.Exception Ex)
                {
                    Console.Write(Ex.Message);
                }

                if (m > 0)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddNews.aspx');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('附件保存失败!');location.href=('updateCleaner.aspx?id=flag&pageno=1');</script>");

                }
            }

            
            else
            {
                if (flag > 0)
                {
                    string lname = "";
                    try
                    {
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            HttpPostedFile file = Request.Files[i];
                            string type = System.IO.Path.GetExtension(file.FileName);
                            char[] c = { '\\' };
                            string[] nameArray = file.FileName.Split(c);
                            for (int j = 0; j < nameArray.Length; j++)
                            {
                                lname = nameArray[j];
                            }
                            string singlefilename = lname.Substring(0, lname.LastIndexOf('.')) + DateTime.Now.ToString("yyyy-mm-dd-yhh-mm-ss") + type;
                            file.SaveAs(System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename);
                            attach = new ImgAttachment();
                            attach.AddDate = DateTime.Now;
                            attach.AttachName = file.FileName;
                            attach.AttachType = 9;
                            //attach.AttachUrl = System.Web.HttpContext.Current.Request.MapPath("../../../attachment/") + singlefilename;
                            attach.AttachUrl = "../../../attachment/" + singlefilename;
                            attach.ModuleID = flag.ToString();

                            attachDAO.AddImgAttachment(attach);
                        }
                        //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddNews.aspx');</script>");
                    }
                    catch (System.Exception Ex)
                    {
                        Console.Write(Ex.Message);
                    }

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddNews.aspx');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");
                }
            }
        }

        ////int flag = newsDAO.AddNews(news);
        //if (flag > 0)
        //{

        //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存成功!');location.href=('AddNews.aspx');</script>");
        //}
        //else
        //{
        //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('保存失败!');history.go(-1);</script>");

        //}



    }
}