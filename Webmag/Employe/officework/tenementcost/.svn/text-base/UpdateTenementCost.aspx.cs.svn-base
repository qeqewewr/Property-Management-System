using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.Util;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_tenementcost_UpdateTenementCost : System.Web.UI.Page
{
    public string id;
    public TenementCost tenementCost;
    public TenementCostDAO tenementCostDAO;
    public string pageno;

    public List<FeeType> feeTypeList;
    public FeeTypeDAO feeTypeDAO;

    public EmployeDAO employeDAO;
    public List<Employe> employeList;

    public TimeUntil timeUntil = new TimeUntil(); 
    public string[] month;
    public int[] year;

    public string role = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            tenementCostDAO = new TenementCostDAO();

            id = Request.QueryString["id"];
            pageno = Request["pageno"];

            feeTypeDAO = new FeeTypeDAO();
            feeTypeList = feeTypeDAO.ListFeeType();
            employeDAO = new EmployeDAO();
            employeList = employeDAO.ListEmploye();

            //月份辅助类
            month = timeUntil.GetMonthArray();
            year = timeUntil.GetYearArray();

            tenementCost = tenementCostDAO.GetTenementCostById(id);
        }
    }


}