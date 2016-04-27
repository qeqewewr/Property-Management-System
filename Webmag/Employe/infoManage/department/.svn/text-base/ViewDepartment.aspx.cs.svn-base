using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Admin;

public partial class BLL_informang_departmang_ViewDepartment : System.Web.UI.Page
{
    public DepartmentDAO departDAO=new DepartmentDAO ();
    public List<Department> departList=new List<Department> ();
    public pageForm page = new pageForm();
    public string pageno;

    public AdminDAO adminDAO = new AdminDAO(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = Request["pageno"];

            page.RowCount = departDAO.GetTotalRecordNum();
            page.PageSize = 10;
            page.PageNo = int.Parse(pageno);

            //确定总的页面数
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

            //读取当前页的部门信息列表
            departList = departDAO.ListPageDepartment(page.PageNo, page.PageSize);
        }
    }
}