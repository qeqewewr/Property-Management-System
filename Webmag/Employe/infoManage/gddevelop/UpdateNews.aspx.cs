using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_gddevelop_UpdateNews : System.Web.UI.Page
{
    public int id;
    public News news = new News();
    public NewsDAO newsDAO = new NewsDAO();
    public int pageno;
    public string keyword;

    public string path = "";

    public List<ImgAttachment> attachList = new List<ImgAttachment>();
    public ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = int.Parse(Request["pageno"]);

            if (Request["keyword"].Trim() != null)
                keyword = Request["keyword"].Trim();

            string a = Request["id"];
            id = int.Parse(a);

            news = newsDAO.GetNewsByID(id);

            attachList = attachDAO.GetImgAttachmentByTypeAndID(3, a);

            path = HttpContext.Current.Request.ApplicationPath;
            path = path + "/webmag/attachment/";

            imageList = imageDAO.GetImgAttachmentByTypeAndID(9, a);
        }
    }
}