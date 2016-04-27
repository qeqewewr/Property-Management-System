using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webmag_Employe_earlypre_fitmonitor_imagePage : System.Web.UI.Page
{
    public string url = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {

            url = Request["fileurl"].Trim();
        }
    }
}