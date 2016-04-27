using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Admin;


public partial class Webmag_Employe_infoManage_employe_ViewEmploye : System.Web.UI.Page
{
    public EmployeDAO employeDAO = new EmployeDAO();
    public List<Employe> employeList = new List<Employe>();
    public pageForm page = new pageForm();
    public string pageno;
    public bool condition;//是否查询
    public string keyword;//查询关键字
    public int status;//查询范围
    public string scope;
    public AdminDAO adminDAO = new AdminDAO(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"].Trim();

            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                scope = Request["scope"].Trim();
                if (scope == "在职")
                {
                    status = 1;
                }
                if (scope == "离职")
                {
                    status = 0;
                }
                if (scope == "全部")
                {
                    status = 2;
                }
                keyword = Request["keyword"].Trim();
                condition = true;
                page.PageSize = 10;
                employeList = employeDAO.GetEmployeByName(keyword, status, int.Parse(pageno), page.PageSize);


                page.RowCount = employeDAO.searchNum;
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
            }
            else
            {
                if (Request["scope"] == null || Request["scope"] == "")
                {
                    status = 1;
                    page.RowCount = employeDAO.GetWorkRecordNum();
                }
                else
                {
                    scope = Request["scope"].Trim();
                    if (scope == "在职")
                    {
                        page.RowCount = employeDAO.GetWorkRecordNum();
                        status = 1;
                    }
                    if (scope == "离职")
                    {
                        page.RowCount = employeDAO.GetLeaveRecordNum();
                        status = 0;
                    }
                    if (scope == "全部")
                    {
                        page.RowCount = employeDAO.GetTotalRecordNum();
                        status = 2;
                    }
                }
                condition = false;


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

                employeList = employeDAO.ListPageEmploye(page.PageNo, page.PageSize, status);
            }
        }
    }
}