using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_earlypre_orderremove_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "ViewOrderRemove.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flag;
    public string action;
    //tempOrderMoveIn暂存从页面发送过来的更新的数据
    OrderMoveIn orderMoveIn,tempOrderMoveIn;
    OrderMoveInDAO orderMoveInDAO;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = Request["oldid"].Trim().ToString();

            tempOrderMoveIn = new OrderMoveIn();
            tempOrderMoveIn.Director = Request.Form["orderMoveInDirector"].Trim();
            tempOrderMoveIn.DirectorPhone = Request.Form["orderMoveInDirectorPhone"].Trim();
            tempOrderMoveIn.DateTime = Request.Form["orderMoveInDateTime"].Trim();
            tempOrderMoveIn.GoodsNum = int.Parse(Request.Form["orderMoveInGoodsNum"].Trim().ToString());
            string sure = Request.Form["orderMoveInIsSure"].ToString();
            tempOrderMoveIn.IsSure = (sure.Equals("是") == true) ? true : false;
            tempOrderMoveIn.Remarks = Request.Form["orderMoveInRemarks"].Trim();
            orderMoveInDAO = new OrderMoveInDAO();

            orderMoveIn = orderMoveInDAO.GetOrderMoveInById(id);
            if (orderMoveIn != null)
            {
                orderMoveIn.Director = tempOrderMoveIn.Director;
                orderMoveIn.DirectorPhone = tempOrderMoveIn.DirectorPhone;
                orderMoveIn.DateTime = tempOrderMoveIn.DateTime;
                orderMoveIn.GoodsNum = tempOrderMoveIn.GoodsNum;
                orderMoveIn.IsSure = tempOrderMoveIn.IsSure;
                orderMoveIn.Remarks = tempOrderMoveIn.Remarks;
                flag = orderMoveInDAO.UpdateOrderMoveIn(orderMoveIn);
            }

            PageBLL pageBLL = new PageBLL();
        
            //页面重定向
            //pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
            action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim(): "all";
            if (action == "all")
            {
                pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
            }
            else
            {
                pageName += "?action=" + action;
                pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
            }
             
        }
    }
}