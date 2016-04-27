using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_building_DetailInfo : System.Web.UI.Page
{
    public string pageno;
    public string id;

    public Building build = new Building();
    public BuildingDAO buildDAO = new BuildingDAO();

    public Employe employe = new Employe();
    public EmployeDAO employeDAO = new EmployeDAO();

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];
            id = Request["id"];

            build = buildDAO.GetBuildingByID(id);

            employe = employeDAO.GetEmployeByID(build.AdminID);

            imageList = imageDAO.GetImgAttachmentByTypeAndID(2, build.ID);
        }
    }

}