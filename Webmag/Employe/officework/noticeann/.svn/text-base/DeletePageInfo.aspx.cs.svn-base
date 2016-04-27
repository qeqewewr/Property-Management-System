using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_officework_noticeann_DeletePageInfo : System.Web.UI.Page
{
    protected NoticeDAO noticeDAO;
    protected int pageno;
    protected int size;

    protected List<Notice> noticelist;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            size = int.Parse(Request["size"]);
            if (Request.Form["pageno"] != null)
            {
                string page = Request.Form["pageno"].Trim();
                pageno = int.Parse(page);
                Response.Redirect("ViewNotice.aspx?pageno=" + pageno + "");
            }
            else
            {
                pageno = int.Parse(Request["page"]);
                int flag = -1;
                int pagecount, i, a;

                noticeDAO = new NoticeDAO();
                noticelist = noticeDAO.ListPageNotice(pageno, size);
                int rowcount = noticeDAO.GetTotalRecordNum();

                for (i = 0; i < noticelist.Count; i++)
                {
                    flag = noticeDAO.DeleteNotice(noticelist[i].ID);
                    if (flag <= 0)
                        break;

                }
                a = rowcount % size;
                if (a == 0)
                {
                    if (rowcount == 0)
                        pagecount = 1;
                    else
                        pagecount = rowcount / size;
                }
                else
                    pagecount = rowcount / size + 1;
                if (pagecount == pageno)
                {
                    if (pageno != 1)
                        pageno--;
                }
                if (flag > 0)
                {

                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功!');location.href=('ViewNotice.aspx?pageno=" + pageno + "');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");

                }
            }
        }
    }
}