using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;


public partial class Webmag_Employe_quitorder_UpdateQuitOrder : System.Web.UI.Page
{
    public string id;
    public QuitOrderDAO quitOrderDAO;
    public QuitOrder quitOrder;
    public string pageno;

    public string action;
    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            quitOrderDAO = new QuitOrderDAO();

            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];

            quitOrder = quitOrderDAO.GetQuitOrderById(id);
            action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
        }
    }
}