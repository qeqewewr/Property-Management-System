using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_officework_repairtable_UpdateRepairTable : System.Web.UI.Page
{
    public string id;
    public RepairTable repairTable;
    public RepairTableDAO repairTableDAO;
    public string pageno;
    public string endtime = "", keyword = "";
   
    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();

    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            repairTableDAO = new RepairTableDAO();

            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];

            if (Request["keyword"] != null)
                keyword = Request["keyword"].Trim();
            if (Request["endtime"] != null)
                endtime = Request["endtime"].Trim();

            repairTable = repairTableDAO.GetRepairTableById(id);
            //----------------------5555555555--------------------------
            imageList = imageDAO.GetImgAttachmentByTypeAndID(5, id);
        }
    }
}