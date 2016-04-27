using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEMIS.Model.Employe;
using CEMIS.BLL;

public partial class Webmag_Employe_officework_repairtable_AddRepairTable : System.Web.UI.Page
{
    public LesseeDAO lesseeDAO=new LesseeDAO();
    public Lessee lessee=new Lessee();
    public List<Lessee> lesseeList;

    public BuildingDAO buildingDAO;
    public List<Building> buildingList;

    public RoomDAO roomDAO;
    public List<Room> roomList;

    public string role;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
            Response.Redirect("../../../../IndexPage/Index.aspx");
        else
        {
            role = Session["Role"].ToString();
            if (role == "property")
            {
                //用于在页面显示住户姓名
  
                lesseeList = lesseeDAO.ListExistLessee();      
            }
            else
            {
                string userName = Session["UserName"].ToString();
            //    lessee = lesseeDAO.GetLesseeByRoomNum(Session["UserName"].ToString());
                lessee = lesseeDAO.GetLesseeByName(userName);
            }
                     //用于在页面显示大楼名称
                buildingDAO = new BuildingDAO();
                buildingList = buildingDAO.ListBuilding();

                //用于在页面显示房间号
                roomDAO = new RoomDAO();
                roomList = roomDAO.ListRoom();
        }
    }
}