using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;

public partial class Webmag_Employe_officework_orderwork_DoUpdate : System.Web.UI.Page
{

    //要跳转到的页面
    public string pageName = "ViewOrderWork.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flag = -1;
    OrderWork orderWork;
    OrderWorkDAO orderWorkDAO;

    private void GetOrderWork()
    {
        orderWork = orderWorkDAO.GetOrderWorkById(id);
        if (orderWork != null)
        {
            orderWork.DayStart = Request.Form["orderWorkDayStart"].Trim();
            orderWork.DayEnd = Request.Form["orderWorkDayEnd"].Trim();
            orderWork.TimeStart = "00:00:00"; //Request.Form["orderWorkTimeStart"].Trim();
            orderWork.TimeEnd = "00:00:00"; //Request.Form["orderWorkTimeEnd"].Trim();
            if (Request.Form["orderWorkNum"] != null && Request.Form["orderWorkNum"] != "")
                orderWork.Num = int.Parse(Request.Form["orderWorkNum"]);
            else
                orderWork.Num = 0;
            orderWork.Service = Request.Form["orderWorkService"].Trim();
            orderWork.Remark = Request.Form["orderWorkRemark"].Trim();
            if (Request.Form["orderWorkFee"] != null && Request.Form["orderWorkFee"] != "")
                orderWork.Fee = decimal.Parse(Request.Form["orderWorkFee"]);
            else
                orderWork.Fee = 0;
            orderWork.IsSure = (Request.Form["orderWorkIsSure"].Trim() == "是") ? true : false;
            flag = orderWorkDAO.UpdateOrderWork(orderWork);

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            orderWork = new OrderWork();
            orderWorkDAO = new OrderWorkDAO();
            pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = Request["oldid"].Trim().ToString();

            GetOrderWork();

            //页面重定向
            PageBLL pageBLL = new PageBLL();
            string action = (Request["action"] != null && Request["action"].ToString().Trim() != "") ? Request["action"].ToString().Trim() : "all";
            if (action == "all")
            {
                pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
            }
            else
            {
                pageName += "?action=" + action;
                pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
            }
            //pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
           
        }
    }
}