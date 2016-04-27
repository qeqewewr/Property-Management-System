using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;

public partial class Webmag_Employe_tabledoc_docmang_documentTypeDelete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pageno"] != null && Request["pageno"].ToString() != "")
            {
                Response.Redirect("documentTypeView.aspx?pageno=" + Request["pageno"]);
            }
            else if (Request["selectDel"] != null && Request["selectDel"] != "")
            {
                DBConnection db = new DBConnection();
                string sql = "delete from DocumentType where ID IN (" + Request["selectDel"].ToString() + ");";
                sql += "delete from Document where TypeID IN (" + Request["selectDel"].ToString() + ")";
                int result = db.ExecuteNonQuery(sql);
                if (result > 0)
                {
                    Response.Write("<script>alert('删除成功');</script>");
                }
                else
                {
                    Response.Write("<script>alert('删除失败');</script>");
                }
                Response.Write("<script>window.location.href='documentTypeView.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('参数无效，请重新操作');</script>");
                Response.Write("<script>window.location.href='documentTypeView.aspx';</script>");
            }
        }
    }
}