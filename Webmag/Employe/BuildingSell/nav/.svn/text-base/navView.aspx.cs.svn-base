using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;


public partial class Webmag_Employe_tabledoc_docmang_docmanage : System.Web.UI.Page
{
    
    public List<Nav> navlist = new List<Nav>();

    public NavDAO navDAO = new NavDAO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            string state = (Request["state"] != null && Request["state"].ToString().Trim() != "") ? Request["state"].ToString().Trim() : "all";
            if (state == "all")
            {
                navlist = navDAO.ListNav();
            }
            else if (state == "enable")
            {
                navlist = navDAO.ListNav("1");
            }
            else if (state == "disable")
            {
                navlist = navDAO.ListNav("0");
            }
            for (int i = 0; i < navlist.Count; i++) navlist[i].Url = HttpUtility.UrlDecode(navlist[i].Url);
        }
    
             
    }


}