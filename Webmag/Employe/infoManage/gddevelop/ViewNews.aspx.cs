using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.Model.Admin;


public partial class Webmag_Employe_infoManage_gddevelop_ViewNews : System.Web.UI.Page
{
    public List<News> newsList;
    public NewsDAO newsDAO;
    public pageForm page = new pageForm();
    public string pageno;
    public bool condition;//是否查询
    public string keyword;//查询关键字
    public AdminDAO adminDAO = new AdminDAO(); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            newsDAO = new NewsDAO();
            pageno = Request["pageno"].Trim();

            //查询情况
            if (Request["keyword"] != "" && Request["keyword"] != null)
            {
                keyword = Request["keyword"].Trim();
                condition = true;


                page.PageSize = 10;


                newsList = newsDAO.GetNewsByTitle(keyword, int.Parse(pageno), page.PageSize);

                page.RowCount = newsDAO.searchNum;
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
            //查看情况
            else
            {
                condition = false;

                page.RowCount = newsDAO.GetTotalRecordNum();
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

                newsList = new List<News>();
                newsList = newsDAO.ListPageNews(page.PageNo, page.PageSize);
            }
        }

    }
}