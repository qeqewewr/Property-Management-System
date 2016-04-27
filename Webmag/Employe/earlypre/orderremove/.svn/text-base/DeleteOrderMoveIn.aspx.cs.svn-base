using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_earlypre_orderremove_DeleteOrderMoveIn : System.Web.UI.Page
{
    public string pageName = "ViewOrderRemove.aspx";
    public string id;
    public int pageno = 1;
    public OrderMoveIn orderMoveIn;
    public OrderMoveInDAO orderMoveInDAO;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            orderMoveInDAO = new OrderMoveInDAO();
            if (Request["pageno"] != null)
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = this.Request.QueryString["id"];

            int flag = orderMoveInDAO.DeleteOrderMoveInById(id);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 0);
        }
    }
}