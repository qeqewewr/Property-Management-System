using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Admin;

public partial class Webmag_Employe_infoManage_building_ViewBuilding : System.Web.UI.Page
{
    public List<Building> buildList;
    public BuildingDAO buildDAO;
    public pageForm page = new pageForm();
    public string pageno;

    public AdminDAO adminDAO = new AdminDAO();

	public EmployeDAO employeDAO = new EmployeDAO();
    public Employe employe = new Employe();
	
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            buildDAO = new BuildingDAO();
            pageno = Request["pageno"].Trim();



            page.RowCount = buildDAO.GetTotalRecordNum();
            page.PageSize = 10; //每页的条数
            page.PageNo = int.Parse(pageno);
            int a = page.RowCount % page.PageSize;
            if (a == 0)
            {
                if (page.RowCount == 0)
                    page.PageCount = 1;
                else
                    page.PageCount = page.RowCount / page.PageSize;
            }
            else
                page.PageCount = page.RowCount / page.PageSize + 1;

            buildList = new List<Building>();
            buildList = buildDAO.ListPageBuilding(page.PageNo, page.PageSize);
        }
    }
}