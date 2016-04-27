using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util.Page;
using CEMIS.BLL;


public partial class Webmag_Employe_quitorder_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "ViewQuitOrder.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flag;
    //tempQuitOrder暂存从页面发送过来的更新的数据
    QuitOrder quitOrder, tempQuitOrder;
    QuitOrderDAO quitOrderDAO;
    public string action;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../IndexPage/Index.aspx");
        else
        {
            pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = Request["oldid"].Trim().ToString();

            tempQuitOrder = new QuitOrder();
            tempQuitOrder.Director = Request.Form["quitOrderDirector"].Trim();
            tempQuitOrder.DirectorPhone = Request.Form["quitOrderDirectorPhone"].Trim();
            tempQuitOrder.DateTime = Request.Form["quitOrderDateTime"].Trim();
            tempQuitOrder.GoodsNum = int.Parse(Request.Form["quitOrderGoodsNum"].Trim());
            string sure = Request.Form["quitOrderIsSure"].Trim();
            tempQuitOrder.IsSure = (sure.Equals("是") == true) ? true : false;
            tempQuitOrder.Remarks = Request.Form["quitOrderRemarks"].Trim();
            quitOrderDAO = new QuitOrderDAO();

            quitOrder = quitOrderDAO.GetQuitOrderById(id);
            if (quitOrder != null)
            {
                quitOrder.Director = tempQuitOrder.Director;
                quitOrder.DirectorPhone = tempQuitOrder.DirectorPhone;
                quitOrder.DateTime = tempQuitOrder.DateTime;
                quitOrder.GoodsNum = tempQuitOrder.GoodsNum;
                quitOrder.IsSure = tempQuitOrder.IsSure;
                quitOrder.Remarks = tempQuitOrder.Remarks;
                flag = quitOrderDAO.UpdateQuitOrder(quitOrder);
            }

            PageBLL pageBLL = new PageBLL();
            //页面重定向
            //pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
            action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
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