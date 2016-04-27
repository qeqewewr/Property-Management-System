using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.tabledoc.docmang;
using CEMIS.Util.Page;


public partial class Webmag_Employe_tabledoc_docmang_docmanage : System.Web.UI.Page
{
    
    public List<Doc> doclist = new List<Doc>();
    public List<DocType> doctypelist = new List<DocType>();
    public DocDAO docDAO = new DocDAO();
    public DocTypeDAO doctypeDAO = new DocTypeDAO();
    public pageForm page = new pageForm();
    public string pageno;
    public string typeid;
    public string role;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            pageno = Request["pageno"];
            if (pageno == null) pageno = "1";
            page.RowCount = docDAO.GetTotalRecordNum();
            page.PageSize = 10;
            page.PageNo = int.Parse(pageno);

            //确定总的页面数
            int a = page.RowCount % page.PageSize;
            if (a == 0)
            {
                if (page.RowCount == 0)
                    page.PageCount = 1;
                else
                    page.PageCount = page.RowCount / page.PageSize;
            }
            else
                page.PageCount = page.RowCount / page.PageSize + 1;
            doctypelist = doctypeDAO.ListPageDocType();
            //读取当前页的部门信息列表
            if (Request["typeid"] != null && Request["typeid"].ToString().Trim() != "")
            {
                typeid = Request["typeid"].ToString().Trim();
                doclist = docDAO.ListPageDoc(page.PageNo, page.PageSize, typeid);

            }
            else
            {
                typeid = "";
                doclist = docDAO.ListPageDoc(page.PageNo, page.PageSize);
            }

        }
    }
}