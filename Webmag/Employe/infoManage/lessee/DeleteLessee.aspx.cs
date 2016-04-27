using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_infoManage_lessee_DeleteLessee : System.Web.UI.Page
{
    protected int id;
    public LesseeDAO lesseeDAO;
    public int pageno;
    public int pagesize;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            lesseeDAO = new LesseeDAO();

            pagesize = int.Parse(Request["pagesize"]);
            pageno = int.Parse(Request["pageno"]);
            id = int.Parse(Request["id"]);

            //如果最后一页只有一个数据则pageno减1
            int rowcount = lesseeDAO.GetTotalRecordNum();

            int a = rowcount % pagesize;
            int pagecount;

            if (a == 0)
            {
                if (rowcount == 0)
                    pagecount = 1;
                else
                    pagecount = rowcount / pagesize;
            }
            else
                pagecount = rowcount / pagesize + 1;
            if (pagecount == pageno && a == 1)
            {
                if (pageno != 1)
                    pageno--;
            }

            int flag = lesseeDAO.deleteLesseeByID(id);
            if (flag > 0)
            {

                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功！');location.href=('ViewLessee.aspx?pageno=" + pageno + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");
            }
        }

    }
}