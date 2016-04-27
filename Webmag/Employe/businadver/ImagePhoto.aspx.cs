using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.Model.Image;

public partial class Webmag_Employe_businadver_ImagePhoto : System.Web.UI.Page
{

    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public string id;
    public string role = "";
    public PageBLL pageBLL = new PageBLL();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            id = Request["id"];
            imageList = new List<ImgAttachment>();
            imageList = imageDAO.GetImgAttachmentByTypeAndID(7, id);
        }
    }
}