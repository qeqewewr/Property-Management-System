using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Webmag_Employe_officework_orderwork_UpdateOrderWork : System.Web.UI.Page
{
    public string id;
    public OrderWork orderWork;
    public OrderWorkDAO orderWorkDAO;
    public string pageno;
    public string role;

    public string action;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            orderWorkDAO = new OrderWorkDAO();

            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];

            orderWork = orderWorkDAO.GetOrderWorkById(id);

            action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
        }
    }
}