using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;

public partial class Webmag_Employe_officework_noticeann_DeleteNotice : System.Web.UI.Page
{
    public Notice notice;
    public NoticeDAO noticeDAO;
    public string pageno;
    public string id;

    protected void Page_Load(object sender, EventArgs e)
    {
        notice = new Notice();
        noticeDAO = new NoticeDAO();

        pageno = Request["pageno"];
        id = this.Request.QueryString["id"];

        if (Request["pageno"] != null && Request["pageno"].ToString().Trim() != "")
        {
            pageno = Request["pageno"].ToString().Trim();
            Response.Redirect("ViewNotice.aspx?pageno=" + Request["pageno"]);
        }
        else if (Request["selectDel"] != null && Request["selectDel"].ToString().Trim() != "")
        {
            DBConnection db = new DBConnection();
            string sql = "delete from Notice where ID IN (" + Request["selectDel"].ToString() + ");";
            sql += "delete from MyNotice where NoticeID IN (" + Request["selectDel"].ToString() + ");";

            int result = db.ExecuteNonQuery(sql);

            if (result > 0)
            {

               // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除成功！');location.href=('ViewNotice.aspx?pageno=" + pageno + "');</script>");
                Response.Write("<script>alert('删除成功');</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');</script>");
                //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "<script>alert('删除失败!');history.go(-1);</script>");
                
            }
            Response.Write("<script>window.location.href='ViewNotice.aspx';</script>");

        }

    }
}