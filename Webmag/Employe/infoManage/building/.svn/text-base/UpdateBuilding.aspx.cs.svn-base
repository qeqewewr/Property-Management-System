using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_infoManage_building_UpdateBuilding : System.Web.UI.Page
{
    public Building build = new Building();
    public BuildingDAO buildDAO = new BuildingDAO();

    public DepartmentDAO departDAO = new DepartmentDAO();
    public List<Department> departlist = new List<Department>();

    public Employe employe = new Employe();
    public EmployeDAO employeDAO = new EmployeDAO();

    public ImgAttachment image = new ImgAttachment();
    public ImgAttachmentDAO imageDAO = new ImgAttachmentDAO();
    public List<ImgAttachment> imageList = new List<ImgAttachment>();

    public string id;
    public string pageno;
    public string oldid;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            id = Request["id"];
            pageno = Request["pageno"];
            build = buildDAO.GetBuildingByID(id);
            departlist = departDAO.ListDepartment();
            oldid = id;

            employe = employeDAO.GetEmployeByID(build.AdminID);

            if (employe != null)
            {
                for (int i = 0; i < departlist.Count; i++)
                {
                    if (departlist[i].Name == employe.Department)
                    {
                        Department tempdepart = departlist[i];
                        departlist.RemoveAt(i);
                        departlist.Insert(0, tempdepart);
                    }
                }
            }

            imageList = imageDAO.GetImgAttachmentByTypeAndID(2, build.ID);

        }
    }
}