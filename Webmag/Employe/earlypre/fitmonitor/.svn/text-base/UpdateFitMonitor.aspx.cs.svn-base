using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Model.Image;

public partial class Webmag_Employe_earlypre_fitmonitor_UpdateFitMonitor : System.Web.UI.Page
{
    public string id;
    public FitMonitorDAO fitMonitorDAO;
    public FitMonitor fitMonitor;
    public string pageno;
    public string keyword;
    public EmployeDAO employeDAO;
    public List<Employe> list;

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
            fitMonitorDAO = new FitMonitorDAO();
            employeDAO = new EmployeDAO();

            if (Request["keyword"] != null)
                keyword = Request["keyword"].Trim();

            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];

            fitMonitor = fitMonitorDAO.GetFitMonitorById(id);
            list = employeDAO.ListEmploye();
            imageList = imageDAO.GetImgAttachmentByTypeAndID(4, id);
        }
    }
}