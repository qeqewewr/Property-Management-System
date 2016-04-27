using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Image;


public partial class Webmag_Employe_infoManage_lessee_DeletePageInfo : System.Web.UI.Page
{
    protected LesseeDAO lesseeDAO;
    protected Lessee lessee;
    protected int pageno;
    protected int size;
    protected int flag;

    protected List<ImgAttachment> imgList = new List<ImgAttachment>();
    protected ImgAttachmentDAO imgDAO = new ImgAttachmentDAO();

    protected string scope = "";
    protected string keyword = "";

    protected List<string> roomList = new List<string>();
    protected RoomDAO roomDAO = new RoomDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["scope"] != "" && Request["scope"] != null)
                scope = Request["scope"].Trim();
            if (Request["keyword"] != "" && Request["keyword"] != null)
                keyword = Request["keyword"].Trim();

            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {

                string page = Request.Form["pageno"].Trim();
                string a = Request["scope"];

                pageno = int.Parse(page);
                Response.Redirect("ViewLessee.aspx?pageno=" + pageno + "&scope=" + scope + "&keyword=" + keyword + "");
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {
                    lesseeDAO = new LesseeDAO();

                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    int id = int.Parse(Request["id"]);
                    //string ee=Request["rowcount"];
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
                    lessee=lesseeDAO.GetLesseeByID(id);
                    roomList = roomDAO.GetBuildByLessee(lessee.Name);
                    if (roomList.Count != 0)
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + lessee.Name + "仍存在租用的房间，不能删除！！');history.go(-1);</script>");
                    else
                    {
                        //flag = lesseeDAO.deleteLesseeByID(id);
                        imgList = imgDAO.GetImgAttachmentByTypeAndID(8, id.ToString());
                        for (int j = 0; j < imgList.Count; j++)
                        {
                            if (deletePic(imgList[j].ID.ToString()))
                                continue;
                            else
                            {
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('附件删除失败!');history.go(-1);</script>");
                            }

                        }

                        flag = lesseeDAO.deleteLesseeByID(id);
                        RedirectPage();
                    }

                }
                //删除多条记录
                else
                {

                    size = int.Parse(Request["size"]);
                    pageno = int.Parse(Request["page"]);

                    string ids = Request["selectDel"];
                    char[] separtor = { ',' };
                    string[] idArray = ids.Split(separtor);




                    lesseeDAO = new LesseeDAO();
                    string lesseeName = "";

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

                    for (int i = 0; i < idArray.Length; i++)
                    {
                       lessee=lesseeDAO.GetLesseeByID(int.Parse(idArray[i]));
                       roomList = roomDAO.GetBuildByLessee(lessee.Name);
                       if (roomList.Count != 0)
                           lesseeName += "  " + lessee.Name;
                    }
                    if (lesseeName != "")
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + lesseeName + "仍存在租用的房间，不能删除！！');history.go(-1);</script>");
                    else
                    {
                        for (int i = 0; i < idArray.Length; i++)
                        {
                            imgList = imgDAO.GetImgAttachmentByTypeAndID(8, idArray[i]);
                            for (int j = 0; j < imgList.Count; j++)
                            {
                                if (deletePic(imgList[j].ID.ToString()))
                                    continue;
                                else
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('附件删除失败!');history.go(-1);</script>");
                                }

                            }

                            flag = lesseeDAO.deleteLesseeByID(int.Parse(idArray[i]));

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

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewLessee.aspx?pageno=" + pageno + "&scope=" + scope + "&keyword=" + keyword + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }

    }

    private  Boolean deletePic(string id)
    {
        ImgAttachmentDAO service = new ImgAttachmentDAO();
        ImgAttachment img = service.GetImgAttachmentByID(int.Parse(id));
        //string path = HttpContext.Current.Request.ApplicationPath;
        //path = path + "/webmag/attachment/"+img.AttachUrl;
        string path = HttpContext.Current.Server.MapPath("../../../attachment")+ "\\"+img.AttachUrl;

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