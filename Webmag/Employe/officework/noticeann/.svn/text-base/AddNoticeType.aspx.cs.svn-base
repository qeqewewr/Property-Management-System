using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;
using CEMIS.Model.Employe.tabledoc.docmang;

public partial class Webmag_Employe_tabledoc_docmang_documentTypeAddaspx : System.Web.UI.Page
{
    public NoticeType noticeType = new NoticeType();
    public NoticeTypeDAO noticeTypeDAO = new NoticeTypeDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request.HttpMethod == "POST")
            {
                noticeType.Name = Request.Form["typename"].ToString().Trim();
                if (noticeType.Name == "")
                {
                    Response.Write("<script>alert('名称不能为空！')</script>");
                }
                else
                {
                    if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                    {
                        noticeType.ID = Request["id"].ToString().Trim();
                        int result = noticeTypeDAO.UpdateNoticeType(noticeType);
                        if (result > 0)
                            Response.Write("<script>alert('编辑成功！')</script>");
                        else
                            Response.Write("<script>alert('编辑失败！')</script>");
                    }
                    else
                    {
                        int result = noticeTypeDAO.AddNoticeType(noticeType);
                        if (result > 0)
                            Response.Write("<script>alert('添加成功！')</script>");
                        else
                            Response.Write("<script>alert('添加失败！')</script>");
                    }
                }


            }
            else
            {
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    noticeType = noticeTypeDAO.GetNoticeType(Request["id"].ToString().Trim());
                }

            }
        }
    }
}