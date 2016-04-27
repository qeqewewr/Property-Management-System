using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Util.Authority;

public partial class Webmag_Authority_ViewAuthority : System.Web.UI.Page
{
    private EmployeDAO employeDAO;
    public List<Employe> employeList;

    public pageForm page = new pageForm();
    public string pageno;//页码
    public string keyword;//查询关键字


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../IndexPage/Index.aspx");
        else
        {
            employeDAO = new EmployeDAO();
            pageno = Request["pageno"].Trim();
            //pageno = "1";
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {

                keyword = Request["keyword"].Trim();
                page.PageSize = 2;
                page.RowCount = employeDAO.GetWorkRecordNum();
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

                employeList = employeDAO.GetEmployeByName(keyword, 1, page.PageNo, page.PageSize);
            }
            else
            {

                page.RowCount = employeDAO.GetTotalRecordNum();
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

                employeList = employeDAO.ListPageEmploye(page.PageNo, page.PageSize, 1);
            }
        }

    }
}