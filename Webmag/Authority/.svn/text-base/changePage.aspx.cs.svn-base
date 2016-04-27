using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webmag_Authority_changePage : System.Web.UI.Page
{
    protected int pageno;
    protected int size;
    public string keyword;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../IndexPage/Index.aspx");
        else
        {
            size = 2;
            //查询关键字
            keyword = Request["comName"];


            if (Request.Form["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"]);
                Response.Redirect("ViewAuthority.aspx?pageno=" + pageno + "&keyword=" + keyword);
            }
        }
    }
}