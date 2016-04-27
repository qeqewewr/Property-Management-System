using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_officework_orderwork_facebox : System.Web.UI.Page
{
    public string detail;
    public string id, flag;
    public OrderWorkDAO orderWorkDAO;
    public OrderWork orderWork;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            id = Request["id"];
            flag = Request["flag"];
            orderWorkDAO = new OrderWorkDAO();
            orderWork = orderWorkDAO.GetOrderWorkById(id);
            detail = (flag == "0") ? orderWork.Service : orderWork.Remark;
        }
    }
}