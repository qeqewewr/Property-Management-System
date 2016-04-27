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
    public DocType doctype = new DocType();
    public DocTypeDAO doctypedao = new DocTypeDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request.HttpMethod == "POST")
            {
                doctype.Name = Request.Form["typename"].ToString().Trim();
                if (doctype.Name == "")
                {
                    Response.Write("<script>alert('名称不能为空！')</script>");
                }
                else
                {
                    if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                    {
                        doctype.ID = Request["id"].ToString().Trim();
                        int result = doctypedao.UpdateDocType(doctype);
                        if (result > 0)
                            Response.Write("<script>alert('编辑成功！')</script>");
                        else
                            Response.Write("<script>alert('编辑失败！')</script>");
                    }
                    else
                    {
                        int result = doctypedao.AddDocType(doctype);
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
                    doctype = doctypedao.GetDocType(Request["id"].ToString().Trim());
                }

            }
        }

    }
}