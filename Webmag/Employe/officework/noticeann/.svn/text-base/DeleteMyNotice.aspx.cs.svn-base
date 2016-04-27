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
    public string building;
    public string room;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["building"] != null && Request["building"].ToString().Trim() != "" && Request["room"] != null && Request["room"].ToString().Trim() != "")
            {
                building = Request["building"].ToString().Trim();
                room = Request["room"].ToString().Trim();
            }

            if (Request["pageno"] != null && Request["pageno"].ToString() != "")
            {
                Response.Redirect("ViewMyNotice.aspx?pageno=" + Request["pageno"] + "&building=" + building + "&room=" + room);
            }
            else if (Request["selectDel"] != null && Request["selectDel"] != "")
            {
                DBConnection db = new DBConnection();
                string sql = "delete from MyNotice where ID IN (" + Request["selectDel"].ToString() + ");";

                int result = db.ExecuteNonQuery(sql);
                if (result > 0)
                {
                    Response.Write("<script>alert('删除成功');</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败');</script>");
                }
                Response.Write("<script>window.location.href='ViewMyNotice.aspx?building=" + building + "&room=" + room + "';</script>");
            }
            else
            {
                Response.Write("<script>alert('参数无效，请重新操作');</script>");
                Response.Write("<script>window.location.href='ViewMyNotice.aspx?building=" + building + "&room=" + room + "';</script>");
            }
        }
    }
}