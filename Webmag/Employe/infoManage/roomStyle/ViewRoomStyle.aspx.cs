using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Image;
using CEMIS.Model.Admin;

public partial class Webmag_Employe_infoManage_roomStyle_ViewRoomStyle : System.Web.UI.Page
{
    public string pageno;
    public pageForm page = new pageForm();
    public List<RoomStyle> roomStyleList = new List<RoomStyle>();
    public RoomStyleDAO roomStyleDAO = new RoomStyleDAO();

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList;
    public AdminDAO adminDAO = new AdminDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"].Trim();

            page.RowCount = roomStyleDAO.GetTotalRecordNum();
            page.PageSize = 10; //每页的条数
            page.PageNo = int.Parse(pageno);
            int a = page.RowCount % page.PageSize;
            if (a == 0)
            {
                if (page.RowCount == 0)
                    page.PageCount = 1;
                else
                    page.PageCount = page.RowCount / page.PageSize;
            }
            else
                page.PageCount = page.RowCount / page.PageSize + 1;

            roomStyleList = roomStyleDAO.ListPageRoomStyle(page.PageNo, page.PageSize);
        }
    }
}