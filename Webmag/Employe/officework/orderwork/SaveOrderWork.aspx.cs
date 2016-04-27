using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_orderwork_SaveOrderWork : System.Web.UI.Page
{
    //要跳转到的页名
    public string pageName = "ViewOrderWork.aspx?pageno=1";
    public int pageno = -1;
    OrderWork orderWork;
    OrderWorkDAO orderWorkDAO;

    private OrderWork GetOrderWork()
    {
        OrderWork temp = new OrderWork();
        temp.Lessee = Request.Form["orderWorkLessee"].Trim();
        temp.BuildingName = Request.Form["orderWorkBuildingName"].Trim();
        temp.Room = Request.Form["orderWorkRoom"].Trim();
        temp.DayStart = Request.Form["orderWorkDayStart"].Trim();
        temp.DayEnd = Request.Form["orderWorkDayEnd"].Trim();
        //----测试
        temp.TimeStart = "00:00:00"; //Request.Form["orderWorkTimeStart"].Trim();
        temp.TimeEnd = "00:00:00"; // Request.Form["orderWorkTimeEnd"].Trim();
        if (Request.Form["orderWorkNum"] != null && Request.Form["orderWorkNum"] != "")
            temp.Num = int.Parse(Request.Form["orderWorkNum"]);
        else 
            temp.Num = 0;
        temp.Service = Request.Form["orderWorkService"].Trim();
        temp.Remark = Request.Form["orderWorkRemark"].Trim();
        if (Request.Form["orderWorkFee"] != null && Request.Form["orderWorkFee"] != "")
            temp.Fee = decimal.Parse(Request.Form["orderWorkFee"]);
        else
            temp.Fee = 0;
        temp.IsSure = (Request.Form["orderWorkIsSure"].Trim() == "是") ? true : false;
        return temp;
    }

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

            orderWorkDAO = new OrderWorkDAO();
            orderWork = GetOrderWork();

            int flag = orderWorkDAO.AddOrderWork(orderWork);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 2);
        }
    }
}