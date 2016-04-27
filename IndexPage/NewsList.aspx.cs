using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;

public partial class IndexPage_NewsList : System.Web.UI.Page
{
    public List<News> newsList=new List<News> ();
    public NewsDAO newsDAO = new NewsDAO();

    public pageForm page = new pageForm();
    public string pageno;

    protected void Page_Load(object sender, EventArgs e)
    {        
        pageno = Request["pageno"].ToString();

        page.PageSize=15;
        page.PageNo = int.Parse(pageno);
        page.RowCount = newsDAO.GetTotalRecordNum();

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

        newsList = newsDAO.ListPageNews(int.Parse(pageno), page.PageSize);

    }
}