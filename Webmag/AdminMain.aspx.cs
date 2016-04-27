using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Util;

public partial class Webmag_AdminMain : System.Web.UI.Page
{
	public string role;

    protected void Page_Load(object sender, EventArgs e)
    {
       // DBConnection db = new DBConnection();
		if (Session["UserName"] == null)
		{
			Response.Redirect("../IndexPage/Index.aspx");
			return;
		}
		else
		{
			role = Session["Role"].ToString();
		}

        
    }
}