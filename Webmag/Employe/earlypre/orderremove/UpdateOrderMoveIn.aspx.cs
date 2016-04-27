using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_earlypre_orderremove_UpdateOrderMoveIn : System.Web.UI.Page
{
    public string id;
    public OrderMoveInDAO orderMoveInDAO;
    public OrderMoveIn orderMoveIn;
    public string pageno;

    public string action;
    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            orderMoveInDAO = new OrderMoveInDAO();
            id = this.Request.QueryString["id"];
            pageno = Request["pageno"];

            orderMoveIn = orderMoveInDAO.GetOrderMoveInById(id);

            action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
        }
    }
}