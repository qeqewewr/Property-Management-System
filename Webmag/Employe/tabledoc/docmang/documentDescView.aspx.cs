using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe.tabledoc.docmang;
using CEMIS.Util.Page;

public partial class Webmag_Employe_tabledoc_docmang_documentDescView : System.Web.UI.Page
{
    public DocDAO docDAO = new DocDAO();
    public Doc doc = new Doc();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["id"] != null && Request["id"].ToString().Trim() != "")
            {
                doc = docDAO.GetDoc(Request["id"].ToString().Trim());
            }
        }
    }
}