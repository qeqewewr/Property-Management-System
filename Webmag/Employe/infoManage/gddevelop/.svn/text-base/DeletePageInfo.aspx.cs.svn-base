using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_gddevelop_DeletePageInfo : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    protected int flag;
    protected string keyword = "";

    protected NewsDAO newsDAO;

    protected News news;

    protected List<ImgAttachment> imgList = new List<ImgAttachment>();
    protected ImgAttachmentDAO imgDAO = new ImgAttachmentDAO();

    protected ImgAttachment image = new ImgAttachment();
    protected ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    protected List<ImgAttachment> imageList = new List<ImgAttachment>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            if (Request["keyword"] != "" && Request["keyword"] != null)
                keyword = Request["keyword"].Trim();

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {

                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);

                Response.Redirect("ViewNews.aspx?pageno=" + pageno + "&keyword=" + keyword + "");
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {
                    newsDAO = new NewsDAO();

                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    int id = int.Parse(Request["id"]);
                    news = newsDAO.GetNewsByID(id);
                    if (news.LunBo == "1")
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('该新闻的图片将显示在首页，不能删除!');history.go(-1);</script>");
                    else
                    {
                        //总页数的计算
                        int rowcount = int.Parse(Request["rowcount"]);

                        int a = rowcount % pagesize;
                        int pagecount;

                        if (a == 0)
                        {
                            if (rowcount == 0)
                                pagecount = 1;
                            else
                                pagecount = rowcount / pagesize;
                        }
                        else
                            pagecount = rowcount / pagesize + 1;
                        //当删除的是最后一页，且最后一页只有一个数据
                        if (pagecount == pageno && a == 1)
                        {
                            if (pageno != 1)
                                pageno--;
                        }

                        imgList = imgDAO.GetImgAttachmentByTypeAndID(3, id.ToString());
                        for (int j = 0; j < imgList.Count; j++)
                        {
                            if (deletePic(imgList[j].ID.ToString()))
                                continue;
                            else
                            {
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('附件删除失败!');history.go(-1);</script>");
                            }

                        }

                        imageList = imageDAO.GetImgAttachmentByTypeAndID(9, id.ToString());
                        if (imageList.Count == 0)
                            flag = 1;
                        for (int i = 0; i < imageList.Count; i++)
                        {
                            flag = imageDAO.deleteImgAttachmentByID(imageList[i].ID);
                            //System.IO.File.Delete(imageList[i].AttachUrl);
                            System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[i].AttachUrl));
                            if (flag < 0)
                                break;
                        }
                        if (flag > 0)
                        {

                            flag = newsDAO.deleteNewsByID(id);
                        }
                        RedirectPage();
                    }

                }
                //删除多条记录
                else
                {

                    size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);
                    //获得当前页的ID序列
                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    string[] idArray = ids.Split(separtor);




                    newsDAO = new NewsDAO();


                    //计算总页数
                    int pagecount, a;
                    int rowcount = int.Parse(Request["rowcount"]);
                    a = rowcount % size;
                    if (a == 0)
                    {
                        if (rowcount == 0)
                            pagecount = 1;
                        else
                            pagecount = rowcount / size;
                    }
                    else
                        pagecount = rowcount / size + 1;

                    //判断是否是最后一页,且全部删除
                    if (pagecount == pageno && (idArray.Length == a || idArray.Length == size))
                    {
                        if (pageno != 1)
                            pageno--;
                    }
                    string info = "";
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        news = newsDAO.GetNewsByID(int.Parse(idArray[i]));

                        if (news.LunBo == "1")
                            info += "  " + news.Title;
                    }
                    if (info != "")
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + info + "新闻的图片将显示在首页，不能删除!');location.href=('ViewDepartment.aspx?pageno=" + pageno + "');</script>");
                    else
                    {
                        for (int i = 0; i < idArray.Length; i++)
                        {
                            imgList = imgDAO.GetImgAttachmentByTypeAndID(3, idArray[i]);
                            for (int j = 0; j < imgList.Count; j++)
                            {
                                if (deletePic(imgList[j].ID.ToString()))
                                    continue;
                                else
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('附件删除失败!');history.go(-1);</script>");
                                }

                            }

                            for (int j = 0; j < imageList.Count; j++)
                            {
                                flag = imageDAO.deleteImgAttachmentByID(imageList[j].ID);
                                System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[j].AttachUrl));
                                //System.IO.File.Delete(imageList[j].AttachUrl);
                                if (flag <= 0)
                                    break;
                            }

                            if (flag < 0)
                                break;

                            flag = newsDAO.deleteNewsByID(int.Parse(idArray[i]));
                            //flag=newsDAO.deleteNews(newslist[i].Name);
                            if (flag <= 0)
                                break;

                        }

                        RedirectPage();
                    }
                }
            }
        }
    }


    private void RedirectPage()
    {

        if (flag > 0)
        {

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewNews.aspx?pageno=" + pageno + "&keyword="+keyword+"');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }

    }

    private Boolean deletePic(string id)
    {
        ImgAttachmentDAO service = new ImgAttachmentDAO();
        ImgAttachment img = service.GetImgAttachmentByID(int.Parse(id));
        //string path = HttpContext.Current.Request.ApplicationPath;
        //path = path + "/webmag/attachment/"+img.AttachUrl;
        string path = HttpContext.Current.Server.MapPath("../../../attachment") + "\\" + img.AttachUrl;

        //System.IO.File.Delete(path);
        try
        {
            System.IO.File.Delete(path);
        }
        catch
        {

        }
        int flag = service.deleteImgAttachmentByID(int.Parse(id));
        if (flag > 0)
            return true;
        else
            return false;
    }
}