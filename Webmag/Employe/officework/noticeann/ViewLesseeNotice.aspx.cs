using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.Util.Page;

public partial class Webmag_Employe_officework_noticeann_ViewLesseeNotice : System.Web.UI.Page
{
    //租户费用
    public MyNoticeDAO mynoticeDAO = new MyNoticeDAO();
    public List<MyNotice> mynoticeList = new List<MyNotice>();

    public List<Notice> noticelist = new List<Notice>();
    public NoticeDAO noticedao = new NoticeDAO();

    public List<NoticeType> noticetypelist = new List<NoticeType>();


    //数据库数据分页辅助类
    public pageForm page = new pageForm();
    //当前页面显示的页号
    public string pageno;

    public string building;

    public string room;

    public class MyNoticeDetail
    {
        public MyNotice myNotice;
        public Notice notice;
    }

    public List<MyNoticeDetail> MyNoticeDetailList = new List<MyNoticeDetail>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else if(Session["Role"] == "lessee")
        {
			string lessee = Session["UserName"].ToString();
			noticetypelist = (new NoticeTypeDAO()).ListNoticeType();
			//从页面获取当前页号
			pageno = Request["pageno"];
			if (pageno == null) pageno = "1";

			string action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
			if (action == "all")
			{
				page.RowCount = mynoticeDAO.GetTotalRecordNumByLessee(lessee);
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


				mynoticeList = mynoticeDAO.ListPageMyNoticeByLessee(page.PageNo, page.PageSize, lessee);
			}
			else if (action == "unread")
			{
				page.RowCount = mynoticeDAO.GetTotalUnReadRecordNumByLessee(lessee);
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

				mynoticeList = mynoticeDAO.ListPageMyUnReadNoticeByLessee(page.PageNo, page.PageSize, lessee);
			}
			for (int i = 0; i < mynoticeList.Count; i++)
			{
				Notice notice = noticedao.GetNotice(mynoticeList[i].NoticeID);
				MyNoticeDetail mynoticedetail = new MyNoticeDetail();
				mynoticedetail.myNotice = mynoticeList[i];
				mynoticedetail.notice = notice;
				MyNoticeDetailList.Add(mynoticedetail);
			}
        }

    }
}