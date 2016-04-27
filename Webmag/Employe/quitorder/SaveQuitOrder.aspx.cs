using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;


public partial class Webmag_Employe_quitorder_SaveQuitOrder : System.Web.UI.Page
{
    public int pageno = -1;
    //要跳转页到的页名
    public string pageName = "ViewQuitOrder.aspx?pageno=1";
    public QuitOrder quitOrder, tempQuitOrder;
    public QuitOrderDAO quitOrderDAO;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            if (Request["pageno"] != null)
            {
                pageno = int.Parse(Request["pageno"].Trim().ToString());
            }
            quitOrder = new QuitOrder();
            tempQuitOrder = new QuitOrder();
            quitOrderDAO = new QuitOrderDAO();
            tempQuitOrder.BuildingName = Request.Form["quitOrderBuildingName"].Trim();
            tempQuitOrder.Lessee = Request.Form["quitOrderLessee"].Trim();
            tempQuitOrder.Room = Request.Form["quitOrderRoom"].Trim();
            tempQuitOrder.Director = Request.Form["quitOrderDirector"].Trim();
            tempQuitOrder.DirectorPhone = Request.Form["quitOrderDirectorPhone"].Trim();
            tempQuitOrder.DateTime = Request.Form["quitOrderDateTime"].Trim();
            if (Request.Form["quitOrderGoodsNum"] != null && Request.Form["quitOrderGoodsNum"] != "")
                tempQuitOrder.GoodsNum = int.Parse(Request.Form["quitOrderGoodsNum"].Trim().ToString());
            else
                tempQuitOrder.GoodsNum = 0;
            tempQuitOrder.IsSure = (Request.Form["quitOrderIsSure"].Trim() == "是") ? true : false;
            tempQuitOrder.Remarks = "";
            quitOrder = tempQuitOrder;
            int flag = quitOrderDAO.AddQuitOrder(quitOrder);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 2);

        }
    }
}