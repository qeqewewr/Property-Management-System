using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_officework_tenementcost_DoUpdate : System.Web.UI.Page
{
    //要跳转到的页面
    public string pageName = "ViewTenementCost.aspx";
    public int pageno;
    public string id;
    //用于标志更新是否成功
    public int flag = -1;
    TenementCost tenementCost;
    TenementCostDAO tenementCostDAO;
    TimeUntil timeUtil = new TimeUntil();

    private void GetTenementCost()
    {
        tenementCost = tenementCostDAO.GetTenementCostById(id);
        if (tenementCost != null)
        {
            tenementCost.FeeType = Request.Form["tenementCostFeeType"].Trim();
            if (Request.Form["tenementCostFee"] != null && Request.Form["tenementCostFee"] != "")
                tenementCost.Fee = decimal.Parse(Request.Form["tenementCostFee"].Trim());
            else
                tenementCost.Fee = 0;
         //   string month = Request.Form["tenementCostFeeMonth"].Trim();
          //  string year = Request.Form["tenementCostFeeYear"].Trim();
            tenementCost.InputDateTime = Request.Form["tenementCostInputDateTime"].Trim();
            tenementCost.InputEmployId = Request.Form["tenementCostInputEmployId"].Trim();
            tenementCost.Deadline = Request.Form["tenementCostDeadline"].Trim();
           // tenementCost.FeeMonth = year + "-" + timeUtil.GetMonthNumber(month);
           
            tenementCost.StartDate = Request.Form["tenementCostStartDate"].Trim();
            tenementCost.IsPayed = (Request.Form["tenementCostIsPayed"].ToString() == "是") ? true : false;
            flag = tenementCostDAO.UpdateTenementCost(tenementCost);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            tenementCost = new TenementCost();
            tenementCostDAO = new TenementCostDAO();
            pageno = int.Parse(Request["pageno"].Trim().ToString());
            id = Request["oldid"].Trim().ToString();

            GetTenementCost();

            //页面重定向
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 1);
        }
    }
}