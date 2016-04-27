using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Util;

public partial class Webmag_Employe_officework_tenementcost_SaveTenementCost : System.Web.UI.Page
{
    public string pageName = "ViewTenementCost.aspx?pageno=1";
    public int pageno = -1;
    public TenementCost tenementCost, tempTenementCost;
    public TenementCostDAO tenementCostDAO;
    public TimeUntil timeUtil = new TimeUntil();

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
            tenementCost = new TenementCost();
            tempTenementCost = new TenementCost();
            tenementCostDAO = new TenementCostDAO();


            tempTenementCost.BuildingName = Request.Form["tenementCostBuildingName"].Trim();
            tempTenementCost.Lessee = Request.Form["tenementCostLessee"].Trim();
            tempTenementCost.Room = Request.Form["tenementCostRoom"].Trim();
            tempTenementCost.FeeType = Request.Form["tenementCostFeeType"].Trim();
            if (Request.Form["tenementCostFee"] != null && Request.Form["tenementCostFee"] != "")
                tempTenementCost.Fee = decimal.Parse(Request.Form["tenementCostFee"].Trim());
            else
                tempTenementCost.Fee = 0;
      //      string month = Request.Form["tenementCostFeeMonth"].Trim();
        //    string year = Request.Form["tenementCostFeeYear"].Trim();
            tempTenementCost.InputDateTime = Request.Form["tenementCostInputDateTime"].Trim();
            tempTenementCost.InputEmployId = Request.Form["tenementCostInputEmployId"].Trim();
            tempTenementCost.Deadline = Request.Form["tenementCostDeadline"].Trim();
            tempTenementCost.StartDate = Request.Form["tenementCostStartDate"].Trim();
            tempTenementCost.IsPayed = (Request.Form["tenementCostIsPayed"].ToString() == "是") ? true : false;
            tenementCost = tempTenementCost;

            int flag = tenementCostDAO.AddTenementCost(tenementCost);
            PageBLL pageBLL = new PageBLL();
            pageBLL.RedirectPage(this, pageName, flag, pageno, 2);
        }
    }
}