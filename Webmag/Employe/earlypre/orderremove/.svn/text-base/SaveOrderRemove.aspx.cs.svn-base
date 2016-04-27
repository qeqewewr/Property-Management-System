using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_earlypre_orderremove_SaveOrderRemove : System.Web.UI.Page
{
    public int pageno = -1;
    //要跳转页到的页名
    public string pageName = "ViewOrderRemove.aspx?pageno=1";
    public OrderMoveIn orderMoveIn,tempOrderMoveIn;
    public OrderMoveInDAO orderMoveInDAO;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            }
            orderMoveIn = new OrderMoveIn();
            tempOrderMoveIn = new OrderMoveIn();
            orderMoveInDAO = new OrderMoveInDAO();
            tempOrderMoveIn.BuildingName = Request.Form["orderRemoveBuildingName"].Trim();
            tempOrderMoveIn.Lessee = Request.Form["orderRemoveLessee"].Trim();
            tempOrderMoveIn.Room = Request.Form["orderRemoveRoom"].Trim();
            tempOrderMoveIn.Director = Request.Form["orderRemoveDirector"].Trim();
            tempOrderMoveIn.DirectorPhone = Request.Form["orderRemoveDirectorPhone"].Trim();
            tempOrderMoveIn.DateTime = Request.Form["orderRemoveDateTime"].Trim();
            if (Request.Form["orderRemoveGoodsNum"] != null && Request.Form["orderRemoveGoodsNum"] != "")
                tempOrderMoveIn.GoodsNum = int.Parse(Request.Form["orderRemoveGoodsNum"].Trim().ToString());
            else
                tempOrderMoveIn.GoodsNum = 0;
            tempOrderMoveIn.IsSure = (Request.Form["orderRemoveIsSure"].Trim() == "是") ? true : false;
            tempOrderMoveIn.Remarks = "";
            orderMoveIn = tempOrderMoveIn;
            int flag = orderMoveInDAO.AddOrderMoveIn(orderMoveIn);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 2);
        }
      
    }
}