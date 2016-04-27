using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_roomStyle_UpdateRoomStyle : System.Web.UI.Page
{
    public RoomStyle roomStyle = new RoomStyle();
    public RoomStyleDAO roomStyleDAO = new RoomStyleDAO();

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();

    public string pageno;
    public int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            id = int.Parse(Request["id"]);

            roomStyle = roomStyleDAO.GetRoomStyleByID(id);

            imageList = imageDAO.GetImgAttachmentByTypeAndID(1, roomStyle.ID.ToString());
        }
    }
}