using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;


public partial class Webmag_Employe_infoManage_roomStyle_DeletePageInfo : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    protected int flag;
    protected RoomStyle roomStyle = new RoomStyle();
    protected RoomStyleDAO roomStyleDAO = new RoomStyleDAO();

    protected RoomDAO roomDAO = new RoomDAO();

    protected ImgAttachment image = new ImgAttachment();
    protected ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    protected List<ImgAttachment> imageList = new List<ImgAttachment>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            //进行页面跳转
            if (Request.Form["pageno"] != null)
            {
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                Response.Redirect("ViewRoomStyle.aspx?pageno=" + pageno + "");
            }
            else
            {
                //删除单条记录
                if (Request["id"] != null)
                {
                    roomStyleDAO = new RoomStyleDAO();

                    int pagesize = int.Parse(Request["pagesize"]);
                    pageno = int.Parse(Request["pageno"]);
                    string id = Request["id"];
                    roomStyle = roomStyleDAO.GetRoomStyleByID(int.Parse(id));
                    if (roomDAO.IsExistRoomStyle(roomStyle.Name))
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('"+roomStyle.Name+"正使用在房间信息中，不能删除!');history.go(-1);</script>");
                    else
                    {
                        imageList = imageDAO.GetImgAttachmentByTypeAndID(1, id);
                        if (imageList.Count == 0)
                            flag = 1;
                        for (int i = 0; i < imageList.Count; i++)
                        {
                            flag = imageDAO.deleteImgAttachmentByID(imageList[i].ID);
                            //System.IO.File.Delete(imageList[i].AttachUrl);
                            System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[i].AttachUrl));
                            if (flag <= 0)
                                break;
                        }
                        if (flag > 0)
                        {
                            //总页数的计算
                            int rowcount = roomStyleDAO.GetTotalRecordNum();

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

                            flag = roomStyleDAO.deleteRoomStyle(int.Parse(id));
                        }
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




                    roomStyleDAO = new RoomStyleDAO();


                    //计算总页数
                    int pagecount, a;
                    int rowcount = roomStyleDAO.GetTotalRecordNum();
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
                        roomStyle = roomStyleDAO.GetRoomStyleByID(int.Parse(idArray[i]));
                        if(roomDAO.IsExistRoomStyle(roomStyle.Name))
                            info += " " + roomStyle.Name;
                    }
                    if (info != "")
                        Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('" + info + "正使用在房间信息中，不能删除！！');history.go(-1);</script>");
                    else
                    {
                        for (int i = 0; i < idArray.Length; i++)
                        {
                            flag = 1;
                            imageList = imageDAO.GetImgAttachmentByTypeAndID(1, idArray[i]);

                            for (int j = 0; j < imageList.Count; j++)
                            {
                                flag = imageDAO.deleteImgAttachmentByID(imageList[j].ID);
                                System.IO.File.Delete(HttpContext.Current.Request.MapPath(imageList[j].AttachUrl));
                                //System.IO.File.Delete(imageList[j].AttachUrl);
                                if (flag <= 0)
                                    break;
                            }

                            if (flag <= 0)
                                break;


                            flag = roomStyleDAO.deleteRoomStyle(int.Parse(idArray[i]));

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

            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewRoomStyle.aspx?pageno=" + pageno + "');</script>");
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

        }

    }


}