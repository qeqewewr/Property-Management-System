using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;

public partial class Webmag_Employe_officework_noticeann_ViewNotice : System.Web.UI.Page
{
    //租户费用
    public NoticeDAO noticeDAO = new NoticeDAO();
    public List<Notice> noticeList = new List<Notice>();
    //费用类型
    public NoticeTypeDAO noticeTypeDAO = new NoticeTypeDAO();
    public List<NoticeType> noticeTypeList;
    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;
    public string role;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            //从页面获取当前页号
            pageno = Request["pageno"];
            if (pageno == null) pageno = "1";
            //总行数
            page.RowCount = noticeDAO.GetTotalRecordNum();
            //每页显示的行数
            page.PageSize = 10;
            page.PageNo = int.Parse(pageno);
            int a = page.RowCount % page.PageSize;
            if (a == 0)
            {
                if (page.RowCount == 0)
                    page.PageCount = 1;//总页数
                else
                    page.PageCount = page.RowCount / page.PageSize;
            }
            else
                page.PageCount = page.RowCount / page.PageSize + 1;

            noticeTypeList = noticeTypeDAO.ListNoticeType();
            noticeList = noticeDAO.ListPageNotice(page.PageNo, page.PageSize);
        }
    }
}