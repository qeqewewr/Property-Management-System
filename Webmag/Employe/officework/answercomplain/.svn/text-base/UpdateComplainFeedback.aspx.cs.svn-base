using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Image;

public partial class Webmag_Employe_officework_answercomplain_UpdateComplainFeedback : System.Web.UI.Page
{
    public string id;
    public ComplainFeedback complainFeedback;
    public ComplainFeedbackDAO complainFeedbackDAO;
    public string pageno;

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();
    public string action;
    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            complainFeedbackDAO = new ComplainFeedbackDAO();
            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];
            action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
            

            complainFeedback = complainFeedbackDAO.GetComplainFeedbackById(id);
            imageList = imageDAO.GetImgAttachmentByTypeAndID(6, id);
        }
    }
}