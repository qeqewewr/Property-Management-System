using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.BLL;
using CEMIS.Model.Employe;
using CEMIS.Util;

public partial class Webmag_Employe_officework_tenementcost_AddTenementCost : System.Web.UI.Page
{
    public LesseeDAO lesseeDAO;
    public List<Lessee> lesseeList;

    public BuildingDAO buildingDAO;
    public List<Building> buildingList;

    public RoomDAO roomDAO;
    public List<Room> roomList;
    
    public FeeTypeDAO feeTypeDAO;
    public List<FeeType> feeTypeList;

    public EmployeDAO employeDAO;
    public List<Employe> employeList;

    public List<string> monthList;

    TimeUntil t;
    public string[] month;
    public int[] year;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            //用于在页面显示住户姓名
            lesseeDAO = new LesseeDAO();
            lesseeList = lesseeDAO.ListExistLessee();

            //用于在页面显示大楼名称
            buildingDAO = new BuildingDAO();
            buildingList = buildingDAO.ListBuilding();

            //用于在页面显示房间号
            roomDAO = new RoomDAO();
            roomList = roomDAO.ListRoom();

            //费用类型
            feeTypeDAO = new FeeTypeDAO();
            feeTypeList = feeTypeDAO.ListFeeType();

            //用于获得员工号
            employeDAO = new EmployeDAO();
            employeList = employeDAO.ListEmploye();

            //月份辅助类
            t = new TimeUntil();
            month = t.GetMonthArray();
            year = t.GetYearArray();
        }
    }
}
