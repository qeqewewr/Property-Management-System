using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_lessee_DetailInfo : System.Web.UI.Page
{
    public int id;
    public LesseeDAO lesseeDAO;
    public Lessee lessee;
    public string pageno;
    public string keyword;
    public string scope;

    public string path;

    public List<ImgAttachment> attachList = new List<ImgAttachment>();
    public ImgAttachmentDAO attachDAO = new ImgAttachmentDAO();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            lesseeDAO = new LesseeDAO();

            id = int.Parse(Request["id"].ToString());
            pageno = Request["pageno"];
            if (Request["keyword"].Trim() != null)
                keyword = Request["keyword"].Trim();
            if (Request["scope"].Trim() != null)
                scope = Request["scope"].Trim();

            lessee = lesseeDAO.GetLesseeByID(id);

            attachList = attachDAO.GetImgAttachmentByTypeAndID(8, id.ToString());

            path = HttpContext.Current.Request.ApplicationPath;
            path = path + "/webmag/attachment/";
        }
    }
}