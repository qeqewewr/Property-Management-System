using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_roomStyle_ImagePhoto : System.Web.UI.Page
{
    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"];
            imageList = imageDAO.GetImgAttachmentByTypeAndID(1, id);
        }
    }
}