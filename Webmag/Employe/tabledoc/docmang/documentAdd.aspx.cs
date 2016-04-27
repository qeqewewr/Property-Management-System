using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;
using CEMIS.Model.Employe.tabledoc.docmang;

public partial class Webmag_Employe_tabledoc_uploaddoc_DocumentAdd : System.Web.UI.Page
{
    public Doc doc = new Doc();
    public List<DocType> doctypelist = new List<DocType>();
    public DocTypeDAO doctypedao = new DocTypeDAO();
    public DocDAO docDAO = new DocDAO();
    public string UploadPath = "../uploaddoc/";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            doctypelist = doctypedao.ListPageDocType();
            if (Request.HttpMethod == "POST")
            {
                doc.Title = Request.Form["title"].ToString().Trim();
                doc.FileName = Request.Form["filename"].ToString().Trim();
                doc.FileDesc = Request.Form["filedesc"].ToString().Trim();
                doc.FileUpDate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                doc.TypeID = Request.Form["typeid"].ToString().Trim();
                doc.TypeName = Request.Form["typename"].ToString().Trim();
                doc.UploadName = Request.Form["uploadname"].ToString().Trim();
                if (doc.Title == "" || doc.FileName == "" || doc.TypeID == "" || doc.TypeName == "" || doc.UploadName == "")
                {
                    Response.Write("<script>alert('加红参数不能为空，请重试')</script>");
                }
                else
                {
                    if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                    {
                        doc.ID = Request["id"].ToString().Trim();
                        doc.FileUrl = Request.Form["fileurl"].ToString().Trim();
                        int result = docDAO.UpdateDoc(doc);
                        if (result > 0)
                        {
                            Response.Write("<script>alert('编辑成功！')</script>");
                            Response.Write("<script>window.location.href='documentView.aspx'</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('编辑失败，请重试')</script>");
                        }
                    }
                    else
                    {
                        HttpPostedFile file = Request.Files["file"];
                        string nowdate = DateTime.Now.ToString("yyyy-MM-dd");
                        string nowtime = DateTime.Now.ToString("hh-mm-ss");
                        string serverpath = Server.MapPath(UploadPath) + nowdate;
                        string downpath = UploadPath + nowdate;
                        if (!Directory.Exists(serverpath)) Directory.CreateDirectory(serverpath);

                        string newfileName = nowtime + doc.FileName;

                        doc.FileUrl = downpath + "/" + newfileName;

                        file.SaveAs(System.IO.Path.Combine(serverpath, newfileName));

                        int result = docDAO.AddDoc(doc);

                        if (result > 0)
                        {
                            Response.Write("<script>alert('上传成功！')</script>");
                            Response.Write("<script>window.location.href='documentView.aspx'</script>");
                        }
                    
                        else
                            Response.Write("<script>alert('上传失败，请重试')</script>");
                        doc = new Doc();

                    }
                }



            }
            else
            {
                if (Request["id"] != null && Request["id"].ToString().Trim() != "")
                {
                    Doc d = docDAO.GetDoc(Request["id"].ToString().Trim());
                    if (d != null) doc = d;
                    Response.Write("<script>var action = 'eddit';</script>");
                    Response.Write("<script>var typeid = '" + d.TypeID + "';</script>");

                }


            }
        }
    }
}